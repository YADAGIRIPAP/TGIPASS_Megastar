<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOfflineCFOExp.aspx.cs" MasterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="UI_TSiPASS_AddOfflineCFOExp" %>

 
 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

  

<%--<script runat="server">

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <link href="../../src/jquery-customselect.css" rel="stylesheet" />
    <script src="../../src/jquery-customselect.js"></script>
        <script>
            $(function () {
                $("#ctl00_ContentPlaceHolder1_ddlintLineofActivity").customselect();
            });
            function pageLoad() {
                $("#ctl00_ContentPlaceHolder1_ddlintLineofActivity").customselect();
            }
      </script>  
 
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
    .style6
    {
        width: 192px;
    }
    .auto-style1 {
        width: 238px;
    }
    .auto-style2 {
        width: 37px;
    }
    .auto-style3 {
        width: 13px;
    }
    .auto-style4 {
        width: 488px;
    }
    .auto-style5 {
        width: 4px;
    }
    </style>

<script type="text/javascript" language="javascript">

    function OpenPopup() {

        window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

        return false;
    }
    </script>
   
 
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit">CAF</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Attachment Details</a>
                            
            
            </li>
        </ol>
 
    <asp:UpdatePanel ID="updPanel" runat="server">
          <ContentTemplate>
                <h3 class="panel-title">
                            Add previuos CFE UID - CFO</h3>
 
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" class="nav-justified">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                Unit name
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtUnitname" runat="server" class="form-control txtbox"
                                                    Height="28px"  TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                               Address
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 10px; text-align: left;">
                                                <asp:TextBox ID="txtAdddress" textmode="MultiLine" runat="server" class="form-control txtbox"
                                                    Height="70"  TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                Line of activity</td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                               <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="custom-select"
                                                Height="33px" AutoPostBack="True"  
                                                Width="300px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            </td>
                                          
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                District</td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True"   class="form-control txtbox" Height="33px"  Width="180px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                                    <asp:ListItem>--District--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" class="auto-style2">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                Mandal</td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlMandal" runat="server" CssClass="form-control txtbox" Height="33px"   Width="180px">
                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; " class="auto-style5">
                                                &nbsp;</td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2">
                                                6
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                Investment in Crores</td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtCrores" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; " class="auto-style5">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2">
                                                7
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                Employment</td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtEmployment" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; " class="auto-style5">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="uidTR" runat="server" visible="false"> 
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2">
                                                8
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                Your UID No</td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblUIDNo" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; " class="auto-style5">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                       
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top" align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;&nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                         TabIndex="10" Text="Submit" ValidationGroup="group" Width="90px" OnClick="BtnSave1_Click" />
                                    &nbsp;&nbsp;</td>
                            </tr>
                           
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            </table>
           

          </ContentTemplate>
                      
          
    </asp:UpdatePanel>


        <style type="text/css">
        .custom-select > div
        {
            width: 750px !important;
        }
        
        .custom-select > div > div
        {
            max-height: 500px !important;
        }
        
        .custom-select input
        {
            width: 400px !important;
        }
        
        .custom-select div ul li
        {
            border-bottom: 1px solid !important;
        }
    </style>
  
</asp:Content>
