Imports System.ComponentModel

Public Class RemindersForm
    ''' <summary>
    ''' Признак завершения работы программы.
    ''' </summary>
    Private AppExit As Boolean = False

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
        RemindersBindingSource.DataSource = Reminders ' привяжем задания к объекту привязке
        ConfigureReminderDataGridView() ' настроим сетку для отображения напоминаний
        ReminderTextBox.DataBindings.Add("Text", RemindersBindingSource, "Text") ' 
        RemindersBindingSource.ResetBindings(False) ' вызовем обновление объекта привязки
    End Sub


    Private Sub LoadReminders()
        Reminders.Add(New Reminder() With {.Number = 1,
                                           .IsActive = True,
                                           .Text = "Test",
                                           .ExecuteFrom = DateTime.Now,
                                           .ExecuteTo = .ExecuteFrom.AddDays(1),
                                           .NextExecute = Now,
                                           .Periodicity = New TimeInterval() With {.IsPeriodic = False, .Interval = New TimeSpan(100000), .Text = "Однократно"}})
        Reminders.Add(New Reminder() With {.Number = 2,
                                           .IsActive = False,
                                           .Text = "Задание 2",
                                           .ExecuteFrom = DateTime.Now,
                                           .ExecuteTo = .ExecuteFrom.AddDays(1),
                                           .NextExecute = Now,
                                           .Periodicity = New TimeInterval() With {.IsPeriodic = True, .Interval = New TimeSpan(100000), .Text = "Каждый день"}})

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
        DateFromColumn.DataPropertyName = NameOf(Reminder.ExecuteFrom)
        DateFromColumn.HeaderText = "Выполнять начиная с"
        RemindersDataGridView.Columns.Add(DateFromColumn)

        Dim DateNextColumn As New DataGridViewTextBoxColumn
        DateNextColumn.DataPropertyName = NameOf(Reminder.NextExecute)
        DateNextColumn.HeaderText = "Следующий раз"
        RemindersDataGridView.Columns.Add(DateNextColumn)

        Dim DateToColumn As New DataGridViewTextBoxColumn
        DateToColumn.DataPropertyName = NameOf(Reminder.ExecuteTo)
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

#Region "Commands"
    ''' <summary>
    ''' Команда в меню формы для удаления напоминания.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DeleteReminderToolStripButton_Click(sender As Object, e As EventArgs) Handles DeleteReminderToolStripButton.Click
        DeleteCurrentReminder()
    End Sub

    ''' <summary>
    ''' Удаляет текущиее напоминание.
    ''' </summary>
    Private Sub DeleteCurrentReminder()
        RemindersBindingSource.RemoveCurrent()
    End Sub

#Region "DataGridView commands"
    ' команды контекстного меню DataGridView напоминаний

    Private Sub DeleteReminderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteReminderToolStripMenuItem.Click
        DeleteCurrentReminder()
    End Sub

    Private Sub ChangeActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeActivityToolStripMenuItem.Click
        Dim currentReminder As Reminder = CType(RemindersBindingSource.Current, Reminder)
        currentReminder.IsActive = Not currentReminder.IsActive
    End Sub
#End Region
#End Region

    Private Sub RemindersForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Hide()
        'If AppExit = False Then
        '    e.Cancel = True
        'End If
    End Sub

#Region "MainContextMenu"

    Private Sub RemindersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemindersToolStripMenuItem.Click
        Me.ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        Me.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        AppExit = True
        Close()
    End Sub





#End Region

End Class
