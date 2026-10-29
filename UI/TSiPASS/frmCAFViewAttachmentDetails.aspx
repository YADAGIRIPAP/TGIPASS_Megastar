<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/Lookups/CCLookupsMaster.master" AutoEventWireup="true" CodeFile="frmCAFViewAttachmentDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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
    .style7
    {
        color: #FF3300;
    }
    .style9
    {
        width: 27px;
    }
    .style10
    {
        width: 341px;
    }
    .style11
    {
        width: 40px;
    }
</style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

    window.open("Lookups/LookupBDC.aspx","List","scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>
    <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
   <%-- </div>
       </td>
        </tr>
    </table>--%>
<div align="left">
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
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">View Attachment Details</h3>
                            </div>
                          <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="210px">Compulsary Attachments<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                            <table cellpadding="5px" cellspacing="5px" 
                                               width="100%" style="font-size: 14px; font-family: Verdana;">
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366; font-weight: 700;">
                                                        S.No</td>
                                                    <td class="style10" style="border: 1px solid #003366; font-weight: 700;">
                                                        Attachment Type</td>
                                                    <td style="border: 1px solid #003366; font-weight: 700;">
                                                        Attachment Path</td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        1</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" 
                                                            Width="210px">B1 Form</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        2</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" 
                                                            Width="210px">B2 Form</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        3</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" 
                                                            Width="165px">Hazardous Form</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        4</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" 
                                                            Width="250px">Compliance Report</asp:Label>
                                                    </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        5</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" 
                                                            Width="250px">Fire Occupancy Certificate</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink5" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        6</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" 
                                                            Width="410px">Boiler Registration</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink6" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        7</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" 
                                                            Width="210px">Drugs License</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink7" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        8</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" 
                                                            Width="200px">Electrical Drawing Approvals</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink8" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        9</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" 
                                                            Width="165px">Partnership deed</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink16" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        10</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" 
                                                            Width="165px">List Of Directors</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink17" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        11</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" 
                                                            Width="165px">PAN/AADHAR Card</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink18" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style11" style="border: 1px solid #003366">
                                                        12</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                                <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" 
                                                            Width="165px">Land OwnerShip Deed</asp:Label>
                                                            </td>
                                                    <td style="border: 1px solid #003366">
                                                        <asp:HyperLink ID="HyperLink19" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="196px">Demand Draft Attachments</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                            <table cellpadding="5px" cellspacing="5px" 
                                                width="100%" style="font-size: 14px; font-family: verdana;">
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366; font-weight: bold;">
                                                        S.No</td>
                                                    <td class="style10" style="border: 1px solid #003366; font-weight: bold;">
                                                        Attachment Path</td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                            <asp:Panel ID="Panel2" runat="server">
                                                        
                                                    </asp:Panel>
                                                    </td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:Panel ID="Panel1" runat="server">
                                                        
                                                    </asp:Panel>
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center" class="style7">
                                            &nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Save" 
                                                ValidationGroup="group" Width="90px" Visible="False" />
                                            &nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-danger" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                                Text="Next" Width="90px" 
                                                OnClientClick="return confirm('Do you want to Next the record ? ');" 
                                                Visible="False" />
                                            <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            &nbsp;</td>
                                    </tr> 
                                            <caption>
                                                &nbsp;</caption>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;&nbsp;&nbsp;</td>
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
                                <asp:HiddenField ID="hdfFlagID0" runat="server" />
                            </div>
                      <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>

    </div>
         <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
<%--<div class="overlay">--%>
<%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>  
<%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%>
<%--<img alt="" src="../../Resource/Images/Processing.gif" />
--%>
</div>
    
</div>
<%--</ProgressTemplate>
</asp:UpdateProgress> --%>
                 
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
          
                       
  <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
<%-- </div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

