Imports System.ComponentModel
Imports System.IO

''' <summary>
''' Форма ежегодных дат.
''' </summary>
Public Class AnnualDatesForm

    ''' <summary>
    ''' Коллекция ежегодных дат.
    ''' </summary>
    Public Property AnnualDates As List(Of AnnualReminder)

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        AnnualDates = New List(Of AnnualReminder)

    End Sub


    ''' <summary>
    ''' Инициализация DataGridView отображающего напоминания.
    ''' </summary>
    Private Sub ConfigureAnnualDatesDataGridView()
        AnnualDatesDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = AnnualDatesDataGridView.ColumnHeadersDefaultCellStyle.BackColor
        AnnualDatesDataGridView.AutoGenerateColumns = False

        Dim DaysAgoColumn As New DataGridViewTextBoxColumn
        DaysAgoColumn.DataPropertyName = NameOf(AnnualReminder.DaysAgo)
        DaysAgoColumn.HeaderText = "За"
        DaysAgoColumn.HeaderCell.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        DaysAgoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DaysAgoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        AnnualDatesDataGridView.Columns.Add(DaysAgoColumn)

        Dim DateFromColumn As New DataGridViewTextBoxColumn
        DateFromColumn.DataPropertyName = NameOf(AnnualReminder.DateFrom)
        DateFromColumn.HeaderText = "Дата"
        DateFromColumn.HeaderCell.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        DaysAgoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DateFromColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        AnnualDatesDataGridView.Columns.Add(DateFromColumn)


        Dim TextColumn As New DataGridViewTextBoxColumn
        TextColumn.DataPropertyName = NameOf(AnnualReminder.Text)
        TextColumn.HeaderText = "Описание ежегодной даты"
        AnnualDatesDataGridView.Columns.Add(TextColumn)

        'AnnualDatesDataGridView.EnableHeadersVisualStyles = False
        AnnualDatesDataGridView.DataSource = AnnualDatesBindingSource
    End Sub


    Private Sub AnnualDatesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureAnnualDatesDataGridView() ' настроим сетку для отображения дат
        AnnualDatesBindingSource.DataSource = AnnualDates ' привяжем задания к объекту привязки
    End Sub

#Region "Commands" ' команды меню
    ''' <summary>
    ''' Команда в меню формы для создания напоминания.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddAnnualDateToolStripButton_Click(sender As Object, e As EventArgs) Handles AddAnnualDateToolStripButton.Click
        CreateAnnualDate()
    End Sub

    ''' <summary>
    ''' Команда в меню формы для редактирования напоминания.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EditAnnualDateToolStripButton_Click(sender As Object, e As EventArgs) Handles EditAnnualDateToolStripButton.Click
        EditAnnualDate()
    End Sub

    ''' <summary>
    ''' Команда в меню формы для удаления напоминания.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DeleteAnnualDateToolStripButton_Click(sender As Object, e As EventArgs) Handles DeleteAnnualDateToolStripButton.Click
        DeleteAnnualDate()
    End Sub

    ''' <summary>
    ''' Вызывает форму создания нового напоминание.
    ''' </summary>
    Private Sub CreateAnnualDate()
        Dim CreateAnnualDateForm As New AnnualDateEditForm(CreateNewReminder:=True)
        CreateAnnualDateForm.StartPosition = FormStartPosition.Manual
        CreateAnnualDateForm.Location = FormHelper.GetLocationPoint(Me, Me.Location, New Point(20, 20))
        CreateAnnualDateForm.ShowDialog()
        If CreateAnnualDateForm.DialogResult = DialogResult.OK Then
            AnnualDatesBindingSource.Add(CreateAnnualDateForm.AnnualDate)
        End If
        CreateAnnualDateForm.Dispose()
    End Sub

    ''' <summary>
    ''' Вызывает форму редактирования напоминания.
    ''' </summary>
    Private Sub EditAnnualDate()
        If AnnualDatesBindingSource.Current Is Nothing Then Return

        Dim EditForm As New AnnualDateEditForm(CreateNewReminder:=False)
        EditForm.StartPosition = FormStartPosition.Manual
        EditForm.Location = FormHelper.GetLocationPoint(Me, Me.Location, New Point(20, 20))

        Dim currentReminderIndex As Integer = AnnualDatesBindingSource.Position
        EditForm.AnnualDate = AnnualDatesBindingSource.Current.Clone()
        EditForm.ShowDialog()
        If EditForm.DialogResult = DialogResult.OK Then
            AnnualDatesBindingSource(currentReminderIndex) = EditForm.AnnualDate
        End If
        EditForm.Dispose()
    End Sub

    ''' <summary>
    ''' Удаляет текущиее напоминание.
    ''' </summary>
    Private Sub DeleteAnnualDate()
        If AnnualDatesBindingSource.Current Is Nothing Then Return

        AnnualDatesBindingSource.RemoveCurrent()
    End Sub

#Region "DataGridView commands"

    Private Sub AnnualRemindersDataGridView_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles AnnualDatesDataGridView.CellContentDoubleClick
        EditAnnualDate()
    End Sub


#End Region
#End Region

End Class