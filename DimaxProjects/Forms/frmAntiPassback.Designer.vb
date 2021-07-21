<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAntiPassback
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAntiPassback))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.OptEnable = New System.Windows.Forms.RadioButton
        Me.OptDisable = New System.Windows.Forms.RadioButton
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.OptDisable)
        Me.Panel1.Controls.Add(Me.OptEnable)
        Me.Panel1.Location = New System.Drawing.Point(5, 6)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 158)
        Me.Panel1.TabIndex = 0
        '
        'OptEnable
        '
        Me.OptEnable.AutoSize = True
        Me.OptEnable.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptEnable.ForeColor = System.Drawing.Color.White
        Me.OptEnable.Location = New System.Drawing.Point(32, 32)
        Me.OptEnable.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.OptEnable.Name = "OptEnable"
        Me.OptEnable.Size = New System.Drawing.Size(199, 22)
        Me.OptEnable.TabIndex = 0
        Me.OptEnable.TabStop = True
        Me.OptEnable.Text = "Enabled Anti-Passback"
        Me.OptEnable.UseVisualStyleBackColor = True
        '
        'OptDisable
        '
        Me.OptDisable.AutoSize = True
        Me.OptDisable.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptDisable.ForeColor = System.Drawing.Color.White
        Me.OptDisable.Location = New System.Drawing.Point(31, 64)
        Me.OptDisable.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.OptDisable.Name = "OptDisable"
        Me.OptDisable.Size = New System.Drawing.Size(204, 22)
        Me.OptDisable.TabIndex = 1
        Me.OptDisable.TabStop = True
        Me.OptDisable.Text = "Disabled Anti-Passback"
        Me.OptDisable.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.White
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(140, 105)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(112, 33)
        Me.cmdSave.TabIndex = 18
        Me.cmdSave.Text = "    &Save"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'frmAntiPassback
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 171)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAntiPassback"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Anti Passback Settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OptDisable As System.Windows.Forms.RadioButton
    Friend WithEvents OptEnable As System.Windows.Forms.RadioButton
    Friend WithEvents cmdSave As System.Windows.Forms.Button
End Class
