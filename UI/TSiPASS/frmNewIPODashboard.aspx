<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true" CodeFile="frmNewIPODashboard.aspx.cs" Inherits="frmNewIPODashboard" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        .style10
        {
            width: 9px;
            height: 28px;
        }
        .style11
        {
            width: 210px;
            height: 28px;
        }
        .style12
        {
            width: 212px;
            height: 28px;
        }
        .style13
        {
            width: 210px;
            height: 21px;
        }
        .style14
        {
            width: 9px;
            height: 21px;
        }
        .style15
        {
            height: 21px;
        }
        .style16
        {
            width: 212px;
            height: 21px;
        }
        .style17
        {
            height: 28px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function sumPropBulk() {
            var txtFirstNumberValue = document.getElementById('txtProsPetorlClassA').value;
            var txtSecondNumberValue = document.getElementById('txtPropPetolClassB').value;
            var txtThirdNumberValue = document.getElementById('txtPropPetolClassB').value;
            var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue) + parseInt(txtThirdNumberValue);
            if (!isNaN(result)) {
                document.getElementById('txtPropPetrolTotal').value = result;
            }
        }
    </script>

    <div align="center">


        <div class="row" align="center">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">S.A &#39;s / J.A&#39;s Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            
                                            <div class="panel panel-default">
                            <div class="panel-body" align="center">
                            
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                                        
                                    <tr>
                                        <td style="width: 395px" valign="top">
                                             <div class="list-group">
                                          
                                           
                                            
                                            
                                              <a href="IncentiveStatusInspectionDateDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="lblAppl" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> No of Applications Received from GM
                                    </a>   
                                          <a class="list-group-item" ><i class="fa fa-fw fa-check"></i>Scrutiny Pending </a>

                                                <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=6"><span class="badge" >
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>With in 3 Days </a>
                                                
                                                
                                                <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=7"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days

                                                </a>
                                                 <a class="list-group-item" ><i class="fa fa-fw fa-check"></i>Scrutiny Completed</a>
                                         <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=6"><span class="badge" >
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>With in 3 Days </a>
                                                
                                                
                                                <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=7"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days
                                    </a>
                                                  
                                           </div>
                                        </td>
                                        <td valign="top">
                                             <div class="list-group" style="vertical-align:top">
                                                  <a class="list-group-item" ><i class="fa fa-fw fa-check"></i>Queries</a>

                                    <a href="IncentiveStatusInspectionDateDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label5" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Queries Yet to Respond
                                    </a>   

                                                 <a href="IncentiveStatusInspectionDateDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label6" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Queries Responded
                                    </a>   

                                                          <a href="IncentiveStatusInspectionDateDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label7" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Total Queries Raised
                                    </a>   
                                  </div>
                                                  
                                        </td>
                                    </tr>
                                  
                                </table>
                               
                            </div>
                        </div>
                                            
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <table cellpadding="2" style="width: 100%">
                                                <tr>
                                                    <td style="width: 417px">
                                                        <a href="IPO Login.doc" target="_blank">User Manual of IPO/DD/AD</a>  </td></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                   
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>


        </div>

</asp:Content>


