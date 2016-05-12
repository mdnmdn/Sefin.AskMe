<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="Sefin.AskMe.WebFormApp.Management.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Survey management</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

        

    <div class="panel panel-default">
        <div class="panel-body">

            <asp:TextBox ID="TxtSearch" runat="server"  
                 placeholder="Search for..." CssClass="form-control" />

        </div>
        <div class="panel-footer">
            <asp:LinkButton runat="server" ID="BtnSearch" 
                OnClick="BtnSearch_Click" CssClass="btn btn-primary" >
                Search
            </asp:LinkButton>
            <asp:LinkButton runat="server" ID="BtnClear" 
                OnClick="BtnClear_Click" CssClass="btn btn-default" >
                Show all
            </asp:LinkButton>

            <a href="Default" class="btn btn-default" >
                Show all 2
            </a>
        </div>
    </div>

    <asp:GridView ID="GridSurvey" 
        SelectMethod="GridSurvey_GetData"
        CssClass="table table-condensed table-striped table-hover table-bordered"
        PagerStyle-CssClass="table-pager"
        AutoGenerateColumns="false"
        AllowPaging="true"
        runat="server">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            
            <asp:TemplateField HeaderText="Survey Name">
                <ItemTemplate>

                    <a href="EditSurvey?id=<%# Eval("Id") %>">
                        <span class="glyphicon glyphicon-ok"></span>
                        <asp:Label runat="server" Text='<%# Eval("Name") %>' />
                    </a>
                    (<%# Eval("NumberOfQuestions") %>)
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CheckBoxField DataField="Active" HeaderText="Active" />

            <asp:TemplateField HeaderText="" >
                <ItemTemplate>

                    <%--<asp:Panel runat="server" Visible='<%# Eval("Active") %>'>
                        <a href="ShowAnswers?id=<%# Eval("Id") %>" >
                            <span class="glyphicon glyphicon-th-list"></span>
                        </a>
                    </asp:Panel>--%>

                    <a href='<%# "ShowAnswers?id=" + Eval("Id") %>' 
                       Visible='<%# Eval("Active") %>' runat="server" >
                        <span class="glyphicon glyphicon-th-list"></span>
                    </a>
                    

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

  </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
