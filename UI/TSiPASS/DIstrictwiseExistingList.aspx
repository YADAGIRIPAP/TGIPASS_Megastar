<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="DIstrictwiseExistingList.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


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
background-color:Gray;
filter: alpha(opacity=60);
opacity: 0.9;
-moz-opacity: 0.9;
}
    .style5
    {
        width: 100%;
    }
    </style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

    window.open("Lookups/LookupBDC.aspx","List","scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit"></i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">District Level Report</a>
                            
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    District Level Report</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 98%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table class="style5">
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <table class="style5" cellpadding="7" cellspacing="7">
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">District</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                                                Height="33px" TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>Adilabad</asp:ListItem>
                                                                                <asp:ListItem>Hyderabad</asp:ListItem>
                                                                                <asp:ListItem>karimnagar</asp:ListItem>
                                                                                <asp:ListItem>Rangareddy-1</asp:ListItem>
                                                                                <asp:ListItem>Mahabubnagar</asp:ListItem>
                                                                                <asp:ListItem>Rangareddy-2</asp:ListItem>
                                                                                <asp:ListItem>Mahbubnagar</asp:ListItem>
                                                                                <asp:ListItem>Medak</asp:ListItem>
                                                                                <asp:ListItem>Warangal</asp:ListItem>
                                                                                <asp:ListItem>Khammam</asp:ListItem>
                                                                                <asp:ListItem>Nizamabad</asp:ListItem>
                                                                                <asp:ListItem>Nalgonda</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="200px">Caste</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlConnectLoad1" runat="server" class="form-control txtbox"
                                                                                Height="33px" TabIndex="1" Width="180px" AutoPostBack="True" 
                                                                                onselectedindexchanged="ddlConnectLoad1_SelectedIndexChanged">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>General</asp:ListItem>
                                                                                <asp:ListItem>OBC</asp:ListItem>
                                                                                <asp:ListItem>ST</asp:ListItem>
                                                                                <asp:ListItem>SC</asp:ListItem>
                                                                                <asp:ListItem>Minority</asp:ListItem>
                                                                                <asp:ListItem>Others</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label454" runat="server" CssClass="LBLBLACK" Width="200px">Current status of the unit</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCurrentStatus" runat="server" class="form-control txtbox"
                                                                                Height="33px" TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>Commenced Production</asp:ListItem>
                                                                                <asp:ListItem>Under Construction</asp:ListItem>
                                                                                <asp:ListItem>Yet to start Construction</asp:ListItem>
                                                                                <asp:ListItem>Dropped</asp:ListItem>
                                                                                <%--<asp:ListItem>Rejected</asp:ListItem>
                                                                                <asp:ListItem>Not started</asp:ListItem>
                                                                                <asp:ListItem>Initial Stage</asp:ListItem>
                                                                                <asp:ListItem>Unit Started </asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label456" runat="server" CssClass="LBLBLACK" Width="200px">Women entrepreneur</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlWomen" runat="server" class="form-control txtbox" Height="33px"
                                                                                TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table class="style5" cellpadding="7" cellspacing="7">
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px">Category</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                                                                TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>micro</asp:ListItem>
                                                                                <asp:ListItem>Small</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label453" runat="server" CssClass="LBLBLACK" Width="200px">PCB categorization of enterprise</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlPCB" runat="server" class="form-control txtbox" Height="33px"
                                                                                TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>GREEN</asp:ListItem>
                                                                                <asp:ListItem>Orange</asp:ListItem>
                                                                                <asp:ListItem>Red</asp:ListItem>
                                                                                <asp:ListItem>NONE</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label455" runat="server" CssClass="LBLBLACK" Width="200px">Differently abled</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddldiffable" runat="server" class="form-control txtbox" Height="33px"
                                                                                TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="minry" runat="server" visible="false">
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label457" runat="server" CssClass="LBLBLACK" Width="200px">Minority</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddltyofmuslim" runat="server" class="form-control txtbox" Height="33px"
                                                                                TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td align="right" style="text-align: right">
                                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                    OnClick="Bthsave4_Click" TabIndex="10" Text="Search" Width="90px" />
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                                                    Width="90px" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="right" style="text-align: right">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblstate11" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Size="14px"
                                                                    ForeColor="Black" Width="200px"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Style="width: 1200px"
                                                        Height="600px">
                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                                            ShowFooter="True" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                                            OnRowCreated="grdDetails_RowCreated" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged"
                                                            PageSize="40" AllowPaging="True">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" CssClass="GRDITEM" />
                                                            <Columns>
                                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                                <asp:BoundField DataField="Name of the unit" HeaderText="Name of the unit" />
                                                                <asp:BoundField DataField="Location of the unit" HeaderText="Location of the unit" />
                                                                <asp:BoundField DataField="Investment in Rs#lakhs" HeaderText="Investment in Rs#lakhs" />
                                                                <asp:BoundField DataField="Employment" HeaderText="Employment" />
                                                                <asp:BoundField DataField="Line of activity" HeaderText="[Line of activity]" />
                                                                <asp:BoundField DataField="E-mail and contact details" HeaderText="E-mail and contact details" />
                                                                <asp:BoundField DataField="Category of enterprise(Micro Small)" HeaderText="[Category of enterprise(Micro Small)]" />
                                                                <asp:BoundField DataField="PCB categorisation of enterprise(Red Orange Green)" HeaderText=" [PCB categorisation of enterprise(Red Orange Green)]" />
                                                                <asp:BoundField HeaderText="[No of Approvals]" />
                                                                <asp:TemplateField HeaderText="Approval Details">
                                                                    <ItemTemplate>
                                                                        <asp:GridView ID="grdDetailsnew" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                            CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="40"
                                                                            ShowFooter="True" Width="100%">
                                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Approvals sought for" HeaderText="[Approvals sought for]" />
                                                                                <asp:BoundField DataField="Date of filing the application under TS-Ipass)" HeaderText="[Date of filing the application under TS-Ipass)]" />
                                                                                <asp:BoundField DataField="Date of pre-scrutiny" HeaderText="[Date of pre-scrutiny]" />
                                                                                <asp:BoundField DataField="Date of forwarding to concerned department" HeaderText="[Date of forwarding to concerned department]" />
                                                                                <asp:BoundField DataField="Date within which approval is to be issued as per the TS-IPASS a"
                                                                                    HeaderText="[Date within which approval is to be issued as per the TS-IPASS a]" />
                                                                                <asp:BoundField DataField="Status of application  (Cleared Returned Rejected Pending Additi"
                                                                                    HeaderText="[Status of application  (Cleared Returned Rejected Pending Additi]" />
                                                                                <asp:BoundField DataField="Current status of the unit (1#Commenced Production 2#Under Const"
                                                                                    HeaderText="[Current status of the unit (1#Commenced Production 2#Under Const]" />
                                                                                <asp:BoundField DataField="Caste" HeaderText="Caste" />
                                                                                <asp:BoundField DataField="Whether Differently abled or not?(Indicate YES NO)" HeaderText="[Whether Differently abled or not?(Indicate YES NO)]" />
                                                                                <asp:BoundField DataField="Whether women entrepreneurIndicate YES NO" HeaderText="[Whether women entrepreneurIndicate YES NO]" />
                                                                                <asp:BoundField DataField="If entrepreneur belongs to Minority indicate religion"
                                                                                    HeaderText="[If entrepreneur belongs to Minority indicate religion]" />
                                                                            </Columns>
                                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                            <EditRowStyle BackColor="#B9D684" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                        <asp:HiddenField ID="hdfFlagIDnew" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" CssClass="GRDHEADER" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    &nbsp;<tr>
                                                        <td align="center" style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
