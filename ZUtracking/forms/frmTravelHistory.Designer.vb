<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTravelHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTravelHistory))
        Me.splitTravelHistory = New System.Windows.Forms.SplitContainer()
        Me.tviewPoints = New System.Windows.Forms.TreeView()
        Me.btnShowTravelLine = New ZUControls.ZUButton()
        Me.btnCenterSelection = New ZUControls.ZUButton()
        Me.tbarMapZoom = New XComponent.SliderBar.ZUTrackBar()
        Me.btnHybrid = New ZUControls.ZUButton()
        Me.btnSatellite = New ZUControls.ZUButton()
        Me.btnMap = New ZUControls.ZUButton()
        Me.mapTravelHistory = New ZUControls.ZUMapa()
        Me.bgwSearchHistory = New System.ComponentModel.BackgroundWorker()
        Me.panelLoading = New ZUControls.ZUPanel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.pboxLoading = New System.Windows.Forms.PictureBox()
        Me.panelHeader = New ZUControls.ZUPanel()
        Me.cboVehicles = New ZUControls.ZUComboBox()
        Me.cboClients = New ZUControls.ZUComboBox()
        Me.btnSearch = New ZUControls.ZUButton()
        Me.dtpTimeTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpTimeFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.splitTravelHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitTravelHistory.Panel1.SuspendLayout()
        Me.splitTravelHistory.Panel2.SuspendLayout()
        Me.splitTravelHistory.SuspendLayout()
        Me.panelLoading.SuspendLayout()
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitTravelHistory
        '
        Me.splitTravelHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitTravelHistory.Location = New System.Drawing.Point(0, 58)
        Me.splitTravelHistory.Name = "splitTravelHistory"
        '
        'splitTravelHistory.Panel1
        '
        Me.splitTravelHistory.Panel1.Controls.Add(Me.tviewPoints)
        '
        'splitTravelHistory.Panel2
        '
        Me.splitTravelHistory.Panel2.Controls.Add(Me.btnShowTravelLine)
        Me.splitTravelHistory.Panel2.Controls.Add(Me.btnCenterSelection)
        Me.splitTravelHistory.Panel2.Controls.Add(Me.tbarMapZoom)
        Me.splitTravelHistory.Panel2.Controls.Add(Me.btnHybrid)
        Me.splitTravelHistory.Panel2.Controls.Add(Me.btnSatellite)
        Me.splitTravelHistory.Panel2.Controls.Add(Me.btnMap)
        Me.splitTravelHistory.Panel2.Controls.Add(Me.mapTravelHistory)
        Me.splitTravelHistory.Size = New System.Drawing.Size(989, 571)
        Me.splitTravelHistory.SplitterDistance = 273
        Me.splitTravelHistory.SplitterWidth = 5
        Me.splitTravelHistory.TabIndex = 1
        '
        'tviewPoints
        '
        Me.tviewPoints.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tviewPoints.Location = New System.Drawing.Point(0, 0)
        Me.tviewPoints.Name = "tviewPoints"
        Me.tviewPoints.Size = New System.Drawing.Size(273, 571)
        Me.tviewPoints.TabIndex = 0
        '
        'btnShowTravelLine
        '
        Me.btnShowTravelLine.BackColor = System.Drawing.Color.Transparent
        Me.btnShowTravelLine.BackgroundImage = CType(resources.GetObject("btnShowTravelLine.BackgroundImage"), System.Drawing.Image)
        Me.btnShowTravelLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowTravelLine.BackgroundOnClick = CType(resources.GetObject("btnShowTravelLine.BackgroundOnClick"), System.Drawing.Image)
        Me.btnShowTravelLine.BackgroundOnDisabled = CType(resources.GetObject("btnShowTravelLine.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnShowTravelLine.BackgroundOnHover = CType(resources.GetObject("btnShowTravelLine.BackgroundOnHover"), System.Drawing.Image)
        Me.btnShowTravelLine.BackgroundOnNormal = CType(resources.GetObject("btnShowTravelLine.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnShowTravelLine.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnShowTravelLine.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnShowTravelLine.Enabled = False
        Me.btnShowTravelLine.FlatAppearance.BorderSize = 0
        Me.btnShowTravelLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnShowTravelLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnShowTravelLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowTravelLine.Location = New System.Drawing.Point(3, 35)
        Me.btnShowTravelLine.Name = "btnShowTravelLine"
        Me.btnShowTravelLine.Size = New System.Drawing.Size(128, 23)
        Me.btnShowTravelLine.TabIndex = 11
        Me.btnShowTravelLine.Text = "Línea de Recorrido"
        Me.btnShowTravelLine.UseVisualStyleBackColor = False
        '
        'btnCenterSelection
        '
        Me.btnCenterSelection.BackColor = System.Drawing.Color.Transparent
        Me.btnCenterSelection.BackgroundImage = CType(resources.GetObject("btnCenterSelection.BackgroundImage"), System.Drawing.Image)
        Me.btnCenterSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCenterSelection.BackgroundOnClick = CType(resources.GetObject("btnCenterSelection.BackgroundOnClick"), System.Drawing.Image)
        Me.btnCenterSelection.BackgroundOnDisabled = CType(resources.GetObject("btnCenterSelection.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnCenterSelection.BackgroundOnHover = CType(resources.GetObject("btnCenterSelection.BackgroundOnHover"), System.Drawing.Image)
        Me.btnCenterSelection.BackgroundOnNormal = CType(resources.GetObject("btnCenterSelection.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnCenterSelection.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnCenterSelection.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnCenterSelection.Enabled = False
        Me.btnCenterSelection.FlatAppearance.BorderSize = 0
        Me.btnCenterSelection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCenterSelection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCenterSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCenterSelection.Location = New System.Drawing.Point(3, 6)
        Me.btnCenterSelection.Name = "btnCenterSelection"
        Me.btnCenterSelection.Size = New System.Drawing.Size(128, 23)
        Me.btnCenterSelection.TabIndex = 11
        Me.btnCenterSelection.Text = "Centrar Selección"
        Me.btnCenterSelection.UseVisualStyleBackColor = False
        '
        'tbarMapZoom
        '
        Me.tbarMapZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbarMapZoom.BackColor = System.Drawing.Color.Transparent
        Me.tbarMapZoom.BorderColor = System.Drawing.Color.Transparent
        Me.tbarMapZoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbarMapZoom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.tbarMapZoom.IndentHeight = 3
        Me.tbarMapZoom.Location = New System.Drawing.Point(458, 33)
        Me.tbarMapZoom.Maximum = 19
        Me.tbarMapZoom.Minimum = 3
        Me.tbarMapZoom.Name = "tbarMapZoom"
        Me.tbarMapZoom.Size = New System.Drawing.Size(237, 25)
        Me.tbarMapZoom.TabIndex = 10
        Me.tbarMapZoom.TextTickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarMapZoom.TickColor = System.Drawing.Color.Red
        Me.tbarMapZoom.TickHeight = 2
        Me.tbarMapZoom.TrackerColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.tbarMapZoom.TrackerSize = New System.Drawing.Size(16, 16)
        Me.tbarMapZoom.TrackLineColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.tbarMapZoom.TrackLineHeight = 3
        Me.tbarMapZoom.Value = 3
        '
        'btnHybrid
        '
        Me.btnHybrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHybrid.BackColor = System.Drawing.Color.Transparent
        Me.btnHybrid.BackgroundImage = CType(resources.GetObject("btnHybrid.BackgroundImage"), System.Drawing.Image)
        Me.btnHybrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHybrid.BackgroundOnClick = CType(resources.GetObject("btnHybrid.BackgroundOnClick"), System.Drawing.Image)
        Me.btnHybrid.BackgroundOnDisabled = CType(resources.GetObject("btnHybrid.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnHybrid.BackgroundOnHover = CType(resources.GetObject("btnHybrid.BackgroundOnHover"), System.Drawing.Image)
        Me.btnHybrid.BackgroundOnNormal = CType(resources.GetObject("btnHybrid.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnHybrid.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnHybrid.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnHybrid.FlatAppearance.BorderSize = 0
        Me.btnHybrid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnHybrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnHybrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHybrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHybrid.Location = New System.Drawing.Point(620, 6)
        Me.btnHybrid.Name = "btnHybrid"
        Me.btnHybrid.Size = New System.Drawing.Size(75, 23)
        Me.btnHybrid.TabIndex = 7
        Me.btnHybrid.Text = "Híbrido"
        Me.btnHybrid.UseVisualStyleBackColor = False
        '
        'btnSatellite
        '
        Me.btnSatellite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSatellite.BackColor = System.Drawing.Color.Transparent
        Me.btnSatellite.BackgroundImage = CType(resources.GetObject("btnSatellite.BackgroundImage"), System.Drawing.Image)
        Me.btnSatellite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSatellite.BackgroundOnClick = CType(resources.GetObject("btnSatellite.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSatellite.BackgroundOnDisabled = CType(resources.GetObject("btnSatellite.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSatellite.BackgroundOnHover = CType(resources.GetObject("btnSatellite.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSatellite.BackgroundOnNormal = CType(resources.GetObject("btnSatellite.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSatellite.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSatellite.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        Me.btnSatellite.FlatAppearance.BorderSize = 0
        Me.btnSatellite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSatellite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSatellite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSatellite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSatellite.Location = New System.Drawing.Point(539, 6)
        Me.btnSatellite.Name = "btnSatellite"
        Me.btnSatellite.Size = New System.Drawing.Size(75, 23)
        Me.btnSatellite.TabIndex = 8
        Me.btnSatellite.Text = "Satélite"
        Me.btnSatellite.UseVisualStyleBackColor = False
        '
        'btnMap
        '
        Me.btnMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMap.BackColor = System.Drawing.Color.Transparent
        Me.btnMap.BackgroundImage = CType(resources.GetObject("btnMap.BackgroundImage"), System.Drawing.Image)
        Me.btnMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMap.BackgroundOnClick = CType(resources.GetObject("btnMap.BackgroundOnClick"), System.Drawing.Image)
        Me.btnMap.BackgroundOnDisabled = CType(resources.GetObject("btnMap.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnMap.BackgroundOnHover = CType(resources.GetObject("btnMap.BackgroundOnHover"), System.Drawing.Image)
        Me.btnMap.BackgroundOnNormal = CType(resources.GetObject("btnMap.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnMap.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnMap.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        Me.btnMap.FlatAppearance.BorderSize = 0
        Me.btnMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMap.Location = New System.Drawing.Point(458, 6)
        Me.btnMap.Name = "btnMap"
        Me.btnMap.Size = New System.Drawing.Size(75, 23)
        Me.btnMap.TabIndex = 9
        Me.btnMap.Text = "Mapa"
        Me.btnMap.UseVisualStyleBackColor = False
        '
        'mapTravelHistory
        '
        Me.mapTravelHistory.Bearing = 0!
        Me.mapTravelHistory.CanDragMap = True
        Me.mapTravelHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mapTravelHistory.EmptyTileColor = System.Drawing.Color.Navy
        Me.mapTravelHistory.GrayScaleMode = False
        Me.mapTravelHistory.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.mapTravelHistory.LevelsKeepInMemmory = 5
        Me.mapTravelHistory.Location = New System.Drawing.Point(0, 0)
        Me.mapTravelHistory.MarkersEnabled = True
        Me.mapTravelHistory.MaxZoom = 19
        Me.mapTravelHistory.MinZoom = 3
        Me.mapTravelHistory.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.mapTravelHistory.Name = "mapTravelHistory"
        Me.mapTravelHistory.NegativeMode = False
        Me.mapTravelHistory.PolygonsEnabled = True
        Me.mapTravelHistory.RetryLoadTile = 0
        Me.mapTravelHistory.RoutesEnabled = True
        Me.mapTravelHistory.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.mapTravelHistory.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.mapTravelHistory.ShowTileGridLines = False
        Me.mapTravelHistory.Size = New System.Drawing.Size(711, 571)
        Me.mapTravelHistory.TabIndex = 0
        Me.mapTravelHistory.Zoom = 12.0R
        '
        'bgwSearchHistory
        '
        Me.bgwSearchHistory.WorkerReportsProgress = True
        Me.bgwSearchHistory.WorkerSupportsCancellation = True
        '
        'panelLoading
        '
        Me.panelLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelLoading.Controls.Add(Me.lblLoading)
        Me.panelLoading.Controls.Add(Me.pboxLoading)
        Me.panelLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelLoading.Location = New System.Drawing.Point(0, 609)
        Me.panelLoading.Name = "panelLoading"
        Me.panelLoading.Size = New System.Drawing.Size(989, 20)
        Me.panelLoading.TabIndex = 18
        '
        'lblLoading
        '
        Me.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLoading.Location = New System.Drawing.Point(0, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(954, 20)
        Me.lblLoading.TabIndex = 16
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pboxLoading
        '
        Me.pboxLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pboxLoading.Dock = System.Windows.Forms.DockStyle.Right
        Me.pboxLoading.Image = Global.ZUtracking.My.Resources.Resources.loading
        Me.pboxLoading.Location = New System.Drawing.Point(954, 0)
        Me.pboxLoading.Name = "pboxLoading"
        Me.pboxLoading.Size = New System.Drawing.Size(35, 20)
        Me.pboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxLoading.TabIndex = 15
        Me.pboxLoading.TabStop = False
        Me.pboxLoading.Visible = False
        '
        'panelHeader
        '
        Me.panelHeader.Controls.Add(Me.cboVehicles)
        Me.panelHeader.Controls.Add(Me.cboClients)
        Me.panelHeader.Controls.Add(Me.btnSearch)
        Me.panelHeader.Controls.Add(Me.dtpTimeTo)
        Me.panelHeader.Controls.Add(Me.dtpTimeFrom)
        Me.panelHeader.Controls.Add(Me.dtpDateTo)
        Me.panelHeader.Controls.Add(Me.dtpDateFrom)
        Me.panelHeader.Controls.Add(Me.Label2)
        Me.panelHeader.Controls.Add(Me.Label4)
        Me.panelHeader.Controls.Add(Me.Label3)
        Me.panelHeader.Controls.Add(Me.Label1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(989, 58)
        Me.panelHeader.TabIndex = 0
        '
        'cboVehicles
        '
        Me.cboVehicles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVehicles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVehicles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVehicles.FormattingEnabled = True
        Me.cboVehicles.HintText = "Hint Text"
        Me.cboVehicles.HintTextColor = System.Drawing.Color.Gray
        Me.cboVehicles.HintTextEnabled = False
        Me.cboVehicles.Location = New System.Drawing.Point(456, 31)
        Me.cboVehicles.Name = "cboVehicles"
        Me.cboVehicles.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboVehicles.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboVehicles.Size = New System.Drawing.Size(432, 21)
        Me.cboVehicles.TabIndex = 3
        '
        'cboClients
        '
        Me.cboClients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboClients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboClients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClients.FormattingEnabled = True
        Me.cboClients.HintText = "Hint Text"
        Me.cboClients.HintTextColor = System.Drawing.Color.Gray
        Me.cboClients.HintTextEnabled = False
        Me.cboClients.Location = New System.Drawing.Point(444, 5)
        Me.cboClients.Name = "cboClients"
        Me.cboClients.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboClients.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboClients.Size = New System.Drawing.Size(444, 21)
        Me.cboClients.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.btnSearch.Location = New System.Drawing.Point(894, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(89, 49)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Buscar Recorrido"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'dtpTimeTo
        '
        Me.dtpTimeTo.CustomFormat = "HH:mm"
        Me.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTimeTo.Location = New System.Drawing.Point(252, 32)
        Me.dtpTimeTo.Name = "dtpTimeTo"
        Me.dtpTimeTo.ShowUpDown = True
        Me.dtpTimeTo.Size = New System.Drawing.Size(113, 20)
        Me.dtpTimeTo.TabIndex = 1
        '
        'dtpTimeFrom
        '
        Me.dtpTimeFrom.CustomFormat = "HH:mm"
        Me.dtpTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTimeFrom.Location = New System.Drawing.Point(252, 6)
        Me.dtpTimeFrom.Name = "dtpTimeFrom"
        Me.dtpTimeFrom.ShowUpDown = True
        Me.dtpTimeFrom.Size = New System.Drawing.Size(113, 20)
        Me.dtpTimeFrom.TabIndex = 1
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateTo.Location = New System.Drawing.Point(133, 32)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(113, 20)
        Me.dtpDateTo.TabIndex = 1
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFrom.Location = New System.Drawing.Point(133, 6)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(113, 20)
        Me.dtpDateFrom.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha/Hora Hasta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(392, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Vehículo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(392, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha/Hora Desde"
        '
        'frmTravelHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 629)
        Me.Controls.Add(Me.panelLoading)
        Me.Controls.Add(Me.splitTravelHistory)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1005, 668)
        Me.Name = "frmTravelHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HISTORIAL DE RECORRIDO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.splitTravelHistory.Panel1.ResumeLayout(False)
        Me.splitTravelHistory.Panel2.ResumeLayout(False)
        Me.splitTravelHistory.Panel2.PerformLayout()
        CType(Me.splitTravelHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitTravelHistory.ResumeLayout(False)
        Me.panelLoading.ResumeLayout(False)
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As ZUControls.ZUPanel
    Friend WithEvents splitTravelHistory As SplitContainer
    Friend WithEvents panelLoading As ZUControls.ZUPanel
    Friend WithEvents lblLoading As Label
    Friend WithEvents pboxLoading As PictureBox
    Friend WithEvents cboVehicles As ZUControls.ZUComboBox
    Friend WithEvents cboClients As ZUControls.ZUComboBox
    Friend WithEvents btnSearch As ZUControls.ZUButton
    Friend WithEvents dtpTimeTo As DateTimePicker
    Friend WithEvents dtpTimeFrom As DateTimePicker
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents mapTravelHistory As ZUControls.ZUMapa
    Friend WithEvents tviewPoints As TreeView
    Friend WithEvents bgwSearchHistory As System.ComponentModel.BackgroundWorker
    Friend WithEvents tbarMapZoom As XComponent.SliderBar.ZUTrackBar
    Friend WithEvents btnHybrid As ZUControls.ZUButton
    Friend WithEvents btnSatellite As ZUControls.ZUButton
    Friend WithEvents btnMap As ZUControls.ZUButton
    Friend WithEvents btnShowTravelLine As ZUControls.ZUButton
    Friend WithEvents btnCenterSelection As ZUControls.ZUButton
End Class
