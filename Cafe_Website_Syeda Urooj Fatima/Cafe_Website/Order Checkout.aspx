<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order Checkout.aspx.cs" Inherits="Order_Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style type="text/css">
        .gvCheckout table th {
            font-size:larger;
            color:maroon;
        }

    </style>
</head>
<body class="container-fluid">
    <form id="form1" runat="server">
        <h2>
            <asp:Label ID="lblCheckout" runat="server" Text="Checkout Board" ForeColor="#990000" Font-Bold="True"></asp:Label>
        </h2>
        <h4>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </h4>
        <div class="gvCheckout">
            <asp:GridView ID="gvCheckout" runat="server" CssClass="table table-striped color-table" GridLines="None" AutoGenerateColumns="false" OnRowDeleting="gvCheckout_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Item_name" HeaderText="Item" ReadOnly="True" SortExpression="Item_name"></asp:BoundField>
                        <asp:BoundField DataField="Item_quantity" HeaderText="Quantity" SortExpression="Item_quantity"></asp:BoundField>
                        <asp:BoundField DataField="Item_price" HeaderText="Price" SortExpression="Item_price"></asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-sm" DeleteText="x Remove" ShowHeader="True" HeaderText="Remove"></asp:CommandField>
                    </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Label ID="lblOrderCost" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <hr />
            <h4><b>Fill the following:</b></h4>
            In case of delivery:<br />
            <asp:TextBox ID="txtAddress" runat="server" placeholder="Delivery Address" CssClass="form-control input-sm col-lg-offset-1 col-lg-4"></asp:TextBox>
            <%--<asp:TextBox ID="txtPickupTime" runat="server" CssClass="form-control input-sm col-lg-offset-1 col-lg-4"></asp:TextBox>--%>
            <br /><br /><br />In case of pickup, select pickup time (HH:MM):&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlStartTimeHr" runat="server" CssClass="dropdown" Width="44px" >
                <asp:ListItem Text="1" Value="1" Selected="True" />
                <asp:ListItem Text="2" Value="2" />
                <asp:ListItem Text="3" Value="3" />
                <asp:ListItem Text="4" Value="4" />
                <asp:ListItem Text="5" Value="5" />
                <asp:ListItem Text="6" Value="6" />
                <asp:ListItem Text="7" Value="7" />
                <asp:ListItem Text="8" Value="8" />
                <asp:ListItem Text="9" Value="9" />
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="11" Value="11" />
                <asp:ListItem Text="12" Value="12" />
                <asp:ListItem Text="13" Value="13"/>
                <asp:ListItem Text="14" Value="14" />
                <asp:ListItem Text="15" Value="15" />
                <asp:ListItem Text="16" Value="16" />
                <asp:ListItem Text="17" Value="17" />
                <asp:ListItem Text="18" Value="18" />
                <asp:ListItem Text="19" Value="19" />
                <asp:ListItem Text="20" Value="20" />
                <asp:ListItem Text="21" Value="21" />
                <asp:ListItem Text="22" Value="22" />
                <asp:ListItem Text="23" Value="23" />
            </asp:DropDownList>
            :
            <asp:DropDownList ID="ddlStartTimeMin" runat="server" CssClass="dropdown" Width="44px" >
                <asp:ListItem Text="00" Value="00" Selected="True" />
                <asp:ListItem Text="05" Value="05" />
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="15" Value="15" />
                <asp:ListItem Text="20" Value="20" />
                <asp:ListItem Text="25" Value="25" />
                <asp:ListItem Text="30" Value="30" />
                <asp:ListItem Text="35" Value="35" />
                <asp:ListItem Text="40" Value="40" />
                <asp:ListItem Text="45" Value="45" />
                <asp:ListItem Text="50" Value="50" />
                <asp:ListItem Text="55" Value="55" />
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnConfirm" runat="server" CssClass='btn btn-primary btn-md' Text="Checkout" OnClick="btnConfirm_Click"/>
    </form>
</body>
</html>
