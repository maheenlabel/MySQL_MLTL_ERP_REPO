<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Npd_Woven_Materials.aspx.cs" Inherits="NewProjectERP.NPD.Npd_Woven_Materials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <center>Woven Materials Entry Form</center>
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">
                                <div>
                                    <asp:Label ID="Label1" Visible="false" CssClass="bg-info" runat="server"></asp:Label>
                                    <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label>
                                </div>
                                      <div class="form-group">
                                        <label for="SampleID:" class="col-sm-4 control-label">Sample Name:</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlSampleID" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                   <div class="form-group">
                                        <label for="StoreItemID:" class="col-sm-4 control-label">Store Item ID:</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlStoreItemID" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                        <div class="form-group">
                                        <label for="MahenCode:" class="col-sm-4 control-label">Mahen Code:</label>
                                        <div class="col-sm-3">
                                          <asp:TextBox ID="txtMahenCode"  runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="Quanity:" class="col-sm-4 control-label">Quanity:</label>
                                        <div class="col-sm-3">
                                          <asp:TextBox ID="txtQuanity"  runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <label for="NPDExecutive:" class="col-sm-4 control-label">Unit:</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>

                                    </div>
                                

                                      <div class="form-group">
                                        <label for="ColorName:" class="col-sm-4 control-label">Color Name:</label>
                                        <div class="col-sm-3">
                                          <asp:TextBox ID="txtColorName"  runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                
                                      <div class="form-group">
                                        <label for="Denier:" class="col-sm-4 control-label">Denier:</label>
                                        <div class="col-sm-3">
                                          <asp:TextBox ID="txtDenier"  runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                 <div class="form-group">
                                        <label for="Pick_Yarnwise:" class="col-sm-4 control-label">Yarn wise Pick:</label>
                                        <div class="col-sm-3">
                                          <asp:TextBox ID="txtPick_Yarnwise"  runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                      <div class="form-group">
                                        <label for="Supplier:" class="col-sm-4 control-label">Supplier:</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlSupplerID" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>

                                    </div>
                                <div class="form-group">
                                        <label for="Batch_ID:" class="col-sm-4 control-label">Batch:</label>
                                        <div class="col-sm-3">
                                          <asp:TextBox ID="txtBatch"  runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <center>

                               
                              
                                    <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" /> 
                              <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Edit" OnClick="btnEdit_Click"/>
                                     <asp:Button ID="btnDelete" runat="server" CausesValidation="false" Visible="False" CssClass="btn btn-warning" Text="Delete" OnClick="btnDelete_Click" />
                                   <asp:Button ID="btnExit" runat="server" CausesValidation="false" CssClass="btn btn-warning" Text="New" OnClick="btnExit_Click" />
                                     
                                
                            </center>
                    </div>
                </div>
                             <hr />

                            <div class="table-responsive">
                                <asp:GridView ID="gvDepartment" runat="server" CellPadding="4" HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader"
                                    FooterStyle-CssClass="GrayBackWhiteFont"
                                    ItemStyle-CssClass="Normal"
                                    ItemStyle-BackColor="#ecd1c4"
                                    AlternatingItemStyle-BackColor="white" BorderWidth="1px" BackColor="White" BorderColor="#3366CC"
                                    BorderStyle="None" ShowFooter="True" CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" AllowPaging="True" OnSelectedIndexChanged="gvDepartment_SelectedIndexChanged" OnRowDataBound="gvDepartment_RowDataBound">

                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                                    </Columns>

                                </asp:GridView>
                            </div>
            </section>
        </div>
    </div>
</asp:Content>