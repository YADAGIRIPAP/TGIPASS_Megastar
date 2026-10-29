<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="frmPulgandplayDetails.aspx.cs" Inherits="UI_TSiPASS_frmPulgandplayDetails" %>

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

        .style7 {
            width: 42px;
        }

        .style8 {
            height: 30px;
        }

        .style9 {
            width: 27px;
            height: 30px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>



    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i></i><a href="Home.aspx">Home</a></li>
                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                    <li class="active"><i></i>PLUG AND PLAY
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">PLUG AND PLAY</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="background-color: white" align="center">
                                                    <table style="width: 95%">
                                                        <tr style="height: 20px">
                                                            <td></td>
                                                        </tr>
                                                        <%--<tr style="height: 40px; padding: 5px; margin: 5px">
                                                <td align="left" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Select Plot
                                                </td>
                                            </tr>--%>
                                                        <tr style="height: 3px">
                                                            <td style="background-color: white"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <table style="width: 100%; background-color: white">
                                                                    <tr style="height: 15px">
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr style="height: 40px">
                                                                        <td style="width: 4%"></td>
                                                                        <td style="width: 15%">District
                                                                        </td>
                                                                        <td style="width: 2%">:
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox" AutoPostBack="true"
                                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0">--District--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td></td>
                                                                        <td style="width: 4%"></td>
                                                                        <td style="width: 15%">Industrial Park/Estate
                                                                        </td>
                                                                        <td style="width: 2%">:
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                            <asp:DropDownList ID="ddlIndustrialParkName" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="250px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 80px">
                                                                        <td align="center" colspan="12" valign="middle">
                                                                            <asp:Button Text="Know Your Approvals" Height="35px" Width="200px" Font-Size="Large" CssClass="btn btn-primary"
                                                                                ForeColor="White" ID="btntab1next" runat="server" OnClick="btntab1next_Click" />
                                                                            <asp:Button Text="Clear" Height="35px" Width="200px" Font-Size="Large" CssClass="btn btn-primary"
                                                                                ForeColor="White" ID="btnclear" runat="server" OnClick="btnclear_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="plotdetails" runat="server" visible="false">
                                                                        <td style="width: 100%; background-color: white" colspan="12" align="center">
                                                                            <table style="width: 7%; background-color: white">
                                                                                <tr style="height: 30px">
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr style="height: 40px">
                                                                                    <td style="width: 4%"></td>
                                                                                    <td style="width: 30%" align="left">Select Plot
                                                                                    </td>
                                                                                    <td style="width: 2%">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlavailableplots" runat="server" class="form-control txtbox" AutoPostBack="true"
                                                                                            Height="33px" Width="220px" OnSelectedIndexChanged="ddlavailableplots_SelectedIndexChanged">
                                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>

                                                                                </tr>
                                                                                <tr style="height: 40px">
                                                                                    <td style="width: 4%"></td>
                                                                                    <td style="width: 30%" align="left">Area (In Sq. Mtrs)
                                                                                    </td>
                                                                                    <td style="width: 2%">:
                                                                                    </td>
                                                                                    <td id="tdAreasqrmtrs" runat="server" align="left"></td>
                                                                                </tr>
                                                                                <tr style="height: 40px">
                                                                                    <td style="width: 4%"></td>
                                                                                    <td style="width: 30%" align="left">Price(Rs. Per Sq. Mtrs)
                                                                                    </td>
                                                                                    <td style="width: 2%">:
                                                                                    </td>
                                                                                    <td id="tdrssqmtrs" runat="server" align="left"></td>
                                                                                </tr>
                                                                                <tr style="height: 30px">
                                                                                    <td></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr id="pre1" runat="server" visible="false" style="height: 30px">
                                                                        <td align="left" colspan="12" style="background-color: burlywood;" >
                                                                            <h3><b>Pre Approval Clearances</b></h3>
                                                                        </td>

                                                                    </tr>
                                                                    <tr id="pre2" runat="server" visible="false">
                                                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                                                        <td style="padding: 5px; margin: 5px;" colspan="8" align="left">
                                                                            <asp:GridView ID="gvmodelsnames" TabIndex="41" runat="server" Width="1000px" border="0"
                                                                                CellPadding="4" AutoGenerateColumns="false" HorizontalAlign="Left" EnableModelValidation="True"
                                                                                ForeColor="#333333" GridLines="both">
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="srn" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="list" HeaderText="List of infrastructure and facilities/services ">
                                                                                        <ItemStyle Width="450px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                                                                        <ItemStyle Width="150px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Details" HeaderText="Details">
                                                                                        <ItemStyle Width="300px" />
                                                                                    </asp:BoundField>
                                                                                     <%--<asp:BoundField DataField="District" HeaderText="District">
                                                                                        <ItemStyle Width="180px" />
                                                                                    </asp:BoundField>
                                                                                     <asp:BoundField DataField="DistrictID" HeaderText="District ID">
                                                                                        <ItemStyle Width="180px" />
                                                                                    </asp:BoundField>
                                                                                     <asp:BoundField DataField="IPID" HeaderText="IP ID">
                                                                                        <ItemStyle Width="180px" />--%>
                                                                                    <%--</asp:BoundField>--%>
                                                                                </Columns>
                                                                                <EditRowStyle BackColor="#7C6F57" />
                                                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                                <RowStyle BackColor="#E3EAEB" />
                                                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="pre3" runat="server" visible="false">
                                                                        <td align="left" colspan="12" valign="left">
                                                                            <h4><b>Pending
                                                                                </b>
                                                                            </h4>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 80px">
                                                                        <td>

                                                                        </td>
                                                                    </tr>
                                                                    <tr id="remaing1" runat="server" visible="false" style="height: 30px">
                                                                        <td align="left" colspan="12" style="background-color: burlywood;">
                                                                            <h3><b><span style="color: red">*</span>Remaning Approval Clearances</b></h3>
                                                                        </td>

                                                                    </tr>
                                                                    <tr id="remaing2" runat="server" visible="false">
                                                                        <td align="left" colspan="12" valign="left">
                                                                            <h4>For the remaining approvals required to be obtained by the manufacturing unit for starting the unit, the procedures and rules
                                                                                with applicable timelines for obtaining the same can be viewed from
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" target="_blank" href="UI/TSiPASS/frmQuestionnaireCFE.aspx"><span style="color: blue">Pre-Establishment Approvals(CFE)</span></asp:LinkButton>
                                                                              
                                                                            </h4>
                                                                        </td>

                                                                    </tr>

                                                                    <tr id="zone" runat="server" visible="false">
                                                                        <td style="width: 100%; background-color: white; color: red" colspan="12" align="center">Note: In Case of smaller plot area is required, please contact Zonal manager to examine the feasibility of Sub-Division
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 10px; background-color: white;">
                                                                        <td colspan="10"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 40px">
                                                            <td></td>
                                                        </tr>
                                                        <tr id="plot" runat="server" visible="false">
                                                            <td align="right">
                                                                <asp:Button ID="BtnAddSelectedplos" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                    TabIndex="10" Text="Add to My Selected Plots"
                                                                    Width="220px" OnClick="BtnAddSelectedplos_Click" />
                                                                &nbsp;&nbsp;&nbsp;
                                              <asp:Button ID="PlotsReset" runat="server" CssClass="btn btn-primary" Height="32px"
                                                  TabIndex="10" Text="Reset"
                                                  Width="100px" OnClick="PlotsReset_Click" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 40px">
                                                            <td></td>
                                                        </tr>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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

