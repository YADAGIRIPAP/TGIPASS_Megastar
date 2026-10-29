<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveFormCFECFONew.aspx.cs" Inherits="UI_TSiPASS_IncentiveFormCFECFONew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function chkRegNoLastLetters() {
            var reg = /^\d[0-9]*$/;
            var tlength = document.getElementById("<%=txtregistrationno.ClientID%>");
            var msg = document.getElementById("<%=lblmsg0.ClientID%>")
            var s = String(tlength.value);
            var st = s.substring(s.length, s.length - 4)
            if (!reg.test(st)) {

                alert("Last 4 Letters must contain only Numbers !\nFormat must be AP09BQ1234");
                tlength.focus();
                return false;
            }
            else
                return true;
        }
    </script>

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
                                    <tr>
                                        <td align="center" valign="middle" >Type of Sector</td>
                                        <td colspan="4">
                                            <asp:DropDownList ID="rblSector" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="rblSector_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="1" Width="180px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Service</asp:ListItem>
                                                <asp:ListItem Value="2">Manufacture</asp:ListItem>
                                                <asp:ListItem Value="3">Textiles</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                   
                                    </tr>
                                    <tr id="trTrans" visible="false" runat="server" >
                                        <td id="tdTrans1" runat="server" style="height:50px" align="center"   valign="middle" visible="false">Transport/Others</td>
                                        <td id="tdTrans2" runat="server" align="left" valign="middle" visible="false" colspan="4">

                                            <asp:RadioButtonList ID="rblVeh" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblVeh_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="5">
                                                <asp:ListItem Value="1">Transport allied activities</asp:ListItem>
                                                <asp:ListItem Value="0">Other Service Sector</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </td> 
                                    </tr>
                                    <tr id="trvehicleno" runat="server" visible="false">
                                        
                                        <td align="center" style="height: 93px" >
                                            <asp:Label ID="lblVehicle" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td style=" width: 28%; height: 93px;">
                                            <asp:TextBox ID="txtregistrationno" runat="server" class="form-control txtbox" Height="28px"  TabIndex="4" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txtregistrationno" Display="None" ErrorMessage="Please Enter Vehicle Number" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                       
                                        <td style="height: 93px"></td>
                                        <td style="height: 93px">
                                            </td>
                                    </tr>
                                    <tr id="trdistrict" runat="server" visible="false">
                                        <td align="center" valign="middle"  >District : </td>
                                        <td style="width: 28%">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged" Width="180px">
                                                <asp:ListItem>--District--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProp_intDistrictid" ErrorMessage="Please Select Proposed Location (District)" InitialValue="--District--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                         
                                        <td align="left" valign="middle" >Mandal : </td>
                                        <td>
                                            <asp:DropDownList ID="ddlProp_intMandalid" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlProp_intMandalid_SelectedIndexChanged">
                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProp_intMandalid" ErrorMessage="Please Select Proposed Location (Mandal)" InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trvillage" runat="server" visible="false">
                                      <td align="center" valign="middle"  >

                                            Village</td>
                                         <td style="width: 28%">
                                            <asp:DropDownList ID="ddlVillage" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                <asp:ListItem>--Village--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvddlVillage" runat="server" ControlToValidate="ddlVillage" ErrorMessage="Please Select Proposed Location (Village)" InitialValue="--Village--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                         
                                    </tr>
                                    <tr id="trlineofactivity" runat="server" visible="false">
                                        <td id="tdLineofActivity" runat="server" valign="middle" visible="false">Line of Activity : </td>
                                         <td id="tdLineofActivity1" runat="server" align="center" valign="middle" visible="false" style="width: 28%">
                                            <asp:DropDownList ID="ddlintLineofActivity" runat="server" AutoPostBack="True" class="custom-select" Height="33px" Width="300px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator94" runat="server" ControlToValidate="ddlintLineofActivity" ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                         
                                        <td align="left" valign="middle" >Name of Unit : </td>
                                        <td>
                                            <asp:TextBox ID="txtnameofunit" runat="server" class="form-control txtbox" Height="28px" MaxLength="1000" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td  align="center" colspan="5" valign="middle">&nbsp;</td>
                                         
                                    </tr>
                                    <tr id="trFirstTrans" runat="server" visible="false">
                                        <td align="right">

                                            <asp:CheckBox ID="chkTransportDeclare" AutoPostBack="true" runat="server" OnCheckedChanged="chkTransportDeclare_CheckedChanged" />

                                        </td>
                                         <td align="center" colspan="5" style="padding: 5px;text-align:justify; color: Red; 
