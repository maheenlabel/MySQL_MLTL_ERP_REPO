<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="npd_Woven_techonical.aspx.cs" Inherits="NewProjectERP.NPD.npd_Woven_techonical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <center>Woven Techonical Entry Form</center>
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">
                                <div>
                                     <asp:Label ID="Label1" CssClass="bg-info" runat="server"></asp:Label>
                                    <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label for="SampleID:" class="col-sm-4 control-label">Sample Name:</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlSampleID" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="Color:" class="col-sm-4 control-label">Warp Color:</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="txtColor" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label for="WeavingType:" class="col-sm-4 control-label">Weaving Type:</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlWeavingType" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="OverallWidth:" class="col-sm-4 control-label">File Name:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtFileName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="Pick:" class="col-sm-4 control-label">Pick:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPick" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="Cutter:" class="col-sm-4 control-label">Cutter:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtCutter" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label for="LengthCuttoCut:" class="col-sm-4 control-label">Length Cut to Cut:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLengthCuttoCut" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="DamaskLengh:" class="col-sm-4 control-label">Damask Lengh:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtDamaskLengh" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="Finishedlength:" class="col-sm-4 control-label">Finished length:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtFinishedlength" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="Width:" class="col-sm-4 control-label">Width:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtWidth" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="Huk:" class="col-sm-4 control-label">Huk:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtHuk" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="StracingInfo:" class="col-sm-4 control-label">Stracing Info :</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlStracingInfo" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />

                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label for="IronicInfo:" class="col-sm-4 control-label">Ironing Info :</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlIronicInfo" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />

                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label for="UltrasonicCutting:" class="col-sm-4 control-label">Ultrasonic Cutting :</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlUltrasonicCutting" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />

                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label for="Wash_Starch_Ironing_Time:" class="col-sm-4 control-label">Wash_Starch_Ironing_Time:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtWash_Starch_Ironing_Time" runat="server" Text="0" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="FinishingInfo:" class="col-sm-4 control-label">Pick Wheel:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPickWheel" Text="0" runat="server" CssClass="form-control" onkeypress="return isDigit(event,this.value);"></asp:TextBox>
                                    </div>

                                </div>


                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 1:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry1" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 2:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry2" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 3:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 4:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry4" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 5:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry5" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 6:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry6" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 7:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry7" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 8:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry8" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 9:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry9" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 10:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtKeyEntry10" runat="server" CssClass="form-control"></asp:TextBox>
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

