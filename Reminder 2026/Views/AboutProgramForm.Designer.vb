<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutProgramForm
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutProgramForm))
        Me.AboutProgramLabel = New System.Windows.Forms.Label()
        Me.TextLabel1 = New System.Windows.Forms.Label()
        Me.TextLabel2 = New System.Windows.Forms.Label()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.AutorLabel = New System.Windows.Forms.Label()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AboutProgramLabel
        '
        Me.AboutProgramLabel.AutoSize = True
        Me.AboutProgramLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AboutProgramLabel.Location = New System.Drawing.Point(13, 22)
        Me.AboutProgramLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.AboutProgramLabel.Name = "AboutProgramLabel"
        Me.AboutProgramLabel.Size = New System.Drawing.Size(104, 16)
        Me.AboutProgramLabel.TabIndex = 0
        Me.AboutProgramLabel.Text = "О программе"
        '
        'TextLabel1
        '
        Me.TextLabel1.AutoSize = True
        Me.TextLabel1.Location = New System.Drawing.Point(12, 49)
        Me.TextLabel1.Name = "TextLabel1"
        Me.TextLabel1.Size = New System.Drawing.Size(55, 16)
        Me.TextLabel1.TabIndex = 1
        Me.TextLabel1.Text = "Версия"
        '
        'TextLabel2
        '
        Me.TextLabel2.AutoSize = True
        Me.TextLabel2.Location = New System.Drawing.Point(12, 74)
        Me.TextLabel2.Name = "TextLabel2"
        Me.TextLabel2.Size = New System.Drawing.Size(79, 16)
        Me.TextLabel2.TabIndex = 2
        Me.TextLabel2.Text = "Создатель"
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Location = New System.Drawing.Point(134, 49)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(45, 16)
        Me.VersionLabel.TabIndex = 3
        Me.VersionLabel.Text = "1.0.0.0"
        '
        'AutorLabel
        '
        Me.AutorLabel.AutoSize = True
        Me.AutorLabel.Location = New System.Drawing.Point(134, 74)
        Me.AutorLabel.Name = "AutorLabel"
        Me.AutorLabel.Size = New System.Drawing.Size(74, 16)
        Me.AutorLabel.TabIndex = 4
        Me.AutorLabel.Text = "Uswer9997"
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DescriptionTextBox.Enabled = False
        Me.DescriptionTextBox.Location = New System.Drawing.Point(16, 123)
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(284, 119)
        Me.DescriptionTextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Описание:"
        '
        'AboutProgramForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 254)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DescriptionTextBox)
        Me.Controls.Add(Me.AutorLabel)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.TextLabel2)
        Me.Controls.Add(Me.TextLabel1)
        Me.Controls.Add(Me.AboutProgramLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutProgramForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "О программе"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AboutProgramLabel As Label
    Friend WithEvents TextLabel1 As Label
    Friend WithEvents TextLabel2 As Label
    Friend WithEvents VersionLabel As Label
    Friend WithEvents AutorLabel As Label
    Friend WithEvents DescriptionTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
