Public Class ImagePixelMap
    Dim MapSize As Size
    Dim Bucket As List(Of Color)(,)
    Public Sub New(ImageSize As Size)
        MapSize = ImageSize
        ReDim Bucket(MapSize.Width, MapSize.Height)
        For x = 0 To MapSize.Width - 1
            For y = 0 To MapSize.Height - 1
                Bucket(x, y) = New List(Of Color)()
            Next
        Next
    End Sub

    Public Sub PushPixel(X As Integer, Y As Integer, Pixel As Color)
        Bucket(X, Y).Add(Pixel)
    End Sub

    Public Sub SetPixel(X As Integer, Y As Integer, Pixel As Color)
        Bucket(X, Y).Clear()
        Bucket(X, Y).Add(Pixel)
    End Sub

    Public Function GetAveragePixel(X As Integer, Y As Integer) As Color
        If Bucket(X, Y).Count = 0 Then Return Color.Empty
        Dim R, G, B As Integer
        R = 0
        G = 0
        B = 0
        For Each C In Bucket(X, Y)
            R += C.R
            G += C.G
            B += C.B
        Next
        Return Color.FromArgb(R / Bucket(X, Y).Count, G / Bucket(X, Y).Count, B / Bucket(X, Y).Count)
    End Function
End Class
