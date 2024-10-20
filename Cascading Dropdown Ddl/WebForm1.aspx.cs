using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Cascading_Dropdown_Ddl
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ITD-LIS-WS-040\\SQLEXPRESS; initial catalog=dropdown; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
                displaycountry();
                ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlState.Enabled = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(btnSubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbinsert", con);
                cmd.Parameters.AddWithValue("@country", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlState.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                clear();
            }


            if(btnSubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbupdate", con);
                cmd.Parameters.AddWithValue("@id", ViewState["id"]);
                cmd.Parameters.AddWithValue("@country", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlState.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                clear();
            }
            

        }

        public void displaycountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("displaycountry",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            ddlCountry.DataValueField = "c_id";
            ddlCountry.DataTextField = "c_country";
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlState.Enabled = true;

        }
        public void displaystate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("displaystate", con);
            cmd.Parameters.AddWithValue("@c_id", ddlCountry.SelectedValue);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            ddlState.DataValueField = "s_id";
            ddlState.DataTextField = "s_name";
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ddlState.Enabled = true;
        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ddljoin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            gv.DataSource = dt;
            gv.DataBind();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaystate();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "btnedit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ddledit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                ddlCountry.SelectedValue = dt.Rows[0][1].ToString();
                displaystate();
                ddlState.SelectedValue = dt.Rows[0][2].ToString();
                btnSubmit.Text = "Update";
                ViewState["id"] = e.CommandArgument;

            }

            if(e.CommandName == "btndelete")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ddldelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();    
            }
        }

        public void clear()
        {
           ddlCountry.SelectedValue = "0";            
           ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
           ddlState.Enabled = false;
        }
    }
}