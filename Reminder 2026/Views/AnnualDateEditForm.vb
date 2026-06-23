Imports System.ComponentModel

Public Class AnnualDateEditForm
    Implements INotifyPropertyChanged

    Private DaysList As List(Of Integer) ' список дней
    Private MonthList As List(Of String) ' список месяцев
    Private DaysAgoList As List(Of Integer) ' список дней до
    Private _TargetDay As Integer = 1 ' выбранный день
    Private _TargetMonth As Integer

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' Формируемая ежегодная дата.
    ''' </summary>
    ''' <remarks>Может быть установлена извне для редактирования.</remarks>>
    Public Property AnnualDate As AnnualReminder

    ''' <summary>
    ''' Выбранный номер дня.
    ''' </summary>
    ''' <returns></returns>
    Public Property TargetDay As Integer
        Get
            Return _TargetDay
        End Get
        Set
            If _TargetDay <> Value Then
                _TargetDay = Value
                OnPropertyChanged("TargetDay")
            End If
        End Set
    End Property

    ''' <summary>
    ''' Выбранный номер месяца.
    ''' </summary>
    ''' <returns></returns>
    Public Property TargetMonth As Integer ' выбранный месяц
        Get
            Return _TargetMonth
        End Get
        Set
            If _TargetMonth <> Value Then
                _TargetMonth = Value
                OnPropertyChanged("TargetMonth")
            End If
        End Set
    End Property

    Public Sub New(ByVal CreateNewReminder As Boolean)

        If (CreateNewReminder = True) Or (Me.AnnualDate Is Nothing) Then
            Me.AnnualDate = New AnnualReminder()
        End If

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().

    End Sub


    Private Sub AnnualDateEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DaysList = New List(Of Integer)(Enumerable.Range(1, 31))
        DateDayComboBox.DataSource = DaysList

        MonthList = New List(Of String)({"Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря"})
        DateMonthComboBox.DataSource = MonthList

        DaysAgoList = New List(Of Integer)(Enumerable.Range(0, 10))
        DaysAgoComboBox.DataSource = DaysAgoList


        ' установим привязки свойств к элементам управления
        AnnualDateTextTextBox.DataBindings.Add("Text", Me.AnnualDate, "Text")
        DateDayComboBox.DataBindings.Add("SelectedItem", Me, "TargetDay")
        DateMonthComboBox.DataBindings.Add("SelectedIndex", Me, "TargetMonth")
        DaysAgoComboBox.DataBindings.Add("SelectedItem", Me.AnnualDate, "DaysAgo")

        ' установим начальные данные для дня и месяца
        TargetDay = AnnualDate.DateFrom.Day ' установим день из даты
        TargetMonth = AnnualDate.DateFrom.Month - 1 ' установим месяц из даты

    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.AnnualDate.DateFrom = New DateTime(Today.Year, TargetMonth + 1, TargetDay, 0, 0, 0)
        Me.AnnualDate.SetNextTime(DateAndTime.Now)
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Protected Overridable Sub OnPropertyChanged(ByVal Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub

End Class