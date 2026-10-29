<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="~/UI/TSiPASS/COMMISSIONERWISEReport.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    
<style   type="text/css">
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
    .style8
    {
        color: #FF0000;
        font-weight: bold;
    }
    .GRD
{
	
	height:auto;
	border-color:#013161;
	border-style:solid;
	border-width:1px;
text-transform:capitalize;
	padding:10px;
}

.GRDITEM
	{
	/*background-color: WHITE;*/
	color:black;	
	font-size:	12px;
	font-weight: normal;
	font-family:Verdana;
	padding:10px;
	/*text-decoration:none;*/
	/*border-color:#013161;*/
	/*border-style:solid;*/
	text-transform:uppercase;
	/*border-width:1px;*/
	/*height:23px;*/
	/*text-indent:5px;*/
	padding:10px;
	
	/*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
	}
	
	.GRDHEADER	
{
	color:#0E2A46;
	vertical-align:middle;
	text-align:center;
	height:25px;
	width:50px;
	padding:10px;
	font-size:	12px;
	font-weight: bold;
	text-transform:capitalize;
	font-family: Verdana;	
	BACKGROUND-IMAGE: url(../images/bg_blue_grd.gif);
	border-color:#ffffff;
	border-style:solid;
	border-width:1px;
	}
    .style9
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
                                <i class="fa fa-fw fa-edit"></i><asp:Label ID="lblHeading2" runat="server"></asp:Label>
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#"></a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title"><asp:Label ID="lblHeading" runat="server"></asp:Label></h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <%--<tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" 
                                            class="style8" align="center">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" 
                                                class="form-control txtbox" Height="33px" 
                                                onselectedindexchanged="ddlProp_intDistrictid_SelectedIndexChanged" 
                                                Width="180px" Visible="False">
                                                <asp:ListItem>--District--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td align="center" class="style8" 
                                            style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" 
                                                NavigateUrl="~/UI/TSiPASS/HomeCommDashboard.aspx">Back</asp:HyperLink>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                            valign="top">
                                            <table class="style9">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="165px">Year</asp:Label>
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Month</asp:Label>
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">January</asp:ListItem>
                                                            <asp:ListItem Value="2">February</asp:ListItem>
                                                            <asp:ListItem Value="3">March</asp:ListItem>
                                                            <asp:ListItem Value="4">April</asp:ListItem>
                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                            <asp:ListItem Value="8">August</asp:ListItem>
                                                            <asp:ListItem Value="9">Sepetmber</asp:ListItem>
                                                            <asp:ListItem Value="10">October</asp:ListItem>
                                                            <asp:ListItem Value="11">November</asp:ListItem>
                                                            <asp:ListItem Value="12">December</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="165px">Name 
                                                        of IPO</asp:Label>
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlIPOname" runat="server" class="form-control txtbox" 
                                                            Height="33px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" 
                                                            TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="165px">Status</asp:Label>
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem >Pending</asp:ListItem>
                                                            <asp:ListItem >Rejected</asp:ListItem>
                                                            <asp:ListItem >Completed</asp:ListItem>
                                                           
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="7" style="text-align: center" valign="top">
                                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                            Height="32px" OnClick="BtnSave_Click" TabIndex="6" Text="Save" 
                                                            ValidationGroup="group" Width="90px" />
                                                        &nbsp;&nbsp;
                                                        <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" 
                                                            CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" 
                                                            OnClientClick="return confirm('Do you want to delete the record ? ');" 
                                                            TabIndex="7" Text="Cancel" Width="90px" />
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;" 
                                            valign="top">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" 
                                                BorderColor="Black" CellPadding="5" CssClass="GRD" ForeColor="#333333" 
                                                Height="62px" onrowcreated="grdDetails_RowCreated" 
                                                onrowdatabound="grdDetails_RowDataBound" 
                                                onselectedindexchanged="grdDetails_SelectedIndexChanged" PageSize="15" 
                                                ShowFooter="True" Width="100%">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                      <asp:BoundField DataField="DICName" HeaderText="DIC Name" />
                                                    <asp:BoundField DataField="Dept_Name" HeaderText="IPO Name" />
                                                    
                                                    <asp:BoundField DataField="VI_Year" HeaderText="Year" />
                                                    <asp:BoundField DataField="MonthName" HeaderText="Month" />
                                                    <asp:HyperLinkField DataTextField="BankReportTarget" 
                                                        HeaderText="Target" />
                                                    <asp:HyperLinkField DataTextField="BankReportPending" HeaderText="Pending" />
                                                    <asp:HyperLinkField DataTextField="BankReportCompleted" 
                                                        HeaderText="Completed" />
                                                        <asp:HyperLinkField DataTextField="BankVisitTarget" 
                                                        HeaderText="Target" />
                                                    <asp:HyperLinkField DataTextField="BankVisitPending" HeaderText="Pending" />
                                                    <asp:HyperLinkField DataTextField="BankVisitCompleted" 
                                                        HeaderText="Completed" />
                                                        <asp:HyperLinkField DataTextField="VehicleInspectionTarget" 
                                                        HeaderText="Target" />
                                                    <asp:HyperLinkField DataTextField="VehicleInspectionPending" HeaderText="Pending" />
                                                    <asp:HyperLinkField DataTextField="VehicleInspectionCompleted" 
                                                        HeaderText="Completed" />
                                                        <asp:HyperLinkField DataTextField="TSiPASSTarget" 
                                                        HeaderText="Target" />
                                                    <asp:HyperLinkField DataTextField="TSiPASSPending" HeaderText="Pending" />
                                                    <asp:HyperLinkField DataTextField="TSiPASSCompleted" 
                                                        HeaderText="Completed" />
                                                        <asp:HyperLinkField DataTextField="ClosedUnitTarget" 
                                                        HeaderText="Target" />
                                                    <asp:HyperLinkField DataTextField="ClosedUnitPending" HeaderText="Pending" />
                                                    <asp:HyperLinkField DataTextField="ClosedUnitCompleted" 
                                                        HeaderText="Completed" />
                                                        
                                                        <asp:HyperLinkField DataTextField="PMEGPTarget" 
                                                        HeaderText="Target" />
                                                    <asp:HyperLinkField DataTextField="PMEGPPending" HeaderText="Pending" />
                                                    <asp:HyperLinkField DataTextField="PMEGPCompleted" 
                                                        HeaderText="Completed" />
                                                        
                                                        <asp:HyperLinkField DataTextField="AdvanceSubsidyTarget" 
                                                        HeaderText="Target" />
                                                    <asp:HyperLinkField DataTextField="AdvanceSubsidyPending" HeaderText="Pending" />
                                                    <asp:HyperLinkField DataTextField="AdvanceSubsidyCompleted" 
                                                        HeaderText="Completed" />
                                                        
                                                        
                                                         <asp:HyperLinkField DataTextField="IndustryCatelogTarget" 
                                                        HeaderText="Target" />
                                                    <asp:HyperLinkField DataTextField="IndustryCatelogPending" HeaderText="Pending" />
                                                    <asp:HyperLinkField DataTextField="IndustryCatelogCompleted" 
                                                        HeaderText="Completed" />
                                                          <asp:HyperLinkField DataTextField="IndustryCatelogCompleted" 
                                                        HeaderText="Status" />
                                                                                                  
                                                        
                                                                                                    </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" HorizontalAlign="Center" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            
                                            
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label> 
  </div>
                                            
                                            
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> 
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
  </div>
                                            </td>
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

