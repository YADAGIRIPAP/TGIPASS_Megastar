<%@ Page Title=":: TS-iPASS ::  DashBoard " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true" CodeFile="frmDashboard.aspx.cs" Inherits="TSTBDCReg1" %>

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
                                <i class="fa fa-edit"></i> <a href="#">DashBoard</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">DashBoard - TS-iPASS</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table cellpadding="0" cellspacing="0" 
                                style=" width: 100%">
                                <tr>
                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                        <table style="width: 95%" cellpadding="0" cellspacing="0" >
                                            <tr>
                                                <td align="left" 
                                                    
                                                    
                                                    style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                    vertical-align: top; padding-top: 5px; text-align: left; " 
                                                    valign="top">
                                                    <table cellpadding="2" cellspacing="2" style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblstate10" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                                    ForeColor="Black" Text="Details of Applications" Width="200px" 
                                                                    Font-Size="14px"></asp:Label>
                                                            </td>
                                                            <td valign="top" rowspan="2" 
                                                                style="padding: 2px; width: 25px; ">
                                                                <asp:Label ID="lblstate12" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                    Width="25px"></asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:Label ID="lblstate11" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                                    ForeColor="Black" Text="Pre-scrutiny Details" Width="200px" 
                                                                    Font-Size="14px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <table cellpadding="8" cellspacing="1" 
                                                                    
                                                                    
                                                                    style="margin: 10px; padding: 10px; border-style: 1; border-width: 1px; border-color: #000080; width: 100%; font-family: Verdana;">
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            1</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:Label ID="lblstate8" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                                Text="No of Units that have applied" Width="220px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptDashBoardDistVoCount.aspx" Width="80px">5</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            2</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:Label ID="lblmandalname7" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Enterprise Type" Width="220px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks3" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptPanchayatswiseVoNew.aspx?id=%&amp;d=%&amp;id1=%&amp;id2=%" 
                                                                                Width="80px">Micro - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks31" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptPanchayatswiseVoNew.aspx?id=%&amp;d=%&amp;id1=%&amp;id2=%" 
                                                                                Width="80px">Small - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks32" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptPanchayatswiseVoNew.aspx?id=%&amp;d=%&amp;id1=%&amp;id2=%" 
                                                                                Width="80px">Medium - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks33" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptPanchayatswiseVoNew.aspx?id=%&amp;d=%&amp;id1=%&amp;id2=%" 
                                                                                Width="80px">Large - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks34" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptPanchayatswiseVoNew.aspx?id=%&amp;d=%&amp;id1=%&amp;id2=%" 
                                                                                Width="80px">Mega - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            3</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:Label ID="lblmandalname" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Pollution Category" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks1" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptVillagewiseVoDrildownSearch.aspx?id=%&amp;d=%" Width="80px">Red -2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks35" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptVillagewiseVoDrildownSearch.aspx?id=%&amp;d=%" Width="80px">Green -2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks36" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptVillagewiseVoDrildownSearch.aspx?id=%&amp;d=%" Width="80px">Orange -1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            4</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" 
                                                                                Text="No of departments applied for " Width="200px" Height="40px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks0" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptNOofSHGSearch.aspx?Type=D&amp;id=%&amp;id1=%&amp;id2=%" 
                                                                                Width="80px">2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            5</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:Label ID="Label59" runat="server" CssClass="LBLBLACK" 
                                                                                Text="No of Appovals for which payment made" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks11" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSearchMemberDrilDownSearch.aspx" Width="80px">1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            6</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:Label ID="Label65" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Appovals Issued" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks12" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">Before Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks37" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">After Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks38" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="120px">Total - 2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            7</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Approvals Under Process" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">Before Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">After Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 3px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="120px">Total - 2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 50%" valign="top">
                                                                <table cellpadding="8" cellspacing="1" 
                                                                    
                                                                    style="margin: 10px; padding: 10px; border-style: 1; border-width: 1px; border-color: #000080; width: 100%; font-family: Verdana;">
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            1</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            <asp:Label ID="lblstate9" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                                Text="Approvals to be Pre-Scruitinise" Width="220px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks39" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptDashBoardDistVoCount.aspx" Width="80px">5</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            2</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Pre-Scrutiny Completed" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink7" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">Before Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink8" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">After Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink9" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="120px">Total - 2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            3</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            <asp:Label ID="Label71" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Awaiting response for Query raised in Pre-Scruitiny" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks54" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptDashBoardDistVoCount.aspx" Width="80px">1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            4</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            <asp:Label ID="Label70" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Pre-Scrutiny Under Process" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink10" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">Before Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink11" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">After Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink12" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="120px">Total - 2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            5</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            <asp:Label ID="lblmandalname8" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Pre-Scruitiny Completed and Payment Made" Width="220px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks40" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptPanchayatswiseVoNew.aspx?id=%&amp;d=%&amp;id1=%&amp;id2=%" 
                                                                                Width="80px">1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            6</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            <asp:Label ID="Label68" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Appovals Issued" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks50" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">Before Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks51" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">After Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks52" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="120px">Total - 2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            7</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            <asp:Label ID="Label69" runat="server" CssClass="LBLBLACK" 
                                                                                Text="Approvals Under Process" Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">Before Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="140px">After Due Date  - 1</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #E1F1F4">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            &nbsp;</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HyperLink6" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptSHGsBankAccountNotOpenedDrldwn.aspx?id=%" Width="120px">Total - 2</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #99CCFF">
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            8</td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF;">
                                                                            <asp:Label ID="Label72" runat="server" CssClass="LBLBLACK" Text="Rejected" 
                                                                                Width="200px"></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 2px; border: 1px solid #FFFFFF">
                                                                            <asp:HyperLink ID="HypUmeedBlocks53" runat="server" Font-Bold="True" 
                                                                                Font-Names="Verdana" Font-Size="12px" ForeColor="#0066CC" 
                                                                                NavigateUrl="~/RptPanchayatswiseVoNew.aspx?id=%&amp;d=%&amp;id1=%&amp;id2=%" 
                                                                                Width="80px">0</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px 5px 5px 5px; margin: 10px 5px 5px 5px; vertical-align: top; width: 50%; text-align: center">
                                        &nbsp;</td>
                                </tr>
                            </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
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
<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
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

