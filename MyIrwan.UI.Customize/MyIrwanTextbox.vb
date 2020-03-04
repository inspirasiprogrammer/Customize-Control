Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace MyIrwan.UI.Customize
#Region ">> Enumerators <<"

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Enum EConversion
        Normal = 0
        UpperCase = 1
    End Enum

#End Region

    Public Class MyIrwanTextbox
        Inherits TextBox

        Private Shared ReadOnly DEFAULT_MAX_LENGTH As Integer = 20

        Private _enterFocusColor As Color = Color.White
        Private _leaveFocusColor As Color = Color.White
        Private _conversion As EConversion
        Private _isSelectionText As Boolean = False
        Private _isThousandSeparator As Boolean = False
        Private _isNumericOnly As Boolean = False
        Private _isLetterOnly As Boolean = False
        Private _isAutoEnter As Boolean = False
        Private _isDecimal As Boolean = False

#Region ">> property <<"

        Public Overrides Property MaxLength() As Integer
            Get
                Return MyBase.MaxLength
            End Get

            Set(ByVal value As Integer)
                If Me._isThousandSeparator AndAlso value > DEFAULT_MAX_LENGTH Then
                    value = DEFAULT_MAX_LENGTH
                End If
                MyBase.MaxLength = value
            End Set
        End Property

        <System.ComponentModel.Category("MyIrwanTextbox Properties")>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property EnterFocusColor() As Color
            Get
                Return _enterFocusColor
            End Get

            Set(ByVal value As Color)
                _enterFocusColor = value
            End Set
        End Property

        <System.ComponentModel.Category("MyIrwanTextbox Properties")>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property LeaveFocusColor() As Color
            Get
                Return _leaveFocusColor
            End Get

            Set(ByVal value As Color)
                _leaveFocusColor = value
            End Set
        End Property

        <System.ComponentModel.Category("MyIrwanTextbox Properties")>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property SelectionText() As Boolean
            Get
                Return _isSelectionText
            End Get
            Set(ByVal value As Boolean)
                _isSelectionText = value
            End Set
        End Property

        <System.ComponentModel.Category("MyIrwanTextbox Properties")>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property ThousandSeparator() As Boolean
            Get
                Return _isThousandSeparator
            End Get

            Set(ByVal value As Boolean)
                _isThousandSeparator = value

                If _isThousandSeparator Then
                    _isNumericOnly = True
                    Me.MaxLength = DEFAULT_MAX_LENGTH
                    Me.TextAlign = HorizontalAlignment.Right
                    Me.Text = "0"
                End If
            End Set
        End Property

        <System.ComponentModel.Category("MyIrwanTextbox Properties")>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property NumericOnly() As Boolean
            Get
                Return _isNumericOnly
            End Get
            Set(ByVal value As Boolean)
                _isNumericOnly = value
            End Set
        End Property

        <System.ComponentModel.Category("MyIrwanTextbox Properties")>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property LetterOnly() As Boolean
            Get
                Return _isLetterOnly
            End Get
            Set(ByVal value As Boolean)
                _isLetterOnly = value
            End Set
        End Property

        <System.ComponentModel.Category("MyIrwanTextbox Properties")>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property AutoEnter() As Boolean
            Get
                Return _isAutoEnter
            End Get
            Set(ByVal value As Boolean)
                _isAutoEnter = value
            End Set
        End Property

        <System.ComponentModel.Category("MyIrwanTextbox Properties")>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property Conversion() As EConversion
            Get
                Return _conversion
            End Get
            Set(ByVal value As EConversion)
                _conversion = value
            End Set
        End Property

#End Region

        Public Sub New()
            AddHandler TextChanged, AddressOf MyIrwanTextbox_TextChanged
            AddHandler Leave, AddressOf MyIrwanTextbox_Leave
            AddHandler KeyPress, AddressOf MyIrwanTextbox_KeyPress
            AddHandler Enter, AddressOf MyIrwanTextbox_Enter
            AddHandler EnabledChanged, AddressOf MyIrwanTextbox_EnabledChanged
        End Sub

