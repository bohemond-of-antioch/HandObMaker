﻿Public Class LayeredBitmap
    Private ThicknessGroups As ThicknessGroup()
    Private Size As IntVector3
    Private ImageSize As Size
    Private TransparentColor As Color
    Private DefaultThickness As Integer

    Public ReadOnly Property Width() As Integer
        Get
            Return ImageSize.Width
        End Get
    End Property
    Public ReadOnly Property Height() As Integer
        Get
            Return ImageSize.Height
        End Get
    End Property

    Private Pixels As Color(,)
    Public Sub New(ByRef Image As Bitmap, Size As IntVector3, DefaultThickness As Integer, ThicknessGroups As ThicknessGroup())
        Me.Size = Size
        ImageSize.Width = Image.Width
        ImageSize.Height = Image.Height
        Me.ThicknessGroups = ThicknessGroups
        Me.DefaultThickness = DefaultThickness

        If Image.Palette.Entries.Length = 0 Then
            TransparentColor = Image.GetPixel(0, 0)
        Else
            TransparentColor = Image.Palette.Entries(0)
        End If

        ReDim Pixels(Image.Width, Image.Height)
        For x = 0 To Image.Width - 1
            For y = 0 To Image.Height - 1
                Pixels(x, y) = Image.GetPixel(x, y)
            Next
        Next
    End Sub

    Public Function GetPixel(X As Integer, Y As Integer, Z As Integer) As Color
        Dim LocalThickness = DefaultThickness
        For Each Group In ThicknessGroups
            If Group.Enabled Then
                If Group.AreaAtPosition(X, Y) <> -1 Then
                    LocalThickness = Group.Thickness
                End If
            End If
        Next
        Dim LowerZBound = (Size.Z - LocalThickness) \ 2
        Dim UpperZBound = Size.Z - Math.Ceiling((Size.Z - LocalThickness) / 2.0)
        If Z >= LowerZBound And Z < UpperZBound Then
            'GetPixel = ImageData.GetPixel(X, Y)
            GetPixel = Pixels(X, Y)
        Else
            GetPixel = TransparentColor
        End If
    End Function

End Class
