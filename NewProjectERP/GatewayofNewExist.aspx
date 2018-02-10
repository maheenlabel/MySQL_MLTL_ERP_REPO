<%@ Page  Title="" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GatewayofNewExist.aspx.cs" Inherits="NewProjectERP.GatewayofNewExist" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="Content/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="Content/glyphicons/css/glyphicons.css" rel="stylesheet" />
    <link href="Content/glyphicons_halflings/css/halflings.css" rel="stylesheet" />
    <link href="Content/css/style.css" rel="stylesheet" />
    <link href="Content/css/style_responsive.css" rel="stylesheet" />
    <link href="Content/css/style_default.css" rel="stylesheet" />

<%--    <link href="Content/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="Content/jquery-ui-1.12.1/jquery-3.3.1.min.js"></script>
    <script src="Content/jquery-ui-1.12.1/jquery-ui.min.js"></script>--%>

    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script> 

    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $(".autosuggest").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "GatewayofNewExist.aspx/GetAutoCompleteData",
                        data: "{'username':'" + document.getElementById('txtSearch').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            if (data != null) {
                                response(data.d);
                            }
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }
        </script>
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
                        <a href="categoryList.aspx?ModuleID=1">
                            <div class="dashboard-stat Cs1">
                                <div class="visual">
                                    <i class="fa fa-gg hvr-pulse-grow"></i>
                                </div>
                                <div class="details">
                                   
                                    <div class="number">
                                    </div>
                                    <div class="desc">
                                       NEW PD
                                    </div>
                                </div>
                                <a class="more CsM" href="categoryList.aspx?ModuleID=1">Go <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </a>
                    </div>
             <div class="span6 responsive" data-tablet="span6" data-desktop="span6">
                       <%-- <a href="categoryList.aspx?ModuleID=1">--%>
                            <div class="dashboard-stat Cs1">
                                <div class="visual">
                                    <i class="fa fa-gg hvr-pulse-grow"></i>
                                </div>
                                <div class="details">
                                   
                                    <div class="number">
                                    </div>
                                    <div class="desc">
                                        SEARCH
                                        <div> <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList> </div>
                                        <asp:TextBox ID="txtSerachItem" Text="Type here and Click GO" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                    </div>
                                </div>
                              <asp:linkbutton ID="linkTsepc" OnClick="linkTsepc_Click" Text="GO"  Runat="server" />
                               
                                <%--</a>--%>
                            </div>
                      
                    </div>

                            </div>
                        <%--</a>--%>
                    </div>
                              
             <div class="demo">
           <div class="ui-widget">
       
                             <%--   <div class="glyphicon">
    <i class="glyphicon glyphicon-search form-control-feedback"></i>--%>
   
</div>
    </div>

            <%-- <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                           <div class="desc">
                                       PD Sample Search
                                    </div>
                                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:MaheenERPConnection %>"
        SelectCommand="SELECT [SampleID], SampleName,[SampleNo] FROM NPD_SampleGeneralSpec_Tbl"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MaheenERPConnection %>"
        SelectCommand="SELECT ProductCategoryID,ProductCategoryName FROM NPD_ProductCategory_Tbl"></asp:SqlDataSource>

    <div class="demo-container size-narrow">
        <telerik:RadSearchBox RenderMode="Lightweight" ID="RadSearchBox2" runat="server" Width="500" DropDownSettings-Height="200px"
            DataSourceID="SqlDataSource1"
            DataTextField="SampleName" DataValueField="SampleID" DataContextKeyField="SampleID">
         
               <SearchContext DataSourceID="SqlDataSource2" DataTextField="ProductCategoryName" DataKeyField="ProductCategoryID"> </SearchContext>
        </telerik:RadSearchBox>
    </div>
             
</div>--%>
                 

          
                    
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