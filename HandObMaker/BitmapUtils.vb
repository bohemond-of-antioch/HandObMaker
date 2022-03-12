Module BitmapUtils
	Friend Enum EColoringMethod
		Last
		Average
	End Enum

	Friend Sub BlitNx(G As Graphics, Image As Bitmap, DestinationX As Integer, DestinationY As Integer, Optional Scale As Integer = 3)
		Dim BitmapData = Image.LockBits(New Rectangle(0, 0, Image.Width, Image.Height), Imaging.ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppArgb)

		Dim SourcePixels(BitmapData.Height * BitmapData.Stride - 1) As Byte
		Runtime.InteropServices.Marshal.Copy(BitmapData.Scan0, SourcePixels, 0, BitmapData.Height * BitmapData.Stride)
		Dim BrushPalette As Dictionary(Of UInt32, SolidBrush) = New Dictionary(Of UInteger, SolidBrush)
		Dim x, y As Integer
		For x = 0 To Image.Width - 1
			For y = 0 To Image.Height - 1
				If SourcePixels(x * 4 + y * BitmapData.Stride + 3) = 0 Then Continue For
				Dim B As SolidBrush
				B = New SolidBrush(Color.FromArgb(SourcePixels(x * 4 + y * BitmapData.Stride + 3), SourcePixels(x * 4 + y * BitmapData.Stride + 2), SourcePixels(x * 4 + y * BitmapData.Stride + 1), SourcePixels(x * 4 + y * BitmapData.Stride + 0)))
				G.FillRectangle(B, DestinationX + x * Scale, DestinationY + y * Scale, Scale, Scale)
			Next
		Next
		Image.UnlockBits(BitmapData)
	End Sub
	'Friend Sub BlitNx(G As Graphics, Image As Bitmap, DestinationX As Integer, DestinationY As Integer, Optional Scale As Integer = 3)
	'	Dim x, y As Integer
	'	For x = 0 To Image.Width - 1
	'		For y = 0 To Image.Height - 1
	'			G.FillRectangle(New SolidBrush(Image.GetPixel(x, y)), DestinationX + x * Scale, DestinationY + y * Scale, Scale, Scale)
	'		Next
	'	Next
	'End Sub
	Friend Sub Blit(DestinationImage As Bitmap, SourceImage As Bitmap, DestinationX As Integer, DestinationY As Integer)
		Dim G = Graphics.FromImage(DestinationImage)
		G.DrawImageUnscaled(SourceImage, DestinationX, DestinationY)
	End Sub

	Friend Function GetPixelIndex(Image As Bitmap, X As Integer, Y As Integer) As Integer
		Dim PixelColor = Image.GetPixel(X, Y)
		Dim f As Integer
		For f = 0 To UBound(Image.Palette.Entries)
			If Image.Palette.Entries(f) = PixelColor Then
				Return f
			End If
		Next
		If Image.GetPixel(X, Y) = Image.GetPixel(0, 0) Then Return 0
		Return -1
	End Function
	Friend Sub ClearBitmap(ByRef Image As Bitmap)
		Dim ClearColor As Color
		If Image.Palette.Entries.Length = 0 Then
			ClearColor = Color.Transparent
		Else
			ClearColor = Image.Palette.Entries(0)
		End If
		For x = 0 To Image.Width - 1
			For y = 0 To Image.Height - 1
				Image.SetPixel(x, y, ClearColor)
			Next
		Next
	End Sub
	Friend Function CalculateAverageColor(ByRef Image As LayeredBitmap, OriginX As Integer, OriginY As Integer, OriginZ As Integer, Radius As Integer, RadiusWeight As Integer, RadiusWeightFalloff As Integer, TransparencyCutoff As Integer, ByRef TransparentColor As Color)
		Dim R, G, B As Integer
		Dim TransparentPixels As Integer
		Dim OpaquePixels As Integer
		R = 0 : G = 0 : B = 0 : TransparentPixels = 0 : OpaquePixels = 0
		For x = OriginX - Radius To OriginX + Radius
			For y = OriginY - Radius To OriginY + Radius
				If TransparentPixels >= TransparencyCutoff Then Return TransparentColor
				If x < 0 Or x >= Image.Width Or y < 0 Or y >= Image.Height Then
					TransparentPixels += 1
					Continue For
				End If
				Dim PixelColor = Image.GetPixel(x, y, OriginZ)
				If PixelColor = TransparentColor Then
					TransparentPixels += 1
					Continue For
				End If
				Dim RadiusDistance As Integer
				RadiusDistance = Math.Abs(x - OriginX) + Math.Abs(y - OriginY)
				Dim Weight As Integer = RadiusWeight - RadiusDistance * RadiusWeightFalloff
				If (Weight > 0) Then
					R += PixelColor.R * Weight
					G += PixelColor.G * Weight
					B += PixelColor.B * Weight
					OpaquePixels += Weight
				End If
			Next
		Next
		If TransparentPixels >= TransparencyCutoff Or OpaquePixels = 0 Then Return TransparentColor
		Return Color.FromArgb(R / OpaquePixels, G / OpaquePixels, B / OpaquePixels)
	End Function

	Friend Sub SetRectangle(ByRef Image As Bitmap, Color As Color, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
		x1 = Math.Min(Image.Width - 1, Math.Max(0, x1))
		y1 = Math.Min(Image.Width - 1, Math.Max(0, y1))
		x2 = Math.Min(Image.Width - 1, Math.Max(0, x2))
		y2 = Math.Min(Image.Width - 1, Math.Max(0, y2))
		For x = x1 To x2
			For y = y1 To y2
				Image.SetPixel(x, y, Color)
			Next
		Next
	End Sub
	Friend Enum EEdge
		Front
		Rear
	End Enum
	Friend Function CalculateEdge(Image As Bitmap, Edge As EEdge) As Integer()
		Dim StartY As Integer
		Dim RayY As Integer
		Select Case Edge
			Case EEdge.Front
				StartY = 0
				RayY = 1
			Case EEdge.Rear
				StartY = Image.Height - 1
				RayY = -1
		End Select
		Dim EdgeData As Integer()
		Dim TransparentColor As Color
		If Image.Palette.Entries.Length = 0 Then
			TransparentColor = Image.GetPixel(0, 0)
		Else
			TransparentColor = Image.Palette.Entries(0)
		End If
		ReDim EdgeData(Image.Width)
		For x = 0 To Image.Width - 1
			Dim y = StartY
			Do While y >= 0 AndAlso y < Image.Height AndAlso Image.GetPixel(x, y) = TransparentColor
				y += RayY
			Loop
			EdgeData(x) = y
		Next
		Return EdgeData
	End Function
	Friend Function CalculateImageBoundingBox(Image As Bitmap) As Rectangle
		Dim BitmapData = Image.LockBits(New Rectangle(0, 0, Image.Width, Image.Height), Imaging.ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppArgb)
		Dim SourcePixels(BitmapData.Height * BitmapData.Stride - 1) As Byte
		Runtime.InteropServices.Marshal.Copy(BitmapData.Scan0, SourcePixels, 0, BitmapData.Height * BitmapData.Stride)

		Dim x, y As Integer
		Dim BoundingBox As Rectangle = New Rectangle()
		BoundingBox.X = Image.Width
		BoundingBox.Y = Image.Height
		BoundingBox.Width = 0
		BoundingBox.Height = 0
		For x = 0 To Image.Width - 1
			For y = 0 To Image.Height - 1
				Dim a As Byte
				a = SourcePixels(x * 4 + y * BitmapData.Stride + 3)
				If a > 0 Then
					If x > BoundingBox.Width Then BoundingBox.Width = x
					If y > BoundingBox.Height Then BoundingBox.Height = y
					If x < BoundingBox.X Then BoundingBox.X = x
					If y < BoundingBox.Y Then BoundingBox.Y = y
				End If
			Next
		Next
		BoundingBox.Width = BoundingBox.Width - BoundingBox.X + 1
		BoundingBox.Height = BoundingBox.Height - BoundingBox.Y + 1
		Image.UnlockBits(BitmapData)

		Return BoundingBox
	End Function

	Friend Function UnboundImageFromFile(Filename As String) As Bitmap
		Dim BoundImage As Bitmap = Image.FromFile(Filename)
		Dim BoundData = BoundImage.LockBits(New Rectangle(0, 0, BoundImage.Size.Width, BoundImage.Size.Height), Imaging.ImageLockMode.ReadOnly, BoundImage.PixelFormat)
		Dim BoundPalette = BoundImage.Palette
		Dim DataSize = BoundData.Stride * BoundData.Height
		Dim ByteData(DataSize - 1) As Byte
		Dim UnboundImage = New Bitmap(BoundImage.Size.Width, BoundImage.Size.Height, BoundImage.PixelFormat)
		If UnboundImage.Palette.Entries.Count > 0 Then UnboundImage.Palette = BoundPalette
		System.Runtime.InteropServices.Marshal.Copy(BoundData.Scan0, ByteData, 0, DataSize)
		BoundImage.UnlockBits(BoundData)
		BoundImage.Dispose()
		Dim UnboundData = UnboundImage.LockBits(New Rectangle(0, 0, UnboundImage.Size.Width, UnboundImage.Size.Height), Imaging.ImageLockMode.WriteOnly, UnboundImage.PixelFormat)
		System.Runtime.InteropServices.Marshal.Copy(ByteData, 0, UnboundData.Scan0, DataSize)
		UnboundImage.UnlockBits(UnboundData)
		Return UnboundImage
	End Function
	Friend Function ConvertToPalette(SourceImage As Bitmap, DestinationPalette As Imaging.ColorPalette) As Bitmap
		Dim TransformedPixels(SourceImage.Width * SourceImage.Height - 1) As Byte
		Dim BitmapData = SourceImage.LockBits(New Rectangle(0, 0, SourceImage.Width, SourceImage.Height), Imaging.ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppArgb)

		Dim SourcePixels(BitmapData.Height * BitmapData.Stride - 1) As Byte
		Runtime.InteropServices.Marshal.Copy(BitmapData.Scan0, SourcePixels, 0, BitmapData.Height * BitmapData.Stride)
		Dim Palette = DestinationPalette.Entries
		For f = 0 To UBound(TransformedPixels)
			Dim a, r, g, b As Integer
			a = SourcePixels(f * 4 + 3)
			r = SourcePixels(f * 4 + 2)
			g = SourcePixels(f * 4 + 1)
			b = SourcePixels(f * 4 + 0)

			If a = 0 Then
				TransformedPixels(f) = 0
			Else
				Dim BestMatchIndex As Byte
				Dim BestCloseness As UInt32 = 256 * 256 * 256
				For p = 0 To 255
					Dim RDelta As UInt32 = Math.Abs(r - Palette(p).R)
					Dim GDelta As UInt32 = Math.Abs(g - Palette(p).G)
					Dim BDelta As UInt32 = Math.Abs(b - Palette(p).B)
					Dim Closeness As UInt32 = RDelta * RDelta + GDelta * GDelta + BDelta * BDelta
					If Closeness < BestCloseness Then
						BestCloseness = Closeness
						BestMatchIndex = p
						If Closeness = 0 Then Exit For
					End If
				Next
				TransformedPixels(f) = BestMatchIndex
			End If
		Next
		SourceImage.UnlockBits(BitmapData)
		Dim scan0 As IntPtr
		scan0 = Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(TransformedPixels, 0)
		ConvertToPalette = New Bitmap(SourceImage.Width, SourceImage.Height, SourceImage.Width, Imaging.PixelFormat.Format8bppIndexed, scan0)
		ConvertToPalette.Palette = DestinationPalette
	End Function
End Module
