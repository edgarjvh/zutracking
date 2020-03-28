<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDevices
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDevices))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gboxDeviceMaintaining = New System.Windows.Forms.GroupBox()
        Me.cboxMStatus = New System.Windows.Forms.CheckBox()
        Me.txtMObservations = New ZUControls.ZUTextBox()
        Me.cboMModels = New ZUControls.ZUComboBox()
        Me.rbtnDeviceMaintaining = New System.Windows.Forms.RadioButton()
        Me.btnCancelDevice = New ZUControls.ZUButton()
        Me.btnDeleteDevice = New ZUControls.ZUButton()
        Me.btnSaveDevice = New ZUControls.ZUButton()
        Me.btnEditDevice = New ZUControls.ZUButton()
        Me.btnNewDevice = New ZUControls.ZUButton()
        Me.txtMImei = New ZUControls.ZUNumericBox()
        Me.cboMSimCards = New ZUControls.ZUComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Labe59 = New System.Windows.Forms.Label()
        Me.gboxDeviceFiltering = New System.Windows.Forms.GroupBox()
        Me.txtFSerialPhone = New ZUControls.ZUNumericBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.panelAsignedDevice = New ZUControls.ZUPanel()
        Me.rbtnFAsignedYes = New System.Windows.Forms.RadioButton()
        Me.rbtnFAsignedNo = New System.Windows.Forms.RadioButton()
        Me.panelStatusDevice = New ZUControls.ZUPanel()
        Me.rbtnFActive = New System.Windows.Forms.RadioButton()
        Me.rbtnFInactive = New System.Windows.Forms.RadioButton()
        Me.btnExportExcel = New ZUControls.ZUButton()
        Me.btnSearchDevices = New ZUControls.ZUButton()
        Me.rbtnDeviceFiltering = New System.Windows.Forms.RadioButton()
        Me.cboxFAsigned = New System.Windows.Forms.CheckBox()
        Me.cboxFStatus = New System.Windows.Forms.CheckBox()
        Me.txtFImei = New ZUControls.ZUNumericBox()
        Me.cboxFImei = New System.Windows.Forms.CheckBox()
        Me.cboxFSimCard = New System.Windows.Forms.CheckBox()
        Me.bgwGetSimCards = New System.ComponentModel.BackgroundWorker()
        Me.bgwSaveDevice = New System.ComponentModel.BackgroundWorker()
        Me.bgwDeleteDevice = New System.ComponentModel.BackgroundWorker()
        Me.bgwSearchDevices = New System.ComponentModel.BackgroundWorker()
        Me.bgwExportExcel = New System.ComponentModel.BackgroundWorker()
        Me.panelLoading = New ZUControls.ZUPanel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.pboxLoading = New System.Windows.Forms.PictureBox()
        Me.dgvDevices = New ZUControls.ZUDataGridView()
        Me.dgvDevices_btn_config = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgvDevices_imei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_simcard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_phone_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_observations = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_device_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_simcard_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_device_model_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_sms_stop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_sms_resume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_gprs_stop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDevices_gprs_resume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gboxDeviceMaintaining.SuspendLayout()
        Me.gboxDeviceFiltering.SuspendLayout()
        Me.panelAsignedDevice.SuspendLayout()
        Me.panelStatusDevice.SuspendLayout()
        Me.panelLoading.SuspendLayout()
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gboxDeviceMaintaining
        '
        Me.gboxDeviceMaintaining.Controls.Add(Me.cboxMStatus)
        Me.gboxDeviceMaintaining.Controls.Add(Me.txtMObservations)
        Me.gboxDeviceMaintaining.Controls.Add(Me.cboMModels)
        Me.gboxDeviceMaintaining.Controls.Add(Me.rbtnDeviceMaintaining)
        Me.gboxDeviceMaintaining.Controls.Add(Me.btnCancelDevice)
        Me.gboxDeviceMaintaining.Controls.Add(Me.btnDeleteDevice)
        Me.gboxDeviceMaintaining.Controls.Add(Me.btnSaveDevice)
        Me.gboxDeviceMaintaining.Controls.Add(Me.btnEditDevice)
        Me.gboxDeviceMaintaining.Controls.Add(Me.btnNewDevice)
        Me.gboxDeviceMaintaining.Controls.Add(Me.txtMImei)
        Me.gboxDeviceMaintaining.Controls.Add(Me.cboMSimCards)
        Me.gboxDeviceMaintaining.Controls.Add(Me.Label1)
        Me.gboxDeviceMaintaining.Controls.Add(Me.Label4)
        Me.gboxDeviceMaintaining.Controls.Add(Me.Label2)
        Me.gboxDeviceMaintaining.Controls.Add(Me.Labe59)
        Me.gboxDeviceMaintaining.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxDeviceMaintaining.Location = New System.Drawing.Point(0, 0)
        Me.gboxDeviceMaintaining.Name = "gboxDeviceMaintaining"
        Me.gboxDeviceMaintaining.Size = New System.Drawing.Size(481, 142)
        Me.gboxDeviceMaintaining.TabIndex = 0
        Me.gboxDeviceMaintaining.TabStop = False
        '
        'cboxMStatus
        '
        Me.cboxMStatus.AutoSize = True
        Me.cboxMStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cboxMStatus.Enabled = False
        Me.cboxMStatus.Location = New System.Drawing.Point(405, 82)
        Me.cboxMStatus.Name = "cboxMStatus"
        Me.cboxMStatus.Size = New System.Drawing.Size(65, 17)
        Me.cboxMStatus.TabIndex = 5
        Me.cboxMStatus.Text = "Estado"
        Me.cboxMStatus.UseVisualStyleBackColor = True
        '
        'txtMObservations
        '
        Me.txtMObservations.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMObservations.Enabled = False
        Me.txtMObservations.HintText = "Hint Text"
        Me.txtMObservations.HintTextColor = System.Drawing.Color.Gray
        Me.txtMObservations.HintTextEnabled = False
        Me.txtMObservations.Location = New System.Drawing.Point(112, 80)
        Me.txtMObservations.Name = "txtMObservations"
        Me.txtMObservations.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtMObservations.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtMObservations.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtMObservations.Size = New System.Drawing.Size(286, 20)
        Me.txtMObservations.TabIndex = 4
        '
        'cboMModels
        '
        Me.cboMModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMModels.Enabled = False
        Me.cboMModels.FormattingEnabled = True
        Me.cboMModels.HintText = "Hint Text"
        Me.cboMModels.HintTextColor = System.Drawing.Color.Gray
        Me.cboMModels.HintTextEnabled = False
        Me.cboMModels.Location = New System.Drawing.Point(69, 54)
        Me.cboMModels.Name = "cboMModels"
        Me.cboMModels.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboMModels.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboMModels.Size = New System.Drawing.Size(181, 21)
        Me.cboMModels.TabIndex = 2
        '
        'rbtnDeviceMaintaining
        '
        Me.rbtnDeviceMaintaining.AutoSize = True
        Me.rbtnDeviceMaintaining.BackColor = System.Drawing.SystemColors.Control
        Me.rbtnDeviceMaintaining.Checked = True
        Me.rbtnDeviceMaintaining.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnDeviceMaintaining.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbtnDeviceMaintaining.Location = New System.Drawing.Point(10, 1)
        Me.rbtnDeviceMaintaining.Name = "rbtnDeviceMaintaining"
        Me.rbtnDeviceMaintaining.Size = New System.Drawing.Size(92, 17)
        Me.rbtnDeviceMaintaining.TabIndex = 0
        Me.rbtnDeviceMaintaining.TabStop = True
        Me.rbtnDeviceMaintaining.Text = "Mantenedor"
        Me.rbtnDeviceMaintaining.UseVisualStyleBackColor = False
        '
        'btnCancelDevice
        '
        Me.btnCancelDevice.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelDevice.BackgroundImage = CType(resources.GetObject("btnCancelDevice.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelDevice.BackgroundOnClick = CType(resources.GetObject("btnCancelDevice.BackgroundOnClick"), System.Drawing.Image)
        Me.btnCancelDevice.BackgroundOnDisabled = CType(resources.GetObject("btnCancelDevice.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnCancelDevice.BackgroundOnHover = CType(resources.GetObject("btnCancelDevice.BackgroundOnHover"), System.Drawing.Image)
        Me.btnCancelDevice.BackgroundOnNormal = CType(resources.GetObject("btnCancelDevice.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnCancelDevice.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnCancelDevice.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnCancelDevice.Enabled = False
        Me.btnCancelDevice.FlatAppearance.BorderSize = 0
        Me.btnCancelDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancelDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancelDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelDevice.Location = New System.Drawing.Point(399, 110)
        Me.btnCancelDevice.Name = "btnCancelDevice"
        Me.btnCancelDevice.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelDevice.TabIndex = 10
        Me.btnCancelDevice.Text = "Cancelar"
        Me.btnCancelDevice.UseVisualStyleBackColor = False
        '
        'btnDeleteDevice
        '
        Me.btnDeleteDevice.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteDevice.BackgroundImage = CType(resources.GetObject("btnDeleteDevice.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteDevice.BackgroundOnClick = CType(resources.GetObject("btnDeleteDevice.BackgroundOnClick"), System.Drawing.Image)
        Me.btnDeleteDevice.BackgroundOnDisabled = CType(resources.GetObject("btnDeleteDevice.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnDeleteDevice.BackgroundOnHover = CType(resources.GetObject("btnDeleteDevice.BackgroundOnHover"), System.Drawing.Image)
        Me.btnDeleteDevice.BackgroundOnNormal = CType(resources.GetObject("btnDeleteDevice.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnDeleteDevice.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnDeleteDevice.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnDeleteDevice.Enabled = False
        Me.btnDeleteDevice.FlatAppearance.BorderSize = 0
        Me.btnDeleteDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteDevice.Location = New System.Drawing.Point(302, 110)
        Me.btnDeleteDevice.Name = "btnDeleteDevice"
        Me.btnDeleteDevice.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteDevice.TabIndex = 9
        Me.btnDeleteDevice.Text = "Eliminar"
        Me.btnDeleteDevice.UseVisualStyleBackColor = False
        '
        'btnSaveDevice
        '
        Me.btnSaveDevice.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveDevice.BackgroundImage = CType(resources.GetObject("btnSaveDevice.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveDevice.BackgroundOnClick = CType(resources.GetObject("btnSaveDevice.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSaveDevice.BackgroundOnDisabled = CType(resources.GetObject("btnSaveDevice.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSaveDevice.BackgroundOnHover = CType(resources.GetObject("btnSaveDevice.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSaveDevice.BackgroundOnNormal = CType(resources.GetObject("btnSaveDevice.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSaveDevice.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSaveDevice.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnSaveDevice.Enabled = False
        Me.btnSaveDevice.FlatAppearance.BorderSize = 0
        Me.btnSaveDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSaveDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSaveDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveDevice.Location = New System.Drawing.Point(205, 110)
        Me.btnSaveDevice.Name = "btnSaveDevice"
        Me.btnSaveDevice.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveDevice.TabIndex = 8
        Me.btnSaveDevice.Text = "Guardar"
        Me.btnSaveDevice.UseVisualStyleBackColor = False
        '
        'btnEditDevice
        '
        Me.btnEditDevice.BackColor = System.Drawing.Color.Transparent
        Me.btnEditDevice.BackgroundImage = CType(resources.GetObject("btnEditDevice.BackgroundImage"), System.Drawing.Image)
        Me.btnEditDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditDevice.BackgroundOnClick = CType(resources.GetObject("btnEditDevice.BackgroundOnClick"), System.Drawing.Image)
        Me.btnEditDevice.BackgroundOnDisabled = CType(resources.GetObject("btnEditDevice.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnEditDevice.BackgroundOnHover = CType(resources.GetObject("btnEditDevice.BackgroundOnHover"), System.Drawing.Image)
        Me.btnEditDevice.BackgroundOnNormal = CType(resources.GetObject("btnEditDevice.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnEditDevice.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnEditDevice.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnEditDevice.Enabled = False
        Me.btnEditDevice.FlatAppearance.BorderSize = 0
        Me.btnEditDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnEditDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnEditDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditDevice.Location = New System.Drawing.Point(108, 110)
        Me.btnEditDevice.Name = "btnEditDevice"
        Me.btnEditDevice.Size = New System.Drawing.Size(75, 23)
        Me.btnEditDevice.TabIndex = 7
        Me.btnEditDevice.Text = "Editar"
        Me.btnEditDevice.UseVisualStyleBackColor = False
        '
        'btnNewDevice
        '
        Me.btnNewDevice.BackColor = System.Drawing.Color.Transparent
        Me.btnNewDevice.BackgroundImage = CType(resources.GetObject("btnNewDevice.BackgroundImage"), System.Drawing.Image)
        Me.btnNewDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNewDevice.BackgroundOnClick = CType(resources.GetObject("btnNewDevice.BackgroundOnClick"), System.Drawing.Image)
        Me.btnNewDevice.BackgroundOnDisabled = CType(resources.GetObject("btnNewDevice.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnNewDevice.BackgroundOnHover = CType(resources.GetObject("btnNewDevice.BackgroundOnHover"), System.Drawing.Image)
        Me.btnNewDevice.BackgroundOnNormal = CType(resources.GetObject("btnNewDevice.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnNewDevice.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnNewDevice.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnNewDevice.FlatAppearance.BorderSize = 0
        Me.btnNewDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNewDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNewDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewDevice.Location = New System.Drawing.Point(11, 110)
        Me.btnNewDevice.Name = "btnNewDevice"
        Me.btnNewDevice.Size = New System.Drawing.Size(75, 23)
        Me.btnNewDevice.TabIndex = 6
        Me.btnNewDevice.Text = "Nuevo"
        Me.btnNewDevice.UseVisualStyleBackColor = False
        '
        'txtMImei
        '
        Me.txtMImei.CaracterDecimal = False
        Me.txtMImei.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMImei.Enabled = False
        Me.txtMImei.HintText = "Hint Text"
        Me.txtMImei.HintTextColor = System.Drawing.Color.Gray
        Me.txtMImei.HintTextEnabled = False
        Me.txtMImei.Location = New System.Drawing.Point(302, 54)
        Me.txtMImei.MaxLength = 15
        Me.txtMImei.Name = "txtMImei"
        Me.txtMImei.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtMImei.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtMImei.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtMImei.Size = New System.Drawing.Size(167, 20)
        Me.txtMImei.TabIndex = 3
        '
        'cboMSimCards
        '
        Me.cboMSimCards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMSimCards.Enabled = False
        Me.cboMSimCards.FormattingEnabled = True
        Me.cboMSimCards.HintText = "Hint Text"
        Me.cboMSimCards.HintTextColor = System.Drawing.Color.Gray
        Me.cboMSimCards.HintTextEnabled = False
        Me.cboMSimCards.Location = New System.Drawing.Point(78, 27)
        Me.cboMSimCards.Name = "cboMSimCards"
        Me.cboMSimCards.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboMSimCards.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboMSimCards.Size = New System.Drawing.Size(391, 21)
        Me.cboMSimCards.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(266, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Imei"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(15, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Observaciones"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(16, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Modelo"
        '
        'Labe59
        '
        Me.Labe59.AutoSize = True
        Me.Labe59.Enabled = False
        Me.Labe59.Location = New System.Drawing.Point(15, 30)
        Me.Labe59.Name = "Labe59"
        Me.Labe59.Size = New System.Drawing.Size(57, 13)
        Me.Labe59.TabIndex = 18
        Me.Labe59.Text = "Sim Card"
        '
        'gboxDeviceFiltering
        '
        Me.gboxDeviceFiltering.Controls.Add(Me.txtFSerialPhone)
        Me.gboxDeviceFiltering.Controls.Add(Me.lblResult)
        Me.gboxDeviceFiltering.Controls.Add(Me.panelAsignedDevice)
        Me.gboxDeviceFiltering.Controls.Add(Me.panelStatusDevice)
        Me.gboxDeviceFiltering.Controls.Add(Me.btnExportExcel)
        Me.gboxDeviceFiltering.Controls.Add(Me.btnSearchDevices)
        Me.gboxDeviceFiltering.Controls.Add(Me.rbtnDeviceFiltering)
        Me.gboxDeviceFiltering.Controls.Add(Me.cboxFAsigned)
        Me.gboxDeviceFiltering.Controls.Add(Me.cboxFStatus)
        Me.gboxDeviceFiltering.Controls.Add(Me.txtFImei)
        Me.gboxDeviceFiltering.Controls.Add(Me.cboxFImei)
        Me.gboxDeviceFiltering.Controls.Add(Me.cboxFSimCard)
        Me.gboxDeviceFiltering.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxDeviceFiltering.Enabled = False
        Me.gboxDeviceFiltering.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxDeviceFiltering.Location = New System.Drawing.Point(0, 142)
        Me.gboxDeviceFiltering.Name = "gboxDeviceFiltering"
        Me.gboxDeviceFiltering.Size = New System.Drawing.Size(481, 132)
        Me.gboxDeviceFiltering.TabIndex = 1
        Me.gboxDeviceFiltering.TabStop = False
        '
        'txtFSerialPhone
        '
        Me.txtFSerialPhone.CaracterDecimal = False
        Me.txtFSerialPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFSerialPhone.Enabled = False
        Me.txtFSerialPhone.HintText = "Hint Text"
        Me.txtFSerialPhone.HintTextColor = System.Drawing.Color.Gray
        Me.txtFSerialPhone.HintTextEnabled = False
        Me.txtFSerialPhone.Location = New System.Drawing.Point(200, 26)
        Me.txtFSerialPhone.MaxLength = 25
        Me.txtFSerialPhone.Name = "txtFSerialPhone"
        Me.txtFSerialPhone.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtFSerialPhone.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtFSerialPhone.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtFSerialPhone.Size = New System.Drawing.Size(269, 20)
        Me.txtFSerialPhone.TabIndex = 2
        '
        'lblResult
        '
        Me.lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.Blue
        Me.lblResult.Location = New System.Drawing.Point(274, 78)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(196, 17)
        Me.lblResult.TabIndex = 14
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblResult.Visible = False
        '
        'panelAsignedDevice
        '
        Me.panelAsignedDevice.Controls.Add(Me.rbtnFAsignedYes)
        Me.panelAsignedDevice.Controls.Add(Me.rbtnFAsignedNo)
        Me.panelAsignedDevice.Enabled = False
        Me.panelAsignedDevice.Location = New System.Drawing.Point(98, 104)
        Me.panelAsignedDevice.Name = "panelAsignedDevice"
        Me.panelAsignedDevice.Size = New System.Drawing.Size(98, 18)
        Me.panelAsignedDevice.TabIndex = 8
        '
        'rbtnFAsignedYes
        '
        Me.rbtnFAsignedYes.AutoSize = True
        Me.rbtnFAsignedYes.Checked = True
        Me.rbtnFAsignedYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFAsignedYes.Location = New System.Drawing.Point(3, 1)
        Me.rbtnFAsignedYes.Name = "rbtnFAsignedYes"
        Me.rbtnFAsignedYes.Size = New System.Drawing.Size(34, 17)
        Me.rbtnFAsignedYes.TabIndex = 0
        Me.rbtnFAsignedYes.TabStop = True
        Me.rbtnFAsignedYes.Text = "Si"
        Me.rbtnFAsignedYes.UseVisualStyleBackColor = True
        '
        'rbtnFAsignedNo
        '
        Me.rbtnFAsignedNo.AutoSize = True
        Me.rbtnFAsignedNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFAsignedNo.Location = New System.Drawing.Point(51, 1)
        Me.rbtnFAsignedNo.Name = "rbtnFAsignedNo"
        Me.rbtnFAsignedNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtnFAsignedNo.TabIndex = 1
        Me.rbtnFAsignedNo.Text = "No"
        Me.rbtnFAsignedNo.UseVisualStyleBackColor = True
        '
        'panelStatusDevice
        '
        Me.panelStatusDevice.Controls.Add(Me.rbtnFActive)
        Me.panelStatusDevice.Controls.Add(Me.rbtnFInactive)
        Me.panelStatusDevice.Enabled = False
        Me.panelStatusDevice.Location = New System.Drawing.Point(87, 80)
        Me.panelStatusDevice.Name = "panelStatusDevice"
        Me.panelStatusDevice.Size = New System.Drawing.Size(137, 18)
        Me.panelStatusDevice.TabIndex = 6
        '
        'rbtnFActive
        '
        Me.rbtnFActive.AutoSize = True
        Me.rbtnFActive.Checked = True
        Me.rbtnFActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFActive.Location = New System.Drawing.Point(3, 1)
        Me.rbtnFActive.Name = "rbtnFActive"
        Me.rbtnFActive.Size = New System.Drawing.Size(55, 17)
        Me.rbtnFActive.TabIndex = 0
        Me.rbtnFActive.TabStop = True
        Me.rbtnFActive.Text = "Activo"
        Me.rbtnFActive.UseVisualStyleBackColor = True
        '
        'rbtnFInactive
        '
        Me.rbtnFInactive.AutoSize = True
        Me.rbtnFInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFInactive.Location = New System.Drawing.Point(70, 1)
        Me.rbtnFInactive.Name = "rbtnFInactive"
        Me.rbtnFInactive.Size = New System.Drawing.Size(63, 17)
        Me.rbtnFInactive.TabIndex = 1
        Me.rbtnFInactive.Text = "Inactivo"
        Me.rbtnFInactive.UseVisualStyleBackColor = True
        '
        'btnExportExcel
        '
        Me.btnExportExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnExportExcel.BackgroundImage = CType(resources.GetObject("btnExportExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportExcel.BackgroundOnClick = CType(resources.GetObject("btnExportExcel.BackgroundOnClick"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundOnDisabled = CType(resources.GetObject("btnExportExcel.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundOnHover = CType(resources.GetObject("btnExportExcel.BackgroundOnHover"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundOnNormal = CType(resources.GetObject("btnExportExcel.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnExportExcel.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        Me.btnExportExcel.Enabled = False
        Me.btnExportExcel.FlatAppearance.BorderSize = 0
        Me.btnExportExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportExcel.Location = New System.Drawing.Point(274, 98)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(115, 23)
        Me.btnExportExcel.TabIndex = 9
        Me.btnExportExcel.Text = "Exportar a Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'btnSearchDevices
        '
        Me.btnSearchDevices.BackColor = System.Drawing.Color.Transparent
        Me.btnSearchDevices.BackgroundImage = CType(resources.GetObject("btnSearchDevices.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchDevices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchDevices.BackgroundOnClick = CType(resources.GetObject("btnSearchDevices.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSearchDevices.BackgroundOnDisabled = CType(resources.GetObject("btnSearchDevices.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSearchDevices.BackgroundOnHover = CType(resources.GetObject("btnSearchDevices.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSearchDevices.BackgroundOnNormal = CType(resources.GetObject("btnSearchDevices.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSearchDevices.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSearchDevices.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        Me.btnSearchDevices.FlatAppearance.BorderSize = 0
        Me.btnSearchDevices.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSearchDevices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSearchDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchDevices.Location = New System.Drawing.Point(395, 98)
        Me.btnSearchDevices.Name = "btnSearchDevices"
        Me.btnSearchDevices.Size = New System.Drawing.Size(75, 23)
        Me.btnSearchDevices.TabIndex = 10
        Me.btnSearchDevices.Text = "Buscar"
        Me.btnSearchDevices.UseVisualStyleBackColor = False
        '
        'rbtnDeviceFiltering
        '
        Me.rbtnDeviceFiltering.AutoSize = True
        Me.rbtnDeviceFiltering.BackColor = System.Drawing.SystemColors.Control
        Me.rbtnDeviceFiltering.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnDeviceFiltering.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbtnDeviceFiltering.Location = New System.Drawing.Point(10, 0)
        Me.rbtnDeviceFiltering.Name = "rbtnDeviceFiltering"
        Me.rbtnDeviceFiltering.Size = New System.Drawing.Size(53, 17)
        Me.rbtnDeviceFiltering.TabIndex = 0
        Me.rbtnDeviceFiltering.Text = "Filtro"
        Me.rbtnDeviceFiltering.UseVisualStyleBackColor = False
        '
        'cboxFAsigned
        '
        Me.cboxFAsigned.AutoSize = True
        Me.cboxFAsigned.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFAsigned.Location = New System.Drawing.Point(18, 105)
        Me.cboxFAsigned.Name = "cboxFAsigned"
        Me.cboxFAsigned.Size = New System.Drawing.Size(78, 17)
        Me.cboxFAsigned.TabIndex = 7
        Me.cboxFAsigned.Text = "Asignado"
        Me.cboxFAsigned.UseVisualStyleBackColor = True
        '
        'cboxFStatus
        '
        Me.cboxFStatus.AutoSize = True
        Me.cboxFStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFStatus.Location = New System.Drawing.Point(18, 82)
        Me.cboxFStatus.Name = "cboxFStatus"
        Me.cboxFStatus.Size = New System.Drawing.Size(65, 17)
        Me.cboxFStatus.TabIndex = 5
        Me.cboxFStatus.Text = "Estado"
        Me.cboxFStatus.UseVisualStyleBackColor = True
        '
        'txtFImei
        '
        Me.txtFImei.CaracterDecimal = False
        Me.txtFImei.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFImei.Enabled = False
        Me.txtFImei.HintText = "Hint Text"
        Me.txtFImei.HintTextColor = System.Drawing.Color.Gray
        Me.txtFImei.HintTextEnabled = False
        Me.txtFImei.Location = New System.Drawing.Point(73, 53)
        Me.txtFImei.MaxLength = 15
        Me.txtFImei.Name = "txtFImei"
        Me.txtFImei.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtFImei.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtFImei.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtFImei.Size = New System.Drawing.Size(396, 20)
        Me.txtFImei.TabIndex = 4
        '
        'cboxFImei
        '
        Me.cboxFImei.AutoSize = True
        Me.cboxFImei.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFImei.Location = New System.Drawing.Point(18, 55)
        Me.cboxFImei.Name = "cboxFImei"
        Me.cboxFImei.Size = New System.Drawing.Size(49, 17)
        Me.cboxFImei.TabIndex = 3
        Me.cboxFImei.Text = "Imei"
        Me.cboxFImei.UseVisualStyleBackColor = True
        '
        'cboxFSimCard
        '
        Me.cboxFSimCard.AutoSize = True
        Me.cboxFSimCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFSimCard.Location = New System.Drawing.Point(18, 28)
        Me.cboxFSimCard.Name = "cboxFSimCard"
        Me.cboxFSimCard.Size = New System.Drawing.Size(176, 17)
        Me.cboxFSimCard.TabIndex = 1
        Me.cboxFSimCard.Text = "Sim Card (Serial/Teléfono)"
        Me.cboxFSimCard.UseVisualStyleBackColor = True
        '
        'bgwGetSimCards
        '
        Me.bgwGetSimCards.WorkerReportsProgress = True
        Me.bgwGetSimCards.WorkerSupportsCancellation = True
        '
        'bgwSaveDevice
        '
        Me.bgwSaveDevice.WorkerReportsProgress = True
        Me.bgwSaveDevice.WorkerSupportsCancellation = True
        '
        'bgwDeleteDevice
        '
        Me.bgwDeleteDevice.WorkerReportsProgress = True
        Me.bgwDeleteDevice.WorkerSupportsCancellation = True
        '
        'bgwSearchDevices
        '
        Me.bgwSearchDevices.WorkerReportsProgress = True
        Me.bgwSearchDevices.WorkerSupportsCancellation = True
        '
        'bgwExportExcel
        '
        Me.bgwExportExcel.WorkerReportsProgress = True
        Me.bgwExportExcel.WorkerSupportsCancellation = True
        '
        'panelLoading
        '
        Me.panelLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelLoading.Controls.Add(Me.lblLoading)
        Me.panelLoading.Controls.Add(Me.pboxLoading)
        Me.panelLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelLoading.Location = New System.Drawing.Point(0, 570)
        Me.panelLoading.Name = "panelLoading"
        Me.panelLoading.Size = New System.Drawing.Size(481, 20)
        Me.panelLoading.TabIndex = 17
        Me.panelLoading.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLoading.Location = New System.Drawing.Point(0, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(451, 20)
        Me.lblLoading.TabIndex = 16
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pboxLoading
        '
        Me.pboxLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pboxLoading.Dock = System.Windows.Forms.DockStyle.Right
        Me.pboxLoading.Image = Global.ZUtracking.My.Resources.Resources.loading
        Me.pboxLoading.Location = New System.Drawing.Point(451, 0)
        Me.pboxLoading.Name = "pboxLoading"
        Me.pboxLoading.Size = New System.Drawing.Size(30, 20)
        Me.pboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxLoading.TabIndex = 15
        Me.pboxLoading.TabStop = False
        '
        'dgvDevices
        '
        Me.dgvDevices.AllowUserToAddRows = False
        Me.dgvDevices.AllowUserToDeleteRows = False
        Me.dgvDevices.AllowUserToResizeColumns = False
        Me.dgvDevices.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        Me.dgvDevices.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDevices.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvDevices.BackgroundHeader = CType(resources.GetObject("dgvDevices.BackgroundHeader"), System.Drawing.Image)
        Me.dgvDevices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDevices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDevices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDevices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDevices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvDevices_btn_config, Me.dgvDevices_imei, Me.dgvDevices_simcard, Me.dgvDevices_model, Me.dgvDevices_phone_number, Me.dgvDevices_observations, Me.dgvDevices_status, Me.dgvDevices_device_id, Me.dgvDevices_simcard_id, Me.dgvDevices_device_model_id, Me.dgvDevices_sms_stop, Me.dgvDevices_sms_resume, Me.dgvDevices_gprs_stop, Me.dgvDevices_gprs_resume})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDevices.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDevices.GridColor = System.Drawing.SystemColors.Control
        Me.dgvDevices.HeaderFontSize = 7.0!
        Me.dgvDevices.HeaderForeColor = System.Drawing.Color.White
        Me.dgvDevices.Location = New System.Drawing.Point(0, 274)
        Me.dgvDevices.MultiSelect = False
        Me.dgvDevices.Name = "dgvDevices"
        Me.dgvDevices.ReadOnly = True
        Me.dgvDevices.RowHeadersVisible = False
        Me.dgvDevices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDevices.Size = New System.Drawing.Size(481, 316)
        Me.dgvDevices.TabIndex = 2
        '
        'dgvDevices_btn_config
        '
        Me.dgvDevices_btn_config.HeaderText = ""
        Me.dgvDevices_btn_config.Name = "dgvDevices_btn_config"
        Me.dgvDevices_btn_config.ReadOnly = True
        Me.dgvDevices_btn_config.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDevices_btn_config.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDevices_btn_config.Text = "CONFIG"
        Me.dgvDevices_btn_config.UseColumnTextForButtonValue = True
        Me.dgvDevices_btn_config.Width = 19
        '
        'dgvDevices_imei
        '
        Me.dgvDevices_imei.HeaderText = "IMEI"
        Me.dgvDevices_imei.Name = "dgvDevices_imei"
        Me.dgvDevices_imei.ReadOnly = True
        Me.dgvDevices_imei.Width = 150
        '
        'dgvDevices_simcard
        '
        Me.dgvDevices_simcard.HeaderText = "SIMCARD"
        Me.dgvDevices_simcard.Name = "dgvDevices_simcard"
        Me.dgvDevices_simcard.ReadOnly = True
        Me.dgvDevices_simcard.Width = 300
        '
        'dgvDevices_model
        '
        Me.dgvDevices_model.HeaderText = "MODELO"
        Me.dgvDevices_model.Name = "dgvDevices_model"
        Me.dgvDevices_model.ReadOnly = True
        '
        'dgvDevices_phone_number
        '
        Me.dgvDevices_phone_number.HeaderText = "TELÉFONO"
        Me.dgvDevices_phone_number.Name = "dgvDevices_phone_number"
        Me.dgvDevices_phone_number.ReadOnly = True
        Me.dgvDevices_phone_number.Visible = False
        Me.dgvDevices_phone_number.Width = 97
        '
        'dgvDevices_observations
        '
        Me.dgvDevices_observations.HeaderText = "OBSERVACIONES"
        Me.dgvDevices_observations.Name = "dgvDevices_observations"
        Me.dgvDevices_observations.ReadOnly = True
        Me.dgvDevices_observations.Visible = False
        Me.dgvDevices_observations.Width = 136
        '
        'dgvDevices_status
        '
        Me.dgvDevices_status.HeaderText = "ESTADO"
        Me.dgvDevices_status.Name = "dgvDevices_status"
        Me.dgvDevices_status.ReadOnly = True
        Me.dgvDevices_status.Visible = False
        Me.dgvDevices_status.Width = 82
        '
        'dgvDevices_device_id
        '
        Me.dgvDevices_device_id.HeaderText = "ID DISPOSITIVO"
        Me.dgvDevices_device_id.Name = "dgvDevices_device_id"
        Me.dgvDevices_device_id.ReadOnly = True
        Me.dgvDevices_device_id.Visible = False
        Me.dgvDevices_device_id.Width = 128
        '
        'dgvDevices_simcard_id
        '
        Me.dgvDevices_simcard_id.HeaderText = "ID SIMCARD"
        Me.dgvDevices_simcard_id.Name = "dgvDevices_simcard_id"
        Me.dgvDevices_simcard_id.ReadOnly = True
        Me.dgvDevices_simcard_id.Visible = False
        Me.dgvDevices_simcard_id.Width = 105
        '
        'dgvDevices_device_model_id
        '
        Me.dgvDevices_device_model_id.HeaderText = "ID MODELO"
        Me.dgvDevices_device_model_id.Name = "dgvDevices_device_model_id"
        Me.dgvDevices_device_model_id.ReadOnly = True
        Me.dgvDevices_device_model_id.Visible = False
        Me.dgvDevices_device_model_id.Width = 101
        '
        'dgvDevices_sms_stop
        '
        Me.dgvDevices_sms_stop.HeaderText = "SMS STOP"
        Me.dgvDevices_sms_stop.Name = "dgvDevices_sms_stop"
        Me.dgvDevices_sms_stop.ReadOnly = True
        Me.dgvDevices_sms_stop.Visible = False
        '
        'dgvDevices_sms_resume
        '
        Me.dgvDevices_sms_resume.HeaderText = "SMS RESUME"
        Me.dgvDevices_sms_resume.Name = "dgvDevices_sms_resume"
        Me.dgvDevices_sms_resume.ReadOnly = True
        Me.dgvDevices_sms_resume.Visible = False
        '
        'dgvDevices_gprs_stop
        '
        Me.dgvDevices_gprs_stop.HeaderText = "GPRS STOP"
        Me.dgvDevices_gprs_stop.Name = "dgvDevices_gprs_stop"
        Me.dgvDevices_gprs_stop.ReadOnly = True
        Me.dgvDevices_gprs_stop.Visible = False
        '
        'dgvDevices_gprs_resume
        '
        Me.dgvDevices_gprs_resume.HeaderText = "GPRS RESUME"
        Me.dgvDevices_gprs_resume.Name = "dgvDevices_gprs_resume"
        Me.dgvDevices_gprs_resume.ReadOnly = True
        Me.dgvDevices_gprs_resume.Visible = False
        '
        'frmDevices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 590)
        Me.Controls.Add(Me.panelLoading)
        Me.Controls.Add(Me.dgvDevices)
        Me.Controls.Add(Me.gboxDeviceFiltering)
        Me.Controls.Add(Me.gboxDeviceMaintaining)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(497, 629)
        Me.Name = "frmDevices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DISPOSITIVOS GPS"
        Me.gboxDeviceMaintaining.ResumeLayout(False)
        Me.gboxDeviceMaintaining.PerformLayout()
        Me.gboxDeviceFiltering.ResumeLayout(False)
        Me.gboxDeviceFiltering.PerformLayout()
        Me.panelAsignedDevice.ResumeLayout(False)
        Me.panelAsignedDevice.PerformLayout()
        Me.panelStatusDevice.ResumeLayout(False)
        Me.panelStatusDevice.PerformLayout()
        Me.panelLoading.ResumeLayout(False)
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDevices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gboxDeviceMaintaining As GroupBox
    Friend WithEvents rbtnDeviceMaintaining As RadioButton
    Friend WithEvents btnCancelDevice As ZUControls.ZUButton
    Friend WithEvents btnDeleteDevice As ZUControls.ZUButton
    Friend WithEvents btnSaveDevice As ZUControls.ZUButton
    Friend WithEvents btnEditDevice As ZUControls.ZUButton
    Friend WithEvents btnNewDevice As ZUControls.ZUButton
    Friend WithEvents txtMImei As ZUControls.ZUNumericBox
    Friend WithEvents cboMSimCards As ZUControls.ZUComboBox
    Friend WithEvents Labe58 As Label
    Friend WithEvents Labe59 As Label
    Friend WithEvents cboMModels As ZUControls.ZUComboBox
    Friend WithEvents Label60 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents gboxDeviceFiltering As GroupBox
    Friend WithEvents txtFSerialPhone As ZUControls.ZUNumericBox
    Friend WithEvents lblResult As Label
    Friend WithEvents panelAsignedDevice As ZUControls.ZUPanel
    Friend WithEvents rbtnFAsignedYes As RadioButton
    Friend WithEvents rbtnFAsignedNo As RadioButton
    Friend WithEvents panelStatusDevice As ZUControls.ZUPanel
    Friend WithEvents rbtnFActive As RadioButton
    Friend WithEvents rbtnFInactive As RadioButton
    Friend WithEvents btnExportExcel As ZUControls.ZUButton
    Friend WithEvents btnSearchDevices As ZUControls.ZUButton
    Friend WithEvents rbtnDeviceFiltering As RadioButton
    Friend WithEvents cboxFAsigned As CheckBox
    Friend WithEvents cboxFStatus As CheckBox
    Friend WithEvents cboxFImei As CheckBox
    Friend WithEvents cboxFSimCard As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMObservations As ZUControls.ZUTextBox
    Friend WithEvents cboxMStatus As CheckBox
    Friend WithEvents txtFImei As ZUControls.ZUNumericBox
    Friend WithEvents dgvDevices As ZUControls.ZUDataGridView
    Friend WithEvents bgwGetSimCards As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwSaveDevice As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwDeleteDevice As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwSearchDevices As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwExportExcel As System.ComponentModel.BackgroundWorker
    Friend WithEvents panelLoading As ZUControls.ZUPanel
    Friend WithEvents lblLoading As Label
    Friend WithEvents pboxLoading As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvDevices_btn_config As DataGridViewButtonColumn
    Friend WithEvents dgvDevices_imei As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_simcard As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_model As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_phone_number As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_observations As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_status As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_device_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_simcard_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_device_model_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_sms_stop As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_sms_resume As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_gprs_stop As DataGridViewTextBoxColumn
    Friend WithEvents dgvDevices_gprs_resume As DataGridViewTextBoxColumn
End Class
