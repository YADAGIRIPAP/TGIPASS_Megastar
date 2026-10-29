<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="JDreports.aspx.cs" Inherits="UI_TSiPASS_JDreports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
           document.getElementById('<%=pdfPrint.ClientID %>').style.display = "none";

           var panel = document.getElementById("<%=grdDetails.ClientID %>");
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
     <script type="text/javascript">
         function printGrid() {
             var gridData = document.getElementById('<%= grdDetails.ClientID %>');
             var windowUrl = 'about:blank';
             //set print document name for gridview
             var uniqueName = new Date();
             var windowName = 'Print_' + uniqueName.getTime();
             var prtWindow = window.open(windowName, 'left=100,top=100,right=100,bottom=100,width=700,height=500');
             prtWindow.document.write('<html><head></head>');
             prtWindow.document.write('<body style=”background:none !important”>');
             prtWindow.document.write(gridData.outerHTML);
             prtWindow.document.write('</body></html>');
             prtWindow.document.close();
             prtWindow.focus();
             prtWindow.print();
             prtWindow.close();
         }
    </script>
   <link rel="stylesheet" href="../code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
   <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 2px; height: 675px;"
                valign="top" > 
                <div class="panel panel-default">
                    <div class="panel-heading" >
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server"  >Abstract</asp:Label>
                            &nbsp;<a id="pdfPrint" href="#" onclick="javascript:return printGrid();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                              
                    </div>
                    <div class="panel-body">
                        <table  cellpadding="10" cellspacing="3" style="font-family: 'Trebuchet MS'">

                           
                         
                           
                            <tr>
                                <td style="text-align: left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/Department/NewJDDashboard.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>
                                </td>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                            </tr>
              



                          
                       
                            <tr>

                               
                                <td align="left">
                                    <b>Distric Level Wise Reports</b>
                                </td>
                                </tr>

                                <tr id="div_Print" runat="server" >
                                <td align="center" colspan="6"  style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"  OnRowDataBound="grdDetails_RowDataBound"                                    
                                        ShowFooter="false" >
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" Width="20px" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>

                                             <asp:BoundField DataField="SlNo" HeaderText="SNO"  />

                                             <asp:BoundField DataField="DistCd" HeaderText="District Name"  Visible="false"/>
                                          <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                           
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="No. of Applications" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("Noofapplications") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Scrunity Pending" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%#Eval("scrunitypending") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Scrunity completed" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink3" runat="server" Text='<%#Eval("scrunitycompleted") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Reffered to Inspecting Officier" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink4" runat="server" Text='<%#Eval("ipoapplications") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Inspection report submitting" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink5" runat="server" Text='<%#Eval("ipecsub") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Inspection report Pending" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink6" runat="server" Text='<%#Eval("inspecbpending") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Dipcagenda Completed" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink7" runat="server" Text='<%#Eval("dipccompletd") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Dipcagenda Pending" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink8" runat="server" Text='<%#Eval("dipcpending") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Submitting COI" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink9" runat="server" Text='<%#Eval("COIwithin") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Submitting SSCL" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink10" runat="server" Text='<%#Eval("SSCLwithin") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                         



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

