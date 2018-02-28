using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Menu2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDatatoGridView();
        }
        loadCartPanel();
    }

    public void BindDatatoGridView()
    {
        using (SqlConnection dbConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ok\\Documents\\Visual Studio 2017\\Projects\\Cafe_Database\\Cafe_Database\\Cafe_Database.mdf\";Integrated Security=True"))
        {
            try
            {
                dbConnection.Open();
                lblConMessage.Text = "Connection successful";

                SqlCommand command = new SqlCommand("SELECT * FROM Item", dbConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                if(dataset.Tables[0].Rows.Count>0)
                {
                    gvMenu.DataSource = dataset;
                    gvMenu.DataBind();
                }
            }

            catch (SqlException exception)
            {
                lblConMessage.Text = "Connection failed: " + exception.Message;
            }

            finally
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
        }
    }

    protected void gvMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        HiddenField hdnItemId = (HiddenField)gvMenu.SelectedRow.Cells[0].FindControl("hdnItemId");
        using (SqlConnection dbConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ok\\Documents\\Visual Studio 2017\\Projects\\Cafe_Database\\Cafe_Database\\Cafe_Database.mdf\";Integrated Security=True"))
        {
            try
            {
                dbConnection.Open();
                //lblConMessage.Text = "Connection successful";

                string sql = String.Format("SELECT * FROM Item WHERE Item_ID={0}",hdnItemId.Value);
                SqlCommand command = new SqlCommand(sql, dbConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ShoppingCart.cart.addItem(reader.GetValue(1).ToString(),1,Convert.ToInt32(reader.GetValue(3)));
                    //lblConMessage.Text = "You selected " + reader.GetValue(1);
                    Session["ShoppingCart"] = ShoppingCart.cart;
                }

                loadCartPanel();
                
            }
            catch (SqlException exception)
            {
                lblConMessage.Text = "Connection failed: " + exception.Message;
            }
            finally
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
        }
    }

    protected void loadCartPanel()
    {
        List<CartItem> cart = ShoppingCart.cart.getCart();
        tblCartPanel.Rows.Clear();
        TableRow headerRow = new TableRow();
        tblCartPanel.Rows.Add(headerRow);
        TableCell headerCell1 = new TableCell();
        TableCell headerCell2 = new TableCell();
        headerCell1.Text = "<b>Food Item</b>";
        headerCell2.Text = "<b>Quantity</b>";
        headerRow.Cells.Add(headerCell1);
        headerRow.Cells.Add(headerCell2);

        foreach (CartItem cartitem in cart)
        {
            TableRow tRow = new TableRow();
            tblCartPanel.Rows.Add(tRow);
            TableCell tCell1 = new TableCell();
            TableCell tCell2 = new TableCell();
            tCell1.Text = cartitem.Item1;
            tCell2.Text = Convert.ToString(cartitem.Item2);
            tRow.Cells.Add(tCell1);
            tRow.Cells.Add(tCell2);
        }
    }
}