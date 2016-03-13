using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data.SqlClient; 
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class editlesson : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=True");
    private SqlCommand com = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con.Open();
            com.CommandText = "select base,ns from tblschool where id=" + Session["id_s"].ToString();
            com.Connection = con;
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            lbltitr.Text = "آموزشگاه" + " " + dr["ns"].ToString();
            Session.Add("ba3", dr["base"].ToString());
            Session.Add("ba4", dr["base"].ToString());
            if (dr["base"].ToString() == "3")
                Session.Add("r1",1);  
            else
                Session.Add("r1", 0);

        }
    }
    protected void DropDownList1_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("");
            DropDownList1.SelectedIndex = DropDownList1.Items.Count - 1;   
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        if (DropDownList1.SelectedValue != "اول دبیرستان" && Session["ba4"].ToString() == "3" && DropDownList1.SelectedValue != "")
        {
            DropDownList2.Visible = true;
            Label2.Visible = true;
            

        }
        else if (DropDownList1.SelectedValue == "اول دبیرستان" && Session["ba4"].ToString() == "3" && DropDownList1.SelectedValue != "")
        {

            DropDownList2.Visible = false;
            Label2.Visible = false;
            Panel2.Visible = true;
            Session["r1"] = 1;
            Session["ba3"] = 1;

        }
        else
        {
            int i = DropDownList1.SelectedIndex;
            i++;
            Session["r1"] = 0;
            Session["ba3"] = i;
            Panel2.Visible = true;

        }
        /*  
        
        if (Session["ba3"].ToString() != "3" && DropDownList1.SelectedValue!="")
        {
            Panel2.Visible = true;

            SqlDataAdapter da = new SqlDataAdapter("select code,name,zarib,date1,date2,id_school from lesson where id_school=" + Session["id_s"].ToString() + " and yer=" + i, con);
            DataSet ds = new DataSet();
            da.Fill(ds,"t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();


        }
        
        if (DropDownList1.SelectedValue == "اول دبیرستان" && Session["ba3"].ToString() == "3" && DropDownList1.SelectedValue != "")
        {
            Panel2.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter("select code,name,zarib,date1,date2,id_school from lesson where id_school=" + Session["id_s"].ToString() + " and yer=" + i, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            
        }*/
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        if (DropDownList2.SelectedValue != "")
        {
            int i = DropDownList2.SelectedIndex;
            i++;
            int i1 = DropDownList1.SelectedIndex;
            i1++;
            Panel2.Visible = true;
            Session["r1"] = i;
            Session["ba3"] = i1; 
        }
        /* 
         
            
            SqlDataAdapter da = new SqlDataAdapter("select code,name,zarib,date1,date2,id_school from lesson where id_school=" + Session["id_s"].ToString() + " and yer=" + i1 + " and resh=" + i, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSourceID = "";   
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
        }*/

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Remove ("r1");
        Session.Remove("ba3");
        Session.Remove("ba4");
        Response.Redirect("PageSchool.aspx");  

    }
}
