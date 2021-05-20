Public Class Form1
    Const WM_CAP As Short = &H400S, WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10, WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11, WM_CAP_EDIT_COPY As Integer = WM_CAP + 30, WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50, WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53, WS_CHILD As Integer = &H40000000, WS_VISIBLE As Integer = &H10000000, SWP_NOMOVE As Short = &H25, SWP_NOSIZE As Short = &H1, SWP_NOZORDER As Short = &H4S, HWND_BOTTOM As Short = 1
    Dim iDevice As Integer = 0, hHwnd As Integer, cnt As Integer = 0, scatto As Boolean = False
    Declare Function SendMessageA Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal iParam As Object) As Integer
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim outo = IO.Path.GetTempPath & "\snapshot"
        If IO.Directory.Exists(outo) = False Then IO.Directory.CreateDirectory(outo)
        outo = outo & "\userlive.png"
        Do : Application.DoEvents() : ApriCam_E_Scatta(outo) : Loop Until scatto
        Threading.Thread.Sleep(1000)
        If IO.File.Exists(outo) Then
            Dim myFile As New IO.FileInfo(outo)
            If myFile.Length > 0 Then
                Application.Exit()
            Else
                My.Resources.BlankPng.Save(outo, Imaging.ImageFormat.Png)
            End If
        Else
            My.Resources.BlankPng.Save(outo, Imaging.ImageFormat.Png)
        End If
        Application.Exit()
    End Sub
    Private Sub ApriCam_E_Scatta(pathscatto As String)
        Dim p As New PictureBox : p.Height = "800" : p.Width = "600"
        Try : hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, p.Handle.ToInt32, 0)
            SyncLock p
                If SendMessageA(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
                    SendMessageA(hHwnd, WM_CAP_SET_SCALE, True, 0) : SendMessageA(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)
                    SendMessageA(hHwnd, WM_CAP_SET_PREVIEW, True, 0) : SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, p.Width, p.Height, SWP_NOMOVE Or SWP_NOZORDER)
                    GeneraCamImmagine(pathscatto) : scatto = True
                Else : DestroyWindow(hHwnd) : scatto = True : End If
            End SyncLock
        Catch ex As Exception : scatto = True : End Try
    End Sub
    Private Sub GeneraCamImmagine(path As String) 'As Image
        Dim data As IDataObject, bmap As Image
        SendMessageA(hHwnd, WM_CAP_EDIT_COPY, 0, 0) : data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(Bitmap)) Then
            bmap = CType(data.GetData(GetType(Bitmap)), Image)
            bmap.Save(path, Imaging.ImageFormat.Png)            'Return bmap
            SendMessageA(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0) : DestroyWindow(hHwnd)
        Else
            SendMessageA(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0) : DestroyWindow(hHwnd)
        End If
    End Sub
End Class
