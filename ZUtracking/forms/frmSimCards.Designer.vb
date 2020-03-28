<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSimCards
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSimCards))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pboxLoading = New System.Windows.Forms.PictureBox()
        Me.bgwSavingSimCard = New System.ComponentModel.BackgroundWorker()
        Me.bgwDeletingSimCard = New System.ComponentModel.BackgroundWorker()
        Me.bgwSearchingSimCards = New System.ComponentModel.BackgroundWorker()
        Me.bgwExporting = New System.ComponentModel.BackgroundWorker()
        Me.dgvSimCards = New ZUControls.ZUDataGridView()
        Me.dgvSimCards_operator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_serial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_phone_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_apn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_observations = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_call_service = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_sms_service = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_data_service = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_asigned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSimCards_simcard_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelHeader = New ZUControls.ZUPanel()
        Me.gboxSimCardFiltering = New System.Windows.Forms.GroupBox()
        Me.txtFApn = New ZUControls.ZUTextBox()
        Me.txtFSerialPhone = New ZUControls.ZUNumericBox()
        Me.cboFOperator = New ZUControls.ZUComboBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.panelAsignedSimCard = New ZUControls.ZUPanel()
        Me.rbtnFAsignedYes = New System.Windows.Forms.RadioButton()
        Me.rbtnFAsignedNo = New System.Windows.Forms.RadioButton()
        Me.panelStatusSimCard = New ZUControls.ZUPanel()
        Me.rbtnFActive = New System.Windows.Forms.RadioButton()
        Me.rbtnFInactive = New System.Windows.Forms.RadioButton()
        Me.btnExportExcel = New ZUControls.ZUButton()
        Me.btnSearchSimCards = New ZUControls.ZUButton()
        Me.rbtnSimCardFiltering = New System.Windows.Forms.RadioButton()
        Me.cboxFAsigned = New System.Windows.Forms.CheckBox()
        Me.cboxFStatus = New System.Windows.Forms.CheckBox()
        Me.cboxFApn = New System.Windows.Forms.CheckBox()
        Me.cboxFSerialPhone = New System.Windows.Forms.CheckBox()
        Me.cboxFOperator = New System.Windows.Forms.CheckBox()
        Me.gboxSimCardMaintaining = New System.Windows.Forms.GroupBox()
        Me.rbtnSimCardMaintaining = New System.Windows.Forms.RadioButton()
        Me.btnCancelSimCard = New ZUControls.ZUButton()
        Me.btnDeleteSimCard = New ZUControls.ZUButton()
        Me.btnSaveSimCard = New ZUControls.ZUButton()
        Me.btnEditSimCard = New ZUControls.ZUButton()
        Me.btnNewSimCard = New ZUControls.ZUButton()
        Me.txtMPhoneNumber = New ZUControls.ZUNumericBox()
        Me.txtMApn = New ZUControls.ZUTextBox()
        Me.txtMObservations = New ZUControls.ZUTextBox()
        Me.txtMSerial = New ZUControls.ZUTextBox()
        Me.cboMOperator = New ZUControls.ZUComboBox()
        Me.cboxMStatus = New System.Windows.Forms.CheckBox()
        Me.cboxMData = New System.Windows.Forms.CheckBox()
        Me.cboxMSms = New System.Windows.Forms.CheckBox()
        Me.cboxMCall = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelLoading = New ZUControls.ZUPanel()
        Me.lblLoading = New System.Windows.Forms.Label()
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSimCards, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.gboxSimCardFiltering.SuspendLayout()
        Me.panelAsignedSimCard.SuspendLayout()
        Me.panelStatusSimCard.SuspendLayout()
        Me.gboxSimCardMaintaining.SuspendLayout()
        Me.panelLoading.SuspendLayout()
        Me.SuspendLayout()
        '
        'pboxLoading
        '
        Me.pboxLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pboxLoading.Dock = System.Windows.Forms.DockStyle.Right
        Me.pboxLoading.Image = Global.ZUtracking.My.Resources.Resources.loading
        Me.pboxLoading.Location = New System.Drawing.Point(452, 0)
        Me.pboxLoading.Name = "pboxLoading"
        Me.pboxLoading.Size = New System.Drawing.Size(30, 20)
        Me.pboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxLoading.TabIndex = 15
        Me.pboxLoading.TabStop = False
        '
        'bgwSavingSimCard
        '
        Me.bgwSavingSimCard.WorkerReportsProgress = True
        Me.bgwSavingSimCard.WorkerSupportsCancellation = True
        '
        'bgwDeletingSimCard
        '
        Me.bgwDeletingSimCard.WorkerReportsProgress = True
        Me.bgwDeletingSimCard.WorkerSupportsCancellation = True
        '
        'bgwSearchingSimCards
        '
        Me.bgwSearchingSimCards.WorkerReportsProgress = True
        Me.bgwSearchingSimCards.WorkerSupportsCancellation = True
        '
        'bgwExporting
        '
        Me.bgwExporting.WorkerReportsProgress = True
        Me.bgwExporting.WorkerSupportsCancellation = True
        '
        'dgvSimCards
        '
        Me.dgvSimCards.AllowUserToAddRows = False
        Me.dgvSimCards.AllowUserToDeleteRows = False
        Me.dgvSimCards.AllowUserToResizeColumns = False
        Me.dgvSimCards.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        Me.dgvSimCards.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSimCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSimCards.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvSimCards.BackgroundHeader = CType(resources.GetObject("dgvSimCards.BackgroundHeader"), System.Drawing.Image)
        Me.dgvSimCards.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSimCards.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvSimCards.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSimCards.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSimCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSimCards.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSimCards_operator, Me.dgvSimCards_serial, Me.dgvSimCards_phone_number, Me.dgvSimCards_apn, Me.dgvSimCards_observations, Me.dgvSimCards_call_service, Me.dgvSimCards_sms_service, Me.dgvSimCards_data_service, Me.dgvSimCards_status, Me.dgvSimCards_asigned, Me.dgvSimCards_simcard_id})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSimCards.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSimCards.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSimCards.GridColor = System.Drawing.SystemColors.Control
        Me.dgvSimCards.HeaderFontSize = 7.0!
        Me.dgvSimCards.HeaderForeColor = System.Drawing.Color.White
        Me.dgvSimCards.Location = New System.Drawing.Point(0, 319)
        Me.dgvSimCards.MultiSelect = False
        Me.dgvSimCards.Name = "dgvSimCards"
        Me.dgvSimCards.ReadOnly = True
        Me.dgvSimCards.RowHeadersVisible = False
        Me.dgvSimCards.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSimCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSimCards.Size = New System.Drawing.Size(482, 292)
        Me.dgvSimCards.TabIndex = 0
        '
        'dgvSimCards_operator
        '
        Me.dgvSimCards_operator.HeaderText = "OPERADORA"
        Me.dgvSimCards_operator.Name = "dgvSimCards_operator"
        Me.dgvSimCards_operator.ReadOnly = True
        Me.dgvSimCards_operator.Width = 109
        '
        'dgvSimCards_serial
        '
        Me.dgvSimCards_serial.HeaderText = "SERIAL"
        Me.dgvSimCards_serial.Name = "dgvSimCards_serial"
        Me.dgvSimCards_serial.ReadOnly = True
        Me.dgvSimCards_serial.Width = 76
        '
        'dgvSimCards_phone_number
        '
        Me.dgvSimCards_phone_number.HeaderText = "TELÉFONO"
        Me.dgvSimCards_phone_number.Name = "dgvSimCards_phone_number"
        Me.dgvSimCards_phone_number.ReadOnly = True
        Me.dgvSimCards_phone_number.Width = 97
        '
        'dgvSimCards_apn
        '
        Me.dgvSimCards_apn.HeaderText = "APN"
        Me.dgvSimCards_apn.Name = "dgvSimCards_apn"
        Me.dgvSimCards_apn.ReadOnly = True
        Me.dgvSimCards_apn.Width = 57
        '
        'dgvSimCards_observations
        '
        Me.dgvSimCards_observations.HeaderText = "OBSERVACIONES"
        Me.dgvSimCards_observations.Name = "dgvSimCards_observations"
        Me.dgvSimCards_observations.ReadOnly = True
        Me.dgvSimCards_observations.Visible = False
        Me.dgvSimCards_observations.Width = 136
        '
        'dgvSimCards_call_service
        '
        Me.dgvSimCards_call_service.HeaderText = "SERVICIO DE VOZ"
        Me.dgvSimCards_call_service.Name = "dgvSimCards_call_service"
        Me.dgvSimCards_call_service.ReadOnly = True
        Me.dgvSimCards_call_service.Visible = False
        Me.dgvSimCards_call_service.Width = 140
        '
        'dgvSimCards_sms_service
        '
        Me.dgvSimCards_sms_service.HeaderText = "SERVICIO DE SMS"
        Me.dgvSimCards_sms_service.Name = "dgvSimCards_sms_service"
        Me.dgvSimCards_sms_service.ReadOnly = True
        Me.dgvSimCards_sms_service.Visible = False
        Me.dgvSimCards_sms_service.Width = 141
        '
        'dgvSimCards_data_service
        '
        Me.dgvSimCards_data_service.HeaderText = "SERVICIO DE DATOS"
        Me.dgvSimCards_data_service.Name = "dgvSimCards_data_service"
        Me.dgvSimCards_data_service.ReadOnly = True
        Me.dgvSimCards_data_service.Visible = False
        Me.dgvSimCards_data_service.Width = 157
        '
        'dgvSimCards_status
        '
        Me.dgvSimCards_status.HeaderText = "ESTADO DE LA LÍNEA"
        Me.dgvSimCards_status.Name = "dgvSimCards_status"
        Me.dgvSimCards_status.ReadOnly = True
        Me.dgvSimCards_status.Visible = False
        Me.dgvSimCards_status.Width = 162
        '
        'dgvSimCards_asigned
        '
        Me.dgvSimCards_asigned.HeaderText = "ASIGNADA A DISPOSITIVO"
        Me.dgvSimCards_asigned.Name = "dgvSimCards_asigned"
        Me.dgvSimCards_asigned.ReadOnly = True
        Me.dgvSimCards_asigned.Visible = False
        Me.dgvSimCards_asigned.Width = 190
        '
        'dgvSimCards_simcard_id
        '
        Me.dgvSimCards_simcard_id.HeaderText = "ID SIM CARD"
        Me.dgvSimCards_simcard_id.Name = "dgvSimCards_simcard_id"
        Me.dgvSimCards_simcard_id.ReadOnly = True
        Me.dgvSimCards_simcard_id.Visible = False
        Me.dgvSimCards_simcard_id.Width = 109
        '
        'panelHeader
        '
        Me.panelHeader.Controls.Add(Me.gboxSimCardFiltering)
        Me.panelHeader.Controls.Add(Me.gboxSimCardMaintaining)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(482, 319)
        Me.panelHeader.TabIndex = 0
        '
        'gboxSimCardFiltering
        '
        Me.gboxSimCardFiltering.Controls.Add(Me.txtFApn)
        Me.gboxSimCardFiltering.Controls.Add(Me.txtFSerialPhone)
        Me.gboxSimCardFiltering.Controls.Add(Me.cboFOperator)
        Me.gboxSimCardFiltering.Controls.Add(Me.lblResult)
        Me.gboxSimCardFiltering.Controls.Add(Me.panelAsignedSimCard)
        Me.gboxSimCardFiltering.Controls.Add(Me.panelStatusSimCard)
        Me.gboxSimCardFiltering.Controls.Add(Me.btnExportExcel)
        Me.gboxSimCardFiltering.Controls.Add(Me.btnSearchSimCards)
        Me.gboxSimCardFiltering.Controls.Add(Me.rbtnSimCardFiltering)
        Me.gboxSimCardFiltering.Controls.Add(Me.cboxFAsigned)
        Me.gboxSimCardFiltering.Controls.Add(Me.cboxFStatus)
        Me.gboxSimCardFiltering.Controls.Add(Me.cboxFApn)
        Me.gboxSimCardFiltering.Controls.Add(Me.cboxFSerialPhone)
        Me.gboxSimCardFiltering.Controls.Add(Me.cboxFOperator)
        Me.gboxSimCardFiltering.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxSimCardFiltering.Enabled = False
        Me.gboxSimCardFiltering.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxSimCardFiltering.Location = New System.Drawing.Point(0, 162)
        Me.gboxSimCardFiltering.Name = "gboxSimCardFiltering"
        Me.gboxSimCardFiltering.Size = New System.Drawing.Size(482, 157)
        Me.gboxSimCardFiltering.TabIndex = 1
        Me.gboxSimCardFiltering.TabStop = False
        '
        'txtFApn
        '
        Me.txtFApn.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtFApn.Enabled = False
        Me.txtFApn.HintText = "Hint Text"
        Me.txtFApn.HintTextColor = System.Drawing.Color.Gray
        Me.txtFApn.HintTextEnabled = False
        Me.txtFApn.Location = New System.Drawing.Point(72, 77)
        Me.txtFApn.MaxLength = 100
        Me.txtFApn.Name = "txtFApn"
        Me.txtFApn.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtFApn.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtFApn.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtFApn.Size = New System.Drawing.Size(398, 20)
        Me.txtFApn.TabIndex = 6
        '
        'txtFSerialPhone
        '
        Me.txtFSerialPhone.CaracterDecimal = False
        Me.txtFSerialPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFSerialPhone.Enabled = False
        Me.txtFSerialPhone.HintText = "Hint Text"
        Me.txtFSerialPhone.HintTextColor = System.Drawing.Color.Gray
        Me.txtFSerialPhone.HintTextEnabled = False
        Me.txtFSerialPhone.Location = New System.Drawing.Point(146, 52)
        Me.txtFSerialPhone.MaxLength = 25
        Me.txtFSerialPhone.Name = "txtFSerialPhone"
        Me.txtFSerialPhone.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtFSerialPhone.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtFSerialPhone.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtFSerialPhone.Size = New System.Drawing.Size(324, 20)
        Me.txtFSerialPhone.TabIndex = 4
        '
        'cboFOperator
        '
        Me.cboFOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOperator.Enabled = False
        Me.cboFOperator.FormattingEnabled = True
        Me.cboFOperator.HintText = "Hint Text"
        Me.cboFOperator.HintTextColor = System.Drawing.Color.Gray
        Me.cboFOperator.HintTextEnabled = False
        Me.cboFOperator.Location = New System.Drawing.Point(108, 26)
        Me.cboFOperator.Name = "cboFOperator"
        Me.cboFOperator.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboFOperator.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboFOperator.Size = New System.Drawing.Size(362, 21)
        Me.cboFOperator.TabIndex = 2
        '
        'lblResult
        '
        Me.lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.Blue
        Me.lblResult.Location = New System.Drawing.Point(274, 109)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(196, 17)
        Me.lblResult.TabIndex = 14
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblResult.Visible = False
        '
        'panelAsignedSimCard
        '
        Me.panelAsignedSimCard.Controls.Add(Me.rbtnFAsignedYes)
        Me.panelAsignedSimCard.Controls.Add(Me.rbtnFAsignedNo)
        Me.panelAsignedSimCard.Enabled = False
        Me.panelAsignedSimCard.Location = New System.Drawing.Point(98, 127)
        Me.panelAsignedSimCard.Name = "panelAsignedSimCard"
        Me.panelAsignedSimCard.Size = New System.Drawing.Size(98, 18)
        Me.panelAsignedSimCard.TabIndex = 10
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
        'panelStatusSimCard
        '
        Me.panelStatusSimCard.Controls.Add(Me.rbtnFActive)
        Me.panelStatusSimCard.Controls.Add(Me.rbtnFInactive)
        Me.panelStatusSimCard.Enabled = False
        Me.panelStatusSimCard.Location = New System.Drawing.Point(87, 103)
        Me.panelStatusSimCard.Name = "panelStatusSimCard"
        Me.panelStatusSimCard.Size = New System.Drawing.Size(137, 18)
        Me.panelStatusSimCard.TabIndex = 8
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
        Me.rbtnFActive.Text = "Activa"
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
        Me.rbtnFInactive.Text = "Inactiva"
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
        Me.btnExportExcel.Location = New System.Drawing.Point(274, 129)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(115, 23)
        Me.btnExportExcel.TabIndex = 11
        Me.btnExportExcel.Text = "Exportar a Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'btnSearchSimCards
        '
        Me.btnSearchSimCards.BackColor = System.Drawing.Color.Transparent
        Me.btnSearchSimCards.BackgroundImage = CType(resources.GetObject("btnSearchSimCards.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchSimCards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchSimCards.BackgroundOnClick = CType(resources.GetObject("btnSearchSimCards.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSearchSimCards.BackgroundOnDisabled = CType(resources.GetObject("btnSearchSimCards.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSearchSimCards.BackgroundOnHover = CType(resources.GetObject("btnSearchSimCards.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSearchSimCards.BackgroundOnNormal = CType(resources.GetObject("btnSearchSimCards.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSearchSimCards.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSearchSimCards.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        Me.btnSearchSimCards.FlatAppearance.BorderSize = 0
        Me.btnSearchSimCards.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSearchSimCards.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSearchSimCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSimCards.Location = New System.Drawing.Point(395, 129)
        Me.btnSearchSimCards.Name = "btnSearchSimCards"
        Me.btnSearchSimCards.Size = New System.Drawing.Size(75, 23)
        Me.btnSearchSimCards.TabIndex = 12
        Me.btnSearchSimCards.Text = "Buscar"
        Me.btnSearchSimCards.UseVisualStyleBackColor = False
        '
        'rbtnSimCardFiltering
        '
        Me.rbtnSimCardFiltering.AutoSize = True
        Me.rbtnSimCardFiltering.BackColor = System.Drawing.SystemColors.Control
        Me.rbtnSimCardFiltering.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbtnSimCardFiltering.Location = New System.Drawing.Point(10, 0)
        Me.rbtnSimCardFiltering.Name = "rbtnSimCardFiltering"
        Me.rbtnSimCardFiltering.Size = New System.Drawing.Size(53, 17)
        Me.rbtnSimCardFiltering.TabIndex = 0
        Me.rbtnSimCardFiltering.Text = "Filtro"
        Me.rbtnSimCardFiltering.UseVisualStyleBackColor = False
        '
        'cboxFAsigned
        '
        Me.cboxFAsigned.AutoSize = True
        Me.cboxFAsigned.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFAsigned.Location = New System.Drawing.Point(18, 128)
        Me.cboxFAsigned.Name = "cboxFAsigned"
        Me.cboxFAsigned.Size = New System.Drawing.Size(78, 17)
        Me.cboxFAsigned.TabIndex = 9
        Me.cboxFAsigned.Text = "Asignado"
        Me.cboxFAsigned.UseVisualStyleBackColor = True
        '
        'cboxFStatus
        '
        Me.cboxFStatus.AutoSize = True
        Me.cboxFStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFStatus.Location = New System.Drawing.Point(18, 105)
        Me.cboxFStatus.Name = "cboxFStatus"
        Me.cboxFStatus.Size = New System.Drawing.Size(65, 17)
        Me.cboxFStatus.TabIndex = 7
        Me.cboxFStatus.Text = "Estado"
        Me.cboxFStatus.UseVisualStyleBackColor = True
        '
        'cboxFApn
        '
        Me.cboxFApn.AutoSize = True
        Me.cboxFApn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFApn.Location = New System.Drawing.Point(18, 80)
        Me.cboxFApn.Name = "cboxFApn"
        Me.cboxFApn.Size = New System.Drawing.Size(48, 17)
        Me.cboxFApn.TabIndex = 5
        Me.cboxFApn.Text = "Apn"
        Me.cboxFApn.UseVisualStyleBackColor = True
        '
        'cboxFSerialPhone
        '
        Me.cboxFSerialPhone.AutoSize = True
        Me.cboxFSerialPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFSerialPhone.Location = New System.Drawing.Point(18, 55)
        Me.cboxFSerialPhone.Name = "cboxFSerialPhone"
        Me.cboxFSerialPhone.Size = New System.Drawing.Size(122, 17)
        Me.cboxFSerialPhone.TabIndex = 3
        Me.cboxFSerialPhone.Text = "Serial / Teléfono"
        Me.cboxFSerialPhone.UseVisualStyleBackColor = True
        '
        'cboxFOperator
        '
        Me.cboxFOperator.AutoSize = True
        Me.cboxFOperator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFOperator.Location = New System.Drawing.Point(18, 28)
        Me.cboxFOperator.Name = "cboxFOperator"
        Me.cboxFOperator.Size = New System.Drawing.Size(85, 17)
        Me.cboxFOperator.TabIndex = 1
        Me.cboxFOperator.Text = "Operadora"
        Me.cboxFOperator.UseVisualStyleBackColor = True
        '
        'gboxSimCardMaintaining
        '
        Me.gboxSimCardMaintaining.Controls.Add(Me.rbtnSimCardMaintaining)
        Me.gboxSimCardMaintaining.Controls.Add(Me.btnCancelSimCard)
        Me.gboxSimCardMaintaining.Controls.Add(Me.btnDeleteSimCard)
        Me.gboxSimCardMaintaining.Controls.Add(Me.btnSaveSimCard)
        Me.gboxSimCardMaintaining.Controls.Add(Me.btnEditSimCard)
        Me.gboxSimCardMaintaining.Controls.Add(Me.btnNewSimCard)
        Me.gboxSimCardMaintaining.Controls.Add(Me.txtMPhoneNumber)
        Me.gboxSimCardMaintaining.Controls.Add(Me.txtMApn)
        Me.gboxSimCardMaintaining.Controls.Add(Me.txtMObservations)
        Me.gboxSimCardMaintaining.Controls.Add(Me.txtMSerial)
        Me.gboxSimCardMaintaining.Controls.Add(Me.cboMOperator)
        Me.gboxSimCardMaintaining.Controls.Add(Me.cboxMStatus)
        Me.gboxSimCardMaintaining.Controls.Add(Me.cboxMData)
        Me.gboxSimCardMaintaining.Controls.Add(Me.cboxMSms)
        Me.gboxSimCardMaintaining.Controls.Add(Me.cboxMCall)
        Me.gboxSimCardMaintaining.Controls.Add(Me.Label4)
        Me.gboxSimCardMaintaining.Controls.Add(Me.Label5)
        Me.gboxSimCardMaintaining.Controls.Add(Me.Label2)
        Me.gboxSimCardMaintaining.Controls.Add(Me.Label3)
        Me.gboxSimCardMaintaining.Controls.Add(Me.Label1)
        Me.gboxSimCardMaintaining.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxSimCardMaintaining.Location = New System.Drawing.Point(0, 0)
        Me.gboxSimCardMaintaining.Name = "gboxSimCardMaintaining"
        Me.gboxSimCardMaintaining.Size = New System.Drawing.Size(482, 162)
        Me.gboxSimCardMaintaining.TabIndex = 0
        Me.gboxSimCardMaintaining.TabStop = False
        '
        'rbtnSimCardMaintaining
        '
        Me.rbtnSimCardMaintaining.AutoSize = True
        Me.rbtnSimCardMaintaining.BackColor = System.Drawing.SystemColors.Control
        Me.rbtnSimCardMaintaining.Checked = True
        Me.rbtnSimCardMaintaining.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSimCardMaintaining.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbtnSimCardMaintaining.Location = New System.Drawing.Point(10, 1)
        Me.rbtnSimCardMaintaining.Name = "rbtnSimCardMaintaining"
        Me.rbtnSimCardMaintaining.Size = New System.Drawing.Size(92, 17)
        Me.rbtnSimCardMaintaining.TabIndex = 0
        Me.rbtnSimCardMaintaining.TabStop = True
        Me.rbtnSimCardMaintaining.Text = "Mantenedor"
        Me.rbtnSimCardMaintaining.UseVisualStyleBackColor = False
        '
        'btnCancelSimCard
        '
        Me.btnCancelSimCard.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelSimCard.BackgroundImage = CType(resources.GetObject("btnCancelSimCard.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelSimCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelSimCard.BackgroundOnClick = CType(resources.GetObject("btnCancelSimCard.BackgroundOnClick"), System.Drawing.Image)
        Me.btnCancelSimCard.BackgroundOnDisabled = CType(resources.GetObject("btnCancelSimCard.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnCancelSimCard.BackgroundOnHover = CType(resources.GetObject("btnCancelSimCard.BackgroundOnHover"), System.Drawing.Image)
        Me.btnCancelSimCard.BackgroundOnNormal = CType(resources.GetObject("btnCancelSimCard.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnCancelSimCard.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnCancelSimCard.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnCancelSimCard.Enabled = False
        Me.btnCancelSimCard.FlatAppearance.BorderSize = 0
        Me.btnCancelSimCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancelSimCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancelSimCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelSimCard.Location = New System.Drawing.Point(399, 129)
        Me.btnCancelSimCard.Name = "btnCancelSimCard"
        Me.btnCancelSimCard.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelSimCard.TabIndex = 14
        Me.btnCancelSimCard.Text = "Cancelar"
        Me.btnCancelSimCard.UseVisualStyleBackColor = False
        '
        'btnDeleteSimCard
        '
        Me.btnDeleteSimCard.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteSimCard.BackgroundImage = CType(resources.GetObject("btnDeleteSimCard.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteSimCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteSimCard.BackgroundOnClick = CType(resources.GetObject("btnDeleteSimCard.BackgroundOnClick"), System.Drawing.Image)
        Me.btnDeleteSimCard.BackgroundOnDisabled = CType(resources.GetObject("btnDeleteSimCard.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnDeleteSimCard.BackgroundOnHover = CType(resources.GetObject("btnDeleteSimCard.BackgroundOnHover"), System.Drawing.Image)
        Me.btnDeleteSimCard.BackgroundOnNormal = CType(resources.GetObject("btnDeleteSimCard.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnDeleteSimCard.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnDeleteSimCard.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnDeleteSimCard.Enabled = False
        Me.btnDeleteSimCard.FlatAppearance.BorderSize = 0
        Me.btnDeleteSimCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteSimCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteSimCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSimCard.Location = New System.Drawing.Point(302, 129)
        Me.btnDeleteSimCard.Name = "btnDeleteSimCard"
        Me.btnDeleteSimCard.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteSimCard.TabIndex = 13
        Me.btnDeleteSimCard.Text = "Eliminar"
        Me.btnDeleteSimCard.UseVisualStyleBackColor = False
        '
        'btnSaveSimCard
        '
        Me.btnSaveSimCard.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveSimCard.BackgroundImage = CType(resources.GetObject("btnSaveSimCard.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveSimCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveSimCard.BackgroundOnClick = CType(resources.GetObject("btnSaveSimCard.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSaveSimCard.BackgroundOnDisabled = CType(resources.GetObject("btnSaveSimCard.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSaveSimCard.BackgroundOnHover = CType(resources.GetObject("btnSaveSimCard.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSaveSimCard.BackgroundOnNormal = CType(resources.GetObject("btnSaveSimCard.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSaveSimCard.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSaveSimCard.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnSaveSimCard.Enabled = False
        Me.btnSaveSimCard.FlatAppearance.BorderSize = 0
        Me.btnSaveSimCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSaveSimCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSaveSimCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveSimCard.Location = New System.Drawing.Point(205, 129)
        Me.btnSaveSimCard.Name = "btnSaveSimCard"
        Me.btnSaveSimCard.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveSimCard.TabIndex = 12
        Me.btnSaveSimCard.Text = "Guardar"
        Me.btnSaveSimCard.UseVisualStyleBackColor = False
        '
        'btnEditSimCard
        '
        Me.btnEditSimCard.BackColor = System.Drawing.Color.Transparent
        Me.btnEditSimCard.BackgroundImage = CType(resources.GetObject("btnEditSimCard.BackgroundImage"), System.Drawing.Image)
        Me.btnEditSimCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditSimCard.BackgroundOnClick = CType(resources.GetObject("btnEditSimCard.BackgroundOnClick"), System.Drawing.Image)
        Me.btnEditSimCard.BackgroundOnDisabled = CType(resources.GetObject("btnEditSimCard.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnEditSimCard.BackgroundOnHover = CType(resources.GetObject("btnEditSimCard.BackgroundOnHover"), System.Drawing.Image)
        Me.btnEditSimCard.BackgroundOnNormal = CType(resources.GetObject("btnEditSimCard.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnEditSimCard.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnEditSimCard.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnEditSimCard.Enabled = False
        Me.btnEditSimCard.FlatAppearance.BorderSize = 0
        Me.btnEditSimCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnEditSimCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnEditSimCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditSimCard.Location = New System.Drawing.Point(108, 129)
        Me.btnEditSimCard.Name = "btnEditSimCard"
        Me.btnEditSimCard.Size = New System.Drawing.Size(75, 23)
        Me.btnEditSimCard.TabIndex = 11
        Me.btnEditSimCard.Text = "Editar"
        Me.btnEditSimCard.UseVisualStyleBackColor = False
        '
        'btnNewSimCard
        '
        Me.btnNewSimCard.BackColor = System.Drawing.Color.Transparent
        Me.btnNewSimCard.BackgroundImage = CType(resources.GetObject("btnNewSimCard.BackgroundImage"), System.Drawing.Image)
        Me.btnNewSimCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNewSimCard.BackgroundOnClick = CType(resources.GetObject("btnNewSimCard.BackgroundOnClick"), System.Drawing.Image)
        Me.btnNewSimCard.BackgroundOnDisabled = CType(resources.GetObject("btnNewSimCard.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnNewSimCard.BackgroundOnHover = CType(resources.GetObject("btnNewSimCard.BackgroundOnHover"), System.Drawing.Image)
        Me.btnNewSimCard.BackgroundOnNormal = CType(resources.GetObject("btnNewSimCard.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnNewSimCard.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnNewSimCard.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnNewSimCard.FlatAppearance.BorderSize = 0
        Me.btnNewSimCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNewSimCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNewSimCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewSimCard.Location = New System.Drawing.Point(11, 129)
        Me.btnNewSimCard.Name = "btnNewSimCard"
        Me.btnNewSimCard.Size = New System.Drawing.Size(75, 23)
        Me.btnNewSimCard.TabIndex = 10
        Me.btnNewSimCard.Text = "Nuevo"
        Me.btnNewSimCard.UseVisualStyleBackColor = False
        '
        'txtMPhoneNumber
        '
        Me.txtMPhoneNumber.CaracterDecimal = False
        Me.txtMPhoneNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMPhoneNumber.Enabled = False
        Me.txtMPhoneNumber.HintText = "Hint Text"
        Me.txtMPhoneNumber.HintTextColor = System.Drawing.Color.Gray
        Me.txtMPhoneNumber.HintTextEnabled = False
        Me.txtMPhoneNumber.Location = New System.Drawing.Point(76, 52)
        Me.txtMPhoneNumber.Name = "txtMPhoneNumber"
        Me.txtMPhoneNumber.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtMPhoneNumber.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtMPhoneNumber.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtMPhoneNumber.Size = New System.Drawing.Size(120, 20)
        Me.txtMPhoneNumber.TabIndex = 3
        '
        'txtMApn
        '
        Me.txtMApn.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtMApn.Enabled = False
        Me.txtMApn.HintText = "Hint Text"
        Me.txtMApn.HintTextColor = System.Drawing.Color.Gray
        Me.txtMApn.HintTextEnabled = False
        Me.txtMApn.Location = New System.Drawing.Point(243, 52)
        Me.txtMApn.Name = "txtMApn"
        Me.txtMApn.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtMApn.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtMApn.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtMApn.Size = New System.Drawing.Size(227, 20)
        Me.txtMApn.TabIndex = 4
        '
        'txtMObservations
        '
        Me.txtMObservations.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMObservations.Enabled = False
        Me.txtMObservations.HintText = "Hint Text"
        Me.txtMObservations.HintTextColor = System.Drawing.Color.Gray
        Me.txtMObservations.HintTextEnabled = False
        Me.txtMObservations.Location = New System.Drawing.Point(112, 77)
        Me.txtMObservations.Name = "txtMObservations"
        Me.txtMObservations.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtMObservations.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtMObservations.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtMObservations.Size = New System.Drawing.Size(358, 20)
        Me.txtMObservations.TabIndex = 5
        '
        'txtMSerial
        '
        Me.txtMSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMSerial.Enabled = False
        Me.txtMSerial.HintText = "Hint Text"
        Me.txtMSerial.HintTextColor = System.Drawing.Color.Gray
        Me.txtMSerial.HintTextEnabled = False
        Me.txtMSerial.Location = New System.Drawing.Point(274, 27)
        Me.txtMSerial.Name = "txtMSerial"
        Me.txtMSerial.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtMSerial.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtMSerial.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtMSerial.Size = New System.Drawing.Size(196, 20)
        Me.txtMSerial.TabIndex = 2
        '
        'cboMOperator
        '
        Me.cboMOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMOperator.Enabled = False
        Me.cboMOperator.FormattingEnabled = True
        Me.cboMOperator.HintText = "Hint Text"
        Me.cboMOperator.HintTextColor = System.Drawing.Color.Gray
        Me.cboMOperator.HintTextEnabled = False
        Me.cboMOperator.Location = New System.Drawing.Point(87, 27)
        Me.cboMOperator.Name = "cboMOperator"
        Me.cboMOperator.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboMOperator.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboMOperator.Size = New System.Drawing.Size(127, 21)
        Me.cboMOperator.TabIndex = 1
        '
        'cboxMStatus
        '
        Me.cboxMStatus.AutoSize = True
        Me.cboxMStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cboxMStatus.Enabled = False
        Me.cboxMStatus.Location = New System.Drawing.Point(405, 105)
        Me.cboxMStatus.Name = "cboxMStatus"
        Me.cboxMStatus.Size = New System.Drawing.Size(65, 17)
        Me.cboxMStatus.TabIndex = 9
        Me.cboxMStatus.Text = "Estado"
        Me.cboxMStatus.UseVisualStyleBackColor = True
        '
        'cboxMData
        '
        Me.cboxMData.AutoSize = True
        Me.cboxMData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cboxMData.Enabled = False
        Me.cboxMData.Location = New System.Drawing.Point(245, 105)
        Me.cboxMData.Name = "cboxMData"
        Me.cboxMData.Size = New System.Drawing.Size(149, 17)
        Me.cboxMData.TabIndex = 8
        Me.cboxMData.Text = "Datos de Navegación"
        Me.cboxMData.UseVisualStyleBackColor = True
        '
        'cboxMSms
        '
        Me.cboxMSms.AutoSize = True
        Me.cboxMSms.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cboxMSms.Enabled = False
        Me.cboxMSms.Location = New System.Drawing.Point(102, 105)
        Me.cboxMSms.Name = "cboxMSms"
        Me.cboxMSms.Size = New System.Drawing.Size(133, 17)
        Me.cboxMSms.TabIndex = 7
        Me.cboxMSms.Text = "Mensajes de Texto"
        Me.cboxMSms.UseVisualStyleBackColor = True
        '
        'cboxMCall
        '
        Me.cboxMCall.AutoSize = True
        Me.cboxMCall.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cboxMCall.Enabled = False
        Me.cboxMCall.Location = New System.Drawing.Point(14, 105)
        Me.cboxMCall.Name = "cboxMCall"
        Me.cboxMCall.Size = New System.Drawing.Size(79, 17)
        Me.cboxMCall.TabIndex = 6
        Me.cboxMCall.Text = "Llamadas"
        Me.cboxMCall.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(208, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Apn"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(15, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Observaciones"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(15, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Teléfono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(15, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Operadora"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(229, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Serial"
        '
        'panelLoading
        '
        Me.panelLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelLoading.Controls.Add(Me.lblLoading)
        Me.panelLoading.Controls.Add(Me.pboxLoading)
        Me.panelLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelLoading.Location = New System.Drawing.Point(0, 591)
        Me.panelLoading.Name = "panelLoading"
        Me.panelLoading.Size = New System.Drawing.Size(482, 20)
        Me.panelLoading.TabIndex = 16
        Me.panelLoading.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLoading.Location = New System.Drawing.Point(0, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(452, 20)
        Me.lblLoading.TabIndex = 16
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSimCards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 611)
        Me.Controls.Add(Me.panelLoading)
        Me.Controls.Add(Me.dgvSimCards)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(498, 650)
        Me.Name = "frmSimCards"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIM CARDS"
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSimCards, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.gboxSimCardFiltering.ResumeLayout(False)
        Me.gboxSimCardFiltering.PerformLayout()
        Me.panelAsignedSimCard.ResumeLayout(False)
        Me.panelAsignedSimCard.PerformLayout()
        Me.panelStatusSimCard.ResumeLayout(False)
        Me.panelStatusSimCard.PerformLayout()
        Me.gboxSimCardMaintaining.ResumeLayout(False)
        Me.gboxSimCardMaintaining.PerformLayout()
        Me.panelLoading.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As ZUControls.ZUPanel
    Friend WithEvents dgvSimCards As ZUControls.ZUDataGridView
    Friend WithEvents gboxSimCardFiltering As GroupBox
    Friend WithEvents cboxFOperator As CheckBox
    Friend WithEvents gboxSimCardMaintaining As GroupBox
    Friend WithEvents rbtnSimCardMaintaining As RadioButton
    Friend WithEvents btnCancelSimCard As ZUControls.ZUButton
    Friend WithEvents btnDeleteSimCard As ZUControls.ZUButton
    Friend WithEvents btnSaveSimCard As ZUControls.ZUButton
    Friend WithEvents btnEditSimCard As ZUControls.ZUButton
    Friend WithEvents btnNewSimCard As ZUControls.ZUButton
    Friend WithEvents txtMPhoneNumber As ZUControls.ZUNumericBox
    Friend WithEvents txtMApn As ZUControls.ZUTextBox
    Friend WithEvents txtMSerial As ZUControls.ZUTextBox
    Friend WithEvents cboMOperator As ZUControls.ZUComboBox
    Friend WithEvents cboxMStatus As CheckBox
    Friend WithEvents cboxMData As CheckBox
    Friend WithEvents cboxMSms As CheckBox
    Friend WithEvents cboxMCall As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboxFSerialPhone As CheckBox
    Friend WithEvents rbtnSimCardFiltering As RadioButton
    Friend WithEvents cboxFApn As CheckBox
    Friend WithEvents rbtnFInactive As RadioButton
    Friend WithEvents rbtnFActive As RadioButton
    Friend WithEvents cboxFAsigned As CheckBox
    Friend WithEvents cboxFStatus As CheckBox
    Friend WithEvents btnExportExcel As ZUControls.ZUButton
    Friend WithEvents btnSearchSimCards As ZUControls.ZUButton
    Friend WithEvents pboxLoading As PictureBox
    Friend WithEvents panelAsignedSimCard As ZUControls.ZUPanel
    Friend WithEvents rbtnFAsignedYes As RadioButton
    Friend WithEvents rbtnFAsignedNo As RadioButton
    Friend WithEvents panelStatusSimCard As ZUControls.ZUPanel
    Friend WithEvents bgwSavingSimCard As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwDeletingSimCard As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwSearchingSimCards As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwExporting As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtMObservations As ZUControls.ZUTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblResult As Label
    Friend WithEvents dgvSimCards_operator As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_serial As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_phone_number As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_apn As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_observations As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_call_service As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_sms_service As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_data_service As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_status As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_asigned As DataGridViewTextBoxColumn
    Friend WithEvents dgvSimCards_simcard_id As DataGridViewTextBoxColumn
    Friend WithEvents txtFApn As ZUControls.ZUTextBox
    Friend WithEvents txtFSerialPhone As ZUControls.ZUNumericBox
    Friend WithEvents cboFOperator As ZUControls.ZUComboBox
    Friend WithEvents panelLoading As ZUControls.ZUPanel
    Friend WithEvents lblLoading As Label
End Class
