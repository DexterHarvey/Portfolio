<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Registration.ascx.cs" Inherits="CPRG214.FormsLab.App.Controls.Registration" %>
<div class="col-lg-4" ID="registerTable" runat="server">
    <table class="table">
        <tr>
            <td style="width: 100px">First Name:</td>
            <td>
                <asp:TextBox ID="txtRegFName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">Last Name:</td>
            <td>
                <asp:TextBox ID="txtRegLName" runat="server"></asp:TextBox></td>
        </tr>
                    <tr>
            <td style="width: 100px">Phone:</td>
            <td>
                <asp:TextBox ID="txtRegPhone" runat="server" Text="XXX-XXX-XXXX"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">City:</td>
            <td>
                <asp:TextBox ID="txtRegCity" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button type="button" class="btn btn-primary" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblError" runat="server" Text="You have entered invalid information. Please try again."></asp:Label></td>
        </tr>
    </table>
</div>