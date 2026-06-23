Imports System.ComponentModel

Public Class DisplayRemindersForm
    ''' <summary>
    ''' Путь к звуковому файлу озвучивания напоминаний.
    ''' </summary>
    Private SoundFile As String = IO.Path.Combine(Application.StartupPath, "Reminder.wav")

    Public Property Reminders As New System.ComponentModel.BindingList(Of Reminder)

    ''' <summary>
    ''' Плеер для воспроизведения звуков.
    ''' </summary>
    Private Player As New Media.SoundPlayer

    Private Sub DisplayRemindersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Reminders.ListChanged, AddressOf RemindersChanged
        Try
            If IO.File.Exists(SoundFile) Then
                Player.SoundLocation = SoundFile
                Player.LoadAsync()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка загрузки звукового файла", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub RemindersChanged(sender As Object, e As ListChangedEventArgs)
        If e.ListChangedType = ListChangedType.ItemAdded Then
            Dim addedReminder As Reminder = Reminders(e.NewIndex)
            RemindersTextBox.AppendText(addedReminder.NextDate.ToString + " " + addedReminder.Text + vbNewLine)
            If My.Settings.PlaySound = True Then
                Player.Play()
            End If
        End If
    End Sub

End Class