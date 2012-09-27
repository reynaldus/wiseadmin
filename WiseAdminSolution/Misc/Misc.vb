Public Module Misc
    Public Function GetFuncaoLogon(ByVal nomeFuncao As String) As Integer
        Try
            Select Case nomeFuncao
                Case "logar"
                    Return 1
                Case "deslogar"
                    Return 2
                Case "permissao"
                    Return 3
                Case Else
                    Return -1
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Module
