Imports BO
Imports DAO
Public Class Alumno
    Public Shared Function GetAll() As List(Of BO.Alumno)
        Return DAO.Alumno.GetAll()
    End Function

    Public Shared Function Save(ByRef al As BO.Alumno) As Integer
        Return DAO.Alumno.Save(al)
    End Function
End Class
