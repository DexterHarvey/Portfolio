<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CPRG214.FormsLab.App.Registration" %>
<%@ Register src="Controls/Registration.ascx" tagname="Registration" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-lg-4" ID="loginTable" runat="server">
        <h3>Login:</h3>
        <table class="table">
            <tr>
                <td style="width: 100px">First Name</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button type="button" class="btn btn-primary" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button type="button" class="btn btn-primary" ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="col-lg-4" ID="registerTable" runat="server">
        <h3>Register:</h3>
        <uc1:Registration ID="Registration1" runat="server" />
    </div>

</asp:Content>
