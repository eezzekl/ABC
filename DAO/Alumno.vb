Imports System.Data.SqlClient
Imports System.Linq

Public Class Alumno
    Private Shared conn As New SqlConnection
    Private Shared dr As SqlDataReader
    Private Shared cmd As SqlCommand
    Private Shared da As SqlDataAdapter

    Private Shared getAllAl As String = "SP_AlumnoGetAll"

    Public Shared Function GetAll() As List(Of BO.Alumno)
        Try
            Dim lstAlumnos As New List(Of BO.Alumno)
            conn = Conexion.conectar()
            conn.Open()
            cmd = New SqlCommand(getAllAl, conn)
            cmd.CommandType = CommandType.StoredProcedure
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim al As New BO.Alumno
                al.id = dr.GetInt32(dr.GetOrdinal("id"))
                al.nombre = dr.GetString(dr.GetOrdinal("Nombre"))
                al.apellido = dr.GetString(dr.GetOrdinal("Apellido"))
                al.sexo = dr.GetInt32(dr.GetOrdinal("Sexo"))
                al.fNacimiento = dr.GetString(dr.GetOrdinal("FechaNacimiento"))
                lstAlumnos.Add(al)
            End While
            Return lstAlumnos
        Catch ex As Exception
            Throw
        Finally
            conn.Close()
        End Try
    End Function

    Public Shared Function Save(ByVal al As BO.Alumno) As Integer
        Try
            conn = Conexion.conectar()
            conn.Open()
            cmd = New SqlCommand(getAllAl, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters("@id").Value = al.id
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar)
            cmd.Parameters("@nombre").Value = al.nombre
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar)
            cmd.Parameters("@apellido").Value = al.apellido
            cmd.Parameters.Add("@sexo", SqlDbType.Int)
            cmd.Parameters("@sexo").Value = al.sexo
            cmd.Parameters.Add("@fnacimiento", SqlDbType.VarChar)
            cmd.Parameters("@fnacimiento").Value = al.fNacimiento
            Return cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            conn.Close()
        End Try
    End Function
End Class
