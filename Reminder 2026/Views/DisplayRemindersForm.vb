Imports System.ComponentModel

Public Class DisplayRemindersForm
    Public Property Reminders As New System.ComponentModel.BindingList(Of Reminder)

    Private Sub DisplayRemindersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Reminders.ListChanged, AddressOf RemindersChanged
    End Sub

    Private Sub RemindersChanged(sender As Object, e As ListChangedEventArgs)
        If e.ListChangedType = ListChangedType.ItemAdded Then
            Dim addedReminder As Reminder = Reminders(e.NewIndex)
            RemindersTextBox.AppendText(addedReminder.NextDate.ToString + " " + addedReminder.Text + vbNewLine)
        End If
    End Sub

    Private Sub DisplayRemindersForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim MeOwner As RemindersForm = Me.Owner
        MeOwner.DisplayReminderForm = Nothing
    End Sub
End Class