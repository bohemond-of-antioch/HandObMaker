<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
		Me.ImageSource = New System.Windows.Forms.PictureBox()
		Me.ButtonLoadSource = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.TextBoxItemWidth = New System.Windows.Forms.TextBox()
		Me.TextBoxItemHeight = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.ImageDestinationHandOb = New System.Windows.Forms.PictureBox()
		Me.ButtonExportHandOb = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.ButtonReloadSourceImage = New System.Windows.Forms.Button()
		Me.ButtonOpenDetails = New System.Windows.Forms.Button()
		Me.ButtonFindCenter = New System.Windows.Forms.Button()
		Me.ButtonFlip = New System.Windows.Forms.Button()
		Me.ButtonMirror = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.TextBoxThickness = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.ButtonExportHandObTFTDPalette = New System.Windows.Forms.Button()
		Me.ButtonExportHandObXComPalette = New System.Windows.Forms.Button()
		Me.GroupBox10 = New System.Windows.Forms.GroupBox()
		Me.ButtonSendToUnitSpriteStudio = New System.Windows.Forms.Button()
		Me.CheckBoxSendToUnitSpriteStudio = New System.Windows.Forms.CheckBox()
		Me.CheckBoxOverrideMask3 = New System.Windows.Forms.CheckBox()
		Me.GroupBox5 = New System.Windows.Forms.GroupBox()
		Me.CheckBoxShadedCenterline = New System.Windows.Forms.CheckBox()
		Me.GroupBox6 = New System.Windows.Forms.GroupBox()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.TextBoxAvgTransparencyCutoff = New System.Windows.Forms.TextBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.TextBoxAvgRadiusFalloff = New System.Windows.Forms.TextBox()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.TextBoxAvgRadiusWeight = New System.Windows.Forms.TextBox()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.TextBoxAvgRadius = New System.Windows.Forms.TextBox()
		Me.ComboBoxColoringMethod = New System.Windows.Forms.ComboBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.TextBoxVerticalAspect = New System.Windows.Forms.TextBox()
		Me.CheckBoxTwoHanded = New System.Windows.Forms.CheckBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.CheckBoxHorizontal = New System.Windows.Forms.CheckBox()
		Me.TextBoxScalingFactor = New System.Windows.Forms.TextBox()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.CheckBoxMaskHand = New System.Windows.Forms.CheckBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.TextBoxHandSize = New System.Windows.Forms.TextBox()
		Me.GroupBox7 = New System.Windows.Forms.GroupBox()
		Me.ButtonExportFloorObTFTDPalette = New System.Windows.Forms.Button()
		Me.ButtonExportFloorObUFOPalette = New System.Windows.Forms.Button()
		Me.ButtonExportFloorOb = New System.Windows.Forms.Button()
		Me.ImageDestinationFloorOb = New System.Windows.Forms.PictureBox()
		Me.GroupBox8 = New System.Windows.Forms.GroupBox()
		Me.CheckBoxFloorObHorizontal = New System.Windows.Forms.CheckBox()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.TextBoxFloorObScale = New System.Windows.Forms.TextBox()
		Me.CheckBoxDrawGrip = New System.Windows.Forms.CheckBox()
		Me.GroupBox9 = New System.Windows.Forms.GroupBox()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.ListBoxRecentFiles = New System.Windows.Forms.ListBox()
		Me.ButtonLoadFile = New System.Windows.Forms.Button()
		Me.ButtonSaveFile = New System.Windows.Forms.Button()
		CType(Me.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ImageDestinationHandOb, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox10.SuspendLayout()
		Me.GroupBox5.SuspendLayout()
		Me.GroupBox6.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.GroupBox7.SuspendLayout()
		CType(Me.ImageDestinationFloorOb, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox8.SuspendLayout()
		Me.GroupBox9.SuspendLayout()
		Me.SuspendLayout()
		'
		'ImageSource
		'
		Me.ImageSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ImageSource.Location = New System.Drawing.Point(8, 40)
		Me.ImageSource.Name = "ImageSource"
		Me.ImageSource.Size = New System.Drawing.Size(96, 144)
		Me.ImageSource.TabIndex = 0
		Me.ImageSource.TabStop = False
		'
		'ButtonLoadSource
		'
		Me.ButtonLoadSource.Location = New System.Drawing.Point(8, 16)
		Me.ButtonLoadSource.Name = "ButtonLoadSource"
		Me.ButtonLoadSource.Size = New System.Drawing.Size(75, 23)
		Me.ButtonLoadSource.TabIndex = 2
		Me.ButtonLoadSource.Text = "Load"
		Me.ButtonLoadSource.UseVisualStyleBackColor = True
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(8, 216)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(48, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Item size"
		'
		'TextBoxItemWidth
		'
		Me.TextBoxItemWidth.Location = New System.Drawing.Point(64, 232)
		Me.TextBoxItemWidth.Name = "TextBoxItemWidth"
		Me.TextBoxItemWidth.Size = New System.Drawing.Size(24, 20)
		Me.TextBoxItemWidth.TabIndex = 4
		'
		'TextBoxItemHeight
		'
		Me.TextBoxItemHeight.Location = New System.Drawing.Point(64, 256)
		Me.TextBoxItemHeight.Name = "TextBoxItemHeight"
		Me.TextBoxItemHeight.Size = New System.Drawing.Size(24, 20)
		Me.TextBoxItemHeight.TabIndex = 5
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(8, 235)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(35, 13)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "Width"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(8, 259)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(38, 13)
		Me.Label4.TabIndex = 7
		Me.Label4.Text = "Height"
		'
		'ImageDestinationHandOb
		'
		Me.ImageDestinationHandOb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ImageDestinationHandOb.Location = New System.Drawing.Point(8, 224)
		Me.ImageDestinationHandOb.Name = "ImageDestinationHandOb"
		Me.ImageDestinationHandOb.Size = New System.Drawing.Size(768, 120)
		Me.ImageDestinationHandOb.TabIndex = 8
		Me.ImageDestinationHandOb.TabStop = False
		'
		'ButtonExportHandOb
		'
		Me.ButtonExportHandOb.Location = New System.Drawing.Point(8, 168)
		Me.ButtonExportHandOb.Name = "ButtonExportHandOb"
		Me.ButtonExportHandOb.Size = New System.Drawing.Size(75, 48)
		Me.ButtonExportHandOb.TabIndex = 9
		Me.ButtonExportHandOb.Text = "Export HandOb"
		Me.ButtonExportHandOb.UseVisualStyleBackColor = True
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.ButtonReloadSourceImage)
		Me.GroupBox1.Controls.Add(Me.ButtonOpenDetails)
		Me.GroupBox1.Controls.Add(Me.ButtonFindCenter)
		Me.GroupBox1.Controls.Add(Me.ButtonFlip)
		Me.GroupBox1.Controls.Add(Me.ButtonMirror)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.TextBoxThickness)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.ImageSource)
		Me.GroupBox1.Controls.Add(Me.TextBoxItemHeight)
		Me.GroupBox1.Controls.Add(Me.ButtonLoadSource)
		Me.GroupBox1.Controls.Add(Me.TextBoxItemWidth)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(128, 504)
		Me.GroupBox1.TabIndex = 10
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Source image (BigOb)"
		'
		'ButtonReloadSourceImage
		'
		Me.ButtonReloadSourceImage.Location = New System.Drawing.Point(8, 184)
		Me.ButtonReloadSourceImage.Name = "ButtonReloadSourceImage"
		Me.ButtonReloadSourceImage.Size = New System.Drawing.Size(112, 23)
		Me.ButtonReloadSourceImage.TabIndex = 17
		Me.ButtonReloadSourceImage.Text = "Reload from disk"
		Me.ButtonReloadSourceImage.UseVisualStyleBackColor = True
		'
		'ButtonOpenDetails
		'
		Me.ButtonOpenDetails.Location = New System.Drawing.Point(8, 376)
		Me.ButtonOpenDetails.Name = "ButtonOpenDetails"
		Me.ButtonOpenDetails.Size = New System.Drawing.Size(112, 23)
		Me.ButtonOpenDetails.TabIndex = 18
		Me.ButtonOpenDetails.Text = "Advanced options"
		Me.ButtonOpenDetails.UseVisualStyleBackColor = True
		'
		'ButtonFindCenter
		'
		Me.ButtonFindCenter.Location = New System.Drawing.Point(8, 344)
		Me.ButtonFindCenter.Name = "ButtonFindCenter"
		Me.ButtonFindCenter.Size = New System.Drawing.Size(112, 23)
		Me.ButtonFindCenter.TabIndex = 13
		Me.ButtonFindCenter.Text = "Find center"
		Me.ButtonFindCenter.UseVisualStyleBackColor = True
		'
		'ButtonFlip
		'
		Me.ButtonFlip.Location = New System.Drawing.Point(64, 312)
		Me.ButtonFlip.Name = "ButtonFlip"
		Me.ButtonFlip.Size = New System.Drawing.Size(56, 23)
		Me.ButtonFlip.TabIndex = 19
		Me.ButtonFlip.Text = "Flip"
		Me.ButtonFlip.UseVisualStyleBackColor = True
		'
		'ButtonMirror
		'
		Me.ButtonMirror.Location = New System.Drawing.Point(8, 312)
		Me.ButtonMirror.Name = "ButtonMirror"
		Me.ButtonMirror.Size = New System.Drawing.Size(56, 23)
		Me.ButtonMirror.TabIndex = 18
		Me.ButtonMirror.Text = "Mirror"
		Me.ButtonMirror.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(88, 283)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(18, 13)
		Me.Label6.TabIndex = 10
		Me.Label6.Text = "px"
		'
		'TextBoxThickness
		'
		Me.TextBoxThickness.Location = New System.Drawing.Point(64, 280)
		Me.TextBoxThickness.Name = "TextBoxThickness"
		Me.TextBoxThickness.Size = New System.Drawing.Size(24, 20)
		Me.TextBoxThickness.TabIndex = 8
		Me.TextBoxThickness.Text = "3"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(8, 283)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(56, 13)
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "Thickness"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.ButtonExportHandObTFTDPalette)
		Me.GroupBox2.Controls.Add(Me.ButtonExportHandObXComPalette)
		Me.GroupBox2.Controls.Add(Me.GroupBox10)
		Me.GroupBox2.Controls.Add(Me.CheckBoxOverrideMask3)
		Me.GroupBox2.Controls.Add(Me.GroupBox5)
		Me.GroupBox2.Controls.Add(Me.GroupBox4)
		Me.GroupBox2.Controls.Add(Me.ButtonExportHandOb)
		Me.GroupBox2.Controls.Add(Me.GroupBox3)
		Me.GroupBox2.Controls.Add(Me.ImageDestinationHandOb)
		Me.GroupBox2.Location = New System.Drawing.Point(136, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(784, 352)
		Me.GroupBox2.TabIndex = 11
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "HandOb"
		'
		'ButtonExportHandObTFTDPalette
		'
		Me.ButtonExportHandObTFTDPalette.Location = New System.Drawing.Point(88, 192)
		Me.ButtonExportHandObTFTDPalette.Name = "ButtonExportHandObTFTDPalette"
		Me.ButtonExportHandObTFTDPalette.Size = New System.Drawing.Size(160, 24)
		Me.ButtonExportHandObTFTDPalette.TabIndex = 22
		Me.ButtonExportHandObTFTDPalette.Text = "Export in TFTD Palette"
		Me.ButtonExportHandObTFTDPalette.UseVisualStyleBackColor = True
		'
		'ButtonExportHandObXComPalette
		'
		Me.ButtonExportHandObXComPalette.Location = New System.Drawing.Point(88, 168)
		Me.ButtonExportHandObXComPalette.Name = "ButtonExportHandObXComPalette"
		Me.ButtonExportHandObXComPalette.Size = New System.Drawing.Size(160, 24)
		Me.ButtonExportHandObXComPalette.TabIndex = 21
		Me.ButtonExportHandObXComPalette.Text = "Export in UFO-EU Palette"
		Me.ButtonExportHandObXComPalette.UseVisualStyleBackColor = True
		'
		'GroupBox10
		'
		Me.GroupBox10.Controls.Add(Me.ButtonSendToUnitSpriteStudio)
		Me.GroupBox10.Controls.Add(Me.CheckBoxSendToUnitSpriteStudio)
		Me.GroupBox10.Location = New System.Drawing.Point(576, 16)
		Me.GroupBox10.Name = "GroupBox10"
		Me.GroupBox10.Size = New System.Drawing.Size(200, 80)
		Me.GroupBox10.TabIndex = 20
		Me.GroupBox10.TabStop = False
		Me.GroupBox10.Text = "UnitSprite Studio Integration"
		'
		'ButtonSendToUnitSpriteStudio
		'
		Me.ButtonSendToUnitSpriteStudio.Location = New System.Drawing.Point(8, 40)
		Me.ButtonSendToUnitSpriteStudio.Name = "ButtonSendToUnitSpriteStudio"
		Me.ButtonSendToUnitSpriteStudio.Size = New System.Drawing.Size(104, 24)
		Me.ButtonSendToUnitSpriteStudio.TabIndex = 18
		Me.ButtonSendToUnitSpriteStudio.Text = "Send"
		Me.ButtonSendToUnitSpriteStudio.UseVisualStyleBackColor = True
		'
		'CheckBoxSendToUnitSpriteStudio
		'
		Me.CheckBoxSendToUnitSpriteStudio.AutoSize = True
		Me.CheckBoxSendToUnitSpriteStudio.Location = New System.Drawing.Point(8, 16)
		Me.CheckBoxSendToUnitSpriteStudio.Name = "CheckBoxSendToUnitSpriteStudio"
		Me.CheckBoxSendToUnitSpriteStudio.Size = New System.Drawing.Size(116, 17)
		Me.CheckBoxSendToUnitSpriteStudio.TabIndex = 19
		Me.CheckBoxSendToUnitSpriteStudio.Text = "Send Automatically"
		Me.CheckBoxSendToUnitSpriteStudio.UseVisualStyleBackColor = True
		'
		'CheckBoxOverrideMask3
		'
		Me.CheckBoxOverrideMask3.AutoSize = True
		Me.CheckBoxOverrideMask3.Location = New System.Drawing.Point(304, 205)
		Me.CheckBoxOverrideMask3.Name = "CheckBoxOverrideMask3"
		Me.CheckBoxOverrideMask3.Size = New System.Drawing.Size(79, 17)
		Me.CheckBoxOverrideMask3.TabIndex = 17
		Me.CheckBoxOverrideMask3.Text = "Don't mask"
		Me.CheckBoxOverrideMask3.UseVisualStyleBackColor = True
		'
		'GroupBox5
		'
		Me.GroupBox5.Controls.Add(Me.CheckBoxShadedCenterline)
		Me.GroupBox5.Controls.Add(Me.GroupBox6)
		Me.GroupBox5.Controls.Add(Me.ComboBoxColoringMethod)
		Me.GroupBox5.Controls.Add(Me.Label7)
		Me.GroupBox5.Location = New System.Drawing.Point(256, 16)
		Me.GroupBox5.Name = "GroupBox5"
		Me.GroupBox5.Size = New System.Drawing.Size(312, 160)
		Me.GroupBox5.TabIndex = 16
		Me.GroupBox5.TabStop = False
		Me.GroupBox5.Text = "Pixelation"
		'
		'CheckBoxShadedCenterline
		'
		Me.CheckBoxShadedCenterline.AutoSize = True
		Me.CheckBoxShadedCenterline.Location = New System.Drawing.Point(176, 48)
		Me.CheckBoxShadedCenterline.Name = "CheckBoxShadedCenterline"
		Me.CheckBoxShadedCenterline.Size = New System.Drawing.Size(128, 17)
		Me.CheckBoxShadedCenterline.TabIndex = 16
		Me.CheckBoxShadedCenterline.Text = "Highlighted centerline"
		Me.CheckBoxShadedCenterline.UseVisualStyleBackColor = True
		'
		'GroupBox6
		'
		Me.GroupBox6.Controls.Add(Me.Label13)
		Me.GroupBox6.Controls.Add(Me.TextBoxAvgTransparencyCutoff)
		Me.GroupBox6.Controls.Add(Me.Label12)
		Me.GroupBox6.Controls.Add(Me.TextBoxAvgRadiusFalloff)
		Me.GroupBox6.Controls.Add(Me.Label11)
		Me.GroupBox6.Controls.Add(Me.TextBoxAvgRadiusWeight)
		Me.GroupBox6.Controls.Add(Me.Label10)
		Me.GroupBox6.Controls.Add(Me.TextBoxAvgRadius)
		Me.GroupBox6.Location = New System.Drawing.Point(8, 40)
		Me.GroupBox6.Name = "GroupBox6"
		Me.GroupBox6.Size = New System.Drawing.Size(160, 112)
		Me.GroupBox6.TabIndex = 15
		Me.GroupBox6.TabStop = False
		Me.GroupBox6.Text = "Average options"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(8, 92)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(102, 13)
		Me.Label13.TabIndex = 20
		Me.Label13.Text = "Transparency cutoff"
		'
		'TextBoxAvgTransparencyCutoff
		'
		Me.TextBoxAvgTransparencyCutoff.Location = New System.Drawing.Point(112, 88)
		Me.TextBoxAvgTransparencyCutoff.Name = "TextBoxAvgTransparencyCutoff"
		Me.TextBoxAvgTransparencyCutoff.Size = New System.Drawing.Size(40, 20)
		Me.TextBoxAvgTransparencyCutoff.TabIndex = 19
		Me.TextBoxAvgTransparencyCutoff.Text = "5"
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Location = New System.Drawing.Point(8, 68)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(71, 13)
		Me.Label12.TabIndex = 18
		Me.Label12.Text = "Radius Falloff"
		'
		'TextBoxAvgRadiusFalloff
		'
		Me.TextBoxAvgRadiusFalloff.Location = New System.Drawing.Point(112, 64)
		Me.TextBoxAvgRadiusFalloff.Name = "TextBoxAvgRadiusFalloff"
		Me.TextBoxAvgRadiusFalloff.Size = New System.Drawing.Size(40, 20)
		Me.TextBoxAvgRadiusFalloff.TabIndex = 17
		Me.TextBoxAvgRadiusFalloff.Text = "2"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Location = New System.Drawing.Point(8, 44)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(77, 13)
		Me.Label11.TabIndex = 16
		Me.Label11.Text = "Radius Weight"
		'
		'TextBoxAvgRadiusWeight
		'
		Me.TextBoxAvgRadiusWeight.Location = New System.Drawing.Point(112, 40)
		Me.TextBoxAvgRadiusWeight.Name = "TextBoxAvgRadiusWeight"
		Me.TextBoxAvgRadiusWeight.Size = New System.Drawing.Size(40, 20)
		Me.TextBoxAvgRadiusWeight.TabIndex = 15
		Me.TextBoxAvgRadiusWeight.Text = "4"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(8, 20)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(40, 13)
		Me.Label10.TabIndex = 14
		Me.Label10.Text = "Radius"
		'
		'TextBoxAvgRadius
		'
		Me.TextBoxAvgRadius.Location = New System.Drawing.Point(112, 16)
		Me.TextBoxAvgRadius.Name = "TextBoxAvgRadius"
		Me.TextBoxAvgRadius.Size = New System.Drawing.Size(40, 20)
		Me.TextBoxAvgRadius.TabIndex = 13
		Me.TextBoxAvgRadius.Text = "1"
		'
		'ComboBoxColoringMethod
		'
		Me.ComboBoxColoringMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBoxColoringMethod.FormattingEnabled = True
		Me.ComboBoxColoringMethod.Location = New System.Drawing.Point(101, 13)
		Me.ComboBoxColoringMethod.Name = "ComboBoxColoringMethod"
		Me.ComboBoxColoringMethod.Size = New System.Drawing.Size(121, 21)
		Me.ComboBoxColoringMethod.TabIndex = 11
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(8, 16)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(83, 13)
		Me.Label7.TabIndex = 12
		Me.Label7.Text = "Coloring method"
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.Label15)
		Me.GroupBox4.Controls.Add(Me.TextBoxVerticalAspect)
		Me.GroupBox4.Controls.Add(Me.CheckBoxTwoHanded)
		Me.GroupBox4.Controls.Add(Me.Label1)
		Me.GroupBox4.Controls.Add(Me.CheckBoxHorizontal)
		Me.GroupBox4.Controls.Add(Me.TextBoxScalingFactor)
		Me.GroupBox4.Location = New System.Drawing.Point(8, 16)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(240, 64)
		Me.GroupBox4.TabIndex = 15
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "Transformation"
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.Location = New System.Drawing.Point(96, 43)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(94, 13)
		Me.Label15.TabIndex = 14
		Me.Label15.Text = "Vertical aspect (%)"
		'
		'TextBoxVerticalAspect
		'
		Me.TextBoxVerticalAspect.Location = New System.Drawing.Point(192, 40)
		Me.TextBoxVerticalAspect.Name = "TextBoxVerticalAspect"
		Me.TextBoxVerticalAspect.Size = New System.Drawing.Size(40, 20)
		Me.TextBoxVerticalAspect.TabIndex = 15
		Me.TextBoxVerticalAspect.Text = "85"
		'
		'CheckBoxTwoHanded
		'
		Me.CheckBoxTwoHanded.AutoSize = True
		Me.CheckBoxTwoHanded.Location = New System.Drawing.Point(8, 16)
		Me.CheckBoxTwoHanded.Name = "CheckBoxTwoHanded"
		Me.CheckBoxTwoHanded.Size = New System.Drawing.Size(86, 17)
		Me.CheckBoxTwoHanded.TabIndex = 0
		Me.CheckBoxTwoHanded.Text = "Two handed"
		Me.CheckBoxTwoHanded.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(136, 20)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(51, 13)
		Me.Label1.TabIndex = 9
		Me.Label1.Text = "Scale (%)"
		'
		'CheckBoxHorizontal
		'
		Me.CheckBoxHorizontal.AutoSize = True
		Me.CheckBoxHorizontal.Location = New System.Drawing.Point(8, 40)
		Me.CheckBoxHorizontal.Name = "CheckBoxHorizontal"
		Me.CheckBoxHorizontal.Size = New System.Drawing.Size(73, 17)
		Me.CheckBoxHorizontal.TabIndex = 13
		Me.CheckBoxHorizontal.Text = "Horizontal"
		Me.CheckBoxHorizontal.UseVisualStyleBackColor = True
		'
		'TextBoxScalingFactor
		'
		Me.TextBoxScalingFactor.Location = New System.Drawing.Point(192, 16)
		Me.TextBoxScalingFactor.Name = "TextBoxScalingFactor"
		Me.TextBoxScalingFactor.Size = New System.Drawing.Size(40, 20)
		Me.TextBoxScalingFactor.TabIndex = 10
		Me.TextBoxScalingFactor.Text = "35"
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.CheckBoxMaskHand)
		Me.GroupBox3.Controls.Add(Me.Label8)
		Me.GroupBox3.Controls.Add(Me.Label9)
		Me.GroupBox3.Controls.Add(Me.TextBoxHandSize)
		Me.GroupBox3.Location = New System.Drawing.Point(8, 88)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(240, 72)
		Me.GroupBox3.TabIndex = 14
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "Masking"
		'
		'CheckBoxMaskHand
		'
		Me.CheckBoxMaskHand.AutoSize = True
		Me.CheckBoxMaskHand.Location = New System.Drawing.Point(8, 16)
		Me.CheckBoxMaskHand.Name = "CheckBoxMaskHand"
		Me.CheckBoxMaskHand.Size = New System.Drawing.Size(79, 17)
		Me.CheckBoxMaskHand.TabIndex = 12
		Me.CheckBoxMaskHand.Text = "Mask hand"
		Me.CheckBoxMaskHand.UseVisualStyleBackColor = True
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(88, 43)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(18, 13)
		Me.Label8.TabIndex = 13
		Me.Label8.Text = "px"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(8, 43)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(54, 13)
		Me.Label9.TabIndex = 12
		Me.Label9.Text = "Hand size"
		'
		'TextBoxHandSize
		'
		Me.TextBoxHandSize.Location = New System.Drawing.Point(64, 40)
		Me.TextBoxHandSize.Name = "TextBoxHandSize"
		Me.TextBoxHandSize.Size = New System.Drawing.Size(24, 20)
		Me.TextBoxHandSize.TabIndex = 11
		Me.TextBoxHandSize.Text = "2"
		'
		'GroupBox7
		'
		Me.GroupBox7.Controls.Add(Me.ButtonExportFloorObTFTDPalette)
		Me.GroupBox7.Controls.Add(Me.ButtonExportFloorObUFOPalette)
		Me.GroupBox7.Controls.Add(Me.ButtonExportFloorOb)
		Me.GroupBox7.Controls.Add(Me.ImageDestinationFloorOb)
		Me.GroupBox7.Controls.Add(Me.GroupBox8)
		Me.GroupBox7.Location = New System.Drawing.Point(136, 360)
		Me.GroupBox7.Name = "GroupBox7"
		Me.GroupBox7.Size = New System.Drawing.Size(232, 144)
		Me.GroupBox7.TabIndex = 12
		Me.GroupBox7.TabStop = False
		Me.GroupBox7.Text = "FloorOb"
		'
		'ButtonExportFloorObTFTDPalette
		'
		Me.ButtonExportFloorObTFTDPalette.Location = New System.Drawing.Point(72, 112)
		Me.ButtonExportFloorObTFTDPalette.Name = "ButtonExportFloorObTFTDPalette"
		Me.ButtonExportFloorObTFTDPalette.Size = New System.Drawing.Size(48, 24)
		Me.ButtonExportFloorObTFTDPalette.TabIndex = 21
		Me.ButtonExportFloorObTFTDPalette.Text = "TFTD"
		Me.ButtonExportFloorObTFTDPalette.UseVisualStyleBackColor = True
		'
		'ButtonExportFloorObUFOPalette
		'
		Me.ButtonExportFloorObUFOPalette.Location = New System.Drawing.Point(72, 88)
		Me.ButtonExportFloorObUFOPalette.Name = "ButtonExportFloorObUFOPalette"
		Me.ButtonExportFloorObUFOPalette.Size = New System.Drawing.Size(48, 24)
		Me.ButtonExportFloorObUFOPalette.TabIndex = 20
		Me.ButtonExportFloorObUFOPalette.Text = "UFO"
		Me.ButtonExportFloorObUFOPalette.UseVisualStyleBackColor = True
		'
		'ButtonExportFloorOb
		'
		Me.ButtonExportFloorOb.Location = New System.Drawing.Point(8, 88)
		Me.ButtonExportFloorOb.Name = "ButtonExportFloorOb"
		Me.ButtonExportFloorOb.Size = New System.Drawing.Size(56, 48)
		Me.ButtonExportFloorOb.TabIndex = 19
		Me.ButtonExportFloorOb.Text = "Export FloorOb"
		Me.ButtonExportFloorOb.UseVisualStyleBackColor = True
		'
		'ImageDestinationFloorOb
		'
		Me.ImageDestinationFloorOb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ImageDestinationFloorOb.Location = New System.Drawing.Point(128, 16)
		Me.ImageDestinationFloorOb.Name = "ImageDestinationFloorOb"
		Me.ImageDestinationFloorOb.Size = New System.Drawing.Size(96, 120)
		Me.ImageDestinationFloorOb.TabIndex = 18
		Me.ImageDestinationFloorOb.TabStop = False
		'
		'GroupBox8
		'
		Me.GroupBox8.Controls.Add(Me.CheckBoxFloorObHorizontal)
		Me.GroupBox8.Controls.Add(Me.Label14)
		Me.GroupBox8.Controls.Add(Me.TextBoxFloorObScale)
		Me.GroupBox8.Location = New System.Drawing.Point(8, 16)
		Me.GroupBox8.Name = "GroupBox8"
		Me.GroupBox8.Size = New System.Drawing.Size(112, 64)
		Me.GroupBox8.TabIndex = 16
		Me.GroupBox8.TabStop = False
		Me.GroupBox8.Text = "Transformation"
		'
		'CheckBoxFloorObHorizontal
		'
		Me.CheckBoxFloorObHorizontal.AutoSize = True
		Me.CheckBoxFloorObHorizontal.Checked = True
		Me.CheckBoxFloorObHorizontal.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CheckBoxFloorObHorizontal.Location = New System.Drawing.Point(8, 40)
		Me.CheckBoxFloorObHorizontal.Name = "CheckBoxFloorObHorizontal"
		Me.CheckBoxFloorObHorizontal.Size = New System.Drawing.Size(73, 17)
		Me.CheckBoxFloorObHorizontal.TabIndex = 14
		Me.CheckBoxFloorObHorizontal.Text = "Horizontal"
		Me.CheckBoxFloorObHorizontal.UseVisualStyleBackColor = True
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.Location = New System.Drawing.Point(8, 20)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(51, 13)
		Me.Label14.TabIndex = 9
		Me.Label14.Text = "Scale (%)"
		'
		'TextBoxFloorObScale
		'
		Me.TextBoxFloorObScale.Location = New System.Drawing.Point(64, 16)
		Me.TextBoxFloorObScale.Name = "TextBoxFloorObScale"
		Me.TextBoxFloorObScale.Size = New System.Drawing.Size(40, 20)
		Me.TextBoxFloorObScale.TabIndex = 10
		Me.TextBoxFloorObScale.Text = "35"
		'
		'CheckBoxDrawGrip
		'
		Me.CheckBoxDrawGrip.AutoSize = True
		Me.CheckBoxDrawGrip.Checked = True
		Me.CheckBoxDrawGrip.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CheckBoxDrawGrip.Location = New System.Drawing.Point(376, 360)
		Me.CheckBoxDrawGrip.Name = "CheckBoxDrawGrip"
		Me.CheckBoxDrawGrip.Size = New System.Drawing.Size(110, 17)
		Me.CheckBoxDrawGrip.TabIndex = 13
		Me.CheckBoxDrawGrip.Text = "Draw grip position"
		Me.CheckBoxDrawGrip.UseVisualStyleBackColor = True
		'
		'GroupBox9
		'
		Me.GroupBox9.Controls.Add(Me.Label16)
		Me.GroupBox9.Controls.Add(Me.ListBoxRecentFiles)
		Me.GroupBox9.Controls.Add(Me.ButtonLoadFile)
		Me.GroupBox9.Controls.Add(Me.ButtonSaveFile)
		Me.GroupBox9.Location = New System.Drawing.Point(640, 360)
		Me.GroupBox9.Name = "GroupBox9"
		Me.GroupBox9.Size = New System.Drawing.Size(280, 144)
		Me.GroupBox9.TabIndex = 14
		Me.GroupBox9.TabStop = False
		Me.GroupBox9.Text = "Files"
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(88, 16)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(63, 13)
		Me.Label16.TabIndex = 3
		Me.Label16.Text = "Recent files"
		'
		'ListBoxRecentFiles
		'
		Me.ListBoxRecentFiles.FormattingEnabled = True
		Me.ListBoxRecentFiles.Location = New System.Drawing.Point(88, 32)
		Me.ListBoxRecentFiles.Name = "ListBoxRecentFiles"
		Me.ListBoxRecentFiles.Size = New System.Drawing.Size(184, 108)
		Me.ListBoxRecentFiles.TabIndex = 2
		'
		'ButtonLoadFile
		'
		Me.ButtonLoadFile.Location = New System.Drawing.Point(8, 40)
		Me.ButtonLoadFile.Name = "ButtonLoadFile"
		Me.ButtonLoadFile.Size = New System.Drawing.Size(75, 23)
		Me.ButtonLoadFile.TabIndex = 1
		Me.ButtonLoadFile.Text = "Load"
		Me.ButtonLoadFile.UseVisualStyleBackColor = True
		'
		'ButtonSaveFile
		'
		Me.ButtonSaveFile.Location = New System.Drawing.Point(8, 16)
		Me.ButtonSaveFile.Name = "ButtonSaveFile"
		Me.ButtonSaveFile.Size = New System.Drawing.Size(75, 23)
		Me.ButtonSaveFile.TabIndex = 0
		Me.ButtonSaveFile.Text = "Save"
		Me.ButtonSaveFile.UseVisualStyleBackColor = True
		'
		'MainWindow
		'
		Me.AllowDrop = True
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(924, 509)
		Me.Controls.Add(Me.GroupBox9)
		Me.Controls.Add(Me.CheckBoxDrawGrip)
		Me.Controls.Add(Me.GroupBox7)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Name = "MainWindow"
		Me.Text = "HandOb Maker"
		CType(Me.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ImageDestinationHandOb, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.GroupBox10.ResumeLayout(False)
		Me.GroupBox10.PerformLayout()
		Me.GroupBox5.ResumeLayout(False)
		Me.GroupBox5.PerformLayout()
		Me.GroupBox6.ResumeLayout(False)
		Me.GroupBox6.PerformLayout()
		Me.GroupBox4.ResumeLayout(False)
		Me.GroupBox4.PerformLayout()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		Me.GroupBox7.ResumeLayout(False)
		CType(Me.ImageDestinationFloorOb, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox8.ResumeLayout(False)
		Me.GroupBox8.PerformLayout()
		Me.GroupBox9.ResumeLayout(False)
		Me.GroupBox9.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents ImageSource As PictureBox
    Friend WithEvents ButtonLoadSource As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxItemWidth As TextBox
    Friend WithEvents TextBoxItemHeight As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ImageDestinationHandOb As PictureBox
    Friend WithEvents ButtonExportHandOb As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBoxTwoHanded As CheckBox
    Friend WithEvents TextBoxScalingFactor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxThickness As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBoxColoringMethod As ComboBox
    Friend WithEvents CheckBoxHorizontal As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBoxHandSize As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CheckBoxMaskHand As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TextBoxAvgRadius As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxAvgRadiusFalloff As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBoxAvgRadiusWeight As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxAvgTransparencyCutoff As TextBox
    Friend WithEvents CheckBoxOverrideMask3 As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents ImageDestinationFloorOb As PictureBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBoxFloorObScale As TextBox
    Friend WithEvents CheckBoxFloorObHorizontal As CheckBox
    Friend WithEvents ButtonExportFloorOb As Button
    Friend WithEvents ButtonFlip As Button
    Friend WithEvents ButtonMirror As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents TextBoxVerticalAspect As TextBox
    Friend WithEvents CheckBoxShadedCenterline As CheckBox
    Friend WithEvents ButtonFindCenter As Button
    Friend WithEvents CheckBoxDrawGrip As CheckBox
    Friend WithEvents ButtonOpenDetails As Button
    Friend WithEvents ButtonReloadSourceImage As Button
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents ListBoxRecentFiles As ListBox
    Friend WithEvents ButtonLoadFile As Button
    Friend WithEvents ButtonSaveFile As Button
	Friend WithEvents ButtonSendToUnitSpriteStudio As Button
	Friend WithEvents GroupBox10 As GroupBox
	Friend WithEvents CheckBoxSendToUnitSpriteStudio As CheckBox
	Friend WithEvents ButtonExportHandObXComPalette As Button
	Friend WithEvents ButtonExportHandObTFTDPalette As Button
	Friend WithEvents ButtonExportFloorObTFTDPalette As Button
	Friend WithEvents ButtonExportFloorObUFOPalette As Button
End Class
