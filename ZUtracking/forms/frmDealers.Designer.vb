<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDealers
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDealers))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gboxGeneralData = New System.Windows.Forms.GroupBox()
        Me.btnMotionAlert = New ZUControls.ZUButton()
        Me.btnIgnitionAlert = New ZUControls.ZUButton()
        Me.btnGeofenceAlert = New ZUControls.ZUButton()
        Me.btnSpeedAlert = New ZUControls.ZUButton()
        Me.btnBatteryAlert = New ZUControls.ZUButton()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cboxStatus = New System.Windows.Forms.CheckBox()
        Me.btnRemoveImage = New ZUControls.ZUButton()
        Me.btnAddImage = New ZUControls.ZUButton()
        Me.pboxLogo = New System.Windows.Forms.PictureBox()
        Me.txtWebSite = New ZUControls.ZUTextBox()
        Me.txtEmail = New ZUControls.ZUTextBox()
        Me.txtAddress = New ZUControls.ZUTextBox()
        Me.txtContact = New ZUControls.ZUTextBox()
        Me.txtName = New ZUControls.ZUTextBox()
        Me.txtPhoneNumber2 = New ZUControls.ZUNumericBox()
        Me.txtPhoneNumber1 = New ZUControls.ZUNumericBox()
        Me.txtDni = New ZUControls.ZUNumericBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelDealer = New ZUControls.ZUButton()
        Me.btnDeleteDealer = New ZUControls.ZUButton()
        Me.btnSaveDealer = New ZUControls.ZUButton()
        Me.btnEditDealer = New ZUControls.ZUButton()
        Me.btnNewDealer = New ZUControls.ZUButton()
        Me.dgvDealers = New ZUControls.ZUDataGridView()
        Me.dgvDealers_dni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_contact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_phone_number1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_phone_number2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_web_site = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_battery_alert = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_speed_alert = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_geofence_alert = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_ignition_alert = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_motion_alert = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_image = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDealers_dealer_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bgwSavingDealers = New System.ComponentModel.BackgroundWorker()
        Me.bgwDeletingDealers = New System.ComponentModel.BackgroundWorker()
        Me.panelButtons = New ZUControls.ZUPanel()
        Me.ofdLogo = New System.Windows.Forms.OpenFileDialog()
        Me.panelLoadingDealers = New ZUControls.ZUPanel()
        Me.lblLoadingDealers = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gboxGeneralData.SuspendLayout()
        CType(Me.pboxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDealers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelButtons.SuspendLayout()
        Me.panelLoadingDealers.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gboxGeneralData
        '
        Me.gboxGeneralData.Controls.Add(Me.btnMotionAlert)
        Me.gboxGeneralData.Controls.Add(Me.btnIgnitionAlert)
        Me.gboxGeneralData.Controls.Add(Me.btnGeofenceAlert)
        Me.gboxGeneralData.Controls.Add(Me.btnSpeedAlert)
        Me.gboxGeneralData.Controls.Add(Me.btnBatteryAlert)
        Me.gboxGeneralData.Controls.Add(Me.lblStatus)
        Me.gboxGeneralData.Controls.Add(Me.cboxStatus)
        Me.gboxGeneralData.Controls.Add(Me.btnRemoveImage)
        Me.gboxGeneralData.Controls.Add(Me.btnAddImage)
        Me.gboxGeneralData.Controls.Add(Me.pboxLogo)
        Me.gboxGeneralData.Controls.Add(Me.txtWebSite)
        Me.gboxGeneralData.Controls.Add(Me.txtEmail)
        Me.gboxGeneralData.Controls.Add(Me.txtAddress)
        Me.gboxGeneralData.Controls.Add(Me.txtContact)
        Me.gboxGeneralData.Controls.Add(Me.txtName)
        Me.gboxGeneralData.Controls.Add(Me.txtPhoneNumber2)
        Me.gboxGeneralData.Controls.Add(Me.txtPhoneNumber1)
        Me.gboxGeneralData.Controls.Add(Me.txtDni)
        Me.gboxGeneralData.Controls.Add(Me.Label5)
        Me.gboxGeneralData.Controls.Add(Me.Label8)
        Me.gboxGeneralData.Controls.Add(Me.Label7)
        Me.gboxGeneralData.Controls.Add(Me.Label6)
        Me.gboxGeneralData.Controls.Add(Me.Label4)
        Me.gboxGeneralData.Controls.Add(Me.Label3)
        Me.gboxGeneralData.Controls.Add(Me.Label2)
        Me.gboxGeneralData.Controls.Add(Me.Label1)
        Me.gboxGeneralData.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxGeneralData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxGeneralData.Location = New System.Drawing.Point(0, 0)
        Me.gboxGeneralData.Name = "gboxGeneralData"
        Me.gboxGeneralData.Size = New System.Drawing.Size(632, 282)
        Me.gboxGeneralData.TabIndex = 0
        Me.gboxGeneralData.TabStop = False
        Me.gboxGeneralData.Text = "Datos Generales"
        '
        'btnMotionAlert
        '
        Me.btnMotionAlert.BackColor = System.Drawing.Color.Transparent
        Me.btnMotionAlert.BackgroundImage = CType(resources.GetObject("btnMotionAlert.BackgroundImage"), System.Drawing.Image)
        Me.btnMotionAlert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMotionAlert.BackgroundOnClick = CType(resources.GetObject("btnMotionAlert.BackgroundOnClick"), System.Drawing.Image)
        Me.btnMotionAlert.BackgroundOnDisabled = CType(resources.GetObject("btnMotionAlert.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnMotionAlert.BackgroundOnHover = CType(resources.GetObject("btnMotionAlert.BackgroundOnHover"), System.Drawing.Image)
        Me.btnMotionAlert.BackgroundOnNormal = CType(resources.GetObject("btnMotionAlert.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnMotionAlert.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnMotionAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnMotionAlert.Enabled = False
        Me.btnMotionAlert.FlatAppearance.BorderSize = 0
        Me.btnMotionAlert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnMotionAlert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnMotionAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMotionAlert.ForeColor = System.Drawing.Color.Black
        Me.btnMotionAlert.Location = New System.Drawing.Point(515, 243)
        Me.btnMotionAlert.Name = "btnMotionAlert"
        Me.btnMotionAlert.Size = New System.Drawing.Size(109, 35)
        Me.btnMotionAlert.TabIndex = 16
        Me.btnMotionAlert.Text = "Alertas de Movimiento"
        Me.btnMotionAlert.UseVisualStyleBackColor = False
        '
        'btnIgnitionAlert
        '
        Me.btnIgnitionAlert.BackColor = System.Drawing.Color.Transparent
        Me.btnIgnitionAlert.BackgroundImage = CType(resources.GetObject("btnIgnitionAlert.BackgroundImage"), System.Drawing.Image)
        Me.btnIgnitionAlert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIgnitionAlert.BackgroundOnClick = CType(resources.GetObject("btnIgnitionAlert.BackgroundOnClick"), System.Drawing.Image)
        Me.btnIgnitionAlert.BackgroundOnDisabled = CType(resources.GetObject("btnIgnitionAlert.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnIgnitionAlert.BackgroundOnHover = CType(resources.GetObject("btnIgnitionAlert.BackgroundOnHover"), System.Drawing.Image)
        Me.btnIgnitionAlert.BackgroundOnNormal = CType(resources.GetObject("btnIgnitionAlert.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnIgnitionAlert.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnIgnitionAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnIgnitionAlert.Enabled = False
        Me.btnIgnitionAlert.FlatAppearance.BorderSize = 0
        Me.btnIgnitionAlert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnIgnitionAlert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnIgnitionAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnitionAlert.ForeColor = System.Drawing.Color.Black
        Me.btnIgnitionAlert.Location = New System.Drawing.Point(390, 243)
        Me.btnIgnitionAlert.Name = "btnIgnitionAlert"
        Me.btnIgnitionAlert.Size = New System.Drawing.Size(109, 35)
        Me.btnIgnitionAlert.TabIndex = 15
        Me.btnIgnitionAlert.Text = "Alertas de Ignicion"
        Me.btnIgnitionAlert.UseVisualStyleBackColor = False
        '
        'btnGeofenceAlert
        '
        Me.btnGeofenceAlert.BackColor = System.Drawing.Color.Transparent
        Me.btnGeofenceAlert.BackgroundImage = CType(resources.GetObject("btnGeofenceAlert.BackgroundImage"), System.Drawing.Image)
        Me.btnGeofenceAlert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGeofenceAlert.BackgroundOnClick = CType(resources.GetObject("btnGeofenceAlert.BackgroundOnClick"), System.Drawing.Image)
        Me.btnGeofenceAlert.BackgroundOnDisabled = CType(resources.GetObject("btnGeofenceAlert.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnGeofenceAlert.BackgroundOnHover = CType(resources.GetObject("btnGeofenceAlert.BackgroundOnHover"), System.Drawing.Image)
        Me.btnGeofenceAlert.BackgroundOnNormal = CType(resources.GetObject("btnGeofenceAlert.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnGeofenceAlert.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnGeofenceAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnGeofenceAlert.Enabled = False
        Me.btnGeofenceAlert.FlatAppearance.BorderSize = 0
        Me.btnGeofenceAlert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnGeofenceAlert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnGeofenceAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGeofenceAlert.ForeColor = System.Drawing.Color.Black
        Me.btnGeofenceAlert.Location = New System.Drawing.Point(265, 243)
        Me.btnGeofenceAlert.Name = "btnGeofenceAlert"
        Me.btnGeofenceAlert.Size = New System.Drawing.Size(109, 35)
        Me.btnGeofenceAlert.TabIndex = 14
        Me.btnGeofenceAlert.Text = "Alertas de Geocerca"
        Me.btnGeofenceAlert.UseVisualStyleBackColor = False
        '
        'btnSpeedAlert
        '
        Me.btnSpeedAlert.BackColor = System.Drawing.Color.Transparent
        Me.btnSpeedAlert.BackgroundImage = CType(resources.GetObject("btnSpeedAlert.BackgroundImage"), System.Drawing.Image)
        Me.btnSpeedAlert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSpeedAlert.BackgroundOnClick = CType(resources.GetObject("btnSpeedAlert.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSpeedAlert.BackgroundOnDisabled = CType(resources.GetObject("btnSpeedAlert.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSpeedAlert.BackgroundOnHover = CType(resources.GetObject("btnSpeedAlert.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSpeedAlert.BackgroundOnNormal = CType(resources.GetObject("btnSpeedAlert.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSpeedAlert.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSpeedAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnSpeedAlert.Enabled = False
        Me.btnSpeedAlert.FlatAppearance.BorderSize = 0
        Me.btnSpeedAlert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSpeedAlert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSpeedAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSpeedAlert.ForeColor = System.Drawing.Color.Black
        Me.btnSpeedAlert.Location = New System.Drawing.Point(140, 243)
        Me.btnSpeedAlert.Name = "btnSpeedAlert"
        Me.btnSpeedAlert.Size = New System.Drawing.Size(109, 35)
        Me.btnSpeedAlert.TabIndex = 13
        Me.btnSpeedAlert.Text = "Alertas de Velocidad"
        Me.btnSpeedAlert.UseVisualStyleBackColor = False
        '
        'btnBatteryAlert
        '
        Me.btnBatteryAlert.BackColor = System.Drawing.Color.Transparent
        Me.btnBatteryAlert.BackgroundImage = CType(resources.GetObject("btnBatteryAlert.BackgroundImage"), System.Drawing.Image)
        Me.btnBatteryAlert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBatteryAlert.BackgroundOnClick = CType(resources.GetObject("btnBatteryAlert.BackgroundOnClick"), System.Drawing.Image)
        Me.btnBatteryAlert.BackgroundOnDisabled = CType(resources.GetObject("btnBatteryAlert.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnBatteryAlert.BackgroundOnHover = CType(resources.GetObject("btnBatteryAlert.BackgroundOnHover"), System.Drawing.Image)
        Me.btnBatteryAlert.BackgroundOnNormal = CType(resources.GetObject("btnBatteryAlert.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnBatteryAlert.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnBatteryAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnBatteryAlert.Enabled = False
        Me.btnBatteryAlert.FlatAppearance.BorderSize = 0
        Me.btnBatteryAlert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBatteryAlert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBatteryAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBatteryAlert.ForeColor = System.Drawing.Color.Black
        Me.btnBatteryAlert.Location = New System.Drawing.Point(15, 243)
        Me.btnBatteryAlert.Name = "btnBatteryAlert"
        Me.btnBatteryAlert.Size = New System.Drawing.Size(109, 35)
        Me.btnBatteryAlert.TabIndex = 12
        Me.btnBatteryAlert.Text = "Alertas de Batería"
        Me.btnBatteryAlert.UseVisualStyleBackColor = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.LightCoral
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(86, 213)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(350, 18)
        Me.lblStatus.TabIndex = 9
        '
        'cboxStatus
        '
        Me.cboxStatus.AutoSize = True
        Me.cboxStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cboxStatus.Enabled = False
        Me.cboxStatus.ForeColor = System.Drawing.Color.Black
        Me.cboxStatus.Location = New System.Drawing.Point(12, 214)
        Me.cboxStatus.Name = "cboxStatus"
        Me.cboxStatus.Size = New System.Drawing.Size(65, 17)
        Me.cboxStatus.TabIndex = 8
        Me.cboxStatus.Text = "Estado"
        Me.cboxStatus.UseVisualStyleBackColor = True
        '
        'btnRemoveImage
        '
        Me.btnRemoveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveImage.BackColor = System.Drawing.Color.Transparent
        Me.btnRemoveImage.BackgroundImage = CType(resources.GetObject("btnRemoveImage.BackgroundImage"), System.Drawing.Image)
        Me.btnRemoveImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRemoveImage.BackgroundOnClick = CType(resources.GetObject("btnRemoveImage.BackgroundOnClick"), System.Drawing.Image)
        Me.btnRemoveImage.BackgroundOnDisabled = CType(resources.GetObject("btnRemoveImage.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnRemoveImage.BackgroundOnHover = CType(resources.GetObject("btnRemoveImage.BackgroundOnHover"), System.Drawing.Image)
        Me.btnRemoveImage.BackgroundOnNormal = CType(resources.GetObject("btnRemoveImage.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnRemoveImage.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnRemoveImage.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnRemoveImage.Enabled = False
        Me.btnRemoveImage.FlatAppearance.BorderSize = 0
        Me.btnRemoveImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRemoveImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRemoveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveImage.ForeColor = System.Drawing.Color.Black
        Me.btnRemoveImage.Location = New System.Drawing.Point(551, 195)
        Me.btnRemoveImage.Name = "btnRemoveImage"
        Me.btnRemoveImage.Size = New System.Drawing.Size(75, 39)
        Me.btnRemoveImage.TabIndex = 11
        Me.btnRemoveImage.Text = "Quitar Imagen"
        Me.btnRemoveImage.UseVisualStyleBackColor = False
        '
        'btnAddImage
        '
        Me.btnAddImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddImage.BackColor = System.Drawing.Color.Transparent
        Me.btnAddImage.BackgroundImage = CType(resources.GetObject("btnAddImage.BackgroundImage"), System.Drawing.Image)
        Me.btnAddImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddImage.BackgroundOnClick = CType(resources.GetObject("btnAddImage.BackgroundOnClick"), System.Drawing.Image)
        Me.btnAddImage.BackgroundOnDisabled = CType(resources.GetObject("btnAddImage.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnAddImage.BackgroundOnHover = CType(resources.GetObject("btnAddImage.BackgroundOnHover"), System.Drawing.Image)
        Me.btnAddImage.BackgroundOnNormal = CType(resources.GetObject("btnAddImage.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnAddImage.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnAddImage.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        Me.btnAddImage.Enabled = False
        Me.btnAddImage.FlatAppearance.BorderSize = 0
        Me.btnAddImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAddImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddImage.ForeColor = System.Drawing.Color.Black
        Me.btnAddImage.Location = New System.Drawing.Point(442, 195)
        Me.btnAddImage.Name = "btnAddImage"
        Me.btnAddImage.Size = New System.Drawing.Size(75, 39)
        Me.btnAddImage.TabIndex = 10
        Me.btnAddImage.Text = "Agregar Imagen"
        Me.btnAddImage.UseVisualStyleBackColor = False
        '
        'pboxLogo
        '
        Me.pboxLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pboxLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pboxLogo.Location = New System.Drawing.Point(442, 12)
        Me.pboxLogo.Name = "pboxLogo"
        Me.pboxLogo.Size = New System.Drawing.Size(184, 177)
        Me.pboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxLogo.TabIndex = 27
        Me.pboxLogo.TabStop = False
        '
        'txtWebSite
        '
        Me.txtWebSite.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtWebSite.Enabled = False
        Me.txtWebSite.ForeColor = System.Drawing.Color.Black
        Me.txtWebSite.HintText = "Hint Text"
        Me.txtWebSite.HintTextColor = System.Drawing.Color.Gray
        Me.txtWebSite.HintTextEnabled = False
        Me.txtWebSite.Location = New System.Drawing.Point(80, 185)
        Me.txtWebSite.MaxLength = 50
        Me.txtWebSite.Name = "txtWebSite"
        Me.txtWebSite.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtWebSite.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtWebSite.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtWebSite.Size = New System.Drawing.Size(356, 20)
        Me.txtWebSite.TabIndex = 7
        '
        'txtEmail
        '
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtEmail.Enabled = False
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.HintText = "Hint Text"
        Me.txtEmail.HintTextColor = System.Drawing.Color.Gray
        Me.txtEmail.HintTextEnabled = False
        Me.txtEmail.Location = New System.Drawing.Point(130, 157)
        Me.txtEmail.MaxLength = 150
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtEmail.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtEmail.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtEmail.Size = New System.Drawing.Size(306, 20)
        Me.txtEmail.TabIndex = 6
        '
        'txtAddress
        '
        Me.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress.Enabled = False
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.HintText = "Hint Text"
        Me.txtAddress.HintTextColor = System.Drawing.Color.Gray
        Me.txtAddress.HintTextEnabled = False
        Me.txtAddress.Location = New System.Drawing.Point(79, 129)
        Me.txtAddress.MaxLength = 200
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtAddress.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtAddress.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtAddress.Size = New System.Drawing.Size(357, 20)
        Me.txtAddress.TabIndex = 5
        '
        'txtContact
        '
        Me.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContact.Enabled = False
        Me.txtContact.ForeColor = System.Drawing.Color.Black
        Me.txtContact.HintText = "Hint Text"
        Me.txtContact.HintTextColor = System.Drawing.Color.Gray
        Me.txtContact.HintTextEnabled = False
        Me.txtContact.Location = New System.Drawing.Point(144, 73)
        Me.txtContact.MaxLength = 100
        Me.txtContact.Name = "txtContact"
        Me.txtContact.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtContact.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtContact.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtContact.Size = New System.Drawing.Size(292, 20)
        Me.txtContact.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Enabled = False
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.HintText = "Hint Text"
        Me.txtName.HintTextColor = System.Drawing.Color.Gray
        Me.txtName.HintTextEnabled = False
        Me.txtName.Location = New System.Drawing.Point(157, 45)
        Me.txtName.MaxLength = 100
        Me.txtName.Name = "txtName"
        Me.txtName.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtName.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtName.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtName.Size = New System.Drawing.Size(279, 20)
        Me.txtName.TabIndex = 1
        '
        'txtPhoneNumber2
        '
        Me.txtPhoneNumber2.CaracterDecimal = False
        Me.txtPhoneNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhoneNumber2.Enabled = False
        Me.txtPhoneNumber2.ForeColor = System.Drawing.Color.Black
        Me.txtPhoneNumber2.HintText = "Hint Text"
        Me.txtPhoneNumber2.HintTextColor = System.Drawing.Color.Gray
        Me.txtPhoneNumber2.HintTextEnabled = False
        Me.txtPhoneNumber2.Location = New System.Drawing.Point(299, 101)
        Me.txtPhoneNumber2.MaxLength = 15
        Me.txtPhoneNumber2.Name = "txtPhoneNumber2"
        Me.txtPhoneNumber2.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtPhoneNumber2.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtPhoneNumber2.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtPhoneNumber2.Size = New System.Drawing.Size(137, 20)
        Me.txtPhoneNumber2.TabIndex = 4
        '
        'txtPhoneNumber1
        '
        Me.txtPhoneNumber1.CaracterDecimal = False
        Me.txtPhoneNumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhoneNumber1.Enabled = False
        Me.txtPhoneNumber1.ForeColor = System.Drawing.Color.Black
        Me.txtPhoneNumber1.HintText = "Hint Text"
        Me.txtPhoneNumber1.HintTextColor = System.Drawing.Color.Gray
        Me.txtPhoneNumber1.HintTextEnabled = False
        Me.txtPhoneNumber1.Location = New System.Drawing.Point(86, 101)
        Me.txtPhoneNumber1.MaxLength = 15
        Me.txtPhoneNumber1.Name = "txtPhoneNumber1"
        Me.txtPhoneNumber1.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtPhoneNumber1.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtPhoneNumber1.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtPhoneNumber1.Size = New System.Drawing.Size(133, 20)
        Me.txtPhoneNumber1.TabIndex = 3
        '
        'txtDni
        '
        Me.txtDni.CaracterDecimal = False
        Me.txtDni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDni.Enabled = False
        Me.txtDni.ForeColor = System.Drawing.Color.Black
        Me.txtDni.HintText = "Hint Text"
        Me.txtDni.HintTextColor = System.Drawing.Color.Gray
        Me.txtDni.HintTextEnabled = False
        Me.txtDni.Location = New System.Drawing.Point(94, 17)
        Me.txtDni.MaxLength = 10
        Me.txtDni.Name = "txtDni"
        Me.txtDni.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtDni.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtDni.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtDni.Size = New System.Drawing.Size(342, 20)
        Me.txtDni.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(228, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Teléfono 2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(12, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Sitio Web"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(12, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Correo Electrónico"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Dirección"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Teléfono 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Persona de Contacto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre / Razón Social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cédula / Rif"
        '
        'btnCancelDealer
        '
        Me.btnCancelDealer.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelDealer.BackgroundImage = CType(resources.GetObject("btnCancelDealer.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelDealer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelDealer.BackgroundOnClick = CType(resources.GetObject("btnCancelDealer.BackgroundOnClick"), System.Drawing.Image)
        Me.btnCancelDealer.BackgroundOnDisabled = CType(resources.GetObject("btnCancelDealer.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnCancelDealer.BackgroundOnHover = CType(resources.GetObject("btnCancelDealer.BackgroundOnHover"), System.Drawing.Image)
        Me.btnCancelDealer.BackgroundOnNormal = CType(resources.GetObject("btnCancelDealer.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnCancelDealer.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnCancelDealer.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnCancelDealer.Enabled = False
        Me.btnCancelDealer.FlatAppearance.BorderSize = 0
        Me.btnCancelDealer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancelDealer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancelDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelDealer.ForeColor = System.Drawing.Color.Black
        Me.btnCancelDealer.Location = New System.Drawing.Point(474, 4)
        Me.btnCancelDealer.Name = "btnCancelDealer"
        Me.btnCancelDealer.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelDealer.TabIndex = 21
        Me.btnCancelDealer.Text = "Cancelar"
        Me.btnCancelDealer.UseVisualStyleBackColor = False
        '
        'btnDeleteDealer
        '
        Me.btnDeleteDealer.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteDealer.BackgroundImage = CType(resources.GetObject("btnDeleteDealer.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteDealer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteDealer.BackgroundOnClick = CType(resources.GetObject("btnDeleteDealer.BackgroundOnClick"), System.Drawing.Image)
        Me.btnDeleteDealer.BackgroundOnDisabled = CType(resources.GetObject("btnDeleteDealer.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnDeleteDealer.BackgroundOnHover = CType(resources.GetObject("btnDeleteDealer.BackgroundOnHover"), System.Drawing.Image)
        Me.btnDeleteDealer.BackgroundOnNormal = CType(resources.GetObject("btnDeleteDealer.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnDeleteDealer.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnDeleteDealer.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnDeleteDealer.Enabled = False
        Me.btnDeleteDealer.FlatAppearance.BorderSize = 0
        Me.btnDeleteDealer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteDealer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteDealer.ForeColor = System.Drawing.Color.Black
        Me.btnDeleteDealer.Location = New System.Drawing.Point(377, 4)
        Me.btnDeleteDealer.Name = "btnDeleteDealer"
        Me.btnDeleteDealer.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteDealer.TabIndex = 20
        Me.btnDeleteDealer.Text = "Eliminar"
        Me.btnDeleteDealer.UseVisualStyleBackColor = False
        '
        'btnSaveDealer
        '
        Me.btnSaveDealer.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveDealer.BackgroundImage = CType(resources.GetObject("btnSaveDealer.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveDealer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveDealer.BackgroundOnClick = CType(resources.GetObject("btnSaveDealer.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSaveDealer.BackgroundOnDisabled = CType(resources.GetObject("btnSaveDealer.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSaveDealer.BackgroundOnHover = CType(resources.GetObject("btnSaveDealer.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSaveDealer.BackgroundOnNormal = CType(resources.GetObject("btnSaveDealer.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSaveDealer.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSaveDealer.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnSaveDealer.Enabled = False
        Me.btnSaveDealer.FlatAppearance.BorderSize = 0
        Me.btnSaveDealer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSaveDealer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSaveDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveDealer.ForeColor = System.Drawing.Color.Black
        Me.btnSaveDealer.Location = New System.Drawing.Point(280, 4)
        Me.btnSaveDealer.Name = "btnSaveDealer"
        Me.btnSaveDealer.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveDealer.TabIndex = 19
        Me.btnSaveDealer.Text = "Guardar"
        Me.btnSaveDealer.UseVisualStyleBackColor = False
        '
        'btnEditDealer
        '
        Me.btnEditDealer.BackColor = System.Drawing.Color.Transparent
        Me.btnEditDealer.BackgroundImage = CType(resources.GetObject("btnEditDealer.BackgroundImage"), System.Drawing.Image)
        Me.btnEditDealer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditDealer.BackgroundOnClick = CType(resources.GetObject("btnEditDealer.BackgroundOnClick"), System.Drawing.Image)
        Me.btnEditDealer.BackgroundOnDisabled = CType(resources.GetObject("btnEditDealer.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnEditDealer.BackgroundOnHover = CType(resources.GetObject("btnEditDealer.BackgroundOnHover"), System.Drawing.Image)
        Me.btnEditDealer.BackgroundOnNormal = CType(resources.GetObject("btnEditDealer.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnEditDealer.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnEditDealer.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnEditDealer.Enabled = False
        Me.btnEditDealer.FlatAppearance.BorderSize = 0
        Me.btnEditDealer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnEditDealer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnEditDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditDealer.ForeColor = System.Drawing.Color.Black
        Me.btnEditDealer.Location = New System.Drawing.Point(183, 4)
        Me.btnEditDealer.Name = "btnEditDealer"
        Me.btnEditDealer.Size = New System.Drawing.Size(75, 23)
        Me.btnEditDealer.TabIndex = 18
        Me.btnEditDealer.Text = "Editar"
        Me.btnEditDealer.UseVisualStyleBackColor = False
        '
        'btnNewDealer
        '
        Me.btnNewDealer.BackColor = System.Drawing.Color.Transparent
        Me.btnNewDealer.BackgroundImage = CType(resources.GetObject("btnNewDealer.BackgroundImage"), System.Drawing.Image)
        Me.btnNewDealer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNewDealer.BackgroundOnClick = CType(resources.GetObject("btnNewDealer.BackgroundOnClick"), System.Drawing.Image)
        Me.btnNewDealer.BackgroundOnDisabled = CType(resources.GetObject("btnNewDealer.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnNewDealer.BackgroundOnHover = CType(resources.GetObject("btnNewDealer.BackgroundOnHover"), System.Drawing.Image)
        Me.btnNewDealer.BackgroundOnNormal = CType(resources.GetObject("btnNewDealer.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnNewDealer.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnNewDealer.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnNewDealer.FlatAppearance.BorderSize = 0
        Me.btnNewDealer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNewDealer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNewDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewDealer.ForeColor = System.Drawing.Color.Black
        Me.btnNewDealer.Location = New System.Drawing.Point(86, 4)
        Me.btnNewDealer.Name = "btnNewDealer"
        Me.btnNewDealer.Size = New System.Drawing.Size(75, 23)
        Me.btnNewDealer.TabIndex = 17
        Me.btnNewDealer.Text = "Nuevo"
        Me.btnNewDealer.UseVisualStyleBackColor = False
        '
        'dgvDealers
        '
        Me.dgvDealers.AllowUserToAddRows = False
        Me.dgvDealers.AllowUserToDeleteRows = False
        Me.dgvDealers.AllowUserToResizeColumns = False
        Me.dgvDealers.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        Me.dgvDealers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDealers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDealers.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvDealers.BackgroundHeader = CType(resources.GetObject("dgvDealers.BackgroundHeader"), System.Drawing.Image)
        Me.dgvDealers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDealers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDealers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDealers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDealers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDealers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvDealers_dni, Me.dgvDealers_name, Me.dgvDealers_contact, Me.dgvDealers_phone_number1, Me.dgvDealers_phone_number2, Me.dgvDealers_address, Me.dgvDealers_email, Me.dgvDealers_web_site, Me.dgvDealers_status, Me.dgvDealers_battery_alert, Me.dgvDealers_speed_alert, Me.dgvDealers_geofence_alert, Me.dgvDealers_ignition_alert, Me.dgvDealers_motion_alert, Me.dgvDealers_image, Me.dgvDealers_dealer_id})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDealers.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDealers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDealers.GridColor = System.Drawing.SystemColors.Control
        Me.dgvDealers.HeaderFontSize = 7.0!
        Me.dgvDealers.HeaderForeColor = System.Drawing.Color.White
        Me.dgvDealers.Location = New System.Drawing.Point(0, 314)
        Me.dgvDealers.MultiSelect = False
        Me.dgvDealers.Name = "dgvDealers"
        Me.dgvDealers.ReadOnly = True
        Me.dgvDealers.RowHeadersVisible = False
        Me.dgvDealers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDealers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDealers.Size = New System.Drawing.Size(632, 280)
        Me.dgvDealers.TabIndex = 1
        '
        'dgvDealers_dni
        '
        Me.dgvDealers_dni.HeaderText = "CÉDULA"
        Me.dgvDealers_dni.Name = "dgvDealers_dni"
        Me.dgvDealers_dni.ReadOnly = True
        Me.dgvDealers_dni.Width = 81
        '
        'dgvDealers_name
        '
        Me.dgvDealers_name.HeaderText = "NOMBRE"
        Me.dgvDealers_name.Name = "dgvDealers_name"
        Me.dgvDealers_name.ReadOnly = True
        Me.dgvDealers_name.Width = 85
        '
        'dgvDealers_contact
        '
        Me.dgvDealers_contact.HeaderText = "CONTACTO"
        Me.dgvDealers_contact.Name = "dgvDealers_contact"
        Me.dgvDealers_contact.ReadOnly = True
        Me.dgvDealers_contact.Width = 99
        '
        'dgvDealers_phone_number1
        '
        Me.dgvDealers_phone_number1.HeaderText = "TELÉFONO 1"
        Me.dgvDealers_phone_number1.Name = "dgvDealers_phone_number1"
        Me.dgvDealers_phone_number1.ReadOnly = True
        Me.dgvDealers_phone_number1.Width = 108
        '
        'dgvDealers_phone_number2
        '
        Me.dgvDealers_phone_number2.HeaderText = "TELÉFONO 2"
        Me.dgvDealers_phone_number2.Name = "dgvDealers_phone_number2"
        Me.dgvDealers_phone_number2.ReadOnly = True
        Me.dgvDealers_phone_number2.Width = 108
        '
        'dgvDealers_address
        '
        Me.dgvDealers_address.HeaderText = "DIRECCIÓN"
        Me.dgvDealers_address.Name = "dgvDealers_address"
        Me.dgvDealers_address.ReadOnly = True
        Me.dgvDealers_address.Visible = False
        '
        'dgvDealers_email
        '
        Me.dgvDealers_email.HeaderText = "CORREO ELECTRÓNICO"
        Me.dgvDealers_email.Name = "dgvDealers_email"
        Me.dgvDealers_email.ReadOnly = True
        Me.dgvDealers_email.Visible = False
        Me.dgvDealers_email.Width = 175
        '
        'dgvDealers_web_site
        '
        Me.dgvDealers_web_site.HeaderText = "SITIO WEB"
        Me.dgvDealers_web_site.Name = "dgvDealers_web_site"
        Me.dgvDealers_web_site.ReadOnly = True
        Me.dgvDealers_web_site.Visible = False
        Me.dgvDealers_web_site.Width = 97
        '
        'dgvDealers_status
        '
        Me.dgvDealers_status.HeaderText = "ESTADO"
        Me.dgvDealers_status.Name = "dgvDealers_status"
        Me.dgvDealers_status.ReadOnly = True
        Me.dgvDealers_status.Visible = False
        Me.dgvDealers_status.Width = 82
        '
        'dgvDealers_battery_alert
        '
        Me.dgvDealers_battery_alert.HeaderText = "ALERTAS DE BATERÍA"
        Me.dgvDealers_battery_alert.Name = "dgvDealers_battery_alert"
        Me.dgvDealers_battery_alert.ReadOnly = True
        Me.dgvDealers_battery_alert.Visible = False
        Me.dgvDealers_battery_alert.Width = 166
        '
        'dgvDealers_speed_alert
        '
        Me.dgvDealers_speed_alert.HeaderText = "ALERTAS DE VELOCIDAD"
        Me.dgvDealers_speed_alert.Name = "dgvDealers_speed_alert"
        Me.dgvDealers_speed_alert.ReadOnly = True
        Me.dgvDealers_speed_alert.Visible = False
        Me.dgvDealers_speed_alert.Width = 183
        '
        'dgvDealers_geofence_alert
        '
        Me.dgvDealers_geofence_alert.HeaderText = "ALERTAS DE GEOCERCA"
        Me.dgvDealers_geofence_alert.Name = "dgvDealers_geofence_alert"
        Me.dgvDealers_geofence_alert.ReadOnly = True
        Me.dgvDealers_geofence_alert.Visible = False
        Me.dgvDealers_geofence_alert.Width = 180
        '
        'dgvDealers_ignition_alert
        '
        Me.dgvDealers_ignition_alert.HeaderText = "ALERTAS DE IGNICIÓN"
        Me.dgvDealers_ignition_alert.Name = "dgvDealers_ignition_alert"
        Me.dgvDealers_ignition_alert.ReadOnly = True
        Me.dgvDealers_ignition_alert.Visible = False
        Me.dgvDealers_ignition_alert.Width = 169
        '
        'dgvDealers_motion_alert
        '
        Me.dgvDealers_motion_alert.HeaderText = "ALERTAS DE MOVIMIENTO"
        Me.dgvDealers_motion_alert.Name = "dgvDealers_motion_alert"
        Me.dgvDealers_motion_alert.ReadOnly = True
        Me.dgvDealers_motion_alert.Visible = False
        Me.dgvDealers_motion_alert.Width = 192
        '
        'dgvDealers_image
        '
        Me.dgvDealers_image.HeaderText = "IMAGEN"
        Me.dgvDealers_image.Name = "dgvDealers_image"
        Me.dgvDealers_image.ReadOnly = True
        Me.dgvDealers_image.Visible = False
        Me.dgvDealers_image.Width = 80
        '
        'dgvDealers_dealer_id
        '
        Me.dgvDealers_dealer_id.HeaderText = "ID DEALER"
        Me.dgvDealers_dealer_id.Name = "dgvDealers_dealer_id"
        Me.dgvDealers_dealer_id.ReadOnly = True
        Me.dgvDealers_dealer_id.Visible = False
        Me.dgvDealers_dealer_id.Width = 98
        '
        'bgwSavingDealers
        '
        Me.bgwSavingDealers.WorkerReportsProgress = True
        Me.bgwSavingDealers.WorkerSupportsCancellation = True
        '
        'bgwDeletingDealers
        '
        Me.bgwDeletingDealers.WorkerReportsProgress = True
        Me.bgwDeletingDealers.WorkerSupportsCancellation = True
        '
        'panelButtons
        '
        Me.panelButtons.Controls.Add(Me.btnCancelDealer)
        Me.panelButtons.Controls.Add(Me.btnNewDealer)
        Me.panelButtons.Controls.Add(Me.btnDeleteDealer)
        Me.panelButtons.Controls.Add(Me.btnEditDealer)
        Me.panelButtons.Controls.Add(Me.btnSaveDealer)
        Me.panelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelButtons.Location = New System.Drawing.Point(0, 282)
        Me.panelButtons.Name = "panelButtons"
        Me.panelButtons.Size = New System.Drawing.Size(632, 32)
        Me.panelButtons.TabIndex = 2
        '
        'ofdLogo
        '
        Me.ofdLogo.Title = "Seleccionar Logo del Dealer"
        '
        'panelLoadingDealers
        '
        Me.panelLoadingDealers.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelLoadingDealers.Controls.Add(Me.lblLoadingDealers)
        Me.panelLoadingDealers.Controls.Add(Me.PictureBox1)
        Me.panelLoadingDealers.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelLoadingDealers.Location = New System.Drawing.Point(0, 574)
        Me.panelLoadingDealers.Name = "panelLoadingDealers"
        Me.panelLoadingDealers.Size = New System.Drawing.Size(632, 20)
        Me.panelLoadingDealers.TabIndex = 19
        Me.panelLoadingDealers.Visible = False
        '
        'lblLoadingDealers
        '
        Me.lblLoadingDealers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoadingDealers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadingDealers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLoadingDealers.Location = New System.Drawing.Point(0, 0)
        Me.lblLoadingDealers.Name = "lblLoadingDealers"
        Me.lblLoadingDealers.Size = New System.Drawing.Size(602, 20)
        Me.lblLoadingDealers.TabIndex = 16
        Me.lblLoadingDealers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.ZUtracking.My.Resources.Resources.loading
        Me.PictureBox1.Location = New System.Drawing.Point(602, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'frmDealers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 594)
        Me.Controls.Add(Me.panelLoadingDealers)
        Me.Controls.Add(Me.dgvDealers)
        Me.Controls.Add(Me.panelButtons)
        Me.Controls.Add(Me.gboxGeneralData)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(648, 633)
        Me.Name = "frmDealers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DEALERS"
        Me.gboxGeneralData.ResumeLayout(False)
        Me.gboxGeneralData.PerformLayout()
        CType(Me.pboxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDealers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelButtons.ResumeLayout(False)
        Me.panelLoadingDealers.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gboxGeneralData As GroupBox
    Friend WithEvents txtName As ZUControls.ZUTextBox
    Friend WithEvents txtDni As ZUControls.ZUNumericBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnRemoveImage As ZUControls.ZUButton
    Friend WithEvents btnAddImage As ZUControls.ZUButton
    Friend WithEvents pboxLogo As PictureBox
    Friend WithEvents txtWebSite As ZUControls.ZUTextBox
    Friend WithEvents txtEmail As ZUControls.ZUTextBox
    Friend WithEvents txtAddress As ZUControls.ZUTextBox
    Friend WithEvents txtContact As ZUControls.ZUTextBox
    Friend WithEvents txtPhoneNumber2 As ZUControls.ZUNumericBox
    Friend WithEvents txtPhoneNumber1 As ZUControls.ZUNumericBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboxStatus As CheckBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnMotionAlert As ZUControls.ZUButton
    Friend WithEvents btnIgnitionAlert As ZUControls.ZUButton
    Friend WithEvents btnGeofenceAlert As ZUControls.ZUButton
    Friend WithEvents btnSpeedAlert As ZUControls.ZUButton
    Friend WithEvents btnBatteryAlert As ZUControls.ZUButton
    Friend WithEvents btnCancelDealer As ZUControls.ZUButton
    Friend WithEvents btnDeleteDealer As ZUControls.ZUButton
    Friend WithEvents btnSaveDealer As ZUControls.ZUButton
    Friend WithEvents btnEditDealer As ZUControls.ZUButton
    Friend WithEvents btnNewDealer As ZUControls.ZUButton
    Friend WithEvents dgvDealers As ZUControls.ZUDataGridView
    Friend WithEvents bgwSavingDealers As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwDeletingDealers As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvDealers_dni As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_contact As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_phone_number1 As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_phone_number2 As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_address As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_email As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_web_site As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_status As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_battery_alert As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_speed_alert As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_geofence_alert As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_ignition_alert As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_motion_alert As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_image As DataGridViewTextBoxColumn
    Friend WithEvents dgvDealers_dealer_id As DataGridViewTextBoxColumn
    Friend WithEvents panelButtons As ZUControls.ZUPanel
    Friend WithEvents ofdLogo As OpenFileDialog
    Friend WithEvents panelLoadingDealers As ZUControls.ZUPanel
    Friend WithEvents lblLoadingDealers As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
