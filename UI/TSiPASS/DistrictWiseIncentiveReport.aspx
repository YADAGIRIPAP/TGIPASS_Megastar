<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true" CodeFile="DistrictWiseIncentiveReport.aspx.cs" Inherits="TSTBDCReg1" %>

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
.algnCenter
        {
            text-align: center;
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

    function pageLoad() {
        $('#<%=grdDetails.ClientID%>').gridviewScroll({
            width: 1090,
            height: "100%",
            arrowsize: 30,
            varrowtopimg: "../../images/arrowvt.png",
            varrowbottomimg: "../../images/arrowvb.png",
            harrowleftimg: "../../images/arrowhl.png",
            harrowrightimg: "../../images/arrowhr.png"
        });
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
                                <i class="fa fa-fw fa-edit">Incentive</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">District Wise Details</a>
                            
                    
                    
                    
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    District Wise Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px CssClass="GRD" ForeColor="#333333" Height="62px"; margin: 5px;" align="center">
                                                                <asp:GridView ID="grdDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    CellPadding="4" OnRowDataBound="grdDetails_RowDataBound" PageSize="40" Width="100%"
                                                                    ShowFooter="True" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged">
                                                                    <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="DistrctName" HeaderText="Distrct Name" />
                                                                        <asp:HyperLinkField DataTextField="No of Applications Received" HeaderText="No of Applications Received" />
                                                                        <asp:HyperLinkField DataTextField="Inspection - Yet Assigned to Inspecting Officer"
                                                                            HeaderText="Inspection-Yet Assigned to Inspecting Officer" />
                                                                        <asp:HyperLinkField DataTextField="Inspection - Assigned to Inspecting Officer" HeaderText="Inspection-Assigned to Inspecting Officer" />
                                                                        <asp:HyperLinkField DataTextField="Inspection - Yet Assigned to Inspecting Officer Repeative"
                                                                            HeaderText="Inspection - Repetitive Applications" />
                                                                        <asp:HyperLinkField DataTextField="Inspection - Inspection Scheduled" HeaderText="Inspection-Inspection Scheduled" />
                                                                        <asp:HyperLinkField DataTextField="Inspection - Inspection Report Uploaded 48 Hrs"
                                                                            HeaderText="Inspection-Inspection Report Uploaded 48 Hrs" />
                                                                        <asp:HyperLinkField DataTextField="Inspection - Inspection Report Uploaded Beyond"
                                                                            HeaderText="Inspection-Inspection Report Uploaded Beyond" />
                                                                        <asp:HyperLinkField DataTextField="Inspection - Inspection Report not Uploaded 48 Hrs"
                                                                            HeaderText="Inspection-Inspection Report not Uploaded 48 Hrs" />
                                                                        <asp:HyperLinkField DataTextField="Inspection - Inspection Report  not Uploaded Beyond"
                                                                            HeaderText="Inspection-Inspection Report  not Uploaded Beyond" />
                                                                        <asp:HyperLinkField DataTextField="GM certificate uploaded" HeaderText="GM certificate uploaded" />
                                                                        <asp:HyperLinkField DataTextField="Recommanded to DIPC" HeaderText="Recommanded to DIPC" />
                                                                        <asp:HyperLinkField DataTextField="Recommanded to COI" HeaderText="Recommanded to COI" />
                                                                        <asp:HyperLinkField DataTextField="Sanctioned Incentives" HeaderText="Sanctioned Incentives" />
                                                                        <asp:HyperLinkField DataTextField="Rejected" HeaderText="Rejected" />
                                                                        <asp:HyperLinkField DataTextField="GMRejected" HeaderText="GMRejected" />
                                                                        <asp:HyperLinkField DataTextField="TotalAssigned" HeaderText="Total Assigned" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <tr>
                                                                    <td align="center" style="padding: 5px; margin: 5px">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <caption>
                                                                    &nbsp;</caption>
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
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
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
