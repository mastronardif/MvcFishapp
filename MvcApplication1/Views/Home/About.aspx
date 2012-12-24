<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
 <% using (Html.BeginForm("Calculate", "Home"))
    {%>
    <h2>About</h2>
    <p>
        Fish released in week nr [F8]: <input type="text" name="F8" value="19" maxlength="10" size="10"  /><br>
                                Email: <input type="text" name="email" size="35"><br>
                                  PIN: <input type="text" name="pin" maxlength="4" size="4"><br>

         <input type="submit" value="Run the SH" />
         <%: Html.ActionLink("Run the spread sheet", "Calculate")%>
    </p>

<%= ViewData["Results"] %>
    <%} %>
</asp:Content>
