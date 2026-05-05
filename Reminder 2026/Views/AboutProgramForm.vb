Public Class AboutProgramForm
    Private Sub AboutProgramForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DescriptionTextBox.Text = $"Простой напоминатель для ваших задач. Позволяет не забыть сделать что-то вовремя, не пропустить важную встречу. {vbCrLf} 
Программа бесплатна как для частного, так и для коммерческого использования."

        VersionLabel.Text = Application.ProductVersion
    End Sub
End Class