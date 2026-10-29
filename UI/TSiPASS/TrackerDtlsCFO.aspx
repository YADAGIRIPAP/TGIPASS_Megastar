<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="TrackerDtlsCFO.aspx.cs" Inherits="UI_TSiPASS_TrackerDtlsCFO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- PAGE LEVEL STYLES -->
    <link href="assets/css/bootstrap-fileupload.min.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Admin Page</a> </li>
        </ol>
    </div>
    <div id="success" runat="server" visible="false" class="alert alert-success">
        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
    </div>
    <div class="row">
        <div class="col-md-6" style="width: 90%">
            <div class="panel panel-default" id="trquerydtls" runat="server" visible="false">
                <div class="panel-heading">
                    Query Details
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 200px; padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">1). Department Name 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tddeptname" runat="server" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; width: 30px"></td>
                                <td style="width: 180px; padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">2). Query Raised Date 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdqdate" runat="server" align="left" valign="top"></td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">3). Query  
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdremarks" runat="server" colspan="5" align="left" valign="top"></td>
                            </tr>
                            <tr id="trresponce1" runat="server">
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">4). Query Response Date </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td id="tdResponseDate" runat="server" style="padding: 5px; margin: 5px" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; width: 30px"></td>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">5). No of Days taken</td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdnotakes" runat="server" align="left" valign="top"></td>
                            </tr>
                            <tr id="trresponce2" runat="server">
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">6). Query Response 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdresonce" runat="server" colspan="5" align="left" valign="top"></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="panel panel-default" id="trrejcted" runat="server" visible="false">
                <div class="panel-heading">
                    Rejected Details
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 200px; padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">1). Department Name 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tddeptnamenew" runat="server" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; width: 30px"></td>
                                <td style="width: 180px; padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">2). Rejectded Date 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdrejcteddate" runat="server" align="left" valign="top"></td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">3). Remarks  
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdremarksrejected" runat="server" colspan="5" align="left" valign="top"></td>
                            </tr>
                           <tr id="hmdaattachements" runat="server" visible="false">
                                <td style="padding: 10px; margin: 5px;" colspan="8">
                                    <asp:GridView ID="gvlastattachments" runat="server" AutoGenerateColumns="False"
                                        Width="40%" HorizontalAlign="Left" ShowHeader="true">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rejected Documents">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("Pathdoc")%>' Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="panel panel-default" id="trPayment" runat="server" visible="false">
                <div class="panel-heading">
                    Payment Details
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 180px; padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">
                                    <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="true" cellpadding="4"
                                        cssclass="GRD" forecolor="#333333" height="62px" onrowdatabound="grdDetails_RowDataBound"
                                        pagesize="15" showfooter="True" width="100%" cellspacing="4">
                                                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                          
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:gridview>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

              <div class="panel panel-default" id="Divappsinfo" runat="server" visible="false">
                <div class="panel-heading">
                    Approval Application Details
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 300px; padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">1). Department Name 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tddeptnameapp" runat="server" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; width: 30px"></td>
                                <td style="width: 180px; padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">2). Approval Applied Date 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdApprovalAppliedDate" runat="server" align="left" valign="top"></td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">3). Target Pre-scrutiny date  
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdtpscdate" runat="server" colspan="5" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">4). Pre-scrutiny date  
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdpscdate" runat="server" colspan="5" align="left" valign="top"></td>
                            </tr>
                           <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">5). No. of days taken for Pre-scrutiny  
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tddaystakenpsc" runat="server" colspan="5" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">6). Pre-scrutiny days  
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="td2" runat="server"  colspan="5" align="left" valign="top" >3</td>
                            </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">7). Date Received to Approval Stage   
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdReceivedApproval" runat="server" colspan="5" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">8). Target Date to Send MAUD 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdSendMAUDTarget" runat="server"  colspan="5" align="left" valign="top" ></td>
                            </tr>
                            
                            <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">9). Date of Sent to MAUD  
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdDateofSenttoMAUD" runat="server" colspan="5" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">10). No. of Days Taken (Sent to MAUD) 
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdDaysTaken" runat="server"  colspan="5" align="left" valign="top" ></td>
                            </tr>
                            <tr runat="server" id="trmauddata1" visible="false">
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top" colspan="4">
                                  -->  Maud Info
                                </td>
                            </tr>
                            <tr runat="server" id="trmauddata" visible="false">
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">11). Target Date for Approval(15 days from Received Date)  
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdTargetDateforApprovalmaud" runat="server" colspan="5" align="left" valign="top"></td>
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">12). Actual Approval Date
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdActualApprovaldate" runat="server"  colspan="5" align="left" valign="top" ></td>
                            </tr>
                            <tr runat="server" id="trmauddata2" visible="false">
                                <td style="padding: 5px; margin: 5px; font-weight: bold" align="left" valign="top">13). No. of Days Taken for Approval
                                </td>
                                <td style="width: 3px; padding: 5px; margin: 5px" align="left" valign="top">: </td>
                                <td style="padding: 5px; margin: 5px" id="tdDaysTakenforApproval" runat="server"  colspan="5" align="left" valign="top" ></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.js"></script>
    <!-- PAGE LEVEL SCRIPTS -->
    <script src="assets/js/bootstrap-fileupload.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>
</asp:Content>

