﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporttesttt.aspx.cs" Inherits="SistemaControlEstudiantesUNI.formsReport.reporttesttt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
  <form id="formCustomerReport" runat="server">  
    <div>  
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  

        <rsweb:ReportViewer ID="CustomerListReportViewer" runat="server" Width="100%"></rsweb:ReportViewer>
         
    </div>  
</form>
</body>
</html>
