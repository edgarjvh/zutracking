<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModemSms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModemSms))
        Me.gboxSmsTemplates = New System.Windows.Forms.GroupBox()
        Me.txtMotionTemplate = New System.Windows.Forms.TextBox()
        Me.txtSpeedTemplate = New System.Windows.Forms.TextBox()
        Me.txtGeofenceTemplate = New System.Windows.Forms.TextBox()
        Me.txtBatteryTemplate = New System.Windows.Forms.TextBox()
        Me.txtIgnitionTemplate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gboxParameters = New System.Windows.Forms.GroupBox()
        Me.txtWriteBufferSize = New ZUControls.ZUNumericBox()
        Me.txtReadBufferSize = New ZUControls.ZUNumericBox()
        Me.txtWriteTimeout = New ZUControls.ZUNumericBox()
        Me.btnGetPorts = New ZUControls.ZUButton()
        Me.btnDefaultValues = New ZUControls.ZUButton()
        Me.cboPortName = New System.Windows.Forms.ComboBox()
        Me.cboHandshake = New System.Windows.Forms.ComboBox()
        Me.cboStopBits = New System.Windows.Forms.ComboBox()
        Me.cboParity = New System.Windows.Forms.ComboBox()
        Me.cboDataBits = New System.Windows.Forms.ComboBox()
        Me.cboBaudRate = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New ZUControls.ZUButton()
        Me.gboxSmsTemplates.SuspendLayout()
        Me.gboxParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'gboxSmsTemplates
        '
        Me.gboxSmsTemplates.Controls.Add(Me.txtMotionTemplate)
        Me.gboxSmsTemplates.Controls.Add(Me.txtSpeedTemplate)
        Me.gboxSmsTemplates.Controls.Add(Me.txtGeofenceTemplate)
        Me.gboxSmsTemplates.Controls.Add(Me.txtBatteryTemplate)
        Me.gboxSmsTemplates.Controls.Add(Me.txtIgnitionTemplate)
        Me.gboxSmsTemplates.Controls.Add(Me.Label14)
        Me.gboxSmsTemplates.Controls.Add(Me.Label13)
        Me.gboxSmsTemplates.Controls.Add(Me.Label12)
        Me.gboxSmsTemplates.Controls.Add(Me.Label10)
        Me.gboxSmsTemplates.Controls.Add(Me.Label11)
        Me.gboxSmsTemplates.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxSmsTemplates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxSmsTemplates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxSmsTemplates.Location = New System.Drawing.Point(0, 138)
        Me.gboxSmsTemplates.Name = "gboxSmsTemplates"
        Me.gboxSmsTemplates.Size = New System.Drawing.Size(563, 367)
        Me.gboxSmsTemplates.TabIndex = 1
        Me.gboxSmsTemplates.TabStop = False
        Me.gboxSmsTemplates.Tag = "35"
        Me.gboxSmsTemplates.Text = "Plantillas Sms"
        '
        'txtMotionTemplate
        '
        Me.txtMotionTemplate.Location = New System.Drawing.Point(12, 314)
        Me.txtMotionTemplate.MaxLength = 200
        Me.txtMotionTemplate.Multiline = True
        Me.txtMotionTemplate.Name = "txtMotionTemplate"
        Me.txtMotionTemplate.Size = New System.Drawing.Size(539, 45)
        Me.txtMotionTemplate.TabIndex = 4
        '
        'txtSpeedTemplate
        '
        Me.txtSpeedTemplate.Location = New System.Drawing.Point(12, 244)
        Me.txtSpeedTemplate.MaxLength = 200
        Me.txtSpeedTemplate.Multiline = True
        Me.txtSpeedTemplate.Name = "txtSpeedTemplate"
        Me.txtSpeedTemplate.Size = New System.Drawing.Size(539, 45)
        Me.txtSpeedTemplate.TabIndex = 3
        '
        'txtGeofenceTemplate
        '
        Me.txtGeofenceTemplate.Location = New System.Drawing.Point(12, 175)
        Me.txtGeofenceTemplate.MaxLength = 200
        Me.txtGeofenceTemplate.Multiline = True
        Me.txtGeofenceTemplate.Name = "txtGeofenceTemplate"
        Me.txtGeofenceTemplate.Size = New System.Drawing.Size(539, 45)
        Me.txtGeofenceTemplate.TabIndex = 2
        '
        'txtBatteryTemplate
        '
        Me.txtBatteryTemplate.Location = New System.Drawing.Point(12, 105)
        Me.txtBatteryTemplate.MaxLength = 200
        Me.txtBatteryTemplate.Multiline = True
        Me.txtBatteryTemplate.Name = "txtBatteryTemplate"
        Me.txtBatteryTemplate.Size = New System.Drawing.Size(539, 45)
        Me.txtBatteryTemplate.TabIndex = 1
        '
        'txtIgnitionTemplate
        '
        Me.txtIgnitionTemplate.Location = New System.Drawing.Point(12, 37)
        Me.txtIgnitionTemplate.MaxLength = 200
        Me.txtIgnitionTemplate.Multiline = True
        Me.txtIgnitionTemplate.Name = "txtIgnitionTemplate"
        Me.txtIgnitionTemplate.Size = New System.Drawing.Size(539, 45)
        Me.txtIgnitionTemplate.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(9, 298)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Movimiento"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(9, 228)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Velocidad"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(9, 159)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Geocerca"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(9, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Batería"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(9, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Ignición"
        '
        'gboxParameters
        '
        Me.gboxParameters.BackColor = System.Drawing.SystemColors.Control
        Me.gboxParameters.Controls.Add(Me.txtWriteBufferSize)
        Me.gboxParameters.Controls.Add(Me.txtReadBufferSize)
        Me.gboxParameters.Controls.Add(Me.txtWriteTimeout)
        Me.gboxParameters.Controls.Add(Me.btnGetPorts)
        Me.gboxParameters.Controls.Add(Me.btnDefaultValues)
        Me.gboxParameters.Controls.Add(Me.cboPortName)
        Me.gboxParameters.Controls.Add(Me.cboHandshake)
        Me.gboxParameters.Controls.Add(Me.cboStopBits)
        Me.gboxParameters.Controls.Add(Me.cboParity)
        Me.gboxParameters.Controls.Add(Me.cboDataBits)
        Me.gboxParameters.Controls.Add(Me.cboBaudRate)
        Me.gboxParameters.Controls.Add(Me.Label9)
        Me.gboxParameters.Controls.Add(Me.Label7)
        Me.gboxParameters.Controls.Add(Me.Label8)
        Me.gboxParameters.Controls.Add(Me.Label6)
        Me.gboxParameters.Controls.Add(Me.Label5)
        Me.gboxParameters.Controls.Add(Me.Label4)
        Me.gboxParameters.Controls.Add(Me.Label3)
        Me.gboxParameters.Controls.Add(Me.Label2)
        Me.gboxParameters.Controls.Add(Me.Label1)
        Me.gboxParameters.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxParameters.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxParameters.Location = New System.Drawing.Point(0, 0)
        Me.gboxParameters.Name = "gboxParameters"
        Me.gboxParameters.Size = New System.Drawing.Size(563, 138)
        Me.gboxParameters.TabIndex = 0
        Me.gboxParameters.TabStop = False
        Me.gboxParameters.Tag = "35"
        Me.gboxParameters.Text = "Parámetros"
        '
        'txtWriteBufferSize
        '
        Me.txtWriteBufferSize.CaracterDecimal = False
        Me.txtWriteBufferSize.HintText = "Hint Text"
        Me.txtWriteBufferSize.HintTextColor = System.Drawing.Color.Gray
        Me.txtWriteBufferSize.HintTextEnabled = False
        Me.txtWriteBufferSize.Location = New System.Drawing.Point(397, 77)
        Me.txtWriteBufferSize.Name = "txtWriteBufferSize"
        Me.txtWriteBufferSize.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtWriteBufferSize.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtWriteBufferSize.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtWriteBufferSize.Size = New System.Drawing.Size(160, 20)
        Me.txtWriteBufferSize.TabIndex = 7
        '
        'txtReadBufferSize
        '
        Me.txtReadBufferSize.CaracterDecimal = False
        Me.txtReadBufferSize.HintText = "Hint Text"
        Me.txtReadBufferSize.HintTextColor = System.Drawing.Color.Gray
        Me.txtReadBufferSize.HintTextEnabled = False
        Me.txtReadBufferSize.Location = New System.Drawing.Point(115, 77)
        Me.txtReadBufferSize.Name = "txtReadBufferSize"
        Me.txtReadBufferSize.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtReadBufferSize.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtReadBufferSize.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtReadBufferSize.Size = New System.Drawing.Size(164, 20)
        Me.txtReadBufferSize.TabIndex = 6
        '
        'txtWriteTimeout
        '
        Me.txtWriteTimeout.CaracterDecimal = False
        Me.txtWriteTimeout.HintText = "Hint Text"
        Me.txtWriteTimeout.HintTextColor = System.Drawing.Color.Gray
        Me.txtWriteTimeout.HintTextEnabled = False
        Me.txtWriteTimeout.Location = New System.Drawing.Point(495, 50)
        Me.txtWriteTimeout.Name = "txtWriteTimeout"
        Me.txtWriteTimeout.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtWriteTimeout.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtWriteTimeout.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtWriteTimeout.Size = New System.Drawing.Size(62, 20)
        Me.txtWriteTimeout.TabIndex = 5
        '
        'btnGetPorts
        '
        Me.btnGetPorts.BackColor = System.Drawing.Color.Transparent
        Me.btnGetPorts.BackgroundImage = CType(resources.GetObject("btnGetPorts.BackgroundImage"), System.Drawing.Image)
        Me.btnGetPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGetPorts.BackgroundOnClick = CType(resources.GetObject("btnGetPorts.BackgroundOnClick"), System.Drawing.Image)
        Me.btnGetPorts.BackgroundOnDisabled = CType(resources.GetObject("btnGetPorts.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnGetPorts.BackgroundOnHover = CType(resources.GetObject("btnGetPorts.BackgroundOnHover"), System.Drawing.Image)
        Me.btnGetPorts.BackgroundOnNormal = CType(resources.GetObject("btnGetPorts.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnGetPorts.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnGetPorts.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        Me.btnGetPorts.FlatAppearance.BorderSize = 0
        Me.btnGetPorts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnGetPorts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnGetPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetPorts.ForeColor = System.Drawing.Color.Black
        Me.btnGetPorts.Location = New System.Drawing.Point(186, 102)
        Me.btnGetPorts.Name = "btnGetPorts"
        Me.btnGetPorts.Size = New System.Drawing.Size(205, 23)
        Me.btnGetPorts.TabIndex = 9
        Me.btnGetPorts.Text = "<< Obtener Puertos Disponibles"
        Me.btnGetPorts.UseVisualStyleBackColor = False
        '
        'btnDefaultValues
        '
        Me.btnDefaultValues.BackColor = System.Drawing.Color.Transparent
        Me.btnDefaultValues.BackgroundImage = CType(resources.GetObject("btnDefaultValues.BackgroundImage"), System.Drawing.Image)
        Me.btnDefaultValues.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDefaultValues.BackgroundOnClick = CType(resources.GetObject("btnDefaultValues.BackgroundOnClick"), System.Drawing.Image)
        Me.btnDefaultValues.BackgroundOnDisabled = CType(resources.GetObject("btnDefaultValues.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnDefaultValues.BackgroundOnHover = CType(resources.GetObject("btnDefaultValues.BackgroundOnHover"), System.Drawing.Image)
        Me.btnDefaultValues.BackgroundOnNormal = CType(resources.GetObject("btnDefaultValues.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnDefaultValues.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnDefaultValues.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        Me.btnDefaultValues.FlatAppearance.BorderSize = 0
        Me.btnDefaultValues.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDefaultValues.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDefaultValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDefaultValues.ForeColor = System.Drawing.Color.Black
        Me.btnDefaultValues.Location = New System.Drawing.Point(397, 102)
        Me.btnDefaultValues.Name = "btnDefaultValues"
        Me.btnDefaultValues.Size = New System.Drawing.Size(160, 23)
        Me.btnDefaultValues.TabIndex = 10
        Me.btnDefaultValues.Text = "Valores Predeterminados"
        Me.btnDefaultValues.UseVisualStyleBackColor = False
        '
        'cboPortName
        '
        Me.cboPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPortName.FormattingEnabled = True
        Me.cboPortName.Location = New System.Drawing.Point(95, 103)
        Me.cboPortName.Name = "cboPortName"
        Me.cboPortName.Size = New System.Drawing.Size(86, 21)
        Me.cboPortName.TabIndex = 8
        '
        'cboHandshake
        '
        Me.cboHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHandshake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHandshake.ForeColor = System.Drawing.Color.Black
        Me.cboHandshake.FormattingEnabled = True
        Me.cboHandshake.Items.AddRange(New Object() {"Hardware", "Xon / Xoff", "Hardware y Xon/Xoff", "Ninguno"})
        Me.cboHandshake.Location = New System.Drawing.Point(281, 50)
        Me.cboHandshake.Name = "cboHandshake"
        Me.cboHandshake.Size = New System.Drawing.Size(89, 21)
        Me.cboHandshake.TabIndex = 4
        '
        'cboStopBits
        '
        Me.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStopBits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStopBits.ForeColor = System.Drawing.Color.Black
        Me.cboStopBits.FormattingEnabled = True
        Me.cboStopBits.Items.AddRange(New Object() {"1", "1.5", "2", "Ninguno"})
        Me.cboStopBits.Location = New System.Drawing.Point(101, 50)
        Me.cboStopBits.Name = "cboStopBits"
        Me.cboStopBits.Size = New System.Drawing.Size(72, 21)
        Me.cboStopBits.TabIndex = 3
        '
        'cboParity
        '
        Me.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboParity.ForeColor = System.Drawing.Color.Black
        Me.cboParity.FormattingEnabled = True
        Me.cboParity.Items.AddRange(New Object() {"Par", "Impar", "Ninguno", "Marca", "Espacio"})
        Me.cboParity.Location = New System.Drawing.Point(455, 22)
        Me.cboParity.Name = "cboParity"
        Me.cboParity.Size = New System.Drawing.Size(102, 21)
        Me.cboParity.TabIndex = 2
        '
        'cboDataBits
        '
        Me.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataBits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDataBits.ForeColor = System.Drawing.Color.Black
        Me.cboDataBits.FormattingEnabled = True
        Me.cboDataBits.Items.AddRange(New Object() {"5", "6", "7", "8"})
        Me.cboDataBits.Location = New System.Drawing.Point(306, 22)
        Me.cboDataBits.Name = "cboDataBits"
        Me.cboDataBits.Size = New System.Drawing.Size(91, 21)
        Me.cboDataBits.TabIndex = 1
        '
        'cboBaudRate
        '
        Me.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaudRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBaudRate.ForeColor = System.Drawing.Color.Black
        Me.cboBaudRate.FormattingEnabled = True
        Me.cboBaudRate.Items.AddRange(New Object() {"110", "300", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600"})
        Me.cboBaudRate.Location = New System.Drawing.Point(115, 22)
        Me.cboBaudRate.Name = "cboBaudRate"
        Me.cboBaudRate.Size = New System.Drawing.Size(95, 21)
        Me.cboBaudRate.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(380, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Tiempo de Espera"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(285, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Búfer de Escritura"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(9, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Puerto Serial"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Búfer de Lectura"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(183, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Control de Flujo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(403, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Paridad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Bits de Parada"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(221, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Bits de Datos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bits por Segundo"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.BackgroundOnClick = CType(resources.GetObject("btnSave.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSave.BackgroundOnDisabled = CType(resources.GetObject("btnSave.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSave.BackgroundOnHover = CType(resources.GetObject("btnSave.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSave.BackgroundOnNormal = CType(resources.GetObject("btnSave.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSave.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSave.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(244, 511)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'frmModemSms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 539)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gboxSmsTemplates)
        Me.Controls.Add(Me.gboxParameters)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(579, 578)
        Me.Name = "frmModemSms"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MODEM SMS"
        Me.gboxSmsTemplates.ResumeLayout(False)
        Me.gboxSmsTemplates.PerformLayout()
        Me.gboxParameters.ResumeLayout(False)
        Me.gboxParameters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gboxSmsTemplates As GroupBox
    Friend WithEvents txtIgnitionTemplate As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents gboxParameters As GroupBox
    Friend WithEvents cboHandshake As ComboBox
    Friend WithEvents cboStopBits As ComboBox
    Friend WithEvents cboParity As ComboBox
    Friend WithEvents cboDataBits As ComboBox
    Friend WithEvents cboBaudRate As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPortName As ComboBox
    Friend WithEvents btnGetPorts As ZUControls.ZUButton
    Friend WithEvents btnDefaultValues As ZUControls.ZUButton
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMotionTemplate As TextBox
    Friend WithEvents txtSpeedTemplate As TextBox
    Friend WithEvents txtGeofenceTemplate As TextBox
    Friend WithEvents txtBatteryTemplate As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnSave As ZUControls.ZUButton
    Friend WithEvents txtWriteBufferSize As ZUControls.ZUNumericBox
    Friend WithEvents txtReadBufferSize As ZUControls.ZUNumericBox
    Friend WithEvents txtWriteTimeout As ZUControls.ZUNumericBox
End Class
