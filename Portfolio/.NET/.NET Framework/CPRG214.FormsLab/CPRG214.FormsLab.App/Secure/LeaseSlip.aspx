<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="CPRG214.FormsLab.App.Secure.LeaseSlip" %>

<%@ Register Src="~/Controls/CurrentLeases.ascx" TagPrefix="uc1" TagName="CurrentLeases" %>
<%@ Register Src="~/Controls/Docks.ascx" TagPrefix="uc1" TagName="Docks" %>
<%@ Register Src="~/Controls/AvailableSlips.ascx" TagPrefix="uc1" TagName="AvailableSlips" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Lease a slip here:</h3>
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
    <asp:Button ID="btnLease" runat="server" Text="Lease" OnClick="btnLease_Click"/>
    </form>
    <br />
    <br />
    <br />
    <h3>Your leases:</h3>
    <uc1:CurrentLeases runat="server" ID="CurrentLeases" />
    <br />

    </asp:Content>
