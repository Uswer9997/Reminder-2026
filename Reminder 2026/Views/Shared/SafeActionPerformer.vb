''' <summary>
''' Выполняет методы с перехватом исключений.
''' </summary>
Public Class SafeActionPerformer

    Private _notificationService As NotificationService

    Public Sub New(ByVal notificationService As NotificationService)
        _notificationService = notificationService
    End Sub

    Public Function Excecute(_action As Action) As SafeActionPerformerResult
        Try
            _action.Invoke()
            Return SafeActionPerformerResult.OK
        Catch ex As Exception
            ExceptionHandler(ex)
            Return SafeActionPerformerResult.Error
        End Try
    End Function

    Public Sub ExceptionHandler(ByVal ex As Exception)
        _notificationService.ShowError(ex.Message + vbNewLine + ex.InnerException.Message)
    End Sub

    Enum SafeActionPerformerResult
        OK
        [Error]
    End Enum
End Class
