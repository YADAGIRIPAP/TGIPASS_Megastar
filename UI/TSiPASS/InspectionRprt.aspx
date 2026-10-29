<%@ Page Title="Inspection Report" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="InspectionRprt.aspx.cs" Inherits="UI_TSiPASS_InspectionRprt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .GridviewDiv {
            font-size: 100%;
            font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }

        .headerstyle {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }

        .auto-style1 {
            font-size: 12.0pt;
            font-family: "Times New Roman", serif;
            margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
            margin-bottom: .0001pt;
        }

        .auto-style2 {
            text-align: justify;
            text-indent: 18.0pt;
            font-size: 12.0pt;
            font-family: "Times New Roman", serif;
            margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
            margin-bottom: .0001pt;
        }

        </style>

    <asp:UpdatePanel ID="updIncInspcRprt" runat="server">
        <ContentTemplate>

            <asp:HiddenField ID="hdfFlagID" runat="server" />
            <asp:HiddenField ID="hdfFlagID0" runat="server" />
            <asp:HiddenField ID="hdfpencode" runat="server" />
            <div class="col-lg-11" style="height: auto">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Inspection Report</h3>
                    </div>

                    <div class="panel-body">
                        <table>
                            <tr>

                                <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                    <span style="font-weight: bold; text-decoration: underline">1.0 Inspection Details:</span>
                                </td>

                            </tr>
                        <%--</table>--%>
                        <div align="center">
                            <table style="width: 80%" cellpadding="10px">

                                <tr id="trNameofInd1ddl" runat="server" visible="false">
                                    <td style="padding: 5px; margin: 5px;">Name of the Industry
                                    </td>
                                    <td style="width:inherit">:
                                    </td>
                                    <td>
                                       
                                        <asp:DropDownList ID="ddlNameofInd" class="form-control txtbox" Width="30px"  Height="28px" runat="server"></asp:DropDownList>
                                    </td>
                                  

                                </tr>
                                <tr id="trNameofInd2TxtBx" runat="server" visible="false">
                                    <td>
                                        Name of the Industry
                                    </td>
                                    <td style="width: 30px">:
                                    </td>

                                      <td id="ddlNameID1" runat="server">
                                            <asp:TextBox ID="txtNameofInd" TextMode="MultiLine" class="form-control txtbox" Height="60px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>

                                 <tr id="tr1" runat="server" visible="false">
                                    <td>
                                        Udyog Aadhar/IEM
                                    </td>
                                    <td style="width: 30px">:
                                    </td>

                                      <td id="Td1" runat="server">
                                            <asp:TextBox ID="txtUdyogAdhar"  class="form-control txtbox" Height="60px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;">Address of the Industry

                                    </td>
                                    <td style="width: 30px">:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" TextMode="MultiLine" class="form-control txtbox" Height="60px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;">Name of the Inspecting Officer
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtIPOName" class="form-control txtbox" Height="28px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;">Designation
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIPODesignation" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;">Date(s) of Inspection                            
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInpectedDate" Width="150px" class="form-control txtbox" Height="28px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Image ID="imgClndr" runat="server" ImageUrl="~/images/calendericon1.gif" />

                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy"
                                            PopupButtonID="imgClndr" TargetControlID="txtInpectedDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;">Constitution                          
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlConstOfUnit" Width="150px" class="form-control txtbox" runat="server">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Proprietary</asp:ListItem>
                                            <asp:ListItem Value="2">Partnership</asp:ListItem>
                                            <asp:ListItem Value="3">Pvt Ltd</asp:ListItem>
                                            <asp:ListItem Value="4">Public Limited</asp:ListItem>
                                            <asp:ListItem Value="5">Co-Operative</asp:ListItem>
                                            <asp:ListItem Value="6">LLP</asp:ListItem>
                                            <asp:ListItem Value="7">Trust</asp:ListItem>

                                        </asp:DropDownList>
                                    </td>

                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;">Person (from Industry) present at the time of Inspection.                          
                                    </td>
                                    <td>:
                                    </td>
                                    <td>

                                        <asp:TextBox ID="txtPersonIndustry" Width="150px" class="form-control txtbox" Height="28px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server"></asp:TextBox>
                                    </td>

                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;">Status of Industry                       
                                    </td>
                                    <td>:
                                    </td>

                                    <td>
                                        <asp:DropDownList ID="ddlStatus" class="form-control txtbox" Width="150px" runat="server">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">New</asp:ListItem>
                                            <asp:ListItem Value="2">Expansion</asp:ListItem>
                                            <asp:ListItem Value="3">Diversification</asp:ListItem>
                                            

                                        </asp:DropDownList>

                                    </td>

                                </tr>

                            </table>
                        </div>
                        <div align="left">
                            <div>
                                <table style="width: auto">
                                    <tr>
                                        <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                            <span style="font-weight: bold; text-decoration: underline">2.0 Verification Certificate:</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="center" align="center">
                                            <asp:RadioButtonList ID="rdbVerifyCert" runat="server" Height="16px" RepeatDirection="Horizontal" Width="5px">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                        <td style="padding: 3px; margin: 3px; width: auto;" align="justify">Certified that contents of the claim under Part-A and the document indicated in Part-c of this claim application were verified and found correct. The plant and machinery and equipment was physically verified as per the statement of machinery and found them duly installed and put on work .  Further certified that the fixed assets claimed for incentives are essentially required for carrying the production in which the industry is engaged in.
                                        </td>
                                    </tr>

                                </table>
                                <table>
                                    <tr>
                                        <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                            <span style="font-weight: bold; text-decoration: underline">3.0 Project Details:</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>

                        <div align="left">
                            <table>
                                <tr>
                                    <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                        <span style="font-weight: bold; text-decoration: underline">3.1 For New Enterprise</span>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div align="center">


                            <table style="width: 100%">
                                <tr align="center">

                                    <th style="text-align: center">Line of activity</th>
                                    <th style="text-align: center">Units</th>
                                    <th style="text-align: center">Installed capacities</th>
                                    <th style="text-align: center">Value</th>
                                </tr>
                                <tr>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtLOAInsp" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtUnitInsp" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtInstldCapInsp" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtValueInsp" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>


                                </tr>
                            </table>
                        </div>
                        <div align="left">
                            <table style="margin-top: 10px">
                                <tr>
                                    <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                        <span style="font-weight: bold; text-decoration: underline">3.2 For Expansion / Diversification Project	</span>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div align="center">


                            <table style="width: 90%">
                                <tr>

                                    <th style="text-align: center"></th>
                                    <th style="text-align: center">Line of activity</th>
                                    <th style="text-align: center">Installed Capacity (in units)</th>
                                    <th style="text-align: center; width: 10px; text-wrap: inherit">% of increase under Expansion/ Diversification Project</th>
                                </tr>
                                <tr>
                                    <td style="width: auto; padding-left: 33px">Existing Enterprise
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtLOAExistEntr" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtInstCapExistEntr" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtPercntIncrExistEntr" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>


                                </tr>
                                <tr>
                                    <td style="padding-top: 0px">&nbsp;
        <!--you just need a space in a row-->
                                    </td>
                                </tr>

                                <tr style="padding-top: 30px">
                                    <td style="width: auto;" align="center">Expansion/ Diversification Project
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtLOAExpn" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtInsCapExpn" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtIncrExpn" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>


                                </tr>

                            </table>
                        </div>


                        <div align="left">
                            <table style="margin-top: 10px">
                                <tr>
                                    <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                        <span style="font-weight: bold; text-decoration: underline">3.3. Fixed Capital Investment of the Expansion / Diversification Project (in Rs.)</span>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div align="center">


                            <table style="width: 90%">
                                <tr>

                                    <th style="text-align: center">Nature of Assets</th>
                                    <th style="text-align: center">Existing Enterprise</th>
                                    <th style="text-align: center">Expansion/ Diversification Project</th>
                                    <th style="text-align: center; width: 10px; text-wrap: inherit">% of increase under Expansion/ Diversification Project</th>
                                </tr>
                                <tr>
                                    <td style="width: auto;" align="center">Land
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtLandExtEntr" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtExpnLAnd" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtLandExpnDiverse" TextMode="MultiLine" class="form-control txtbox" Height="50px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>


                                </tr>
                                <tr>
                                    <td style="padding-top: 0px">&nbsp;
        <!--you just need a space in a row-->
                                    </td>
                                </tr>

                                <caption>
                                    
                                    <tr>
                                        <td align="center" style="width: auto;">Building </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtBldngExtEntr" runat="server" class="form-control txtbox" Height="50px" MaxLength="80" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtBldngExpnDivers" runat="server" class="form-control txtbox" Height="50px" MaxLength="80" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtBldgIncrExpn" runat="server" class="form-control txtbox" Height="50px" MaxLength="80" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 0px">&nbsp;
                                            <!--you just need a space in a row-->
                                        </td>
                                    </tr>
                                    <tr style="padding-top: 30px">
                                        <td align="center" style="width: auto;">Plant &amp; Machinery </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtPltMachExstEntr" runat="server" class="form-control txtbox" Height="50px" MaxLength="80" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtPltMachExpn" runat="server" class="form-control txtbox" Height="50px" MaxLength="80" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtPltMachIncrExpn" runat="server" class="form-control txtbox" Height="50px" MaxLength="80" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 0px">&nbsp;
                                            <!--you just need a space in a row-->
                                        </td>
                                    </tr>
                                    <tr style="padding-top: 30px">
                                        <td align="center" style="width: auto;">Total </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtTotLand" runat="server" class="form-control txtbox"  Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtTolBldg" runat="server" class="form-control txtbox"  Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                        <td align="center" style="width: auto">
                                            <asp:TextBox ID="txtToTPlantMach" runat="server" class="form-control txtbox"  Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </caption>

                            </table>
                        </div>
                        <div align="center">

                            <table>
                                <tr>
                                    <td style="padding-top: 30px"></td>
                                </tr>
                                <tr>

                                    <td style="padding-left: 30px"></td>
                                    <td style="text-align: center; white-space: nowrap;">Date of commencement of Production
                                    </td>
                                    <td style="padding-left: 30px"></td>
                                    <td>
                                        <asp:TextBox ID="txtCalenderDCP" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 30px"></td>
                                    <td>
                                        <asp:Image ID="ImgClndrDCP" runat="server" ImageUrl="~/images/calendericon1.gif" />

                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy"
                                            PopupButtonID="ImgClndrDCP" TargetControlID="txtCalenderDCP">
                                        </cc1:CalendarExtender>
                                    </td>

                                </tr>


                                <tr>
                                    <td style="padding-top: 10px"></td>
                                </tr>
                                <tr>

                                    <td style="padding-left: 30px"></td>
                                    <td style="text-align: center; white-space: nowrap;">Date of receipt of claim application
                                    </td>
                                    <td style="padding-left: 10px"></td>
                                    <td>
                                        <asp:TextBox ID="txtRcptAppln" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 30px"></td>
                                    <td>
                                        <asp:Image ID="imgRcptAppln" runat="server" ImageUrl="~/images/calendericon1.gif" />

                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy"
                                            PopupButtonID="imgRcptAppln" TargetControlID="txtRcptAppln">
                                        </cc1:CalendarExtender>
                                    </td>

                                </tr>

                                <tr>
                                    <td style="padding-top: 2px"></td>
                                </tr>
                                <tr>

                                    <td style="padding-left: 30px"></td>
                                    <td style="text-align: center; white-space: normal;">Date of issue of Regd. Notice calling shortfall  documents/information
                                    </td>
                                    <td style="padding-left: 10px"></td>
                                    <td>
                                        <asp:TextBox ID="txtDateShrtfall" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 30px"></td>
                                    <td>
                                        <asp:Image ID="imgCldShrtfl" runat="server" ImageUrl="~/images/calendericon1.gif" />

                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy"
                                            PopupButtonID="imgCldShrtfl" TargetControlID="txtDateShrtfall">
                                        </cc1:CalendarExtender>
                                    </td>

                                </tr>

                                <tr>
                                    <td style="padding-top: 2px"></td>
                                </tr>
                                <tr>

                                    <td style="padding-left: 30px"></td>
                                    <td style="text-align: center; white-space: normal;">Date of receipt of shortfall documents/information.
                                    </td>
                                    <td style="padding-left: 10px"></td>
                                    <td>
                                        <asp:TextBox ID="txtDtShrtFallRcvd" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 30px"></td>
                                    <td>
                                        <asp:Image ID="imgCldShrtFallRcvd" runat="server" ImageUrl="~/images/calendericon1.gif" />

                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy"
                                            PopupButtonID="imgCldShrtFallRcvd" TargetControlID="txtDtShrtFallRcvd">
                                        </cc1:CalendarExtender>
                                    </td>

                                </tr>

                            </table>
                        </div>

                        <div>
                            <table>
                                <tr>
                                    <td style="padding-top: 7px"></td>
                                </tr>
                                <tr>

                                    <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                        <span style="font-weight: bold; text-decoration: underline">4.0.0	Capital cost computed & recommended in Rs.</span>
                                    </td>

                                </tr>
                                <tr>
                                    <td>4.1.0	Land: 
                                    </td>

                                </tr>
                            </table>

                        </div>

                        <div align="center">
                            <table style="width: 90%">
                                <tr>

                                    <th style="text-align: center; width: 10px">Extent in Sq.Mtrs</th>
                                    <th style="text-align: center; width: 10px">Built up area in Sq.Mtrs</th>
                                    <th style="text-align: center; width: 15px; text-wrap: inherit">5 times built up area in Sq.Mtrs</th>
                                    <th style="text-align: center; width: 10px; text-wrap: inherit">Extent eligible in Sq.Mtrs</th>
                                </tr>
                                <tr>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtExtent" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>

                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtBuiltupAra" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>

                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txt5TtimesBltup" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>

                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtExtentElgble" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>


                                </tr>
                        </div>


                        <div align="center">
                            <table style="width: 70%">
                                <tr>
                                    <td style="padding-top: 30px"></td>
                                </tr>
                                <tr width="10px">
                                    <td style="text-align: justify; width: auto; text-wrap: inherit">Claim application submitted by the Enterprise for reimbursement of Stamp Duty:
                                    </td>
                                    <td style="width: 5px;">
                                        <asp:RadioButtonList ID="rdblYesNoClaimSubmn" runat="server" RepeatDirection="Horizontal" Width="10px">
                                            <asp:ListItem Value="1">YES</asp:ListItem>
                                            <asp:ListItem Value="2">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px"></td>
                                </tr>
                                <tr width="10px">
                                    <td style="text-align: justify; width: auto; text-wrap: inherit">Claim application submitted by the Enterprise for reimbursement of Land Cost:
                                    </td>
                                    <td style="width: 5px;">
                                        <asp:RadioButtonList ID="rdblClmApplRmbrLandCst" runat="server" RepeatDirection="Horizontal" Width="10px">
                                            <asp:ListItem Value="1">YES</asp:ListItem>
                                            <asp:ListItem Value="2">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding-top: 10px"></td>
                                </tr>


                            </table>
                        </div>

                        <div>
                            <table style="width: 100%">

                                <tr>
                                    <td style="width: auto;" align="justify">(if, the Enterprise submitted the claim applications for sanction of 25% Land cost, the GM, DIC concerned should not consider the land value for computation of fixed capital investment)
                                    </td>
                                </tr>

                            </table>
                        </div>



                        <div align="center">
                            <table style="width: 90%">
                                <tr>

                                    <th style="text-align: center; width: auto">Land cost</th>
                                    <th style="text-align: center; width: auto">Stamp Duty& Regn. Fees</th>
                                    <th style="text-align: center; width: auto;">Total</th>
                                    <th style="text-align: center; width: auto; text-wrap: inherit">Approved Project cost</th>
                                    <th style="text-align: center; width: 10px; text-wrap: inherit">Proportionate eligible value</th>
                                </tr>
                                <tr>
                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtLndCst25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>


                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtRegnFee25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>


                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtTotal25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>

                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtAprdPjCst25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>

                                    <td style="width: auto" align="center">
                                        <asp:TextBox ID="txtProprtn25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>


                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-left: 80px; vertical-align: bottom; text-decoration-style: solid">Computed Total
                                    </td>
                                    <td style="padding-top: 20px; padding-left: 15px; align-self: center; width: auto">
                                        <asp:TextBox ID="txtComputedcost"  runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                        </div>

                        <div align="left">
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding-top: 7px"></td>
                                </tr>
                                <tr>
                                     <td style="padding: 5px; margin: 5px;">4.2.0	Building and other civil works

                                    </td>
                                    <td style="width: 30px">:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBldgCvlWrksCst"  class="form-control txtbox" Height="28px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>

                                    <td>

                                    </td>

                                </tr>
                        
                                 <tr>
                                     <td style="padding: 5px; margin: 5px;">4.2.1 Approved Project cost :

                                    </td>
                                    <td style="width: 30px">:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtApprdPjCost"  class="form-control txtbox" Height="28px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                                    </td>

                                    <td>

                                    </td>

                                </tr>

                            </table>

                        </div>

                        <div align="center">
                            <table style="width: 75%">

                                <tr>
                                    <td style="padding-top: 30px"></td>
                                </tr>
                                <tr>
                                    <th>4.2.2
                                    </th>

                                    <th style="text-align: center; padding-left: 10px; max-width: 20px; text-wrap: inherit">Value of the items 8.2.2  to  8.2.10 of guideline</th>


                                    <th align="center" style="text-align: center">Plinth area
                                    </th>

                                    <th style="text-align: center; max-width: 10px; text-wrap: inherit">Rate as per the TSSFC norms
                                    </th>

                                    <th style="text-align: center;">Value
                                    </th>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txtValofItems" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtPlnthArea" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTSSFC" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAprvPJVal" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>


                                </tr>
                                <tr>
                                    <td style="padding-top: 30px"></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Total value of 100 % Items
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAppJTot" runat="server"  class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div>
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding-top: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 50px"></td>
                                    <td style="text-align: justify; align-content: center">Value of the items 8.2.11 to  8.2.17 and similar items of guidelines not to exceed 10% of the total value of the civil works.
                                    </td>

                                </tr>
                            </table>
                        </div>
                        <div align="center">
                            <table>
                                <tr>
                                    <td style="padding-top:10px"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtTotVal1" runat="server"  class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="padding-right:10px">

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotVal2" runat="server"  class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="padding-right:10px">

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotVal3" runat="server"  class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                     <td style="padding-right:10px">

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotVal4" runat="server"  class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            </div>
                        <div>
                           <table>
                               <tr>
                                   <td style="padding-top:20px">

                                   </td>
                               </tr>
                               <tr>
                                   
                                     <td style="display: inline; text-decoration-style: double; white-space: nowrap;">
                                        Total Value 10% Items
                                    
                                   </td>
                                
                                   <td style="padding-right:120px">

                                   </td>
                                   <td>
  <asp:TextBox ID="txtTotVal10" runat="server"  class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                   </td>
                               </tr>
                           </table> 
                        </div>

                          <div>
                           <table>
                               <tr>
                                   <td style="padding-top:20px">

                                   </td>
                               </tr>
                               <tr>
                                   
                                     <td style="display: inline; text-decoration-style: double; white-space: nowrap;">
                                        Grand Total Value 100% + 10% Items
                                    
                                   </td>
                                
                                   <td style="padding-right:25px">

                                   </td>
                                   <td>
  <asp:TextBox ID="txtGrndTotVal" runat="server"  class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                   </td>
                               </tr>
                           </table> 
                        </div>




                        <div align="center">
                            <table style="width:50%">
                                <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        As per approved project cost
                                    </th>
                                    <th>
                                        As per Civil Engineer Certificate
                                    </th>
                                    <th>
                                        Computed value by the GM
                                    </th>
                                </tr>
                                <tr>
                                    <td>
  <asp:TextBox ID="txtAsperApprvdCost" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                
                                    <td>
  <asp:TextBox ID="txtAsperCivilEngr" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                
                                    <td>
  <asp:TextBox ID="txtComptdGm" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>

                              <div>
                           <table>
                               <tr>
                                   <td style="padding-top:20px">

                                   </td>
                               </tr>
                               <tr>
                                   
                                     <td style="display: inline; text-decoration-style: double; white-space: nowrap;">
                                       Computed cost :
                                    
                                   </td>
                                
                                   <td style="padding-right:150px">

                                   </td>
                                   <td>
  <asp:TextBox ID="txtComputedCostApprPrj" runat="server"  class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                   </td>
                               </tr>
                           </table> 
                        </div>




  <div align="left">
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding-top: 7px"></td>
                                </tr>
                                <tr>

                                    <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                        <span style="font-weight: bold; text-decoration: underline">4.3.0   Plant and Machinery and Equipment ( PM&E) :  
 </span>
                                    </td>

                                </tr>
                              

                            </table>

                        </div>



                        <div align="center">
                            <table style="width:80%">
                                <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                       As per approved project cost
                                    </th>
                                    <th>
                                        As per list of Plant & Machinery
                                    </th>
                                    <th style="text-align: center; width: 30px; text-wrap: inherit">
                                        Tech. Know how and study and turnkey charges not to exceed 10% of PM & E
                                    </th>
                                       <th style="padding-right:1px">

                                    </th>
                                    <th>
                                        2nd hand machinery Value

                                    </th>
                                 
                                  
                                    <th>
                                        % of 2nd hand  Machinery

                                    </th>
                                    <th>
                                       Total
                                    </th>
                                </tr>
                                <tr>
                                    <td>
  <asp:TextBox ID="txtAsperApprPjCostPM" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                
                                    <td>
  <asp:TextBox ID="txtAsperListPM" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                
                                    <td>
  <asp:TextBox ID="txtTechKnowPM" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                     
                                    <td style="padding-right:20px">

                                    </td>
                                        <td>
  <asp:TextBox ID="txt2ndMachPM" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                     <td>
  <asp:TextBox ID="txtPrcnt2ndMach" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                        <td>
  <asp:TextBox ID="txtTotal2ndHandMach" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        Computed Cost:
                                    </td>
                                    <td>
