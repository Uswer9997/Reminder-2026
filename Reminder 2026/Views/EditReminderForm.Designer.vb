<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditReminderForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditReminderForm))
        Me.FromToGroupBox = New System.Windows.Forms.GroupBox()
        Me.DateToCheckBox = New System.Windows.Forms.CheckBox()
        Me.DateToButton = New System.Windows.Forms.Button()
        Me.DateFromButton = New System.Windows.Forms.Button()
        Me.DateToLabel = New System.Windows.Forms.Label()
        Me.LabelTo = New System.Windows.Forms.Label()
        Me.DateFromLabel = New System.Windows.Forms.Label()
        Me.LabelFrom = New System.Windows.Forms.Label()
        Me.PeriodicityGroupBox = New System.Windows.Forms.GroupBox()
        Me.DaysNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.DaysLabel = New System.Windows.Forms.Label()
        Me.HoursLabel = New System.Windows.Forms.Label()
        Me.MinutsLabel = New System.Windows.Forms.Label()
        Me.OnceRadioButton = New System.Windows.Forms.RadioButton()
        Me.YearRadioButton = New System.Windows.Forms.RadioButton()
        Me.MonthRadioButton = New System.Windows.Forms.RadioButton()
        Me.HoursComboBox = New System.Windows.Forms.ComboBox()
        Me.MinutsComboBox = New System.Windows.Forms.ComboBox()
        Me.DaysRadioButton = New System.Windows.Forms.RadioButton()
        Me.HoursRadioButton = New System.Windows.Forms.RadioButton()
        Me.MinutsRadioButton = New System.Windows.Forms.RadioButton()
        Me.ReminderGroupBox = New System.Windows.Forms.GroupBox()
        Me.ReminderTextBox = New System.Windows.Forms.TextBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.LateCheckBox = New System.Windows.Forms.CheckBox()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.FromToGroupBox.SuspendLayout()
        Me.PeriodicityGroupBox.SuspendLayout()
        CType(Me.DaysNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ReminderGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'FromToGroupBox
        '
        Me.FromToGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FromToGroupBox.Controls.Add(Me.DateToCheckBox)
        Me.FromToGroupBox.Controls.Add(Me.DateToButton)
        Me.FromToGroupBox.Controls.Add(Me.DateFromButton)
        Me.FromToGroupBox.Controls.Add(Me.DateToLabel)
        Me.FromToGroupBox.Controls.Add(Me.LabelTo)
        Me.FromToGroupBox.Controls.Add(Me.DateFromLabel)
        Me.FromToGroupBox.Controls.Add(Me.LabelFrom)
        Me.FromToGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FromToGroupBox.Location = New System.Drawing.Point(8, 4)
        Me.FromToGroupBox.Name = "FromToGroupBox"
        Me.FromToGroupBox.Size = New System.Drawing.Size(335, 104)
        Me.FromToGroupBox.TabIndex = 0
        Me.FromToGroupBox.TabStop = False
        Me.FromToGroupBox.Text = "Выполнять задание..."
        '
        'DateToCheckBox
        '
        Me.DateToCheckBox.AutoSize = True
        Me.DateToCheckBox.Checked = True
        Me.DateToCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DateToCheckBox.Location = New System.Drawing.Point(40, 68)
        Me.DateToCheckBox.Name = "DateToCheckBox"
        Me.DateToCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.DateToCheckBox.TabIndex = 6
        Me.DateToCheckBox.UseVisualStyleBackColor = True
        '
        'DateToButton
        '
        Me.DateToButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateToButton.Location = New System.Drawing.Point(220, 60)
        Me.DateToButton.Name = "DateToButton"
        Me.DateToButton.Size = New System.Drawing.Size(104, 28)
        Me.DateToButton.TabIndex = 5
        Me.DateToButton.Text = "Установить"
        Me.DateToButton.UseVisualStyleBackColor = True
        '
        'DateFromButton
        '
        Me.DateFromButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateFromButton.Location = New System.Drawing.Point(220, 24)
        Me.DateFromButton.Name = "DateFromButton"
        Me.DateFromButton.Size = New System.Drawing.Size(104, 28)
        Me.DateFromButton.TabIndex = 4
        Me.DateFromButton.Text = "Установить"
        Me.DateFromButton.UseVisualStyleBackColor = True
        '
        'DateToLabel
        '
        Me.DateToLabel.AutoSize = True
        Me.DateToLabel.Location = New System.Drawing.Point(92, 68)
        Me.DateToLabel.Name = "DateToLabel"
        Me.DateToLabel.Size = New System.Drawing.Size(49, 16)
        Me.DateToLabel.TabIndex = 3
        Me.DateToLabel.Text = "Label4"
        '
        'LabelTo
        '
        Me.LabelTo.AutoSize = True
        Me.LabelTo.Location = New System.Drawing.Point(64, 68)
        Me.LabelTo.Name = "LabelTo"
        Me.LabelTo.Size = New System.Drawing.Size(28, 16)
        Me.LabelTo.TabIndex = 2
        Me.LabelTo.Text = "До:"
        '
        'DateFromLabel
        '
        Me.DateFromLabel.AutoSize = True
        Me.DateFromLabel.Location = New System.Drawing.Point(92, 28)
        Me.DateFromLabel.Name = "DateFromLabel"
        Me.DateFromLabel.Size = New System.Drawing.Size(49, 16)
        Me.DateFromLabel.TabIndex = 1
        Me.DateFromLabel.Text = "Label2"
        '
        'LabelFrom
        '
        Me.LabelFrom.AutoSize = True
        Me.LabelFrom.Location = New System.Drawing.Point(16, 28)
        Me.LabelFrom.Name = "LabelFrom"
        Me.LabelFrom.Size = New System.Drawing.Size(78, 16)
        Me.LabelFrom.TabIndex = 0
        Me.LabelFrom.Text = "Начиная с:"
        '
        'PeriodicityGroupBox
        '
        Me.PeriodicityGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PeriodicityGroupBox.Controls.Add(Me.DaysNumericUpDown)
        Me.PeriodicityGroupBox.Controls.Add(Me.DaysLabel)
        Me.PeriodicityGroupBox.Controls.Add(Me.HoursLabel)
        Me.PeriodicityGroupBox.Controls.Add(Me.MinutsLabel)
        Me.PeriodicityGroupBox.Controls.Add(Me.OnceRadioButton)
        Me.PeriodicityGroupBox.Controls.Add(Me.YearRadioButton)
        Me.PeriodicityGroupBox.Controls.Add(Me.MonthRadioButton)
        Me.PeriodicityGroupBox.Controls.Add(Me.HoursComboBox)
        Me.PeriodicityGroupBox.Controls.Add(Me.MinutsComboBox)
        Me.PeriodicityGroupBox.Controls.Add(Me.DaysRadioButton)
        Me.PeriodicityGroupBox.Controls.Add(Me.HoursRadioButton)
        Me.PeriodicityGroupBox.Controls.Add(Me.MinutsRadioButton)
        Me.PeriodicityGroupBox.Location = New System.Drawing.Point(8, 116)
        Me.PeriodicityGroupBox.Name = "PeriodicityGroupBox"
        Me.PeriodicityGroupBox.Size = New System.Drawing.Size(335, 128)
        Me.PeriodicityGroupBox.TabIndex = 1
        Me.PeriodicityGroupBox.TabStop = False
        Me.PeriodicityGroupBox.Text = "Периодичность выполнения задания"
        '
        'DaysNumericUpDown
        '
        Me.DaysNumericUpDown.Location = New System.Drawing.Point(88, 92)
        Me.DaysNumericUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.DaysNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.DaysNumericUpDown.Name = "DaysNumericUpDown"
        Me.DaysNumericUpDown.Size = New System.Drawing.Size(48, 22)
        Me.DaysNumericUpDown.TabIndex = 12
        Me.DaysNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'DaysLabel
        '
        Me.DaysLabel.AutoSize = True
        Me.DaysLabel.Location = New System.Drawing.Point(140, 94)
        Me.DaysLabel.Name = "DaysLabel"
        Me.DaysLabel.Size = New System.Drawing.Size(39, 16)
        Me.DaysLabel.TabIndex = 11
        Me.DaysLabel.Text = "день"
        '
        'HoursLabel
        '
        Me.HoursLabel.AutoSize = True
        Me.HoursLabel.Location = New System.Drawing.Point(140, 62)
        Me.HoursLabel.Name = "HoursLabel"
        Me.HoursLabel.Size = New System.Drawing.Size(31, 16)
        Me.HoursLabel.TabIndex = 10
        Me.HoursLabel.Text = "час"
        '
        'MinutsLabel
        '
        Me.MinutsLabel.AutoSize = True
        Me.MinutsLabel.Location = New System.Drawing.Point(140, 30)
        Me.MinutsLabel.Name = "MinutsLabel"
        Me.MinutsLabel.Size = New System.Drawing.Size(48, 16)
        Me.MinutsLabel.TabIndex = 9
        Me.MinutsLabel.Text = "минут"
        '
        'OnceRadioButton
        '
        Me.OnceRadioButton.AutoSize = True
        Me.OnceRadioButton.Checked = True
        Me.OnceRadioButton.Location = New System.Drawing.Point(204, 92)
        Me.OnceRadioButton.Name = "OnceRadioButton"
        Me.OnceRadioButton.Size = New System.Drawing.Size(87, 20)
        Me.OnceRadioButton.TabIndex = 8
        Me.OnceRadioButton.TabStop = True
        Me.OnceRadioButton.Text = "Один раз"
        Me.OnceRadioButton.UseVisualStyleBackColor = True
        '
        'YearRadioButton
        '
        Me.YearRadioButton.AutoSize = True
        Me.YearRadioButton.Location = New System.Drawing.Point(204, 60)
        Me.YearRadioButton.Name = "YearRadioButton"
        Me.YearRadioButton.Size = New System.Drawing.Size(92, 20)
        Me.YearRadioButton.TabIndex = 7
        Me.YearRadioButton.Text = "Ежегодно"
        Me.YearRadioButton.UseVisualStyleBackColor = True
        '
        'MonthRadioButton
        '
        Me.MonthRadioButton.AutoSize = True
        Me.MonthRadioButton.Location = New System.Drawing.Point(204, 28)
        Me.MonthRadioButton.Name = "MonthRadioButton"
        Me.MonthRadioButton.Size = New System.Drawing.Size(109, 20)
        Me.MonthRadioButton.TabIndex = 6
        Me.MonthRadioButton.Text = "Ежемесячно"
        Me.MonthRadioButton.UseVisualStyleBackColor = True
        '
        'HoursComboBox
        '
        Me.HoursComboBox.DropDownHeight = 100
        Me.HoursComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.HoursComboBox.FormattingEnabled = True
        Me.HoursComboBox.IntegralHeight = False
        Me.HoursComboBox.Location = New System.Drawing.Point(88, 59)
        Me.HoursComboBox.Name = "HoursComboBox"
        Me.HoursComboBox.Size = New System.Drawing.Size(48, 24)
        Me.HoursComboBox.TabIndex = 4
        '
        'MinutsComboBox
        '
        Me.MinutsComboBox.DropDownHeight = 100
        Me.MinutsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MinutsComboBox.FormattingEnabled = True
        Me.MinutsComboBox.IntegralHeight = False
        Me.MinutsComboBox.Location = New System.Drawing.Point(88, 27)
        Me.MinutsComboBox.Name = "MinutsComboBox"
        Me.MinutsComboBox.Size = New System.Drawing.Size(48, 24)
        Me.MinutsComboBox.TabIndex = 3
        '
        'DaysRadioButton
        '
        Me.DaysRadioButton.AutoSize = True
        Me.DaysRadioButton.Location = New System.Drawing.Point(12, 92)
        Me.DaysRadioButton.Name = "DaysRadioButton"
        Me.DaysRadioButton.Size = New System.Drawing.Size(76, 20)
        Me.DaysRadioButton.TabIndex = 2
        Me.DaysRadioButton.Text = "Каждый"
        Me.DaysRadioButton.UseVisualStyleBackColor = True
        '
        'HoursRadioButton
        '
        Me.HoursRadioButton.AutoSize = True
        Me.HoursRadioButton.Location = New System.Drawing.Point(12, 60)
        Me.HoursRadioButton.Name = "HoursRadioButton"
        Me.HoursRadioButton.Size = New System.Drawing.Size(76, 20)
        Me.HoursRadioButton.TabIndex = 1
        Me.HoursRadioButton.Text = "Каждый"
        Me.HoursRadioButton.UseVisualStyleBackColor = True
        '
        'MinutsRadioButton
        '
        Me.MinutsRadioButton.AutoSize = True
        Me.MinutsRadioButton.Location = New System.Drawing.Point(12, 28)
        Me.MinutsRadioButton.Name = "MinutsRadioButton"
        Me.MinutsRadioButton.Size = New System.Drawing.Size(76, 20)
        Me.MinutsRadioButton.TabIndex = 0
        Me.MinutsRadioButton.Text = "Каждые"
        Me.MinutsRadioButton.UseVisualStyleBackColor = True
        '
        'ReminderGroupBox
        '
        Me.ReminderGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReminderGroupBox.Controls.Add(Me.ReminderTextBox)
        Me.ReminderGroupBox.Location = New System.Drawing.Point(8, 252)
        Me.ReminderGroupBox.Name = "ReminderGroupBox"
        Me.ReminderGroupBox.Size = New System.Drawing.Size(333, 128)
        Me.ReminderGroupBox.TabIndex = 2
        Me.ReminderGroupBox.TabStop = False
        Me.ReminderGroupBox.Text = "Задание"
        '
        'ReminderTextBox
        '
        Me.ReminderTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReminderTextBox.Location = New System.Drawing.Point(8, 20)
        Me.ReminderTextBox.Multiline = True
        Me.ReminderTextBox.Name = "ReminderTextBox"
        Me.ReminderTextBox.Size = New System.Drawing.Size(317, 98)
        Me.ReminderTextBox.TabIndex = 0
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(181, 416)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 28)
        Me.OkButton.TabIndex = 3
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'LateCheckBox
        '
        Me.LateCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LateCheckBox.AutoSize = True
        Me.LateCheckBox.Checked = True
        Me.LateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LateCheckBox.Location = New System.Drawing.Point(16, 388)
        Me.LateCheckBox.Name = "LateCheckBox"
        Me.LateCheckBox.Size = New System.Drawing.Size(224, 20)
        Me.LateCheckBox.TabIndex = 4
        Me.LateCheckBox.Text = "Выполнять, когда опаздывает"
        Me.LateCheckBox.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(265, 416)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 28)
        Me.CancelBtn.TabIndex = 5
        Me.CancelBtn.Text = "Отмена"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'EditReminderForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelBtn
        Me.ClientSize = New System.Drawing.Size(352, 457)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.LateCheckBox)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.ReminderGroupBox)
        Me.Controls.Add(Me.PeriodicityGroupBox)
        Me.Controls.Add(Me.FromToGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(368, 428)
        Me.Name = "EditReminderForm"
        Me.Text = "Form"
        Me.FromToGroupBox.ResumeLayout(False)
        Me.FromToGroupBox.PerformLayout()
        Me.PeriodicityGroupBox.ResumeLayout(False)
        Me.PeriodicityGroupBox.PerformLayout()
        CType(Me.DaysNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ReminderGroupBox.ResumeLayout(False)
        Me.ReminderGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FromToGroupBox As GroupBox
    Friend WithEvents DateToLabel As Label
    Friend WithEvents LabelTo As Label
    Friend WithEvents DateFromLabel As Label
    Friend WithEvents LabelFrom As Label
    Friend WithEvents PeriodicityGroupBox As GroupBox
    Friend WithEvents ReminderGroupBox As GroupBox
    Friend WithEvents DateToCheckBox As CheckBox
    Friend WithEvents DateToButton As Button
    Friend WithEvents DateFromButton As Button
    Friend WithEvents MinutsRadioButton As RadioButton
    Friend WithEvents HoursComboBox As ComboBox
    Friend WithEvents MinutsComboBox As ComboBox
    Friend WithEvents DaysRadioButton As RadioButton
    Friend WithEvents HoursRadioButton As RadioButton
    Friend WithEvents DaysLabel As Label
    Friend WithEvents HoursLabel As Label
    Friend WithEvents MinutsLabel As Label
    Friend WithEvents OnceRadioButton As RadioButton
    Friend WithEvents YearRadioButton As RadioButton
    Friend WithEvents MonthRadioButton As RadioButton
    Friend WithEvents ReminderTextBox As TextBox
    Friend WithEvents DaysNumericUpDown As NumericUpDown
    Friend WithEvents OkButton As Button
    Friend WithEvents LateCheckBox As CheckBox
    Friend WithEvents CancelBtn As Button
End Class
