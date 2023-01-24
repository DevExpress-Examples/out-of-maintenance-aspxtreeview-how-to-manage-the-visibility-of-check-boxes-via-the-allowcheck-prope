<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	 <form id="form1" runat="server">


<dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" 
	AutoPostBack="True" ClientIDMode="AutoID" 
	onselectedindexchanged="ASPxRadioButtonList1_SelectedIndexChanged" 
	SelectedIndex="0">
	<Items>
		<dx:ListEditItem Text="Hide all check boxes" Value="HideAll" />
		<dx:ListEditItem Text="Show check boxes for leaf nodes only" Value="ShowLeaves" />
		<dx:ListEditItem Text="Show all check boxes" Value="Show" />
	</Items>
</dx:ASPxRadioButtonList>


<dx:ASPxTreeView ID="ASPxTreeView1" runat="server" ClientIDMode="AutoID">
	<Nodes>
		<dx:TreeViewNode>
			<Nodes>
				<dx:TreeViewNode>
					<Nodes>
						<dx:TreeViewNode>
						</dx:TreeViewNode>
						<dx:TreeViewNode>
						</dx:TreeViewNode>
					</Nodes>
				</dx:TreeViewNode>
				<dx:TreeViewNode>
				</dx:TreeViewNode>
			</Nodes>
		</dx:TreeViewNode>
		<dx:TreeViewNode>
			<Nodes>
				<dx:TreeViewNode>
				</dx:TreeViewNode>
				<dx:TreeViewNode>
				</dx:TreeViewNode>
				<dx:TreeViewNode>
				</dx:TreeViewNode>
				<dx:TreeViewNode>
				</dx:TreeViewNode>
			</Nodes>
		</dx:TreeViewNode>
	</Nodes>
</dx:ASPxTreeView>
		 <br />
		 <br />
		 <dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Disable checked nodes">
		 </dx:ASPxButton>
		 <br />
		 <dx:ASPxButton ID="ASPxButton2" runat="server" OnClick="ASPxButton2_Click" Text="Enable checked nodes">
		 </dx:ASPxButton>
	</form>
</body>
</html>