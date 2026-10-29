<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ComplncDashBoard.aspx.cs" Inherits="UI_TSiPASS_ComplncDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .grid-container {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 16px;
            padding: 16px;
        }

        .card {
            border: 1px solid #ccc;
            border-radius: 4px;
            padding: 16px;
            background-color: #f9f9f9;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            cursor: pointer;
            transition: background-color 0.3s ease, transform 0.3s ease;
        }

            .card:hover {
                background: #c69942;
                transform: translateY(-5px);
            }

            .card.active {
                background: #c69942; /* Highlight active card */
                transform: translateY(0);
            }

            .card h3 {
                margin-top: 0;
            }

            .card p {
                margin: 8px 0;
            }

        .details-section {
            margin-top: 20px;
            display: none; /* Hidden by default */
        }

        .grid-view {
            width: 100%;
            border-collapse: collapse;
        }

            .grid-view th, .grid-view td {
                border: 1px solid #ccc;
                padding: 8px;
                text-align: left;
            }

            .grid-view th {
                background-color: #f2f2f2;
            }
    </style>
    <script type="text/javascript">
        function setActiveCard(cardId) {
            // Remove active class from all cards
            document.querySelectorAll('.card').forEach(function (card) {
                card.classList.remove('active');
            });

            // Add active class to clicked card
            document.getElementById(cardId).classList.add('active');

            // Hide all details divs
            document.querySelectorAll('.details-section').forEach(function (detail) {
                detail.style.display = 'none';
            });

            // Show the selected details section
            document.getElementById(detailsId).style.display = 'block';
        }

    </script>



    <div>
        <div class="panel-heading">
            <h3 class="panel-title">APPLICATION DETAILS</h3>
        </div>
        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">

            <tr>
                <td align="center" style="padding: 5px; margin: 5px; height: 102px;">
                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label353" runat="server" CssClass="LBLBLACK" Width="165px"
                                    Font-Bold="True">1. Name of the Industry</asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="labNameandAddress" runat="server" CssClass="LBLBLACK"
                                    Width="150px"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label355" runat="server" CssClass="LBLBLACK" Width="165px"
                                    Font-Bold="True">2. 
                            Line of Activity</asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="labLineofActivity" runat="server" CssClass="LBLBLACK"
                                    Width="165px"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label357" runat="server" CssClass="LBLBLACK" Width="165px"
                                    Font-Bold="True">3. 
                            Total Investment</asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="labTotalInvestment" runat="server" CssClass="LBLBLACK"
                                    Width="165px"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px"
                                    Font-Bold="True">4. 
                            Industry Scale</asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="lblindustryscale" runat="server" CssClass="LBLBLACK"
                                    Width="165px"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td align="center" style="padding: 5px; margin: 5px; height: 102px;"></td>
                <td align="center"
                    style="padding: 5px; margin: 5px; height: 102px; vertical-align: top;">
                    <table cellpadding="4" cellspacing="5"
                        style="width: 100%; vertical-align: top;">

                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label362" runat="server" CssClass="LBLBLACK" Width="165px"
                                    Font-Bold="True">5. Address of the Industry</asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="labNameandAddress0" runat="server" CssClass="LBLBLACK"
                                    Width="150px"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px"
                                    Font-Bold="True">6. Risk Category</asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="lblriskcategory" runat="server" CssClass="LBLBLACK"
                                    Width="150px"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px"
                                    Font-Bold="True">7. Organization Compliance Rating</asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="lblCmplncRtg" runat="server" CssClass="LBLBLACK"
                                    Width="150px"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">* For Reference *</asp:Label>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td>
                                <table border="1" cellpadding="8" cellspacing="0">

                                    <tr>
                                        <th>Rating/ Grade</th>
                                        <th>Compliance Score</th>
                                    </tr>
                                    <tr>
                                        <td>AAA</td>
                                        <td>95% to 100%</td>
                                    </tr>
                                    <tr>
                                        <td>AA</td>
                                        <td>90% to 94%</td>
                                    </tr>
                                    <tr>
                                        <td>B+</td>
                                        <td>80% to 89%</td>
                                    </tr>
                                    <tr>
                                        <td>B+</td>
                                        <td>Below 79%</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

        </table>


    </div>



    <p class="grid-container">
        <button id="newLicenseCard" class="card" data-toggle="collapse" href="#collapseExample" onclick="setActiveCard('newLicenseCard')" role="button" aria-expanded="false" aria-controls="collapseExample">
            New License Details
        </button>
        <button id="ActivelicenseCard" class="card" type="button" data-toggle="collapse" data-target="#collapseActvLicense" onclick="setActiveCard('ActivelicenseCard')" aria-expanded="false" aria-controls="collapseActvLicense">
            Active License & Renewal
        </button>
        <button id="InspectionCard" class="card" type="button" data-toggle="collapse" data-target="#collapseInspection" onclick="setActiveCard('InspectionCard')" aria-expanded="false" aria-controls="collapseInspection">
            Inspection Details
        </button>
    </p>

    <div class="collapse" id="collapseExample">
        <div class="body-content">
            <h3 class="header-top-quaternary">New License Details</h3>
            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Height="62px" Width="100%" Font-Names="Verdana"
                Font-Size="12px" OnRowDataBound="grdDetails_RowDataBound">
                <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                <RowStyle CssClass="GridviewScrollC1Item" />
                <PagerStyle CssClass="GridviewScrollC1Pager" />
                <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
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
                    <asp:BoundField DataField="UIDNO" ItemStyle-HorizontalAlign="Left" HeaderText="Application No" />

                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblRENENTERPID" Text='<%#Eval("RENENTERPID") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Left"
                        HeaderText="Applied Date" />

                    <asp:TemplateField HeaderText="ApplicationNo" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblApplicationFiledDate" Text='<%#Eval("ApplicationFiledDate") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="View Application">
                        <ItemTemplate>
                            <asp:HyperLink ID="anchortaglink" runat="server" Text="View" Font-Bold="true" ForeColor="Green"
                                Target="_blank" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:BoundField DataField="PendingQueries" ItemStyle-HorizontalAlign="Center" HeaderText="Pending Queries" />--%>
                    <asp:TemplateField HeaderText="Questionnaireid" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblRENINTQNREID" Text='<%#Eval("RENintqnreid") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ApprovalStatus" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblApprovalStatus" Text='<%#Eval("Approval_Status") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Respond to Query" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hplQueries" runat="server" Text='<%#Eval("PendingQueries") %>'
                                Width="150px" Font-Bold="true" ForeColor="Green" Target="_blank" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Respond to Rejection" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hplRejection" runat="server" Text='<%#Eval("PendingPreRejection") %>'
                                Width="150px" Font-Bold="true" ForeColor="Green" Target="_blank" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ApprovalRejection" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblApplApprRejection" Text='<%#Eval("PendingAprRejection") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:HyperLink ID="anchortaglinkStatus" runat="server" Text="Track" Font-Bold="true"
                                ForeColor="Green" Target="_blank" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>



    <div class="collapse" id="collapseActvLicense">
        <div class="body-content">
            <h3 class="header-top-quaternary">Active License and Renewal Details</h3>
            <asp:GridView ID="ActvlRenGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Height="62px" Width="100%" Font-Names="Verdana"
                Font-Size="12px" OnRowDataBound="ActvlRenGridView_RowDataBound" OnDataBound="ActvlRenGridView_DataBound">
                <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                <RowStyle CssClass="GridviewScrollC1Item" />
                <PagerStyle CssClass="GridviewScrollC1Pager" />
                <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                <Columns>
                    <asp:BoundField DataField="SNO" HeaderText="SNO" />
                    <asp:BoundField DataField="APPLICATIONID" HeaderText="Application ID" />
                    <asp:BoundField DataField="SERVICENAME" HeaderText="Service Name" />
                    <asp:BoundField DataField="LICENSENO" HeaderText="License No" />
                    <asp:BoundField DataField="DATEOFISSUE" HeaderText="Date of Issue" />
                    <asp:TemplateField HeaderText="View Document">
                        <ItemTemplate>
                            <a href='<%# Eval("VIEWDOCUMENT") %>' target="_blank">View</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="VALIDITYOFLICENSE" HeaderText="Validity of License" />
                    <asp:BoundField DataField="VALIDIDTYDATE" HeaderText="Validity Date" />
                    <asp:BoundField DataField="RENEWALDUE" HeaderText="Renewal Due" />
                    <asp:BoundField DataField="NOTIFICATION" HeaderText="Notification" />
                    <asp:BoundField DataField="ISRENEWALDUE" HeaderText="Is Renewal Due" />
                    <asp:BoundField DataField="RENEWALBEFOREDUEDATE" HeaderText="Renewal Before Due Date" />
                    <asp:BoundField DataField="ACTRULES" HeaderText="Act Rules" />
                    <asp:TemplateField HeaderText="Link to Apply Renewal">
                        <ItemTemplate>
                            <a href='<%# Eval("LINKTOAPPLYRENEWAL") %>' target="_blank">Apply Renewal</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PENALPROVISION" HeaderText="Penal Provision" />
                    <asp:TemplateField HeaderText="Compliance Status">
                        <ItemTemplate>
                            <asp:Label ID="lblComplianceStatus" runat="server" Text='<%# Eval("COMPLIANCESTATUS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="collapse" id="collapseInspection">
        <div class="body-content">
            <h3 class="header-top-quaternary">Inspection Details</h3>
            <asp:GridView ID="InspCmplncGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Height="62px" Width="100%" Font-Names="Verdana"
                Font-Size="12px">
                <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                <RowStyle CssClass="GridviewScrollC1Item" />
                <PagerStyle CssClass="GridviewScrollC1Pager" />
                <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                <Columns>
                    <asp:BoundField DataField="DEPARTMENTNAME" HeaderText="Department Name" />
                    <asp:BoundField DataField="NAMEOFESTABLISHMENT" HeaderText="Name of Establishment" />
                    <asp:BoundField DataField="SCHEDULEDINSPECTIONDATE" HeaderText="Scheduled Inspection Date" />
                    <asp:BoundField DataField="INSPECTIONMONTH" HeaderText="Inspection Month" />
                    <asp:BoundField DataField="INSPECTIONYEAR" HeaderText="Inspection Year" />
                    <asp:BoundField DataField="INSPECTIONCONDUCTEDDATE" HeaderText="Inspection Conducted Date" />
                    <asp:BoundField DataField="ALLOCATEDINSPECTOR" HeaderText="Allocated Inspector" />
                    <asp:BoundField DataField="DATEOFUPLOADINGINSPECTIONREPORT" HeaderText="Date of Uploading Inspection Report" />
                    <asp:BoundField DataField="UPLOADWITHIN24HRS" HeaderText="Upload Within 24 Hrs" />
                    <asp:TemplateField HeaderText="Inspection Report">
                        <ItemTemplate>
                            <a href='<%# Eval("INSPECTIONREPORT") %>' target="_blank">View Report</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DISTRICT" HeaderText="District" />
                    <asp:BoundField DataField="REGISTRATIONNO" HeaderText="Registration No" />
                    <asp:BoundField DataField="CATEGORY" HeaderText="Category" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

