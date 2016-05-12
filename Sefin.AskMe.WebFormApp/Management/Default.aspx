<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="Sefin.AskMe.WebFormApp.Management.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Survey management</h1>

    <asp:GridView ID="GridSurvey" 
        SelectMethod="GridSurvey_GetData"
        CssClass="table table-condensed table-striped table-hover table-bordered"
        AutoGenerateColumns="false"
        runat="server">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <%-- <asp:BoundField DataField="Name" HeaderText="Survey Name" /> --%>
            
            <asp:TemplateField HeaderText="Survey Name">
                <ItemTemplate>

                    <span class="glyphicon glyphicon-ok"></span>
                    <asp:Label runat="server" Text='<%# Eval("Name") %>' />

                </ItemTemplate>
            </asp:TemplateField>

            <asp:CheckBoxField DataField="Active" HeaderText="Active" />

        </Columns>


    </asp:GridView>

</asp:Content>
