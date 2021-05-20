Imports Telegram.Bot
Module SC
    Public BC As ITelegramBotClient
    Public Event BC_MessageReceived(sa As String)
    Sub OnMessage(ByVal sender As Object, ByVal e As Args.MessageEventArgs)
        If e.Message.Text <> Nothing Then RaiseEvent BC_MessageReceived(e.Message.Text)
    End Sub
    Async Sub SendMessage(id As String, ness As String)
        Try : Await BC.SendTextMessageAsync(id, ness) : Catch ex As Exception : End Try
    End Sub
    Function ISBCLive() As Boolean
        Try : Dim crs = BC.GetMeAsync().Result : Return True : Catch ex As Exception : Return False : End Try
    End Function
    Async Sub SendChatActionAsync(id As String, document As Types.Enums.ChatAction)
        Try : Await BC.SendChatActionAsync(id, document) : Catch ex As Exception : End Try
    End Sub
    Async Sub SendImageFile(ByVal destID As String, ByVal Path As String, Optional DescriptionFile As String = "") ' As Task
        Try : Dim objReader As IO.StreamReader, objFS As IO.FileStream
            objFS = New IO.FileStream(Path, IO.FileMode.Open) : objReader = New IO.StreamReader(objFS)
            Await BC.SendPhotoAsync(destID, objFS, DescriptionFile)
            objReader.Close() : objFS.Close() : objReader.Dispose() : objFS.Dispose() : objFS = Nothing : objReader = Nothing
        Catch e As Exception : End Try
    End Sub
    Async Sub SendAudioFile(ByVal destID As String, ByVal Path As String, Optional DescriptionFile As String = "") ' As Task
        Try : Dim objReader As IO.StreamReader, objFS As IO.FileStream
            objFS = New IO.FileStream(Path, IO.FileMode.Open) : objReader = New IO.StreamReader(objFS)
            Await BC.SendAudioAsync(destID, objFS, DescriptionFile)
            objReader.Close() : objFS.Close() : objReader.Dispose() : objFS.Dispose() : objFS = Nothing : objReader = Nothing
        Catch e As Exception : End Try
    End Sub
    Async Sub SendVideoFile(ByVal destID As String, ByVal Path As String, Optional DescriptionFile As String = "") ' As Task
        Try : Dim objReader As IO.StreamReader, objFS As IO.FileStream
            objFS = New IO.FileStream(Path, IO.FileMode.Open) : objReader = New IO.StreamReader(objFS)
            Await BC.SendVideoAsync(destID, objFS, DescriptionFile)
            objReader.Close() : objFS.Close() : objReader.Dispose() : objFS.Dispose() : objFS = Nothing : objReader = Nothing
        Catch e As Exception : End Try
    End Sub

End Module
