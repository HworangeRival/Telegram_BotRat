Namespace My
    Partial Friend Class MyApplication
        Private Sub AppStart(ByVal sender As Object, ByVal e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ResolveAssemblies
        End Sub

        Private Function ResolveAssemblies(sender As Object, e As ResolveEventArgs) As Reflection.Assembly
            Dim desiredAssembly As Reflection.AssemblyName = New Reflection.AssemblyName(e.Name)
            If desiredAssembly.Name = "Telegram.Bot" Then
                Return Reflection.Assembly.Load(My.Resources.Telegram_Bot) 'replace with your assembly's resource name
            ElseIf desiredAssembly.Name = "Newtonsoft.Json" Then
                Return Reflection.Assembly.Load(My.Resources.Newtonsoft_Json) 'replace with your assembly's resource name
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace
