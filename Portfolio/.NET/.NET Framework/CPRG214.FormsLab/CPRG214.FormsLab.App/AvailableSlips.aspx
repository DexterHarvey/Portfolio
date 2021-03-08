<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AvailableSlips.aspx.cs" Inherits="CPRG214.FormsLab.App.AvailableSlips" %>
<%@ Register src="Controls/AvailableSlips.ascx" tagname="AvailableSlips" tagprefix="uc1" %>
<%@ Register Src="~/Controls/Docks.ascx" TagPrefix="uc1" TagName="Docks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h3>Available Slips:</h3>
    <form>
        <div class="form-group">
            <label for="ddlDocks">Dock:</label>
            <asp:DropDownList ID="ddlDocks" runat="server" OnSelectedIndexChanged="DdlDocks_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="ddlAvailable">Slip:</label>
            <asp:DropDownList ID="ddlAvailable" runat="server" OnSelectedIndexChanged="ddlAvailable_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtLength">Slip Length:</label>
            <asp:TextBox ID="txtLength" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtLength">Slip Length:</label>
            <asp:TextBox ID="txtWidth" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
    </form>
        <img src="/Content/Images/availabledock.jpg" class="img-responsive center-block" id="dock" alt="dock" />
</asp:Content>
