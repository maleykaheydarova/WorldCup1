using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static WorldCup1.Enums;
using WorldCup1.Models;
using WorldCup1.Operations.Abstract;
using WorldCup1.Operations.Concrete;

namespace WorldCup1
{
    public partial class AddOrEditGroup : System.Web.UI.Page
    {
        IGroupOperation groupOperation = new GroupManager();
        private object textId;
        private object textName;

        public Mode PageMode
        {
            get
            {
                return (Mode)ViewState["PageMode"];
            }
            set
            {
                ViewState["PageMode"] = value;
            }
        }

        public int RowId
        {
            get
            {
                return (int)ViewState["ID"];
            }
            set
            {
                ViewState["ID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var queryString = Request.QueryString["ID"];
                if (queryString == null)
                {
                    PageMode = Mode.Insert;
                    textId.Text = groupOperation.GetNextId().ToString();
                }
                else
                {
                    PageMode = Mode.Edit;
                    RowId = int.Parse(Request.QueryString["ID"]);
                    BindData();
                }
            }
        }

        private void BindData()
        {
            var data = groupOperation.Get(RowId);
            textId.Text = data.ID.ToString();
            textName.Text = data.Name.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageMode == Mode.Insert)
                {
                    InsertData();
                }
                else
                {
                    UpdateData();
                }

                Response.Redirect("Groups.aspx", false);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void UpdateData()
        {
            var existingModel = groupOperation.Get(RowId);
            existingModel.Name = textName.Text;
            groupOperation.Update(existingModel);
        }

        private void InsertData()
        {
            Groups group = new Groups();
            group.ID = groupOperation.GetNextId();
            group.Name = textName.Text;

            groupOperation.Add(group);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Groups.aspx");
        }
    }
}