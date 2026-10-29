<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmknowledgingsharing.aspx.cs" Inherits="UI_TSiPASS_frmknowledgingsharing" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .style21 {
            height: 35px;
        }

        .style26 {
            height: 21px;
        }

        .style27 {
            height: 21px;
        }

        .style34 {
            height: 21px;
            width: 261px;
        }

        .style35 {
            height: 35px;
            width: 261px;
        }

        .style36 {
            width: 261px;
        }

        .style41 {
            height: 29px;
        }

        .style42 {
            width: 261px;
            height: 29px;
        }

        .style46 {
            height: 44px;
        }

        .style47 {
            height: 44px;
            width: 261px;
        }

        .style48 {
            width: 10px;
            height: 44px;
        }

        .style49 {
            width: 206px;
            height: 44px;
        }
        .auto-style1 {
            height: 21px;
            width: 27px;
        }
        .auto-style2 {
            height: 29px;
            width: 27px;
        }
        .auto-style3 {
            width: 27px;
        }
        .auto-style4 {
            height: 87px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>



    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp;<li class="active">
            <a href="#">
                <asp:Label ID="lblHead1" runat="server" CssClass="LBLBLACK" Font-Bold="True"></asp:Label></a></li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="199px"></asp:Label></h3>
                    </div>
                      <table  id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
     <tr>
         <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
             valign="top" align="center">
             <div class="col-lg-12" style="left: 0px; top: 0px">
                 <div class="panel panel-default">
                     <div class="panel-heading" style="text-align: center">
                         <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                         <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;"><asp:Label ID="lblHeading" runat="server">TSiPASS- Knowledge Repository Report </asp:Label>
                             <a id="Button2" href="#"   onserverclick="Button2_ServerClick"
                             runat="server">
                             <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                 alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                     <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                         alt="Excel" /></a></h2>
                     </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                      <%--  <tr>
                                            <td class="style26" colspan="5"
                                                style="padding: 5px; margin: 5px; text-align: left;">
                                                Knowledge Repository</td>
                                            <td class="style26" colspan="4" style="padding: 5px; margin: 5px;"></td>
                                        </tr>--%>
                                        <tr runat="server" id="trData">
                                            <td colspan="9">
                                                <table>

                                                    <tr>
                                                        <td class="auto-style1" style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                                        <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                            Name Of Section:</td>
                                                        <td class="style26" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:DropDownList ID="ddldept0" runat="server" Visible="true" class="form-control txtbox"
                                                                Height="33px" TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>                                                       
                                                        </tr>
                                                   </table>
                                                
                                                            &nbsp;</td>
                                                    </tr>
                                        <tr runat="server" id="trDocum">
                                            <td colspan="9">
                                                <table>                                                                                       
                                                    <tr>
                                                        <td class="auto-style1" style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                                        <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                        Description Of Document:</td>
                                                           <td class="style26" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:DropDownList ID="ddldoc" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldoc_SelectedIndexChanged" class="form-control txtbox"
                                                                Height="33px" TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                       </td>
                                                    </tr>
                                                      </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trud">
                                            <td colspan="9">
                                                <table>                                                
                                        <tr id="trotherdesc" runat="server" visible="false">
                                            <td class="auto-style1" style="padding:5px; margin:5px"></td>
                                             <td class="style34" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                 <td class="style26" style="padding: 5px; margin: 5px"></td>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;" colspan="6" >
                                                           <%-- <asp:TextBox ID="txtuidno" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                                Width="200px" AutoPostBack="True" OnTextChanged="txtuidno_TextChanged"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtuidno" runat="server" CssClass="form-control" Height="28px" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                                    </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trRemark">
                                            <td colspan="9" class="auto-style4">
                                                <table>                                                  
                                                    <tr>
                                                        <td class="auto-style2" style="padding: 5px; margin: 5px; text-align: left;"
                                                            valign="middle">
                                                            <asp:Label ID="lblSlno7" runat="server" Text="Label">3.</asp:Label></td>
                                                        <td class="style42" style="padding: 5px; margin: 5px; text-align: left;">
                                                            Remark:</td>
                                                        <td class="style41" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:TextBox ID="txtDesc" runat="server" class="form-control txtbox"
                                                                Height="58px" MaxLength="40" TabIndex="1" TextMode="MultiLine"
                                                                ValidationGroup="group" Width="643px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                      </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trUpload">
                                            <td colspan="9">
                                                <table>                                                     
                                                    <tr id="rem" runat="server">
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                            valign="middle" class="auto-style3">
                                                            <asp:Label ID="lblSlno8" runat="server" Text="Label">4.</asp:Label></td>
                                                        <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label549" runat="server" CssClass="LBLBLACK" Width="114px">Upload:</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>                                                      
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="3">
                                                            <asp:FileUpload ID="FileUpload" runat="server" class="form-control txtbox"
                                                                Height="30px" />
                                                            <asp:HyperLink ID="lblFileName1" runat="server" CssClass="LBLBLACK" Visible="false"
                                                                Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                            <br />
                                                            <asp:Label ID="Label560" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                      <%--  <td class="style6" colspan="3"
                                                            style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:Button ID="BtnUpload" runat="server" CssClass="btn btn-xs btn-warning"
                                                                Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="BtnUpload_Click"/>
                                                        </td>--%>
                                                    </tr>
                                                     </table>
                                            </td>
                                        </tr>
                                       <%-- <tr runat="server" id="trbtn">
                                            <td colspan="15">
                                                <table cellspacing="5">   --%>                                               
                                                    <tr>
                                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;<asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                                                            Height="32px" TabIndex="10" Text="Submit" ValidationGroup="group"
                                                            Width="90px" OnClick="BtnSave_Click" />
                                                            &nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                                        </td>
                                                    </tr>
                                       <%--  </table>
                                            </td>
                                        </tr>
                                         --%>
      
            <tr>
                <td align="center" style="text-align: center;" valign="top" colspan="5">
                    <asp:GridView ID="Gridview" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                            Width="100%" ShowFooter="True" >
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate> 
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                            </asp:TemplateField>
                          <asp:BoundField HeaderText="Name of Section" DataField="NameofSection">
                            <ItemStyle CssClass="text-center" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="Description Of Document" DataField="DescriptionofDocument">
                            <ItemStyle HorizontalAlign="Center" CssClass="tex-center" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="Remark" DataField="Remarkmultiline">
                            <ItemStyle HorizontalAlign="Center" CssClass="aligncenter" />
                        </asp:BoundField>
<%--                                                <asp:BoundField HeaderText="Upload" DataField="Section_File_Path" />--%>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Upload">
                             <ItemTemplate>
                          <asp:HyperLink ID="Hyperlink" runat="server" Text="Upload" NavigateUrl='<%#Eval("Section_File_Path", "~/YourNextPage.aspx") %>' Target="_blank"></asp:HyperLink>
                          </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                            </asp:TemplateField>                           
                        </Columns>
                    </asp:GridView>
                </td>                
            </tr>                                            
                                         </table>
                                            </td>
                                        </tr>
                                    </table>
                        </div>
                     </div>
                 </div>
         </td>
     </tr>
                               <%-- </td>--%>
                            <%--</tr>--%>

                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert"
                                            href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label
                                                ID="lblmsg" runat="server" Visible="false"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server" Visible="false"></asp:Label>
                                    </div>

                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </td>
                            </tr>
                        </table>



                    </div>

                </div>
            </div>
        </div>

    </div>



    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

