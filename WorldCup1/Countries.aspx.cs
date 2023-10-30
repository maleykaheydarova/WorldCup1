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
    public partial class Countries : System.Web.UI.Page
    {
        ICountryOperation _countryOperation = new CountryManager();
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

        private List<Country> LoadAllCountries()
        {
            return _countryOperation.GetAll();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddOrEditCountry.aspx");
        }

        protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    Response.Redirect("AddOrEditCountry.aspx?ID=" + e.CommandArgument.ToString());
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
            var deletedRow = _countryOperation.Get(id);
            _countryOperation.Delete(deletedRow);
            BindData();
        }
    }
}