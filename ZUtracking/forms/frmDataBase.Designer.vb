<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDataBase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataBase))
        Me.cboDatabase = New ZUControls.ZUComboBox()
        Me.txtPassword = New ZUControls.ZUTextBox()
        Me.txtUsername = New ZUControls.ZUTextBox()
        Me.txtServer = New ZUControls.ZUTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gboxParameters = New System.Windows.Forms.GroupBox()
        Me.cboxAsDefault = New System.Windows.Forms.CheckBox()
        Me.rbtnLocal = New System.Windows.Forms.RadioButton()
        Me.rbtnRemote = New System.Windows.Forms.RadioButton()
        Me.gboxOrigin = New System.Windows.Forms.GroupBox()
        Me.btnClear = New ZUControls.ZUButton()
        Me.btnSave = New ZUControls.ZUButton()
        Me.gboxParameters.SuspendLayout()
        Me.gboxOrigin.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboDatabase
        '
        Me.cboDatabase.ForeColor = System.Drawing.Color.Black
        Me.cboDatabase.FormattingEnabled = True
        Me.cboDatabase.HintText = "Hint Text"
        Me.cboDatabase.HintTextColor = System.Drawing.Color.Gray
        Me.cboDatabase.HintTextEnabled = False
        Me.cboDatabase.Location = New System.Drawing.Point(104, 91)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.OnFocusBackColor = System.Drawing.Color.Gold
        Me.cboDatabase.OnLeaveBackColor = System.Drawing.Color.White
        Me.cboDatabase.Size = New System.Drawing.Size(207, 21)
        Me.cboDatabase.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.HintText = "Hint Text"
        Me.txtPassword.HintTextColor = System.Drawing.Color.Gray
        Me.txtPassword.HintTextEnabled = False
        Me.txtPassword.Location = New System.Drawing.Point(104, 65)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtPassword.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtPassword.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(207, 20)
        Me.txtPassword.TabIndex = 2
        '
        'txtUsername
        '
        Me.txtUsername.ForeColor = System.Drawing.Color.Black
        Me.txtUsername.HintText = "Hint Text"
        Me.txtUsername.HintTextColor = System.Drawing.Color.Gray
        Me.txtUsername.HintTextEnabled = False
        Me.txtUsername.Location = New System.Drawing.Point(104, 39)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtUsername.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtUsername.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtUsername.Size = New System.Drawing.Size(207, 20)
        Me.txtUsername.TabIndex = 1
        '
        'txtServer
        '
        Me.txtServer.ForeColor = System.Drawing.Color.Black
        Me.txtServer.HintText = "Hint Text"
        Me.txtServer.HintTextColor = System.Drawing.Color.Gray
        Me.txtServer.HintTextEnabled = False
        Me.txtServer.Location = New System.Drawing.Point(104, 13)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.OnEnterKeyPressed = ZUControls.ZUTextBox.EnterKeyPressed.doNothing
        Me.txtServer.OnFocusBackColor = System.Drawing.Color.Gold
        Me.txtServer.OnLeaveBackColor = System.Drawing.Color.White
        Me.txtServer.Size = New System.Drawing.Size(207, 20)
        Me.txtServer.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Base de Datos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Contraseña"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(42, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Usuario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(38, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Servidor"
        '
        'gboxParameters
        '
        Me.gboxParameters.Controls.Add(Me.cboDatabase)
        Me.gboxParameters.Controls.Add(Me.txtPassword)
        Me.gboxParameters.Controls.Add(Me.txtUsername)
        Me.gboxParameters.Controls.Add(Me.txtServer)
        Me.gboxParameters.Controls.Add(Me.Label4)
        Me.gboxParameters.Controls.Add(Me.Label3)
        Me.gboxParameters.Controls.Add(Me.Label2)
        Me.gboxParameters.Controls.Add(Me.Label1)
        Me.gboxParameters.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxParameters.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxParameters.Location = New System.Drawing.Point(0, 0)
        Me.gboxParameters.Name = "gboxParameters"
        Me.gboxParameters.Size = New System.Drawing.Size(317, 125)
        Me.gboxParameters.TabIndex = 0
        Me.gboxParameters.TabStop = False
        Me.gboxParameters.Text = "Parámetros"
        '
        'cboxAsDefault
        '
        Me.cboxAsDefault.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboxAsDefault.AutoSize = True
        Me.cboxAsDefault.Checked = True
        Me.cboxAsDefault.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cboxAsDefault.ForeColor = System.Drawing.Color.Black
        Me.cboxAsDefault.Location = New System.Drawing.Point(48, 50)
        Me.cboxAsDefault.Name = "cboxAsDefault"
        Me.cboxAsDefault.Size = New System.Drawing.Size(211, 17)
        Me.cboxAsDefault.TabIndex = 2
        Me.cboxAsDefault.Text = "Establecer como predeterminada"
        Me.cboxAsDefault.UseVisualStyleBackColor = True
        '
        'rbtnLocal
        '
        Me.rbtnLocal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rbtnLocal.AutoSize = True
        Me.rbtnLocal.Checked = True
        Me.rbtnLocal.ForeColor = System.Drawing.Color.Black
        Me.rbtnLocal.Location = New System.Drawing.Point(48, 19)
        Me.rbtnLocal.Name = "rbtnLocal"
        Me.rbtnLocal.Size = New System.Drawing.Size(56, 17)
        Me.rbtnLocal.TabIndex = 0
        Me.rbtnLocal.TabStop = True
        Me.rbtnLocal.Text = "Local"
        Me.rbtnLocal.UseVisualStyleBackColor = True
        '
        'rbtnRemote
        '
        Me.rbtnRemote.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rbtnRemote.AutoSize = True
        Me.rbtnRemote.ForeColor = System.Drawing.Color.Black
        Me.rbtnRemote.Location = New System.Drawing.Point(200, 19)
        Me.rbtnRemote.Name = "rbtnRemote"
        Me.rbtnRemote.Size = New System.Drawing.Size(68, 17)
        Me.rbtnRemote.TabIndex = 1
        Me.rbtnRemote.Text = "Remoto"
        Me.rbtnRemote.UseVisualStyleBackColor = True
        '
        'gboxOrigin
        '
        Me.gboxOrigin.Controls.Add(Me.cboxAsDefault)
        Me.gboxOrigin.Controls.Add(Me.rbtnLocal)
        Me.gboxOrigin.Controls.Add(Me.rbtnRemote)
        Me.gboxOrigin.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxOrigin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gboxOrigin.Location = New System.Drawing.Point(0, 125)
        Me.gboxOrigin.Name = "gboxOrigin"
        Me.gboxOrigin.Size = New System.Drawing.Size(317, 77)
        Me.gboxOrigin.TabIndex = 1
        Me.gboxOrigin.TabStop = False
        Me.gboxOrigin.Text = "Origen"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.BackgroundImage = CType(resources.GetObject("btnClear.BackgroundImage"), System.Drawing.Image)
        Me.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClear.BackgroundOnClick = CType(resources.GetObject("btnClear.BackgroundOnClick"), System.Drawing.Image)
        Me.btnClear.BackgroundOnDisabled = CType(resources.GetObject("btnClear.BackgroundOnDisabled"), System.Drawing.Image)
        Me.btnClear.BackgroundOnHover = CType(resources.GetObject("btnClear.BackgroundOnHover"), System.Drawing.Image)
        Me.btnClear.BackgroundOnNormal = CType(resources.GetObject("btnClear.BackgroundOnNormal"), System.Drawing.Image)
        Me.btnClear.BackgroundStyle = ZUControls.ZUButton.styleType.Native
        Me.btnClear.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleOrange
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(48, 208)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(87, 30)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "LIMPIAR"
        Me.btnClear.UseVisualStyleBackColor = False
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
        Me.btnSave.Location = New System.Drawing.Point(181, 208)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 30)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "GUARDAR"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'frmDataBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 242)
        Me.Controls.Add(Me.gboxOrigin)
        Me.Controls.Add(Me.gboxParameters)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(333, 281)
        Me.Name = "frmDataBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BASE DE DATOS"
        Me.gboxParameters.ResumeLayout(False)
        Me.gboxParameters.PerformLayout()
        Me.gboxOrigin.ResumeLayout(False)
        Me.gboxOrigin.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents cboDatabase As ZUControls.ZUComboBox
    Private WithEvents txtPassword As ZUControls.ZUTextBox
    Private WithEvents txtUsername As ZUControls.ZUTextBox
    Private WithEvents txtServer As ZUControls.ZUTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents gboxParameters As GroupBox
    Friend WithEvents cboxAsDefault As CheckBox
    Friend WithEvents rbtnLocal As RadioButton
    Friend WithEvents rbtnRemote As RadioButton
    Private WithEvents btnClear As ZUControls.ZUButton
    Private WithEvents btnSave As ZUControls.ZUButton
    Friend WithEvents gboxOrigin As GroupBox
End Class
