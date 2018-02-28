<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body class="container-fluid">
    <h4>
        <asp:Label ID="lblConMessage" runat="server" Text="Label"></asp:Label>
    </h4>
    <form id="form1" runat="server">
        <div>
            <ul class="list-unstyled">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </ul>
        </div>
    </form>
</body>
</html>
