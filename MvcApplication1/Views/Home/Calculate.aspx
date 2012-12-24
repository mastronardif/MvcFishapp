<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Fish Vac and Fries.
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% using (Html.BeginForm("Calculate", "Home"))
 {%>    

 <%= ViewData["Results"] %>
 
 <hr/>

  
    <table style="width:420px;" border="10">
    <CAPTION style="background-color:Aqua; color:Black;">Vaccine model</CAPTION>
    <tr> <td>F8</td>  <td align="right"> Fish released in week nr   </td>  <td align="right">  <select id="F8" name="F8">
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="4">4</option>
        <option value="5">5</option>
        <option value="6">6</option>
        <option selected value="<%= ViewData["F8"] %>">  <%= ViewData["F8"] %> </option>
    </select>
    </td>
    </tr>

    <tr> <td>F9</td> <td align="right"> Weight of smolt   </td>  <td align="right">  <select id="F9" name="F9">
        <option value="60">60</option>
        <option value="65">65</option>
        <option value="75">75</option>
        <option value="80">80</option>
        <option value="85">85</option>
        <option selected value="<%= ViewData["F9"] %>">  <%= ViewData["F9"] %> </option>
    </select>
    </td>
    </tr>
    <tr> <td>F10</td>  <td align="right"> Number of smolt released </td>  <td align="right">  <select id="F10" name="F10">
        <option value="300000">300000</option>
        <option value="350000">350000</option>
        <option value="400000">400000</option>
        <option value="450000">450000</option>
        <option value="500000">500000</option>
        <option selected value="<%= ViewData["F10"] %>">  <%= ViewData["F10"] %> </option>
    </select>
    </td>
    </tr>
    <tr><td colspan="100%" align="right"> <input type="submit" value="Run calculation" /></td>  </tr>
 </table>
    
         <i>Play along filling in F8, F9 and F10 compare the printer fiendly sheet w/ this results.</i>
    <p>
        To learn SpreadsheetGear2012 visit <a href="http://www.spreadsheetgear.com/?aw=spreadsheetgear" title="SpreadsheetGear">http://www.spreadsheetgear.com/?aw=spreadsheetgear</a>.
    </p>


<%} %>
</asp:Content>
