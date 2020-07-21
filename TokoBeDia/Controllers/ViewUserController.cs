using System;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
namespace TokoBeDia.Controllers
{
    public class ViewUserController
    {
        public void UpdateGrid(GridView gridUser)
        {
            gridUser.DataSource = new UserHandler().GetAllUser();
            gridUser.DataBind();
        }

        public void UpdateStatus(GridView gridUser, object sender, object UserEmail, Label lblErrorChange)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);
            string status = row.Cells[3].Text;
            string email = row.Cells[2].Text;

            if (email == Convert.ToString(UserEmail))
            {
                lblErrorChange.Visible = true;
                return;
            }

            if (status == "active")
            {
                new UserHandler().UpdateStatus(ID, "blocked");
            }
            else if (status == "blocked")
            {
                new UserHandler().UpdateStatus(ID, "active");
            }

            lblErrorChange.Visible = false;
            UpdateGrid(gridUser);
        }

        public void UpdateRole(GridView gridUser,object sender, object UserEmail, Label lblErrorChange )
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(row.Cells[0].Text);
            int roleID = Convert.ToInt32(row.Cells[1].Text);
            string email = row.Cells[2].Text;

            if (email == Convert.ToString(UserEmail))
            {
                lblErrorChange.Visible = true;
                return;
            }

            if (roleID == 1)
            {
                new UserHandler().UpdateRole(ID, 2);
            }
            else if (roleID == 2)
            {
                new UserHandler().UpdateRole(ID, 1);
            }

            lblErrorChange.Visible = false;
            UpdateGrid(gridUser);
        }
    }
}