<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New ZUControls.ZUPanel()
        Me.gboxFecha = New System.Windows.Forms.GroupBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dtpByRangeTo = New ZUControls.ZUDatePicker()
        Me.dtpByRangeFrom = New ZUControls.ZUDatePicker()
        Me.cboxCommunicationType = New System.Windows.Forms.CheckBox()
        Me.dtpByYear = New System.Windows.Forms.DateTimePicker()
        Me.dtpByMonth = New ZUControls.ZUMonthPicker()
        Me.rbtnByYear = New System.Windows.Forms.RadioButton()
        Me.rbtnByRange = New System.Windows.Forms.RadioButton()
        Me.rbtnByMonth = New System.Windows.Forms.RadioButton()
        Me.rbtnToday = New System.Windows.Forms.RadioButton()
        Me.gboxParametros = New System.Windows.Forms.GroupBox()
        Me.btnExportExcel = New ZUControls.ZUButton()
        Me.btnSearch = New ZUControls.ZUButton()
        Me.cboReportTypes = New ZUControls.ZUComboBox()
        Me.cboUsers = New ZUControls.ZUComboBox()
        Me.cboVehicles = New ZUControls.ZUComboBox()
        Me.cboClients = New ZUControls.ZUComboBox()
        Me.cboxReportType = New System.Windows.Forms.CheckBox()
        Me.cboxUser = New System.Windows.Forms.CheckBox()
        Me.cboxVehicle = New System.Windows.Forms.CheckBox()
        Me.cboxClient = New System.Windows.Forms.CheckBox()
        Me.bgwGetClientsUsersReportTypes = New System.ComponentModel.BackgroundWorker()
        Me.panelLoading = New ZUControls.ZUPanel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.pboxLoading = New System.Windows.Forms.PictureBox()
        Me.bgwGetReports = New System.ComponentModel.BackgroundWorker()
        Me.dgvReports = New ZUControls.ZUDataGridView()
        Me.dgvReports_client_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_license_plate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_date_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_user_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_report_type_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_communication_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_transmitter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_receiver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_validation_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_report_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_client_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_vehicle_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_user_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvReports_report_type_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bgwExporting = New System.ComponentModel.BackgroundWorker()
        Me.panelHeader.SuspendLayout()
        Me.gboxFecha.SuspendLayout()
        Me.gboxParametros.SuspendLayout()
        Me.panelLoading.SuspendLayout()
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.Controls.Add(Me.gboxFecha)
        Me.panelHeader.Controls.Add(Me.gboxParametros)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1050, 172)
        Me.panelHeader.TabIndex = 0
        '
        'gboxFecha
        '
        Me.gboxFecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gboxFecha.Controls.Add(Me.label2)
        Me.gboxFecha.Controls.Add(Me.label1)
        Me.gboxFecha.Controls.Add(Me.dtpByRangeTo)
        Me.gboxFecha.Controls.Add(Me.dtpByRangeFrom)
        Me.gboxFecha.Controls.Add(Me.cboxCommunicationType)
        Me.gboxFecha.Controls.Add(Me.dtpByYear)
        Me.gboxFecha.Controls.Add(Me.dtpByMonth)
        Me.gboxFecha.Controls.Add(Me.rbtnByYear)
        Me.gboxFecha.Controls.Add(Me.rbtnByRange)
        Me.gboxFecha.Controls.Add(Me.rbtnByMonth)
        Me.gboxFecha.Controls.Add(Me.rbtnToday)
        Me.gboxFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxFecha.Location = New System.Drawing.Point(114, 5)
        Me.gboxFecha.Name = "gboxFecha"
        Me.gboxFecha.Size = New System.Drawing.Size(408, 162)
        Me.gboxFecha.TabIndex = 1
        Me.gboxFecha.TabStop = False
        Me.gboxFecha.Text = "Fecha"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(68, 108)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(36, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Hasta"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(65, 80)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(39, 13)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Desde"
        '
        'dtpByRangeTo
        '
        Me.dtpByRangeTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpByRangeTo.Enabled = False
        Me.dtpByRangeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpByRangeTo.Location = New System.Drawing.Point(110, 105)
        Me.dtpByRangeTo.MaxDate = New Date(2020, 10, 4, 8, 58, 0, 0)
        Me.dtpByRangeTo.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpByRangeTo.Name = "dtpByRangeTo"
        Me.dtpByRangeTo.Size = New System.Drawing.Size(292, 20)
        Me.dtpByRangeTo.TabIndex = 6
        Me.dtpByRangeTo.Value = New Date(2016, 10, 1, 0, 0, 0, 0)
        '
        'dtpByRangeFrom
        '
        Me.dtpByRangeFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpByRangeFrom.Enabled = False
        Me.dtpByRangeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpByRangeFrom.Location = New System.Drawing.Point(110, 77)
        Me.dtpByRangeFrom.MaxDate = New Date(2020, 10, 4, 8, 58, 0, 0)
        Me.dtpByRangeFrom.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpByRangeFrom.Name = "dtpByRangeFrom"
        Me.dtpByRangeFrom.Size = New System.Drawing.Size(292, 20)
        Me.dtpByRangeFrom.TabIndex = 5
        Me.dtpByRangeFrom.Value = New Date(2016, 10, 1, 0, 0, 0, 0)
        '
        'cboxCommunicationType
        '
        Me.cboxCommunicationType.AutoSize = True
        Me.cboxCommunicationType.ForeColor = System.Drawing.Color.Black
        Me.cboxCommunicationType.Location = New System.Drawing.Point(209, 137)
        Me.cboxCommunicationType.Name = "cboxCommunicationType"
        Me.cboxCommunicationType.Size = New System.Drawing.Size(193, 17)
        Me.cboxCommunicationType.TabIndex = 8
        Me.cboxCommunicationType.Text = "Mostrar Vía de Comunicación"
        Me.cboxCommunicationType.UseVisualStyleBackColor = True
        '
        'dtpByYear
        '
        Me.dtpByYear.CustomFormat = "yyyy"
        Me.dtpByYear.Enabled = False
        Me.dtpByYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpByYear.Location = New System.Drawing.Point(59, 49)
        Me.dtpByYear.Name = "dtpByYear"
        Me.dtpByYear.ShowUpDown = True
        Me.dtpByYear.Size = New System.Drawing.Size(343, 20)
        Me.dtpByYear.TabIndex = 3
        '
        'dtpByMonth
        '
        Me.dtpByMonth.CustomFormat = "MMMM yyyy"
        Me.dtpByMonth.Enabled = False
        Me.dtpByMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpByMonth.Location = New System.Drawing.Point(59, 19)
        Me.dtpByMonth.MaxDate = New Date(2020, 10, 4, 8, 53, 0, 0)
        Me.dtpByMonth.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpByMonth.Name = "dtpByMonth"
        Me.dtpByMonth.ShowUpDown = True
        Me.dtpByMonth.Size = New System.Drawing.Size(343, 20)
        Me.dtpByMonth.TabIndex = 1
        Me.dtpByMonth.Value = New Date(2016, 10, 1, 0, 0, 0, 0)
        '
        'rbtnByYear
        '
        Me.rbtnByYear.AutoSize = True
        Me.rbtnByYear.ForeColor = System.Drawing.Color.Black
        Me.rbtnByYear.Location = New System.Drawing.Point(6, 50)
        Me.rbtnByYear.Name = "rbtnByYear"
        Me.rbtnByYear.Size = New System.Drawing.Size(47, 17)
        Me.rbtnByYear.TabIndex = 2
        Me.rbtnByYear.Text = "Año"
        Me.rbtnByYear.UseVisualStyleBackColor = True
        '
        'rbtnByRange
        '
        Me.rbtnByRange.AutoSize = True
        Me.rbtnByRange.ForeColor = System.Drawing.Color.Black
        Me.rbtnByRange.Location = New System.Drawing.Point(6, 78)
        Me.rbtnByRange.Name = "rbtnByRange"
        Me.rbtnByRange.Size = New System.Drawing.Size(62, 17)
        Me.rbtnByRange.TabIndex = 4
        Me.rbtnByRange.Text = "Rango"
        Me.rbtnByRange.UseVisualStyleBackColor = True
        '
        'rbtnByMonth
        '
        Me.rbtnByMonth.AutoSize = True
        Me.rbtnByMonth.ForeColor = System.Drawing.Color.Black
        Me.rbtnByMonth.Location = New System.Drawing.Point(6, 20)
        Me.rbtnByMonth.Name = "rbtnByMonth"
        Me.rbtnByMonth.Size = New System.Drawing.Size(48, 17)
        Me.rbtnByMonth.TabIndex = 0
        Me.rbtnByMonth.Text = "Mes"
        Me.rbtnByMonth.UseVisualStyleBackColor = True
        '
        'rbtnToday
        '
        Me.rbtnToday.AutoSize = True
        Me.rbtnToday.Checked = True
        Me.rbtnToday.ForeColor = System.Drawing.Color.Black
        Me.rbtnToday.Location = New System.Drawing.Point(6, 136)
        Me.rbtnToday.Name = "rbtnToday"
        Me.rbtnToday.Size = New System.Drawing.Size(47, 17)
        Me.rbtnToday.TabIndex = 7
        Me.rbtnToday.TabStop = True
        Me.rbtnToday.Text = "Hoy"
        Me.rbtnToday.UseVisualStyleBackColor = True
        '
        'gboxParametros
        '
        Me.gboxParametros.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gboxParametros.Controls.Add(Me.btnExportExcel)
        Me.gboxParametros.Controls.Add(Me.btnSearch)
        Me.gboxParametros.Controls.Add(Me.cboReportTypes)
        Me.gboxParametros.Controls.Add(Me.cboUsers)
        Me.gboxParametros.Controls.Add(Me.cboVehicles)
        Me.gboxParametros.Controls.Add(Me.cboClients)
        Me.gboxParametros.Controls.Add(Me.cboxReportType)
        Me.gboxParametros.Controls.Add(Me.cboxUser)
        Me.gboxParametros.Controls.Add(Me.cboxVehicle)
        Me.gboxParametros.Controls.Add(Me.cboxClient)
        Me.gboxParametros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxParametros.Location = New System.Drawing.Point(528, 5)
        Me.gboxParametros.Name = "gboxParametros"
        Me.gboxParametros.Size = New System.Drawing.Size(408, 162)
        Me.gboxParametros.TabIndex = 0
        Me.gboxParametros.TabStop = False
        Me.gboxParametros.Text = "Parámetros"
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
        Me.btnExportExcel.ForeColor = System.Drawing.Color.Black
        Me.btnExportExcel.Location = New System.Drawing.Point(157, 130)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(115, 28)
        Me.btnExportExcel.TabIndex = 13
        Me.btnExportExcel.Text = "Exportar a Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearch.BackgroundOnClick = CType(resources.GetObject("btnSearch.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSearch.BackgroundOnDisabled = CType(resources.GetObject("btnSearch.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSearch.BackgroundOnHover = CType(resources.GetObject("btnSearch.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSearch.BackgroundOnNormal = CType(resources.GetObject("btnSearch.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSearch.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSearch.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(278, 130)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(121, 28)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Buscar Reportes"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cboReportTypes
        '
        Me.cboReportTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportTypes.Enabled = False
        Me.cboReportTypes.ForeColor = System.Drawing.Color.Black
        Me.cboReportTypes.FormattingEnabled = True
        Me.cboReportTypes.HintText = "Hint Text"
        Me.cboReportTypes.HintTextColor = System.Drawing.Color.Gray
        Me.cboReportTypes.HintTextEnabled = False
        Me.cboReportTypes.Location = New System.Drawing.Point(115, 106)
        Me.cboReportTypes.Name = "cboReportTypes"
        Me.cboReportTypes.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboReportTypes.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboReportTypes.Size = New System.Drawing.Size(284, 21)
        Me.cboReportTypes.TabIndex = 7
        '
        'cboUsers
        '
        Me.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsers.Enabled = False
        Me.cboUsers.ForeColor = System.Drawing.Color.Black
        Me.cboUsers.FormattingEnabled = True
        Me.cboUsers.HintText = "Hint Text"
        Me.cboUsers.HintTextColor = System.Drawing.Color.Gray
        Me.cboUsers.HintTextEnabled = False
        Me.cboUsers.Location = New System.Drawing.Point(84, 77)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboUsers.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboUsers.Size = New System.Drawing.Size(315, 21)
        Me.cboUsers.TabIndex = 5
        '
        'cboVehicles
        '
        Me.cboVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVehicles.Enabled = False
        Me.cboVehicles.ForeColor = System.Drawing.Color.Black
        Me.cboVehicles.FormattingEnabled = True
        Me.cboVehicles.HintText = "Hint Text"
        Me.cboVehicles.HintTextColor = System.Drawing.Color.Gray
        Me.cboVehicles.HintTextEnabled = False
        Me.cboVehicles.Location = New System.Drawing.Point(92, 49)
        Me.cboVehicles.Name = "cboVehicles"
        Me.cboVehicles.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboVehicles.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboVehicles.Size = New System.Drawing.Size(307, 21)
        Me.cboVehicles.TabIndex = 3
        '
        'cboClients
        '
        Me.cboClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClients.Enabled = False
        Me.cboClients.ForeColor = System.Drawing.Color.Black
        Me.cboClients.FormattingEnabled = True
        Me.cboClients.HintText = "Hint Text"
        Me.cboClients.HintTextColor = System.Drawing.Color.Gray
        Me.cboClients.HintTextEnabled = False
        Me.cboClients.Location = New System.Drawing.Point(80, 19)
        Me.cboClients.Name = "cboClients"
        Me.cboClients.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboClients.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboClients.Size = New System.Drawing.Size(319, 21)
        Me.cboClients.TabIndex = 1
        '
        'cboxReportType
        '
        Me.cboxReportType.AutoSize = True
        Me.cboxReportType.ForeColor = System.Drawing.Color.Black
        Me.cboxReportType.Location = New System.Drawing.Point(9, 108)
        Me.cboxReportType.Name = "cboxReportType"
        Me.cboxReportType.Size = New System.Drawing.Size(100, 17)
        Me.cboxReportType.TabIndex = 6
        Me.cboxReportType.Text = "Tipo Reporte"
        Me.cboxReportType.UseVisualStyleBackColor = True
        '
        'cboxUser
        '
        Me.cboxUser.AutoSize = True
        Me.cboxUser.ForeColor = System.Drawing.Color.Black
        Me.cboxUser.Location = New System.Drawing.Point(9, 79)
        Me.cboxUser.Name = "cboxUser"
        Me.cboxUser.Size = New System.Drawing.Size(69, 17)
        Me.cboxUser.TabIndex = 4
        Me.cboxUser.Text = "Usuario"
        Me.cboxUser.UseVisualStyleBackColor = True
        '
        'cboxVehicle
        '
        Me.cboxVehicle.AutoSize = True
        Me.cboxVehicle.Enabled = False
        Me.cboxVehicle.ForeColor = System.Drawing.Color.Black
        Me.cboxVehicle.Location = New System.Drawing.Point(9, 51)
        Me.cboxVehicle.Name = "cboxVehicle"
        Me.cboxVehicle.Size = New System.Drawing.Size(77, 17)
        Me.cboxVehicle.TabIndex = 2
        Me.cboxVehicle.Text = "Vehículo"
        Me.cboxVehicle.UseVisualStyleBackColor = True
        '
        'cboxClient
        '
        Me.cboxClient.AutoSize = True
        Me.cboxClient.ForeColor = System.Drawing.Color.Black
        Me.cboxClient.Location = New System.Drawing.Point(9, 21)
        Me.cboxClient.Name = "cboxClient"
        Me.cboxClient.Size = New System.Drawing.Size(65, 17)
        Me.cboxClient.TabIndex = 0
        Me.cboxClient.Text = "Cliente"
        Me.cboxClient.UseVisualStyleBackColor = True
        '
        'bgwGetClientsUsersReportTypes
        '
        Me.bgwGetClientsUsersReportTypes.WorkerReportsProgress = True
        Me.bgwGetClientsUsersReportTypes.WorkerSupportsCancellation = True
        '
        'panelLoading
        '
        Me.panelLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelLoading.Controls.Add(Me.lblLoading)
        Me.panelLoading.Controls.Add(Me.pboxLoading)
        Me.panelLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelLoading.Location = New System.Drawing.Point(0, 545)
        Me.panelLoading.Name = "panelLoading"
        Me.panelLoading.Size = New System.Drawing.Size(1050, 20)
        Me.panelLoading.TabIndex = 18
        '
        'lblLoading
        '
        Me.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLoading.Location = New System.Drawing.Point(0, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(1020, 20)
        Me.lblLoading.TabIndex = 16
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pboxLoading
        '
        Me.pboxLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pboxLoading.Dock = System.Windows.Forms.DockStyle.Right
        Me.pboxLoading.Image = Global.ZUtracking.My.Resources.Resources.loading
        Me.pboxLoading.Location = New System.Drawing.Point(1020, 0)
        Me.pboxLoading.Name = "pboxLoading"
        Me.pboxLoading.Size = New System.Drawing.Size(30, 20)
        Me.pboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxLoading.TabIndex = 15
        Me.pboxLoading.TabStop = False
        Me.pboxLoading.Visible = False
        '
        'bgwGetReports
        '
        Me.bgwGetReports.WorkerReportsProgress = True
        Me.bgwGetReports.WorkerSupportsCancellation = True
        '
        'dgvReports
        '
        Me.dgvReports.AllowUserToAddRows = False
        Me.dgvReports.AllowUserToDeleteRows = False
        Me.dgvReports.AllowUserToResizeColumns = False
        Me.dgvReports.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        Me.dgvReports.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvReports.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvReports.BackgroundHeader = CType(resources.GetObject("dgvReports.BackgroundHeader"), System.Drawing.Image)
        Me.dgvReports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReports.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvReports_client_name, Me.dgvReports_license_plate, Me.dgvReports_date_time, Me.dgvReports_user_name, Me.dgvReports_report_type_name, Me.dgvReports_communication_type, Me.dgvReports_transmitter, Me.dgvReports_receiver, Me.dgvReports_description, Me.dgvReports_validation_date, Me.dgvReports_report_id, Me.dgvReports_client_id, Me.dgvReports_vehicle_id, Me.dgvReports_user_id, Me.dgvReports_report_type_id})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReports.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReports.GridColor = System.Drawing.SystemColors.Control
        Me.dgvReports.HeaderFontSize = 7.0!
        Me.dgvReports.HeaderForeColor = System.Drawing.Color.White
        Me.dgvReports.Location = New System.Drawing.Point(0, 172)
        Me.dgvReports.MultiSelect = False
        Me.dgvReports.Name = "dgvReports"
        Me.dgvReports.ReadOnly = True
        Me.dgvReports.RowHeadersVisible = False
        Me.dgvReports.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReports.Size = New System.Drawing.Size(1050, 373)
        Me.dgvReports.TabIndex = 19
        '
        'dgvReports_client_name
        '
        Me.dgvReports_client_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReports_client_name.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReports_client_name.HeaderText = "CLIENTE"
        Me.dgvReports_client_name.Name = "dgvReports_client_name"
        Me.dgvReports_client_name.ReadOnly = True
        Me.dgvReports_client_name.Width = 250
        '
        'dgvReports_license_plate
        '
        Me.dgvReports_license_plate.HeaderText = "MATRÍCULA"
        Me.dgvReports_license_plate.Name = "dgvReports_license_plate"
        Me.dgvReports_license_plate.ReadOnly = True
        Me.dgvReports_license_plate.Width = 103
        '
        'dgvReports_date_time
        '
        DataGridViewCellStyle4.Format = "g"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.dgvReports_date_time.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReports_date_time.HeaderText = "FECHA / HORA"
        Me.dgvReports_date_time.Name = "dgvReports_date_time"
        Me.dgvReports_date_time.ReadOnly = True
        Me.dgvReports_date_time.Width = 121
        '
        'dgvReports_user_name
        '
        Me.dgvReports_user_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReports_user_name.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReports_user_name.HeaderText = "USUARIO"
        Me.dgvReports_user_name.Name = "dgvReports_user_name"
        Me.dgvReports_user_name.ReadOnly = True
        Me.dgvReports_user_name.Width = 250
        '
        'dgvReports_report_type_name
        '
        Me.dgvReports_report_type_name.HeaderText = "TIPO REPORTE"
        Me.dgvReports_report_type_name.Name = "dgvReports_report_type_name"
        Me.dgvReports_report_type_name.ReadOnly = True
        Me.dgvReports_report_type_name.Width = 124
        '
        'dgvReports_communication_type
        '
        Me.dgvReports_communication_type.HeaderText = "TIPO COMUNICACIÓN"
        Me.dgvReports_communication_type.Name = "dgvReports_communication_type"
        Me.dgvReports_communication_type.ReadOnly = True
        Me.dgvReports_communication_type.Visible = False
        Me.dgvReports_communication_type.Width = 160
        '
        'dgvReports_transmitter
        '
        Me.dgvReports_transmitter.HeaderText = "REMITENTE"
        Me.dgvReports_transmitter.Name = "dgvReports_transmitter"
        Me.dgvReports_transmitter.ReadOnly = True
        Me.dgvReports_transmitter.Width = 104
        '
        'dgvReports_receiver
        '
        Me.dgvReports_receiver.HeaderText = "RECIPIENTE"
        Me.dgvReports_receiver.Name = "dgvReports_receiver"
        Me.dgvReports_receiver.ReadOnly = True
        Me.dgvReports_receiver.Width = 106
        '
        'dgvReports_description
        '
        Me.dgvReports_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReports_description.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvReports_description.HeaderText = "DESCRIPCIÓN"
        Me.dgvReports_description.Name = "dgvReports_description"
        Me.dgvReports_description.ReadOnly = True
        '
        'dgvReports_validation_date
        '
        Me.dgvReports_validation_date.HeaderText = "VALIDACIÓN"
        Me.dgvReports_validation_date.Name = "dgvReports_validation_date"
        Me.dgvReports_validation_date.ReadOnly = True
        Me.dgvReports_validation_date.Visible = False
        Me.dgvReports_validation_date.Width = 106
        '
        'dgvReports_report_id
        '
        Me.dgvReports_report_id.HeaderText = "ID REPORTE"
        Me.dgvReports_report_id.Name = "dgvReports_report_id"
        Me.dgvReports_report_id.ReadOnly = True
        Me.dgvReports_report_id.Visible = False
        Me.dgvReports_report_id.Width = 108
        '
        'dgvReports_client_id
        '
        Me.dgvReports_client_id.HeaderText = "ID CLIENTE"
        Me.dgvReports_client_id.Name = "dgvReports_client_id"
        Me.dgvReports_client_id.ReadOnly = True
        Me.dgvReports_client_id.Visible = False
        Me.dgvReports_client_id.Width = 101
        '
        'dgvReports_vehicle_id
        '
        Me.dgvReports_vehicle_id.HeaderText = "ID VEHÍCULO"
        Me.dgvReports_vehicle_id.Name = "dgvReports_vehicle_id"
        Me.dgvReports_vehicle_id.ReadOnly = True
        Me.dgvReports_vehicle_id.Visible = False
        Me.dgvReports_vehicle_id.Width = 111
        '
        'dgvReports_user_id
        '
        Me.dgvReports_user_id.HeaderText = "ID USUARIO"
        Me.dgvReports_user_id.Name = "dgvReports_user_id"
        Me.dgvReports_user_id.ReadOnly = True
        Me.dgvReports_user_id.Visible = False
        Me.dgvReports_user_id.Width = 105
        '
        'dgvReports_report_type_id
        '
        Me.dgvReports_report_type_id.HeaderText = "ID TIPO REPORTE"
        Me.dgvReports_report_type_id.Name = "dgvReports_report_type_id"
        Me.dgvReports_report_type_id.ReadOnly = True
        Me.dgvReports_report_type_id.Visible = False
        Me.dgvReports_report_type_id.Width = 141
        '
        'bgwExporting
        '
        Me.bgwExporting.WorkerReportsProgress = True
        Me.bgwExporting.WorkerSupportsCancellation = True
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 565)
        Me.Controls.Add(Me.dgvReports)
        Me.Controls.Add(Me.panelLoading)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1066, 604)
        Me.Name = "frmReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTES"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelHeader.ResumeLayout(False)
        Me.gboxFecha.ResumeLayout(False)
        Me.gboxFecha.PerformLayout()
        Me.gboxParametros.ResumeLayout(False)
        Me.gboxParametros.PerformLayout()
        Me.panelLoading.ResumeLayout(False)
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As ZUControls.ZUPanel
    Private WithEvents btnSearch As ZUControls.ZUButton
    Private WithEvents gboxFecha As GroupBox
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Private WithEvents dtpByRangeTo As ZUControls.ZUDatePicker
    Private WithEvents dtpByRangeFrom As ZUControls.ZUDatePicker
    Private WithEvents dtpByYear As DateTimePicker
    Private WithEvents dtpByMonth As ZUControls.ZUMonthPicker
    Private WithEvents rbtnByYear As RadioButton
    Private WithEvents rbtnByRange As RadioButton
    Private WithEvents rbtnByMonth As RadioButton
    Private WithEvents rbtnToday As RadioButton
    Private WithEvents gboxParametros As GroupBox
    Private WithEvents cboReportTypes As ZUControls.ZUComboBox
    Private WithEvents cboUsers As ZUControls.ZUComboBox
    Private WithEvents cboVehicles As ZUControls.ZUComboBox
    Private WithEvents cboClients As ZUControls.ZUComboBox
    Private WithEvents cboxCommunicationType As CheckBox
    Private WithEvents cboxReportType As CheckBox
    Private WithEvents cboxUser As CheckBox
    Private WithEvents cboxVehicle As CheckBox
    Private WithEvents cboxClient As CheckBox
    Friend WithEvents bgwGetClientsUsersReportTypes As System.ComponentModel.BackgroundWorker
    Friend WithEvents panelLoading As ZUControls.ZUPanel
    Friend WithEvents lblLoading As Label
    Friend WithEvents pboxLoading As PictureBox
    Friend WithEvents bgwGetReports As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvReports As ZUControls.ZUDataGridView
    Friend WithEvents dgvReports_client_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_license_plate As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_date_time As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_user_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_report_type_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_communication_type As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_transmitter As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_receiver As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_description As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_validation_date As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_report_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_client_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_vehicle_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_user_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvReports_report_type_id As DataGridViewTextBoxColumn
    Friend WithEvents btnExportExcel As ZUControls.ZUButton
    Friend WithEvents bgwExporting As System.ComponentModel.BackgroundWorker
End Class
