using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldCup1.Models;
using WorldCup1.Operations.Abstract;
using WorldCup1.Operations.Concrete;
using static WorldCup1.Enums;

namespace WorldCup1
{
    public partial class AddOrEditCountry : System.Web.UI.Page
    {
        ICountryOperation countryOperation = new CountryManager();

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
                    txtId.Text = countryOperation.GetNextId().ToString();
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
            var data = countryOperation.Get(RowId);
            txtId.Text = data.ID.ToString();
            txtName.Text = data.Name.ToString();
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

                Response.Redirect("Countries.aspx", false);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void UpdateData()
        {
            var existingModel = countryOperation.Get(RowId);
            existingModel.Name = txtName.Text;
            countryOperation.Update(existingModel);
        }

        private void InsertData()
        {
            Country country = new Country();
            country.ID = countryOperation.GetNextId();
            country.Name = txtName.Text;

            countryOperation.Add(country);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Countries.aspx");
        }
    }
}