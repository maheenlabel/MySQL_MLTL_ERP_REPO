<%@ Page  Title="" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WovenSpectedDataSheet.aspx.cs" Inherits="NewProjectERP.WovenSpectedDataSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%--   <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/css/metro.css" rel="stylesheet" />
    <link href="Content/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="Content/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="Content/glyphicons/css/glyphicons.css" rel="stylesheet" />
    <link href="Content/glyphicons_halflings/css/halflings.css" rel="stylesheet" />
    <link href="Content/css/style.css" rel="stylesheet" />
    <link href="Content/css/style_responsive.css" rel="stylesheet" />
    <link href="Content/css/style_default.css" rel="stylesheet" />--%>

 

     <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <center><b>Woven Specs.</b></center>
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">

         
                                <div class="form-group">
                                    <label for="BrandName:"  class="col-sm-4 control-label">Sample Name:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtSampleName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                  

                                </div>
                                  <div class="form-group">
                                    <label for="BrandName:" class="col-sm-4 control-label">Brand Name:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>

                                      <div class="form-group">
                                    <label for="BrandName:" class="col-sm-4 control-label">Sub Brand Name:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtsubBrandName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>

                                 <div class="form-group">
                                    <label for="Length:" class="col-sm-4 control-label">Length:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtLength" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="Width:" class="col-sm-4 control-label">Width:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtWidth" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="Color:" class="col-sm-4 control-label">Color:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtColor" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="OverallLength:" class="col-sm-4 control-label">Warp Color:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtOverallLength" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="OverallWidth:" class="col-sm-4 control-label">Weaving Type:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtOverallWidth" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>

                                 <div class="form-group">
                                    <label for="Finished:" class="col-sm-4 control-label">Pick:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtFinishedLength" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="FinishedWidth:" class="col-sm-4 control-label">Cutter:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtFinishedWidth" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="FrontSideColor:" class="col-sm-4 control-label">Damask Length :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtFrontSideColor" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="BackSideColor:" class="col-sm-4 control-label">Finish Length :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtBackSideColor" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="RibbonType:" class="col-sm-4 control-label">Stracing Info:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtRibbonType" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="RibbonWidth:" class="col-sm-4 control-label">Ultrasonic Cutting:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtRibbonWidth" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="RibbonColor:" class="col-sm-4 control-label">Laser Cutting :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtRibbonColor" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="EdgeQuality:" class="col-sm-4 control-label">Cut Fold Info:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtEdgeQuality" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="FaceQuality:" class="col-sm-4 control-label">Wash/Starch/Ironing Time:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtFaceQuality" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="BrandName:" class="col-sm-4 control-label">Ultrasonic Cut Capacity:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtMachineType" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div>
                                 <div class="form-group">
                                    <label for="BrandName:" class="col-sm-4 control-label">Pick Wheel:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtMachineName" runat="server" CssClass="form-control"></asp:TextBox>
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
                                  <asp:Button ID="btnSearch" CssClass="btn btn-success" runat="server" Text="Search" /> 
                                   
                            </center>
                            </div>
                        </div>
                    </div>
                </section>
                </div>
             </div>


  

    </asp:Content>