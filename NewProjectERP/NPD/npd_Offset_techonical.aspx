<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="npd_Offset_techonical.aspx.cs" Inherits="NewProjectERP.NPD.npd_Offset_techonical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <center>Offset Techonical Entry Form</center>
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">
                                <div>
                                    <asp:Label ID="Label1" CssClass="bg-info" Visible="false" runat="server"></asp:Label>
                                    <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" for="SampleName:" class="col-sm-4 control-label" Text="<%$Resources:Resource, Language %>">Language</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlLanguages" runat="server" AutoPostBack="true">
                                            <asp:ListItem Text="English" Value="en-us" />
                                            <asp:ListItem Text="French" Value="fr" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="SampleID:" class="col-sm-4 control-label">Sample Name:</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlSampleID" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="OverallLength:" class="col-sm-4 control-label">Overall Length:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtOverallLength" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="OverallWidth:" class="col-sm-4 control-label">Overall Width:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtOverallWidth" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="FinishedLength:" class="col-sm-4 control-label">Finished Length:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtFinishedLength" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="FinishedWidth:" class="col-sm-4 control-label">Finished Width:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtFinishedWidth" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label for="ForntSideColor:" class="col-sm-4 control-label">Fornt Side Process Color:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtForntSideColor" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="BackSideColor:" class="col-sm-4 control-label">Back Side Process Color:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtBackSideColor" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="RibbonType:" class="col-sm-4 control-label">Cutting Emboss :</label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlCuttingEmboss" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="RibbonColor:" class="col-sm-4 control-label">Cutting Debossing:</label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlCuttingDebossing" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="RibbonWidth:" class="col-sm-4 control-label">Die Cutting:</label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlDieCutting" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="EdgeQuality:" class="col-sm-4 control-label">Punch hole size:</label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlPunch" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="FaceQuality:" class="col-sm-4 control-label">Perforation:</label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlPerforation" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 1:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry1" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 2:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry2" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 3:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 4:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry4" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 5:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry5" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 6:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry6" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 7:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry7" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 8:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry8" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 9:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtKeyEntry9" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="KeyEntry1:" class="col-sm-4 control-label">Key Entry 10:</label>
                                    <div class="col-sm-6">
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
                                     <asp:Button ID="btnDelete" runat="server" CausesValidation="false" Visible="False" CssClass="btn btn-warning" Text="Delete" OnClick="btnDelete_Click"/>
                                   <asp:Button ID="btnExit" runat="server" CausesValidation="false" CssClass="btn btn-warning" Text="New" OnClick="btnExit_Click"/>
                                
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
                        BorderStyle="None" ShowFooter="True" CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" AllowPaging="True" OnSelectedIndexChanged="gvDepartment_SelectedIndexChanged">

                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                        </Columns>

                    </asp:GridView>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

