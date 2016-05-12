<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sefin.AskMe.WebFormApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1><img src="Content/images/logo_askme_white_400_claims.png"/></h1>
        <p class="lead"></p>

        <div class="row">
            <div class="col-md-push-1 col-md-4">
                <a href="#" class="btn btn-default btn-lg btn-block">
                    <span class="glyphicon glyphicon-pencil"></span>
                    Take a survey
                </a>
            </div>
            <div class="col-md-2">
                &nbsp;
            </div>
            <div class="col-md-4">
                <a href="Management" class="btn btn-default btn-lg btn-block">
                    <span class="glyphicon glyphicon-briefcase"></span>
                Survey management
                </a>
            </div>
        </div>
    </div>


</asp:Content>
