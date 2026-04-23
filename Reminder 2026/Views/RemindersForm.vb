Imports System.ComponentModel
Imports System.IO
Imports Reminder_2026

Public Class RemindersForm
    ''' <summary>
    ''' Признак завершения работы программы.
    ''' </summary>
    Private AppExit As Boolean = False

    Private sourceFile As String = Path.Combine(Application.StartupPath, "Reminders.xml")

    ''' <summary>
    ''' Ссылка на форму отображения напоминаний.
    ''' </summary>
    ''' <remarks>Если эта ссылка не null, то значит форма отображается и следует работать с формой по этой ссылке.</remarks>
    Friend DisplayReminderForm As DisplayRemindersForm

    ''' <summary>
    ''' Коллекция напоминаний.
    ''' </summary>
    Public Reminders As List(Of Reminder)

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        Reminders = New List(Of Reminder)
        LoadReminders() ' загрузим сохранённые напоминания
        AddHandler RemindersBindingSource.ListChanged, AddressOf ReNumberReminders
        RemindersBindingSource.DataSource = Reminders ' привяжем задания к объекту привязки
        ConfigureReminderDataGridView() ' настроим сетку для отображения напоминаний
        ReminderTextBox.DataBindings.Add("Text", RemindersBindingSource, "Text") ' 
        RemindersBindingSource.ResetBindings(False) ' вызовем обновление объекта привязки
        ReminderTimer.Start()
    End Sub


    Private Sub LoadReminders()
        Try
            Dim serializer As New Xml.Serialization.XmlSerializer(GetType(List(Of Reminder)))
            ' загрузим напоминания если файл существует
            If IO.File.Exists(sourceFile) Then
                Using fs As New System.IO.FileStream(sourceFile, FileMode.Open)
                    Me.Reminders = serializer.Deserialize(fs)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка чтения напоминаний из файла.", MessageBoxButtons.OK)
        End Try

        'Reminders.Add(New Reminder() With {.Number = 1,
        '                                   .IsActive = True,
        '                                   .Text = "Test",
        '                                   .DateFrom = DateTime.Now,
        '                                   .DateTo = .DateFrom.AddDays(1),
        '                                   .NextDate = Nothing,
        '                                   .ExecIfLate = True,
        '                                   .Periodicity = New OneTime()})
        'Reminders.Add(New Reminder() With {.Number = 2,
        '                                   .IsActive = False,
        '                                   .Text = "Задание 2",
        '                                   .DateFrom = DateTime.Now,
        '                                   .DateTo = .DateFrom.AddDays(1),
        '                                   .NextDate = Now,
        '                                   .ExecIfLate = True,
        '                                   .Periodicity = New TimeInterval() With {.Interval = New TimeSpan(100000),
        '                                                                           .Text = "Каждый день",
        '                                                                           .FrequencyOfRepeate = Repetitions.SomeDays}})

    End Sub

    ''' <summary>
    ''' Перенумерует список напоминаний.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ReNumberReminders(sender As Object, e As ListChangedEventArgs)
        For i As Integer = 0 To RemindersBindingSource.Count - 1
            RemindersBindingSource(i).Number = i + 1
        Next
    End Sub

    ''' <summary>
    ''' Инициализация DataGridView отображающего напоминания.
    ''' </summary>
    Private Sub ConfigureReminderDataGridView()
        Dim NumberColumn As New DataGridViewTextBoxColumn
        NumberColumn.DataPropertyName = NameOf(Reminder.Number)
        NumberColumn.HeaderText = "№"
        NumberColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        RemindersDataGridView.Columns.Add(NumberColumn)

        Dim DateFromColumn As New DataGridViewTextBoxColumn
        DateFromColumn.DataPropertyName = NameOf(Reminder.DateFrom)
        DateFromColumn.HeaderText = "Выполнять начиная с"
        RemindersDataGridView.Columns.Add(DateFromColumn)

        Dim DateNextColumn As New DataGridViewTextBoxColumn
        DateNextColumn.DataPropertyName = NameOf(Reminder.NextDate)
        DateNextColumn.HeaderText = "Следующий раз"
        RemindersDataGridView.Columns.Add(DateNextColumn)

        Dim DateToColumn As New DataGridViewTextBoxColumn
        DateToColumn.DataPropertyName = "DateToText"
        DateToColumn.HeaderText = "Выполнять до"
        RemindersDataGridView.Columns.Add(DateToColumn)

        Dim PeriodicColumn As New DataGridViewTextBoxColumn
        PeriodicColumn.DataPropertyName = "PeriodicityText"
        PeriodicColumn.HeaderText = "Периодичность"
        RemindersDataGridView.Columns.Add(PeriodicColumn)

        Dim ActiveColumn As New DataGridViewTextBoxColumn
        ActiveColumn.DataPropertyName = NameOf(Reminder.IsActive)
        ActiveColumn.DefaultCellStyle.FormatProvider = New BoolFormatter()
        ActiveColumn.DefaultCellStyle.Format = "ДаНет"
        ActiveColumn.HeaderText = "Активно"
        ActiveColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        RemindersDataGridView.Columns.Add(ActiveColumn)

        RemindersDataGridView.EnableHeadersVisualStyles = False
        RemindersDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = RemindersDataGridView.ColumnHeadersDefaultCellStyle.BackColor
    End Sub

    ''' <summary>
    ''' Обрабатывает форматирование ячеек с применением кастомного форматтера.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Применяется для поля 'Активно'</remarks>
    Private Sub RemindersDataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles RemindersDataGridView.CellFormatting
        If TypeOf e.CellStyle.FormatProvider Is ICustomFormatter Then
            Dim formatter As ICustomFormatter = e.CellStyle.FormatProvider.GetFormat(GetType(ICustomFormatter))
            If formatter IsNot Nothing Then
                e.Value = formatter.Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider)
                e.FormattingApplied = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' Обработчик таймера приложения. Выполняет проверку наступления момента напоминаний.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ReminderTimer_Tick(sender As Object, e As EventArgs) Handles ReminderTimer.Tick
        Dim ThisMoment As DateTime = DateTime.Now
        ReminderTimer.Stop()

        For Each cRem As Reminder In RemindersBindingSource
            If cRem.IsActive Then
                If RequiredToComplete(cRem) = True Then
                    ' тут показываем напоминание
                    If DisplayReminderForm Is Nothing Then
                        DisplayReminderForm = New DisplayRemindersForm()
                        DisplayReminderForm.Owner = Me
                        DisplayReminderForm.Show()
                    End If

                    DisplayReminderForm.Reminders.Add(cRem)
                    SetNextTime(cRem) ' установим следующую дату напоминания.
                    DisplayReminderForm.BringToFront()

                End If
            End If
        Next

        ReminderTimer.Start()
    End Sub


    ''' <summary>
    ''' Проверяет напоминание на предмет наступления момента его выполнения.
    ''' </summary>
    ''' <param name="currentReminder">Проверяемое напоминание.</param>
    ''' <returns>Возвращает True если напоминание необходимо выполнить и False в противном случае.</returns>
    Private Function RequiredToComplete(ByVal currentReminder As Reminder) As Boolean
        Dim thisMoment As DateTime = DateTime.Now
        ' проверяем поле даты следующего выполнения.
        If (currentReminder.NextDate IsNot Nothing) AndAlso (currentReminder.NextDate < thisMoment) Then
            Return True
        End If

        ' если включен флаг "выполнять, когда опаздывает", то ориентируемся на дату начала напоминания.
        If (currentReminder.NextDate Is Nothing) And currentReminder.ExecIfLate And (currentReminder.DateFrom < thisMoment) Then
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' Устанавливает дату следующего выполнения и снимает флаг активности при необходимости.
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
        Else
            ' у не повторяющихся напоминаний сразу снимаем флаг выполнения,
            ' так как их выполнение в текущем методе считается произошедшим.
            currentReminder.IsActive = False
            currentReminder.NextDate = Nothing
        End If

        ' если напоминание не бесконечное проверим необходимость его деактивации.
        If currentReminder.ExecForever = False Then
            ' если следующий момент выполнения превышает дату окончания выполнения
            ' или наступил момент окончания напоминания.
            If (currentReminder.NextDate > currentReminder.DateTo) Or
               (currentReminder.DateTo < thisMoment) Then
                currentReminder.IsActive = False
                currentReminder.NextDate = Nothing
            End If
        End If

    End Sub

