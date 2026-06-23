<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnnualDateEditForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnnualDateEditForm))
        Me.DateDayComboBox = New System.Windows.Forms.ComboBox()
        Me.DescLabel = New System.Windows.Forms.Label()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.AnnualDateDescriptionGroupBox = New System.Windows.Forms.GroupBox()
        Me.AnnualDateTextTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateMonthComboBox = New System.Windows.Forms.ComboBox()
        Me.AnnualDateParamsGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DaysAgoComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AnnualDateDescriptionGroupBox.SuspendLayout()
        Me.AnnualDateParamsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateDayComboBox
        '
        Me.DateDayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DateDayComboBox.FormattingEnabled = True
        Me.DateDayComboBox.Location = New System.Drawing.Point(115, 15)
        Me.DateDayComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.DateDayComboBox.Name = "DateDayComboBox"
        Me.DateDayComboBox.Size = New System.Drawing.Size(48, 24)
        Me.DateDayComboBox.TabIndex = 0
        '
        'DescLabel
        '
        Me.DescLabel.AutoSize = True
        Me.DescLabel.Location = New System.Drawing.Point(7, 18)
        Me.DescLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DescLabel.Name = "DescLabel"
        Me.DescLabel.Size = New System.Drawing.Size(100, 16)
        Me.DescLabel.TabIndex = 1
        Me.DescLabel.Text = "Опишите дату"
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(457, 142)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 28)
        Me.CancelBtn.TabIndex = 7
        Me.CancelBtn.Text = "Отмена"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(373, 142)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 28)
        Me.OkButton.TabIndex = 6
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'AnnualDateDescriptionGroupBox
        '
        Me.AnnualDateDescriptionGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AnnualDateDescriptionGroupBox.Controls.Add(Me.AnnualDateTextTextBox)
        Me.AnnualDateDescriptionGroupBox.Controls.Add(Me.Label1)
        Me.AnnualDateDescriptionGroupBox.Controls.Add(Me.DateMonthComboBox)
        Me.AnnualDateDescriptionGroupBox.Controls.Add(Me.DescLabel)
        Me.AnnualDateDescriptionGroupBox.Controls.Add(Me.DateDayComboBox)
        Me.AnnualDateDescriptionGroupBox.Location = New System.Drawing.Point(8, 6)
        Me.AnnualDateDescriptionGroupBox.Name = "AnnualDateDescriptionGroupBox"
        Me.AnnualDateDescriptionGroupBox.Size = New System.Drawing.Size(530, 75)
        Me.AnnualDateDescriptionGroupBox.TabIndex = 8
        Me.AnnualDateDescriptionGroupBox.TabStop = False
        Me.AnnualDateDescriptionGroupBox.Text = "Описание даты"
        '
        'AnnualDateTextTextBox
        '
        Me.AnnualDateTextTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AnnualDateTextTextBox.Location = New System.Drawing.Point(6, 46)
        Me.AnnualDateTextTextBox.Name = "AnnualDateTextTextBox"
        Me.AnnualDateTextTextBox.Size = New System.Drawing.Size(518, 22)
        Me.AnnualDateTextTextBox.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(303, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = ":"
        '
        'DateMonthComboBox
        '
        Me.DateMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DateMonthComboBox.FormattingEnabled = True
        Me.DateMonthComboBox.Location = New System.Drawing.Point(171, 15)
        Me.DateMonthComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.DateMonthComboBox.Name = "DateMonthComboBox"
        Me.DateMonthComboBox.Size = New System.Drawing.Size(124, 24)
        Me.DateMonthComboBox.TabIndex = 2
        '
        'AnnualDateParamsGroupBox
        '
        Me.AnnualDateParamsGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AnnualDateParamsGroupBox.Controls.Add(Me.Label4)
        Me.AnnualDateParamsGroupBox.Controls.Add(Me.DaysAgoComboBox)
        Me.AnnualDateParamsGroupBox.Controls.Add(Me.Label3)
        Me.AnnualDateParamsGroupBox.Controls.Add(Me.Label2)
        Me.AnnualDateParamsGroupBox.Location = New System.Drawing.Point(8, 87)
        Me.AnnualDateParamsGroupBox.Name = "AnnualDateParamsGroupBox"
        Me.AnnualDateParamsGroupBox.Size = New System.Drawing.Size(359, 89)
        Me.AnnualDateParamsGroupBox.TabIndex = 9
        Me.AnnualDateParamsGroupBox.TabStop = False
        Me.AnnualDateParamsGroupBox.Text = "Дополнительные параметры"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(127, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "дней (в таблице это колонка 'За')"
        '
        'DaysAgoComboBox
        '
        Me.DaysAgoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DaysAgoComboBox.FormattingEnabled = True
        Me.DaysAgoComboBox.Location = New System.Drawing.Point(89, 57)
        Me.DaysAgoComboBox.Name = "DaysAgoComboBox"
        Me.DaysAgoComboBox.Size = New System.Drawing.Size(32, 24)
        Me.DaysAgoComboBox.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "начать за"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(324, 32)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Выберите за сколько дней до наступления даты" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "начать о ней напоминать:"
        '
        'AnnualDateEditForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 182)
        Me.Controls.Add(Me.AnnualDateParamsGroupBox)
        Me.Controls.Add(Me.AnnualDateDescriptionGroupBox)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OkButton)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(560, 220)
        Me.Name = "AnnualDateEditForm"
        Me.Text = "Данные о ежегодной дате"
        Me.AnnualDateDescriptionGroupBox.ResumeLayout(False)
        Me.AnnualDateDescriptionGroupBox.PerformLayout()
        Me.AnnualDateParamsGroupBox.ResumeLayout(False)
        Me.AnnualDateParamsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DateDayComboBox As ComboBox
    Friend WithEvents DescLabel As Label
    Friend WithEvents CancelBtn As Button
    Friend WithEvents OkButton As Button
    Friend WithEvents AnnualDateDescriptionGroupBox As GroupBox
    Friend WithEvents AnnualDateTextTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateMonthComboBox As ComboBox
    Friend WithEvents AnnualDateParamsGroupBox As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents DaysAgoComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
