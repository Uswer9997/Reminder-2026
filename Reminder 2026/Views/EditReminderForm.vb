Public Class EditReminderForm
    ''' <summary>
    ''' Формируемое напоминание.
    ''' </summary>
    ''' <remarks>Может быть установлен извне для редактирования.</remarks>>
    Public Property Reminder As Reminder

    Private MinutsList As List(Of Integer) ' список минут
    Private HoursList As List(Of Integer) ' список часов
    Private SelectedPeriodicity As Repetitions ' выбранное значение периодичности напоминания

    Public Sub New(ByVal CreateNewReminder As Boolean)

        If (CreateNewReminder = True) Or (Me.Reminder Is Nothing) Then
            Me.Reminder = New Reminder()
            Me.Reminder.Periodicity = New OneTime()
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

        ' установим привязки свойств к элементам управления
        ReminderTextBox.DataBindings.Add("Text", Me.Reminder, "Text")
        LateCheckBox.DataBindings.Add("Checked", Me.Reminder, "ExecIfLate")

        Select Case Me.Reminder.Periodicity.FrequencyOfRepeate
            Case Repetitions.SomeMinuts
                MinutsRadioButton.Checked = True
                MinutsComboBox.SelectedItem = Me.Reminder.Periodicity.Interval.Minutes
            Case Repetitions.SomeHours
                HoursRadioButton.Checked = True
                HoursComboBox.SelectedItem = Me.Reminder.Periodicity.Interval.Hours
            Case Repetitions.SomeDays
                DaysRadioButton.Checked = True
                DaysNumericUpDown.Value = Me.Reminder.Periodicity.Interval.Days
            Case Repetitions.EveryMonth
                MonthRadioButton.Checked = True
            Case Repetitions.EveryYear
                YearRadioButton.Checked = True
            Case Else
                OnceRadioButton.Checked = True
        End Select
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.Reminder.IsActive = True
        BuildPeriodicy()
        SetNextTime(Me.Reminder)
        ' если снят флаг конечной даты 
        If DateToCheckBox.Checked = False Then
            Me.Reminder.DateTo = Nothing
        End If
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub


    ''' <summary>
    ''' Отключает и включает контролы настройки даты окончания.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
        SetDateForm.Location = FormHelper.GetLocationPoint(Me, Me.Location, New Point(22, 90))
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
        SetDateForm.Location = FormHelper.GetLocationPoint(Me, Me.Location, New Point(22, 126))
        SetDateForm.ShowDialog()
        If SetDateForm.DialogResult = DialogResult.OK Then
            Me.Reminder.DateTo = SetDateForm.DateAndTime
        End If
        SetDateForm.Dispose()
    End Sub


    Private Sub LateCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles LateCheckBox.CheckedChanged
        If LateCheckBox.Checked = True Then
            Me.Reminder.ExecIfLate = True
        Else
            Me.Reminder.ExecIfLate = False
        End If
    End Sub

    ''' <summary>
    ''' Устанавливает дату следующего выполнения.
    ''' </summary>
    ''' <param name="currentReminder">Обрабатываемое напоминание.</param>
    Private Sub SetNextTime(ByVal currentReminder As Reminder)
        Dim thisMoment As DateTime = DateTime.Now

        If currentReminder.Periodicity.IsPeriodic = True Then
            Dim newNextDate As DateTime ' дата следующего выполнения
            ' установим текущее значение даты следующего выполнения
            If currentReminder.NextDate Is Nothing Then
                newNextDate = currentReminder.DateFrom ' отсчёт от начала выполнения
            Else
                newNextDate = currentReminder.NextDate ' отсчёт от предыдущей даты выполнения
            End If
            ' установим (изменим) дату следующего выполнения
            Select Case currentReminder.Periodicity.FrequencyOfRepeate
                Case Repetitions.SomeMinuts
                    currentReminder.NextDate = newNextDate.AddMinutes(currentReminder.Periodicity.Interval.TotalMinutes)
                Case Repetitions.SomeHours
                    currentReminder.NextDate = newNextDate.AddHours(currentReminder.Periodicity.Interval.TotalHours)
                Case Repetitions.SomeDays
                    currentReminder.NextDate = newNextDate.AddDays(currentReminder.Periodicity.Interval.TotalDays)
                Case Repetitions.EveryMonth
                    currentReminder.NextDate = newNextDate.AddMonths(1)
                Case Repetitions.EveryYear
                    currentReminder.NextDate = newNextDate.AddYears(1)
            End Select
        End If

        ' если следующий момент выполнения превышает дату окончания выполнения
        If currentReminder.NextDate > currentReminder.DateTo Then
            currentReminder.IsActive = False
            currentReminder.NextDate = Nothing
        End If

        ' если создано напоминание с прошедшими датами
        If currentReminder.DateTo < thisMoment Then
            currentReminder.IsActive = False
        End If
    End Sub

