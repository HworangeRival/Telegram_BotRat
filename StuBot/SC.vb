Imports Telegram.Bot
Module SC
    Public BotClient As ITelegramBotClient
    Public Event BotClientMessageReceived(sa As String)
    Sub Bot_OnMessage(ByVal sender As Object, ByVal e As Args.MessageEventArgs)
        If e.Message.Text <> Nothing Then RaiseEvent BotClientMessageReceived(e.Message.Text)
    End Sub
    Async Sub Bot_SendMessage(id As String, ness As String)
        Try
            Await BotClient.SendTextMessageAsync(id, ness)
            ' Debug.WriteLine("Message Sended!!")
        Catch ex As Exception
            '     Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Function ISBotConnected() As Boolean
        Try
            Dim crs = BotClient.GetMeAsync().Result
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
