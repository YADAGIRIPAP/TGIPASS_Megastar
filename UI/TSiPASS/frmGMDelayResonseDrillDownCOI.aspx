<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmGMDelayResonseDrillDownCOI.aspx.cs" Inherits="UI_TSiPASS_frmGMDelayResonseDrillDownCOI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
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
    <script type="text/javascript">
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
           
            document.getElementById('<%=pdfPrint.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=gvdetailsnew.ClientID %>");
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
            var gridData = document.getElementById('<%= gvdetailsnew.ClientID %>');
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
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }
        
        select
        {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">Incentive</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Details</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                
                                   <%-- <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a>--%>
                                                <a id="pdfPrint" href="#" onclick="javascript:return printGrid();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                                </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr style="display: none">
                                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px" class="style11">
                                                                            <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="108px">Status</asp:Label>
                                                                        </td>
                                                                        <td class="style10" style="padding: 5px; margin: 5px">
                                                                            :
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                            <asp:DropDownList ID="ddlstatus" runat="server" class="form-control txtbox" Height="33px"
                                                                                Width="180px" AutoPostBack="True" TabIndex="1">
                                                                                <asp:ListItem>All</asp:ListItem>
                                                                                <asp:ListItem>Pending</asp:ListItem>
                                                                                <asp:ListItem>Reject</asp:ListItem>
                                                                                <asp:ListItem>Forwarded</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="108px">Industry Name</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                            :
                                                                        </td>
                                                                        <td class="style12" style="padding: 5px; margin: 5px">
                                                                            <asp:TextBox ID="TxtIndname" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px" class="style13">
                                                                            <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="108px">District</asp:Label>
                                                                        </td>
                                                                        <td class="style14" style="padding: 5px; margin: 5px">
                                                                            :
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px"
                                                                                Width="180px" AutoPostBack="True" TabIndex="1">
                                                                                <asp:ListItem Text="Select" Value="0"> </asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                                            <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="108px">Incentive Name</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                                            :
                                                                        </td>
                                                                        <td class="style16" style="padding: 5px; margin: 5px">
                                                                            <asp:DropDownList ID="ddlIncentiveName" runat="server" class="form-control txtbox"
                                                                                Height="33px" TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style13" style="padding: 5px; margin: 5px">
                                                                            <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="108px">From Date</asp:Label>
                                                                        </td>
                                                                        <td class="style14" style="padding: 5px; margin: 5px">
                                                                            :
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                            <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="108px">To Date</asp:Label>
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                            :
                                                                        </td>
                                                                        <td class="style16" style="padding: 5px; margin: 5px">
                                                                            <asp:TextBox ID="txtToDate" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td valign="middle" align="center" colspan="3" style="text-align: center">
                                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                    TabIndex="10" Text="Search" Width="90px" OnClick="BtnSearch_Click" />
                                                                &nbsp;
                                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen"
                                                                    Width="90px" />
                                                                &nbsp;<asp:Button ID="BtnSearch0" runat="server" CssClass="btn btn-info" Height="32px"
                                                                    OnClick="BtnSearch0_Click" TabIndex="10" Text="Export" Width="90px" />
                                                            </td>
                                                            

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 27px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3" align="center">
                                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                                    ForeColor="#006600"></asp:Label>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                                        <asp:Panel ID="Panel1" runat="server">
                                                                            <contenttemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                     <tr >
                                        <td style="text-align: left">
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmGMDelayReasonReportCOI.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>
                                        </td>
                                        <td  class="col-xs-5" style="padding: 5px; text-align: right;" colspan="1">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                        <div style="margin-bottom: 17px; text-align: left; margin-left:0px;">
                                                            <input type="text" id="search" class="form-control input-sm" style="width: 380px; font-size: 16px; height: 35px;float:left;margin-right:10px;" placeholder="Type to search" /><input type="button" class="btn btn-default" value="Clear" id="clear" />
                                        </div>
                                           <asp:GridView ID="gvdetailsnew"  runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                                            CellPadding="4"  Height="62px"
                                                                            PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound">
                                                                            <HeaderStyle VerticalAlign="Middle"  Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle BackColor="#013161"  Height="40px" CssClass="GridviewScrollC1Header" />
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
                                                                               <%-- <asp:BoundField DataField="EMiUdyogAadhar" ItemStyle-HorizontalAlign="Center" HeaderText="EMI Udyog Aadhaar" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>--%>
                                                                                <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="EnterpriseSector" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Unit" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="EnterpriseName" ItemStyle-HorizontalAlign="Center" HeaderText="Category of Unit" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>


                                                                                <asp:BoundField DataField="ApplciantName" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Name" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="Caste_Name" ItemStyle-HorizontalAlign="Center" HeaderText="Social Status" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="Address" ItemStyle-HorizontalAlign="Center" HeaderText="Address" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                 <asp:BoundField DataField="DELAYREASON" ItemStyle-HorizontalAlign="Center" HeaderText="Delay Reason"  >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                 <asp:BoundField DataField="DELAYREASONDATE" ItemStyle-HorizontalAlign="Center" HeaderText="Delay submit Date" DataFormatString="{0:dd-M-yyyy}" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                           <%--     <asp:BoundField DataField="IncentiveCount" ItemStyle-HorizontalAlign="Center" HeaderText="No. of Incentives" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>--%>
                                                                                  <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="MstIncentiveId" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                
                                                                                <asp:TemplateField HeaderText="Process Application" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                      <%--  <a id="View" target="_blank" href="ApplicantIncentiveDtls.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">View</a>--%>
                                                                                       <%-- <asp:HyperLink ID="anchortaglink" runat="server" Text="Process" Font-Bold="true" ForeColor="Green" Target="_blank" />--%>
                                                                                        <asp:Button ID="anchortaglink" runat="server" Text="Accept" CssClass="btn btn-primary" OnClick="anchortaglink_Click"></asp:Button>
                                                                                        <br />
                                                                                        <br />
                                                                                        <br/>
                                                                                         <asp:Button ID="btnnotaccept" runat="server" Text="Not Accept" CssClass="btn btn-primary" OnClick="btnnotaccept_Click"></asp:Button>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Showcause Letter"  Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagGMCertificate" runat="server" Text="Showcause Letter" Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                                                 <asp:BoundField DataField="SHOWCAUSEREPLIED" ItemStyle-HorizontalAlign="Center" HeaderText="Showcause reply by GM"  >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                 <asp:BoundField DataField="SHOWCAUSEREPLIEDDATE" ItemStyle-HorizontalAlign="Center" HeaderText="Showcause reply submit Date" DataFormatString="{0:dd-M-yyyy}" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                               
                                                                            </Columns>

                                              
                                                                            
                                                                        </asp:GridView>
                                        
                                        </td>

                                            </tr>
                                   
                                            </table>
                                            </div>
                                            </contenttemplate>
                                                                        </asp:Panel>
                                                                        <tr>
                                                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                                &nbsp;
                                                                                <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                                                    ForeColor="#006600"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <caption>
                                                                            &nbsp;</caption>
                                                                    </td>
                                                                </tr>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
    <script type="text/javascript">
        $(function () {
            $('#search').val('');
        });

        $('#search').keyup(function () {
            var value = $(this).val();
            var patt = new RegExp(value, "i");

            $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                if (!($(this).find('td').text().search(patt) >= 0)) {
                    $(this).not('thead').hide();
                }
                if (($(this).find('td').text().search(patt) >= 0)) {
                    $(this).show();
                }
            });

        });

        $('#clear').click(function () {
            $('#search').val('');
            $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody tr').show();
        });

    </script>
</asp:Content>
