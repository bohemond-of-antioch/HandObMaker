Public Structure IntVector3
    Public X As Integer
    Public Y As Integer
    Public Z As Integer

    Public Sub New(X As Integer, Y As Integer, Z As Integer)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
    End Sub

    Public Shared Operator +(ByVal A As IntVector3, ByVal B As IntVector3)
        Return New IntVector3(A.X + B.X, A.Y + B.Y, A.Z + B.Z)
    End Operator

    Public Shared Operator -(ByVal A As IntVector3, ByVal B As IntVector3)
        Return New IntVector3(A.X - B.X, A.Y - B.Y, A.Z - B.Z)
    End Operator

    Public Shared Operator =(ByVal A As IntVector3, ByVal B As IntVector3)
        Return A.X = B.X And A.Y = B.Y And A.Z = B.Z
    End Operator

    Public Shared Operator <>(ByVal A As IntVector3, ByVal B As IntVector3)
        Return Not (A.X = B.X And A.Y = B.Y And A.Z = B.Z)
    End Operator

    Public Overrides Function ToString() As String
        Return String.Format("[{0}, {1}, {2}]", X, Y, Z)
    End Function

End Structure
