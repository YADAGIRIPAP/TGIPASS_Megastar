<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmQurieResponseStatusCFO.aspx.cs" Inherits="TSTBDCReg1" %>

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
                                <i class="fa fa-edit"></i> <a href="#">R1: VIEW DETAILS</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Query Raise and Response Details</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" 
                                            class="style8" align="center">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" 
                                                class="form-control txtbox" Height="33px" 
                                                onselectedindexchanged="ddlProp_intDistrictid_SelectedIndexChanged" 
                                                Width="180px" Visible="False">
                                                <asp:ListItem>--District--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style8" 
                                            style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <%--<asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="150px">Approval 
                                            By Status</asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                            valign="top">
                                            <asp:GridView ID="grdDetails" runat="server" 
                                                AutoGenerateColumns="False" CellPadding="5" CssClass="GRD" ForeColor="#333333" 
                                                Height="62px" PageSize="15" 
                                                ShowFooter="True" Width="100%" onrowdatabound="grdDetails_RowDataBound" 
                                                BorderColor="Black">
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
                                                   
                                                    <asp:BoundField  HeaderText="Constitution of the unit" />
                                                    <asp:BoundField DataField="Sector_EntA" HeaderText="Sector of Enterprise" />
                                                    <asp:BoundField  HeaderText="Total Extent of Land" />
                                                    <asp:BoundField DataField="Ent_is" HeaderText="Enterprise Type" />
                                                    <asp:BoundField DataField="Val_Land" HeaderText="Land Value" />
                                                    <asp:BoundField DataField="Val_Build" HeaderText="Building Value" />
                                                    <asp:BoundField DataField="Val_Plant" HeaderText="Plant Value" />
                                                    <asp:BoundField DataField="Tot_PrjCost" HeaderText="Total" />
                                                    <%--<asp:BoundField DataField="Dept_Full_name" HeaderText="Department Full Name" />
                                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name" />
                                                    <asp:BoundField DataField="UID_No" HeaderText="UID" />--%>
                                                    <asp:BoundField DataField="PLoutionCategorys" HeaderText="Pollution Category" />
                                                    <asp:BoundField DataField="NameofthePromoter" HeaderText="Name of the Promoter" />
                                                    <asp:BoundField DataField="QueryRaiseDate" HeaderText="Query Raise Date"  DataFormatString="{0:MM/dd/yyyy}" />
                                                    <asp:BoundField DataField="QueryDescription" HeaderText="Query Description"  />
                                                    <asp:BoundField DataField="QueryRespondDate" HeaderText="Query Respond Date"  DataFormatString="{0:MM/dd/yyyy}" />
                                                    <asp:BoundField DataField="QueryRespondRemarks" HeaderText="Query Respond Remarks" />
                                                    <asp:BoundField DataField="nameofunit" HeaderText="Name of unit" />
                                                    <%--<asp:BoundField DataField="QueryAttachmentFileName" HeaderText="Query Attachment FileName" />
                                                    <asp:BoundField DataField="QueryAttachmentFilePath" HeaderText="Query Attachment FilePath" />--%>
                                                    <asp:HyperLinkField HeaderText="Attachment" Text="Attachment" />
                                                   <%--<asp:BoundField DataField="LastDateofPreScrutiy" HeaderText="Last Date of PreScrutiy" />--%>
                                                   <%-- <asp:BoundField DataField="intDepartmentApprovalid" HeaderText="Department Approval ID" />--%>
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;" 
                                            valign="top">
                                            &nbsp;</td>
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

