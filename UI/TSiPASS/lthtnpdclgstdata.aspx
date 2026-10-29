<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="lthtnpdclgstdata.aspx.cs" Inherits="UI_TSiPASS_lthtnpdclgstdata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
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

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .algnRight {
            text-align: right;
        }
    </style>
    <style>
        .algnCenter {
            text-align: center;
        }

        body {
            font-family: 'Trebuchet MS';
        }
    </style>
    <script type="text/javascript" language="javascript">
        function OpenPopup() {
            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");
            return false;
        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {
            win = window.open("commsmeprint.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function PopupONE(intval) {

            win = window.open("frmMSME_edit.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('#MstLftMenu').remove();
        });

    </script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter {
            text-align: center;
        }
        </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
              {
                  dateFormat: "dd-mm-yy",
                  changeMonth: true,
                  changeYear: true,
                  yearRange: yrRange

                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
              {
                  dateFormat: "dd-mm-yy",
                  changeMonth: true,
                  changeYear: true,
                  yearRange: yrRange

                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
               {
                   //dateFormat: "dd/mm/yy",
                   dateFormat: "dd-mm-yy",
                   //maxDate: new Date(currentYear, currentMonth, currentDate)
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange
               });
            $("input[id$='txtTodate']").datepicker(
              {
                  dateFormat: "dd-mm-yy",
                  changeMonth: true,
                  changeYear: true,
                  yearRange: yrRange

                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
        });
    </script>
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
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
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">List of MSME Applications</a> </li>
        </ol>
    </div>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" align="center">
                <h3 class="panel-title" style="font-weight: bold;">
                    <asp:Label ID="lblHeading" runat="server"></asp:Label>&nbsp; <a id="A1" href="#"
                        onserverclick="BtnSave3_Click" runat="server">
                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                            alt="PDF" /></a>&nbsp;&nbsp; <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                    <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                        runat="server">
                        <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                            style="float: right;" /></a>
                </h3>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5">
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" Text="<< Back">
                            </asp:HyperLink>
                        </td>
                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="style8" style="padding: 5px; margin: 5px; text-align: right;"
                            valign="top"></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="100%">
                                <tr><td>
                                     <table width="80%">
                                                <tr runat="server" id="trBetweenDates" visible="true">
                                                    <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                                    <td></td>
                                                    
                                                    
                                                    
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label3" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                            data-balloon-pos="down" CssClass="LBLBLACK">Select District : </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox"
                                                            Height="33px" Width="180px" AutoPostBack="false">
                                                            <asp:ListItem Value="%">--ALL--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                
                                            </table>
                                    </td>
                                    <td></td>
                                   
                                </tr>
                                <tr>
                                    <%--<td style="padding: 5px; margin: 5px" align="left" class="auto-style1"></td>
                                    <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                    <td></td>
                                    <td></td>--%>
                                </tr>
                                <tr align="center">
                                    <td id="Td1" style="padding: 5px; margin: 5px" colspan="4" align="center" runat="server" visible="true">
                                        <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td id="Td2" style="padding: 5px; margin: 5px" colspan="4" align="center" runat="server">
                                        <%--<asp:Button ID="Button1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                            Text="Submit" OnClick="BtnSave1_Click" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr id="divPrint" runat="server">
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px; text-align: center;"
                            valign="top">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                ShowFooter="True" Width="100%" OnRowDataBound="grdDetails_RowDataBound"  >
                                <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="SLNO" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLID" Text='<%#Eval("IDENTITYCOLUMN") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                    <asp:BoundField DataField="DISTRICT" ItemStyle-HorizontalAlign="Center" HeaderText="DISTRICT">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ENTERPRISENAME" ItemStyle-HorizontalAlign="Center" HeaderText="ENTERPRISE NAME">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADDRESS" ItemStyle-HorizontalAlign="Center" HeaderText="ADDRESS">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="MOBILENO" ItemStyle-HorizontalAlign="Center" HeaderText="MOBILENO">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EMAILID" ItemStyle-HorizontalAlign="Center" HeaderText="EMAIL ID">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LINEOFACTIVITY" ItemStyle-HorizontalAlign="Center" HeaderText="LINE OF ACTIVITY">
                                        <ItemStyle HorizontalAlign="Center" />
                                      </asp:BoundField>
                                    <asp:TemplateField HeaderText="Whether temperory or permanent connection" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLDISCONNECTION" Text='<%#Eval("DISCONNECTION") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Connection Status" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLCONNECTIONSTATUS" Text='<%#Eval("CONNECTIONSTATUS") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Whether Temperory or Permanent Connction">
                                        <ItemTemplate>
                                           
                                           <asp:RadioButtonList ID="rbltemporperm" AutoPostBack="true" OnSelectedIndexChanged="rbltemporperm_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server" >
                            <asp:ListItem Value="T" >Temperory</asp:ListItem>
                            <asp:ListItem Value="P" >Permanent</asp:ListItem>
                        </asp:RadioButtonList>
                                            <br />
                                           <asp:Label ID="LBLREASON" runat="server" Visible="false">Please enter Reasons for Disconnection</asp:Label> 
                                             <asp:TextBox ID="txtreason" runat="server" Visible="false"></asp:TextBox>
                                            <br />
                                            <asp:Button ID="btnsubmitreason" runat="server" Visible="false" Text="SUBMIT REASON" OnClick="btnsubmitreason_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reasons for Disconnection(UDC/BS)" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLREASONS" Text='<%#Eval("REASONS") %>' runat="server" Visible="false" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Whether Existing unit name is same as MSME Data">
                                        <ItemTemplate>
                                           
                                           <asp:RadioButtonList ID="rblunitname" AutoPostBack="true" OnSelectedIndexChanged="rblunitname_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server" >
                            <asp:ListItem Value="Y" >YES</asp:ListItem>
                            <asp:ListItem Value="N" >NO</asp:ListItem>
                        </asp:RadioButtonList>
                                            <br />
                                           <asp:Label ID="LBLUNITNAMENEW" runat="server" Visible="false">Please enter Unit Name as per MSME data for Mapping</asp:Label> 
                                             <asp:TextBox ID="txtunitname" runat="server" Visible="false"></asp:TextBox>
                                            <br />
                                            <asp:Button ID="btnsubmitunitname" runat="server" Visible="false" Text="SUBMIT" OnClick="btnsubmitunitname_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Whether belongs to your district ot not">
                                        <ItemTemplate>
                                           
                                           <asp:RadioButtonList ID="rbldistrict" AutoPostBack="true" OnSelectedIndexChanged="rbldistrict_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server" >
                            <asp:ListItem Value="Y" >YES</asp:ListItem>
                            <asp:ListItem Value="N" >NO</asp:ListItem>
                        </asp:RadioButtonList>
                                            <br />
                                           <asp:Label ID="LBLDISTRICTORNOT" runat="server" Visible="false">Please select district</asp:Label> 
                                             <asp:DropDownList ID="ddldistrict_GRID" Visible="false" runat="server" class="form-control txtbox" Height="33px" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_GRID_SelectedIndexChanged"
                                                TabIndex="1" Width="180px" >
                                                <asp:ListItem Value="0">--District--</asp:ListItem>
                                               
                                            </asp:DropDownList>
                                            <br />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ENTERPRISE TYPE">
                                        <ItemTemplate>
                                           
                                            <asp:DropDownList ID="ddl_status" runat="server" class="form-control txtbox" Height="33px"
                                                TabIndex="1" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddl_status_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Industry</asp:ListItem>
                                                <asp:ListItem Value="2">Service</asp:ListItem> 
                                            </asp:DropDownList>
                                            <br />
                                           <asp:Label ID="lblmsme" runat="server" Visible="false">whether  mapped with MSME or Not</asp:Label> 
                                            <asp:RadioButtonList ID="rblmsme"  Visible="false" runat="server"
                                                AutoPostBack="true" OnSelectedIndexChanged="rblmsme_SelectedIndexChanged"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            <br />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="DISTRICTID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLDISTRICTID" Text='<%#Eval("DISTRICTID") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                     <asp:TemplateField HeaderText="UNIT NAME" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLUNITNAME" Text='<%#Eval("ENTERPRISENAME") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                    <asp:BoundField DataField="MSMENO" ItemStyle-HorizontalAlign="Center" HeaderText="MSME NO">

                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Same District or not" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLSAMEDISTRICTORNOT" Text='<%#Eval("SAMEDISTRICTORNOT") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Industry/Service" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLINDUSORSERVICE" Text='<%#Eval("INDUSTRYORSERVICE") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Name same as  MSME data or not" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLUNITNAMESAMEORNIT" Text='<%#Eval("UNITNAME_SAMEORNOT") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                          
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <%--<tr id="divPrint_new" runat="server">
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px; text-align: center;"
                            valign="top">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                ShowFooter="True" Width="100%">
                                <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NAMEOFUNIT" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADDRESSOFUNIT" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Address">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="LINEOFACTIVITY" ItemStyle-HorizontalAlign="Center" HeaderText="Line of Activity">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="SECTOR" ItemStyle-HorizontalAlign="Center" HeaderText="Sector">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVESTMENT" ItemStyle-HorizontalAlign="Center" HeaderText="Investment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EMPLOYMENT" ItemStyle-HorizontalAlign="Center" HeaderText="Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PROGRESS" ItemStyle-HorizontalAlign="Center" HeaderText="Implementation Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>


                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>--%>
                    <%--<tr id="divExport" visible="false" runat="server">
                        <td align="center" style="text-align: center;" valign="top">
                            <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="true" ShowFooter="true">

                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                </Columns>
                                <RowStyle Wrap="true" />
                            </asp:GridView>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="child" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
