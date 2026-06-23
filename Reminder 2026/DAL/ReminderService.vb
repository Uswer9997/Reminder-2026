Imports System.IO

''' <summary>
''' Содержит все инструментарии для чтения/записи напоминаний всех типов.
''' </summary>
Public Class ReminderService
    ''' <summary>
    ''' Путь к файлу для чтения/записи напоминаний.
    ''' </summary>
    Private RemindersSourceFile As String = Path.Combine(Application.StartupPath, "Reminders.xml")

    ''' <summary>
    ''' Путь к файлу для чтения/записи ежегодных дат.
    ''' </summary>
    Private AnnualDatesSourceFile As String = Path.Combine(Application.StartupPath, "AnnualDates.xml")

    ''' <summary>
    ''' Обработчик действий с перехватом исключений.
    ''' </summary>
    Private _SafePerformer As SafeActionPerformer


    ''' <summary>
    ''' Коллекция периодических напоминаний.
    ''' </summary>
    Public Property PeriodicReminders As List(Of PeriodicReminder)

    ''' <summary>
    ''' Коллекция ежегодных дат.
    ''' </summary>
    Public Property AnnualDates As List(Of AnnualReminder)

    ''' <summary>
    ''' Возвращает коллекцию всех напоминаний.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property AllReminders As IEnumerable(Of Reminder)
        Get
            Return PeriodicReminders.OfType(Of Reminder).Concat(AnnualDates.OfType(Of Reminder))
        End Get
    End Property

    Public Sub New(ByVal _NotificationSrv As NotificationService)
        _SafePerformer = New SafeActionPerformer(_NotificationSrv) ' инжектируем оповещателя об ошибках в обработчик действий
        PeriodicReminders = New List(Of PeriodicReminder)
        AnnualDates = New List(Of AnnualReminder)
    End Sub

#Region "Load block"
    ''' <summary>
    ''' Загружает напоминания в коллекции из файлов.
    ''' </summary>
    Public Sub LoadReminders()
        _SafePerformer.Excecute(AddressOf LoadPeriodicReminders)
        _SafePerformer.Excecute(AddressOf LoadAnnualDates)
    End Sub

    ''' <summary>
    ''' Загружает напоминания в коллекцию из файла.
    ''' </summary>
    Private Sub LoadPeriodicReminders()
        Try
            ' загрузим напоминания если файл существует
            If IO.File.Exists(RemindersSourceFile) Then
                Dim serializer As New Xml.Serialization.XmlSerializer(GetType(List(Of PeriodicReminder)))

                Using fs As New System.IO.FileStream(RemindersSourceFile, FileMode.Open)
                    PeriodicReminders = serializer.Deserialize(fs)
                End Using
            End If
        Catch ex As Exception
            Throw New Exception(message:="Ошибка чтения напоминаний из файла.", innerException:=ex)
        End Try
    End Sub

    ''' <summary>
    ''' Загружает ежегодные даты в коллекцию из файла.
    ''' </summary>
    Private Sub LoadAnnualDates()
        Try
            ' загрузим напоминания если файл существует
            If IO.File.Exists(AnnualDatesSourceFile) Then
                Dim serializer As New Xml.Serialization.XmlSerializer(GetType(List(Of AnnualReminder)))

                Using fs As New System.IO.FileStream(AnnualDatesSourceFile, FileMode.Open)
                    AnnualDates = serializer.Deserialize(fs)
                End Using
            End If
        Catch ex As Exception
            Throw New Exception(message:="Ошибка чтения ежегодных дат из файла.", innerException:=ex)
        End Try
    End Sub
#End Region

#Region "Save block"

    ''' <summary>
    ''' Записывает напоминания в файл.
    ''' </summary>
    Public Sub SavePeriodicReminders()
        _SafePerformer.Excecute(AddressOf locSavePeriodicReminders)
    End Sub

    ''' <summary>
    ''' Записывает напоминания в файл.
    ''' </summary>
    Private Sub locSavePeriodicReminders()
        Try
            Dim serializer As New Xml.Serialization.XmlSerializer(GetType(List(Of PeriodicReminder)))
            Using fs As New System.IO.FileStream(RemindersSourceFile, FileMode.Create)
                serializer.Serialize(fs, PeriodicReminders)
            End Using
        Catch ex As Exception
            Throw New Exception(message:="Ошибка записи напоминаний в файл.", innerException:=ex)
        End Try
    End Sub

    ''' <summary>
    ''' Записывает ежегодные даты в файл.
    ''' </summary>
    Public Sub SaveAnnualDates()
        _SafePerformer.Excecute(AddressOf locSaveAnnualDates)
    End Sub

    ''' <summary>
    ''' Записывает ежегодные даты в файл.
    ''' </summary>
    Private Sub locSaveAnnualDates()
        Try
            Dim serializer As New Xml.Serialization.XmlSerializer(GetType(List(Of AnnualReminder)))
            Using fs As New System.IO.FileStream(AnnualDatesSourceFile, FileMode.Create)
                serializer.Serialize(fs, AnnualDates)
            End Using
        Catch ex As Exception
            Throw New Exception(message:="Ошибка записи ежегодных дат в файл.", innerException:=ex)
        End Try
    End Sub
#End Region

End Class
