Imports System.Data.SqlClient
Imports System.Configuration
Public Class Conexion
    Shared sqlConn As SqlConnection
    Public Shared Function conectar() As SqlConnection
        sqlConn = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)
        Return sqlConn
    End Function
End Class
