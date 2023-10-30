using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldCup1.Models;
using WorldCup1.Operations.Abstract;
using WorldCup1.Operations.Concrete;

namespace WorldCup1
{
    public partial class Groups : System.Web.UI.Page
    {
        public object Name { get; internal set; }

        IGroupOperation _groupOperation = new   GroupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            rptData.DataSource = LoadAllCountries();
            rptData.DataBind();
        }

        private List<Groups> LoadAllCountries()
        {
            return _groupOperation.GetAll();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddOrEditGroup.aspx");
        }

        protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    Response.Redirect("AddOrEditGroup.aspx?ID=" + e.CommandArgument.ToString());
                    break;
                case "Remove":
                    RemoveData(int.Parse(e.CommandArgument.ToString()));
                    break;
                default:
                    break;
            }
        }

        private void RemoveData(int id)
        {
            var deletedRow = _groupOperation.Get(id);
            _groupOperation.Delete(deletedRow);
            BindData();
        }
    }
}