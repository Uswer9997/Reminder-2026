<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemindersForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RemindersForm))
        Me.ReminderNotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MainIconContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemindersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IsActiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommandToolStrip = New System.Windows.Forms.ToolStrip()
        Me.AddReminderToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EditReminderToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteReminderToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.RemindersDataGridView = New System.Windows.Forms.DataGridView()
        Me.RemindersDGVContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CreateReminderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditReminderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteReminderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemindersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RemindersSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.ReminderGroupBox = New System.Windows.Forms.GroupBox()
        Me.ReminderTextBox = New System.Windows.Forms.TextBox()
        Me.RemindersToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ReminderTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainIconContextMenuStrip.SuspendLayout()
        Me.CommandToolStrip.SuspendLayout()
        CType(Me.RemindersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RemindersDGVContextMenuStrip.SuspendLayout()
        CType(Me.RemindersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemindersSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RemindersSplitContainer.Panel1.SuspendLayout()
        Me.RemindersSplitContainer.Panel2.SuspendLayout()
        Me.RemindersSplitContainer.SuspendLayout()
        Me.ReminderGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReminderNotifyIcon
        '
        Me.ReminderNotifyIcon.ContextMenuStrip = Me.MainIconContextMenuStrip
        Me.ReminderNotifyIcon.Icon = CType(resources.GetObject("ReminderNotifyIcon.Icon"), System.Drawing.Icon)
        Me.ReminderNotifyIcon.Text = "Напоминания"
        Me.ReminderNotifyIcon.Visible = True
        '
        'MainIconContextMenuStrip
        '
        Me.MainIconContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemindersToolStripMenuItem, Me.IsActiveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MainIconContextMenuStrip.Name = "MainIconContextMenuStrip"
        Me.MainIconContextMenuStrip.Size = New System.Drawing.Size(153, 70)
        '
        'RemindersToolStripMenuItem
        '
        Me.RemindersToolStripMenuItem.Name = "RemindersToolStripMenuItem"
        Me.RemindersToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RemindersToolStripMenuItem.Text = "Напоминания"
        '
        'IsActiveToolStripMenuItem
        '
        Me.IsActiveToolStripMenuItem.Checked = True
        Me.IsActiveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IsActiveToolStripMenuItem.Name = "IsActiveToolStripMenuItem"
        Me.IsActiveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IsActiveToolStripMenuItem.Text = "Активен"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Выход"
        '
        'CommandToolStrip
        '
        Me.CommandToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddReminderToolStripButton, Me.EditReminderToolStripButton, Me.DeleteReminderToolStripButton})
        Me.CommandToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.CommandToolStrip.Name = "CommandToolStrip"
        Me.CommandToolStrip.Size = New System.Drawing.Size(558, 25)
        Me.CommandToolStrip.TabIndex = 1
        Me.CommandToolStrip.Text = "RemindersToolStrip"
        '
        'AddReminderToolStripButton
        '
        Me.AddReminderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AddReminderToolStripButton.Image = CType(resources.GetObject("AddReminderToolStripButton.Image"), System.Drawing.Image)
        Me.AddReminderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddReminderToolStripButton.Name = "AddReminderToolStripButton"
        Me.AddReminderToolStripButton.Size = New System.Drawing.Size(54, 22)
        Me.AddReminderToolStripButton.Text = "Создать"
        Me.AddReminderToolStripButton.ToolTipText = "Создать новое напоминание"
        '
        'EditReminderToolStripButton
        '
        Me.EditReminderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.EditReminderToolStripButton.Image = CType(resources.GetObject("EditReminderToolStripButton.Image"), System.Drawing.Image)
        Me.EditReminderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditReminderToolStripButton.Name = "EditReminderToolStripButton"
        Me.EditReminderToolStripButton.Size = New System.Drawing.Size(91, 22)
        Me.EditReminderToolStripButton.Text = "Редактировать"
        Me.EditReminderToolStripButton.ToolTipText = "Изменить выделенное напоминание"
        '
        'DeleteReminderToolStripButton
        '
        Me.DeleteReminderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DeleteReminderToolStripButton.Image = CType(resources.GetObject("DeleteReminderToolStripButton.Image"), System.Drawing.Image)
        Me.DeleteReminderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteReminderToolStripButton.Name = "DeleteReminderToolStripButton"
        Me.DeleteReminderToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.DeleteReminderToolStripButton.Text = "Удалить"
        Me.DeleteReminderToolStripButton.ToolTipText = "Удалить выделенное напоминание"
        '
        'RemindersDataGridView
        '
        Me.RemindersDataGridView.AllowUserToAddRows = False
        Me.RemindersDataGridView.AllowUserToResizeRows = False
        Me.RemindersDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RemindersDataGridView.AutoGenerateColumns = False
        Me.RemindersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.RemindersDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.RemindersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RemindersDataGridView.ContextMenuStrip = Me.RemindersDGVContextMenuStrip
        Me.RemindersDataGridView.DataSource = Me.RemindersBindingSource
        Me.RemindersDataGridView.Location = New System.Drawing.Point(2, 2)
        Me.RemindersDataGridView.MultiSelect = False
        Me.RemindersDataGridView.Name = "RemindersDataGridView"
        Me.RemindersDataGridView.ReadOnly = True
        Me.RemindersDataGridView.RowHeadersVisible = False
        Me.RemindersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RemindersDataGridView.Size = New System.Drawing.Size(554, 223)
        Me.RemindersDataGridView.TabIndex = 2
        '
        'RemindersDGVContextMenuStrip
        '
        Me.RemindersDGVContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateReminderToolStripMenuItem, Me.EditReminderToolStripMenuItem, Me.DeleteReminderToolStripMenuItem, Me.ToolStripSeparator1, Me.ChangeActivityToolStripMenuItem})
        Me.RemindersDGVContextMenuStrip.Name = "RemindersDGVContextMenuStrip"
        Me.RemindersDGVContextMenuStrip.Size = New System.Drawing.Size(234, 98)
        '
        'CreateReminderToolStripMenuItem
        '
        Me.CreateReminderToolStripMenuItem.Name = "CreateReminderToolStripMenuItem"
        Me.CreateReminderToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.CreateReminderToolStripMenuItem.Text = "Создать напоминание"
        '
        'EditReminderToolStripMenuItem
        '
        Me.EditReminderToolStripMenuItem.Name = "EditReminderToolStripMenuItem"
        Me.EditReminderToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.EditReminderToolStripMenuItem.Text = "Редактировать напоминание"
        '
        'DeleteReminderToolStripMenuItem
        '
        Me.DeleteReminderToolStripMenuItem.Name = "DeleteReminderToolStripMenuItem"
        Me.DeleteReminderToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.DeleteReminderToolStripMenuItem.Text = "Удалить напоминание"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(230, 6)
        '
        'ChangeActivityToolStripMenuItem
        '
        Me.ChangeActivityToolStripMenuItem.Name = "ChangeActivityToolStripMenuItem"
        Me.ChangeActivityToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ChangeActivityToolStripMenuItem.Text = "Изменить активность"
        '
        'RemindersSplitContainer
        '
        Me.RemindersSplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RemindersSplitContainer.BackColor = System.Drawing.SystemColors.Control
        Me.RemindersSplitContainer.Location = New System.Drawing.Point(0, 23)
        Me.RemindersSplitContainer.Name = "RemindersSplitContainer"
        Me.RemindersSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'RemindersSplitContainer.Panel1
        '
        Me.RemindersSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.RemindersSplitContainer.Panel1.Controls.Add(Me.RemindersDataGridView)
        '
        'RemindersSplitContainer.Panel2
        '
        Me.RemindersSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.RemindersSplitContainer.Panel2.Controls.Add(Me.ReminderGroupBox)
        Me.RemindersSplitContainer.Size = New System.Drawing.Size(558, 349)
        Me.RemindersSplitContainer.SplitterDistance = 227
        Me.RemindersSplitContainer.TabIndex = 3
        '
        'ReminderGroupBox
        '
        Me.ReminderGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReminderGroupBox.Controls.Add(Me.ReminderTextBox)
        Me.ReminderGroupBox.Location = New System.Drawing.Point(2, 4)
        Me.ReminderGroupBox.Name = "ReminderGroupBox"
        Me.ReminderGroupBox.Size = New System.Drawing.Size(554, 112)
        Me.ReminderGroupBox.TabIndex = 0
        Me.ReminderGroupBox.TabStop = False
        Me.ReminderGroupBox.Text = "Выбранное задание"
        '
        'ReminderTextBox
        '
        Me.ReminderTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReminderTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ReminderTextBox.Location = New System.Drawing.Point(4, 16)
        Me.ReminderTextBox.Multiline = True
        Me.ReminderTextBox.Name = "ReminderTextBox"
        Me.ReminderTextBox.ReadOnly = True
        Me.ReminderTextBox.Size = New System.Drawing.Size(546, 92)
        Me.ReminderTextBox.TabIndex = 0
        '
        'ReminderTimer
        '
        Me.ReminderTimer.Interval = 5000
        '
        'RemindersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 373)
        Me.Controls.Add(Me.RemindersSplitContainer)
        Me.Controls.Add(Me.CommandToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RemindersForm"
        Me.ShowInTaskbar = False
        Me.Text = "Напоминания"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.MainIconContextMenuStrip.ResumeLayout(False)
        Me.CommandToolStrip.ResumeLayout(False)
        Me.CommandToolStrip.PerformLayout()
        CType(Me.RemindersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RemindersDGVContextMenuStrip.ResumeLayout(False)
        CType(Me.RemindersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RemindersSplitContainer.Panel1.ResumeLayout(False)
        Me.RemindersSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.RemindersSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RemindersSplitContainer.ResumeLayout(False)
        Me.ReminderGroupBox.ResumeLayout(False)
        Me.ReminderGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReminderNotifyIcon As NotifyIcon
    Friend WithEvents CommandToolStrip As ToolStrip
    Friend WithEvents AddReminderToolStripButton As ToolStripButton
    Friend WithEvents EditReminderToolStripButton As ToolStripButton
    Friend WithEvents DeleteReminderToolStripButton As ToolStripButton
    Friend WithEvents RemindersBindingSource As BindingSource
    Friend WithEvents RemindersDataGridView As DataGridView
    Friend WithEvents MainIconContextMenuStrip As ContextMenuStrip
    Friend WithEvents RemindersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IsActiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemindersSplitContainer As SplitContainer
    Friend WithEvents ReminderGroupBox As GroupBox
    Friend WithEvents ReminderTextBox As TextBox
    Friend WithEvents RemindersToolTip As ToolTip
    Friend WithEvents RemindersDGVContextMenuStrip As ContextMenuStrip
    Friend WithEvents CreateReminderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditReminderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteReminderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ChangeActivityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReminderTimer As Timer
End Class
