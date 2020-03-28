<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEventHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEventHistory))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New ZUControls.ZUPanel()
        Me.gboxDates = New System.Windows.Forms.GroupBox()
        Me.dtpByRangeTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpByRangeFrom = New System.Windows.Forms.DateTimePicker()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dtpByYear = New System.Windows.Forms.DateTimePicker()
        Me.dtpByMonth = New ZUControls.ZUMonthPicker()
        Me.rbtnByYear = New System.Windows.Forms.RadioButton()
        Me.rbtnByRange = New System.Windows.Forms.RadioButton()
        Me.rbtnByMonth = New System.Windows.Forms.RadioButton()
        Me.rbtnToday = New System.Windows.Forms.RadioButton()
        Me.gboxParameters = New System.Windows.Forms.GroupBox()
        Me.btnExportExcel = New ZUControls.ZUButton()
        Me.btnSearch = New ZUControls.ZUButton()
        Me.cboEvents = New ZUControls.ZUComboBox()
        Me.cboVehicles = New ZUControls.ZUComboBox()
        Me.cboClients = New ZUControls.ZUComboBox()
        Me.cboxEvent = New System.Windows.Forms.CheckBox()
        Me.cboxVehicle = New System.Windows.Forms.CheckBox()
        Me.cboxClient = New System.Windows.Forms.CheckBox()
        Me.dgvEvents = New ZUControls.ZUDataGridView()
        Me.dgvEvents_client_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_license_plate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_imei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_date_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_latitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_longitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_event_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_client_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_vehicle_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_device_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_event_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEvents_geofence_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelLoading = New ZUControls.ZUPanel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.pboxLoading = New System.Windows.Forms.PictureBox()
        Me.bgwGetClients = New System.ComponentModel.BackgroundWorker()
        Me.bgwGetEvents = New System.ComponentModel.BackgroundWorker()
        Me.bgwExporting = New System.ComponentModel.BackgroundWorker()
        Me.panelHeader.SuspendLayout()
        Me.gboxDates.SuspendLayout()
        Me.gboxParameters.SuspendLayout()
        CType(Me.dgvEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLoading.SuspendLayout()
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.Controls.Add(Me.gboxDates)
        Me.panelHeader.Controls.Add(Me.gboxParameters)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1048, 149)
        Me.panelHeader.TabIndex = 0
        '
        'gboxDates
        '
        Me.gboxDates.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gboxDates.Controls.Add(Me.dtpByRangeTo)
        Me.gboxDates.Controls.Add(Me.dtpByRangeFrom)
        Me.gboxDates.Controls.Add(Me.label2)
        Me.gboxDates.Controls.Add(Me.label1)
        Me.gboxDates.Controls.Add(Me.dtpByYear)
        Me.gboxDates.Controls.Add(Me.dtpByMonth)
        Me.gboxDates.Controls.Add(Me.rbtnByYear)
        Me.gboxDates.Controls.Add(Me.rbtnByRange)
        Me.gboxDates.Controls.Add(Me.rbtnByMonth)
        Me.gboxDates.Controls.Add(Me.rbtnToday)
        Me.gboxDates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxDates.Location = New System.Drawing.Point(113, 5)
        Me.gboxDates.Name = "gboxDates"
        Me.gboxDates.Size = New System.Drawing.Size(408, 141)
        Me.gboxDates.TabIndex = 0
        Me.gboxDates.TabStop = False
        Me.gboxDates.Text = "Fecha"
        '
        'dtpByRangeTo
        '
        Me.dtpByRangeTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpByRangeTo.Enabled = False
        Me.dtpByRangeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpByRangeTo.Location = New System.Drawing.Point(110, 91)
        Me.dtpByRangeTo.Name = "dtpByRangeTo"
        Me.dtpByRangeTo.Size = New System.Drawing.Size(292, 20)
        Me.dtpByRangeTo.TabIndex = 6
        '
        'dtpByRangeFrom
        '
        Me.dtpByRangeFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpByRangeFrom.Enabled = False
        Me.dtpByRangeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpByRangeFrom.Location = New System.Drawing.Point(110, 67)
        Me.dtpByRangeFrom.Name = "dtpByRangeFrom"
        Me.dtpByRangeFrom.Size = New System.Drawing.Size(292, 20)
        Me.dtpByRangeFrom.TabIndex = 5
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(68, 94)
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
        Me.label1.Location = New System.Drawing.Point(65, 70)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(39, 13)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Desde"
        '
        'dtpByYear
        '
        Me.dtpByYear.CustomFormat = "yyyy"
        Me.dtpByYear.Enabled = False
        Me.dtpByYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpByYear.Location = New System.Drawing.Point(59, 43)
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
        Me.rbtnByYear.Location = New System.Drawing.Point(6, 44)
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
        Me.rbtnByRange.Location = New System.Drawing.Point(6, 68)
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
        Me.rbtnToday.Location = New System.Drawing.Point(6, 118)
        Me.rbtnToday.Name = "rbtnToday"
        Me.rbtnToday.Size = New System.Drawing.Size(47, 17)
        Me.rbtnToday.TabIndex = 7
        Me.rbtnToday.TabStop = True
        Me.rbtnToday.Text = "Hoy"
        Me.rbtnToday.UseVisualStyleBackColor = True
        '
        'gboxParameters
        '
        Me.gboxParameters.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gboxParameters.Controls.Add(Me.btnExportExcel)
        Me.gboxParameters.Controls.Add(Me.btnSearch)
        Me.gboxParameters.Controls.Add(Me.cboEvents)
        Me.gboxParameters.Controls.Add(Me.cboVehicles)
        Me.gboxParameters.Controls.Add(Me.cboClients)
        Me.gboxParameters.Controls.Add(Me.cboxEvent)
        Me.gboxParameters.Controls.Add(Me.cboxVehicle)
        Me.gboxParameters.Controls.Add(Me.cboxClient)
        Me.gboxParameters.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxParameters.Location = New System.Drawing.Point(527, 5)
        Me.gboxParameters.Name = "gboxParameters"
        Me.gboxParameters.Size = New System.Drawing.Size(408, 141)
        Me.gboxParameters.TabIndex = 1
        Me.gboxParameters.TabStop = False
        Me.gboxParameters.Text = "Parámetros"
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
        Me.btnExportExcel.Location = New System.Drawing.Point(168, 104)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(115, 31)
        Me.btnExportExcel.TabIndex = 12
        Me.btnExportExcel.Text = "Exportar a Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
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
        Me.btnSearch.Location = New System.Drawing.Point(289, 104)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(110, 31)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Buscar Eventos"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cboEvents
        '
        Me.cboEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEvents.Enabled = False
        Me.cboEvents.ForeColor = System.Drawing.Color.Black
        Me.cboEvents.FormattingEnabled = True
        Me.cboEvents.HintText = "Hint Text"
        Me.cboEvents.HintTextColor = System.Drawing.Color.Gray
        Me.cboEvents.HintTextEnabled = False
        Me.cboEvents.Items.AddRange(New Object() {"BATERÍA", "GEOCERCA", "VELOCIDAD", "IGNICIÓN", "MOVIMIENTO"})
        Me.cboEvents.Location = New System.Drawing.Point(84, 77)
        Me.cboEvents.Name = "cboEvents"
        Me.cboEvents.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboEvents.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboEvents.Size = New System.Drawing.Size(315, 21)
        Me.cboEvents.TabIndex = 5
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
        'cboxEvent
        '
        Me.cboxEvent.AutoSize = True
        Me.cboxEvent.ForeColor = System.Drawing.Color.Black
        Me.cboxEvent.Location = New System.Drawing.Point(9, 79)
        Me.cboxEvent.Name = "cboxEvent"
        Me.cboxEvent.Size = New System.Drawing.Size(66, 17)
        Me.cboxEvent.TabIndex = 4
        Me.cboxEvent.Text = "Evento"
        Me.cboxEvent.UseVisualStyleBackColor = True
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
        'dgvEvents
        '
        Me.dgvEvents.AllowUserToAddRows = False
        Me.dgvEvents.AllowUserToDeleteRows = False
        Me.dgvEvents.AllowUserToResizeColumns = False
        Me.dgvEvents.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        Me.dgvEvents.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEvents.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvEvents.BackgroundHeader = CType(resources.GetObject("dgvEvents.BackgroundHeader"), System.Drawing.Image)
        Me.dgvEvents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEvents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvEvents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEvents.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEvents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEvents_client_name, Me.dgvEvents_license_plate, Me.dgvEvents_imei, Me.dgvEvents_date_time, Me.dgvEvents_latitude, Me.dgvEvents_longitude, Me.dgvEvents_event_name, Me.dgvEvents_client_id, Me.dgvEvents_vehicle_id, Me.dgvEvents_device_id, Me.dgvEvents_event_id, Me.dgvEvents_geofence_id})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEvents.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEvents.GridColor = System.Drawing.SystemColors.Control
        Me.dgvEvents.HeaderFontSize = 7.0!
        Me.dgvEvents.HeaderForeColor = System.Drawing.Color.White
        Me.dgvEvents.Location = New System.Drawing.Point(0, 149)
        Me.dgvEvents.MultiSelect = False
        Me.dgvEvents.Name = "dgvEvents"
        Me.dgvEvents.ReadOnly = True
        Me.dgvEvents.RowHeadersVisible = False
        Me.dgvEvents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEvents.Size = New System.Drawing.Size(1048, 425)
        Me.dgvEvents.TabIndex = 0
        '
        'dgvEvents_client_name
        '
        Me.dgvEvents_client_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvEvents_client_name.HeaderText = "CLIENTE"
        Me.dgvEvents_client_name.Name = "dgvEvents_client_name"
        Me.dgvEvents_client_name.ReadOnly = True
        '
        'dgvEvents_license_plate
        '
        Me.dgvEvents_license_plate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvEvents_license_plate.HeaderText = "MATRÍCULA"
        Me.dgvEvents_license_plate.Name = "dgvEvents_license_plate"
        Me.dgvEvents_license_plate.ReadOnly = True
        Me.dgvEvents_license_plate.Width = 120
        '
        'dgvEvents_imei
        '
        Me.dgvEvents_imei.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvEvents_imei.HeaderText = "IMEI"
        Me.dgvEvents_imei.Name = "dgvEvents_imei"
        Me.dgvEvents_imei.ReadOnly = True
        Me.dgvEvents_imei.Width = 150
        '
        'dgvEvents_date_time
        '
        Me.dgvEvents_date_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvEvents_date_time.HeaderText = "FECHA / HORA"
        Me.dgvEvents_date_time.Name = "dgvEvents_date_time"
        Me.dgvEvents_date_time.ReadOnly = True
        Me.dgvEvents_date_time.Width = 200
        '
        'dgvEvents_latitude
        '
        Me.dgvEvents_latitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvEvents_latitude.HeaderText = "LATITUD"
        Me.dgvEvents_latitude.Name = "dgvEvents_latitude"
        Me.dgvEvents_latitude.ReadOnly = True
        '
        'dgvEvents_longitude
        '
        Me.dgvEvents_longitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvEvents_longitude.HeaderText = "LONGITUD"
        Me.dgvEvents_longitude.Name = "dgvEvents_longitude"
        Me.dgvEvents_longitude.ReadOnly = True
        '
        'dgvEvents_event_name
        '
        Me.dgvEvents_event_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvEvents_event_name.HeaderText = "EVENTO"
        Me.dgvEvents_event_name.Name = "dgvEvents_event_name"
        Me.dgvEvents_event_name.ReadOnly = True
        '
        'dgvEvents_client_id
        '
        Me.dgvEvents_client_id.HeaderText = "ID CLIENTE"
        Me.dgvEvents_client_id.Name = "dgvEvents_client_id"
        Me.dgvEvents_client_id.ReadOnly = True
        Me.dgvEvents_client_id.Visible = False
        '
        'dgvEvents_vehicle_id
        '
        Me.dgvEvents_vehicle_id.HeaderText = "ID VEHICULO"
        Me.dgvEvents_vehicle_id.Name = "dgvEvents_vehicle_id"
        Me.dgvEvents_vehicle_id.ReadOnly = True
        Me.dgvEvents_vehicle_id.Visible = False
        '
        'dgvEvents_device_id
        '
        Me.dgvEvents_device_id.HeaderText = "ID DISPOSITIVO"
        Me.dgvEvents_device_id.Name = "dgvEvents_device_id"
        Me.dgvEvents_device_id.ReadOnly = True
        Me.dgvEvents_device_id.Visible = False
        '
        'dgvEvents_event_id
        '
        Me.dgvEvents_event_id.HeaderText = "ID EVENTO"
        Me.dgvEvents_event_id.Name = "dgvEvents_event_id"
        Me.dgvEvents_event_id.ReadOnly = True
        Me.dgvEvents_event_id.Visible = False
        '
        'dgvEvents_geofence_id
        '
        Me.dgvEvents_geofence_id.HeaderText = "ID GEOCERCA"
        Me.dgvEvents_geofence_id.Name = "dgvEvents_geofence_id"
        Me.dgvEvents_geofence_id.ReadOnly = True
        Me.dgvEvents_geofence_id.Visible = False
        '
        'panelLoading
        '
        Me.panelLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelLoading.Controls.Add(Me.lblLoading)
        Me.panelLoading.Controls.Add(Me.pboxLoading)
        Me.panelLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelLoading.Location = New System.Drawing.Point(0, 574)
        Me.panelLoading.Name = "panelLoading"
        Me.panelLoading.Size = New System.Drawing.Size(1048, 20)
        Me.panelLoading.TabIndex = 19
        '
        'lblLoading
        '
        Me.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLoading.Location = New System.Drawing.Point(0, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(1018, 20)
        Me.lblLoading.TabIndex = 16
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pboxLoading
        '
        Me.pboxLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pboxLoading.Dock = System.Windows.Forms.DockStyle.Right
        Me.pboxLoading.Image = Global.ZUtracking.My.Resources.Resources.loading
        Me.pboxLoading.Location = New System.Drawing.Point(1018, 0)
        Me.pboxLoading.Name = "pboxLoading"
        Me.pboxLoading.Size = New System.Drawing.Size(30, 20)
        Me.pboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxLoading.TabIndex = 15
        Me.pboxLoading.TabStop = False
        Me.pboxLoading.Visible = False
        '
        'bgwGetClients
        '
        Me.bgwGetClients.WorkerReportsProgress = True
        Me.bgwGetClients.WorkerSupportsCancellation = True
        '
        'bgwGetEvents
        '
        Me.bgwGetEvents.WorkerReportsProgress = True
        Me.bgwGetEvents.WorkerSupportsCancellation = True
        '
        'bgwExporting
        '
        Me.bgwExporting.WorkerReportsProgress = True
        Me.bgwExporting.WorkerSupportsCancellation = True
        '
        'frmEventHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 594)
        Me.Controls.Add(Me.dgvEvents)
        Me.Controls.Add(Me.panelHeader)
        Me.Controls.Add(Me.panelLoading)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1064, 633)
        Me.Name = "frmEventHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HISTORIAL DE EVENTOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelHeader.ResumeLayout(False)
        Me.gboxDates.ResumeLayout(False)
        Me.gboxDates.PerformLayout()
        Me.gboxParameters.ResumeLayout(False)
        Me.gboxParameters.PerformLayout()
        CType(Me.dgvEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLoading.ResumeLayout(False)
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As ZUControls.ZUPanel
    Friend WithEvents dgvEvents As ZUControls.ZUDataGridView
    Private WithEvents gboxDates As GroupBox
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Private WithEvents dtpByYear As DateTimePicker
    Private WithEvents dtpByMonth As ZUControls.ZUMonthPicker
    Private WithEvents rbtnByYear As RadioButton
    Private WithEvents rbtnByRange As RadioButton
    Private WithEvents rbtnByMonth As RadioButton
    Private WithEvents rbtnToday As RadioButton
    Private WithEvents gboxParameters As GroupBox
    Friend WithEvents btnSearch As ZUControls.ZUButton
    Private WithEvents cboEvents As ZUControls.ZUComboBox
    Private WithEvents cboVehicles As ZUControls.ZUComboBox
    Private WithEvents cboClients As ZUControls.ZUComboBox
    Private WithEvents cboxEvent As CheckBox
    Private WithEvents cboxVehicle As CheckBox
    Private WithEvents cboxClient As CheckBox
    Friend WithEvents panelLoading As ZUControls.ZUPanel
    Friend WithEvents lblLoading As Label
    Friend WithEvents pboxLoading As PictureBox
    Friend WithEvents bgwGetClients As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwGetEvents As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvEvents_client_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_license_plate As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_imei As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_date_time As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_latitude As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_longitude As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_event_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_client_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_vehicle_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_device_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_event_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvEvents_geofence_id As DataGridViewTextBoxColumn
    Friend WithEvents dtpByRangeTo As DateTimePicker
    Friend WithEvents dtpByRangeFrom As DateTimePicker
    Friend WithEvents btnExportExcel As ZUControls.ZUButton
    Friend WithEvents bgwExporting As System.ComponentModel.BackgroundWorker
End Class
