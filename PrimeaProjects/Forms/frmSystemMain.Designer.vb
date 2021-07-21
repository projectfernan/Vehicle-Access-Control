<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemMain))
        Me.txtSystemUser = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SystemTag = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UserAcc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtdbStat = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtMsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SysToolBar = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdSettings = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuSeverCon = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSysAcc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuController = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAntiPsb = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuParkerRec = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditLogs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTerminate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdStart = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.txttime = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.txtCardCode = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtDoor = New System.Windows.Forms.ToolStripTextBox()
        Me.Textbox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.PanelDev = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstList = New System.Windows.Forms.ListView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtSystemUser.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SysToolBar.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSystemUser
        '
        Me.txtSystemUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSystemUser.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel5, Me.SystemTag, Me.UserAcc, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel2, Me.txtdbStat, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.txtMsg})
        Me.txtSystemUser.Location = New System.Drawing.Point(0, 518)
        Me.txtSystemUser.Name = "txtSystemUser"
        Me.txtSystemUser.Size = New System.Drawing.Size(1058, 37)
        Me.txtSystemUser.TabIndex = 2
        Me.txtSystemUser.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel5.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(11, 32)
        Me.ToolStripStatusLabel5.Text = " "
        '
        'SystemTag
        '
        Me.SystemTag.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemTag.Image = CType(resources.GetObject("SystemTag.Image"), System.Drawing.Image)
        Me.SystemTag.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SystemTag.Name = "SystemTag"
        Me.SystemTag.Size = New System.Drawing.Size(92, 32)
        Me.SystemTag.Text = "System :"
        '
        'UserAcc
        '
        Me.UserAcc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserAcc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.UserAcc.Name = "UserAcc"
        Me.UserAcc.Size = New System.Drawing.Size(35, 32)
        Me.UserAcc.Text = "Lock"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel6.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(11, 32)
        Me.ToolStripStatusLabel6.Text = " "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.Image = CType(resources.GetObject("ToolStripStatusLabel2.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(96, 32)
        Me.ToolStripStatusLabel2.Text = "Database :"
        '
        'txtdbStat
        '
        Me.txtdbStat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdbStat.ForeColor = System.Drawing.Color.Red
        Me.txtdbStat.Name = "txtdbStat"
        Me.txtdbStat.Size = New System.Drawing.Size(89, 32)
        Me.txtdbStat.Text = "Disconnected"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(11, 32)
        Me.ToolStripStatusLabel1.Text = " "
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.Image = CType(resources.GetObject("ToolStripStatusLabel3.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(140, 32)
        Me.ToolStripStatusLabel3.Text = "System Message :"
        '
        'txtMsg
        '
        Me.txtMsg.ActiveLinkColor = System.Drawing.Color.Navy
        Me.txtMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMsg.ForeColor = System.Drawing.Color.Navy
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(22, 32)
        Me.txtMsg.Text = "---"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1058, 518)
        Me.SplitContainer1.SplitterDistance = 43
        Me.SplitContainer1.TabIndex = 3
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SysToolBar)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1056, 41)
        Me.SplitContainer2.SplitterDistance = 687
        Me.SplitContainer2.TabIndex = 1
        '
        'SysToolBar
        '
        Me.SysToolBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SysToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator5, Me.cmdSettings, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripSeparator8, Me.cmdStart, Me.ToolStripSeparator3, Me.cmdRefresh, Me.ToolStripSeparator4, Me.ToolStripSeparator7, Me.ToolStripButton1, Me.ToolStripSeparator9})
        Me.SysToolBar.Location = New System.Drawing.Point(0, 0)
        Me.SysToolBar.Name = "SysToolBar"
        Me.SysToolBar.Size = New System.Drawing.Size(687, 41)
        Me.SysToolBar.TabIndex = 2
        Me.SysToolBar.Text = "ToolStrip2"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 41)
        '
        'cmdSettings
        '
        Me.cmdSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeverCon, Me.mnuSysAcc, Me.mnuController, Me.mnuAntiPsb, Me.mnuParkerRec, Me.mnuLogs, Me.mnuAuditLogs, Me.mnuLogout, Me.mnuTerminate})
        Me.cmdSettings.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSettings.Image = CType(resources.GetObject("cmdSettings.Image"), System.Drawing.Image)
        Me.cmdSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Size = New System.Drawing.Size(115, 38)
        Me.cmdSettings.Text = "Settings"
        '
        'mnuSeverCon
        '
        Me.mnuSeverCon.Name = "mnuSeverCon"
        Me.mnuSeverCon.Size = New System.Drawing.Size(267, 22)
        Me.mnuSeverCon.Text = "Server Connection"
        '
        'mnuSysAcc
        '
        Me.mnuSysAcc.Name = "mnuSysAcc"
        Me.mnuSysAcc.Size = New System.Drawing.Size(267, 22)
        Me.mnuSysAcc.Text = "System Accounts"
        '
        'mnuController
        '
        Me.mnuController.Name = "mnuController"
        Me.mnuController.Size = New System.Drawing.Size(267, 22)
        Me.mnuController.Text = "Controller Settings"
        '
        'mnuAntiPsb
        '
        Me.mnuAntiPsb.Name = "mnuAntiPsb"
        Me.mnuAntiPsb.Size = New System.Drawing.Size(267, 22)
        Me.mnuAntiPsb.Text = "Anti Passback Settings"
        '
        'mnuParkerRec
        '
        Me.mnuParkerRec.Name = "mnuParkerRec"
        Me.mnuParkerRec.Size = New System.Drawing.Size(267, 22)
        Me.mnuParkerRec.Text = "Reserved Parker Records"
        '
        'mnuLogs
        '
        Me.mnuLogs.Name = "mnuLogs"
        Me.mnuLogs.Size = New System.Drawing.Size(267, 22)
        Me.mnuLogs.Text = "Logs Report"
        '
        'mnuAuditLogs
        '
        Me.mnuAuditLogs.Name = "mnuAuditLogs"
        Me.mnuAuditLogs.Size = New System.Drawing.Size(267, 22)
        Me.mnuAuditLogs.Text = "Audit Logs"
        Me.mnuAuditLogs.Visible = False
        '
        'mnuLogout
        '
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(267, 22)
        Me.mnuLogout.Text = "Logout"
        '
        'mnuTerminate
        '
        Me.mnuTerminate.Name = "mnuTerminate"
        Me.mnuTerminate.Size = New System.Drawing.Size(267, 22)
        Me.mnuTerminate.Text = "Terminate System"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 41)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(10, 38)
        Me.ToolStripLabel1.Text = " "
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 41)
        Me.ToolStripSeparator2.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 41)
        '
        'cmdStart
        '
        Me.cmdStart.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStart.Image = CType(resources.GetObject("cmdStart.Image"), System.Drawing.Image)
        Me.cmdStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(82, 38)
        Me.cmdStart.Text = "Start"
        Me.cmdStart.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 41)
        Me.ToolStripSeparator3.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Image = CType(resources.GetObject("cmdRefresh.Image"), System.Drawing.Image)
        Me.cmdRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(215, 38)
        Me.cmdRefresh.Text = "Refresh Controller List"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 41)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 41)
        Me.ToolStripSeparator7.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(135, 38)
        Me.ToolStripButton1.Text = "Test Trigger"
        Me.ToolStripButton1.Visible = False
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 41)
        Me.ToolStripSeparator9.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.txttime, Me.ToolStripLabel4, Me.txtCardCode, Me.ToolStripSeparator6, Me.txtDoor, Me.Textbox1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(365, 41)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(10, 38)
        Me.ToolStripLabel3.Text = " "
        '
        'txttime
        '
        Me.txttime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txttime.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttime.Image = CType(resources.GetObject("txttime.Image"), System.Drawing.Image)
        Me.txttime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.txttime.Name = "txttime"
        Me.txttime.Size = New System.Drawing.Size(76, 38)
        Me.txttime.Text = "Time"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(13, 38)
        Me.ToolStripLabel4.Text = "  "
        '
        'txtCardCode
        '
        Me.txtCardCode.Name = "txtCardCode"
        Me.txtCardCode.Size = New System.Drawing.Size(100, 41)
        Me.txtCardCode.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 41)
        Me.ToolStripSeparator6.Visible = False
        '
        'txtDoor
        '
        Me.txtDoor.Name = "txtDoor"
        Me.txtDoor.Size = New System.Drawing.Size(100, 41)
        Me.txtDoor.Visible = False
        '
        'Textbox1
        '
        Me.Textbox1.Name = "Textbox1"
        Me.Textbox1.Size = New System.Drawing.Size(100, 41)
        Me.Textbox1.Visible = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.PanelDev)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer3.Size = New System.Drawing.Size(1058, 471)
        Me.SplitContainer3.SplitterDistance = 689
        Me.SplitContainer3.TabIndex = 0
        '
        'PanelDev
        '
        Me.PanelDev.AutoScroll = True
        Me.PanelDev.ColumnCount = 2
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PanelDev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDev.Location = New System.Drawing.Point(0, 0)
        Me.PanelDev.Name = "PanelDev"
        Me.PanelDev.RowCount = 8
        Me.PanelDev.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.PanelDev.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.PanelDev.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.PanelDev.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.PanelDev.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.PanelDev.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.PanelDev.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.PanelDev.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.PanelDev.Size = New System.Drawing.Size(687, 469)
        Me.PanelDev.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Black
        Me.GroupBox2.Controls.Add(Me.lstList)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(346, 451)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Real Time Logs"
        '
        'lstList
        '
        Me.lstList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstList.FullRowSelect = True
        Me.lstList.GridLines = True
        Me.lstList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstList.Location = New System.Drawing.Point(7, 19)
        Me.lstList.MultiSelect = False
        Me.lstList.Name = "lstList"
        Me.lstList.Size = New System.Drawing.Size(333, 425)
        Me.lstList.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lstList.TabIndex = 2
        Me.lstList.UseCompatibleStateImageBehavior = False
        Me.lstList.View = System.Windows.Forms.View.Details
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'frmSystemMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 555)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.txtSystemUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmSystemMain"
        Me.Text = "frmSystemMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.txtSystemUser.ResumeLayout(False)
        Me.txtSystemUser.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SysToolBar.ResumeLayout(False)
        Me.SysToolBar.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSystemUser As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SystemTag As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserAcc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtdbStat As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtMsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SysToolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSettings As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuSeverCon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuController As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAntiPsb As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuParkerRec As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTerminate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txttime As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtCardCode As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtDoor As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Textbox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstList As System.Windows.Forms.ListView
    Friend WithEvents PanelDev As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSysAcc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAuditLogs As System.Windows.Forms.ToolStripMenuItem
End Class
