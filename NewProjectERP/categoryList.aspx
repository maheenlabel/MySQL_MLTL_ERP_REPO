﻿<%@ Page  Title="" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="categoryList.aspx.cs" Inherits="NewProjectERP.categoryList" %>
<%--<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="Content/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="Content/glyphicons/css/glyphicons.css" rel="stylesheet" />
    <link href="Content/glyphicons_halflings/css/halflings.css" rel="stylesheet" />
    <link href="Content/css/style.css" rel="stylesheet" />
    <link href="Content/css/style_responsive.css" rel="stylesheet" />
    <link href="Content/css/style_default.css" rel="stylesheet" />

 <style>
        body {
            background-color: #dddddd !important;
        }
        /*.dashboard-stat .visual i {
    font-size: 44px !important;
    color: #fff !important;
}*/


        .Cs1 {
            background-color: #003399;
        }

        .CsM {
            background-color: #002b80 !important;
        }

        .Cs2 {
            background-color: #006666;
        }

        .CsN {
            background-color: #004d4d !important;
        }

        .Cs3 {
            background-color: #ff8000;
        }

        .CsO {
            background-color: #cc6600 !important;
        }

        .Cs4 {
            background-color: #cc0066;
        }

        .CsP {
            background-color: #99004d !important;
        }

        .Cs5 {
            background-color: #00804d;
        }

        .CsQ {
            background-color: #004d2e !important;
        }

        .Cs6 {
            background-color: #006699;
        }

        .CsR {
            background-color: #004466 !important;
        }

        .Cs7 {
            background-color: #990073;
        }

        .CsT {
            background-color: #66004d !important;
        }

         .Cs8 {
            background-color: #8a1415;
        }

        .CsU {
            background-color: #5f0c0d !important;
        }

        /*.header .nav .dropdown-toggle:hover, .header .nav .dropdown.open .dropdown-toggle {
            background-color: #eee !important;
        }*/

        /*.header .nav > li.dropdown .dropdown-toggle {
            margin: 0px !important;
            padding: 4px 12px 4px 12px !important;
            border-radius: 32px 32px !important;
        }*/

        .top-nav ul.top-menu > li .dropdown-menu.logout {
            width: 170px !important;
            padding: 2px !important;
        }

        .top-nav .dropdown-menu.extended.logout {
            top: 33px !important;
        }


        @media only screen and (min-device-width:768px) and (max-device-width:1024px) {
            .FontSizeSm {
                font-size: 10px !important;
            }
        }

        .ModuleSize {
            font-size: 70px !important;
            padding-top: 11px !important;
            padding-bottom: 6px !important;
        }

        .NN {
            padding: 7px 0px 5px 0px !important;
            background-color: #fafafa !important;
            background-image: none !important;
            filter: none !important;
            -webkit-box-shadow: none !important;
            -moz-box-shadow: none !important;
            box-shadow: none !important;
            display: block !important;
            color: #32323a !important;
            text-shadow: none !important;
            /*margin: 7px 5px 5px 7px !important;*/
            /*margin:auto !important;*/
            /* font-size: 30px; */
            -webkit-transition: all 0.3s ease !important;
            -moz-transition: all 0.3s ease !important;
            -ms-transition: all 0.3s ease !important;
            -o-transition: all 0.3s ease !important;
            transition: all 0.3s ease !important;
        }

        [class^="icon-"], [class*=" icon-"], [class^="icon-"]:hover, [class*=" icon-"]:hover {
            /*background: none !important;*/
            /*background: rgba(201, 219, 220,0.1) !important;*/
            background: rgba(88, 129, 132,0.1) !important;
        }

        [class^="icon-"], [class*=" icon-"] {
            font-family: FontAwesome;
            /* font-size: 14px; */
            font-weight: normal;
            font-style: normal;
            text-decoration: inherit;
            display: inline;
            width: auto;
            height: auto;
            line-height: normal;
            vertical-align: baseline;
            background-image: none !important;
            background-position: 0% 0%;
            background-repeat: repeat;
        }

        .icon-btn i {
            font-size: 52px !important;
            /*color: #4b8df8 !important;*/
            /*color: #a0a7a9 !important;*/
            color: #e5e5e5 !important;
        }

        .icon-btn {
            /*border: 0px !important;*/
            /*border: 1px solid #a0a7a9 !important;*/
            border: none !important;
        }


            .icon-btn i:hover {
                /*font-size: 60px !important;*/
                /*color: #db1a21 !important;*/
                color: #00b9ce !important;
            }

            .icon-btn div {
                font-family: 'Open Sans' !important;
                margin-top: 5px !important;
                margin-bottom: 20px !important;
                /*color: #4b8df8 !important;*/
                /*color: #a0a7a9 !important;*/
                color: #e5e5e5 !important;
                font-size: 13px !important;
                font-weight: 500 !important;
            }

                .icon-btn div:hover {
                    /*font-size: 15px !important;*/
                    /*color: #db1a21 !important;*/
                    color: #ffffff !important;
                }
    </style>

     <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <center>Main Form</center>
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">

         <div class="row-fluid" >
                    <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                        <a href="Default.aspx?ModuleID=1">
                            <div class="dashboard-stat Cs1">
                                <div class="visual">
                                    <i class="fa fa-gg hvr-pulse-grow"></i>
                                </div>
                                <div class="details">
                                    <div class="number">
                                    </div>
                                    <div class="badge">
                                       New Product Development
                                    </div>
                                </div>


                               <%-- <a class="more CsM" href="PFLSpectedDataSheet.aspx?ModuleID=1">PFL <i class="m-icon-swapright m-icon-white"></i>
                                <a class="more CsM" href="Default.aspx?ModuleID=1">Screen Print  <i class="m-icon-swapright m-icon-white"></i>
                                <a class="more CsM" href="WovenSpectedDataSheet.aspx?ModuleID=1">Woven <i class="m-icon-swapright m-icon-white"></i>
                                <a class="more CsM" href="Default.aspx?ModuleID=1">Offse <i class="m-icon-swapright m-icon-white"></i>
                                <a class="more CsM" href="Default.aspx?ModuleID=1">Heat Transfer<i class="m-icon-swapright m-icon-white"></i>
                                <a class="more CsM" href="Default.aspx?ModuleID=1">Thermal <i class="m-icon-swapright m-icon-white"></i>
                                <a class="more CsM" href="Default.aspx?ModuleID=1">Button Label  <i class="m-icon-swapright m-icon-white"></i>
                                <a class="more CsM" href="Default.aspx?ModuleID=1">Rebbon  <i class="m-icon-swapright m-icon-white"></i>
                                </a>--%>

                                    						<asp:DataGrid id="DataGrid1" Runat="server"  AutoGenerateColumns="False"  EditItemStyle-BackColor="#F7F7F7"
							HeaderStyle-BackColor="#F7F7F7" CellPadding="3" HorizontalAlign="Center">
							<FooterStyle BackColor="PaleGoldenrod"></FooterStyle>
							<SelectedItemStyle BackColor="Control"></SelectedItemStyle>
							<EditItemStyle BackColor="#F7F7F7"></EditItemStyle>
							<ItemStyle BackColor="White"></ItemStyle>
							<HeaderStyle BackColor="DarkKhaki"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="">
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemTemplate>
										<asp:Literal ID="Label" Text='<%# DataBinder.Eval(Container.DataItem, "ProductCategoryID") %>' Runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="">
									<HeaderStyle Width="100px"></HeaderStyle>
									<ItemTemplate>
										<asp:linkbutton ID="linkCategory" OnClick="linkCategory_Click"  Text='<%# DataBinder.Eval(Container.DataItem, "ProductCategoryName") %>'  Runat="server" />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:Textbox ID="TextBox1" Text='<%# DataBinder.Eval(Container.DataItem, "ProductCategoryName") %>'  Runat="server" />
									</EditItemTemplate>
								</asp:TemplateColumn>
							
							
							</Columns>
						</asp:DataGrid>
                            </div>
                        </a>
                    </div>
                    
                 

          
                    
                </div>
 <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MaheenERPConnection %>"
        SelectCommand="SELECT PFL_SPEC_ID, SPEC_NAME FROM pfl_spec"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MaheenERPConnection %>"
        SelectCommand="SELECT Product_Category_ID,Category_Name FROM npd_product_category"></asp:SqlDataSource>

    <div class="demo-container size-narrow">
        <telerik:RadSearchBox RenderMode="Lightweight" ID="RadSearchBox2" runat="server" Width="500" DropDownSettings-Height="200px"
            DataSourceID="SqlDataSource1"
            DataTextField="SPEC_NAME" DataValueField="PFL_SPEC_ID" DataContextKeyField="PFL_SPEC_ID">
         
               <SearchContext DataSourceID="SqlDataSource2" DataTextField="Category_Name" DataKeyField="Product_Category_ID"> </SearchContext>
        </telerik:RadSearchBox>
    </div>--%>
