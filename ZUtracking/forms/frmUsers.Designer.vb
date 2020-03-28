<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsers))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gboxData = New System.Windows.Forms.GroupBox()
        Me.txtPhoneNumber2 = New ZUControls.ZUNumericBox()
        Me.txtPhoneNumber1 = New ZUControls.ZUNumericBox()
        Me.btnCancelUser = New ZUControls.ZUButton()
        Me.btnDeleteUser = New ZUControls.ZUButton()
        Me.btnSaveUser = New ZUControls.ZUButton()
        Me.btnEditUser = New ZUControls.ZUButton()
        Me.btnNewUser = New ZUControls.ZUButton()
        Me.cboxStatus = New System.Windows.Forms.CheckBox()
        Me.txtDni = New ZUControls.ZUNumericBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtEmail = New ZUControls.ZUTextBox()
        Me.txtLastName = New ZUControls.ZUTextBox()
        Me.txtFirstName = New ZUControls.ZUTextBox()
        Me.txtPass = New ZUControls.ZUTextBox()
        Me.txtAddress = New ZUControls.ZUTextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.dgvUsers = New ZUControls.ZUDataGridView()
        Me.dgvUsers_dni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_first_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_last_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_phone_number1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_phone_number2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_pass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers_user_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bgwSavingUsers = New System.ComponentModel.BackgroundWorker()
        Me.bgwDeletingUsers = New System.ComponentModel.BackgroundWorker()
        Me.panelLoading = New ZUControls.ZUPanel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.pboxLoading = New System.Windows.Forms.PictureBox()
        Me.gboxData.SuspendLayout()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLoading.SuspendLayout()
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gboxData
        '
        Me.gboxData.Controls.Add(Me.txtPhoneNumber2)
        Me.gboxData.Controls.Add(Me.txtPhoneNumber1)
        Me.gboxData.Controls.Add(Me.btnCancelUser)
        Me.gboxData.Controls.Add(Me.btnDeleteUser)
        Me.gboxData.Controls.Add(Me.btnSaveUser)
        Me.gboxData.Controls.Add(Me.btnEditUser)
        Me.gboxData.Controls.Add(Me.btnNewUser)
        Me.gboxData.Controls.Add(Me.cboxStatus)
        Me.gboxData.Controls.Add(Me.txtDni)
        Me.gboxData.Controls.Add(Me.label1)
        Me.gboxData.Controls.Add(Me.txtEmail)
        Me.gboxData.Controls.Add(Me.txtLastName)
        Me.gboxData.Controls.Add(Me.txtFirstName)
        Me.gboxData.Controls.Add(Me.txtPass)
        Me.gboxData.Controls.Add(Me.txtAddress)
        Me.gboxData.Controls.Add(Me.label7)
        Me.gboxData.Controls.Add(Me.label4)
        Me.gboxData.Controls.Add(Me.label3)
        Me.gboxData.Controls.Add(Me.Label10)
        Me.gboxData.Controls.Add(Me.Label9)
        Me.gboxData.Controls.Add(Me.Label8)
        Me.gboxData.Controls.Add(Me.Label5)
        Me.gboxData.Controls.Add(Me.label2)
        Me.gboxData.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxData.ForeColor = System.Drawing.Color.Blue
        Me.gboxData.Location = New System.Drawing.Point(0, 0)
        Me.gboxData.Name = "gboxData"
        Me.gboxData.Size = New System.Drawing.Size(434, 285)
        Me.gboxData.TabIndex = 0
        Me.gboxData.TabStop = False
        Me.gboxData.Text = "Datos Personales"
        '
        'txtPhoneNumber2
        '
        Me.txtPhoneNumber2.CaracterDecimal = False
        Me.txtPhoneNumber2.Enabled = False
        Me.txtPhoneNumber2.HintText = "Hint Text"
        Me.txtPhoneNumber2.HintTextColor = System.Drawing.Color.Gray
        Me.txtPhoneNumber2.HintTextEnabled = False
        Me.txtPhoneNumber2.Location = New System.Drawing.Point(80, 150)
        Me.txtPhoneNumber2.MaxLength = 15
        Me.txtPhoneNumber2.Name = "txtPhoneNumber2"
        Me.txtPhoneNumber2.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtPhoneNumber2.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtPhoneNumber2.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtPhoneNumber2.Size = New System.Drawing.Size(344, 20)
        Me.txtPhoneNumber2.TabIndex = 5
        '
        'txtPhoneNumber1
        '
        Me.txtPhoneNumber1.CaracterDecimal = False
        Me.txtPhoneNumber1.Enabled = False
        Me.txtPhoneNumber1.HintText = "Hint Text"
        Me.txtPhoneNumber1.HintTextColor = System.Drawing.Color.Gray
        Me.txtPhoneNumber1.HintTextEnabled = False
        Me.txtPhoneNumber1.Location = New System.Drawing.Point(80, 125)
        Me.txtPhoneNumber1.MaxLength = 15
        Me.txtPhoneNumber1.Name = "txtPhoneNumber1"
        Me.txtPhoneNumber1.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtPhoneNumber1.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtPhoneNumber1.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtPhoneNumber1.Size = New System.Drawing.Size(344, 20)
        Me.txtPhoneNumber1.TabIndex = 4
        '
        'btnCancelUser
        '
        Me.btnCancelUser.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelUser.BackgroundImage = CType(resources.GetObject("btnCancelUser.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelUser.BackgroundOnClick = CType(resources.GetObject("btnCancelUser.BackgroundOnClick"), System.Drawing.Image)
        Me.btnCancelUser.BackgroundOnDisabled = CType(resources.GetObject("btnCancelUser.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnCancelUser.BackgroundOnHover = CType(resources.GetObject("btnCancelUser.BackgroundOnHover"), System.Drawing.Image)
        Me.btnCancelUser.BackgroundOnNormal = CType(resources.GetObject("btnCancelUser.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnCancelUser.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnCancelUser.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnCancelUser.Enabled = False
        Me.btnCancelUser.FlatAppearance.BorderSize = 0
        Me.btnCancelUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancelUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancelUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelUser.ForeColor = System.Drawing.Color.Black
        Me.btnCancelUser.Location = New System.Drawing.Point(346, 254)
        Me.btnCancelUser.Name = "btnCancelUser"
        Me.btnCancelUser.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelUser.TabIndex = 13
        Me.btnCancelUser.Text = "Cancelar"
        Me.btnCancelUser.UseVisualStyleBackColor = False
        '
        'btnDeleteUser
        '
        Me.btnDeleteUser.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteUser.BackgroundImage = CType(resources.GetObject("btnDeleteUser.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteUser.BackgroundOnClick = CType(resources.GetObject("btnDeleteUser.BackgroundOnClick"), System.Drawing.Image)
        Me.btnDeleteUser.BackgroundOnDisabled = CType(resources.GetObject("btnDeleteUser.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnDeleteUser.BackgroundOnHover = CType(resources.GetObject("btnDeleteUser.BackgroundOnHover"), System.Drawing.Image)
        Me.btnDeleteUser.BackgroundOnNormal = CType(resources.GetObject("btnDeleteUser.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnDeleteUser.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnDeleteUser.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnDeleteUser.Enabled = False
        Me.btnDeleteUser.FlatAppearance.BorderSize = 0
        Me.btnDeleteUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteUser.ForeColor = System.Drawing.Color.Black
        Me.btnDeleteUser.Location = New System.Drawing.Point(263, 254)
        Me.btnDeleteUser.Name = "btnDeleteUser"
        Me.btnDeleteUser.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteUser.TabIndex = 12
        Me.btnDeleteUser.Text = "Eliminar"
        Me.btnDeleteUser.UseVisualStyleBackColor = False
        '
        'btnSaveUser
        '
        Me.btnSaveUser.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveUser.BackgroundImage = CType(resources.GetObject("btnSaveUser.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveUser.BackgroundOnClick = CType(resources.GetObject("btnSaveUser.BackgroundOnClick"), System.Drawing.Image)
        Me.btnSaveUser.BackgroundOnDisabled = CType(resources.GetObject("btnSaveUser.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnSaveUser.BackgroundOnHover = CType(resources.GetObject("btnSaveUser.BackgroundOnHover"), System.Drawing.Image)
        Me.btnSaveUser.BackgroundOnNormal = CType(resources.GetObject("btnSaveUser.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnSaveUser.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnSaveUser.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnSaveUser.Enabled = False
        Me.btnSaveUser.FlatAppearance.BorderSize = 0
        Me.btnSaveUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSaveUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveUser.ForeColor = System.Drawing.Color.Black
        Me.btnSaveUser.Location = New System.Drawing.Point(180, 254)
        Me.btnSaveUser.Name = "btnSaveUser"
        Me.btnSaveUser.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveUser.TabIndex = 11
        Me.btnSaveUser.Text = "Guardar"
        Me.btnSaveUser.UseVisualStyleBackColor = False
        '
        'btnEditUser
        '
        Me.btnEditUser.BackColor = System.Drawing.Color.Transparent
        Me.btnEditUser.BackgroundImage = CType(resources.GetObject("btnEditUser.BackgroundImage"), System.Drawing.Image)
        Me.btnEditUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditUser.BackgroundOnClick = CType(resources.GetObject("btnEditUser.BackgroundOnClick"), System.Drawing.Image)
        Me.btnEditUser.BackgroundOnDisabled = CType(resources.GetObject("btnEditUser.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnEditUser.BackgroundOnHover = CType(resources.GetObject("btnEditUser.BackgroundOnHover"), System.Drawing.Image)
        Me.btnEditUser.BackgroundOnNormal = CType(resources.GetObject("btnEditUser.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnEditUser.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnEditUser.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnEditUser.Enabled = False
        Me.btnEditUser.FlatAppearance.BorderSize = 0
        Me.btnEditUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnEditUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditUser.ForeColor = System.Drawing.Color.Black
        Me.btnEditUser.Location = New System.Drawing.Point(97, 254)
        Me.btnEditUser.Name = "btnEditUser"
        Me.btnEditUser.Size = New System.Drawing.Size(75, 23)
        Me.btnEditUser.TabIndex = 10
        Me.btnEditUser.Text = "Editar"
        Me.btnEditUser.UseVisualStyleBackColor = False
        '
        'btnNewUser
        '
        Me.btnNewUser.BackColor = System.Drawing.Color.Transparent
        Me.btnNewUser.BackgroundImage = CType(resources.GetObject("btnNewUser.BackgroundImage"), System.Drawing.Image)
        Me.btnNewUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNewUser.BackgroundOnClick = CType(resources.GetObject("btnNewUser.BackgroundOnClick"), System.Drawing.Image)
        Me.btnNewUser.BackgroundOnDisabled = CType(resources.GetObject("btnNewUser.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnNewUser.BackgroundOnHover = CType(resources.GetObject("btnNewUser.BackgroundOnHover"), System.Drawing.Image)
        Me.btnNewUser.BackgroundOnNormal = CType(resources.GetObject("btnNewUser.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnNewUser.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnNewUser.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnNewUser.FlatAppearance.BorderSize = 0
        Me.btnNewUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNewUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewUser.ForeColor = System.Drawing.Color.Black
        Me.btnNewUser.Location = New System.Drawing.Point(14, 254)
        Me.btnNewUser.Name = "btnNewUser"
        Me.btnNewUser.Size = New System.Drawing.Size(75, 23)
        Me.btnNewUser.TabIndex = 9
        Me.btnNewUser.Text = "Nuevo"
        Me.btnNewUser.UseVisualStyleBackColor = False
        '
        'cboxStatus
        '
        Me.cboxStatus.AutoSize = True
        Me.cboxStatus.Checked = True
        Me.cboxStatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cboxStatus.Enabled = False
        Me.cboxStatus.ForeColor = System.Drawing.Color.Black
        Me.cboxStatus.Location = New System.Drawing.Point(80, 230)
        Me.cboxStatus.Name = "cboxStatus"
        Me.cboxStatus.Size = New System.Drawing.Size(62, 17)
        Me.cboxStatus.TabIndex = 8
        Me.cboxStatus.Text = "Activo"
        Me.cboxStatus.UseVisualStyleBackColor = True
        '
        'txtDni
        '
        Me.txtDni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDni.CaracterDecimal = False
        Me.txtDni.Enabled = False
        Me.txtDni.HintText = "Hint Text"
        Me.txtDni.HintTextColor = System.Drawing.Color.Gray
        Me.txtDni.HintTextEnabled = False
        Me.txtDni.Location = New System.Drawing.Point(80, 25)
        Me.txtDni.MaxLength = 10
        Me.txtDni.Name = "txtDni"
        Me.txtDni.OnEnterKeyPressed = ZUControls.ZUNumericBox.EnterKeyPressed.doNothing
        Me.txtDni.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtDni.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtDni.Size = New System.Drawing.Size(344, 20)
        Me.txtDni.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(28, 28)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(46, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Cédula"
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtEmail.Enabled = False
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.HintText = "Hint Text"
        Me.txtEmail.HintTextColor = System.Drawing.Color.Gray
        Me.txtEmail.HintTextEnabled = False
        Me.txtEmail.Location = New System.Drawing.Point(80, 100)
        Me.txtEmail.MaxLength = 150
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtEmail.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtEmail.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtEmail.Size = New System.Drawing.Size(344, 20)
        Me.txtEmail.TabIndex = 3
        '
        'txtLastName
        '
        Me.txtLastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Enabled = False
        Me.txtLastName.ForeColor = System.Drawing.Color.Black
        Me.txtLastName.HintText = "Hint Text"
        Me.txtLastName.HintTextColor = System.Drawing.Color.Gray
        Me.txtLastName.HintTextEnabled = False
        Me.txtLastName.Location = New System.Drawing.Point(80, 75)
        Me.txtLastName.MaxLength = 50
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtLastName.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtLastName.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtLastName.Size = New System.Drawing.Size(344, 20)
        Me.txtLastName.TabIndex = 2
        '
        'txtFirstName
        '
        Me.txtFirstName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Enabled = False
        Me.txtFirstName.ForeColor = System.Drawing.Color.Black
        Me.txtFirstName.HintText = "Hint Text"
        Me.txtFirstName.HintTextColor = System.Drawing.Color.Gray
        Me.txtFirstName.HintTextEnabled = False
        Me.txtFirstName.Location = New System.Drawing.Point(80, 50)
        Me.txtFirstName.MaxLength = 50
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtFirstName.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtFirstName.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtFirstName.Size = New System.Drawing.Size(344, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'txtPass
        '
        Me.txtPass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPass.Enabled = False
        Me.txtPass.ForeColor = System.Drawing.Color.Black
        Me.txtPass.HintText = "Hint Text"
        Me.txtPass.HintTextColor = System.Drawing.Color.Gray
        Me.txtPass.HintTextEnabled = False
        Me.txtPass.Location = New System.Drawing.Point(80, 201)
        Me.txtPass.MaxLength = 15
        Me.txtPass.Name = "txtPass"
        Me.txtPass.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtPass.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtPass.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(344, 20)
        Me.txtPass.TabIndex = 7
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress.Enabled = False
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.HintText = "Hint Text"
        Me.txtAddress.HintTextColor = System.Drawing.Color.Gray
        Me.txtAddress.HintTextEnabled = False
        Me.txtAddress.Location = New System.Drawing.Point(80, 175)
        Me.txtAddress.MaxLength = 200
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtAddress.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtAddress.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtAddress.Size = New System.Drawing.Size(344, 20)
        Me.txtAddress.TabIndex = 6
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.ForeColor = System.Drawing.Color.Black
        Me.label7.Location = New System.Drawing.Point(28, 231)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(46, 13)
        Me.label7.TabIndex = 0
        Me.label7.Text = "Estado"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.Color.Black
        Me.label4.Location = New System.Drawing.Point(3, 204)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(71, 13)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Contraseña"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.ForeColor = System.Drawing.Color.Black
        Me.label3.Location = New System.Drawing.Point(13, 178)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(61, 13)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Dirección"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(6, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Teléfono 2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Teléfono 1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(33, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "E-mail"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Apellidos"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(18, 53)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(56, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Nombres"
        '
        'dgvUsers
        '
        Me.dgvUsers.AllowUserToAddRows = False
        Me.dgvUsers.AllowUserToDeleteRows = False
        Me.dgvUsers.AllowUserToResizeColumns = False
        Me.dgvUsers.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        Me.dgvUsers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvUsers.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvUsers.BackgroundHeader = CType(resources.GetObject("dgvUsers.BackgroundHeader"), System.Drawing.Image)
        Me.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvUsers_dni, Me.dgvUsers_first_name, Me.dgvUsers_last_name, Me.dgvUsers_email, Me.dgvUsers_phone_number1, Me.dgvUsers_phone_number2, Me.dgvUsers_address, Me.dgvUsers_pass, Me.dgvUsers_status, Me.dgvUsers_user_id})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUsers.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsers.GridColor = System.Drawing.SystemColors.Control
        Me.dgvUsers.HeaderFontSize = 7.0!
        Me.dgvUsers.HeaderForeColor = System.Drawing.Color.White
        Me.dgvUsers.Location = New System.Drawing.Point(0, 285)
        Me.dgvUsers.MultiSelect = False
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.ReadOnly = True
        Me.dgvUsers.RowHeadersVisible = False
        Me.dgvUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsers.Size = New System.Drawing.Size(434, 266)
        Me.dgvUsers.TabIndex = 1
        '
        'dgvUsers_dni
        '
        Me.dgvUsers_dni.HeaderText = "CÉDULA"
        Me.dgvUsers_dni.Name = "dgvUsers_dni"
        Me.dgvUsers_dni.ReadOnly = True
        Me.dgvUsers_dni.Width = 81
        '
        'dgvUsers_first_name
        '
        Me.dgvUsers_first_name.HeaderText = "NOMBRES"
        Me.dgvUsers_first_name.Name = "dgvUsers_first_name"
        Me.dgvUsers_first_name.ReadOnly = True
        Me.dgvUsers_first_name.Width = 93
        '
        'dgvUsers_last_name
        '
        Me.dgvUsers_last_name.HeaderText = "APELLIDOS"
        Me.dgvUsers_last_name.Name = "dgvUsers_last_name"
        Me.dgvUsers_last_name.ReadOnly = True
        '
        'dgvUsers_email
        '
        Me.dgvUsers_email.HeaderText = "EMAIL"
        Me.dgvUsers_email.Name = "dgvUsers_email"
        Me.dgvUsers_email.ReadOnly = True
        Me.dgvUsers_email.Visible = False
        Me.dgvUsers_email.Width = 69
        '
        'dgvUsers_phone_number1
        '
        Me.dgvUsers_phone_number1.HeaderText = "TELEFONO 1"
        Me.dgvUsers_phone_number1.Name = "dgvUsers_phone_number1"
        Me.dgvUsers_phone_number1.ReadOnly = True
        Me.dgvUsers_phone_number1.Visible = False
        Me.dgvUsers_phone_number1.Width = 108
        '
        'dgvUsers_phone_number2
        '
        Me.dgvUsers_phone_number2.HeaderText = "TELEFONO 2"
        Me.dgvUsers_phone_number2.Name = "dgvUsers_phone_number2"
        Me.dgvUsers_phone_number2.ReadOnly = True
        Me.dgvUsers_phone_number2.Visible = False
        Me.dgvUsers_phone_number2.Width = 108
        '
        'dgvUsers_address
        '
        Me.dgvUsers_address.HeaderText = "DIRECCION"
        Me.dgvUsers_address.Name = "dgvUsers_address"
        Me.dgvUsers_address.ReadOnly = True
        Me.dgvUsers_address.Visible = False
        '
        'dgvUsers_pass
        '
        Me.dgvUsers_pass.HeaderText = "CONTRASEÑA"
        Me.dgvUsers_pass.Name = "dgvUsers_pass"
        Me.dgvUsers_pass.ReadOnly = True
        Me.dgvUsers_pass.Visible = False
        Me.dgvUsers_pass.Width = 116
        '
        'dgvUsers_status
        '
        Me.dgvUsers_status.HeaderText = "STATUS"
        Me.dgvUsers_status.Name = "dgvUsers_status"
        Me.dgvUsers_status.ReadOnly = True
        Me.dgvUsers_status.Visible = False
        Me.dgvUsers_status.Width = 81
        '
        'dgvUsers_user_id
        '
        Me.dgvUsers_user_id.HeaderText = "ID USUARIO"
        Me.dgvUsers_user_id.Name = "dgvUsers_user_id"
        Me.dgvUsers_user_id.ReadOnly = True
        Me.dgvUsers_user_id.Visible = False
        Me.dgvUsers_user_id.Width = 105
        '
        'bgwSavingUsers
        '
        Me.bgwSavingUsers.WorkerReportsProgress = True
        Me.bgwSavingUsers.WorkerSupportsCancellation = True
        '
        'bgwDeletingUsers
        '
        Me.bgwDeletingUsers.WorkerReportsProgress = True
        Me.bgwDeletingUsers.WorkerSupportsCancellation = True
        '
        'panelLoading
        '
        Me.panelLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelLoading.Controls.Add(Me.lblLoading)
        Me.panelLoading.Controls.Add(Me.pboxLoading)
        Me.panelLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelLoading.Location = New System.Drawing.Point(0, 531)
        Me.panelLoading.Name = "panelLoading"
        Me.panelLoading.Size = New System.Drawing.Size(434, 20)
        Me.panelLoading.TabIndex = 18
        Me.panelLoading.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLoading.Location = New System.Drawing.Point(0, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(404, 20)
        Me.lblLoading.TabIndex = 16
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pboxLoading
        '
        Me.pboxLoading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pboxLoading.Dock = System.Windows.Forms.DockStyle.Right
        Me.pboxLoading.Image = Global.ZUtracking.My.Resources.Resources.loading
        Me.pboxLoading.Location = New System.Drawing.Point(404, 0)
        Me.pboxLoading.Name = "pboxLoading"
        Me.pboxLoading.Size = New System.Drawing.Size(30, 20)
        Me.pboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxLoading.TabIndex = 15
        Me.pboxLoading.TabStop = False
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 551)
        Me.Controls.Add(Me.panelLoading)
        Me.Controls.Add(Me.dgvUsers)
        Me.Controls.Add(Me.gboxData)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(450, 590)
        Me.Name = "frmUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "USUARIOS"
        Me.gboxData.ResumeLayout(False)
        Me.gboxData.PerformLayout()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLoading.ResumeLayout(False)
        CType(Me.pboxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents gboxData As GroupBox
    Private WithEvents cboxStatus As CheckBox
    Private WithEvents txtDni As ZUControls.ZUNumericBox
    Private WithEvents label1 As Label
    Private WithEvents txtEmail As ZUControls.ZUTextBox
    Private WithEvents txtLastName As ZUControls.ZUTextBox
    Private WithEvents txtFirstName As ZUControls.ZUTextBox
    Private WithEvents txtPass As ZUControls.ZUTextBox
    Private WithEvents txtAddress As ZUControls.ZUTextBox
    Private WithEvents label7 As Label
    Private WithEvents label4 As Label
    Private WithEvents label3 As Label
    Private WithEvents Label10 As Label
    Private WithEvents Label9 As Label
    Private WithEvents Label8 As Label
    Private WithEvents Label5 As Label
    Private WithEvents label2 As Label
    Friend WithEvents btnCancelUser As ZUControls.ZUButton
    Friend WithEvents btnDeleteUser As ZUControls.ZUButton
    Friend WithEvents btnSaveUser As ZUControls.ZUButton
    Friend WithEvents btnEditUser As ZUControls.ZUButton
    Friend WithEvents btnNewUser As ZUControls.ZUButton
    Friend WithEvents dgvUsers As ZUControls.ZUDataGridView
    Friend WithEvents bgwSavingUsers As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwDeletingUsers As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtPhoneNumber2 As ZUControls.ZUNumericBox
    Friend WithEvents txtPhoneNumber1 As ZUControls.ZUNumericBox
    Friend WithEvents dgvUsers_dni As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_first_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_last_name As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_email As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_phone_number1 As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_phone_number2 As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_address As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_pass As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_status As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers_user_id As DataGridViewTextBoxColumn
    Friend WithEvents panelLoading As ZUControls.ZUPanel
    Friend WithEvents lblLoading As Label
    Friend WithEvents pboxLoading As PictureBox
End Class
