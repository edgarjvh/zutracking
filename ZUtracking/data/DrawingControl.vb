Imports System.Runtime.InteropServices

Public Class DrawingControl
    Public Sub New()
    End Sub
    <DllImport("user32.dll")>
    Public Shared Function SendMessage(hWnd As IntPtr, wMsg As Int32, wParam As Boolean, lParam As Int32) As Integer
    End Function

    Private Const WM_SETREDRAW As Integer = 11
    ''' <summary>
    ''' Some controls, such as the DataGridView, do not allow setting the DoubleBuffered property.
    ''' It is set as a protected property. This method is a work-around to allow setting it.
    ''' Call this in the constructor just after InitializeComponent().
    ''' </summary>
    ''' <param name="control">The Control on which to set DoubleBuffered to true.</param>
    Public Shared Sub SetDoubleBuffered(control As Control)
        ' if not remote desktop session then enable double-buffering optimization

        If Not System.Windows.Forms.SystemInformation.TerminalServerSession Then
            ' set instance non-public property with name "DoubleBuffered" to true
            GetType(Control).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic, Nothing, control, New Object() {True})
        End If
    End Sub

    ''' <summary>
    ''' Suspend drawing updates for the specified control. After the control has been updated
    ''' call DrawingControl.ResumeDrawing(Control control).
    ''' </summary>
    ''' <param name="control">The control to suspend draw updates on.</param>
    Public Shared Sub SuspendDrawing(control As Control)
        SendMessage(control.Handle, WM_SETREDRAW, False, 0)
    End Sub

    ''' <summary>
    ''' Resume drawing updates for the specified control.
    ''' </summary>
    ''' <param name="control">The control to resume draw updates on.</param>
    Public Shared Sub ResumeDrawing(control As Control)
        SendMessage(control.Handle, WM_SETREDRAW, True, 0)
        control.Refresh()
    End Sub
End Class