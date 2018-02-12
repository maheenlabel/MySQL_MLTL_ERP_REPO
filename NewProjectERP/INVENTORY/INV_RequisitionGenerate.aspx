<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="INV_RequisitionGenerate.aspx.cs" Inherits="NewProjectERP.INVENTORY.INV_RequisitionGenerate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
     <script type="text/javascript">
        $(document).ready(function ()
        {
            $('#MainContent_gvPD_DashBoard_chkAll').click(function () {
                if ($(this).prop('checked'))
                    $(this).closest('table').find('input[id^="MainContent_gvPD_DashBoard_ctl00"]').prop('checked', true);
                else
                    $(this).closest('table').find('input[id^="MainContent_gvPD_DashBoard_ctl00"]').prop('checked', false);
            });
        });
     </script>

    
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
                        DataKeyNames="PurchaseRequitionID"
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
                            <asp:TemplateField HeaderText="PurchaseRequitionID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchaseRequitionID" runat="server" Text='<%# Bind("PurchaseRequitionID") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                     

                            <asp:TemplateField HeaderText="PurchaseRequitionNo" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchaseRequitionNo" runat="server" Text='<%# Bind("PurchaseRequitionNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PurchaseRequitionDate" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchaseRequitionDate" runat="server" Text='<%# Bind("PurchaseRequitionDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SupplierID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplierID" runat="server" Text='<%# Bind("SupplierID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                     <asp:TemplateField HeaderText="SupplierName" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="SampleID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSampleID" runat="server" Text='<%# Bind("SampleID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                                 <asp:TemplateField  HeaderStyle-BackColor="#d9edf7" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lblMaterials" Width="20px" OnClick="lblMaterials_Click">Details</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField  HeaderStyle-BackColor="#d9edf7" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lblPreview" Width="20px" OnClick="lblPreview_Click">Preview</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField  HeaderStyle-BackColor="#d9edf7" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lblDelete" Width="20px" OnClick="lblDelete_Click">Delete</asp:LinkButton>
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
                            <asp:Button ID="btnGenerateRequisition"  CssClass="btn btn-success" runat="server" Text=" Requisition"  OnClick="btnGenerateRequisition_Click1"/> 
                                 <asp:Button ID="btnSearchRequisition" CssClass="btn btn-primary"  runat="server" Text="Search Requisition" OnClick="btnSearchRequisition_Click1"/>                                 
                                
                            </center>
                    </div>
                 <hr />

                <div class="table-responsive">
                    <asp:GridView ID="gvPurchaseRequitionID_DashBoard" GridLines="None" CellPadding="4"
                        HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader "
                        FooterStyle-CssClass="GrayBackWhiteFont"
                        ItemStyle-CssClass="Normal"
                        ItemStyle-BackColor="#ecd1c4"
                        AlternatingItemStyle-BackColor="white"
                        runat="server"
                        DataKeyNames="PurchaseRequitionID"
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
                            <asp:TemplateField HeaderText="PurchaseRequitionID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchaseRequitionID1" runat="server" Text='<%# Bind("PurchaseRequitionID") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                     

                            <asp:TemplateField HeaderText="PurchaseRequitionNo" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchaseRequitionNo1" runat="server" Text='<%# Bind("PurchaseRequitionNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PurchaseRequitionDate" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchaseRequitionDate1" runat="server" Text='<%# Bind("PurchaseRequitionDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SupplierID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplierID1" runat="server" Text='<%# Bind("SupplierID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                     <asp:TemplateField HeaderText="SampleID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSampleID" runat="server" Text='<%# Bind("SampleID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="PurchaseRequisitionDetailsID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchaseRequisitionDetailsID1" runat="server" Text='<%# Bind("PurchaseRequisitionDetailsID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="ProductID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductID1" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="ItemCode" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemCode1" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="RequisitionQTY" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequisitionQTY1" runat="server" Text='<%# Bind("RequisitionQTY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Rate" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Amount" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderStyle-BackColor="#d9edf7" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lblDeletedetails" Width="20px" OnClick="lblDeletedetails_Click">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                             


                        </Columns>
                        <FooterStyle CssClass="GrayBackWhiteFont"></FooterStyle>

                        <HeaderStyle CssClass="GrayBackWhiteFontFixedHeader"></HeaderStyle>
                    </asp:GridView>
                </div>
                        
                </section>
            </div>
        </div>
</asp:Content>

