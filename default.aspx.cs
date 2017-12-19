using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

public partial class _default : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["crudCon"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            clear();
            gridFill();
        }
    }

    protected void btninsert_Click(object sender, EventArgs e)
    {
        
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("AddOrEDIT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", (hfproductID.Value == "" ? 0 : Convert.ToInt32(hfproductID.Value)));
                    cmd.Parameters.AddWithValue("@product", txtproduct.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@count", Convert.ToInt32(txtcount.Text.Trim()));
                    cmd.Parameters.AddWithValue("@description", txtdecription.Text.Trim());
                    cmd.ExecuteNonQuery();
                    gridFill();
                    clear();
                    succes.Text = "SAVED SUCCESFULLY!";
                }
                catch (Exception ex)
                {

                    error.Text = ex.Message;
                }
               
                



            }

        }
       
    
    protected void btndelete_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("deleteById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", (hfproductID.Value==""?0:Convert.ToInt32(hfproductID.Value)));
           
            cmd.ExecuteNonQuery();
            gridFill();
            clear();
            succes.Text = "DELETED SUCCESFULLY!";




        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {

        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productid", (hfproductID.Value == "" ? 0 : Convert.ToInt32(hfproductID.Value)));
                cmd.Parameters.AddWithValue("@product", txtproduct.Text.Trim());
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtprice.Text.Trim()));
                cmd.Parameters.AddWithValue("@count", Convert.ToInt32(txtcount.Text.Trim()));
                cmd.Parameters.AddWithValue("@description", txtdecription.Text.Trim());
                cmd.ExecuteNonQuery();
                gridFill();
                clear();
                succes.Text = "Edited SUCCESFULLY!";



            }

        }
        catch (Exception ex)
        {

            error.Text = ex.Message;
        }
    }
    protected void lnk_edit(object sender, EventArgs e)
    {
        int productid = Convert.ToInt32((sender as LinkButton).CommandArgument);
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("ViewById", con);
            da.SelectCommand.Parameters.AddWithValue("@productid", productid);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtproduct.Text = dt.Rows[0][1].ToString();
            txtprice.Text = dt.Rows[0][2].ToString();
            txtcount.Text = dt.Rows[0][3].ToString();
            txtdecription.Text = dt.Rows[0][4].ToString();
            hfproductID.Value = dt.Rows[0][0].ToString();
           // btndelete.Enabled = true;
        }
    }
    protected void lnkdlt(object sender, EventArgs e)
    {
        int productid = Convert.ToInt32((sender as LinkButton).CommandArgument);
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("deleteById", con);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            gridFill();
            clear();
            succes.Text = "DELETED SUCCESFULLY!";
           
        }
    }
    public void clear()
    {
        hfproductID.Value = "";
        txtproduct.Text = txtprice.Text = txtcount.Text = txtdecription.Text = "";
       // btndelete.Enabled = false;
        succes.Text = error.Text = "";
    }
     void gridFill()
    {
        using(SqlConnection con=new SqlConnection(cs))
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("viewAll", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            grd1.DataSource = ds;
            grd1.DataBind();
        }
    }
}
	



