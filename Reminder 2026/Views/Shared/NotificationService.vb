''' <summary>
''' Отображает сообщение об ошибке.
''' </summary>
Public Class NotificationService

    Public Sub ShowError(ByVal message As String)
        MessageBox.Show(text:=message, caption:="Ошибка", buttons:=MessageBoxButtons.OK, icon:=MessageBoxIcon.Error)
    End Sub
End Class
