using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Repositories;

namespace TokoBeDia.Views
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserEmail"] == null && Convert.ToInt32(Session["RoleId"]) != 2)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                UpdateGridData();
            }
            
        }
        private void UpdateGridData()
        {
            gridUser.DataSource = new UserRepository().GetAllUser();
            gridUser.DataBind();
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);
            string status = row.Cells[3].Text;
            string email = row.Cells[2].Text;

            if(email == Convert.ToString(Session["UserEmail"]))
            {
                lblErrorChange.Visible = true;
                return;
            }

            if(status == "active")
            {
                new UserRepository().UpdateStatus(ID, "blocked");
            }
            else if(status == "blocked")
            {
                new UserRepository().UpdateStatus(ID, "active");
            }

            lblErrorChange.Visible = false;
            UpdateGridData();
        }

        protected void btnChangeRole_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);
            int roleID = Convert.ToInt32(row.Cells[1].Text);
            string email = row.Cells[2].Text;

            if (email == Convert.ToString(Session["UserEmail"]))
            {
                lblErrorChange.Visible = true;
                return;
            }

            if (roleID == 1)
            {
                new UserRepository().UpdateRole(ID, 2);
            }
            else if(roleID == 2)
            {
                new UserRepository().UpdateRole(ID, 1);
            }

            lblErrorChange.Visible = false;
            UpdateGridData();
        }
    }
}