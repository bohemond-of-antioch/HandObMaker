Public Structure DoubleVector3
    Public X As Double
    Public Y As Double
    Public Z As Double

    Public Sub New(X As Double, Y As Double, Z As Double)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
    End Sub

    Public Shared Operator +(ByVal A As DoubleVector3, ByVal B As DoubleVector3)
        Return New DoubleVector3(A.X + B.X, A.Y + B.Y, A.Z + B.Z)
    End Operator

    Public Shared Operator -(ByVal A As DoubleVector3, ByVal B As DoubleVector3)
        Return New DoubleVector3(A.X - B.X, A.Y - B.Y, A.Z - B.Z)
    End Operator

    Public Shared Operator =(ByVal A As DoubleVector3, ByVal B As DoubleVector3)
        Return A.X = B.X And A.Y = B.Y And A.Z = B.Z
    End Operator

    Public Shared Operator <>(ByVal A As DoubleVector3, ByVal B As DoubleVector3)
        Return Not (A.X = B.X And A.Y = B.Y And A.Z = B.Z)
    End Operator
End Structure
