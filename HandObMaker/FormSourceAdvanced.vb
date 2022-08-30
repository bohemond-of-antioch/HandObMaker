Public Class FormSourceAdvanced
	Private Enum EOperationMode
		None
		Drag
		Resize
	End Enum


	Private GroupSelected As Integer = -1
	Private AreaSelected As Integer = -1
	Private DragPosition As Point
	Private ResizeMode As Integer = 0

	Private OperationMode As EOperationMode

	Private Const DetailScale As Integer = 6

	Private Sub RefreshOutput()
		ImageSource.Invalidate()
	End Sub

	Private Sub FormSourceAdvanced_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		ImageSource.Width = BigObWidth * 6
		ImageSource.Height = BigObHeight * 6

		Group0Color.BackColor = MainWindowPtr.ThicknessGroups(0).Color
		Group1Color.BackColor = MainWindowPtr.ThicknessGroups(1).Color

		CheckBoxGroup0Enabled.Checked = MainWindowPtr.ThicknessGroups(0).Enabled
		CheckBoxGroup1Enabled.Checked = MainWindowPtr.ThicknessGroups(1).Enabled

		TextBoxGroup0Thickness.Text = Trim(Str(MainWindowPtr.ThicknessGroups(0).Thickness))
		TextBoxGroup1Thickness.Text = Trim(Str(MainWindowPtr.ThicknessGroups(1).Thickness))

		TextBoxFrontPenetration.Text = Trim(Str(MainWindowPtr.FrontImagePenetration))
		TextBoxRearPenetration.Text = Trim(Str(MainWindowPtr.RearImagePenetration))
	End Sub

	Private Sub ImageSource_Paint(sender As Object, e As PaintEventArgs) Handles ImageSource.Paint
		If MainWindowPtr.GetSourceImage Is Nothing Then Exit Sub

		Dim G As Graphics
		G = e.Graphics
		Try
			BitmapUtils.BlitNx(G, MainWindowPtr.GetSourceImage, 0, 0, DetailScale)
			For GroupIndex = 0 To MainWindowPtr.ThicknessGroups.Length - 1
				Dim Group = MainWindowPtr.ThicknessGroups(GroupIndex)
				If Group.Enabled = False Then Continue For
				Dim GroupBrush As Brush
				GroupBrush = New SolidBrush(Color.FromArgb(150, Group.Color.R, Group.Color.G, Group.Color.B))
				Dim SelectionPen As Pen
				SelectionPen = New Pen(New SolidBrush(Color.FromArgb(255, Group.Color.R, Group.Color.G, Group.Color.B)))
				SelectionPen.Width = 2

				For a = 0 To Group.Areas.Count - 1
					G.FillRectangle(GroupBrush, Group.Areas(a).Left * DetailScale, Group.Areas(a).Top * DetailScale, Group.Areas(a).Width * DetailScale, Group.Areas(a).Height * DetailScale)
					If GroupSelected = GroupIndex And AreaSelected = a Then
						G.DrawRectangle(SelectionPen, Group.Areas(a).Left * DetailScale, Group.Areas(a).Top * DetailScale, Group.Areas(a).Width * DetailScale, Group.Areas(a).Height * DetailScale)
					End If
				Next a
			Next
		Catch ex As Exception
			Debug.Print(ex.StackTrace)
		End Try

	End Sub

	Private Sub TextBoxGroupThickness_TextChanged(sender As Object, e As EventArgs) Handles TextBoxGroup0Thickness.TextChanged, TextBoxGroup1Thickness.TextChanged
		Dim Group As Integer
		Group = Val(CType(sender, Control).Tag)
		Dim Element = CType(sender, TextBox)
		If Element.Text = "" Then Exit Sub
		'If Val(Element.Text) > Val(MainWindowPtr.TextBoxThickness.Text) Then
		'    Element.Text = MainWindowPtr.TextBoxThickness.Text
		'End If
		MainWindowPtr.ThicknessGroups(Group).Thickness = Val(Element.Text)
		MainWindowPtr.RefreshDestinations()
	End Sub

	Private Sub ButtonGroupCreateArea_Click(sender As Object, e As EventArgs) Handles ButtonGroup0CreateArea.Click, ButtonGroup1CreateArea.Click
		Dim Group As Integer
		Group = Val(CType(sender, Control).Tag)
		MainWindowPtr.ThicknessGroups(Group).AddArea(New ThicknessGroup.Box(10, 10, 20, 20))
		RefreshOutput()
		MainWindowPtr.RefreshDestinations()
	End Sub
	Private Sub ButtonGroupClear_Click(sender As Object, e As EventArgs) Handles ButtonGroup0Clear.Click, ButtonGroup1Clear.Click
		Dim Group As Integer
		Group = Val(CType(sender, Control).Tag)
		MainWindowPtr.ThicknessGroups(Group).Areas.Clear()
		RefreshOutput()
		MainWindowPtr.RefreshDestinations()
	End Sub

	Private Sub CheckBoxGroupEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGroup0Enabled.CheckedChanged, CheckBoxGroup1Enabled.CheckedChanged
		Dim Group As Integer
		Dim Element = CType(sender, CheckBox)
		Group = Val(Element.Tag)
		MainWindowPtr.ThicknessGroups(Group).Enabled = Element.Checked
		RefreshOutput()
		MainWindowPtr.RefreshDestinations()
	End Sub

	Private Function TransformPosition(Position As Point) As Point
		Return New Point(Position.X \ DetailScale, Position.Y \ DetailScale)
	End Function

	Private Sub ImageSource_MouseDown(sender As Object, e As MouseEventArgs) Handles ImageSource.MouseDown
		For GroupIndex = 0 To MainWindowPtr.ThicknessGroups.Length - 1
			Dim Group = MainWindowPtr.ThicknessGroups(GroupIndex)
			If Group.Enabled = False Then Continue For
			Dim Area As Integer
			Area = Group.AreaAtPosition(TransformPosition(e.Location))
			If Area <> -1 Then
				GroupSelected = GroupIndex
				AreaSelected = Area
				Exit For
			End If
		Next

		If GroupSelected <> -1 Then
			For GroupIndex = 0 To MainWindowPtr.ThicknessGroups.Length - 1
				Dim Group = MainWindowPtr.ThicknessGroups(GroupIndex)
				If Group.Enabled = False Then Continue For
				Dim Area As Integer
				Area = Group.AreaAtPosition(TransformPosition(e.Location))
				If Area <> -1 Then
					' possible drag or resize
					If GroupIndex = GroupSelected And Area = AreaSelected Then
						Dim PointerPosition = TransformPosition(e.Location)
						ResizeMode = 0
						If PointerPosition.X = Group.Areas(Area).Left Then
							ResizeMode = ResizeMode Or 1
						ElseIf PointerPosition.X = Group.Areas(Area).Right Then
							ResizeMode = ResizeMode Or 2
						End If
						If PointerPosition.Y = Group.Areas(Area).Top Then
							ResizeMode = ResizeMode Or 4
						ElseIf PointerPosition.Y = Group.Areas(Area).Bottom Then
							ResizeMode = ResizeMode Or 8
						End If
						If ResizeMode = 0 Then
							DragPosition = Group.Areas(Area).Location - TransformPosition(e.Location)
							OperationMode = EOperationMode.Drag
						Else
							OperationMode = EOperationMode.Resize
						End If
						Exit Sub
					End If
				End If
			Next
		End If
		OperationMode = EOperationMode.None
	End Sub

	Private Sub ImageSource_MouseUp(sender As Object, e As MouseEventArgs) Handles ImageSource.MouseUp
		GroupSelected = -1
		AreaSelected = -1
		For GroupIndex = 0 To MainWindowPtr.ThicknessGroups.Length - 1
			Dim Group = MainWindowPtr.ThicknessGroups(GroupIndex)
			If Group.Enabled = False Then Continue For
			Dim Area As Integer
			Area = Group.AreaAtPosition(TransformPosition(e.Location))
			If Area <> -1 Then
				GroupSelected = GroupIndex
				AreaSelected = Area
				Exit For
			End If
		Next
		If OperationMode <> EOperationMode.None Then
			OperationMode = EOperationMode.None
			ResizeMode = 0
			MainWindowPtr.RefreshDestinations()
		End If
		RefreshOutput()
	End Sub

	Private Sub ImageSource_MouseMove(sender As Object, e As MouseEventArgs) Handles ImageSource.MouseMove
		If OperationMode = EOperationMode.Drag Then
			MainWindowPtr.ThicknessGroups(GroupSelected).Areas(AreaSelected).Relocate(TransformPosition(e.Location) + DragPosition)
			RefreshOutput()
		ElseIf OperationMode = EOperationMode.Resize Then
			Dim PointerPosition = TransformPosition(e.Location)
			If (ResizeMode And 1) <> 0 Then
				MainWindowPtr.ThicknessGroups(GroupSelected).Areas(AreaSelected).Left = PointerPosition.X
			End If
			If (ResizeMode And 2) <> 0 Then
				MainWindowPtr.ThicknessGroups(GroupSelected).Areas(AreaSelected).Right = PointerPosition.X
			End If
			If (ResizeMode And 4) <> 0 Then
				MainWindowPtr.ThicknessGroups(GroupSelected).Areas(AreaSelected).Top = PointerPosition.Y
			End If
			If (ResizeMode And 8) <> 0 Then
				MainWindowPtr.ThicknessGroups(GroupSelected).Areas(AreaSelected).Bottom = PointerPosition.Y
			End If
			If MainWindowPtr.ThicknessGroups(GroupSelected).Areas(AreaSelected).Repair() Then
				GroupSelected = -1
				AreaSelected = -1
				OperationMode = EOperationMode.None
			End If
			RefreshOutput()
		End If

	End Sub
	Private Sub ImageFront_Paint(sender As Object, e As PaintEventArgs) Handles ImageFront.Paint
		If MainWindowPtr.FrontImage Is Nothing Then Exit Sub
		Dim G As Graphics
		G = e.Graphics
		BitmapUtils.BlitNx(G, MainWindowPtr.FrontImage, 0, 0)
	End Sub

	Private Sub ImageRear_Paint(sender As Object, e As PaintEventArgs) Handles ImageRear.Paint
		If MainWindowPtr.RearImage Is Nothing Then Exit Sub
		Dim G As Graphics
		G = e.Graphics
		BitmapUtils.BlitNx(G, MainWindowPtr.RearImage, 0, 0)
	End Sub
	Private Sub ButtonLoadFront_Click(sender As Object, e As EventArgs) Handles ButtonLoadFront.Click
		Dim OpenFileDialog As New OpenFileDialog
		OpenFileDialog.Filter = "Image Files (*.bmp,*.png,*.gif)|*.bmp;*.png;*.gif|All Files (*.*)|*.*"
		OpenFileDialog.Multiselect = False
		If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String
			FileName = OpenFileDialog.FileName
			MainWindowPtr.LoadFrontImage(FileName)
		End If
	End Sub
	Private Sub ButtonLoadRear_Click(sender As Object, e As EventArgs) Handles ButtonLoadRear.Click
		Dim OpenFileDialog As New OpenFileDialog
		OpenFileDialog.Filter = "Image Files (*.bmp,*.png,*.gif)|*.bmp;*.png;*.gif|All Files (*.*)|*.*"
		OpenFileDialog.Multiselect = False
		If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String
			FileName = OpenFileDialog.FileName
			MainWindowPtr.LoadRearImage(FileName)
		End If
	End Sub
	Private Sub ButtonReloadFront_Click(sender As Object, e As EventArgs) Handles ButtonReloadFront.Click
		If MainWindowPtr.LoadedFrontImage = "" Then Exit Sub
		MainWindowPtr.LoadFrontImage(MainWindowPtr.LoadedFrontImage)
	End Sub

	Private Sub ButtonReloadRear_Click(sender As Object, e As EventArgs) Handles ButtonReloadRear.Click
		If MainWindowPtr.LoadedRearImage = "" Then Exit Sub
		MainWindowPtr.LoadRearImage(MainWindowPtr.LoadedRearImage)
	End Sub
	Private Sub ButtonUnloadFront_Click(sender As Object, e As EventArgs) Handles ButtonUnloadFront.Click
		MainWindowPtr.FrontImage = Nothing
		MainWindowPtr.LoadedFrontImage = Nothing
		ImageFront.Invalidate()
		MainWindowPtr.RefreshDestinations()
	End Sub
	Private Sub ButtonGenerateFront_Click(sender As Object, e As EventArgs) Handles ButtonGenerateFront.Click
		If MainWindowPtr.GetSourceImage Is Nothing Then Exit Sub
		Dim FrameParameters As IsometricFrameParameters
		FrameParameters = MainWindowPtr.GatherFrameParameters()
		If FrameParameters Is Nothing Then
			MsgBox("Could not render with the selected parameters.", MsgBoxStyle.Critical)
			Exit Sub
		End If
		Dim Size As IntVector3
		Size = Hl.CalculateLayeredSize(FrameParameters)
		Dim SourceImage As LayeredBitmap = New LayeredBitmap(MainWindowPtr.GetSourceImage, Size, FrameParameters.ItemThickness, FrameParameters.ThicknessGroups)
		Dim Surface = SourceImage.GenerateSurface(EEdge.Front)
		Dim FrontTexture As Bitmap = New Bitmap(Size.Z, Size.X)
		For x = 0 To Size.X - 1
			For z = 0 To Size.Z - 1
				FrontTexture.SetPixel(z, x, SourceImage.GetPixel(x, Surface(x, z), z))
			Next z
		Next x
		MainWindowPtr.SetFrontImage(FrontTexture)
		Clipboard.SetImage(FrontTexture)
	End Sub
	Private Sub ButtonGenerateRear_Click(sender As Object, e As EventArgs) Handles ButtonGenerateRear.Click
		If MainWindowPtr.GetSourceImage Is Nothing Then Exit Sub
		Dim FrameParameters As IsometricFrameParameters
		FrameParameters = MainWindowPtr.GatherFrameParameters()
		If FrameParameters Is Nothing Then
			MsgBox("Could not render with the selected parameters.", MsgBoxStyle.Critical)
			Exit Sub
		End If
		Dim Size As IntVector3
		Size = Hl.CalculateLayeredSize(FrameParameters)
		Dim SourceImage As LayeredBitmap = New LayeredBitmap(MainWindowPtr.GetSourceImage, Size, FrameParameters.ItemThickness, FrameParameters.ThicknessGroups)
		Dim Surface = SourceImage.GenerateSurface(EEdge.Rear)
		Dim RearTexture As Bitmap = New Bitmap(Size.Z, Size.X)
		For x = 0 To Size.X - 1
			For z = 0 To Size.Z - 1
				RearTexture.SetPixel(z, x, SourceImage.GetPixel(x, Surface(x, z), z))
			Next z
		Next x
		MainWindowPtr.SetRearImage(RearTexture)
		Clipboard.SetImage(RearTexture)
	End Sub


	Private Sub ButtonUnloadRear_Click(sender As Object, e As EventArgs) Handles ButtonUnloadRear.Click
		MainWindowPtr.RearImage = Nothing
		MainWindowPtr.LoadedRearImage = Nothing
		ImageRear.Invalidate()
		MainWindowPtr.RefreshDestinations()
	End Sub

	Private Sub FormSourceAdvanced_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
		If e.KeyCode = Keys.Delete Then
			If GroupSelected <> -1 And AreaSelected <> -1 Then
				MainWindowPtr.ThicknessGroups(GroupSelected).RemoveArea(AreaSelected)
				GroupSelected = -1
				AreaSelected = -1
				RefreshOutput()
				MainWindowPtr.RefreshDestinations()
			End If
		End If
	End Sub

	Private Sub TextBoxFrontPenetration_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFrontPenetration.TextChanged
		MainWindowPtr.FrontImagePenetration = Val(TextBoxFrontPenetration.Text)
		MainWindowPtr.RefreshDestinations()
	End Sub

	Private Sub TextBoxRearPenetration_TextChanged(sender As Object, e As EventArgs) Handles TextBoxRearPenetration.TextChanged
		MainWindowPtr.RearImagePenetration = Val(TextBoxRearPenetration.Text)
		MainWindowPtr.RefreshDestinations()
	End Sub
End Class