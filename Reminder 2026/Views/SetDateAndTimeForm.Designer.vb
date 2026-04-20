<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetDateAndTimeForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetDateAndTimeForm))
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.ReminderDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.ReminderMonthCalendar = New System.Windows.Forms.MonthCalendar()
        Me.DateTimeGroupBox = New System.Windows.Forms.GroupBox()
        Me.ReminderTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(219, 244)
        Me.CancelBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(76, 28)
        Me.CancelBtn.TabIndex = 7
        Me.CancelBtn.Text = "Отмена"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(131, 244)
        Me.OkButton.Margin = New System.Windows.Forms.Padding(4)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(76, 28)
        Me.OkButton.TabIndex = 6
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'ReminderDatePicker
        '
        Me.ReminderDatePicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReminderDatePicker.Location = New System.Drawing.Point(128, 24)
        Me.ReminderDatePicker.Margin = New System.Windows.Forms.Padding(4)
        Me.ReminderDatePicker.Name = "ReminderDatePicker"
        Me.ReminderDatePicker.ShowUpDown = True
        Me.ReminderDatePicker.Size = New System.Drawing.Size(164, 22)
        Me.ReminderDatePicker.TabIndex = 8
        '
        'ReminderMonthCalendar
        '
        Me.ReminderMonthCalendar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReminderMonthCalendar.Location = New System.Drawing.Point(128, 52)
        Me.ReminderMonthCalendar.Margin = New System.Windows.Forms.Padding(12, 11, 12, 11)
        Me.ReminderMonthCalendar.MaxSelectionCount = 1
        Me.ReminderMonthCalendar.Name = "ReminderMonthCalendar"
        Me.ReminderMonthCalendar.ShowToday = False
        Me.ReminderMonthCalendar.TabIndex = 9
        '
        'DateTimeGroupBox
        '
        Me.DateTimeGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimeGroupBox.Controls.Add(Me.ReminderTimePicker)
        Me.DateTimeGroupBox.Controls.Add(Me.ReminderMonthCalendar)
        Me.DateTimeGroupBox.Controls.Add(Me.ReminderDatePicker)
        Me.DateTimeGroupBox.Location = New System.Drawing.Point(4, 4)
        Me.DateTimeGroupBox.Name = "DateTimeGroupBox"
        Me.DateTimeGroupBox.Size = New System.Drawing.Size(300, 228)
        Me.DateTimeGroupBox.TabIndex = 10
        Me.DateTimeGroupBox.TabStop = False
        Me.DateTimeGroupBox.Text = "Укажите дату и время"
        '
        'ReminderTimePicker
        '
        Me.ReminderTimePicker.CustomFormat = "HH:mm"
        Me.ReminderTimePicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReminderTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ReminderTimePicker.Location = New System.Drawing.Point(16, 64)
        Me.ReminderTimePicker.Name = "ReminderTimePicker"
        Me.ReminderTimePicker.ShowUpDown = True
        Me.ReminderTimePicker.Size = New System.Drawing.Size(96, 38)
        Me.ReminderTimePicker.TabIndex = 10
        '
        'SetDateAndTimeForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelBtn
        Me.ClientSize = New System.Drawing.Size(308, 287)
        Me.Controls.Add(Me.DateTimeGroupBox)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OkButton)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(324, 325)
        Me.Name = "SetDateAndTimeForm"
        Me.Text = "SetDateAndTimeForm"
        Me.DateTimeGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CancelBtn As Button
    Friend WithEvents OkButton As Button
    Friend WithEvents ReminderDatePicker As DateTimePicker
    Friend WithEvents ReminderMonthCalendar As MonthCalendar
    Friend WithEvents DateTimeGroupBox As GroupBox
    Friend WithEvents ReminderTimePicker As DateTimePicker
End Class
