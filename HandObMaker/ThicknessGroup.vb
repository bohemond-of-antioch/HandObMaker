Public Class ThicknessGroup
    Public Class Box
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
        Public Sub New()

        End Sub

        Public Sub New(Left As Integer, Top As Integer, Right As Integer, Bottom As Integer)
            Me.Left = Left
            Me.Top = Top
            Me.Right = Right
            Me.Bottom = Bottom
        End Sub

        Public ReadOnly Property Width() As Integer
            Get
                Return Right - Left + 1
            End Get
        End Property
        Public ReadOnly Property Height() As Integer
            Get
                Return Bottom - Top + 1
            End Get
        End Property
        Public Sub ShiftTLCorner(Position As Point)
            Left = Position.X
            Top = Position.Y
        End Sub
        Public Sub ShiftBRCorner(Position As Point)
            Right = Position.X
            Bottom = Position.Y
        End Sub

        Public Sub Relocate(Position As Point)
            If Right + Position.X - Left < 0 Then Exit Sub
            If Bottom + Position.Y - Top < 0 Then Exit Sub
            If Position.Y > BigObHeight - 1 Then Exit Sub
            If Position.X > BigObWidth - 1 Then Exit Sub

            Right += Position.X - Left
            Bottom += Position.Y - Top
            Left = Position.X
            Top = Position.Y
        End Sub

        Public Function Repair() As Boolean
            Repair = False
            If Left > Right Then
                Left = Right
                Repair = True
            End If
            If Top > Bottom Then
                Top = Bottom
                Repair = True
            End If
        End Function

        Public Property Location() As Point
            Get
                Return New Point(Left, Top)
            End Get
            Set(value As Point)
                Relocate(value)
            End Set
        End Property

        Public Function Contains(X As Integer, Y As Integer) As Boolean
            Return X >= Left And X <= Right And Y >= Top And Y <= Bottom
        End Function
    End Class

    Public Color As Color
    Public Areas As List(Of Box)
    Public Enabled As Boolean
    Public Thickness As Integer

    Public Sub New(SetColor As Color)
        Color = SetColor
        Areas = New List(Of Box)
        Thickness = 1
    End Sub

    Public Sub AddArea(Area As Box)
        Areas.Add(Area)
    End Sub

    Public Sub RemoveArea(Index As Integer)
        Areas.RemoveAt(Index)
    End Sub

    Public Function AreaAtPosition(Position As Point) As Integer
        Return AreaAtPosition(Position.X, Position.Y)
    End Function

    Public Function AreaAtPosition(X As Integer, Y As Integer) As Integer
        AreaAtPosition = -1
        For a = 0 To Areas.Count - 1
            If Areas(a).Contains(X, Y) Then
                Return a
            End If
        Next a
    End Function

End Class
