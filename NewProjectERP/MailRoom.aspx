<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailRoom.aspx.cs" Inherits="NewProjectERP.MailRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gvEmails" runat="server" OnRowDataBound="OnRowDataBound" DataKeyNames="MessageNumber"
    AutoGenerateColumns="false">
   <Columns>
        <asp:BoundField HeaderText="From" DataField="From" HtmlEncode="false" />
        <asp:TemplateField HeaderText="Subject">
            <ItemTemplate>
                <asp:LinkButton ID="lnkView" runat="server" Text='<%# Eval("Subject") %>' />
                <span class="body" style="display: none">
                    <%# Eval("Body") %></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Date" DataField="DateSent" />
        <asp:TemplateField ItemStyle-CssClass="Attachments">
            <ItemTemplate>
                <asp:Repeater ID="rptAttachments" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkAttachment" runat="server" OnClick="Download" Text='<%# Eval("FileName") %>' />
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br>
                    </SeparatorTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div id="dialog" style="display: none">
    <span id="body"></span>
    <br />
    <span id="attachments"></span>
</div>
    </div>
    </form>
</body>
</html>
