Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
''' <summary>
''' Описывает ежегодное 'Напоминание'
''' </summary>
Public Class AnnualReminder
    Inherits Reminder
    Implements ICloneable

    Private _DaysAgo As Integer

    '''' <summary>
    '''' Дата 'Напоминания'.
    '''' </summary>
    '''' <returns></returns>
    'Public Property TargetDate As DateTime
    '    Get
    '        Return MyBase.DateTo
    '    End Get
    '    Set
    '        SetValue(Of DateTime)(MyBase.DateTo, Value)
    '    End Set
    'End Property

    ''' <summary>
    ''' За сколько дней начинается 'Напоминание'.
    ''' </summary>
    ''' <returns></returns>
    Public Property DaysAgo As Integer
        Get
            Return _DaysAgo
        End Get
        Set
            SetValue(Of Integer)(_DaysAgo, Value)
        End Set
    End Property

    Public Sub New()
        Dim today As DateTime = DateTime.Now
        Me.DateFrom = New DateTime(today.Year, today.Month, today.Day, 0, 0, 0)
        Me.DateTo = New DateTime(today.Year, today.Month, today.Day, 0, 0, 0) 'Me.TargetDate = New DateTime(today.Year, today.Month, today.Day, 0, 0, 0)
        Me.IsActive = True
        Me.ExecForever = True
        Me.ExecIfLate = False
    End Sub

    Public Overrides Function Clone() As Object Implements ICloneable.Clone
        Dim MeClone As AnnualReminder = Me.MemberwiseClone()
        Return MeClone
    End Function

    ''' <summary>
    ''' Устанавливает дату следующего выполнения, от текущего момента времени.
    ''' </summary>
    ''' <param name="thisMoment">Текущий момент времени.</param>
    Public Overrides Sub SetNextTime(ByVal thisMoment As DateTime)
        If thisMoment >= DateTo Then
            SetTargetDate(thisMoment) ' установим дату следующего напоминания
        End If

        Dim newNextDate As DateTime ' дата следующего выполнения с учетом дней предварительных выполнений
        ' установим текущее значение даты следующего выполнения
        newNextDate = Me.DateTo.AddDays(-DaysAgo) ' отсчёт от даты следующего напоминания
        ' докрутим дату следующего выполнения пока она не превысит текущий момент
        While newNextDate < thisMoment
            newNextDate = newNextDate.AddDays(1)
        End While

        Me.NextDate = newNextDate
    End Sub

    ''' <summary>
    ''' Устанавливает дату следующего 'Напоминания', от текущего момента времени.
    ''' </summary>
    ''' <param name="thisMoment">Текущий момент времени.</param>
    Private Sub SetTargetDate(ByVal thisMoment As DateTime)
        Dim newTargetDate As DateTime ' дата следующего выполнения
        ' установим текущее значение даты следующего выполнения
        newTargetDate = Me.DateFrom ' отсчёт от начала выполнения
        ' докрутим дату следующего выполнения пока она не превысит текущий момент
        While newTargetDate < thisMoment
            newTargetDate = newTargetDate.AddYears(1)
        End While

        Me.DateTo = newTargetDate
    End Sub
End Class
