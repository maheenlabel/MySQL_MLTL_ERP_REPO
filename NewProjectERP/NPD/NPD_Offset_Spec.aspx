<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NPD_Offset_Spec.aspx.cs" Inherits="MLTL_ERP.NPD_Offset_Spec" %>

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
                                <div>

                                    <asp:Label ID="Label1" CssClass="bg-info" runat="server"></asp:Label>
                                    <asp:Label ID="Label2" CssClass="bg-info" runat="server"></asp:Label>
                                    <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label>
                                </div>
                                <br />
                                <center> <asp:Button ID="btnBack" CssClass="btn btn-danger" runat="server"
                                            Text="<%$Resources:Resource, BackToMenu %>" OnClick="btnBack_Click" CausesValidation="false" 
                                             /></center>
                                <br />
                                <div class="form-group">
                                    <asp:Label runat="server" for="SampleName:" class="col-sm-4 control-label" Text="<%$Resources:Resource, Language %>" >Language</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlLanguages" runat="server" AutoPostBack="true">
                                            <asp:ListItem Text="English" Value="en-us" />
                                            <asp:ListItem Text="French" Value="fr" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" for="SampleName:" class="col-sm-4 control-label"  Text="<%$Resources:Resource, SampleName %>" >Sample Name</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtSampleName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="Brand:" class="col-sm-4 control-label" Text="<%$Resources:Resource, Brand %>" >Brand</asp:Label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddBrand" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddBrand_SelectedIndexChanged"></asp:DropDownList>
                                    </div>

                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="Program:" class="col-sm-4 control-label" Text="<%$Resources:Resource, SubBrand %>" >Sub Brand</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" for="SubCategory:" class="col-sm-4 control-label" Text="<%$Resources:Resource, SubCategory %>" >Sub Category</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddSubCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" for="Client:" class="col-sm-4 control-label" Text="<%$Resources:Resource, Client %>" >Client</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddClient" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" for="Company:" class="col-sm-4 control-label" Text="<%$Resources:Resource, Company %>" >Company</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control"></asp:DropDownList>


                                    </div>

                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" for="PDExecutive:" class="col-sm-4 control-label" Text="<%$Resources:Resource, PDExecutive %>" >PD Executive</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddPDExecutive" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="NPDExecutive:" class="col-sm-4 control-label" Text="<%$Resources:Resource, Unit %>" >Unit</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>

                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="Length:" class="col-sm-4 control-label" Text="<%$Resources:Resource, LengthMM %>" >Length (MM)</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtLenghtmm" runat="server" placeholder="Only Number" onkeypress="return isDigit(event,this.value);" CssClass="form-control"></asp:TextBox>

                                    </div>

                                </div>


                                <div class="form-group">
                                    <asp:Label runat="server" for="Width:" class="col-sm-4 control-label" Text="<%$Resources:Resource, WidthMM %>" >Width (MM)</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtwidthmm" runat="server" placeholder="Only Number" onkeypress="return isDigit(event,this.value);" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">

                                        <label style="color: red;">*</label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="QuotedPrice:" class="col-sm-4 control-label" Text="<%$Resources:Resource, PaperGSM %>" >Paper GSM</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtPaperGSM" runat="server" CssClass="form-control" float="right"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="QuotedPrice:" class="col-sm-4 control-label" Text="<%$Resources:Resource, NoofUPS %>" >No of UPS</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtNoofUPS" runat="server" CssClass="form-control" float="right"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="QuotedPrice:" class="col-sm-4 control-label" Text="<%$Resources:Resource, QuotedPrice %>" >Quoted Price</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtQuotedPrice" runat="server" CssClass="form-control" float="right"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="ArtworkLocation:" class="col-sm-4 control-label" Text="<%$Resources:Resource, ArtWorkLocation %>" >Art Work Location</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtArtworkLocation" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:Button ID="btnBrowse" runat="server" Text="Browse" OnClick="btnBrowse_Click" />--%>
                                        <asp:FileUpload ID="FileUpload1" type="file" name="file" onchange="SampalFile2()" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" for="Imagepath:" class="col-sm-4 control-label" Text="<%$Resources:Resource, ImagePath %>" >Image Path</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtImagepath" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" for="Cancel:" class="col-sm-4 control-label" Text="<%$Resources:Resource, Cancel %>" >Cancel</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlCancel" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="No" Value="0" />
                                            <asp:ListItem Text="Yes" Value="1" />

                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">

                                        <label style="color: red;">*</label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" for="PcsYard:" class="col-sm-4 control-label" Text="<%$Resources:Resource, TotalNoOfColor %>" >Total No Of Color</asp:Label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtTotalColor" runat="server" placeholder="Only Number" onkeypress="return isDigit(event,this.value);" CssClass="form-control" Text="1"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">

                                        <label style="color: red;">*</label>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <center>

                               
                              
                                    <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server" Text="<%$Resources:Resource, Save %>" OnClick="btnSave_Click"/> 
                                 <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Edit" OnClick="btnEdit_Click"/>
                                     <asp:Button ID="btnDelete" runat="server" CausesValidation="false" Visible="False" CssClass="btn btn-warning" Text="Delete" OnClick="btnDelete_Click" />
                                   <asp:Button ID="btnExit" runat="server" CausesValidation="false" CssClass="btn btn-warning" Text="<%$Resources:Resource, New %>" OnClick="btnExit_Click" />
                                     
                                 <asp:linkbutton ID="linkTechnical" OnClick="linkTechnical_Click"  Text="Technical"  Runat="server" />
                                <asp:linkbutton ID="LinkbuttonMaterials" OnClick="LinkbuttonMaterials_Click" Text="Materials"  Runat="server" />
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