<%--                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:MaheenERPConnection2 %>"
        SelectCommand="SELECT * FROM public.NPD_ProductCategory_Tbl where Status=0 ORDER BY ProductCategoryID ASC" ></asp:SqlDataSource>
                                 <div class="table-responsive">
                      <asp:GridView ID="gvItemMaster" runat="server" CellPadding="4"  HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader" 
	          FooterStyle-CssClass="GrayBackWhiteFont" 
	          ItemStyle-CssClass="Normal" 
	          ItemStyle-BackColor="#ecd1c4" 
	          AlternatingItemStyle-BackColor="white" borderwidth="1px"  BackColor="White" BorderColor="#3366CC" 
            BorderStyle="None" ShowFooter="True"  CssClass=" table  table-bordered table-striped table-hover margin-bottome-0"  AllowPaging="True"   DataSourceID="SqlDataSource1"
	    >
                         
                          <Columns>
                            
                         </Columns>

                      </asp:GridView>--%>
                     </div>
                               
                                </div>
                                </div>
                            </div>
                        </div>
                </section>
                </div>
             </div>


    -----------------------------------------------------
   <%-- <div>

        <div class="col-md-10 col-md-offset-1">

            <div>
                <div class="row-fluid">
                    <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                        <a href="Default.aspx?ModuleID=1">
                            <div class="dashboard-stat Cs1">
                                <div class="visual">
                                    <i class="fa fa-gg hvr-pulse-grow"></i>
                                </div>
                                <div class="details">
                                    <div class="number">
                                    </div>
                                    <div class="desc">
                                        Common
                                    </div>
                                </div>
                                <a class="more CsM" href="Default.aspx?ModuleID=1">Go <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </a>
                    </div>
                    <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                        <a href="Default.aspx?ModuleID=2">
                            <div class="dashboard-stat Cs2">
                                <div class="visual">
                                   
                                </div>
                                <div class="details">
                                    <div class="number"></div>
                                    <div class="desc">Inventory</div>
                                </div>
                                <a class="more CsN" href="Default.aspx?ModuleID=2">GO <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </a>
                    </div>
                    <div class="span3 responsive" data-tablet="span6  fix-offset" data-desktop="span3">
                        <a href="Default.aspx?ModuleID=3">
                            <div class="dashboard-stat purple">
                                <div class="visual">
                                    <i class="fa fa-users hvr-pulse-grow"></i>
                                </div>
                                <div class="details">
                                    <div class="number"></div>
                                    <div class="desc">NPD</div>
                                </div>
                                <a class="more" href="Default.aspx?ModuleID=3">GO <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </a>
                    </div>
                    <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                        <a href="Default.aspx?ModuleID=4">
                            <div class="dashboard-stat Cs3">
                                <div class="visual">
                                    <i class="fa fa-bullseye hvr-pulse-grow"></i>
                                </div>
                                <div class="details">
                                    <div class="number"></div>
                                    <div class="desc">Costing</div>
                                </div>
                                <a class="more CsO" href="Default.aspx?ModuleID=4">GO <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </a>
                    </div>

                </div>
                  </div>

                </div>
        </div>--%>

    </asp:Content>