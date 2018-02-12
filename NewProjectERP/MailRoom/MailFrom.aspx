<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MailFrom.aspx.cs" Inherits="NewProjectERP.MailRoom.MailFrom" %>

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
                                <asp:Label runat="server" ID="lblMsg" class="col-sm-2 control-label"></asp:Label>
                                <hr />

                                <div style="width: 100%;">
                                    <div style="width: 100%;">
                                        <div style="width: 30%; float: left">
                                            <div class="panel-body">

                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvMailRoom" runat="server" CellPadding="4" HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader"
                                                        FooterStyle-CssClass="GrayBackWhiteFont"
                                                        ItemStyle-CssClass="Normal"
                                                        ItemStyle-BackColor="#ecd1c4"
                                                        AlternatingItemStyle-BackColor="white" BorderWidth="1px" BackColor="White" BorderColor="#3366CC"
                                                        BorderStyle="None" ShowFooter="True" CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" AllowPaging="True">
                                                    </asp:GridView>
                                                </div>


                                            </div>
                                        </div>
                                        <div style="width: 70%; float: right">
                                            <div class="panel-body">

                                                <div class="form-group">
                                                    <label for="Subject:" class="col-sm-2 control-label">Subject:</label>
                                                    <div class="col-sm-9">
                                                        <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="From:" class="col-sm-2 control-label">From:</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <asp:CheckBox ID="IsAttachment" runat="server"/>
                                                     <asp:LinkButton runat="server" ID="lblPreview" >Attachment</asp:LinkButton>
                                                </div>
                                                   <div class="form-group">
                                                    <label for="Subject" class="col-sm-2 control-label">CC:</label>
                                                    <div class="col-sm-9">
                                                       <asp:label ID="labCC" runat="server" class="col-sm-2 control-label"></asp:label>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label for="Body:" class="col-sm-2 control-label">Body:</label>
                                                    <div class="col-sm-9">
                                                        <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine"  style="height:200px;"  CssClass="form-control"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <center>
                            <asp:Button ID="btnRead"  CssClass="btn btn-success" runat="server" Text="Read"  OnClick="btnRead_Click"/> 
                               
                            </center>
                    </div>
                </div>
            </section>

        </div>
    </div>


</asp:Content>

