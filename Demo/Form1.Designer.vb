<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MyIrwanTextbox1 = New MyIrwan.UI.Customize.MyIrwan.UI.Customize.MyIrwanTextbox()
        Me.MyIrwanButton1 = New MyIrwan.UI.Customize.MyIrwan.UI.Customize.MyIrwanButton()
        Me.SuspendLayout()
        '
        'MyIrwanTextbox1
        '
        Me.MyIrwanTextbox1.AutoEnter = False
        Me.MyIrwanTextbox1.Conversion = MyIrwan.UI.Customize.MyIrwan.UI.Customize.EConversion.Normal
        Me.MyIrwanTextbox1.EnterFocusColor = System.Drawing.Color.White
        Me.MyIrwanTextbox1.LeaveFocusColor = System.Drawing.Color.White
        Me.MyIrwanTextbox1.LetterOnly = False
        Me.MyIrwanTextbox1.Location = New System.Drawing.Point(118, 95)
        Me.MyIrwanTextbox1.MaxLength = 20
        Me.MyIrwanTextbox1.Name = "MyIrwanTextbox1"
        Me.MyIrwanTextbox1.NumericOnly = True
        Me.MyIrwanTextbox1.SelectionText = False
        Me.MyIrwanTextbox1.Size = New System.Drawing.Size(258, 22)
        Me.MyIrwanTextbox1.TabIndex = 0
        Me.MyIrwanTextbox1.Text = "0"
        Me.MyIrwanTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.MyIrwanTextbox1.ThousandSeparator = True
        '
        'MyIrwanButton1
        '
        Me.MyIrwanButton1.BackColor = System.Drawing.SystemColors.Control
        Me.MyIrwanButton1.FlatAppearance.BorderSize = 0
        Me.MyIrwanButton1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MyIrwanButton1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.MyIrwanButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MyIrwanButton1.Location = New System.Drawing.Point(405, 54)
        Me.MyIrwanButton1.Name = "MyIrwanButton1"
        Me.MyIrwanButton1.Size = New System.Drawing.Size(229, 146)
        Me.MyIrwanButton1.TabIndex = 1
        Me.MyIrwanButton1.Text = "MyIrwanButton1"
        Me.MyIrwanButton1.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 299)
        Me.Controls.Add(Me.MyIrwanButton1)
        Me.Controls.Add(Me.MyIrwanTextbox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MyIrwanTextbox1 As MyIrwan.UI.Customize.MyIrwan.UI.Customize.MyIrwanTextbox
    Friend WithEvents MyIrwanButton1 As MyIrwan.UI.Customize.MyIrwan.UI.Customize.MyIrwanButton

End Class
