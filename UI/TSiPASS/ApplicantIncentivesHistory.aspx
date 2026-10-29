<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="ApplicantIncentivesHistory.aspx.cs" Inherits="UI_TSiPASS_ApplicantIncentivesHistory" %>

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
        
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
        
        .GRD
        {
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 10px;
        }
        
        .GRDITEM
        {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/
            padding: 10px; /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }
        
        .GRDHEADER
        {
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url(../images/bg_blue_grd.gif);
            border-color: #ffffff;
            border-style: solid;
            border-width: 1px;
        }
        </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i></li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">VIEW DETAILS</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    VIEW DETAILS</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="checkClaim" runat="server" visible="false">
                                                <td align="center" class="style8" style="padding: 5px; color:red; margin: 5px; text-align: center;"
                                                    valign="top">
                                                   <b>INCENTIVE CLAIMS ARE NOT YET FILED!</b>
                                                </td>
                                            </tr>
                                             <tr id="trNotapplied" runat="server" visible="false">
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="mainGrid" runat="server">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        Height="62px" OnRowDataBound="grdDetails_RowDataBound" Width="100%" Font-Names="Verdana"
                                                        Font-Size="12px">
                                                        <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
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
                                                            <asp:BoundField DataField="ApplicationNo" ItemStyle-HorizontalAlign="Left" HeaderText="Application No" />
                                                            <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Left"
                                                                HeaderText="Applied Date" />
                                                            <asp:TemplateField HeaderText="ApplicationNo" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplicationNo" Text='<%#Eval("ApplicationNo") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ApplicationNo" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplicationFiledDate" Text='<%#Eval("ApplicationFiledDate") %>'
                                                                        runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View Application">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink" runat="server" Text="View" Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View Acknowledgement">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglinkAcknowledgement" runat="server" Text="Acknowledgement"
                                                                        Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="PendingQueries" ItemStyle-HorizontalAlign="Center" HeaderText="Pending Queries" />--%>
                                                            <asp:TemplateField HeaderText="Pending Queries">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPendingQueries" Text='<%#Eval("PendingQueries") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglinkPendingQueriesAtLevel" runat="server" Text='<%#Eval("QueryAt") %>'
                                                                        Width="150px" Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Respond to query" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglinkPendingQueries" runat="server" Text="Respond to query"
                                                                        Width="150px" Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglinkStatus" runat="server" Text="Track" Font-Bold="true"
                                                                        ForeColor="Green" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>   
                                                              <asp:TemplateField HeaderText="Latest Details" Visible="false" runat="server">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglinkLatest" runat="server" Text="Update Latest Details" Font-Bold="true"
                                                                        ForeColor="Green" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                               <asp:TemplateField HeaderText="intStageid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStageid" Text='<%#Eval("intStageid") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ApplicationStatus" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="ApplicationStatus" Text='<%#Eval("ApplicationStatus") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
 
                                                             </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="trApplyAgainNote" runat="server" visible="false">
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    &nbsp;<b>Note:</b> To Apply Again for another claim application, Please Click on
                                                    &#39;Apply Again&#39; and click on Next, Next..&nbsp;&nbsp; no need to fill common
                                                    form again. And in the incentives list shown page, please click on &#39;Apply Again&#39;
                                                    check box and continue as a fresh application in the final page you will get new application
                                                    number and new acknowledgement.
                                                </td>
                                            </tr>
                                                <tr id="trRejection" runat="server" visible="false">
                                                <td align="justify" style="padding: 5px; margin: 5px; color:red; font text-align: justify;" valign="top">
                                                   <b>Note : With reference to your application dtd: <asp:Label ID="lblApplnDate" runat="server" Text=""></asp:Label> 
                                                    &nbsp;for sanction of incentive type  <asp:Label ID="lblType" runat="server" Text=""></asp:Label> &nbsp; for period&nbsp; 
                                                    <asp:Label ID="lblPeriod" runat="server" Text=""></asp:Label> , a query has been raised for your application on dated 
                                                    <asp:Label ID="lblQueryDate" runat="server" Text="">
                                                          </asp:Label>  , Since you have failed to reply, your application is deemed to have been closed. You may file a fresh application with all the documents and information and the same will be examined as per the Guidelines, if it is within due date.</b>
                                                </td>
                                            </tr>

                                             <tr id="trRejectioinNotice" runat="server" visible="false">
                                                <td align="justify" style="padding: 5px; margin: 5px; color:red; font text-align: justify;" valign="top">
                                                   <b>Note : If you fail to furnish the information within 45 Days from the date of query raise, the application will be rejected. </b>
                                                </td>
                                            </tr>
                                            <tr align="center" id="trApplyAgainbtn" runat="server" visible="false">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                    &nbsp;
                                                    <asp:Button ID="btnApplyAgain" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        TabIndex="10" Text="Apply Again" Width="150px" OnClick="btnApplyAgain_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trprintack" runat="server" visible="false">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>

                                             <tr id="tr1" runat="server" visible="false">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    &nbsp;<b> There are no incentives applied </b> 
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
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
</asp:Content>
