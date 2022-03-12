<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSourceAdvanced
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
		Me.ImageSource = New System.Windows.Forms.PictureBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.ButtonGroup1Clear = New System.Windows.Forms.Button()
		Me.Group1Color = New System.Windows.Forms.PictureBox()
		Me.ButtonGroup1CreateArea = New System.Windows.Forms.Button()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.TextBoxGroup1Thickness = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.CheckBoxGroup1Enabled = New System.Windows.Forms.CheckBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.ButtonGroup0Clear = New System.Windows.Forms.Button()
		Me.Group0Color = New System.Windows.Forms.PictureBox()
		Me.ButtonGroup0CreateArea = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TextBoxGroup0Thickness = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.CheckBoxGroup0Enabled = New System.Windows.Forms.CheckBox()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.GroupBox6 = New System.Windows.Forms.GroupBox()
		Me.TextBoxRearPenetration = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.ButtonGenerateRear = New System.Windows.Forms.Button()
		Me.ImageRear = New System.Windows.Forms.PictureBox()
		Me.ButtonLoadRear = New System.Windows.Forms.Button()
		Me.ButtonReloadRear = New System.Windows.Forms.Button()
		Me.ButtonUnloadRear = New System.Windows.Forms.Button()
		Me.GroupBox5 = New System.Windows.Forms.GroupBox()
		Me.TextBoxFrontPenetration = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.ImageFront = New System.Windows.Forms.PictureBox()
		Me.ButtonLoadFront = New System.Windows.Forms.Button()
		Me.ButtonGenerateFront = New System.Windows.Forms.Button()
		Me.ButtonUnloadFront = New System.Windows.Forms.Button()
		Me.ButtonReloadFront = New System.Windows.Forms.Button()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		CType(Me.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.Group1Color, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		CType(Me.Group0Color, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox4.SuspendLayout()
		Me.GroupBox6.SuspendLayout()
		CType(Me.ImageRear, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox5.SuspendLayout()
		CType(Me.ImageFront, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ImageSource
		'
		Me.ImageSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ImageSource.Location = New System.Drawing.Point(8, 8)
		Me.ImageSource.Name = "ImageSource"
		Me.ImageSource.Size = New System.Drawing.Size(192, 288)
		Me.ImageSource.TabIndex = 1
		Me.ImageSource.TabStop = False
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.GroupBox3)
		Me.GroupBox1.Controls.Add(Me.GroupBox2)
		Me.GroupBox1.Location = New System.Drawing.Point(208, 8)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(184, 224)
		Me.GroupBox1.TabIndex = 2
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "3D profile"
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.ButtonGroup1Clear)
		Me.GroupBox3.Controls.Add(Me.Group1Color)
		Me.GroupBox3.Controls.Add(Me.ButtonGroup1CreateArea)
		Me.GroupBox3.Controls.Add(Me.Label3)
		Me.GroupBox3.Controls.Add(Me.TextBoxGroup1Thickness)
		Me.GroupBox3.Controls.Add(Me.Label4)
		Me.GroupBox3.Controls.Add(Me.CheckBoxGroup1Enabled)
		Me.GroupBox3.Location = New System.Drawing.Point(8, 120)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(168, 96)
		Me.GroupBox3.TabIndex = 19
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "Group 1"
		'
		'ButtonGroup1Clear
		'
		Me.ButtonGroup1Clear.Location = New System.Drawing.Point(120, 64)
		Me.ButtonGroup1Clear.Name = "ButtonGroup1Clear"
		Me.ButtonGroup1Clear.Size = New System.Drawing.Size(43, 23)
		Me.ButtonGroup1Clear.TabIndex = 19
		Me.ButtonGroup1Clear.Tag = "1"
		Me.ButtonGroup1Clear.Text = "Clear"
		Me.ButtonGroup1Clear.UseVisualStyleBackColor = True
		'
		'Group1Color
		'
		Me.Group1Color.Location = New System.Drawing.Point(112, 16)
		Me.Group1Color.Name = "Group1Color"
		Me.Group1Color.Size = New System.Drawing.Size(48, 48)
		Me.Group1Color.TabIndex = 18
		Me.Group1Color.TabStop = False
		Me.Group1Color.Tag = "1"
		'
		'ButtonGroup1CreateArea
		'
		Me.ButtonGroup1CreateArea.Location = New System.Drawing.Point(8, 64)
		Me.ButtonGroup1CreateArea.Name = "ButtonGroup1CreateArea"
		Me.ButtonGroup1CreateArea.Size = New System.Drawing.Size(75, 23)
		Me.ButtonGroup1CreateArea.TabIndex = 17
		Me.ButtonGroup1CreateArea.Tag = "1"
		Me.ButtonGroup1CreateArea.Text = "Create area"
		Me.ButtonGroup1CreateArea.UseVisualStyleBackColor = True
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(88, 43)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(18, 13)
		Me.Label3.TabIndex = 16
		Me.Label3.Text = "px"
		'
		'TextBoxGroup1Thickness
		'
		Me.TextBoxGroup1Thickness.Location = New System.Drawing.Point(64, 40)
		Me.TextBoxGroup1Thickness.Name = "TextBoxGroup1Thickness"
		Me.TextBoxGroup1Thickness.Size = New System.Drawing.Size(24, 20)
		Me.TextBoxGroup1Thickness.TabIndex = 14
		Me.TextBoxGroup1Thickness.Tag = "1"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(8, 43)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(56, 13)
		Me.Label4.TabIndex = 15
		Me.Label4.Text = "Thickness"
		'
		'CheckBoxGroup1Enabled
		'
		Me.CheckBoxGroup1Enabled.AutoSize = True
		Me.CheckBoxGroup1Enabled.Location = New System.Drawing.Point(8, 16)
		Me.CheckBoxGroup1Enabled.Name = "CheckBoxGroup1Enabled"
		Me.CheckBoxGroup1Enabled.Size = New System.Drawing.Size(65, 17)
		Me.CheckBoxGroup1Enabled.TabIndex = 0
		Me.CheckBoxGroup1Enabled.Tag = "1"
		Me.CheckBoxGroup1Enabled.Text = "Enabled"
		Me.CheckBoxGroup1Enabled.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.ButtonGroup0Clear)
		Me.GroupBox2.Controls.Add(Me.Group0Color)
		Me.GroupBox2.Controls.Add(Me.ButtonGroup0CreateArea)
		Me.GroupBox2.Controls.Add(Me.Label1)
		Me.GroupBox2.Controls.Add(Me.TextBoxGroup0Thickness)
		Me.GroupBox2.Controls.Add(Me.Label2)
		Me.GroupBox2.Controls.Add(Me.CheckBoxGroup0Enabled)
		Me.GroupBox2.Location = New System.Drawing.Point(8, 16)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(168, 96)
		Me.GroupBox2.TabIndex = 14
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Group 0"
		'
		'ButtonGroup0Clear
		'
		Me.ButtonGroup0Clear.Location = New System.Drawing.Point(120, 64)
		Me.ButtonGroup0Clear.Name = "ButtonGroup0Clear"
		Me.ButtonGroup0Clear.Size = New System.Drawing.Size(43, 23)
		Me.ButtonGroup0Clear.TabIndex = 20
		Me.ButtonGroup0Clear.Tag = "0"
		Me.ButtonGroup0Clear.Text = "Clear"
		Me.ButtonGroup0Clear.UseVisualStyleBackColor = True
		'
		'Group0Color
		'
		Me.Group0Color.Location = New System.Drawing.Point(112, 16)
		Me.Group0Color.Name = "Group0Color"
		Me.Group0Color.Size = New System.Drawing.Size(48, 48)
		Me.Group0Color.TabIndex = 18
		Me.Group0Color.TabStop = False
		Me.Group0Color.Tag = "0"
		'
		'ButtonGroup0CreateArea
		'
		Me.ButtonGroup0CreateArea.Location = New System.Drawing.Point(8, 64)
		Me.ButtonGroup0CreateArea.Name = "ButtonGroup0CreateArea"
		Me.ButtonGroup0CreateArea.Size = New System.Drawing.Size(75, 23)
		Me.ButtonGroup0CreateArea.TabIndex = 17
		Me.ButtonGroup0CreateArea.Tag = "0"
		Me.ButtonGroup0CreateArea.Text = "Create area"
		Me.ButtonGroup0CreateArea.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(88, 43)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(18, 13)
		Me.Label1.TabIndex = 16
		Me.Label1.Text = "px"
		'
		'TextBoxGroup0Thickness
		'
		Me.TextBoxGroup0Thickness.Location = New System.Drawing.Point(64, 40)
		Me.TextBoxGroup0Thickness.Name = "TextBoxGroup0Thickness"
		Me.TextBoxGroup0Thickness.Size = New System.Drawing.Size(24, 20)
		Me.TextBoxGroup0Thickness.TabIndex = 14
		Me.TextBoxGroup0Thickness.Tag = "0"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(8, 43)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(56, 13)
		Me.Label2.TabIndex = 15
		Me.Label2.Text = "Thickness"
		'
		'CheckBoxGroup0Enabled
		'
		Me.CheckBoxGroup0Enabled.AutoSize = True
		Me.CheckBoxGroup0Enabled.Location = New System.Drawing.Point(8, 16)
		Me.CheckBoxGroup0Enabled.Name = "CheckBoxGroup0Enabled"
		Me.CheckBoxGroup0Enabled.Size = New System.Drawing.Size(65, 17)
		Me.CheckBoxGroup0Enabled.TabIndex = 0
		Me.CheckBoxGroup0Enabled.Tag = "0"
		Me.CheckBoxGroup0Enabled.Text = "Enabled"
		Me.CheckBoxGroup0Enabled.UseVisualStyleBackColor = True
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.GroupBox6)
		Me.GroupBox4.Controls.Add(Me.GroupBox5)
		Me.GroupBox4.Location = New System.Drawing.Point(400, 8)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(424, 192)
		Me.GroupBox4.TabIndex = 3
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "Additional Texture"
		'
		'GroupBox6
		'
		Me.GroupBox6.Controls.Add(Me.Label8)
		Me.GroupBox6.Controls.Add(Me.TextBoxRearPenetration)
		Me.GroupBox6.Controls.Add(Me.Label6)
		Me.GroupBox6.Controls.Add(Me.ButtonGenerateRear)
		Me.GroupBox6.Controls.Add(Me.ImageRear)
		Me.GroupBox6.Controls.Add(Me.ButtonLoadRear)
		Me.GroupBox6.Controls.Add(Me.ButtonReloadRear)
		Me.GroupBox6.Controls.Add(Me.ButtonUnloadRear)
		Me.GroupBox6.Location = New System.Drawing.Point(216, 16)
		Me.GroupBox6.Name = "GroupBox6"
		Me.GroupBox6.Size = New System.Drawing.Size(200, 168)
		Me.GroupBox6.TabIndex = 33
		Me.GroupBox6.TabStop = False
		Me.GroupBox6.Text = "Rear"
		'
		'TextBoxRearPenetration
		'
		Me.TextBoxRearPenetration.Location = New System.Drawing.Point(160, 117)
		Me.TextBoxRearPenetration.Name = "TextBoxRearPenetration"
		Me.TextBoxRearPenetration.Size = New System.Drawing.Size(32, 20)
		Me.TextBoxRearPenetration.TabIndex = 36
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(96, 120)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(61, 13)
		Me.Label6.TabIndex = 35
		Me.Label6.Text = "Penetration"
		'
		'ButtonGenerateRear
		'
		Me.ButtonGenerateRear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
		Me.ButtonGenerateRear.Location = New System.Drawing.Point(8, 120)
		Me.ButtonGenerateRear.Name = "ButtonGenerateRear"
		Me.ButtonGenerateRear.Size = New System.Drawing.Size(80, 24)
		Me.ButtonGenerateRear.TabIndex = 34
		Me.ButtonGenerateRear.Text = "Generate"
		Me.ButtonGenerateRear.UseVisualStyleBackColor = True
		'
		'ImageRear
		'
		Me.ImageRear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ImageRear.Location = New System.Drawing.Point(8, 16)
		Me.ImageRear.Name = "ImageRear"
		Me.ImageRear.Size = New System.Drawing.Size(88, 96)
		Me.ImageRear.TabIndex = 27
		Me.ImageRear.TabStop = False
		'
		'ButtonLoadRear
		'
		Me.ButtonLoadRear.Location = New System.Drawing.Point(112, 16)
		Me.ButtonLoadRear.Name = "ButtonLoadRear"
		Me.ButtonLoadRear.Size = New System.Drawing.Size(80, 24)
		Me.ButtonLoadRear.TabIndex = 26
		Me.ButtonLoadRear.Text = "Load"
		Me.ButtonLoadRear.UseVisualStyleBackColor = True
		'
		'ButtonReloadRear
		'
		Me.ButtonReloadRear.Location = New System.Drawing.Point(112, 48)
		Me.ButtonReloadRear.Name = "ButtonReloadRear"
		Me.ButtonReloadRear.Size = New System.Drawing.Size(80, 24)
		Me.ButtonReloadRear.TabIndex = 30
		Me.ButtonReloadRear.Text = "Reload"
		Me.ButtonReloadRear.UseVisualStyleBackColor = True
		'
		'ButtonUnloadRear
		'
		Me.ButtonUnloadRear.Location = New System.Drawing.Point(112, 80)
		Me.ButtonUnloadRear.Name = "ButtonUnloadRear"
		Me.ButtonUnloadRear.Size = New System.Drawing.Size(80, 24)
		Me.ButtonUnloadRear.TabIndex = 28
		Me.ButtonUnloadRear.Text = "Clear"
		Me.ButtonUnloadRear.UseVisualStyleBackColor = True
		'
		'GroupBox5
		'
		Me.GroupBox5.Controls.Add(Me.Label7)
		Me.GroupBox5.Controls.Add(Me.TextBoxFrontPenetration)
		Me.GroupBox5.Controls.Add(Me.Label5)
		Me.GroupBox5.Controls.Add(Me.ImageFront)
		Me.GroupBox5.Controls.Add(Me.ButtonLoadFront)
		Me.GroupBox5.Controls.Add(Me.ButtonGenerateFront)
		Me.GroupBox5.Controls.Add(Me.ButtonUnloadFront)
		Me.GroupBox5.Controls.Add(Me.ButtonReloadFront)
		Me.GroupBox5.Location = New System.Drawing.Point(8, 16)
		Me.GroupBox5.Name = "GroupBox5"
		Me.GroupBox5.Size = New System.Drawing.Size(200, 168)
		Me.GroupBox5.TabIndex = 32
		Me.GroupBox5.TabStop = False
		Me.GroupBox5.Text = "Front"
		'
		'TextBoxFrontPenetration
		'
		Me.TextBoxFrontPenetration.Location = New System.Drawing.Point(160, 117)
		Me.TextBoxFrontPenetration.Name = "TextBoxFrontPenetration"
		Me.TextBoxFrontPenetration.Size = New System.Drawing.Size(32, 20)
		Me.TextBoxFrontPenetration.TabIndex = 33
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(96, 120)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(61, 13)
		Me.Label5.TabIndex = 32
		Me.Label5.Text = "Penetration"
		'
		'ImageFront
		'
		Me.ImageFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ImageFront.Location = New System.Drawing.Point(8, 16)
		Me.ImageFront.Name = "ImageFront"
		Me.ImageFront.Size = New System.Drawing.Size(88, 96)
		Me.ImageFront.TabIndex = 25
		Me.ImageFront.TabStop = False
		'
		'ButtonLoadFront
		'
		Me.ButtonLoadFront.Location = New System.Drawing.Point(112, 16)
		Me.ButtonLoadFront.Name = "ButtonLoadFront"
		Me.ButtonLoadFront.Size = New System.Drawing.Size(80, 24)
		Me.ButtonLoadFront.TabIndex = 24
		Me.ButtonLoadFront.Text = "Load"
		Me.ButtonLoadFront.UseVisualStyleBackColor = True
		'
		'ButtonGenerateFront
		'
		Me.ButtonGenerateFront.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
		Me.ButtonGenerateFront.Location = New System.Drawing.Point(8, 120)
		Me.ButtonGenerateFront.Name = "ButtonGenerateFront"
		Me.ButtonGenerateFront.Size = New System.Drawing.Size(80, 24)
		Me.ButtonGenerateFront.TabIndex = 31
		Me.ButtonGenerateFront.Text = "Generate"
		Me.ButtonGenerateFront.UseVisualStyleBackColor = True
		'
		'ButtonUnloadFront
		'
		Me.ButtonUnloadFront.Location = New System.Drawing.Point(112, 80)
		Me.ButtonUnloadFront.Name = "ButtonUnloadFront"
		Me.ButtonUnloadFront.Size = New System.Drawing.Size(80, 24)
		Me.ButtonUnloadFront.TabIndex = 23
		Me.ButtonUnloadFront.Text = "Clear"
		Me.ButtonUnloadFront.UseVisualStyleBackColor = True
		'
		'ButtonReloadFront
		'
		Me.ButtonReloadFront.Location = New System.Drawing.Point(112, 48)
		Me.ButtonReloadFront.Name = "ButtonReloadFront"
		Me.ButtonReloadFront.Size = New System.Drawing.Size(80, 24)
		Me.ButtonReloadFront.TabIndex = 29
		Me.ButtonReloadFront.Text = "Reload"
		Me.ButtonReloadFront.UseVisualStyleBackColor = True
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(8, 144)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(98, 13)
		Me.Label7.TabIndex = 34
		Me.Label7.Text = "Copies to Clipboard"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(8, 144)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(98, 13)
		Me.Label8.TabIndex = 37
		Me.Label8.Text = "Copies to Clipboard"
		'
		'FormSourceAdvanced
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(829, 302)
		Me.Controls.Add(Me.GroupBox4)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.ImageSource)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.Name = "FormSourceAdvanced"
		Me.Text = "Advanced source operations"
		CType(Me.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		CType(Me.Group1Color, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.Group0Color, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox4.ResumeLayout(False)
		Me.GroupBox6.ResumeLayout(False)
		Me.GroupBox6.PerformLayout()
		CType(Me.ImageRear, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox5.ResumeLayout(False)
		Me.GroupBox5.PerformLayout()
		CType(Me.ImageFront, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents ImageSource As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Group1Color As PictureBox
    Friend WithEvents ButtonGroup1CreateArea As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxGroup1Thickness As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBoxGroup1Enabled As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Group0Color As PictureBox
    Friend WithEvents ButtonGroup0CreateArea As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxGroup0Thickness As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBoxGroup0Enabled As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ButtonUnloadRear As Button
    Friend WithEvents ButtonUnloadFront As Button
    Friend WithEvents ImageRear As PictureBox
    Friend WithEvents ButtonLoadRear As Button
    Friend WithEvents ButtonLoadFront As Button
    Friend WithEvents ImageFront As PictureBox
    Friend WithEvents ButtonReloadRear As Button
    Friend WithEvents ButtonReloadFront As Button
	Friend WithEvents ButtonGroup1Clear As Button
	Friend WithEvents ButtonGroup0Clear As Button
	Friend WithEvents ButtonGenerateFront As Button
	Friend WithEvents GroupBox6 As GroupBox
	Friend WithEvents GroupBox5 As GroupBox
	Friend WithEvents TextBoxFrontPenetration As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents TextBoxRearPenetration As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents ButtonGenerateRear As Button
	Friend WithEvents Label8 As Label
	Friend WithEvents Label7 As Label
End Class
