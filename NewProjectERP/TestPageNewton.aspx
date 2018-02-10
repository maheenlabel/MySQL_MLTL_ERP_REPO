<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPageNewton.aspx.cs" Inherits="NewProjectERP.TestPageNewton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <center></center>
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">
                                      <div class="form-group">
                                    <label for="BrandName:" class="col-sm-4 control-label">Brand Name:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtBrandName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                  

                                </div>
                                 </div>
                                </div>
                            </div>
                        </div>
                <div class="container">
                        <div class="row">
                            <div class="form-group">
                                <center>
                                  <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Save"  OnClick="Button2_Click"/> 
                                     <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                     <asp:Button ID="btnDelete" runat="server" CausesValidation="false" Visible="False" CssClass="btn btn-warning" Text="Delete" OnClick="btnDelete_Click" />
                                   <asp:Button ID="btnExit" runat="server" CausesValidation="false" CssClass="btn btn-warning" Text="New" OnClick="btnExit_Click" />
                                     
                            </center>
                            </div>
                        </div>
                    </div>
                            <hr />

                            <div class="table-responsive">
                                <asp:GridView ID="gvDepartment" runat="server" CellPadding="4" HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader"
                                    FooterStyle-CssClass="GrayBackWhiteFont"
                                    ItemStyle-CssClass="Normal"
                                    ItemStyle-BackColor="#ecd1c4"
                                    AlternatingItemStyle-BackColor="white" BorderWidth="1px" BackColor="White" BorderColor="#3366CC"
                                    BorderStyle="None" ShowFooter="True" CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" AllowPaging="True">

                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                                    </Columns>

                                </asp:GridView>
                            </div>

          <%--      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="WorkOrderID" HeaderText="WorkOrderID" ItemStyle-Width="150" />
        <asp:BoundField DataField="WorkOrderNo" HeaderText="WorkOrderNo" ItemStyle-Width="150" />
          <asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" ItemStyle-Width="150" />
        <asp:BoundField DataField="EstDeliverDate" HeaderText="EstDeliverDate" ItemStyle-Width="150" />
          <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="150" />
        <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" ItemStyle-Width="150" />
          <asp:BoundField DataField="value" HeaderText="value" ItemStyle-Width="150" />
        <asp:BoundField DataField="SampleName" HeaderText="SampleName" ItemStyle-Width="150" />
    </Columns>
</asp:GridView>--%>

                </section>
                </div>
             </div>
    </asp:Content>