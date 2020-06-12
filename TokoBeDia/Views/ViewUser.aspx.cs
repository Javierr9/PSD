using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;
using TokoBeDia.Factories;
using TokoBeDia.Handlers;
using TokoBeDia.Controllers;

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
               new ViewUserController().UpdateGrid(gridUser);
            }
            
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            new ViewUserController().UpdateStatus(gridUser, sender, Session["UserEmail"], lblErrorChange);
        }

        protected void btnChangeRole_Click(object sender, EventArgs e)
        {
            new ViewUserController().UpdateRole(gridUser,sender, Session["UserEmail"], lblErrorChange);
           
        }
    }
}