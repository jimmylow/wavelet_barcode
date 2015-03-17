Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Reflection


Public Class properties

    Public Sub New(ByVal Capacity As Integer)
        m_myValue = New String(Capacity - 1) {}
        MyType = New Type(Capacity - 1) {}
    End Sub

    <System.ComponentModel.Category("Data"), System.ComponentModel.Description("The Type of parameter ")> _
         Public Property Type() As Type
        Get
            Return MyType(m_index)
        End Get

        Set(ByVal value As Type)
            MyType(m_index) = value
        End Set
    End Property

    <System.ComponentModel.Category("Data"), System.ComponentModel.Description(" Enter value but whit attention Type parameter")> _
         Public Property Value() As String
        Get
            Return m_myValue(m_index)
        End Get
        Set(ByVal value As String)
            m_myValue(m_index) = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)> _
         Public Property Index() As Integer
        Get
            Return m_index
        End Get
        Set(ByVal value As Integer)
            m_index = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)> _
         Public ReadOnly Property MyValue() As String()
        Get
            Return m_myValue
        End Get
    End Property

    <System.ComponentModel.Browsable(False)> _
         Public Property TypeParameter() As Type()
        Get
            Return MyType
        End Get
        Set(ByVal value As Type())
            MyType = value
        End Set
    End Property



    Private Shared m_myValue As String()
    Private Shared m_index As Integer
    Private Shared MyType As Type()
End Class
