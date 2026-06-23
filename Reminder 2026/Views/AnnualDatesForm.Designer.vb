<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnnualDatesForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnnualDatesForm))
        Me.CommandToolStrip = New System.Windows.Forms.ToolStrip()
        Me.AddAnnualDateToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EditAnnualDateToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteAnnualDateToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AnnualDatesDataGridView = New System.Windows.Forms.DataGridView()
        Me.AnnualDatesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CommandToolStrip.SuspendLayout()
        CType(Me.AnnualDatesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnnualDatesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CommandToolStrip
        '
        Me.CommandToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAnnualDateToolStripButton, Me.EditAnnualDateToolStripButton, Me.DeleteAnnualDateToolStripButton})
        Me.CommandToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.CommandToolStrip.Name = "CommandToolStrip"
        Me.CommandToolStrip.Size = New System.Drawing.Size(625, 25)
        Me.CommandToolStrip.TabIndex = 2
        Me.CommandToolStrip.Text = "RemindersToolStrip"
        '
        'AddAnnualDateToolStripButton
        '
        Me.AddAnnualDateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AddAnnualDateToolStripButton.Image = CType(resources.GetObject("AddAnnualDateToolStripButton.Image"), System.Drawing.Image)
        Me.AddAnnualDateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddAnnualDateToolStripButton.Name = "AddAnnualDateToolStripButton"
        Me.AddAnnualDateToolStripButton.Size = New System.Drawing.Size(54, 22)
        Me.AddAnnualDateToolStripButton.Text = "Создать"
        Me.AddAnnualDateToolStripButton.ToolTipText = "Создать новое напоминание"
        '
        'EditAnnualDateToolStripButton
        '
        Me.EditAnnualDateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.EditAnnualDateToolStripButton.Image = CType(resources.GetObject("EditAnnualDateToolStripButton.Image"), System.Drawing.Image)
        Me.EditAnnualDateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditAnnualDateToolStripButton.Name = "EditAnnualDateToolStripButton"
        Me.EditAnnualDateToolStripButton.Size = New System.Drawing.Size(91, 22)
        Me.EditAnnualDateToolStripButton.Text = "Редактировать"
        Me.EditAnnualDateToolStripButton.ToolTipText = "Изменить выделенное напоминание"
        '
        'DeleteAnnualDateToolStripButton
        '
        Me.DeleteAnnualDateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DeleteAnnualDateToolStripButton.Image = CType(resources.GetObject("DeleteAnnualDateToolStripButton.Image"), System.Drawing.Image)
        Me.DeleteAnnualDateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteAnnualDateToolStripButton.Name = "DeleteAnnualDateToolStripButton"
        Me.DeleteAnnualDateToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.DeleteAnnualDateToolStripButton.Text = "Удалить"
        Me.DeleteAnnualDateToolStripButton.ToolTipText = "Удалить выделенное напоминание"
        '
        'AnnualDatesDataGridView
        '
        Me.AnnualDatesDataGridView.AllowUserToAddRows = False
        Me.AnnualDatesDataGridView.AllowUserToResizeRows = False
        Me.AnnualDatesDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AnnualDatesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.AnnualDatesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.AnnualDatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AnnualDatesDataGridView.Location = New System.Drawing.Point(0, 28)
        Me.AnnualDatesDataGridView.MultiSelect = False
        Me.AnnualDatesDataGridView.Name = "AnnualDatesDataGridView"
        Me.AnnualDatesDataGridView.ReadOnly = True
        Me.AnnualDatesDataGridView.RowHeadersVisible = False
        Me.AnnualDatesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AnnualDatesDataGridView.Size = New System.Drawing.Size(625, 337)
        Me.AnnualDatesDataGridView.TabIndex = 3
        '
        'AnnualDatesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 365)
        Me.Controls.Add(Me.AnnualDatesDataGridView)
        Me.Controls.Add(Me.CommandToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AnnualDatesForm"
        Me.Text = "Ежегодные даты"
        Me.CommandToolStrip.ResumeLayout(False)
        Me.CommandToolStrip.PerformLayout()
        CType(Me.AnnualDatesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnnualDatesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CommandToolStrip As ToolStrip
    Friend WithEvents AddAnnualDateToolStripButton As ToolStripButton
    Friend WithEvents EditAnnualDateToolStripButton As ToolStripButton
    Friend WithEvents DeleteAnnualDateToolStripButton As ToolStripButton
    Friend WithEvents AnnualDatesDataGridView As DataGridView
    Friend WithEvents AnnualDatesBindingSource As BindingSource
End Class
