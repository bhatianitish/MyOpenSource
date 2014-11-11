<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrafficUpdateClient._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: &quot;Trebuchet MS&quot;, &quot;Lucida Sans Unicode&quot;, &quot;Lucida Grande&quot;, &quot;Lucida Sans&quot;, Arial, sans-serif; font-size: large; background-color: #336699;">
    
        Enter City Name to fet the list of Accidents nearby. (Try entering a state name to get more incidents as there may be no reporting of incident in the city at a particular time.)<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Incidents List!" BorderStyle="Groove" />
        <br />
        <br />
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="Incident list coming soon..."></asp:Label>
    </form>
</body>
</html>
