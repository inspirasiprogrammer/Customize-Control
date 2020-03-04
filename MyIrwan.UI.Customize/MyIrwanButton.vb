Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace MyIrwan.UI.Customize
    Public Class MyIrwanButton
        Inherits Button

#Region ">> property <<"


#End Region

        Public Sub New()

        End Sub

        Protected Overrides Sub OnCreateControl()
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.FlatAppearance.BorderSize = 0
            Me.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption
            Me.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight
            Me.FlatStyle = System.Windows.Forms.FlatStyle.Flat

            MyBase.OnCreateControl()
        End Sub
#Region ">> delegate method <<"

#End Region

#Region ">> private method <<"

#End Region
    End Class
End Namespace
