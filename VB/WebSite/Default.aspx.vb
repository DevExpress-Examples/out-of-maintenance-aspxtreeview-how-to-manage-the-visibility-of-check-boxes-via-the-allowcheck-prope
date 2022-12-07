Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			ASPxTreeView1.AllowCheckNodes = Not(ASPxRadioButtonList1.SelectedIndex = 0)
			ASPxTreeView1.ExpandAll()
		End If
	End Sub

	Protected Sub ASPxRadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim rblOptions As ASPxRadioButtonList = TryCast(sender, ASPxRadioButtonList)
		Select Case rblOptions.SelectedIndex
			Case 0
				ASPxTreeView1.AllowCheckNodes = False
			Case 1
				ASPxTreeView1.AllowCheckNodes = True
				PerformActionOnNodesRecursive(ASPxTreeView1.Nodes, AddressOf AnonymousMethod1)
			Case 2
				ASPxTreeView1.AllowCheckNodes = True
				PerformActionOnNodesRecursive(ASPxTreeView1.Nodes, AddressOf AnonymousMethod2)
		End Select
	End Sub
	
	Private Sub AnonymousMethod1(ByVal node As TreeViewNode)
		node.AllowCheck = node.Nodes.Count = 0
	End Sub
	
	Private Sub AnonymousMethod2(ByVal node As TreeViewNode)
		node.AllowCheck = True
	End Sub

	Protected Sub PerformActionOnNodesRecursive(ByVal nodes As TreeViewNodeCollection, ByVal action As Action(Of TreeViewNode))
		For Each node As TreeViewNode In nodes
			action(node)
			If node.Nodes.Count > 0 Then
				PerformActionOnNodesRecursive(node.Nodes, action)
			End If
		Next node
	End Sub
	Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
		PerformActionOnNodesRecursive(ASPxTreeView1.Nodes, AddressOf AnonymousMethod3)
	End Sub
	
	Private Sub AnonymousMethod3(ByVal node As TreeViewNode)
		node.Enabled = Not node.Checked
	End Sub
	Protected Sub ASPxButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
		PerformActionOnNodesRecursive(ASPxTreeView1.Nodes, AddressOf AnonymousMethod4)
	End Sub
	
	Private Sub AnonymousMethod4(ByVal node As TreeViewNode)
		node.Enabled = True
	End Sub
End Class