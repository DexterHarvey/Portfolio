<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CPRG214.FormsLab.App.ContactUs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <img src="/Content/Images/contactusboat.jpg" class="img-responsive center-block" id="contactboat" alt="powerboat" />
    <h2><%: Title %>Contact Us</h2>
    <address>
        Inland Lake Marina<br />
        Inland Lake, AZ 86038<br />
        <abbr title="Office Phone">OP:</abbr>
        928-555-2234 <br />
        <abbr title="Leasing Phone">LP:</abbr>
        928-555-2235 <br />
        <abbr title="Fax">F:</abbr>
        928-555-2236
    </address>

    <address>
        <strong>Manager:</strong><p>Glenn Cooke</p><br />
        <strong>Slip Manager:</strong><p>Kimberley Carson</p><br />
        <strong>Contact Email:</strong> <a href="mailto:info@inlandmarina.com">info@inlandmarina.com</a>
    </address>
</asp:Content>
