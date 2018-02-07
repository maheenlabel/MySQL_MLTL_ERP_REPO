<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PD_DashBorad.aspx.cs" Inherits="NewProjectERP.NPD.PD_DashBorad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        
        <script type="text/javascript">      

        $(document).ready(function () {            

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
                    <center><asp:label runat="server" Text="Approval Borad"></asp:label></center>
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>
                    </span>
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-horizontal" role="form">
                                <asp:Label runat="server" id="lblMsg" class="col-sm-2 control-label"></asp:Label>
                                <div class="form-group">
                                    <asp:Label runat="server" for="Program:" class="col-sm-2 control-label">Category Name</asp:Label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" Enabled="false" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>


                                    <asp:Label runat="server" for="SampleName:" class="col-sm-1 control-label">Status</asp:Label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" OnSelectedIndexChanged="Status_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="Please Select" Value="0" />
                                            <asp:ListItem Text="Approved" Value="1" />
                                            <asp:ListItem Text="Not Approved" Value="2" />
                                            <asp:ListItem Text="Reject" Value="3" />
                                            <asp:ListItem Text="All" Value="4" />

                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <center>
                            <asp:Button ID="btnApproved"  CssClass="btn btn-success" runat="server" Text="Update"  OnClick="btnApproved_Click"/> 
                                 <asp:Button ID="btnReject" CssClass="btn btn-primary" Visible="false" runat="server" Text="Reject" OnClick="btnReject_Click"/>                                 
                                   <asp:Button ID="btnExit" runat="server" CausesValidation="false" Text="New" CssClass="btn btn-warning" OnClick="btnExit_Click"/>                                     
                               
                            </center>
                    </div>
                </div>

                <hr />

                <div class="table-responsive">
                    <asp:GridView ID="gvPD_DashBoard" GridLines="None" CellPadding="4"
                        HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader "
                        FooterStyle-CssClass="GrayBackWhiteFont"
                        ItemStyle-CssClass="Normal"
                        ItemStyle-BackColor="#ecd1c4"
                        AlternatingItemStyle-BackColor="white"
                        runat="server"
                        DataKeyNames="ID"
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
                            <asp:TemplateField HeaderText="ID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SampleID" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSampleID" runat="server" Text='<%# Bind("SampleID") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BrandName" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SampleName" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblSampleName" runat="server" Text='<%# Bind("SampleName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Length" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblLength" runat="server" Text='<%# Bind("Length") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Width" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:Label ID="lblWidth" runat="server" Text='<%# Bind("Width") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Sample Qty" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblSampleQty" CssClass="form-control" runat="server" Text='<%# Bind("SampleQty") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Spec" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lblSpec" Width="20px" OnClick="lblSpec_Click">Spec</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Technical" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lblTechnical" Width="40px" OnClick="lblTechnical_Click">Technical</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Material" HeaderStyle-BackColor="#d9edf7" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lblMaterials" Width="20px" OnClick="lblMaterials_Click">Materials</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                           
                            <asp:TemplateField HeaderText="Email" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                      <asp:LinkButton runat="server" ID="lblShowEmail" Width="20px" OnClick="lblSpec_Click">Show Email</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                            
                            <asp:TemplateField HeaderText="Send Requisition" HeaderStyle-BackColor="#d9edf7" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lblSendRequisition" Width="20px" OnClick="lblSendRequisition_Click">Send Requisition</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                           
                            <asp:TemplateField HeaderText="Check Stock" HeaderStyle-BackColor="#d9edf7">
                                <ItemTemplate>
                                      <asp:LinkButton runat="server" ID="lblCheckStock" Width="20px" OnClick="lblSpec_Click">Check Stock</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="#d9edf7">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus"  runat="server" Text='<%# Eval("Status") %>' Visible="false"/>
                                                 <asp:DropDownList ID="ddlStatusgr" runat="server" Width="150px" CssClass="form-control">
                                             <asp:ListItem Text="Please Select" Value="0" />
                                            <asp:ListItem Text="Approved" Value="1" />
                                            <asp:ListItem Text="Not Approved" Value="2" />
                                            <asp:ListItem Text="Reject" Value="3" />
                                            <asp:ListItem Text="All" Value="4" />
                                                 </asp:DropDownList>
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
