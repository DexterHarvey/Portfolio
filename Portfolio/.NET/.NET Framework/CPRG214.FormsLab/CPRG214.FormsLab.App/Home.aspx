<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CPRG214.FormsLab.App.Home" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Inland Marina</h1>
        <p class="lead">Welcome to Inland Marina located on the south shore Inland Lake, just a small commute from
        major centers in the south west. </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Slips for Rent</h2>
            <p>
                Here at Inland Marina we have dozens of slips of all sizes to accomodate whatever kind of boating you enjoy. Make sure to check out which slips we have available right now by clicking the button below:
            </p>
            <p>
                <a class="btn btn-default" href="AvailableSlips.aspx">Available Slips &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Become a member</h2>
            <p>
                Members have exclusive access to rent the slips we provide, year-round! Membership is free and signup takes seconds. Members enjoy the dock services of electrical and fresh water. Register today!
            </p>
            <p>
                <a class="btn btn-default" href="Registration.aspx">Register &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>About Us</h2>
            <p>
                Inland Marina was established in the 1967 shortly after Inland Lake was created as a result of
the South West damn. From its humble beginnings, it has grown to be the largest marina on
Inland Lake. Due to the warm climate that extends year round, Inland Lake has become a
popular tourist destination in the south west. Boat owners from California, Arizona, Nevada,
and Utah are attracted to the area.
            </p>
        </div>
        <div>
            <img src="/Content/Images/mainpageboat.jpg" alt="boat" class="img-responsive center-block"/>
        </div>
    </div>

</asp:Content>