#Region "Commands" ' команды меню
    ''' <summary>
    ''' Команда в меню формы для создания напоминания.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddReminderToolStripButton_Click(sender As Object, e As EventArgs) Handles AddReminderToolStripButton.Click
        CreateReminder()
    End Sub

    ''' <summary>
    ''' Команда в меню формы для редактирования напоминания.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EditReminderToolStripButton_Click(sender As Object, e As EventArgs) Handles EditReminderToolStripButton.Click
        EditReminder()
    End Sub

    ''' <summary>
    ''' Команда в меню формы для удаления напоминания.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DeleteReminderToolStripButton_Click(sender As Object, e As EventArgs) Handles DeleteReminderToolStripButton.Click
        DeleteReminder()
    End Sub

    ''' <summary>
    ''' Вызывает форму создания нового напоминание.
    ''' </summary>
    Private Sub CreateReminder()
        Dim CreateReminderForm As New EditReminderForm(CreateNewReminder:=True)
        CreateReminderForm.Text = "Новое напоминание"
        CreateReminderForm.StartPosition = FormStartPosition.Manual
        CreateReminderForm.Location = FormHelper.GetLocationPoint(Me, Me.Location, New Point(20, 20))
        CreateReminderForm.ShowDialog()
        If CreateReminderForm.DialogResult = DialogResult.OK Then
            RemindersBindingSource.Add(CreateReminderForm.Reminder)
        End If
        CreateReminderForm.Dispose()
    End Sub

    ''' <summary>
    ''' Вызывает форму редактирования напоминания.
    ''' </summary>
    Private Sub EditReminder()
        Dim EditForm As New EditReminderForm(CreateNewReminder:=False)
        EditForm.Text = "Изменить напоминание"
        EditForm.StartPosition = FormStartPosition.Manual
        EditForm.Location = FormHelper.GetLocationPoint(Me, Me.Location, New Point(20, 20))

        Dim currentReminderIndex As Integer = RemindersBindingSource.Position
        EditForm.Reminder = RemindersBindingSource.Current.Clone()
        EditForm.ShowDialog()
        If EditForm.DialogResult = DialogResult.OK Then
            RemindersBindingSource(currentReminderIndex) = EditForm.Reminder
        End If
        EditForm.Dispose()
    End Sub

    ''' <summary>
    ''' Удаляет текущиее напоминание.
    ''' </summary>
    Private Sub DeleteReminder()
        RemindersBindingSource.RemoveCurrent()
    End Sub

#Region "DataGridView commands"
    ' команды контекстного меню DataGridView напоминаний

    Private Sub CreateReminderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateReminderToolStripMenuItem.Click
        CreateReminder()
    End Sub

    Private Sub EditReminderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditReminderToolStripMenuItem.Click
        EditReminder()
    End Sub

    Private Sub DeleteReminderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteReminderToolStripMenuItem.Click
        DeleteReminder()
    End Sub

    Private Sub ChangeActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeActivityToolStripMenuItem.Click
        Dim currentReminder As Reminder = CType(RemindersBindingSource.Current, Reminder)
        currentReminder.IsActive = Not currentReminder.IsActive
    End Sub
#End Region
#End Region

    ''' <summary>
    ''' Отображает форму настройки напоминаний.
    ''' </summary>
    Private Sub ShowRemindersForm()
        Me.ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        Me.Show()
    End Sub

    Private Sub RemindersForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Hide()
        SaveReminders()
        If AppExit = False Then
            e.Cancel = True ' отмена закрытия приложения
        End If
    End Sub

    ''' <summary>
    ''' Записывает напоминания в файл.
    ''' </summary>
    Private Sub SaveReminders()
        Try
            Dim serializer As New Xml.Serialization.XmlSerializer(GetType(List(Of Reminder)))
            'Reminders = RemindersBindingSource.DataSource
            Using fs As New System.IO.FileStream(sourceFile, FileMode.Create)
                serializer.Serialize(fs, Reminders)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка записи напоминаний", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ReminderNotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ReminderNotifyIcon.MouseDoubleClick
        ShowRemindersForm()
    End Sub

#Region "MainContextMenu"
    ' Команды контекстного меню иконки приложения в трее

    ''' <summary>
    ''' Команда отображения формы настройки напоминаний.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RemindersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemindersToolStripMenuItem.Click
        ShowRemindersForm()
    End Sub

    ''' <summary>
    ''' Команда закрытия приложения.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        AppExit = True
        Close()
    End Sub

    ''' <summary>
    ''' Команда запуска и остановки процесса обработки напоминаний.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub IsActiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IsActiveToolStripMenuItem.Click
        If IsActiveToolStripMenuItem.Checked = True Then
            IsActiveToolStripMenuItem.Checked = False
            ReminderTimer.Stop()
        Else
            IsActiveToolStripMenuItem.Checked = True
            ReminderTimer.Start()
        End If
    End Sub

#End Region

End Class
