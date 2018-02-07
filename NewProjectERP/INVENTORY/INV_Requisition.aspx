<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="INV_Requisition.aspx.cs" Inherits="NewProjectERP.INVENTORY.INV_Requisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <center><asp:label runat="server" Text="<%$Resources:Resource, OffsetSpecEntryForm %>"></asp:label></center>
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">
                                <asp:Label runat="server" id="lblMsg" class="col-sm-2 control-label"></asp:Label>
                            <hr />

                <div class="table-responsive">
                    <asp:GridView ID="gvPD_DashBoard" GridLines="None" CellPadding="4"
                        HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader "
                        FooterStyle-CssClass="GrayBackWhiteFont"
                        ItemStyle-CssClass="Normal"
                        ItemStyle-BackColor="#ecd1c4"
                        AlternatingItemStyle-BackColor="white"
                        runat="server"
                        DataKeyNames="SampleID"
                        CssClass=" table  table-bordered table-striped table-hover margin-bottome-0"
                        AutoGenerateColumns="False"
                        BorderWidth="1px" BackColor="White" BorderColor="#3366CC"
                        BorderStyle="None" ShowFooter="True" OnRowDataBound="gvPD_DashBoard_RowDataBound">


                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="false" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>                         
                            <asp:TemplateField HeaderText="SampleID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSampleID" runat="server" Text='<%# Bind("SampleID") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                     

                            <asp:TemplateField HeaderText="SampleName" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSampleName" runat="server" Text='<%# Bind("SampleName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ItemID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ItemCode" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Qty" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Rate" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblSampleQty" AutoPostBack="true" CssClass="form-control" runat="server" Text='<%# Bind("Rate") %>' OnTextChanged="lblSampleQty_TextChanged"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             


                                 <asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="#d9edf7">
                                            <ItemTemplate>
                                               <asp:DropDownList ID="ddlSupplier" runat="server" Width="150px" CssClass="form-control"  DataTextField="SupplierName" DataValueField="SupplierID"></asp:DropDownList> <%-- DataSource="<%#BindSupplier()%>"--%>
                                           
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>


                        </Columns>
                        <FooterStyle CssClass="GrayBackWhiteFont"></FooterStyle>

                        <HeaderStyle CssClass="GrayBackWhiteFontFixedHeader"></HeaderStyle>
                    </asp:GridView>
                </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <center>
                            <asp:Button ID="btnGenerateRequisition"  CssClass="btn btn-success" runat="server" Text="Generate Requisition"  OnClick="btnGenerateRequisition_Click"/> 
                                 <asp:Button ID="btnSearchRequisition" CssClass="btn btn-primary"  runat="server" Text="Search Requisition" OnClick="btnSearchRequisition_Click"/>                                 
                                
                            </center>
                    </div>
                </section>
            </div>
        </div>
</asp:Content>

