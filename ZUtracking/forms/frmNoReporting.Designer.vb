<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNoReporting
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNoReporting))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New ZUControls.ZUPanel()
        Me.cboDealers = New ZUControls.ZUComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCant = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.getNoReporting = New System.ComponentModel.BackgroundWorker()
        Me.dgvNoReporting = New ZUControls.ZUDataGridView()
        Me.panelFooter = New ZUControls.ZUPanel()
        Me.btnExportExcel = New ZUControls.ZUButton()
        Me.numNoReporting = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bgwExporting = New System.ComponentModel.BackgroundWorker()
        Me.panelLoading = New ZUControls.ZUPanel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.pboxLoading = New System.Windows.Forms.PictureBox()
        Me.dgvNoReporting_priority = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_dealer_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_client_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_phone_number1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_phone_number2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_imei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_license_plate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_no_report_since = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_difference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_validation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_client_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoReporting_dealer_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelHeader.SuspendLayout()
        CType(Me.dgvNoReporting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelFooter.SuspendLayout()
        CType(Me.numNoReporting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLoading.SuspendLayout()
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelHeader.Controls.Add(Me.cboDealers)
        Me.panelHeader.Controls.Add(Me.Label4)
        Me.panelHeader.Controls.Add(Me.lblCant)
        Me.panelHeader.Controls.Add(Me.lblInfo)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Padding = New System.Windows.Forms.Padding(10)
        Me.panelHeader.Size = New System.Drawing.Size(1082, 64)
        Me.panelHeader.TabIndex = 0
        '
        'cboDealers
        '
        Me.cboDealers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDealers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDealers.FormattingEnabled = True
        Me.cboDealers.HintText = "Hint Text"
        Me.cboDealers.HintTextColor = System.Drawing.Color.Gray
        Me.cboDealers.HintTextEnabled = False
        Me.cboDealers.Location = New System.Drawing.Point(61, 24)
        Me.cboDealers.Name = "cboDealers"
        Me.cboDealers.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboDealers.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboDealers.Size = New System.Drawing.Size(226, 21)
        Me.cboDealers.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Dealer:"
        '
        'lblCant
        '
        Me.lblCant.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold)
        Me.lblCant.ForeColor = System.Drawing.Color.Green
        Me.lblCant.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCant.Location = New System.Drawing.Point(293, 9)
        Me.lblCant.Name = "lblCant"
        Me.lblCant.Size = New System.Drawing.Size(104, 50)
        Me.lblCant.TabIndex = 0
        Me.lblCant.Text = "0000"
        Me.lblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInfo
        '
        Me.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold)
        Me.lblInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInfo.Location = New System.Drawing.Point(388, 9)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(397, 50)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Vehículos Sin Reportar"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'getNoReporting
        '
        Me.getNoReporting.WorkerReportsProgress = True
        Me.getNoReporting.WorkerSupportsCancellation = True
        '
        'dgvNoReporting
        '
        Me.dgvNoReporting.AllowUserToAddRows = False
        Me.dgvNoReporting.AllowUserToDeleteRows = False
        Me.dgvNoReporting.AllowUserToResizeColumns = False
        Me.dgvNoReporting.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        Me.dgvNoReporting.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNoReporting.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvNoReporting.BackgroundHeader = CType(resources.GetObject("dgvNoReporting.BackgroundHeader"), System.Drawing.Image)
        Me.dgvNoReporting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvNoReporting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvNoReporting.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNoReporting.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNoReporting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNoReporting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvNoReporting_priority, Me.dgvNoReporting_dealer_name, Me.dgvNoReporting_client_name, Me.dgvNoReporting_phone_number1, Me.dgvNoReporting_phone_number2, Me.dgvNoReporting_imei, Me.dgvNoReporting_license_plate, Me.dgvNoReporting_no_report_since, Me.dgvNoReporting_difference, Me.dgvNoReporting_validation, Me.dgvNoReporting_client_id, Me.dgvNoReporting_dealer_id})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNoReporting.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvNoReporting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNoReporting.GridColor = System.Drawing.SystemColors.Control
        Me.dgvNoReporting.HeaderFontSize = 7.0!
        Me.dgvNoReporting.HeaderForeColor = System.Drawing.Color.White
        Me.dgvNoReporting.Location = New System.Drawing.Point(0, 64)
        Me.dgvNoReporting.MultiSelect = False
        Me.dgvNoReporting.Name = "dgvNoReporting"
        Me.dgvNoReporting.ReadOnly = True
        Me.dgvNoReporting.RowHeadersVisible = False
        Me.dgvNoReporting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvNoReporting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNoReporting.Size = New System.Drawing.Size(1082, 504)
        Me.dgvNoReporting.TabIndex = 7
        '
        'panelFooter
        '
        Me.panelFooter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelFooter.Controls.Add(Me.btnExportExcel)
        Me.panelFooter.Controls.Add(Me.numNoReporting)
        Me.panelFooter.Controls.Add(Me.Label2)
        Me.panelFooter.Controls.Add(Me.Label1)
        Me.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelFooter.Location = New System.Drawing.Point(0, 568)
        Me.panelFooter.Name = "panelFooter"
        Me.panelFooter.Size = New System.Drawing.Size(1082, 28)
        Me.panelFooter.TabIndex = 8
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExportExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnExportExcel.BackgroundImage = CType(resources.GetObject("btnExportExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportExcel.BackgroundOnClick = CType(resources.GetObject("btnExportExcel.BackgroundOnClick"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundOnDisabled = CType(resources.GetObject("btnExportExcel.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundOnHover = CType(resources.GetObject("btnExportExcel.BackgroundOnHover"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundOnNormal = CType(resources.GetObject("btnExportExcel.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnExportExcel.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnExportExcel.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        Me.btnExportExcel.FlatAppearance.BorderSize = 0
        Me.btnExportExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportExcel.Location = New System.Drawing.Point(967, 1)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(109, 23)
        Me.btnExportExcel.TabIndex = 1
        Me.btnExportExcel.Text = "Exportar a Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'numNoReporting
        '
        Me.numNoReporting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.numNoReporting.BackColor = System.Drawing.Color.Gold
        Me.numNoReporting.Location = New System.Drawing.Point(607, 4)
        Me.numNoReporting.Maximum = New Decimal(New Integer() {168, 0, 0, 0})
        Me.numNoReporting.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numNoReporting.Name = "numNoReporting"
        Me.numNoReporting.Size = New System.Drawing.Size(62, 20)
        Me.numNoReporting.TabIndex = 1
        Me.numNoReporting.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(675, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "(Mínimo = 1; Máximo = 168)"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(239, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(362, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tiempo (en horas) que se evaluará como ""No Reportando"" >> "
        '
        'bgwExporting
        '
        Me.bgwExporting.WorkerReportsProgress = True
        Me.bgwExporting.WorkerSupportsCancellation = True
        '
        'panelLoading
        '
        Me.panelLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelLoading.Controls.Add(Me.lblLoading)
        Me.panelLoading.Controls.Add(Me.pboxLoading)
        Me.panelLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelLoading.Location = New System.Drawing.Point(0, 548)
        Me.panelLoading.Name = "panelLoading"
        Me.panelLoading.Size = New System.Drawing.Size(1082, 20)
        Me.panelLoading.TabIndex = 19
        Me.panelLoading.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLoading.Location = New System.Drawing.Point(0, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(1052, 20)
        Me.lblLoading.TabIndex = 16
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pboxLoading
        '
        Me.pboxLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pboxLoading.Dock = System.Windows.Forms.DockStyle.Right
        Me.pboxLoading.Image = Global.ZUtracking.My.Resources.Resources.loading
        Me.pboxLoading.Location = New System.Drawing.Point(1052, 0)
        Me.pboxLoading.Name = "pboxLoading"
        Me.pboxLoading.Size = New System.Drawing.Size(30, 20)
        Me.pboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxLoading.TabIndex = 15
        Me.pboxLoading.TabStop = False
        Me.pboxLoading.Visible = False
        '
        'dgvNoReporting_priority
        '
        Me.dgvNoReporting_priority.HeaderText = "PRIORIDAD"
        Me.dgvNoReporting_priority.Name = "dgvNoReporting_priority"
        Me.dgvNoReporting_priority.ReadOnly = True
        Me.dgvNoReporting_priority.Visible = False
        Me.dgvNoReporting_priority.Width = 80
        '
        'dgvNoReporting_dealer_name
        '
        Me.dgvNoReporting_dealer_name.HeaderText = "DEALER"
        Me.dgvNoReporting_dealer_name.Name = "dgvNoReporting_dealer_name"
        Me.dgvNoReporting_dealer_name.ReadOnly = True
        Me.dgvNoReporting_dealer_name.Width = 250
        '
        'dgvNoReporting_client_name
        '
        Me.dgvNoReporting_client_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNoReporting_client_name.HeaderText = "CLIENTE"
        Me.dgvNoReporting_client_name.Name = "dgvNoReporting_client_name"
        Me.dgvNoReporting_client_name.ReadOnly = True
        '
        'dgvNoReporting_phone_number1
        '
        Me.dgvNoReporting_phone_number1.HeaderText = "TELÉFONO 1"
        Me.dgvNoReporting_phone_number1.Name = "dgvNoReporting_phone_number1"
        Me.dgvNoReporting_phone_number1.ReadOnly = True
        '
        'dgvNoReporting_phone_number2
        '
        Me.dgvNoReporting_phone_number2.HeaderText = "TELÉFONO 2"
        Me.dgvNoReporting_phone_number2.Name = "dgvNoReporting_phone_number2"
        Me.dgvNoReporting_phone_number2.ReadOnly = True
        '
        'dgvNoReporting_imei
        '
        Me.dgvNoReporting_imei.HeaderText = "IMEI"
        Me.dgvNoReporting_imei.Name = "dgvNoReporting_imei"
        Me.dgvNoReporting_imei.ReadOnly = True
        Me.dgvNoReporting_imei.Width = 150
        '
        'dgvNoReporting_license_plate
        '
        Me.dgvNoReporting_license_plate.HeaderText = "MATRÍCULA"
        Me.dgvNoReporting_license_plate.Name = "dgvNoReporting_license_plate"
        Me.dgvNoReporting_license_plate.ReadOnly = True
        Me.dgvNoReporting_license_plate.Width = 120
        '
        'dgvNoReporting_no_report_since
        '
        Me.dgvNoReporting_no_report_since.HeaderText = "SIN REPORTAR DESDE"
        Me.dgvNoReporting_no_report_since.Name = "dgvNoReporting_no_report_since"
        Me.dgvNoReporting_no_report_since.ReadOnly = True
        Me.dgvNoReporting_no_report_since.Width = 200
        '
        'dgvNoReporting_difference
        '
        Me.dgvNoReporting_difference.HeaderText = "DIFERENCIA"
        Me.dgvNoReporting_difference.Name = "dgvNoReporting_difference"
        Me.dgvNoReporting_difference.ReadOnly = True
        Me.dgvNoReporting_difference.Visible = False
        Me.dgvNoReporting_difference.Width = 106
        '
        'dgvNoReporting_validation
        '
        Me.dgvNoReporting_validation.HeaderText = "VÁLIDO HASTA"
        Me.dgvNoReporting_validation.Name = "dgvNoReporting_validation"
        Me.dgvNoReporting_validation.ReadOnly = True
        Me.dgvNoReporting_validation.Visible = False
        Me.dgvNoReporting_validation.Width = 200
        '
        'dgvNoReporting_client_id
        '
        Me.dgvNoReporting_client_id.HeaderText = "ID CLIENTE"
        Me.dgvNoReporting_client_id.Name = "dgvNoReporting_client_id"
        Me.dgvNoReporting_client_id.ReadOnly = True
        Me.dgvNoReporting_client_id.Visible = False
        Me.dgvNoReporting_client_id.Width = 101
        '
        'dgvNoReporting_dealer_id
        '
        Me.dgvNoReporting_dealer_id.HeaderText = "ID DEALER"
        Me.dgvNoReporting_dealer_id.Name = "dgvNoReporting_dealer_id"
        Me.dgvNoReporting_dealer_id.ReadOnly = True
        Me.dgvNoReporting_dealer_id.Visible = False
        '
        'frmNoReporting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 596)
        Me.Controls.Add(Me.panelLoading)
        Me.Controls.Add(Me.dgvNoReporting)
        Me.Controls.Add(Me.panelFooter)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1098, 635)
        Me.Name = "frmNoReporting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VEHÍCULOS SIN REPORTAR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.dgvNoReporting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelFooter.ResumeLayout(False)
        Me.panelFooter.PerformLayout()
        CType(Me.numNoReporting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLoading.ResumeLayout(False)
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As ZUControls.ZUPanel
    Friend WithEvents lblCant As Label
    Friend WithEvents lblInfo As Label
    Friend WithEvents dgvNoReporting As ZUControls.ZUDataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents getNoReporting As System.ComponentModel.BackgroundWorker
    Friend WithEvents panelFooter As ZUControls.ZUPanel
    Friend WithEvents numNoReporting As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExportExcel As ZUControls.ZUButton
    Friend WithEvents bgwExporting As System.ComponentModel.BackgroundWorker
    Friend WithEvents panelLoading As ZUControls.ZUPanel
    Friend WithEvents lblLoading As Label
    Friend WithEvents pboxLoading As PictureBox
    Friend WithEvents cboDealers As ZUControls.ZUComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvNoReporting_priority As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_dealer_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_client_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_phone_number1 As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_phone_number2 As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_imei As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_license_plate As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_no_report_since As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_difference As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_validation As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_client_id As DataGridViewTextBoxColumn
    Friend WithEvents dgvNoReporting_dealer_id As DataGridViewTextBoxColumn
End Class
