<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu2.aspx.cs" Inherits="Menu2" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <style type="text/css">
        .gvMenu table th {
            text-align:center;
            font-size:larger;
            color:maroon;
        }

        .borderless{
            border: none;
        }
    </style>
</head>
<body class="container-fluid">
    <form id="form1" runat="server">
        <h2>
            <asp:Label ID="lblMenu" runat="server" Text="Menu" ForeColor="#990000" Font-Bold="True"></asp:Label>
        </h2>
        <h4>
            <asp:Label ID="lblConMessage" runat="server" Text="label" style="display:none"></asp:Label>
        </h4>
        <div class="gvMenu col-lg-7">
            <asp:GridView ID="gvMenu" runat="server" CssClass="table table-striped color-table" GridLines="None" AutoGenerateColumns="false" OnSelectedIndexChanged="gvMenu_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Items">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnItemId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Item_ID") %>'/>
                            <div class="card col-xs-9 col-lg-9" style="display:inline-block; top: 0px; left: 0px;">
	                            <img class='card-img-top' src='Images/cover.jpeg' alt='Card image' style='width:100%' />
	                            <div class='card-body'>
		                            <h4 class='card-title'><%# Eval("Item_name") %></h4>
		                            <p class='card-text'><%# Eval("Item_description") %>
                                        <br /><%# Eval("Item_quantitydesc") %>
                                        <br /><h4 style='color:maroon'>Rs. <%# Eval("Item_rate") %></h4>
                                    </p>
                                <br /></div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary btn-md" SelectText="+ Add to cart"/>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-lg-offset-8 col-lg-3 col-xs-offset-8 col-xs-3 panel panel-default" style="position:fixed; text-align:center; padding:0px">
          <div class="panel-heading" style="background-color:brown; color:white"><h4>Order List</h4></div>
          <div class="panel-body" style="background-color:bisque"><asp:Table ID="tblCartPanel" runat="server" CssClass="table borderless"></asp:Table><br /><br />
              <asp:Button ID="btnConfirm" runat="server" CssClass='btn btn-primary btn-md' Text="View Cart" PostBackUrl="~/Order Checkout.aspx" /></div>
        </div>
    </form>
</body>
</html>
