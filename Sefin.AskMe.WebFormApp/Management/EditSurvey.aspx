<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSurvey.aspx.cs" Inherits="Sefin.AskMe.WebFormApp.Management.EditSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label runat="server" ID="LblTitle" /></h1>

    <asp:FormView runat="server" ID="FormSurvey"
        DefaultMode="Edit"
        SelectMethod="FormSurvey_GetItem"
        UpdateMethod="FormSurvey_UpdateItem"
        OnDataBound="FormSurvey_DataBound"

        Width="100%"
        >
        <EditItemTemplate>

            <asp:HiddenField runat="server" ID="HidId" Value='<%# Bind("Id") %>' />

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
                            AutoPostBack="true"
                            OnSelectedIndexChanged="DdlNumQuestions_SelectedIndexChanged"
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

                    
                    <hr />
                    <div class="form-group">
                        <label>Question 1</label>
                        <asp:TextBox runat="server" CssClass="form-control"
                            ID="TxtQuestion1" Text='<%# Bind("Question1") %>' />
                    </div>
                    <!-- risposte domanda 1 -->

                    <asp:Panel runat="server" ID="PnlQuestion2">
                        <hr />
                        <div class="form-group">
                            <label>Question 2</label>
                            <asp:TextBox runat="server" CssClass="form-control"
                                ID="TxtQuestion2" Text='<%# Bind("Question2") %>' />
                        </div>
                        <!-- risposte domanda 2 -->
                     </asp:Panel>

                    <asp:Panel runat="server" ID="PnlQuestion3">
                        <hr />
                        <div class="form-group">
                            <label>Question 3</label>
                            <asp:TextBox runat="server" CssClass="form-control"
                                ID="TxtQuestion3" Text='<%# Bind("Question3") %>' />
                        </div>
                        <!-- risposte domanda 3 -->
                    </asp:Panel>
                </div>

                <div class="panel-footer">

                    <asp:LinkButton runat="server" CssClass="btn btn-default"
                        OnClientClick="return confirm('Do you want to save?');"
                        CommandName="Update">
                        Save
                    </asp:LinkButton>

                </div>
            </div>

            

        </EditItemTemplate>
    </asp:FormView>


</asp:Content>