text margin: 5px">&nbsp;<b>I Hereby declare that, i am applying for first time for transport and no one in my family has earlier filed for this claim by any means. I am Liable for any deviation or violation of rules.</b>
                                         </td>
                                    </tr>
                                    <tr id="trFirstService" runat="server" visible="false">
                                        <td align="right">

                                            <asp:CheckBox ID="chkFirstService" AutoPostBack="true" runat="server" OnCheckedChanged="chkTransportDeclare_CheckedChanged" />

                                        </td>
                                         <td align="center" colspan="5" style="padding: 5px;text-align:justify; color: Red; 
text margin: 5px">&nbsp;<b>I Hereby declare that, i am applying for first time for service activity and no one in my family has earlier filed for this claim by any means. I am Liable for any deviation or violation of rules.</b>
                                         </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="5" style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="btnnext" runat="server" CssClass="btn btn-primary" Enabled="true" Height="32px" OnClick="btnnext_Click" TabIndex="2" Text="Next" ValidationGroup="group" Visible="false" Width="90px" />
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Enabled="false" Height="32px" OnClick="BtnSave1_Click" TabIndex="2" Text="Search" ValidationGroup="group" Visible="false" Width="90px" />
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr id="TRISMSMEUNIT" runat="server" visible="false">
                                      <td align="center" valign="middle"  >

                                            IS UNIT ENTERED IN MSME CATELOGE</td>
                                         <td style="width: 28%">
                                             <asp:RadioButtonList ID="RBTISMSMEUNIT" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RBTISMSMEUNIT_SelectedIndexChanged"  RepeatDirection="Horizontal" TabIndex="5">
                                                <asp:ListItem Value="1">YES</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                         
                                    </tr>
                                    <tr id="TRMSMEUNITNAME" runat="server" visible="false">
                                      <td align="center" valign="middle"  >

                                            MSMEUNITNAME</td>
                                         <td style="width: 28%">
                                            <asp:DropDownList ID="DDLMSMEUNITNAME" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="DDLMSMEUNITNAME_SelectedIndexChanged">
                                                <%--<asp:ListItem Value="0">--MSMEUNITNAME--</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                         
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:GridView ID="grdDetails" runat="server" AllowPaging="False" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound" PageSize="15" ShowFooter="True" Width="100%">
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
                                                    <asp:BoundField DataField="UID" HeaderText="UID" />
                                                    <asp:BoundField DataField="Name of the Industry" HeaderText="Name of the Industry" />
                                                    <asp:BoundField DataField="Activity Proposed" HeaderText="Activity Proposed" />
                                                    <asp:BoundField DataField="Line of Activity" HeaderText="Line of Activity" />
                                                    <asp:BoundField DataField="Total Investment" HeaderText="Total Investment (in Crores)" />
                                                    <asp:BoundField DataField="Date of application" HeaderText="Date of application" />
                                                    <asp:BoundField DataField="createdBy" HeaderText="createdby" Visible="false" />
                                                    <asp:TemplateField HeaderText="View Status">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypLetter" runat="server" Target="_blank"> </asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#B9D684" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="checkUID" runat="server" visible="false">
                                        <td align="center" colspan="6" style="padding: 5px; color: red; margin: 5px"><b>Note : There is no UID number for this user id. Please apply for incentives from the login through which CFE &amp; CFO is applied. </b></td>
                                    </tr>
                                    <tr>
                                    <asp:HiddenField ID="HDNAPPLICATIONTYPE" runat="server" Visible="false" />
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
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
                                <asp:HiddenField ID="hdfID" runat="server" />
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
