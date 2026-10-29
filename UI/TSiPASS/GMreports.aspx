<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="GMreports.aspx.cs" Inherits="UI_TSiPASS_GMreports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" href="/../code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

     <style type="text/css">

        
#myFooter
{
 display:none;
}


     


        ul.nav-wizard {
            background-color: #f1f1f1;
            border: 1px solid #d4d4d4;
            -webkit-border-radius: 6px;
            -moz-border-radius: 6px;
            border-radius: 3px;
            position: relative;
            overflow: hidden;
        }

            ul.nav-wizard:before {
                position: absolute;
            }

            ul.nav-wizard:after {
                display: block;
                position: absolute;
                left: 0px;
                right: 0px;
                top: 138px;
                height: 47px;
                border-top: 1px solid #d4d4d4;
                border-bottom: 1px solid #d4d4d4;
                z-index: 11;
                content: " ";
            }

            ul.nav-wizard li {
                position: relative;
                float: left;
                height: 46px;
                display: block;
                text-align: center;
                padding: 0 20px 0 30px;
                margin: 0;
                font-size: 16px;
                line-height: 46px;
            }

                ul.nav-wizard li a {
                    color: #428bca;
                    padding: 0;
                }

                    ul.nav-wizard li a:hover {
                        background-color: transparent;
                    }

                ul.nav-wizard li:before {
                    position: absolute;
                    display: block;
                    border: 24px solid transparent;
                    border-left: 16px solid #d4d4d4;
                    border-right: 0;
                    top: -1px;
                    z-index: 10;
                    content: '';
                    right: -16px;
                }

                ul.nav-wizard li:after {
                    position: absolute;
                    display: block;
                    border: 24px solid transparent;
                    border-left: 16px solid #f1f1f1;
                    border-right: 0;
                    top: -1px;
                    z-index: 10;
                    content: '';
                    right: -15px;
                }

                ul.nav-wizard li.active {
                    color: #3a87ad;
                    background: #dedede;
                }

                    ul.nav-wizard li.active:after {
                        border-left: 16px solid #dedede;
                    }

                    ul.nav-wizard li.active a,
                    ul.nav-wizard li.active a:active,
                    ul.nav-wizard li.active a:visited,
                    ul.nav-wizard li.active a:focus {
                        color: #989898;
                        background: #dedede;
                    }

            ul.nav-wizard .active ~ li {
                color: #999999;
                background: #f9f9f9;
            }

                ul.nav-wizard .active ~ li:after {
                    border-left: 16px solid #f9f9f9;
                }

                ul.nav-wizard .active ~ li a,
                ul.nav-wizard .active ~ li a:active,
                ul.nav-wizard .active ~ li a:visited,
                ul.nav-wizard .active ~ li a:focus {
                    color: #999999;
                    background: #f9f9f9;
                }

            ul.nav-wizard.nav-wizard-backnav li:hover {
                color: #468847;
                background: #f6fbfd;
            }

                ul.nav-wizard.nav-wizard-backnav li:hover:after {
                    border-left: 16px solid #f6fbfd;
                }

                ul.nav-wizard.nav-wizard-backnav li:hover a,
                ul.nav-wizard.nav-wizard-backnav li:hover a:active,
                ul.nav-wizard.nav-wizard-backnav li:hover a:visited,
                ul.nav-wizard.nav-wizard-backnav li:hover a:focus {
                    color: #468847;
                    background: #f6fbfd;
                }

            ul.nav-wizard.nav-wizard-backnav .active ~ li {
                color: #999999;
                background: #ededed;
            }

                ul.nav-wizard.nav-wizard-backnav .active ~ li:after {
                    border-left: 16px solid #ededed;
                }

                ul.nav-wizard.nav-wizard-backnav .active ~ li a,
                ul.nav-wizard.nav-wizard-backnav .active ~ li a:active,
                ul.nav-wizard.nav-wizard-backnav .active ~ li a:visited,
                ul.nav-wizard.nav-wizard-backnav .active ~ li a:focus {
                    color: #999999;
                    background: #ededed;
                }



        .file-preview-input {
            position: relative;
            overflow: hidden;
            margin: 0px;
            color: #333;
            background-color: #fff;
            border-color: #ccc;
        }

            .file-preview-input input[type=file] {
                position: absolute;
                top: 0;
                right: 0;
                margin: 0;
                padding: 0;
                font-size: 20px;
                cursor: pointer;
                opacity: 0;
                filter: alpha(opacity=0);
            }

        .file-preview-input-title {
            margin-left: 2px;
        }

        .file {
            visibility: hidden;
            position: absolute;
        }


        .progressBar {
            width: 300px;
            height: 22px;
            /*border: 1px solid #ddd;
            border-radius: 5px;*/
            overflow: hidden;
            display: block;
            margin: 0px 10px 5px 5px;
            vertical-align: top;
        }

            .progressBar div {
                height: 100%;
                color: #fff;
                text-align: center;
                /*line-height: 22px;*/ /* same as #progressBar height if we want text middle aligned */
                width: 0;
                background-color: #0ba1b5;
                border-radius: 3px;
            }

        .statusbar {
            border-top: 1px solid #A9CCD1;
            min-height: 25px;
            /*width: 700px;*/
            padding: 10px 10px 0px 10px;
            vertical-align: top;
        }

        /*.statusbar:nth-child(odd) {
            background: #EBEFF0;
        }*/

        .filename {
            display: inline-block;
            vertical-align: top;
            width: 300px;
            overflow:hidden;
        }

        .filesize {
            display: inline-block;
            vertical-align: top;
            color: #30693D;
            width: 100px;
            margin-left: 10px;
            margin-right: 5px;
        }

        .abort {
            background-color: #A8352F;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
            display: inline-block;
            color: #fff;
            font-family: arial;
            font-size: 13px;
            font-weight: normal;
            padding: 4px 15px;
            cursor: pointer;
            vertical-align: top
        }

        .radio-inline td {
            padding-right:25px;
        }

         button[disabled], .btnsuccess {
        
        color: #fff;
        background-color: #337ab7;
        border-color: #2e6da4;
        display: inline-block;
        padding: 6px 12px;
        margin-bottom: 0;
        font-size: 14px;
        font-weight: 400;
        line-height: 1.42857143;
        text-align: center;
        white-space: nowrap;
        vertical-align: middle;border-radius: 4px;
        
        }
        button[disabled],input[disabled]{
            cursor:not-allowed !important;
        }

    </style>
   
     <script language="javascript" type="text/javascript">
         function Panel1() {
             
             
             var panel = document.getElementById("<%=divPrint.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title>newTable</title>');

             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();

             setTimeout(function () {
                 printWindow.print();
                 location.reload(true);
                 printWindow.close();
             }, 1000);
             return false;

         }


         $(function () {

             $('#MstLftMenu').remove();

         });

    </script>
   <link rel="stylesheet" href="../code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 2px; height: 675px;"
                valign="top" > 
                <div class="panel panel-default">
                    <div class="panel-heading" >
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server"  >Abstract</asp:Label>
                            &nbsp;<a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                              </h3>
                    </div>
                    <div class="panel-body">
                        <table  cellpadding="10" cellspacing="3" style="font-family: 'Trebuchet MS'">

                           
                         
                           
                            <tr>
                                <td style="text-align: left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/Department/NewJDDashboard.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>
                                </td>
                            </tr>
              
                            <tr>
                               



                                                            <div class="col-md-3">
                                                              
                                                                  
                                                                        <label for="new_name" class=" control-label">From Date:<span style="font-weight: bold; color: red;">*</span></label>
                                                                        
                                                                      <asp:TextBox runat="server" class="datepicker-input" ID="txtfromdate"  style="height: 31px;" Width="120px"   placeholder="Enter Fromdate (DD - MM - YYYY)" />
                                                                        
                                                                        
                                                                  
                                                             
                                                            </div>
                                                            <div class="col-md-3">
                                                             
                                                                   
                                                                        <label for="new_name" class=" control-label">To Date:<span style="font-weight: bold; color: red;">*</span></label>
                                                                        
                                                                       
                                                                             <asp:TextBox runat="server" class="datepicker-input"  ID="txttodate"  style="height: 31px;"   Width="120px"  placeholder="Enter Todate (DD - MM - YYYY)" />
                                                                           
                                                                       
                                                               
                                                            </div>


                                     
                                                                
                                                                    <div class="row">
                                                                        <label for="new_name" class="control-label">District:<span style="font-weight: bold; color: red;">*</span></label>
                                                                       
                                                                       
                                                                                                               
                                                  <asp:DropDownList ID="DropDownList1" runat="server"  Height="33px" Width="120px" cssstyle="" >  
        </asp:DropDownList>  
                                                                           
                                                                       
                                                                
                                                                </div>
                                                           
                                                       


                                </tr>
                             <tr>

                                  <div class="col-sm-7" style="visibility:hidden">
                                             <div class="form-group" style="text-align:center;padding-left:150px;">
                                                      <div class="row">
                                          <asp:Button runat="server" id="Button2"  Text="Submit" OnClick="btnLogin_Click" Width="100px"/>
                                           
                                                                     </div>
                                                 
                                                                                      </div>
                                         </div>
                               
                               

                             </tr>
                            <tr>
                               
                                
                                             <div class="form-group" style="text-align:left;padding-left:250px;">
                                                      <div class="row">
                                          <asp:Button runat="server" id="Button1"  Text="Submit" OnClick="btnLogin_Click" Width="100px"/>
                                           
                                                                     </div>
<div class="row">
<b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
</div>
                                                 
                                                                                      </div>
                               

                                  
                            </tr>
                            <tr>

                               
                                <td align="left">
                                    <b>Srcutiny Stage</b>
                                </td>
                                </tr>

                                <tr id="div_Print" runat="server" >
                                <td align="left" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"                                    
                                        ShowFooter="false"  OnRowDataBound="grdDetails_RowDataBound">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" Width="10px" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                         
                                            <asp:HyperLinkField HeaderText="Application received" DataTextField="TOTAL">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Scrutiny Pending Within Due Date"  DataTextField="within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Scrutiny Pending Beyond Due Date" DataTextField="beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Scrutiny Pending"   DataTextField="totalassigned">
                                                <FooterStyle HorizontalAlign="Center" />
                                               <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Scrutiny Completed Within Due Date"   DataTextField="completedassignedwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Scrutiny Completed Beyond Due Date"   DataTextField="completedassignedbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Scrutiny Completed"  DataTextField="totalassignedcompleted">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                          
                                 

                                              <asp:HyperLinkField HeaderText="Query Raised" DataTextField="gmquery">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="GM Rejected" DataTextField="rejeted">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>

                           

                           <tr>

                                <td align="left">

                                    <b>Inspection Stage</b>
                                </td>


                            </tr>

                               <tr id="Tr13" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="gvLevel2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ShowFooter="false"  OnRowDataBound="gvLevel2_RowDataBound">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Width="40px" Height="40px" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                           
                                            <asp:HyperLinkField HeaderText="Total Applications" DataTextField="totalipoapps" HeaderStyle-Wrap="true" HeaderStyle-Width="50px">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                         
                                            
                                          
  <asp:HyperLinkField HeaderText="Inspections Scheduled Within Due Date" DataTextField="inspectionwithin"  >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspections Scheduled Beyond Due Date" DataTextField="inspectionbeyond" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Total Inspections Scheduled" DataTextField="totalinspscheduled" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                              <asp:HyperLinkField HeaderText="InspectionS not Yet Scheduled Within Due Date" DataTextField="notinspschedulewithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                              <asp:HyperLinkField HeaderText="InspectionS not Yet Scheduled Beyond Due Date" DataTextField="notyetschedulebeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                              <asp:HyperLinkField HeaderText="Total Inspections not Yet Scheduled" DataTextField="totalinspnotscheduled">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Pending Within" DataTextField="insprptnotsubpenwithin" visible="false" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Pending Beyond" DataTextField="insprptnotsubbeyond" visible="false" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Inspection Upload Total Pending" DataTextField="totalinsprptnotsub" visible="false" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Within" DataTextField="inspsubwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Beyond" DataTextField="inspsubmittedbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Inspections Uploaded" DataTextField="totalinsprptsubmitted">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Query Raised" DataTextField="ipoquery">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                                 </Columns>
                                    </asp:GridView>
                     

                                    </td>
                                   </tr>
                            
                              <tr>

                                <td align="left">

                                    <b>Refferal Stage</b>
                                </td>
                                  </tr>
                                          <tr id="Tr51" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">


                                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ShowFooter="false" OnRowDataBound="GridView2_RowDataBound">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Width="40px" Height="40px" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>

                                            <asp:HyperLinkField HeaderText="Pending to be Reffered Within" DataTextField="pendingwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending to be Reffered Beyond" DataTextField="pendingbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            
                                            <asp:HyperLinkField HeaderText="Referred to Dipcagenda Within" DataTextField="dipcagendawithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Referred to Dipcagenda Beyond" DataTextField="dipcbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Release within" DataTextField="releasewithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="ReleaseBeyond" DataTextField="releasebeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Submitted COI within" DataTextField="coiwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                            <asp:HyperLinkField HeaderText="Submitted COI Beyond" DataTextField="coibeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Submitted SSCL within " DataTextField="ssclwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                             <asp:HyperLinkField HeaderText="Submitted SSCL Beyond " DataTextField="ssclbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                        </Columns>

                                    </asp:GridView>

                                    </td>
                                              </tr>
                            <tr>
                              <td align="left">

                                    <b>JD Level </b>
                                </td>
                                  </tr>
                                          <tr id="Tr1" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        
                                        ShowFooter="false"  OnRowDataBound="GridView1_RowDataBound" >
                                      <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Width="40px" Height="40px" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:HyperLinkField HeaderText="Total Applications Received from GM" DataTextField="total">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Within " DataTextField="jdwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="pending Beyond" DataTextField="jdbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                              <asp:HyperLinkField HeaderText="Total Pending" DataTextField="totaljdapps">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                        
                                          

                                            <asp:HyperLinkField HeaderText="Approved Within" DataTextField="jdcompletedassign">
                                             <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                            <asp:HyperLinkField HeaderText="Approved Beyond" DataTextField="jdcompletedbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total" DataTextField="jdtotal">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                              <asp:HyperLinkField HeaderText="Rejected" DataTextField="jdreject">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Total Query Raised" DataTextField="jdqueries">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                         
                                        </Columns>
                                    </asp:GridView>



                             </td>


                                              

                                  
                            </tr>


         <tr>
                              <td align="left">

                                    <b> Addittional Level </b>
                                </td>
                                  </tr>
                                          <tr id="Tr2" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">

                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    
                                        ShowFooter="false"  OnRowDataBound="GridView3_RowDataBound">
                                         <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Width="40px" Height="20px" />
                                        <RowStyle Height="20px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:HyperLinkField HeaderText="Total Applications" DataTextField="addltotal"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText=" Pending Within" DataTextField="addlwithin"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText=" pending Beyond " DataTextField="addlbeyond"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                               <asp:HyperLinkField HeaderText="Total Applications Pending" DataTextField="totaladdlpend"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Applications Within SSCl" DataTextField="addlssclwithin"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Approved Applications Beyond SSCl" DataTextField="addlssclbeyond"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField >
                                          <asp:HyperLinkField HeaderText="Approved Applications commissioner Within" DataTextField="commissionerwithin"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Approved Applications commissioner Beyond" DataTextField="commissionerbeynd" HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField >
                                           
                                            <asp:HyperLinkField HeaderText="Rejected" DataTextField="addlreject"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Query Raised" DataTextField="addlquery"  HeaderStyle-Width="160" >
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                           
                                        </Columns>

                                    </asp:GridView>

                                    </td>

                                              </tr>

                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <script src="js/jquery-1.3.2.min.js"></script>
       <script src="Scripts/JqueryTextBoxMask.js"></script>
    <script src="Scripts/JsonHtmlTable.js"></script>
    <script src="js/jquery-ui-1.7.1.custom.min.js"></script>
    <script>

        $('#MstLftMenu').remove();
      


        $(".datepicker-input").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd-mm-yy'
        });

        $("#datepicker-btn").click(function () {
            $(this).parent().prev().datepicker('show');
        });

      



       
       
    </script>

</asp:Content>

