<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSurvey.aspx.cs" Inherits="Sefin.AskMe.WebFormApp.Management.EditSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label runat="server" ID="LblTitle" /></h1>

    <asp:FormView runat="server" ID="FormSurvey"
        DefaultMode="Edit"
        SelectMethod="FormSurvey_GetItem"
        UpdateMethod="FormSurvey_UpdateItem"
        Width="100%"
        >
        <EditItemTemplate>
            <div class="panel panel-default">
                <div class="panel-body">
                    
                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox runat="server" CssClass="form-control"
                            ID="TxtName" Text='<%# Bind("Name") %>' />

                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="TxtName" 
                            SetFocusOnError="true" 
                            ErrorMessage="Field Required" />
                        
                    </div>

                    <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox runat="server" CssClass="form-control"
                            TextMode="MultiLine"
                            ID="TxtDescription" Text='<%# Bind("Description") %>' />
                    </div>

                    <div class="form-group">
                        <label>Number of questions</label>
                        <asp:DropDownList runat="server" CssClass="form-control"
                            Id="DdlNumQuestions" 
                            SelectedValue='<%# Bind("NumberOfQuestions") %>'>
                            
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <div class="form-group">
                        <label>Active</label>
                        <asp:CheckBox runat="server" CssClass="form-control"
                            ID="ChkActive" Checked='<%# Bind("Active") %>' />
                    </div>

                    
                </div>

                <div class="panel-footer">

                    <asp:LinkButton runat="server" CssClass="btn btn-default"
                        CommandName="Update"
                        >
                        Save
                    </asp:LinkButton>


                </div>
            </div>

            

        </EditItemTemplate>
    </asp:FormView>


</asp:Content>
