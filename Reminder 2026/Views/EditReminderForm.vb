Public Class EditReminderForm
    ''' <summary>
    ''' Формируемое напоминание.
    ''' </summary>
    ''' <remarks>Может быть установлен извне для редактирования.</remarks>>
    Public Property Reminder As Reminder

    Private MinutsList As List(Of Integer) ' список минут
    Private HoursList As List(Of Integer) ' список часов

    Public Sub New(ByVal CreateNewReminder As Boolean)

        If (CreateNewReminder = True) Or (Me.Reminder Is Nothing) Then
            Me.Reminder = New Reminder()
            Me.Reminder.Periodicity = New OneTime()
        Else
            ' тут надо клонировать напоминание
        End If

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().

    End Sub

    Private Sub EditReminderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MinutsList = New List(Of Integer)(Enumerable.Range(1, 59))
        MinutsComboBox.DataSource = MinutsList

        HoursList = New List(Of Integer)(Enumerable.Range(1, 23))
        HoursComboBox.DataSource = HoursList

        ' объект привязки с дате начала напоминания
        Dim DateFromBinding As New Binding("Text", Me.Reminder, "DateFrom")
        ' делаем доступным форматирование
        DateFromBinding.FormattingEnabled = True
        ' задаём строку формата
        DateFromBinding.FormatString = "dd.MM.yyyy HH:mm"
        ' установим привязку к элементу управления
        DateFromLabel.DataBindings.Add(DateFromBinding)

        ' объект привязки с дате окончания напоминания
        Dim DateToBinding As New Binding("Text", Me.Reminder, "DateTo")
        ' делаем доступным форматирование
        DateToBinding.FormattingEnabled = True
        ' задаём строку формата
        DateToBinding.FormatString = "dd.MM.yyyy HH:mm"
        ' установим привязку к элементу управления
        DateToLabel.DataBindings.Add(DateToBinding)

        ReminderTextBox.DataBindings.Add("Text", Me.Reminder, "Text")
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub



    Private Sub DateToCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles DateToCheckBox.CheckedChanged
        If DateToCheckBox.Checked = True Then
            DateToLabel.Enabled = True
            DateToButton.Enabled = True
        Else
            DateToLabel.Enabled = False
            DateToButton.Enabled = False
        End If
    End Sub


    Private Sub DateFromButton_Click(sender As Object, e As EventArgs) Handles DateFromButton.Click
        Dim SetDateForm As New SetDateAndTimeForm()
        SetDateForm.Text = "Выполнять начиная с:"
        SetDateForm.DateAndTime = Me.Reminder.DateFrom
        SetDateForm.StartPosition = FormStartPosition.Manual
        SetDateForm.Location = GetLocationPoint(Me.Location, New Point(22, 90))
        SetDateForm.ShowDialog()
        If SetDateForm.DialogResult = DialogResult.OK Then
            Me.Reminder.DateFrom = SetDateForm.DateAndTime
        End If
        SetDateForm.Dispose()
    End Sub

    Private Sub DateToButton_Click(sender As Object, e As EventArgs) Handles DateToButton.Click
        Dim SetDateForm As New SetDateAndTimeForm()
        SetDateForm.Text = "Выполнять до:"
        SetDateForm.DateAndTime = Me.Reminder.DateTo
        SetDateForm.StartPosition = FormStartPosition.Manual
        SetDateForm.Location = GetLocationPoint(Me.Location, New Point(22, 126))
        SetDateForm.ShowDialog()
        If SetDateForm.DialogResult = DialogResult.OK Then
            Me.Reminder.DateTo = SetDateForm.DateAndTime
        End If
        SetDateForm.Dispose()
    End Sub

    ''' <summary>
    ''' Вызвращает точку всегда находящуюся на экране.
    ''' </summary>
    ''' <param name="originalPoint">Исходные координаты точки.</param>
    ''' <param name="Offset">Желаемое смещение точки.</param>
    ''' <returns></returns>
    Private Function GetLocationPoint(ByVal originalPoint As Point, ByVal Offset As Point) As Point
        Dim newPoint As Point = originalPoint
        newPoint.X = newPoint.X + Offset.X
        Dim xx = Screen.FromControl(Me).WorkingArea
        If newPoint.X > Screen.FromControl(Me).WorkingArea.Width Then
            newPoint.X = originalPoint.X
        End If

        newPoint.Y = newPoint.Y + Offset.Y
        If newPoint.Y > Screen.FromControl(Me).WorkingArea.Height Then
            newPoint.Y = originalPoint.Y
        End If

        Return newPoint
    End Function

#Region "Periodicity" ' параметры периодичности

    Private Sub MinutsRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MinutsRadioButton.CheckedChanged
        If MinutsRadioButton.Checked = True Then
            Dim minuts As Integer = MinutsComboBox.SelectedValue

            Dim periodic As IPeriodicity = New TimeInterval()
            periodic.Interval = TimeSpan.FromMinutes(minuts)
            periodic.FrequencyOfRepeate = Repetitions.SomeMinuts

            If minuts = 1 Then
                periodic.Text = $"Каждую минуту"
            ElseIf minuts < 5 Then
                periodic.Text = $"Каждые {minuts} минуты"
            Else
                periodic.Text = $"Каждые {minuts} минут"
            End If
            Me.Reminder.Periodicity = periodic
        End If
    End Sub

    Private Sub HoursRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles HoursRadioButton.CheckedChanged
        If HoursRadioButton.Checked = True Then
            Dim hours As Integer = HoursComboBox.SelectedValue

            Dim periodic As IPeriodicity = New TimeInterval()
            periodic.Interval = TimeSpan.FromHours(hours)
            periodic.FrequencyOfRepeate = Repetitions.SomeHours
            periodic.Text = $"Каждый {HoursComboBox.SelectedValue} час"

            Me.Reminder.Periodicity = periodic
        End If
    End Sub

    Private Sub DaysRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles DaysRadioButton.CheckedChanged
        If DaysRadioButton.Checked = True Then
            Dim days As Integer = DaysNumericUpDown.Value

            Dim periodic As IPeriodicity = New TimeInterval()
            periodic.Interval = TimeSpan.FromDays(days)
            periodic.FrequencyOfRepeate = Repetitions.SomeDays
            periodic.Text = $"Каждый {days} час"

            Me.Reminder.Periodicity = periodic
        End If
    End Sub

    Private Sub MonthRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MonthRadioButton.CheckedChanged
        If MonthRadioButton.Checked = True Then
            Dim periodic As IPeriodicity = New TimeInterval()
            periodic.Interval = TimeSpan.Zero
            periodic.FrequencyOfRepeate = Repetitions.EveryMonth
            periodic.Text = "Ежемесячно"

            Me.Reminder.Periodicity = periodic
        End If
    End Sub

    Private Sub YearRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles YearRadioButton.CheckedChanged
        If YearRadioButton.Checked = True Then
            Dim periodic As IPeriodicity = New TimeInterval()
            periodic.Interval = TimeSpan.Zero
            periodic.FrequencyOfRepeate = Repetitions.EveryYear
            periodic.Text = "Ежегодно"

            Me.Reminder.Periodicity = periodic
        End If
    End Sub

    Private Sub OnceRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles OnceRadioButton.CheckedChanged
        If OnceRadioButton.Checked = True Then
            Dim periodic As IPeriodicity = New OneTime()
            periodic.Interval = TimeSpan.Zero

            Me.Reminder.Periodicity = periodic
        End If
    End Sub

#End Region

End Class