#Region ">> delegate method <<"

        Private Sub MyIrwanTextbox_EnabledChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.BackColor = If(Me.Enabled, Me._leaveFocusColor, Color.FromArgb(232, 235, 242))
        End Sub

        Private Sub MyIrwanTextbox_Enter(ByVal sender As Object, ByVal e As EventArgs)
            If Me._isSelectionText Then
                SeleksiText(DirectCast(sender, System.Windows.Forms.TextBox))
            End If

            If Not Me.ReadOnly Then
                Me.BackColor = Me._enterFocusColor
            End If
        End Sub

        Private Sub MyIrwanTextbox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            If Me._isAutoEnter Then
                If e.KeyChar = CChar(CChar(CStr(Keys.Return))) Then
                    SendKeys.Send("{Tab}")
                End If
            End If

            If Me._isNumericOnly Then
                If _isDecimal AndAlso e.KeyChar = "."c Then
                    e.Handled = True
                Else
                    e.Handled = ValidasiAngka(e)
                End If

            ElseIf Me._isLetterOnly Then
                If Me._conversion = EConversion.UpperCase Then
                    e.KeyChar = HurufBesar(e)
                End If
                e.Handled = ValidasiHuruf(e)

            ElseIf Me._conversion = EConversion.UpperCase Then
                e.KeyChar = HurufBesar(e)
            End If
        End Sub

        Private Sub MyIrwanTextbox_Leave(ByVal sender As Object, ByVal e As EventArgs)
            If Me._isNumericOnly Then
                If Not (Me.Text.Length > 0) Then
                    Me.Text = "0"
                End If
            End If

            Me.BackColor = Me._leaveFocusColor
        End Sub

        Private Sub MyIrwanTextbox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            _isDecimal = False

            Dim index As Integer = Me.Text.IndexOf(".")
            _isDecimal = Not (index < 0)

            If Me._isNumericOnly AndAlso Me._isThousandSeparator Then
                If Me.Text.Length > 0 Then
                    If Me.Text.Substring(0, 1) = "." Then
                        Me.Text = Me.Text.Replace(".", "")
                    End If

                    Dim tmp = Me.Text.Replace(",", "")
                    If _isDecimal Then
                        tmp = Math.Round(Convert.ToDouble(tmp), MidpointRounding.AwayFromZero).ToString()
                    End If

                    Dim strAfterFormat As String = String.Format("{0:N0}", Convert.ToInt64(tmp))

                    If Me.Text <> strAfterFormat Then
                        Dim pos As Integer = Me.Text.Length - Me.SelectionStart

                        Me.Text = strAfterFormat
                        If ((Me.Text.Length - pos) < 0) Then
                            Me.SelectionStart = 0
                        Else
                            Me.SelectionStart = Me.Text.Length - pos
                        End If
                    End If
                End If
            End If
        End Sub

#End Region

#Region ">> private method <<"

        Private Function HurufBesar(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Char
            Return Convert.ToChar(e.KeyChar.ToString().ToUpper())
        End Function

        Private Sub SeleksiText(ByVal sender As System.Windows.Forms.TextBox)
            sender.SelectionStart = 0
            sender.SelectionLength = sender.Text.Length
        End Sub

        Private Function ValidasiAngka(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
            Dim strValid = "0123456789"

            If Not _isThousandSeparator Then
                strValid &= "."
            End If

            Dim pos = strValid.IndexOf(e.KeyChar)
            If pos < 0 AndAlso Not (e.KeyChar = CChar(CChar(CStr(Keys.Back)))) Then
                Return True ' not valid
            Else
                Return False ' valid
            End If
        End Function

        Private Function ValidasiHuruf(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
            Dim strValid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ. "

            Dim pos = strValid.IndexOf(e.KeyChar)
            If pos < 0 AndAlso Not (e.KeyChar = CChar(CChar(CStr(Keys.Back)))) Then
                Return True ' not valid
            Else
                Return False ' valid
            End If
        End Function

#End Region
    End Class
End Namespace
