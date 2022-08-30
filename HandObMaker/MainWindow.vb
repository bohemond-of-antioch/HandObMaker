Public Class MainWindow
	Private BigObImage As Bitmap = Nothing
	Public FrontImage As Bitmap = Nothing
	Public RearImage As Bitmap = Nothing
	Private HandPosition As Point
	Private AdvancedWindow As FormSourceAdvanced

	Private LoadedBigOb As String
	Public LoadedFrontImage As String
	Public LoadedRearImage As String
	Public FrontImagePenetration As Integer = 1
	Public RearImagePenetration As Integer = 1

	Public ThicknessGroups As ThicknessGroup()
	Private LoadingFileInProgress = False

	Friend Function GetSourceImage() As Bitmap
		Return BigObImage
	End Function

	Friend Sub SetThickness(Value As String)
		TextBoxThickness.Text = Value
	End Sub

	Friend Sub LoadSourceImage(FileName As String)
		If Not BigObImage Is Nothing Then
			BigObImage.Dispose()
		End If
		Try
			BigObImage = BitmapUtils.UnboundImageFromFile(FileName)
			LoadedBigOb = FileName
			If BigObImage.Width > BigObWidth Or BigObImage.Height > BigObHeight Then
				MsgBox("Image is too large. Maximum is 32x48.", MsgBoxStyle.Critical)
				BigObImage = Nothing
			Else
				Dim ItemSize = Hl.CalculateItemSize(BigObImage)
				TextBoxItemWidth.Text = Trim(Str(ItemSize.Width))
				TextBoxItemHeight.Text = Trim(Str(ItemSize.Height))
			End If
		Catch ex As Exception
			MsgBox("Could not load image.", MsgBoxStyle.Critical)
			Debug.Print(ex.StackTrace)
			BigObImage = Nothing
		Finally
			ImageSource.Invalidate()
			RefreshDestinations()
		End Try
	End Sub
	Friend Sub SetFrontImage(Source As Bitmap)
		If Not FrontImage Is Nothing Then
			FrontImage.Dispose()
		End If
		FrontImage = Source
		If Not AdvancedWindow Is Nothing Then
			AdvancedWindow.ImageFront.Width = FrontImage.Width * 3 + 2
			AdvancedWindow.ImageFront.Height = FrontImage.Height * 3 + 2
		End If
		If Not AdvancedWindow Is Nothing Then AdvancedWindow.ImageFront.Invalidate()
		RefreshDestinations()
	End Sub
	Friend Sub LoadFrontImage(FileName As String)
		If Not FrontImage Is Nothing Then
			FrontImage.Dispose()
		End If
		Try
			FrontImage = BitmapUtils.UnboundImageFromFile(FileName)
			LoadedFrontImage = FileName
			If FrontImage.Width > BigObWidth Or FrontImage.Height > BigObHeight Then
				MsgBox("Image is too large. Maximum is 32x48.", MsgBoxStyle.Critical)
				LoadedFrontImage = Nothing
				FrontImage = Nothing
			Else
				If Not AdvancedWindow Is Nothing Then
					AdvancedWindow.ImageFront.Width = FrontImage.Width * 3 + 2
					AdvancedWindow.ImageFront.Height = FrontImage.Height * 3 + 2
				End If
			End If
		Catch
			MsgBox("Could not load image.", MsgBoxStyle.Critical)
			LoadedFrontImage = Nothing
			FrontImage = Nothing
		Finally
			If Not AdvancedWindow Is Nothing Then AdvancedWindow.ImageFront.Invalidate()
			RefreshDestinations()
		End Try
	End Sub
	Friend Sub SetRearImage(Source As Bitmap)
		If Not RearImage Is Nothing Then
			RearImage.Dispose()
		End If
		RearImage = Source
		If Not AdvancedWindow Is Nothing Then
			AdvancedWindow.ImageRear.Width = RearImage.Width * 3 + 2
			AdvancedWindow.ImageRear.Height = RearImage.Height * 3 + 2
		End If
		If Not AdvancedWindow Is Nothing Then AdvancedWindow.ImageRear.Invalidate()
		RefreshDestinations()
	End Sub
	Friend Sub LoadRearImage(FileName As String)
		If Not RearImage Is Nothing Then
			RearImage.Dispose()
		End If
		Try
			RearImage = BitmapUtils.UnboundImageFromFile(FileName)
			LoadedRearImage = FileName
			If RearImage.Width > BigObWidth Or RearImage.Height > BigObHeight Then
				MsgBox("Image is too large. Maximum is 32x48.", MsgBoxStyle.Critical)
				LoadedRearImage = Nothing
				RearImage = Nothing
			Else
				If Not AdvancedWindow Is Nothing Then
					AdvancedWindow.ImageRear.Width = RearImage.Width * 3 + 2
					AdvancedWindow.ImageRear.Height = RearImage.Height * 3 + 2
				End If
			End If
		Catch
			MsgBox("Could not load image.", MsgBoxStyle.Critical)
			LoadedRearImage = Nothing
			RearImage = Nothing
		Finally
			If Not AdvancedWindow Is Nothing Then AdvancedWindow.ImageRear.Invalidate()
			RefreshDestinations()
		End Try
	End Sub

	Private Sub ButtonReloadSourceImage_Click(sender As Object, e As EventArgs) Handles ButtonReloadSourceImage.Click
		If LoadedBigOb = "" Then Exit Sub
		LoadSourceImage(LoadedBigOb)
	End Sub
	Private Sub ButtonLoadSource_Click(sender As Object, e As EventArgs) Handles ButtonLoadSource.Click
		Dim OpenFileDialog As New OpenFileDialog
		OpenFileDialog.Filter = "Image Files (*.bmp,*.png,*.gif)|*.bmp;*.png;*.gif|All Files (*.*)|*.*"
		OpenFileDialog.Multiselect = False
		If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String
			FileName = OpenFileDialog.FileName
			LoadSourceImage(FileName)
		End If
	End Sub
	Private Sub ImageSource_Paint(sender As Object, e As PaintEventArgs) Handles ImageSource.Paint
		If BigObImage Is Nothing Then Exit Sub
		Dim G As Graphics
		G = e.Graphics
		BitmapUtils.BlitNx(G, BigObImage, 0, 0)
		G.DrawLine(Pens.Gray, 0, HandPosition.Y * 3 + 1, ImageSource.Width, HandPosition.Y * 3 + 1)
		G.DrawLine(Pens.Gray, HandPosition.X * 3 + 1, 0, HandPosition.X * 3 + 1, ImageSource.Height)
	End Sub

	Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Hl.MainWindowPtr = Me

		ImageSource.Width = BigObWidth * 3
		ImageSource.Height = BigObHeight * 3

		ImageDestinationHandOb.Width = HandObWidth * 8 * 3
		ImageDestinationHandOb.Height = HandObHeight * 3

		ImageDestinationFloorOb.Width = HandObWidth * 3
		ImageDestinationFloorOb.Height = HandObHeight * 3

		ReDim ThicknessGroups(1)
		ThicknessGroups(0) = New ThicknessGroup(Color.White)
		ThicknessGroups(1) = New ThicknessGroup(Color.Magenta)


		ComboBoxColoringMethod.Items.Clear()
		For Each N In System.Enum.GetNames(GetType(BitmapUtils.EColoringMethod))
			ComboBoxColoringMethod.Items.Add(N)
		Next
		ComboBoxColoringMethod.SelectedIndex = 0

		If Not My.Settings.RecentFiles Is Nothing Then
			For Each RecentFilepath In My.Settings.RecentFiles
				Dim NewRecentFileItem As RecentFileItem
				Try
					NewRecentFileItem = New RecentFileItem(RecentFilepath)
					ListBoxRecentFiles.Items.Add(NewRecentFileItem)
				Catch ex As Exception

				End Try
			Next
		End If

	End Sub
	Friend Function GatherFrameParameters() As IsometricFrameParameters
		If BigObImage Is Nothing Then Return Nothing
		If Val(TextBoxThickness.Text) < 1 Then Return Nothing
		If Val(TextBoxItemHeight.Text) < 1 Then Return Nothing
		If Val(TextBoxItemWidth.Text) < 1 Then Return Nothing
		If Val(TextBoxScalingFactor.Text) < 1 Then Return Nothing

		Dim FrameParameters As New IsometricFrameParameters
		With FrameParameters
			.HandPosition = HandPosition
			.TwoHanded = CheckBoxTwoHanded.Checked
			.Horizontal = CheckBoxHorizontal.Checked
			.Scale = Val(TextBoxScalingFactor.Text) / 100
			.VerticalAspect = Val(TextBoxVerticalAspect.Text) / 100
			.ItemSize = New Size(Val(TextBoxItemWidth.Text), Val(TextBoxItemHeight.Text))
			.ItemThickness = Val(TextBoxThickness.Text)
			.ColoringMethod = ComboBoxColoringMethod.SelectedIndex
			.ShadedCenterline = CheckBoxShadedCenterline.Checked
			.MaskHand = CheckBoxMaskHand.Checked
			.HandSize = Val(TextBoxHandSize.Text)
			.OverrideMask3 = CheckBoxOverrideMask3.Checked
			.ColoringAverage.Radius = Val(TextBoxAvgRadius.Text)
			.ColoringAverage.RadiusWeight = Val(TextBoxAvgRadiusWeight.Text)
			.ColoringAverage.RadiusWeightFalloff = Val(TextBoxAvgRadiusFalloff.Text)
			.ColoringAverage.TransparencyCutoff = Val(TextBoxAvgTransparencyCutoff.Text)
			.FrontImage = FrontImage
			.RearImage = RearImage
			.FrontImagePenetration = FrontImagePenetration
			.RearImagePenetration = RearImagePenetration
			.ThicknessGroups = ThicknessGroups
		End With
		Return FrameParameters
	End Function
	Private Function GatherFloorFrameParameters() As IsometricFrameParameters
		Dim FrameParameters As New IsometricFrameParameters
		FrameParameters = GatherFrameParameters()
		If FrameParameters Is Nothing Then Return Nothing

		FrameParameters.Scale = Val(TextBoxFloorObScale.Text) / 100
		FrameParameters.Horizontal = CheckBoxFloorObHorizontal.Checked
		FrameParameters.TwoHanded = True

		Dim BoundingBox = CalculateImageBoundingBox(BigObImage)

		FrameParameters.HandPosition = New Point(BoundingBox.X + BoundingBox.Width / 2, BoundingBox.Y + BoundingBox.Height / 2)

		Return FrameParameters
	End Function
	Private Sub ButtonExportHandObXComPalette_Click(sender As Object, e As EventArgs) Handles ButtonExportHandObXComPalette.Click
		Dim SaveFileDialog As New SaveFileDialog

		SaveFileDialog.Filter = "PNG file (*.png)|*.png|All Files (*.*)|*.*"

		If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String = SaveFileDialog.FileName
			Try
				Dim GeneratedImage = GenerateExportImage()
				Dim ExportImage = BitmapUtils.ConvertToPalette(GeneratedImage, My.Resources.UFOBattlescapePalette.Palette)
				ExportImage.Save(FileName)
			Catch ex As Exception
				MsgBox(ex.Message, MsgBoxStyle.Critical)
			End Try
		End If
	End Sub
	Private Sub ButtonExportHandObTFTDPalette_Click(sender As Object, e As EventArgs) Handles ButtonExportHandObTFTDPalette.Click
		Dim SaveFileDialog As New SaveFileDialog

		SaveFileDialog.Filter = "PNG file (*.png)|*.png|All Files (*.*)|*.*"

		If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String = SaveFileDialog.FileName
			Try
				Dim GeneratedImage = GenerateExportImage()
				Dim ExportImage = BitmapUtils.ConvertToPalette(GeneratedImage, My.Resources.TFTDBattlescapePalette.Palette)
				ExportImage.Save(FileName)
			Catch ex As Exception
				MsgBox(ex.Message, MsgBoxStyle.Critical)
			End Try
		End If
	End Sub

	Private Sub ButtonExportHandOb_Click(sender As Object, e As EventArgs) Handles ButtonExportHandOb.Click
		Dim SaveFileDialog As New SaveFileDialog

		SaveFileDialog.Filter = "PNG file (*.png)|*.png|All Files (*.*)|*.*"

		If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String = SaveFileDialog.FileName
			Try
				Dim ExportImage = GenerateExportImage()
				ExportImage.Save(FileName)
			Catch ex As Exception
				MsgBox(ex.Message, MsgBoxStyle.Critical)
			End Try
		End If
	End Sub

	Public Function GenerateExportImage() As Bitmap
		Dim FrameParameters As IsometricFrameParameters
		FrameParameters = GatherFrameParameters()
		If FrameParameters Is Nothing Then
			'MsgBox("Could not render with the selected parameters.", MsgBoxStyle.Critical)
			Throw New Exception("Could not render with the selected parameters.")
		End If

		Dim ExportImage = New Bitmap(HandObWidth * 8, HandObHeight)

		'ExportImage.Palette = My.Resources.UFOBattlescapePalette.Palette
		Dim Frames = Hl.CreateHandObFrames(BigObImage, FrameParameters)
		For f = 0 To 7
			BitmapUtils.Blit(ExportImage, Frames(f), f * HandObWidth, 0)
		Next

		Return ExportImage
	End Function

	Private Sub ButtonExportFloorOb_Click(sender As Object, e As EventArgs) Handles ButtonExportFloorOb.Click
		Dim SaveFileDialog As New SaveFileDialog

		SaveFileDialog.Filter = "PNG file (*.png)|*.png|All Files (*.*)|*.*"

		If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String = SaveFileDialog.FileName
			Dim FrameParameters As IsometricFrameParameters
			FrameParameters = GatherFloorFrameParameters()
			If FrameParameters Is Nothing Then
				MsgBox("Could not render with the selected parameters.", MsgBoxStyle.Critical)
				Exit Sub
			End If

			Dim ExportImage = New Bitmap(HandObWidth, HandObHeight)

			Dim Frame = Hl.CreateFloorObFrame(BigObImage, FrameParameters)
			BitmapUtils.Blit(ExportImage, Frame, 0, 0)

			ExportImage.Save(FileName)
		End If
	End Sub
	Private Sub ButtonExportFloorObUFOPalette_Click(sender As Object, e As EventArgs) Handles ButtonExportFloorObUFOPalette.Click
		Dim SaveFileDialog As New SaveFileDialog

		SaveFileDialog.Filter = "PNG file (*.png)|*.png|All Files (*.*)|*.*"

		If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String = SaveFileDialog.FileName
			Dim FrameParameters As IsometricFrameParameters
			FrameParameters = GatherFloorFrameParameters()
			If FrameParameters Is Nothing Then
				MsgBox("Could not render with the selected parameters.", MsgBoxStyle.Critical)
				Exit Sub
			End If

			Dim Frame = Hl.CreateFloorObFrame(BigObImage, FrameParameters)
			Dim ExportImage = BitmapUtils.ConvertToPalette(Frame, My.Resources.UFOBattlescapePalette.Palette)

			ExportImage.Save(FileName)
		End If
	End Sub

	Private Sub ButtonExportFloorObTFTDPalette_Click(sender As Object, e As EventArgs) Handles ButtonExportFloorObTFTDPalette.Click
		Dim SaveFileDialog As New SaveFileDialog

		SaveFileDialog.Filter = "PNG file (*.png)|*.png|All Files (*.*)|*.*"

		If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String = SaveFileDialog.FileName
			Dim FrameParameters As IsometricFrameParameters
			FrameParameters = GatherFloorFrameParameters()
			If FrameParameters Is Nothing Then
				MsgBox("Could not render with the selected parameters.", MsgBoxStyle.Critical)
				Exit Sub
			End If

			Dim Frame = Hl.CreateFloorObFrame(BigObImage, FrameParameters)
			Dim ExportImage = BitmapUtils.ConvertToPalette(Frame, My.Resources.TFTDBattlescapePalette.Palette)

			ExportImage.Save(FileName)
		End If
	End Sub
	Friend Sub RefreshDestinations()
		If LoadingFileInProgress Then Exit Sub
		ImageDestinationHandOb.Invalidate()
		ImageDestinationFloorOb.Invalidate()
		If CheckBoxSendToUnitSpriteStudio.Checked Then IPC.SendToUnitSpriteStudio()
	End Sub
	Private Sub ImageSource_MouseUp(sender As Object, e As MouseEventArgs) Handles ImageSource.MouseUp
		If e.Button = MouseButtons.Left Then
			HandPosition.X = e.X / 3
			HandPosition.Y = e.Y / 3
			ImageSource.Invalidate()
			RefreshDestinations()
		End If
	End Sub
	Private Sub ImageSource_MouseMove(sender As Object, e As MouseEventArgs) Handles ImageSource.MouseMove
		If e.Button = MouseButtons.Left Then
			HandPosition.X = e.X / 3
			HandPosition.Y = e.Y / 3
			ImageSource.Invalidate()
			RefreshDestinations()
		End If
	End Sub

	Private Sub ImageDestinationHandOb_Paint(sender As Object, e As PaintEventArgs) Handles ImageDestinationHandOb.Paint
		Dim G As Graphics
		G = e.Graphics
		Dim f As Integer
		Try
			Dim FrameParameters As IsometricFrameParameters
			FrameParameters = GatherFrameParameters()
			If FrameParameters Is Nothing Then
				Exit Sub
			End If
			Dim Frames = Hl.CreateHandObFrames(BigObImage, FrameParameters)
			For f = 0 To 7
				BitmapUtils.BlitNx(G, Frames(f), f * HandObWidth * 3, 0)
			Next

			For f = 1 To 7
				G.DrawLine(Pens.Gray, f * HandObWidth * 3, 0, f * HandObWidth * 3, HandObHeight * 3)
			Next
			If CheckBoxDrawGrip.Checked Then
				If CheckBoxTwoHanded.Checked Then
					For f = 0 To 7
						G.DrawRectangle(Pens.Gray, TwoHandedHorizontalPositions(f).X * 3 + f * HandObWidth * 3, TwoHandedHorizontalPositions(f).Y * 3, 3, 3)
					Next
				Else
					For f = 0 To 7
						G.DrawRectangle(Pens.Gray, SingleHandPositions(f).X * 3 + f * HandObWidth * 3, SingleHandPositions(f).Y * 3, 3, 3)
					Next
				End If
			End If
		Catch ex As Exception
			Debug.Print(ex.StackTrace)
		End Try
	End Sub
	Private Sub ImageDestinationFloorOb_Paint(sender As Object, e As PaintEventArgs) Handles ImageDestinationFloorOb.Paint
		Dim G As Graphics
		G = e.Graphics
		Try
			Dim FrameParameters As IsometricFrameParameters
			FrameParameters = GatherFloorFrameParameters()
			If FrameParameters Is Nothing Then
				Exit Sub
			End If

			Dim Frame = Hl.CreateFloorObFrame(BigObImage, FrameParameters)
			BitmapUtils.BlitNx(G, Frame, 0, 0)
		Catch ex As Exception
			Debug.Print(ex.StackTrace)
		End Try
	End Sub
	Private Sub ButtonMirror_Click(sender As Object, e As EventArgs) Handles ButtonMirror.Click
		If BigObImage Is Nothing Then Exit Sub
		BigObImage = Mirror(BigObImage)
		ImageSource.Invalidate()
		RefreshDestinations()
	End Sub

	Private Sub ButtonFlip_Click(sender As Object, e As EventArgs) Handles ButtonFlip.Click
		If BigObImage Is Nothing Then Exit Sub
		BigObImage = Flip(BigObImage)
		ImageSource.Invalidate()
		RefreshDestinations()
	End Sub

	Private Sub ButtonFindCenter_Click(sender As Object, e As EventArgs) Handles ButtonFindCenter.Click
		If BigObImage Is Nothing Then Exit Sub
		Dim BoundingBox = BitmapUtils.CalculateImageBoundingBox(BigObImage)
		HandPosition.X = BoundingBox.X + BoundingBox.Width / 2
		HandPosition.Y = BoundingBox.Y + BoundingBox.Height / 2
		ImageSource.Invalidate()
		RefreshDestinations()
	End Sub

	Private Sub MainWindow_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If
	End Sub

	Private Sub MainWindow_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
			LoadSourceImage(filePaths(0))
		End If
	End Sub

	Private Sub ButtonOpenDetails_Click(sender As Object, e As EventArgs) Handles ButtonOpenDetails.Click
		If AdvancedWindow Is Nothing OrElse AdvancedWindow.IsDisposed Then
			AdvancedWindow = New FormSourceAdvanced()
			AdvancedWindow.Show()
		Else
			AdvancedWindow.Show()
			AdvancedWindow.BringToFront()
		End If
	End Sub

	Private Sub OptionChanged(sender As Object, e As EventArgs) _
		Handles CheckBoxTwoHanded.CheckedChanged,
			TextBoxScalingFactor.TextChanged,
			TextBoxItemWidth.TextChanged,
			TextBoxItemHeight.TextChanged,
			TextBoxThickness.TextChanged,
			ComboBoxColoringMethod.SelectedIndexChanged,
			CheckBoxHorizontal.CheckedChanged,
			CheckBoxMaskHand.CheckedChanged,
			TextBoxHandSize.TextChanged,
			TextBoxAvgRadius.TextChanged,
			TextBoxAvgRadiusFalloff.TextChanged,
			TextBoxAvgRadiusWeight.TextChanged,
			TextBoxAvgTransparencyCutoff.TextChanged,
			CheckBoxOverrideMask3.CheckedChanged,
			CheckBoxFloorObHorizontal.CheckedChanged,
			TextBoxFloorObScale.TextChanged,
			TextBoxVerticalAspect.TextChanged,
			CheckBoxShadedCenterline.CheckedChanged,
			CheckBoxDrawGrip.CheckedChanged
		RefreshDestinations()
	End Sub
	Private Sub AddRecentFile(Filepath As String)
		Dim FileAlreadyInRecent As Boolean = False
		For Each RecentFile As RecentFileItem In ListBoxRecentFiles.Items.OfType(Of RecentFileItem)
			If RecentFile.Filepath = Filepath Then
				FileAlreadyInRecent = True
				Exit For
			End If
		Next
		If Not FileAlreadyInRecent Then
			ListBoxRecentFiles.Items.Insert(0, New RecentFileItem(Filepath))
			If ListBoxRecentFiles.Items.Count > My.Settings.MaxRecentFiles Then
				For f = ListBoxRecentFiles.Items.Count - 1 To My.Settings.MaxRecentFiles Step -1
					ListBoxRecentFiles.Items.RemoveAt(f)
				Next
			End If
		End If
	End Sub
	Private Const SaveVersion As Integer = 2
	Private Sub ButtonSaveFile_Click(sender As Object, e As EventArgs) Handles ButtonSaveFile.Click
		Dim SaveFileDialog As New SaveFileDialog

		SaveFileDialog.Filter = "HandOb files (*.handob)|*.handob|All Files (*.*)|*.*"

		If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String = SaveFileDialog.FileName

			Dim File As System.IO.BinaryWriter
			File = New System.IO.BinaryWriter(System.IO.File.Open(FileName, IO.FileMode.OpenOrCreate))

			File.Write(SaveVersion)

			If LoadedBigOb Is Nothing Then
				File.Write("")
			Else
				File.Write(LoadedBigOb)
			End If

			File.Write(HandPosition.X)
			File.Write(HandPosition.Y)
			File.Write(CheckBoxTwoHanded.Checked)
			File.Write(CheckBoxHorizontal.Checked)
			File.Write(Val(TextBoxScalingFactor.Text))
			File.Write(Val(TextBoxVerticalAspect.Text))
			File.Write(Val(TextBoxItemWidth.Text))
			File.Write(Val(TextBoxItemHeight.Text))
			File.Write(Val(TextBoxThickness.Text))
			File.Write(ComboBoxColoringMethod.SelectedIndex)
			File.Write(CheckBoxShadedCenterline.Checked)
			File.Write(CheckBoxMaskHand.Checked)
			File.Write(Val(TextBoxHandSize.Text))
			File.Write(CheckBoxOverrideMask3.Checked)
			File.Write(Val(TextBoxAvgRadius.Text))
			File.Write(Val(TextBoxAvgRadiusWeight.Text))
			File.Write(Val(TextBoxAvgRadiusFalloff.Text))
			File.Write(Val(TextBoxAvgTransparencyCutoff.Text))
			If LoadedFrontImage Is Nothing Then
				File.Write("")
			Else
				File.Write(LoadedFrontImage)
			End If
			If LoadedRearImage Is Nothing Then
				File.Write("")
			Else
				File.Write(LoadedRearImage)
			End If
			File.Write(FrontImagePenetration)
			File.Write(RearImagePenetration)

			File.Write(ThicknessGroups.Count)
			For Each Group In ThicknessGroups
				File.Write(Group.Enabled)
				File.Write(Group.Color.ToArgb())
				File.Write(Group.Thickness)
				File.Write(Group.Areas.Count)
				For Each Area In Group.Areas
					File.Write(Area.Left)
					File.Write(Area.Right)
					File.Write(Area.Top)
					File.Write(Area.Bottom)
				Next
			Next

			File.Close()
			AddRecentFile(FileName)
		End If
	End Sub

	Private Sub LoadHandobFile(Filename As String)
		Dim File As System.IO.BinaryReader
		LoadingFileInProgress = True
		File = New System.IO.BinaryReader(System.IO.File.Open(Filename, IO.FileMode.Open))

		Dim LoadVersion As Integer = File.ReadInt32()

		LoadedBigOb = File.ReadString()
		If LoadedBigOb = "" Then LoadedBigOb = Nothing

		HandPosition.X = File.ReadInt32()
		HandPosition.Y = File.ReadInt32()
		CheckBoxTwoHanded.Checked = File.ReadBoolean()
		CheckBoxHorizontal.Checked = File.ReadBoolean()
		TextBoxScalingFactor.Text = Trim(Str(File.ReadDouble()))
		TextBoxVerticalAspect.Text = Trim(Str(File.ReadDouble()))
		TextBoxItemWidth.Text = Trim(Str(File.ReadDouble()))
		TextBoxItemHeight.Text = Trim(Str(File.ReadDouble()))
		TextBoxThickness.Text = Trim(Str(File.ReadDouble()))
		ComboBoxColoringMethod.SelectedIndex = File.ReadInt32()
		CheckBoxShadedCenterline.Checked = File.ReadBoolean()
		CheckBoxMaskHand.Checked = File.ReadBoolean()
		TextBoxHandSize.Text = Trim(Str(File.ReadDouble()))
		CheckBoxOverrideMask3.Checked = File.Read
		TextBoxAvgRadius.Text = Trim(Str(File.ReadDouble()))
		TextBoxAvgRadiusWeight.Text = Trim(Str(File.ReadDouble()))
		TextBoxAvgRadiusFalloff.Text = Trim(Str(File.ReadDouble()))
		TextBoxAvgTransparencyCutoff.Text = Trim(Str(File.ReadDouble()))
		LoadedFrontImage = File.ReadString()
		LoadedRearImage = File.ReadString()
		If LoadedFrontImage = "" Then LoadedFrontImage = Nothing
		If LoadedRearImage = "" Then LoadedRearImage = Nothing
		FrontImagePenetration = File.ReadInt32()
		RearImagePenetration = File.ReadInt32()

		Dim ThicknessGroupsCount = File.ReadInt32()
		For Each Group In ThicknessGroups
			Group.Enabled = File.ReadBoolean()
			Group.Color = Color.FromArgb(File.ReadInt32())
			Group.Thickness = File.ReadInt32()
			Group.Areas.Clear()
			Dim GroupAreasCount = File.ReadInt32()
			For f = 1 To GroupAreasCount
				Dim Area As New ThicknessGroup.Box
				Area.Left = File.ReadInt32()
				Area.Right = File.ReadInt32()
				Area.Top = File.ReadInt32()
				Area.Bottom = File.ReadInt32()
				Group.AddArea(Area)
			Next
		Next

		File.Close()
		If Not LoadedBigOb Is Nothing Then LoadSourceImage(LoadedBigOb)
		If Not LoadedFrontImage Is Nothing Then LoadFrontImage(LoadedFrontImage)
		If Not LoadedRearImage Is Nothing Then LoadRearImage(LoadedRearImage)
		LoadingFileInProgress = False
		RefreshDestinations()
		AddRecentFile(Filename)
	End Sub

	Private Sub LoadOldHandobFile(Filename As String)
		Dim File As System.IO.BinaryReader
		LoadingFileInProgress = True
		File = New System.IO.BinaryReader(System.IO.File.Open(Filename, IO.FileMode.Open))

		LoadedBigOb = File.ReadString()
		If LoadedBigOb = "" Then LoadedBigOb = Nothing

		HandPosition.X = File.ReadInt32()
		HandPosition.Y = File.ReadInt32()
		CheckBoxTwoHanded.Checked = File.ReadBoolean()
		CheckBoxHorizontal.Checked = File.ReadBoolean()
		TextBoxScalingFactor.Text = Trim(Str(File.ReadDouble()))
		TextBoxVerticalAspect.Text = Trim(Str(File.ReadDouble()))
		TextBoxItemWidth.Text = Trim(Str(File.ReadDouble()))
		TextBoxItemHeight.Text = Trim(Str(File.ReadDouble()))
		TextBoxThickness.Text = Trim(Str(File.ReadDouble()))
		ComboBoxColoringMethod.SelectedIndex = File.ReadInt32()
		CheckBoxShadedCenterline.Checked = File.ReadBoolean()
		CheckBoxMaskHand.Checked = File.ReadBoolean()
		TextBoxHandSize.Text = Trim(Str(File.ReadDouble()))
		CheckBoxOverrideMask3.Checked = File.Read
		TextBoxAvgRadius.Text = Trim(Str(File.ReadDouble()))
		TextBoxAvgRadiusWeight.Text = Trim(Str(File.ReadDouble()))
		TextBoxAvgRadiusFalloff.Text = Trim(Str(File.ReadDouble()))
		TextBoxAvgTransparencyCutoff.Text = Trim(Str(File.ReadDouble()))
		LoadedFrontImage = File.ReadString()
		LoadedRearImage = File.ReadString()
		If LoadedFrontImage = "" Then LoadedFrontImage = Nothing
		If LoadedRearImage = "" Then LoadedRearImage = Nothing

		Dim ThicknessGroupsCount = File.ReadInt32()
		For Each Group In ThicknessGroups
			Group.Enabled = File.ReadBoolean()
			Group.Color = Color.FromArgb(File.ReadInt32())
			Group.Thickness = File.ReadInt32()
			Group.Areas.Clear()
			Dim GroupAreasCount = File.ReadInt32()
			For f = 1 To GroupAreasCount
				Dim Area As New ThicknessGroup.Box
				Area.Left = File.ReadInt32()
				Area.Right = File.ReadInt32()
				Area.Top = File.ReadInt32()
				Area.Bottom = File.ReadInt32()
				Group.AddArea(Area)
			Next
		Next

		File.Close()
		If Not LoadedBigOb Is Nothing Then LoadSourceImage(LoadedBigOb)
		If Not LoadedFrontImage Is Nothing Then LoadFrontImage(LoadedFrontImage)
		If Not LoadedRearImage Is Nothing Then LoadRearImage(LoadedRearImage)
		LoadingFileInProgress = False
		RefreshDestinations()
		AddRecentFile(Filename)
	End Sub

	Private Sub ButtonLoadFile_Click(sender As Object, e As EventArgs) Handles ButtonLoadFile.Click
		Dim OpenFileDialog As New OpenFileDialog
		OpenFileDialog.Filter = "HandOb files (*.handob)|*.handob|All Files (*.*)|*.*"
		OpenFileDialog.Multiselect = False
		If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String
			FileName = OpenFileDialog.FileName
			LoadHandobFile(FileName)
		End If
	End Sub
	Private Sub ButtonLoadOldFile_Click(sender As Object, e As EventArgs) Handles ButtonLoadOldFile.Click
		Dim OpenFileDialog As New OpenFileDialog
		OpenFileDialog.Filter = "HandOb files (*.handob)|*.handob|All Files (*.*)|*.*"
		OpenFileDialog.Multiselect = False
		If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
			Dim FileName As String
			FileName = OpenFileDialog.FileName
			LoadOldHandobFile(FileName)
		End If
	End Sub


	Private Class RecentFileItem
		Friend Filename As String
		Friend Filepath As String

		Public Overrides Function ToString() As String
			Return Filename
		End Function

		Public Sub New(Filepath As String)
			Dim FileInfo = My.Computer.FileSystem.GetFileInfo(Filepath)
			If Not FileInfo.Exists Then
				Throw New System.IO.FileNotFoundException
			End If
			Me.Filepath = Filepath
			Filename = System.IO.Path.GetFileNameWithoutExtension(Filepath)
		End Sub

	End Class

	Private Sub MainWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		If My.Settings.RecentFiles Is Nothing Then
			My.Settings.RecentFiles = New Specialized.StringCollection()
		Else
			My.Settings.RecentFiles.Clear()
		End If
		For Each RecentFile As RecentFileItem In ListBoxRecentFiles.Items.OfType(Of RecentFileItem)
			My.Settings.RecentFiles.Add(RecentFile.Filepath)
		Next
		My.Settings.Save()
	End Sub

	Private Sub ListBoxRecentFiles_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBoxRecentFiles.MouseDoubleClick
		If ListBoxRecentFiles.SelectedIndex = -1 Then Exit Sub
		LoadHandobFile(CType(ListBoxRecentFiles.SelectedItem, RecentFileItem).Filepath)
	End Sub

	Private Sub ButtonSendToUnitSpriteStudio_Click(sender As Object, e As EventArgs) Handles ButtonSendToUnitSpriteStudio.Click
		IPC.SendToUnitSpriteStudio()
	End Sub

End Class