<asp:TextBox ID="txtTot2ndMach" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                       
                        </div>

  <div align="left">
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding-top: 7px"></td>
                                </tr>
                                <tr>

                                    <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                        <span style="font-weight: bold; text-decoration: underline">4.4.0.	Total Cost computed:
 </span>
                                    </td>

                                </tr>
                              

                            </table>

                        </div>

                          <div align="center">
                            <table style="width: 50%">
                                <tr>
                                <td>
                                    Land (4.1.5)
                                </td>
                                    <td>
<asp:TextBox ID="txtTotCstCmptdLand" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    Buildings (4.2.7)
                                </td>
                                    <td>
<asp:TextBox ID="txtTotCstCmptdBldg" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>

                                  <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                <td>
                                  Plant & Machinery (4.3.2)
                                </td>
                                    <td>
<asp:TextBox ID="txtTotCstCmptdPlntMach" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>


                                     <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                <td>
                                  Total
                                </td>
                                    <td>
<asp:TextBox ID="txtTotCstCmptdTotal" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>

                              

                            </table>

                        </div>


                          <div align="center">
                            <table style="width: 50%">
                                <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <span lang="EN-US">Investment Subsidy</span></td>
                                    <td>
<asp:TextBox ID="txtInvSubsidyVal" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <span lang="EN-US"> An Additional Investment Subsidy for Women entrepreneurs. </span>
                                </td>
                                    <td>
