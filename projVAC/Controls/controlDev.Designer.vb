<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class controlDev
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controlDev))
        Me.tmeRead = New System.Windows.Forms.Timer(Me.components)
        Me.txtHandler = New System.Windows.Forms.TextBox
        Me.txtCardCode = New System.Windows.Forms.TextBox
        Me.txtDoor = New System.Windows.Forms.TextBox
        Me.NetVid1 = New AxNETVIDEOACTIVEXLib.AxNetVideoActiveX
        Me.NetVid2 = New AxNETVIDEOACTIVEXLib.AxNetVideoActiveX
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ConnectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshCam1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DisconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestTriggerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NormallyOpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NormallyCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtCtrl = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtStatus = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.NetVid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NetVid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmeRead
        '
        Me.tmeRead.Interval = 300
        '
        'txtHandler
        '
        Me.txtHandler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHandler.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHandler.Location = New System.Drawing.Point(11, 362)
        Me.txtHandler.MaxLength = 30
        Me.txtHandler.Name = "txtHandler"
        Me.txtHandler.Size = New System.Drawing.Size(167, 22)
        Me.txtHandler.TabIndex = 30
        Me.txtHandler.Visible = False
        '
        'txtCardCode
        '
        Me.txtCardCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardCode.Location = New System.Drawing.Point(11, 306)
        Me.txtCardCode.MaxLength = 30
        Me.txtCardCode.Name = "txtCardCode"
        Me.txtCardCode.Size = New System.Drawing.Size(167, 22)
        Me.txtCardCode.TabIndex = 29
        Me.txtCardCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDoor
        '
        Me.txtDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDoor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDoor.Location = New System.Drawing.Point(11, 334)
        Me.txtDoor.MaxLength = 30
        Me.txtDoor.Name = "txtDoor"
        Me.txtDoor.Size = New System.Drawing.Size(167, 22)
        Me.txtDoor.TabIndex = 31
        Me.txtDoor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NetVid1
        '
        Me.NetVid1.Enabled = True
        Me.NetVid1.Location = New System.Drawing.Point(8, 21)
        Me.NetVid1.Name = "NetVid1"
        Me.NetVid1.OcxState = CType(resources.GetObject("NetVid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.NetVid1.Size = New System.Drawing.Size(182, 153)
        Me.NetVid1.TabIndex = 32
        '
        'NetVid2
        '
        Me.NetVid2.Enabled = True
        Me.NetVid2.Location = New System.Drawing.Point(196, 21)
        Me.NetVid2.Name = "NetVid2"
        Me.NetVid2.OcxState = CType(resources.GetObject("NetVid2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.NetVid2.Size = New System.Drawing.Size(182, 153)
        Me.NetVid2.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 16)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Entry Camera"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(193, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Exit Camera"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripStatusLabel1, Me.txtCtrl, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.txtStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 182)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(386, 38)
        Me.StatusStrip1.TabIndex = 40
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectedToolStripMenuItem, Me.RefreshCam1ToolStripMenuItem, Me.DisconnectToolStripMenuItem, Me.ConnectToolStripMenuItem, Me.TestTriggerToolStripMenuItem, Me.NormallyOpenToolStripMenuItem, Me.NormallyCloseToolStripMenuItem})
        Me.ToolStripDropDownButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(91, 36)
        Me.ToolStripDropDownButton1.Text = "Settings"
        '
        'ConnectedToolStripMenuItem
        '
        Me.ConnectedToolStripMenuItem.Name = "ConnectedToolStripMenuItem"
        Me.ConnectedToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ConnectedToolStripMenuItem.Text = "Connected"
        '
        'RefreshCam1ToolStripMenuItem
        '
        Me.RefreshCam1ToolStripMenuItem.Name = "RefreshCam1ToolStripMenuItem"
        Me.RefreshCam1ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RefreshCam1ToolStripMenuItem.Text = "Disconnect"
        '
        'DisconnectToolStripMenuItem
        '
        Me.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem"
        Me.DisconnectToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DisconnectToolStripMenuItem.Text = "Refresh Cam 1"
        '
        'ConnectToolStripMenuItem
        '
        Me.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem"
        Me.ConnectToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ConnectToolStripMenuItem.Text = "Refresh Cam 2"
        '
        'TestTriggerToolStripMenuItem
        '
        Me.TestTriggerToolStripMenuItem.Name = "TestTriggerToolStripMenuItem"
        Me.TestTriggerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TestTriggerToolStripMenuItem.Text = "Test Trigger"
        '
        'NormallyOpenToolStripMenuItem
        '
        Me.NormallyOpenToolStripMenuItem.Name = "NormallyOpenToolStripMenuItem"
        Me.NormallyOpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NormallyOpenToolStripMenuItem.Text = "Normally Open"
        '
        'NormallyCloseToolStripMenuItem
        '
        Me.NormallyCloseToolStripMenuItem.Name = "NormallyCloseToolStripMenuItem"
        Me.NormallyCloseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NormallyCloseToolStripMenuItem.Text = "Normally Close"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(11, 33)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'txtCtrl
        '
        Me.txtCtrl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtCtrl.Name = "txtCtrl"
        Me.txtCtrl.Size = New System.Drawing.Size(63, 33)
        Me.txtCtrl.Text = "Controller 1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(11, 33)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(45, 33)
        Me.ToolStripStatusLabel3.Text = "Status :"
        '
        'txtStatus
        '
        Me.txtStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(71, 33)
        Me.txtStatus.Text = "Disconnected"
        '
        'controlDev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NetVid2)
        Me.Controls.Add(Me.NetVid1)
        Me.Controls.Add(Me.txtDoor)
        Me.Controls.Add(Me.txtHandler)
        Me.Controls.Add(Me.txtCardCode)
        Me.Name = "controlDev"
        Me.Size = New System.Drawing.Size(386, 220)
        CType(Me.NetVid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NetVid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmeRead As System.Windows.Forms.Timer
    Friend WithEvents txtHandler As System.Windows.Forms.TextBox
    Friend WithEvents txtCardCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDoor As System.Windows.Forms.TextBox
    Friend WithEvents NetVid1 As AxNETVIDEOACTIVEXLib.AxNetVideoActiveX
    Friend WithEvents NetVid2 As AxNETVIDEOACTIVEXLib.AxNetVideoActiveX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents DisconnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtCtrl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RefreshCam1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestTriggerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NormallyOpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NormallyCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
