Module Hl
    Friend Const BigObWidth As Integer = 32
    Friend Const BigObHeight As Integer = 48

    Friend Const BigObGrid As Integer = 16

    Friend Const HandObWidth As Integer = 32
    Friend Const HandObHeight As Integer = 40

    Friend MainWindowPtr As MainWindow

    Friend SingleHandPositions As Point() = {
        New Point(22, 17),
        New Point(21, 18),
        New Point(16, 20),
        New Point(9, 20),
        New Point(9, 17),
        New Point(9, 15),
        New Point(16, 14),
        New Point(23, 16),
        New Point(15, 32)
    }
    Friend TwoHandedHorizontalPositions As Point() = {
        New Point(15, 15),
        New Point(23, 16),
        New Point(18, 19),
        New Point(15, 18),
        New Point(13, 18),
        New Point(8, 16),
        New Point(16, 15),
        New Point(15, 16),
        New Point(15, 32)
    }
    Friend Structure ColoringAverageParameters
        Friend Radius As Integer
        Friend RadiusWeight As Integer
        Friend RadiusWeightFalloff As Integer
        Friend TransparencyCutoff As Integer
    End Structure
    Friend Class IsometricFrameParameters
        Friend Scale As Double
        Friend VerticalAspect As Double
        Friend HandPosition As Point
        Friend TwoHanded As Boolean
        Friend Horizontal As Boolean
        Friend ItemSize As Size
        Friend ItemThickness As Integer
        Friend MaskHand As Boolean
        Friend HandSize As Integer
        Friend OverrideMask3 As Boolean
        Friend ShadedCenterline As Boolean
        Friend ColoringMethod As EColoringMethod
        Friend ColoringAverage As ColoringAverageParameters
        Friend FrontImage As Bitmap
        Friend RearImage As Bitmap
        Friend ThicknessGroups As ThicknessGroup()
    End Class
    Const IsometricSquash = 0.75
    Friend Function Mirror(Image As Bitmap) As Bitmap
        Dim ItemSize As Size = CalculateItemSize(Image)
        Mirror = New Bitmap(Image)
        For x = 0 To Image.Width - 1
            For y = 0 To Image.Height - 1
                Mirror.SetPixel(x, y, Image.GetPixel(x, y))
            Next y
        Next x
        For x = 0 To ItemSize.Width * BigObGrid - 1
            For y = 0 To ItemSize.Height * BigObGrid - 1
                Mirror.SetPixel(x, y, Image.GetPixel(ItemSize.Width * BigObGrid - x - 1, y))
            Next y
        Next x
    End Function
    Friend Function Flip(Image As Bitmap) As Bitmap
        Dim ItemSize As Size = CalculateItemSize(Image)
        Flip = New Bitmap(Image)
        For x = 0 To Image.Width - 1
            For y = 0 To Image.Height - 1
                Flip.SetPixel(x, y, Image.GetPixel(x, y))
            Next y
        Next x
        For x = 0 To ItemSize.Width * BigObGrid - 1
            For y = 0 To ItemSize.Height * BigObGrid - 1
                Flip.SetPixel(x, y, Image.GetPixel(x, ItemSize.Height * BigObGrid - y - 1))
            Next y
        Next x
    End Function

    Friend Function CalculateItemSize(BigObImage As Bitmap) As Size
        Dim BoundingBox = CalculateImageBoundingBox(BigObImage)
        CalculateItemSize.Width = Math.Ceiling((BoundingBox.X + BoundingBox.Width) / BigObGrid)
        CalculateItemSize.Height = Math.Ceiling((BoundingBox.Y + BoundingBox.Height) / BigObGrid)
    End Function

    Friend Function CreateHandObFrames(BigObImage As Bitmap, FrameParameters As IsometricFrameParameters) As Bitmap()
        Dim Frames As Bitmap()
        ReDim Frames(8)
        Dim SourceSize As Size = New Size(FrameParameters.ItemSize.Width * BigObGrid, FrameParameters.ItemSize.Height * BigObGrid)
        Dim Size As IntVector3
        Size = New IntVector3(SourceSize.Width, SourceSize.Height, FrameParameters.ItemThickness)
        For Each Group In FrameParameters.ThicknessGroups
            If Group.Enabled Then
                If Group.Thickness > Size.Z Then Size.Z = Group.Thickness
            End If
        Next
        Dim SourceImage As LayeredBitmap = New LayeredBitmap(BigObImage, Size, FrameParameters.ItemThickness, FrameParameters.ThicknessGroups)
        'For f = 0 To 7
        '    Frames(f) = MakeIsometricFrame(BigObImage, SourceImage, f, FrameParameters)
        'Next

        Parallel.For(0, 8, Sub(Index)
                               Frames(Index) = MakeIsometricFrame(BigObImage, SourceImage, Index, FrameParameters)
                           End Sub)

        Return Frames
    End Function

    Friend Function CreateFloorObFrame(BigObImage As Bitmap, FrameParameters As IsometricFrameParameters) As Bitmap
        Dim SourceSize As Size = New Size(FrameParameters.ItemSize.Width * BigObGrid, FrameParameters.ItemSize.Height * BigObGrid)
        Dim SourceImage As LayeredBitmap = New LayeredBitmap(BigObImage, New IntVector3(SourceSize.Width, SourceSize.Height, FrameParameters.ItemThickness), FrameParameters.ItemThickness, FrameParameters.ThicknessGroups)

        Dim Frame As Bitmap
        Frame = MakeIsometricFrame(BigObImage, SourceImage, 8, FrameParameters)
        Return Frame
    End Function

    Friend Function MakeIsometricFrame(ByRef BigOb As Bitmap, ByRef SourceImage As LayeredBitmap, Direction As Integer, Parameters As IsometricFrameParameters) As Bitmap

        Dim SourceSize As Size = New Size(Parameters.ItemSize.Width * BigObGrid, Parameters.ItemSize.Height * BigObGrid)

        Dim EdgeFront As Integer()
        Dim EdgeRear As Integer()

        If Not Parameters.FrontImage Is Nothing Then
            SyncLock BigOb
                EdgeFront = BitmapUtils.CalculateEdge(BigOb, EEdge.Front)
            End SyncLock
        End If
        If Not Parameters.RearImage Is Nothing Then
            SyncLock BigOb
                EdgeRear = BitmapUtils.CalculateEdge(BigOb, EEdge.Rear)
            End SyncLock
        End If

        If Parameters.HandPosition.X < 0 Or Parameters.HandPosition.X > SourceSize.Width Or Parameters.HandPosition.Y < 0 Or Parameters.HandPosition.Y > SourceSize.Height Then Return New Bitmap(HandObWidth, HandObHeight)

        Dim Origin As IntVector3
        Dim ScanDirection As IntVector3
        Dim Size As IntVector3
        Size = New IntVector3(SourceSize.Width, SourceSize.Height, Parameters.ItemThickness)
        For Each Group In Parameters.ThicknessGroups
            If Group.Enabled Then
                If Group.Thickness > Size.Z Then Size.Z = Group.Thickness
            End If
        Next


        Dim ProjectionX As DoubleVector3
        Dim ProjectionY As DoubleVector3
        Dim HandOffset As Point
        Dim AdjustedDirection = Direction
        If Parameters.Horizontal Then
            If Parameters.TwoHanded Then
                HandOffset = TwoHandedHorizontalPositions(Direction)
            Else
                HandOffset = SingleHandPositions(Direction)
                AdjustedDirection = (Direction + 2) Mod 8
            End If
            Select Case AdjustedDirection
                Case 0 '9
                    ScanDirection = New IntVector3(-1, 1, -1)
                    ProjectionX = New DoubleVector3(0, Parameters.Scale * IsometricSquash, 1 * IsometricSquash)
                    ProjectionY = New DoubleVector3(Parameters.Scale * Parameters.VerticalAspect, Parameters.Scale * IsometricSquash * 0.5, -0.5 * IsometricSquash)
                Case 1 '6
                    ScanDirection = New IntVector3(-1, 1, 1)
                    ProjectionX = New DoubleVector3(0, 0, 1)
                    ProjectionY = New DoubleVector3(Parameters.Scale * Parameters.VerticalAspect, Parameters.Scale * IsometricSquash * 0.5, 0)
                Case 2 '3
                    ScanDirection = New IntVector3(-1, 1, 1)
                    ProjectionX = New DoubleVector3(0, -Parameters.Scale * IsometricSquash, 1 * IsometricSquash)
                    ProjectionY = New DoubleVector3(Parameters.Scale * Parameters.VerticalAspect, Parameters.Scale * IsometricSquash * 0.5, 0.5 * IsometricSquash)
                Case 3 '2
                    ScanDirection = New IntVector3(-1, 1, 1)
                    ProjectionX = New DoubleVector3(0, -Parameters.Scale, 0)
                    ProjectionY = New DoubleVector3(Parameters.Scale * Parameters.VerticalAspect, 0, IsometricSquash * 0.5)
                Case 4 '1
                    ScanDirection = New IntVector3(-1, -1, -1)
                    ProjectionX = New DoubleVector3(0, -Parameters.Scale * IsometricSquash, 1 * IsometricSquash)
                    ProjectionY = New DoubleVector3(Parameters.Scale * Parameters.VerticalAspect, -Parameters.Scale * IsometricSquash * 0.5, -0.5 * IsometricSquash)
                Case 5 '4
                    ScanDirection = New IntVector3(-1, -1, -1)
                    ProjectionX = New DoubleVector3(0, 0, 1)
                    ProjectionY = New DoubleVector3(Parameters.Scale * Parameters.VerticalAspect, -Parameters.Scale * IsometricSquash * 0.5, 0)
                Case 6 '7
                    ScanDirection = New IntVector3(-1, -1, 1)
                    ProjectionX = New DoubleVector3(0, Parameters.Scale * IsometricSquash, 1 * IsometricSquash)
                    ProjectionY = New DoubleVector3(Parameters.Scale * Parameters.VerticalAspect, -Parameters.Scale * IsometricSquash * 0.5, 0.5 * IsometricSquash)
                Case 7 '8
                    ScanDirection = New IntVector3(-1, 1, 1)
                    ProjectionX = New DoubleVector3(0, Parameters.Scale, 0)
                    ProjectionY = New DoubleVector3(Parameters.Scale * Parameters.VerticalAspect, 0, IsometricSquash * 0.5)
                Case 8 'On the ground
                    ScanDirection = New IntVector3(1, 1, -1)
                    ProjectionX = New DoubleVector3(0, -Parameters.Scale, 0)
                    ProjectionY = New DoubleVector3(IsometricSquash * 0.5, 0, Parameters.Scale)
            End Select
        Else
            HandOffset = SingleHandPositions(Direction)
            Select Case Direction
                Case 0 '9
                    ScanDirection = New IntVector3(-1, -1, 1)
                    ProjectionX = New DoubleVector3(Parameters.Scale * IsometricSquash, 0, 1 * IsometricSquash)
                    ProjectionY = New DoubleVector3(-Parameters.Scale * IsometricSquash * 0.5, Parameters.Scale * Parameters.VerticalAspect, 0.5 * IsometricSquash)
                Case 1 '6
                    ScanDirection = New IntVector3(1, -1, 1)
                    ProjectionX = New DoubleVector3(Parameters.Scale, 0, 0)
                    ProjectionY = New DoubleVector3(0, Parameters.Scale * Parameters.VerticalAspect, 0.5)
                Case 2 '3
                    ScanDirection = New IntVector3(1, -1, -1)
                    ProjectionX = New DoubleVector3(Parameters.Scale * IsometricSquash, 0, 1 * IsometricSquash)
                    ProjectionY = New DoubleVector3(Parameters.Scale * IsometricSquash * 0.5, Parameters.Scale * Parameters.VerticalAspect, -0.5 * IsometricSquash)
                Case 3 '2
                    ScanDirection = New IntVector3(1, -1, -1)
                    ProjectionX = New DoubleVector3(0, 0, 1)
                    ProjectionY = New DoubleVector3(Parameters.Scale * IsometricSquash * 0.5, Parameters.Scale * Parameters.VerticalAspect, 0)
                Case 4 '1
                    ScanDirection = New IntVector3(-1, -1, 1)
                    ProjectionX = New DoubleVector3(-Parameters.Scale * IsometricSquash, 0, 1 * IsometricSquash)
                    ProjectionY = New DoubleVector3(Parameters.Scale * IsometricSquash * 0.5, Parameters.Scale * Parameters.VerticalAspect, 0.5 * IsometricSquash)
                Case 5 '4
                    ScanDirection = New IntVector3(-1, -1, 1)
                    ProjectionX = New DoubleVector3(-Parameters.Scale, 0, 0)
                    ProjectionY = New DoubleVector3(0, Parameters.Scale * Parameters.VerticalAspect, 0.5)
                Case 6 '7
                    ScanDirection = New IntVector3(1, -1, -1)
                    ProjectionX = New DoubleVector3(-Parameters.Scale * IsometricSquash, 0, 1 * IsometricSquash)
                    ProjectionY = New DoubleVector3(-Parameters.Scale * IsometricSquash * 0.5, Parameters.Scale * Parameters.VerticalAspect, -0.5 * IsometricSquash)
                Case 7 '8
                    ScanDirection = New IntVector3(-1, -1, 1)
                    ProjectionX = New DoubleVector3(0, 0, 1)
                    ProjectionY = New DoubleVector3(-Parameters.Scale * IsometricSquash * 0.5, Parameters.Scale * Parameters.VerticalAspect, 0)
                Case 8
                    ScanDirection = New IntVector3(1, -1, 1)
                    ProjectionX = New DoubleVector3(Parameters.Scale, 0, 0)
                    ProjectionY = New DoubleVector3(0, Parameters.Scale, 0.5)
            End Select
        End If

        Origin = New IntVector3()
        If ScanDirection.X = 1 Then
            Origin.X = 0
        Else
            Origin.X = Size.X - 1
        End If
        If ScanDirection.Y = 1 Then
            Origin.Y = 0
        Else
            Origin.Y = Size.Y - 1
        End If
        If ScanDirection.Z = 1 Then
            Origin.Z = 0
        Else
            Origin.Z = Size.Z - 1
        End If

        Dim DestinationSize As Size = New Size(SourceSize.Width * Parameters.Scale, SourceSize.Height * Parameters.Scale)

        MakeIsometricFrame = New Bitmap(HandObWidth, HandObHeight)
        BitmapUtils.ClearBitmap(MakeIsometricFrame)
        Dim TransparentColor As Color
        SyncLock BigOb
            If Not BigOb.Palette.Entries.Length = 0 Then
                MakeIsometricFrame.Palette = BigOb.Palette
            End If
            If BigOb.Palette.Entries.Length = 0 Then
                TransparentColor = BigOb.GetPixel(0, 0)
            Else
                TransparentColor = BigOb.Palette.Entries(0)
            End If
        End SyncLock

        Dim Pixels As Color(,)
        ReDim Pixels(MakeIsometricFrame.Width, MakeIsometricFrame.Height)


        Dim ScanPosition As IntVector3
        ScanPosition.Z = Origin.Z

        For z = 0 To Size.Z - 1
            ScanPosition.X = Origin.X
            For x = 0 To Size.X - 1
                ScanPosition.Y = Origin.Y
                For y = 0 To Size.Y - 1
                    Dim DrawingPoint As Point
                    DrawingPoint.X = ProjectionX.X * (ScanPosition.X - Parameters.HandPosition.X) + ProjectionX.Y * (ScanPosition.Y - Parameters.HandPosition.Y) + ProjectionX.Z * (ScanPosition.Z - Math.Floor(Size.Z / 2)) + HandOffset.X
                    DrawingPoint.Y = ProjectionY.X * (ScanPosition.X - Parameters.HandPosition.X) + ProjectionY.Y * (ScanPosition.Y - Parameters.HandPosition.Y) + ProjectionY.Z * (ScanPosition.Z - Math.Floor(Size.Z / 2)) + HandOffset.Y

                    'Debug.Print("Scan position = " + ScanPosition.ToString)
                    Dim CurrentScanPosition As IntVector3 = ScanPosition
                    ScanPosition.Y += ScanDirection.Y
                    If DrawingPoint.X < 0 Or DrawingPoint.X >= MakeIsometricFrame.Width Or DrawingPoint.Y < 0 Or DrawingPoint.Y >= MakeIsometricFrame.Height Then
                        Continue For
                    End If
                    Dim DrawColor As Color
                    Select Case Parameters.ColoringMethod
                        Case EColoringMethod.Last
                            DrawColor = SourceImage.GetPixel(CurrentScanPosition.X, CurrentScanPosition.Y, CurrentScanPosition.Z)
                        Case EColoringMethod.Average
                            DrawColor = CalculateAverageColor(SourceImage, CurrentScanPosition.X, CurrentScanPosition.Y, CurrentScanPosition.Z, Parameters.ColoringAverage.Radius, Parameters.ColoringAverage.RadiusWeight, Parameters.ColoringAverage.RadiusWeightFalloff, Parameters.ColoringAverage.TransparencyCutoff, TransparentColor)
                    End Select
                    If DrawColor = TransparentColor Then Continue For
                    If Not Parameters.FrontImage Is Nothing Then
                        SyncLock Parameters.FrontImage
                            If EdgeFront(CurrentScanPosition.X) = CurrentScanPosition.Y And CurrentScanPosition.X < Parameters.FrontImage.Height And CurrentScanPosition.Z < Parameters.FrontImage.Width Then
                                Dim FrontPixel = Parameters.FrontImage.GetPixel(CurrentScanPosition.Z, CurrentScanPosition.X)
                                If FrontPixel <> TransparentColor Then
                                    DrawColor = FrontPixel
                                End If
                            End If
                        End SyncLock
                    End If
                    If Not Parameters.RearImage Is Nothing Then
                        SyncLock Parameters.FrontImage
                            If EdgeRear(CurrentScanPosition.X) = CurrentScanPosition.Y And CurrentScanPosition.X < Parameters.RearImage.Height And CurrentScanPosition.Z < Parameters.RearImage.Width Then
                                Dim RearPixel = Parameters.RearImage.GetPixel(CurrentScanPosition.Z, CurrentScanPosition.X)
                                If RearPixel <> TransparentColor Then
                                    DrawColor = RearPixel
                                End If
                            End If
                        End SyncLock
                    End If
                    If Parameters.ShadedCenterline Then
                        If ScanPosition.Z - Math.Floor(Size.Z / 2) = 0 Then
                            DrawColor = Color.FromArgb(Math.Min(255, DrawColor.R + 16), Math.Min(255, DrawColor.G + 16), Math.Min(255, DrawColor.B + 16))
                        End If
                    End If
                    Pixels(DrawingPoint.X, DrawingPoint.Y) = DrawColor
                Next y
                ScanPosition.X += ScanDirection.X
            Next x
            ScanPosition.Z += ScanDirection.Z
        Next z
        For x = 0 To MakeIsometricFrame.Width - 1
            For y = 0 To MakeIsometricFrame.Height - 1
                MakeIsometricFrame.SetPixel(x, y, Pixels(x, y))
            Next
        Next
        If Parameters.MaskHand Then
            Select Case Direction
                Case 0 '9
                    SetRectangle(MakeIsometricFrame, TransparentColor, 0, HandOffset.Y, CInt(Math.Ceiling(HandOffset.X + Parameters.HandSize / 2.0)), HandOffset.Y + Parameters.HandSize - 1)
                Case 1 '6
                    SetRectangle(MakeIsometricFrame, TransparentColor, 0, HandOffset.Y, CInt(Math.Ceiling(HandOffset.X + Parameters.HandSize / 2.0)), HandOffset.Y + Parameters.HandSize - 1)
                Case 2 '3
                    SetRectangle(MakeIsometricFrame, TransparentColor, 0, HandOffset.Y, CInt(Math.Ceiling(HandOffset.X + Parameters.HandSize / 2.0)), HandOffset.Y + Parameters.HandSize - 1)
                Case 3 '2
                    If Not Parameters.OverrideMask3 Then SetRectangle(MakeIsometricFrame, TransparentColor, 0, HandOffset.Y, MakeIsometricFrame.Width, HandOffset.Y + Parameters.HandSize - 1)
                Case 4 '1
                    SetRectangle(MakeIsometricFrame, TransparentColor, CInt(Math.Ceiling(HandOffset.X - Parameters.HandSize / 2.0)), HandOffset.Y, MakeIsometricFrame.Width, HandOffset.Y + Parameters.HandSize - 1)
                Case 5 '4
                    SetRectangle(MakeIsometricFrame, TransparentColor, CInt(Math.Ceiling(HandOffset.X - Parameters.HandSize / 2.0)), HandOffset.Y, MakeIsometricFrame.Width, HandOffset.Y + Parameters.HandSize - 1)
                Case 6 '7
                    SetRectangle(MakeIsometricFrame, TransparentColor, CInt(Math.Ceiling(HandOffset.X - Parameters.HandSize / 2.0)), HandOffset.Y, MakeIsometricFrame.Width, HandOffset.Y + Parameters.HandSize - 1)
                Case 7 '8
                    SetRectangle(MakeIsometricFrame, TransparentColor, 0, HandOffset.Y, MakeIsometricFrame.Width, HandOffset.Y + Parameters.HandSize - 1)
            End Select
        End If

    End Function

End Module