<asp:TextBox ID="txtAddnInvSubsdyWmn" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>

                                  <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                <td>
                                   
                                          <span lang="EN-US">Investment subsidy for SC/ST entrepreneurs @35% </span>
                                   
                                </td>
                                    <td>
<asp:TextBox ID="txtInvSubsdySCST" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>

                                    <tr>
                                <td>
                                   
                                          <span lang="EN-US">An additional investment subsidy for Women entrepreneurs set up in Scheduled areas @10%  </span>
                                   
                                </td>
                                    <td>
<asp:TextBox ID="txtAddnInvSbsdySc10Prcnt" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>

                                     <tr>
                                    <td style="padding-top:10px">

                                    </td>
                                </tr>
                                <tr>
                                <td>
                                  Total
                                </td>
                                    <td>
<asp:TextBox ID="txtTotalInv" runat="server" Enabled="true" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="padding-left:78px">

                                    </td>

                                </tr>

                              

                            </table>

                        </div>


                       

                            <div>
                                <table style="width: auto">
                                    <tr>
                                        <td style="display: inline; text-decoration-style: double; white-space: nowrap;">

                                            <span style="font-weight: bold; text-decoration: underline">2.0 Verification Certificate:</span>
                                        </td>
                                    </tr>
                                    <tr>                                     

                                        <td style="padding: 3px; margin: 3px; width: auto;" align="justify">Recommended for sanction of investment subsidy mentioned below:
                                        </td>
                                    </tr>                                 

                                </table>

                                <div align="center">
                                    <table>
                                         <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="chkInvSubs" runat="server" />
                                        </td>
                                        <td>
                                            Pavalla vaddi
                                        </td>
                                    </tr>

                                              <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="chkStmpDuty" runat="server" />
                                        </td>
                                        <td style="width:auto;white-space:nowrap">
                                            Application For Transport Vehicle Under T-Pride
                                        </td>
                                    </tr>

                                            <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </td>
                                        <td>
                                            Power Cost Reimbursement
                                        </td>
                                    </tr>

                                                    <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                        </td>
                                        <td>
                                            Specific Cleaner Production measures
                                        </td>
                                    </tr>
                                        
                                             <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox3" runat="server" />
                                        </td>
                                        <td>
                                            Sales TAX(VAT/GST/SGST) Reimbursement
                                        </td>
                                    </tr>


                                                 <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox4" runat="server" />
                                        </td>
                                        <td>
                                            Investment Subsidy
                                        </td>
                                    </tr>

                                                   <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox5" runat="server" />
                                        </td>
                                        <td style="width:auto;white-space:nowrap">
                                            Industrial Infrastructure Development Fund(IIDF)
                                        </td>
                                    </tr>

                                                       <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox6" runat="server" />
                                        </td>
                                        <td style="width:auto;white-space:nowrap">
                                            Reimbursement of cost involved in skill upgradation and training
                                        </td>
                                    </tr>
                                          <tr>
                                       
                                        
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox7" runat="server" />
                                        </td>
                                        <td style="width:auto;white-space:nowrap">
                                            Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost
                                        </td>
                                    </tr>

                                      <tr>
                                       
                                        
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox10" runat="server" />
                                        </td>
                                        <td style="width:auto;white-space:nowrap">
                                            Seed Capital Assistance for 1st generation Entrepreneur for Micro Enterprise
                                        </td>
                                    </tr>

                                                           
                                                               <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox12" runat="server" />
                                        </td>
                                        <td style="width:auto;white-space:nowrap">
                                            Reimbursement of all expenses incurred for Quality Certification/Patent Registration
                                        </td>
                                    </tr>

                                              
                                                               <tr>
                                        <td>                                             
                                            <asp:CheckBox ID="CheckBox14" runat="server" />
                                        </td>
                                        <td>
                                            Advance Subsidy before DCP for SC/ST Enterprises
                                        </td>
                                    </tr>


                                        </td>
                                    </tr>

                                    </table>
                                </div>


                                <div align="center">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit Report" OnClick="btnSubmit_Click" Width="128px" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>










                        <div align="center">
                            <table style="width: 100%">
                                <tr>

                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>


                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                            <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                        <asp:HiddenField ID="HiddenField3" runat="server" />

                                    </td>
                                </tr>
                            </table>
                        </div>




                    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


