<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmProcessPattalandappl.aspx.cs" Inherits="UI_TSiPASS_frmProcessPattalandappl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Styles/SideMenu/script.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/SideMenu/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
   
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
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

        .style6 {
            width: 192px;
        }

        .style7 {
            color: #FF3300;
        }
        .auto-style1 {
            width: 32px;
        }
    </style>
    <table>
        <tr>
            <td style="padding: 5px; margin: 5px" valign="top">
                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="278px">Processing of Pattaland Appliction<font 
                                                            color="red">*</font></asp:Label>
            </td>
        </tr>
    <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        ForeColor="#333333" Height="62px"  ShowFooter="True"
                                                        Width="100%" >
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <%--ID	PATTADARID	DEPTID	APPROVALID	APPLICATIONSTATUS	STAGEID	PANcardno	AadharNo	Email	GST	MOBILENO	PATTADARNAME	SODOWO	DHARANINUMBER	MINERALNAME	EXTENTINHECTARE	SURVEYNO	DISTRICT	MANDAL	VILLAGE	CREATED_DT	CREATED_BY	MODIFIED_DT	MODIFIED_BY	UIDNO	DistrictName	MandalName	VillageName--%>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false"  />
                                                            <asp:BoundField DataField="PATTADARID" HeaderText="Pattadar Application ID" />
                                                            <asp:BoundField DataField="PATTADARNAME" HeaderText="Pattadar Name" />
                                                            <asp:BoundField DataField="DHARANINUMBER" HeaderText="Pattadar Passbook No." />
                                                            <asp:BoundField DataField="MINERALNAME" HeaderText="Mineral NameE" />
                                                            <asp:BoundField DataField="EXTENTINHECTARE" HeaderText="Total Extent in Hectare" />
                                                             <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                                             <asp:BoundField DataField="MandalName" HeaderText="Mandal" />
                                                             <asp:BoundField DataField="VillageName" HeaderText="Village" />
                                                            <asp:BoundField DataField="SURVEYNO" HeaderText="Survey No" />
                                                             <asp:BoundField DataField="PartExtent" HeaderText="Extent per Survey No." />
                                                             <asp:BoundField DataField="PANcardno" HeaderText="PAN card No." />
                                                             <asp:BoundField DataField="AadharNo" HeaderText="Aadhar No." />
                                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                                              <asp:BoundField DataField="MOBILENO" HeaderText="MOBILE No." />
                                                            <%--<asp:HyperLinkField HeaderText="PATTADAR Application" Text="View" />
                                                            <asp:HyperLinkField HeaderText="Attachments" Text="Attachments" />
                                                            <asp:HyperLinkField HeaderText="Process" Text="Process" />--%>
                                                             <%--<asp:BoundField DataField="rejected_reason" HeaderText="Rejected Reason"  />
                                                             <asp:HyperLinkField HeaderText="Approved DGPS/NOC" Text="Signed DGPS" />
                                                             <asp:BoundField DataField="ApprovalCompleteFlg" HeaderText="Status" />--%>


                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr></table>
    </br>
    </br>
    <table>
        <tr>
            <td style="padding: 5px; margin: 5px" valign="top">
                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="278px">To Process above Pattaland Appliction<font 
                                                            color="red">*</font></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                <table cellpadding="4" cellspacing="5" style="width: 100%; text-align: left;">
                    <%--<tr>
                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">1. </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;">
                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" data-balloon="Self Certification Form" data-balloon-length="large" data-balloon-pos="down" Width="210px">Land documents (Sale Deed/Pattadar Passbook etc).<font 
                                                            color="red">*</font></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px">: </td>
                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                            <asp:FileUpload ID="FUPLANDDOCUMENTS" runat="server" class="form-control txtbox" Height="33px" Width="300px" />
                            <asp:HyperLink ID="HYPLANDDOCUMENTS" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                            <br />
                            <asp:Label ID="LBLLANDDOCUMENTS" runat="server" Visible="False"></asp:Label>
                            <asp:HiddenField ID="HDNLANDDOCUMENT" runat="server" />
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            <asp:Button ID="BTNLANDDOCUMENT" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" OnClick="BTNLANDDOCUMENT_Click" TabIndex="10" Text="Upload" Width="72px" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">1. </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;">
                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" data-balloon="Self Certification Form" data-balloon-length="large" data-balloon-pos="down" style="left: 0px; top: 10px; width: 255px">Select Approve or Reject to Process the application<font 
                                                            color="red">*</font></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px">: </td>
                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                           <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" class="form-control txtbox"
                            Height="33px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="180px">
                             <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="13">Approve</asp:ListItem>
                        <asp:ListItem Value="16">Reject</asp:ListItem>

                           </asp:DropDownList>
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            &nbsp;</td>
                    </tr>
                     <tr id="trReject" visible="false" runat="server">
                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">2. </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;">
                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" data-balloon="Self Certification Form" data-balloon-length="large" data-balloon-pos="down" style="left: 0px; top: 10px; width: 255px">If You want to Reject the application Please type the reason<font 
                                                            color="red">*</font></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px">: </td>
                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                          <asp:TextBox ID="txtRjctReasn" runat="server" class="form-control txtbox" Height="40px"
                           TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Visible="true" Width="180px"></asp:TextBox>
                            </td>
                         <td>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRjctReasn"
                        ErrorMessage="Please Enter Discription" TabIndex="1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            &nbsp;</td>
                    </tr>
                    <tr id="trNOC" Visible="false" runat="server">
                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">2. </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;">
                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" data-balloon="Self Certification Form" data-balloon-length="large" data-balloon-pos="down" style="left: 0px; top: 10px; width: 265px">If you want to Approve Please Upload Signed DGPS Map.<font 
                                                            color="red">*</font></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px">: </td>
                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                            <asp:FileUpload ID="FUPNOC" runat="server" class="form-control txtbox" Height="33px" Width="300px" />
                            <asp:HyperLink ID="HYPNOC" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                            <br />
                            <asp:Label ID="LBLNOC" runat="server" Visible="False"></asp:Label>
                            <asp:HiddenField ID="HDNNOC" runat="server" />
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            <asp:Button ID="BTNNOC" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" OnClick="BTNNOC_Click" TabIndex="10" Text="Upload" Width="72px" />
                        </td>
                    </tr>
                    <tr id="trDGPS" visible="false" runat="server">
                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">3. </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;">
                            <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" data-balloon="Self Certification Form" data-balloon-length="large" data-balloon-pos="down" style="left: 0px; top: 10px; width: 244px">Please Upload Signed Copy of DGPS Map<font 
                                                            color="red">*</font></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px">: </td>
                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                            <asp:FileUpload ID="FUPSignedDGPS" runat="server" class="form-control txtbox" Height="33px" Width="300px" />
                            <asp:HyperLink ID="HYPSignedDGPS" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                            <br />
                            <asp:Label ID="LBLSignedDGPS" runat="server" Visible="False"></asp:Label>
                            <asp:HiddenField ID="HDNSignedDgps" runat="server" />
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            <asp:Button ID="BTNSignedDGPS" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" OnClick="BTNSignedDGPS_Click" TabIndex="10" Text="Upload" Width="72px" />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style1"></td>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Height="32px"
                                OnClick="btnsave_Click" TabIndex="10" Text="Submit" ValidationGroup="group" Width="90px"
                                Visible="true" />
                            &nbsp;&nbsp;<asp:Button ID="btnclear" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                Height="32px" OnClick="btnclear_Click" TabIndex="10" Text="Clear" Width="90px" />

                            &nbsp;<%-- &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                Width="90px" />--%></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
</asp:Content>