#Region "Periodicity" ' параметры периодичности

    ''' <summary>
    ''' Устанавливает периодичность напоминания в соответствии с выбранными параметрами.
    ''' </summary>
    Private Sub BuildPeriodicy()
        Dim periodic As IPeriodicity = New OneTime()

        Select Case SelectedPeriodicity
            Case Repetitions.Once
                periodic.Interval = TimeSpan.Zero
            Case Repetitions.SomeMinuts
                Dim minuts As Integer = MinutsComboBox.SelectedValue

                periodic = New TimeInterval()
                periodic.Interval = TimeSpan.FromMinutes(minuts)
                periodic.FrequencyOfRepeate = Repetitions.SomeMinuts

                If minuts = 1 Then
                    periodic.Text = $"Каждую минуту"
                ElseIf minuts < 5 Then
                    periodic.Text = $"Каждые {minuts} минуты"
                Else
                    periodic.Text = $"Каждые {minuts} минут"
                End If
            Case Repetitions.SomeHours
                Dim hours As Integer = HoursComboBox.SelectedValue

                periodic = New TimeInterval()
                periodic.Interval = TimeSpan.FromHours(hours)
                periodic.FrequencyOfRepeate = Repetitions.SomeHours
                periodic.Text = $"Каждый {hours} час"
            Case Repetitions.SomeDays
                Dim days As Integer = DaysNumericUpDown.Value

                periodic = New TimeInterval()
                periodic.Interval = TimeSpan.FromDays(days)
                periodic.FrequencyOfRepeate = Repetitions.SomeDays
                periodic.Text = $"Каждый {days} час"
            Case Repetitions.EveryMonth
                periodic = New TimeInterval()
                periodic.Interval = TimeSpan.Zero
                periodic.FrequencyOfRepeate = Repetitions.EveryMonth
                periodic.Text = "Ежемесячно"
            Case Repetitions.EveryYear
                periodic = New TimeInterval()
                periodic.Interval = TimeSpan.Zero
                periodic.FrequencyOfRepeate = Repetitions.EveryYear
                periodic.Text = "Ежегодно"
        End Select

        Me.Reminder.Periodicity = periodic
    End Sub

    Private Sub MinutsRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MinutsRadioButton.CheckedChanged
        If MinutsRadioButton.Checked = True Then
            SelectedPeriodicity = Repetitions.SomeMinuts
        End If
    End Sub

    Private Sub HoursRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles HoursRadioButton.CheckedChanged
        If HoursRadioButton.Checked = True Then
            SelectedPeriodicity = Repetitions.SomeHours
        End If
    End Sub

    Private Sub DaysRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles DaysRadioButton.CheckedChanged
        If DaysRadioButton.Checked = True Then
            SelectedPeriodicity = Repetitions.SomeDays
        End If
    End Sub

    Private Sub MonthRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MonthRadioButton.CheckedChanged
        If MonthRadioButton.Checked = True Then
            SelectedPeriodicity = Repetitions.EveryMonth
        End If
    End Sub

    Private Sub YearRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles YearRadioButton.CheckedChanged
        If YearRadioButton.Checked = True Then
            SelectedPeriodicity = Repetitions.EveryYear
        End If
    End Sub

    Private Sub OnceRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles OnceRadioButton.CheckedChanged
        If OnceRadioButton.Checked = True Then
            SelectedPeriodicity = Repetitions.Once
        End If
    End Sub

    Private Sub MinutsComboBox_Enter(sender As Object, e As EventArgs) Handles MinutsComboBox.Enter
        MinutsRadioButton.Checked = True
    End Sub

    Private Sub HoursComboBox_Enter(sender As Object, e As EventArgs) Handles HoursComboBox.Enter
        HoursRadioButton.Checked = True
    End Sub

    Private Sub DaysNumericUpDown_Enter(sender As Object, e As EventArgs) Handles DaysNumericUpDown.Enter
        DaysRadioButton.Checked = True
    End Sub

#End Region

End Class