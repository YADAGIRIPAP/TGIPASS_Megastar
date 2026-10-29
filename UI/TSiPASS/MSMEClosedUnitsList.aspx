<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="MSMEClosedUnitsList.aspx.cs" Inherits="UI_TSiPASS_MSMEClosedUnitsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= grdDetails.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();
            var prtWindow = window.open(windowUrl, windowName,
                'left=100,top=100,right=100,bottom=100,width=700,height=500');
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

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
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

        .style21 {
            height: 35px;
        }

        .style26 {
            height: 21px;
        }

        .style27 {
            height: 21px;
        }

        .style34 {
            height: 21px;
            width: 261px;
        }

        .style35 {
            height: 35px;
            width: 261px;
        }

        .style36 {
            width: 261px;
        }

        .style41 {
            height: 29px;
        }

        .style42 {
            width: 261px;
            height: 29px;
        }

        .style46 {
            height: 44px;
        }

        .style47 {
            height: 44px;
            width: 261px;
        }

        .style48 {
            width: 10px;
            height: 44px;
        }

        .style49 {
            width: 206px;
            height: 44px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function OpenPopup() {
            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");
            return false;
        }
    </script>
    <style type="text/css">
        .modalBackground {
            background-color: #4e5e6a;
            border-color: Blue;
            border: 1px;
            filter: alpha(opacity=70);
            opacity: 0.4;
            z-index: 10000;
        }
    </style>

    <script type="text/javascript" language="javascript">
        var win = new Object();
        function PopupONE(intval) {
            win = window.open("listofMSMEDistrictwisedetails.aspx?DistrictID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
        }

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>


    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="grdDetails" />
        </Triggers>
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;<li class="active"><a href="#">
                        <asp:Label ID="lblHead1" runat="server" CssClass="LBLBLACK" Font-Bold="True"></asp:Label>
                    </a></li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    <asp:Label ID="lblHead2" runat="server" Text="MSME District Wise Closed Units Report" CssClass="LBLBLACK" Font-Bold="True" Width="499px"></asp:Label>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-5"></div>
                                    <div class="col-sm-7">
                                        <div class="DTTT_container">
                                            <asp:LinkButton ID="lnk_excel" runat="server" Enabled="true" OnClick="lnk_excel_Click" CssClass="DTTT_button DTTT_button_xls" TabIndex="0" aria-controls="example-4">
                                       <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" />                               
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnk_pdf" runat="server" Enabled="true" OnClick="lnk_pdf_Click" CssClass="DTTT_button DTTT_button_pdf" TabIndex="0" aria-controls="example-4">
                                     <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" />                                 
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnk_print" CssClass="DTTT_button DTTT_button_prin" TabIndex="0" aria-controls="example-4" ToolTip="View print view"
                                                OnClientClick="printGrid()" runat="server">
                                 <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" />
                                            </asp:LinkButton>

                                        </div>
                                    </div>
                                </div>
                                <div class="row" runat="server" visible="false">
                                    <div class="col-md-2 form-group"></div>
                                    <div class="col-md-3 form-group">
                                        <label class="control-label label-required">
                                            From Date:</label>
                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group"
                                            Width="125px"></asp:TextBox>
                                        <%-- <cc1:CalendarExtender ID="CalendarExtender2"  runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>--%>
                                    </div>
                                    <div class="col-md-3 form-group">
                                        <label class="control-label label-required">
                                            To Date:</label>
                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group"
                                            Width="125px"></asp:TextBox>
                                        <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                </cc1:CalendarExtender>--%>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label class="control-label label-required">
                                            .
                                        </label>
                                        <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px"
                                            Text="Generate Report" Width="140px" OnClick="btnGet_Click" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4 form-group"></div>
                                    <div class="col-sm-5 form-group">
                                        <asp:Label ID="lbl_datesdisplay" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row" id="headboxlabel">
                                    <div class="col-md-12 form-group" align="center">
                                        <h5><b>MSME Closed Units</b> &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; <b style="text-align: right;">
                                    </div>
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Visible="false">Report as on date</asp:Label>

                                </div>
                                <div class="row">
                                    <div class="col-sm-12 form-group" align="center">
                                        <asp:GridView ID="grdDetails" runat="server" OnRowDataBound="grdDetails_RowDataBound"
                                            AutoGenerateColumns="False" AllowPaging="false" OnRowCreated="grdDetails_RowCreated"
                                            CellPadding="4" Width="100%" ShowFooter="True" Style="width: 60%">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Center" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />

                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri; text-align: center">District</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("DistrictName") %>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterTemplate>
                                                        <b style="font-family: Calibri">Total</b>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">No of Closed Units Given by APPC</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplAPPCclosedunits" runat="server" ForeColor="Black" Text='<%#Eval("AppcClosedUnits") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblAPPCclosedunits" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">No of Closed Units Confirmed by GM</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplGMclosedunits" runat="server" Text='<%#Eval("GMUpdtdClosedUnits") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblGMclosedunits" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Phone Not Working</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplPhoneNotWorking" runat="server" Text='<%#Eval("PhoneNotWorking") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblPhoneNotWorking" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">No Demand</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplNoDemand" runat="server" Text='<%#Eval("NoDemand") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblNoDemand" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Competetion</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplCompetetion" runat="server" Text='<%#Eval("Competetion") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblCompetetion" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Covid</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplCovid" runat="server" Text='<%#Eval("Covid") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblCovid" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Dispute among Partners</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplDisputeamongPartners" runat="server" Text='<%#Eval("DisputeamongPartners") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblDisputeamongPartners" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Finance Problems</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplFinanceProblems" runat="server" Text='<%#Eval("FinanceProblems") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblFinanceProblems" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Labour Problems</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplLabourProblems" runat="server" Text='<%#Eval("LabourProblems") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblLabourProblems" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">ManagementProblems</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplManagementProblems" runat="server" Text='<%#Eval("ManagementProblems") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblManagementProblems" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Legal Dispute</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplLegalDispute" runat="server" Text='<%#Eval("LegalDispute") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblLegalDispute" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Not Established</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplNotEstablished" runat="server" Text='<%#Eval("NotEstablished") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblNotEstablished" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Other Activity</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplOtherActivity" runat="server" Text='<%#Eval("Competetion") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblOtherActivity" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Out Dated</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplOutDated" runat="server" Text='<%#Eval("OutDated") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblOutDated" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">PersonalReasons</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplPersonalReasons" runat="server" Text='<%#Eval("PersonalReasons") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblPersonalReasons" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Phone Not Working</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplPhoneNotWorking" runat="server" Text='<%#Eval("PhoneNotWorking") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblPhoneNotWorking" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Relocation</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplRelocation" runat="server" Text='<%#Eval("Relocation") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblRelocation" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Temporarily Closed</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplTemporarilyClosed" runat="server" Text='<%#Eval("TemporarilyClosed") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTemporarilyClosed" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Seasonally Closed</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplSeasonallyClosed" runat="server" Text='<%#Eval("SeasonallyClosed") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblSeasonallyClosed" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">SoldOut</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplSoldOut" runat="server" Text='<%#Eval("SoldOut") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblSoldOut" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">TechnicalProblem</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplTechnicalProblem" runat="server" Text='<%#Eval("TechnicalProblem") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTechnicalProblem" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">Other</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplOther" runat="server" Text='<%#Eval("Other") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblOther" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <b style="font-family: Calibri">DistrictId</b>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Eval("DistrictID") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <table>
                                <tr>
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

