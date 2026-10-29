<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="Jdwisereports.aspx.cs" Inherits="UI_TSiPASS_Jdwisereports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style type="text/css">
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
            overflow: hidden;
        }



        th {
            text-align: center;
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
            vertical-align: top;
        }

        .radio-inline td {
            padding-right: 25px;
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
            vertical-align: middle;
            border-radius: 4px;
        }

        button[disabled], input[disabled] {
            cursor: not-allowed !important;
        }
    </style>
    <script>

        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }
    </script>


    <script language="javascript" type="text/javascript">
        function Panel1() {


            document.getElementById('<%=A1.ClientID %>').style.display = "none";
          
            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=div_Print.ClientID %>");


            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');

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


    </script>
    <link rel="stylesheet" href="http://localhost:9736/code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">






    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">

        <tr>
            <td style="text-align: left">
                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/Department/JDreports.aspx"
                    Text="<< Back">
                </asp:HyperLink>
            </td>
        </tr>

        <tr>




            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">


                    <div class="panel-heading" style="text-align: center">


                            <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">Abstract</asp:Label>
                            &nbsp; <a id="A2" href="#"  onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a>
                                <a id="A1" href="#" onclick="javascript:return Panel1();" runat="server">
                                        <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                            </h3>
                
                      </div>
                        <h3 class="panel-title" style="font-weight: bold;">





                        <%--    <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <label for="new_name" class="col-sm-3 control-label">From Date:<span style="font-weight: bold; color: red;">*</span></label>
                                            <div class="col-sm-3">
                                                <asp:TextBox runat="server" class="datepicker-input" ID="txtfromdate" Style="height: 31px; width: 120px" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <label for="new_name" class="col-sm-3 control-label">To Date:<span style="font-weight: bold; color: red;">*</span></label>
                                            <div class="col-sm-3">

                                                <asp:TextBox runat="server" class="datepicker-input" ID="txttodate" Style="height: 31px; width: 120px;" />

                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>--%>



                            <div class="col-sm-10">
                                <div class="form-group" style="text-align:right;" >

                                     <b>
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>


                                </div>
                            </div>

                            <div class="panel-body">
                                <table align="center">

                                    <tr id="div_Print" runat="server" style="width:1000px;">

                                      

                                     <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                           <asp:GridView ID="gvdetailsnew" CssClass="" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CellPadding="4" Height="62px"
                                                PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both">
                                                <HeaderStyle Height="40px" ForeColor="#FFFFFF" BackColor="#009688" CssClass="text-center" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="RMId" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NameofUnit" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RMName" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Raw Material">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RMApplicationType" ItemStyle-HorizontalAlign="Center" HeaderText="Application Type">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="ApplicationFiledDate" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-HorizontalAlign="Center" HeaderText="Application Filed Date">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:BoundField>
                                                      

                                                    



                                                    



                                                      <asp:BoundField DataField="District" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-HorizontalAlign="Center" HeaderText="District">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:BoundField>
                                                     

                                                
                                                  


                                                  

                                                    <asp:TemplateField HeaderText="RMTypeId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRmTypeid" Text='<%#Eval("RMTypeId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>





                                                </Columns>
                                            </asp:GridView>



                                     </td>



                                          
                                     
                                        
                                           
                                        
                                   

                                    </tr>

                                     <asp:Label runat="server" ID="Label1" Visible="false"></asp:Label>
                                </table>


                              
                            </div>
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

