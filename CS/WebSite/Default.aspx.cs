using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
#region #Check_Boxes
using DevExpress.Web.ASPxTreeView;
using DevExpress.Web.ASPxEditors;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            ASPxTreeView1.AllowCheckNodes = !(ASPxRadioButtonList1.SelectedIndex == 0);
            ASPxTreeView1.ExpandAll();
        }
    }
    
    protected void ASPxRadioButtonList1_SelectedIndexChanged(object sender, EventArgs e) {
        ASPxRadioButtonList rblOptions = sender as ASPxRadioButtonList;
        switch (rblOptions.SelectedIndex) {
            case 0:
                ASPxTreeView1.AllowCheckNodes = false;
                break;
            case 1:
                ASPxTreeView1.AllowCheckNodes = true;
                PerformActionOnNodesRecursive(ASPxTreeView1.Nodes, delegate(TreeViewNode node) { node.AllowCheck = node.Nodes.Count == 0; });
                break;
            case 2:
                ASPxTreeView1.AllowCheckNodes = true;
                PerformActionOnNodesRecursive(ASPxTreeView1.Nodes, delegate(TreeViewNode node) { node.AllowCheck = true; });
                break;
        }
    }

    protected void PerformActionOnNodesRecursive(TreeViewNodeCollection nodes, Action<TreeViewNode> action) {
        foreach (TreeViewNode node in nodes) {
            action(node);
            if (node.Nodes.Count > 0)
                PerformActionOnNodesRecursive(node.Nodes, action);
        }
    }
    protected void ASPxButton1_Click(object sender, EventArgs e) {
        PerformActionOnNodesRecursive(ASPxTreeView1.Nodes, delegate(TreeViewNode node) { node.Enabled = !node.Checked;});
    }
    protected void ASPxButton2_Click(object sender, EventArgs e) {
        PerformActionOnNodesRecursive(ASPxTreeView1.Nodes, delegate(TreeViewNode node) { node.Enabled = true; });
    }
}
#endregion #Check_Boxes