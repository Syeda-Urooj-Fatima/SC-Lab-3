using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Order_Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //loadCheckoutHeaders();
        loadOrder();
    }

    protected SqlConnection databaseConnect()
    {
        SqlConnection dbConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ok\\Documents\\Visual Studio 2017\\Projects\\Cafe_Database\\Cafe_Database\\Cafe_Database.mdf\";Integrated Security=True");
        try
        {
            dbConnection.Open();
        }

        catch (SqlException exception)
        {
            lblMessage.Text = "Connection failed: " + exception.Message;
        }
        return dbConnection;
        
    }

    protected int getPrice(SqlConnection dbConnection, string product)
    {
        int rate = 0;
        try
        {
            string sql = String.Format("SELECT * FROM Item WHERE Item_name={0}", product);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                rate = Convert.ToInt32(reader.GetValue(3));                
            }
        }

        catch (SqlException exception)
        {
            lblMessage.Text = "Database Error: " + exception.Message;
        }

        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
        return rate;
    }

    protected void gvCheckout_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)gvCheckout.Rows[e.RowIndex];

        string item_name = gvRow.Cells[0].Text;
        //lblMessage.Text = item_name;
        lblMessage.Text = "";
        ShoppingCart shopCart = (ShoppingCart)Session["ShoppingCart"];
        shopCart.removeItem(item_name, shopCart.getQuantity(item_name), shopCart.getRate(item_name));
        Session["ShoppingCart"] = shopCart;
        loadOrder();
    }

    protected void loadOrder()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Item_name", typeof(string)),
                    new DataColumn("Item_quantity", typeof(int)),
                    new DataColumn("Item_price",typeof(int)) });

        int OrderCost = 0;
        if (Session["ShoppingCart"]!=null)
        {
            List<CartItem> cart = ((ShoppingCart)Session["ShoppingCart"]).getCart();
            if (cart.Count != 0)
            {
                foreach (CartItem cartitem in cart)
                {
                    int quantity = Convert.ToInt32(cartitem.Item2);
                    int rate = Convert.ToInt32(cartitem.Item3);
                    int price = quantity * rate;
                    dt.Rows.Add(cartitem.Item1, quantity, price);
                    OrderCost += price;
                }
                gvCheckout.DataSource = dt;
                gvCheckout.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvCheckout.DataSource = dt;
                gvCheckout.DataBind();
                int TotalColumns = gvCheckout.Rows[0].Cells.Count;
                gvCheckout.Rows[0].Cells.Clear();
                gvCheckout.Rows[0].Cells.Add(new TableCell());
                gvCheckout.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                gvCheckout.Rows[0].Cells[0].Text = "No orders placed yet";
            }
        }
        else
        {
            dt.Rows.Add(dt.NewRow());
            gvCheckout.DataSource = dt;
            gvCheckout.DataBind();
            int TotalColumns = gvCheckout.Rows[0].Cells.Count;
            gvCheckout.Rows[0].Cells.Clear();
            gvCheckout.Rows[0].Cells.Add(new TableCell());
            gvCheckout.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvCheckout.Rows[0].Cells[0].Text = "No orders placed yet";
        }
        lblOrderCost.Text = "<h4><b>Total Cost: Rs." + OrderCost.ToString() + "</b></h4>";

    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        SqlConnection dbConnection = databaseConnect();
        string order = "";
        try
        {
            List<CartItem> cart = ((ShoppingCart)Session["ShoppingCart"]).getCart();
            if (cart.Count != 0)
            {
                int OrderCost = 0;
                foreach (CartItem cartitem in cart)
                {
                    if (order != "")
                        order += ", ";
                    string product = cartitem.Item1;
                    string quantity = cartitem.Item2.ToString();
                    int rate = cartitem.Item3;
                    int price = Convert.ToInt32(quantity) * rate;
                    string stringPrice = price.ToString();
                    OrderCost += price;
                    order += quantity + " " + product;
                }
            }
            lblMessage.Text = order;
            string sql;
            if (txtAddress.Text!="")
                sql = String.Format("INSERT INTO [Order] (Username, Order_Description, Delivery_Address, Pickup_Time, Order_Time, Order_Date) Values ({0},{1},{2},{3},{4},{5})", "dummy", order,txtAddress.Text,"00:00",DateTime.Now.ToString("HH:mm"),DateTime.Today.ToString("d"));

            else
                sql = String.Format("INSERT INTO [Order] (Username, Order_Description, Delivery_Address, Pickup_Time, Order_Time, Order_Date) Values ({0},{1},{2},{3},{4},{5})", "dummy", order, "", (ddlStartTimeHr.SelectedValue).ToString()+":"+ ddlStartTimeMin.SelectedValue.ToString(), DateTime.Now.ToString("HH:mm"), DateTime.Today.ToString("d"));
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        catch (SqlException exception)
        {
            //lblMessage.Text = "Database Error: " + exception.Message;
        }

        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
    }
}