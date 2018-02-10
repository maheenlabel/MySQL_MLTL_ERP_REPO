﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoSearchCompleted.aspx.cs" Inherits="autosearch.AutoSearchCompleted" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

  <html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
        <title>AutoComplete Box with jQuery</title>
        <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>  
        <script type="text/javascript">
            $(document).ready(function() {
                SearchText();
            });
            function SearchText() {
                $(".autosuggest").autocomplete({
                    source: function(request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "AutoSearchCompleted.aspx/GetAutoCompleteData",
                            data: "{'username':'" + document.getElementById('txtSearch').value + "'}",
                            dataType: "json",
                            success: function (data) {
                                if (data != null) {

                                    response(data.d);
                                }
                            },
                            error: function(result) {
                                alert("Error");
                            }
                        });
                    }
                });
            }
        </script>
  </head>
  <body>
      <form id="form1" runat="server">
          <div class="demo">
           <div class="ui-widget">
            <label for="tbAuto">Enter UserName: </label>
       <input type="text" id="txtSearch" class="autosuggest" />
               
    </div>
<div>
<asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
<ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCountry"
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" 
        CompletionInterval="1" ServiceMethod="GetCountries" UseContextKey="True" >
</ajax:AutoCompleteExtender>
</div>

        </form>
    </body>
    </html>  