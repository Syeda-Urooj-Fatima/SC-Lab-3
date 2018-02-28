using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection dbConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ok\\Documents\\Visual Studio 2017\\Projects\\Cafe_Database\\Cafe_Database\\Cafe_Database.mdf\";Integrated Security=True"))
        {
            try
            {
                dbConnection.Open();
                lblConMessage.Text = "Connection successful";
                try
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Item", dbConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        int count = 0;
                        while(reader.Read())
                        {
                            count++;
                            //lblOutput.Text += string.Format("<li style=\"color:brown;\">{0}</li>", reader.GetValue(0));
                            lblOutput.Text += string.Format("<li>" +
                                "<div class='card col-xs-12 col-lg-3' style='display:inline-block; top: 0px; left: 0px;'>" +
                                "<img class='card-img-top' src='Images/cover.jpeg' alt='Card image' style='width:100%' />" +
                                "<div class='card-body'>" +
                                    "<h4 class='card-title'>{0}</h4>" +
                                    "<p class='card-text'>{1}" +
                                        "<br/><h4 style='color:maroon'>Rs. {2}</h4><button class='btn btn-primary btn-sm col-lg-offset-8'>+ Add to cart</button></p>" +
                                "</div><br></div>" +
                            "</li>", reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
                        }
                    }
                }
                catch (SqlException exception)
                {
                    lblOutput.Text = "<li> Select Command Failed" + exception.Message + "</li>";
                }
            }
            catch (SqlException exception)
            {
                lblConMessage.Text = "Connection failed: "+exception.Message;
            }
            finally
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
        }
    }
}