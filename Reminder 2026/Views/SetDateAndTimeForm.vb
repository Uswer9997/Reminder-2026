Imports System.ComponentModel

Public Class SetDateAndTimeForm
    Implements System.ComponentModel.INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _DateAndTime As DateTime

    ''' <summary>
    ''' Устанавливаемые дата и время.
    ''' </summary>
    ''' <returns></returns>
    Public Property DateAndTime As DateTime
        Get
            Return _DateAndTime
        End Get
        Set
            If _DateAndTime <> Value Then
                _DateAndTime = Value
                OnPropertyChanged("DateAndTime")
            End If
        End Set
    End Property

    Private Sub OnPropertyChanged(ByVal PropertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub

    Private Sub SetDateAndTimeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ReminderDateTimePicker.DataBindings.Add("Value", Me, "DateAndTime")
        ReminderMonthCalendar.DataBindings.Add("SelectionStart", Me, "DateAndTime")
        ReminderTimePicker.Value = Me.DateAndTime
    End Sub

    Private Sub ReminderMonthCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles ReminderMonthCalendar.DateChanged
        ReminderDatePicker.Value = e.Start
    End Sub

    Private Sub ReminderDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles ReminderDatePicker.ValueChanged
        Me.DateAndTime = ReminderDatePicker.Value
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.DialogResult = DialogResult.OK
        Hide()
        Dim targetDateTime As New DateTime(Me.DateAndTime.Year, Me.DateAndTime.Month, Me.DateAndTime.Day)
        targetDateTime = targetDateTime.AddHours(ReminderTimePicker.Value.Hour)
        targetDateTime = targetDateTime.AddMinutes(ReminderTimePicker.Value.Minute)
        Me.DateAndTime = targetDateTime
        Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class