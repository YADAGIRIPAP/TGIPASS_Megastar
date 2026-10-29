<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="LTHTGSTDATAPROCESSING.aspx.cs" Inherits="UI_TSiPASS_LTHTGSTDATAPROCESSING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>

            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="index.html">ADMIN</a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-table"></i>
                    </li>

                </ol>
            </div>
            <%--<div class="alert alert-warning fade in" id="warning" runat="server" visible="false">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> <asp:Label ID="lbluserid0" runat="server" 
        CssClass="" ></asp:Label>
    &nbsp;
  </div>--%>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title"></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr id="trextension" runat="server" visible="false">
                                        <td style="text-align: left; color: Red; height: 25px;" class="style3">
                                            <%--<a href="Library/Covid-19 Extension of Incentives Apply.pdf" target="_blank" class="list-group-item">  <img src="Images\newimg.gif"></a>--%>
                                            <b>
                                                <asp:HyperLink CssClass="blink" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSIPASS/DisplayDocs/Covid-19 Incentives Time Extension.pdf"
                                                     Target="_blank"> <%--<img alt="" width="40px" height="20px" src="../../images/animated-hand-image-0117.gif" />--%>
                                                </asp:HyperLink>
                                            </b>
                                        </td>
                                    </tr>
                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                   
                                    
                                    
                                    
                                    <tr id="TRISMSMEUNIT" runat="server" visible="true">
                                      <td align="center" valign="middle"  >

                                            IS UNIT ENTERED IN MSME CATELOGE</td>
                                         <td style="width: 22%">
                                             <asp:RadioButtonList ID="RBTISMSMEUNIT" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RBTISMSMEUNIT_SelectedIndexChanged"  RepeatDirection="Horizontal" TabIndex="5">
                                                <asp:ListItem Value="1">YES</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                         
                                    </tr>
                                    <tr id="TRMSMEUNITNAME" runat="server" visible="false">
                                      <td align="center" valign="middle"  >

                                            MSMEUNITNAME</td>
                                         <td style="width: 22%">
                                            <asp:DropDownList ID="DDLMSMEUNITNAME" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="DDLMSMEUNITNAME_SelectedIndexChanged">
                                                <%--<asp:ListItem Value="0">--MSMEUNITNAME--</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                         
                                    </tr>
                                     <tr id="TRDISTANDMANDAL" runat="server" visible="false">
                                        <td align="center" valign="middle"  >District : </td>
                                        <td style="width: 22%">
                                            <asp:Label ID="LBLDISTRICT" runat="server"></asp:Label>
                                        </td>
                                         
                                        <td align="left" valign="middle" >Mandal : </td>
                                        <td>
                                            <asp:Label ID="LBLMANDAL" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr id="TRMSMEANDLOA" runat="server" visible="false">
                                      <td align="center" valign="middle"  >

                                            MSME NO</td>
                                         <td style="width: 22%">
                                            <asp:Label ID="LBLMSMENO" runat="server"></asp:Label>
                                        </td>
                                         <td align="left" valign="middle" >Line of Activity : </td>
                                        <td>
<asp:Label ID="LBLLOANAME" runat="server"></asp:Label>                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                   <tr id="trunitname" runat="server" visible="false">
                                      <td align="center" valign="middle"  >

                                            UNIT NAME</td>
                                         <td style="width: 22%">
                                            <asp:Label ID="LBLUNITNAME" runat="server"></asp:Label>
                                        </td>
                                         
                                    </tr>
                                    <tr id="TRUPDATE" runat="server" visible="false">
                                        <td align="center" colspan="4" style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="BTNUPDATE" runat="server" CssClass="btn btn-primary" Enabled="true" Height="32px" OnClick="BTNUPDATE_Click" TabIndex="2" Text="UPDATE" ValidationGroup="group" Width="90px" />
                                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                                                            <asp:HiddenField ID="HDNAPPLICATIONTYPE" runat="server" Visible="false" />

                                    <tr>
                                        <td align="center" colspan="5" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    


                                </table>
                                <table>
                                </table>
                                <asp:HiddenField ID="HDNMSMENO" runat="server" />
                                <asp:HiddenField ID="HDNUNITNAME" runat="server" />
                                <asp:HiddenField ID="HDNIDENTITYID" runat="server" />
                                <asp:HiddenField ID="HDNDISTRICTID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>




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
