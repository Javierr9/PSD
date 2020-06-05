﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;

namespace TokoBeDia.Views
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserEmail"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if(Convert.ToInt32(Session["RoleId"]) == 1)//Member
            {
                int UserId = Int32.Parse(Session["UserID"].ToString());
                HeaderTransasctionHandler.updateGridDataMember(gridTransaction, UserId);
            }
            else if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                
            }
        }
    }
}