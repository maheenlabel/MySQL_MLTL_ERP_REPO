<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="NewProjectERP.User" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/common-script.js"></script>




    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Save?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type="text/javascript">
        function ConfirmEdit() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_Edit_value";
            if (confirm("Do you want to Edit?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type="text/javascript">
        function ConfirmDelete() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_delete_value";
            if (confirm("Do you want to Delete?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>


    <div class="row">
        <div class="col-md-12 xs-zero-padding">
            <div class="top-banner"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    User Entry          
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">
                                <br />
                                <center> <asp:Button ID="btnBack" CssClass="btn btn-danger" runat="server"
                                            Text="Back To Menu" OnClick="btnBack_Click"
                                             /></center>
                                <br />
                                <div>
                                    <center>  <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label></center>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Style="font-size: x-small; float: right;"><i style="color:red;">* </i><i>Marks fields are Required.</i> </asp:Label>
                                </div>
                                <%--<div class="form-group">
                            <label for="Department Name:" class="col-sm-4 control-label">Department Name:</label>
                            <div class="col-sm-4">
                                  <asp:DropDownList ID="ddlDept" runat="server" CssClass="selectpicker form-control" data-live-search="true" AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                           <div class="col-sm-2">
                                <label style="color:red;">*</label>
                            </div>

                        </div>--%>

                                <%--<div class="form-group">
                            <label for="Department Name:" class="col-sm-4 control-label">Card No:</label>
                            <div class="col-sm-4">
                                  <asp:DropDownList ID="ddCardNo" runat="server" CssClass="selectpicker form-control" data-live-search="true"  AutoPostBack="true" OnSelectedIndexChanged="ddCardNo_SelectedIndexChanged" ></asp:DropDownList>
                            </div> 
                           <div class="col-sm-2">
                                <label style="color:red;">*</label>
                            </div>

                        </div>--%>


                                <%--<div class="form-group">
                            <label for="Department Name:" class="col-sm-4 control-label">Employee Name:</label>
                            <div class="col-sm-4">
                                  <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="selectpicker form-control" data-live-search="true"></asp:DropDownList>
                            </div>
                           <div class="col-sm-2">
                                <label style="color:red;">*</label>
                            </div>

                        </div>--%>
                                <div class="form-group">
                                    <label for="Department Name:" class="col-sm-4 control-label">Select Language:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="selectpicker form-control" data-live-search="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">
                                        <label style="color: red;">*</label>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label for="Designation Name:" class="col-sm-4 control-label">Login ID:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtLoginID" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2">
                                        <label style="color: red;">*</label>
                                    </div>

                                </div>

                                <div class="form-group">
                                    <label for="Designation Name Bangla:" class="col-sm-4 control-label">Password:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Label ID="lblstar" runat="server" Style="color: red;">*</asp:Label>
                                    </div>

                                </div>

                                <%--<div class="form-group">--%>
                                <%--<label for="Report To:" class="col-sm-4 control-label">Role:</label>--%>
                                <%--<div class="col-sm-4">--%>
                                <asp:DropDownList ID="ddlRole" Visible="false" runat="server" CssClass="selectpicker form-control" data-live-search="true"></asp:DropDownList>
                                <%--</div>--%>
                                <%--</div>--%>

                                <%--<div class="form-group">
                                    <label for="Company(s) Access:" class="col-sm-4 control-label">Role :</label>
                                    <div class="col-sm-4">
                                        <div style="height: 300px; overflow: scroll;">
                                            <asp:CheckBoxList ID="cblRole" runat="server" CheckBoxes="true" SelectionMode="Multiple" RepeatDirection="Vertical"></asp:CheckBoxList>
                                        </div>
                                    </div>
                            <div class="col-sm-2">
                                <label style="color:red;">*</label>
                            </div>
                        </div>--%>

                                <div class="form-group">
                                    <label for="Report To:" class="col-sm-4 control-label">Status:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="INACTIVE" Value="0" />
                                            <asp:ListItem Text="ACTIVE" Value="1" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">
                                        <label style="color: red;">*</label>
                                    </div>

                                </div>




                                <hr />

                                <div class="form-group">


                                    <center>
                                     <asp:Button ID="btnSaveAndSameBatch" CssClass="btn btn-success" runat="server"
                                            Text="Save" OnClick="btnSave_Click" OnClientClick="Confirm()"
                                             />
                                     <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server"
                                            Text="Edit" OnClick="btnEdit_Click" OnClientClick="ConfirmEdit()"
                                             />
                                         <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CssClass="btn btn-danger" Visible="False" Text="Delete" OnClick="btnDelete_Click" OnClientClick="ConfirmDelete()"/>
                                    <asp:Button ID="btnExit" runat="server" CausesValidation="false" CssClass="btn btn-warning" Text="New" OnClick="btnExit_Click" />
                                         <asp:Button ID="btnResetPassword" runat="server" CausesValidation="false" CssClass="btn btn-danger" Text="Reset Password" OnClick="btnResetPassword_OnClick"/>
                                     </center>


                                </div>



                            </div>
                        </div>

                    </div>

                    <hr>
                    <%--<div class="row">--%>
                    <center>
             <%--<div class="form-group"> 
                
            <table>
                <tr>
                    <td>Search Type :</td>
                    <td>
                        <asp:DropDownList ID="ddlSearch" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Please Select" Selected="True"/>
                        <asp:ListItem Text="Login ID"/>
                        <asp:ListItem Text="Card No"/>
                        </asp:DropDownList>
                    </td>
                   <td>
                        <asp:TextBox ID="FindLoginID" runat="server"  CssClass="form-control" OnTextChanged="FindLoginID_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                         <asp:Button ID="btnFind" runat="server" Text="Search"  CausesValidation="false" CssClass="btn btn-info" OnClick="btnFind_Click"/>
                    </td>
                </tr>
            </table>
                   
        </div>--%>
         <%--   <div class="form-group">
            <table>
                <tr>
                    <td>
                        Login ID :
                    </td>
                    
                </tr>
            </table>
        </div>--%>
          </center>
                </div>
                <hr />
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader"
                        FooterStyle-CssClass="GrayBackWhiteFont"
                        ItemStyle-CssClass="Normal"
                        ItemStyle-BackColor="#ecd1c4"
                        AlternatingItemStyle-BackColor="white" BorderWidth="1px" BackColor="White" BorderColor="#3366CC"
                        BorderStyle="None" ShowFooter="True" CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">

                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                        </Columns>
                    </asp:GridView>
                </div>
        </div>
        </section>
    </div>
    </div>
</asp:Content>
