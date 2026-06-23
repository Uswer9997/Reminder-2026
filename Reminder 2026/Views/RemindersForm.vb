Imports System.ComponentModel
Imports System.IO
Imports Reminder_2026

''' <summary>
''' Главная форма приложения. При её закрытии приложение закрывается.
''' </summary>
Public Class RemindersForm
    ''' <summary>
    ''' Признак завершения работы программы.
    ''' </summary>
    Private AppExit As Boolean = False

    ''' <summary>
    ''' Сервис отображения сообщений об ошибках.
    ''' </summary>
    Private _NotificationSrv As NotificationService

    ''' <summary>
    ''' Сервис чтения и записи напоминаний в файлы.
    ''' </summary>
    Private _ReminderService As ReminderService

    ''' <summary>
    ''' Ссылка на форму отображения напоминаний.
    ''' </summary>
    ''' <remarks>Если эта ссылка не null, то значит форма отображается и следует работать с формой по этой ссылке.</remarks>
    Friend DisplayReminderForm As DisplayRemindersForm

    ''' <summary>
    ''' Ссылка на форму отображения ежегодных дат.
    ''' </summary>
    Friend _AnnualDatesForm As AnnualDatesForm

    ''' <summary>
    ''' Коллекция периодических напоминаний.
    ''' </summary>
    Public Property PeriodicReminders As List(Of PeriodicReminder)


    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        _NotificationSrv = New NotificationService()
        _ReminderService = New ReminderService(_NotificationSrv) ' инжектируем оповещателя об ошибках в сервис чтения/записи напоминаний
        LoadAppSettings() ' загрузим настройки приложения
        _ReminderService.LoadReminders() ' загрузим все напоминания
        PeriodicReminders = _ReminderService.PeriodicReminders
        AddHandler RemindersBindingSource.ListChanged, AddressOf ReNumberReminders
        RemindersBindingSource.DataSource = PeriodicReminders ' привяжем задания к объекту привязки
        RemindersBindingSource.Filter = ""
        ConfigureReminderDataGridView() ' настроим сетку для отображения напоминаний
        ReminderTextBox.DataBindings.Add("Text", RemindersBindingSource, "Text") ' 
        RemindersBindingSource.ResetBindings(False) ' вызовем обновление объекта привязки
        ReminderTimer.Start()
    End Sub

    ''' <summary>
    ''' Загружает настройки приложения и устанавливает контролы с ними связанные в необходимое состояние.
    ''' </summary>
    Private Sub LoadAppSettings()
        PlaySoundToolStripMenuItem.Checked = My.Settings.PlaySound ' проигрывать или нет звук напоминаний

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

    Private Sub RemindersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    ''' Инициализация DataGridView отображающего напоминания.
    ''' </summary>
    Private Sub ConfigureReminderDataGridView()
        Dim NumberColumn As New DataGridViewTextBoxColumn
        NumberColumn.DataPropertyName = NameOf(PeriodicReminder.Number)
        NumberColumn.HeaderText = "№"
        NumberColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        RemindersDataGridView.Columns.Add(NumberColumn)

        Dim DateFromColumn As New DataGridViewTextBoxColumn
        DateFromColumn.DataPropertyName = NameOf(PeriodicReminder.DateFrom)
        DateFromColumn.HeaderText = "Выполнять начиная с"
        RemindersDataGridView.Columns.Add(DateFromColumn)

        Dim DateNextColumn As New DataGridViewTextBoxColumn
        DateNextColumn.DataPropertyName = NameOf(PeriodicReminder.NextDate)
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
        ActiveColumn.DataPropertyName = NameOf(PeriodicReminder.IsActive)
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
        ReminderTimer.Stop()

        For Each cRem As Reminder In _ReminderService.AllReminders
            Processing(cRem)
        Next

        ReminderTimer.Start()
    End Sub

    ''' <summary>
    ''' Проверяет напоминание на предмет необходимости выполнения и
    ''' выполняет его если это необходимо.
    ''' </summary>
    ''' <param name="processedReminder">Обрабатываемое напоминание.</param>
    Private Sub Processing(ByVal processedReminder As Reminder)
        If processedReminder.IsActive Then
            If RequiredToComplete(processedReminder) = True Then
                ' тут показываем напоминание
                If DisplayReminderForm Is Nothing Then
                    DisplayReminderForm = New DisplayRemindersForm()
                    DisplayReminderForm.Owner = Me
                    DisplayReminderForm.Show()
                End If

                DisplayReminderForm.Reminders.Add(processedReminder)
                SetNextTime(processedReminder) ' установим следующую дату напоминания.
                DisplayReminderForm.BringToFront()

            End If
        End If
    End Sub


    ''' <summary>
    ''' Проверяет напоминание на предмет наступления момента его выполнения.
    ''' </summary>
    ''' <param name="verifiableReminder">Проверяемое напоминание.</param>
    ''' <returns>Возвращает True если напоминание необходимо выполнить и False в противном случае.</returns>
    Private Function RequiredToComplete(ByVal verifiableReminder As Reminder) As Boolean
        Dim thisMoment As DateTime = DateTime.Now
        ' проверяем поле даты следующего выполнения.
        ' Если есть дата следующего выполнения и она уже наступила.
        If (verifiableReminder.NextDate IsNot Nothing) AndAlso (verifiableReminder.NextDate <= thisMoment) Then
            ' если дата окончания выполнения ещё не наступила или бесконечное напоминание.
            If (verifiableReminder.DateTo > thisMoment) Or (verifiableReminder.ExecForever = True) Then
                Return True
            End If

            ' Если включен флаг "выполнять, когда опаздывает". 
            If verifiableReminder.ExecIfLate Then
                ' Если мы здесь, то выполнение было запланировано, т.е. NextDate <> Nothing, но почему-то выполнено не было.
                ' При этом истекло время выполнения, т.е. DateTo < thisMoment, а также напоминание не бесконечное (ExecForever = False).
                ' Но, т.к. установлен флаг "выполнять, когда опаздывает", то всё равно сообщим о необходимости выполнения напоминания.
                Return True
            End If
        End If

        ' для однократного напоминания, которое почему-то не имеет даты следующего выполнения, но активно
        'If verifiableReminder.Periodicity.FrequencyOfRepeate = Repetitions.Once Then
        '    ' ориентируемся на дату начала
        '    If verifiableReminder.DateFrom < thisMoment Then
        '        Return True
        '    End If
        'End If

        Return False
    End Function

    ''' <summary>
    ''' Устанавливает дату следующего выполнения и снимает флаг активности при необходимости.
    ''' </summary>
    ''' <param name="processedReminder">Обрабатываемое напоминание.</param>
    Private Sub SetNextTime(ByVal processedReminder As Reminder)
        Dim thisMoment As DateTime = DateTime.Now

        processedReminder.SetNextTime(thisMoment) ' установим дату следующего выполнения

        Dim periodicRem As PeriodicReminder = TryCast(processedReminder, PeriodicReminder) ' пробуем выполнить приведение типов
        If (periodicRem IsNot Nothing) AndAlso (periodicRem.Periodicity.IsPeriodic = False) Then
            ' у не повторяющихся напоминаний сразу снимаем флаг выполнения,
            ' так как их выполнение в текущем методе считается произошедшим.
            processedReminder.IsActive = False
            processedReminder.NextDate = Nothing
        End If

        ' если напоминание не бесконечное проверим необходимость его деактивации.
        If processedReminder.ExecForever = False Then
            ' если следующий момент выполнения превышает дату окончания выполнения
            ' или наступил момент окончания напоминания.
            If (processedReminder.NextDate > processedReminder.DateTo) Or
               (processedReminder.DateTo <= thisMoment) Then
                processedReminder.IsActive = False
                processedReminder.NextDate = Nothing
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
        _ReminderService.SavePeriodicReminders()
    End Sub

    Private Sub ReminderNotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ReminderNotifyIcon.MouseDoubleClick
        ShowRemindersForm()
    End Sub

#Region "Работа с ежегодными датами"
    ''' <summary>
    ''' Отображает форму ежегодных дат.
    ''' </summary>
    Private Sub ShowAnnualDatesForm()
        If _AnnualDatesForm Is Nothing Then
            _AnnualDatesForm = New AnnualDatesForm()
            _AnnualDatesForm.AnnualDates = _ReminderService.AnnualDates
            AddHandler _AnnualDatesForm.FormClosing, AddressOf AnnualDatesFormClosing
        End If

        _AnnualDatesForm.Show()
    End Sub

    Private Sub AnnualDatesFormClosing(sender As Object, e As FormClosingEventArgs)
        _ReminderService.SaveAnnualDates()
        _AnnualDatesForm = Nothing
    End Sub
#End Region

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
    ''' Команда отображения формы ежегодных дат.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnnualDatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnualDatesToolStripMenuItem.Click
        ShowAnnualDatesForm()
    End Sub

    ''' <summary>
    ''' Команда отображения информационного окна.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutProgramForm.Show()
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

    ''' <summary>
    ''' Команда включения и отключения звука напоминаний.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PlaySoundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlaySoundToolStripMenuItem.Click
        If PlaySoundToolStripMenuItem.Checked = True Then
            PlaySoundToolStripMenuItem.Checked = False
            My.Settings.PlaySound = False
        Else
            PlaySoundToolStripMenuItem.Checked = True
            My.Settings.PlaySound = True
        End If
    End Sub

#End Region

End Class
