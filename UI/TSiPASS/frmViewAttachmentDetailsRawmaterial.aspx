<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/Lookups/CCLookupsMaster.master" AutoEventWireup="true" CodeFile="frmViewAttachmentDetailsRawmaterial.aspx.cs" Inherits="TSTBDCReg1" %>

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
                                <i class="fa fa-fw fa-edit">Raw Materials</i> 
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
                                <h3 class="panel-title">View Raw material Attachment Details</h3>
                            </div>
                          <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="196px">Raw Material Attachment</asp:Label>
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
                                                        Attachmaent name</td>
                                                    <td class="style10" style="border: 1px solid #003366; font-weight: bold;">
                                                        Attachment Path</td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                                        1</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                        ExistingAllotmentOrder</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:HyperLink ID="HyperLink11" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                                        2</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                        ValidCFO</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:HyperLink ID="HyperLink12" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                                        3</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                        BoilerDetails</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:HyperLink ID="HyperLink13" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                                        4</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                        production</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:HyperLink ID="HyperLink20" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                                        5</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                        VAT</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:HyperLink ID="HyperLink21" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                                        6</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                        RG1Register</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:HyperLink ID="HyperLink22" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                                        7</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                                        Process Description FlowChart</td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:HyperLink ID="HyperLink23" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
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

