<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Cascading_Dropdown_Ddl.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <table>
                    <tr>
                        <td>Country:</td>
                        <td><asp:DropDownList runat="server" ID="ddlCountry" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>State:</td>
                        <td><asp:DropDownList runat="server" ID="ddlState"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" /></td>
                    </tr>
                </table>
            </center>
        </div>
    
        <asp:GridView runat="server" ID="gv" OnRowCommand="gv_RowCommand" AutoGenerateColumns="false" Width="100%" style="text-align:center" >
        <Columns>
            <asp:TemplateField HeaderText="Id">
                <ItemTemplate>
                    <%#Eval("id") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Selected Country">
                <ItemTemplate>
                    <%#Eval("c_country") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Selected State">
                <ItemTemplate>
                    <%#Eval("s_name") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" id="btnEdit" CommandName="btnedit" CommandArgument='<%#Eval("id") %>' Text="Edit" Width="100%"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" id="btnDelete" CommandName="btndelete" CommandArgument='<%#Eval("id") %>' Text="Delete" Width="100%"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </form>
</body>
</html>
