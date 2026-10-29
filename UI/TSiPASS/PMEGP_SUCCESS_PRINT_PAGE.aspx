<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMEGP_SUCCESS_PRINT_PAGE.aspx.cs" Inherits="UI_TSiPASS_PMEGP_SUCCESS_PRINT_PAGE" %>


<script runat="server">   
</script>

</script>

<%--    <form id="form2" runat="server">
        <div>
            <asp:Label ID="lblAbbreviation" runat="server" Text=""></asp:Label>
        </div>
    </form>--%>


<html xmlns="http://www.w3.org/1999/xhtml">
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <style>
        @media print {
            @page {
                size: A3;
                margin: 0;
            }

            body {
                transform: scale(1);
                transform-origin: left top;
                width: auto;
            }

            #printButton {
                display: none;
            }
        }

        /* Define landscape mode */
        @page {
            size: 1980px 1080px;
        }

        /* Define page margins */
        body {
            margin: 5px;
        }

        /* Style for left and right columns */
        .column {
            float: left;
            width: 50%;
        }

        .left {
            width: 53%;
            margin-right: 5px;
        }

        .right {
            width: 45%;
            margin-left: 7px;
            //margin-right:0px;
        }
        /* Left Column */
        .left-column {
            width: 40%;
            margin-right: 5px;
        }

        /* Right Column */
        .right-column {
            width: 58%;
            margin-left: 5px;
        }

        /* Style for tables */
        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 5px;
        }

        th, td {
            border: 1px solid #000;
            padding: 5px;
            text-align: left;
        }

        /* Style for image sections */
        .image-section {
            width: 50%;
            float: left;
            margin-top: 5px;
            margin-bottom: 5px;
        }

            .image-section img {
                max-width: 100%;
                height: auto;
                //shape-margin:5px;
            }

        .image {
            max-width: 200px;
            max-height: 200px;
            width: auto;
            height: auto;
        }

        .image1 {
            max-width: 1200px;
            max-height: 200px;
            width: auto;
            height: auto;
        }

        .primary {
            background-color: #007bff; /* Change to your preferred primary color */
            color: #fff; /* Text color */
            border: none; /* Remove the button border */
            padding: 10px 20px; /* Adjust padding as needed */
            cursor: pointer; /* Show a pointer cursor on hover */
            border-radius: 5px; /* Add some rounded corners */
            font-weight: bold; /* Make the text bold */
        }

            .primary:hover {
                background-color: #0056b3; /* Change to a darker shade on hover if desired */
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: Left; font-size: 20px">PMEGP SUCCESS STORIES FORMAT</h1>
        <div class="column left-column">

            <!-- Table 1 -->
            <table style="font-size: 12px">
                <tr>
                    <th colspan="3" style="font-weight: bold; font-size: 14px; text-align: center">BENEFICIARY DETAILS</th>
                </tr>
                <tr>
                    <td width="7px">1</td>
                    <td width="200px" style="font-weight: bold;">APPLICANT NAME</td>
                    <td>
                        <asp:Label ID="Applicantname" runat="server" Text='<%#Eval("ApplicantName") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">2</td>
                    <td style="font-weight: bold;">FATHER/SPOUSE NAME</td>
                    <td>
                        <asp:Label ID="fatherName" runat="server" Text='<%#Eval("FatherorSpouseName") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">3</td>
                    <td style="font-weight: bold;">SOCIAL STATUS</td>
                    <td>
                        <asp:Label ID="Caste" runat="server" Text='<%#Eval("caste") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">4</td>
                    <td style="font-weight: bold;">AGE</td>
                    <td>
                        <asp:Label ID="Age" runat="server" Text='<%#Eval("Age") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">5</td>
                    <td style="font-weight: bold;">EDUCATION QUALIFICATION</td>
                    <td>
                        <asp:Label ID="EducationQualification" runat="server" Text='<%#Eval("Educationalqualifiaction") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">6</td>
                    <td style="font-weight: bold;">SPECIAL CATEGORY</td>
                    <td>
                        <asp:Label ID="SpecialCategory" runat="server" Text='<%#Eval("SpecialCategory") %>'></asp:Label></td>
                </tr>
            </table>

            <!-- Table 2 -->
            <table style="font-size: 12px">
                <tr>
                    <th colspan="3" style="font-weight: bold; font-size: 14px; text-align: center;">ADDRESS</th>
                </tr>
                <tr>
                    <td width="7px">7</td>
                    <td width="200px" style="font-weight: bold;">H.No.</td>
                    <td>
                        <asp:Label ID="HNo" runat="server" Text='<%#Eval("HNO") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">8</td>
                    <td style="font-weight: bold;">STREET</td>
                    <td>
                        <asp:Label ID="Street" runat="server" Text='<%#Eval("Street") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">9</td>
                    <td style="font-weight: bold;">VILLAGE/WARD</td>
                    <td>
                        <asp:Label ID="VillageWard" runat="server" Text='<%#Eval("VillageWard") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">10</td>
                    <td style="font-weight: bold;">MANDAL/MUNICIPALITY</td>
                    <td>
                        <asp:Label ID="Mandalmunicipality" runat="server" Text='<%#Eval("Mandalmunicipality") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">11</td>
                    <td style="font-weight: bold;">DISTRICT</td>
                    <td>
                        <asp:Label ID="District" runat="server" Text='<%#Eval("District") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">12</td>
                    <td style="font-weight: bold;">AREA/REGION</td>
                    <td>
                        <asp:Label ID="AreaorRegion" runat="server" Text='<%#Eval("AreaorRegion") %>'></asp:Label></td>
                </tr>
            </table>

            <!-- Table 3 -->

            <table style="font-size: 12px">
                <tr>
                    <th colspan="3" style="font-weight: bold; font-size: 14px; text-align: center">UNIQUE IDENTIFIERS</th>
                </tr>
                <tr>
                    <td width="7px">13</td>
                    <td width="200px" style="font-weight: bold;">AADHAR NUMBER</td>
                    <td>
                        <asp:Label ID="Aadharnumber" runat="server" Text='<%#Eval("Aadharnumber") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">14</td>
                    <td style="font-weight: bold;">PAN NUMBER</td>
                    <td>
                        <asp:Label ID="Pannumber" runat="server" Text='<%#Eval("Pannumber") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">15</td>
                    <td style="font-weight: bold;">UDYAM REGISTRATION NUMBER</td>
                    <td>
                        <asp:Label ID="Udayamregisternumber" runat="server" Text='<%#Eval("Udayamregisternumber") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">16</td>
                    <td style="font-weight: bold;">RATION CARD NUMBER</td>
                    <td>
                        <asp:Label ID="Rationcradnumber" runat="server" Text='<%#Eval("Rationcradnumber") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">17</td>
                    <td style="font-weight: bold;">CONTACT NUMBER</td>
                    <td>
                        <asp:Label ID="Contactnumber" runat="server" Text='<%#Eval("Contactnumber") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">18</td>
                    <td style="font-weight: bold;">E-MAIL ID</td>
                    <td>
                        <asp:Label ID="Emailid" runat="server" Text='<%#Eval("Emailid") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">19</td>
                    <td style="font-weight: bold;">PMEGP ID</td>
                    <td>
                        <asp:Label ID="PMEGP_ID_TSIPASS" runat="server" Text='<%#Eval("PMEGP_ID_TSIPASS") %>'></asp:Label></td>
                </tr>
            </table>

            <!-- Table 4 -->

            <table style="font-size: 12px">
                <tr>
                    <th colspan="3" style="font-weight: bold; font-size: 14px; text-align: center">TRAINING</th>
                </tr>
                <tr>
                    <td width="7px">20</td>
                    <td width="250px" style="font-weight: bold;">EDP CERTIFICATE FROM WHICH TRAINING INSTITUTE</td>
                    <td>
                        <asp:Label ID="EDPcertifiacte" runat="server" Text='<%#Eval("EDPcertifiacte") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">21</td>
                    <td width="250px" style="font-weight: bold;">ANY OTHER TRAINING PROGRAMS ATTENDED (Y/N)</td>
                    <td>
                        <asp:Label ID="Anyotherprograms" runat="server" Text='<%#Eval("Anyotherprograms") %>'></asp:Label></td>
                </tr>
            </table>

            <!-- Table 5 -->

            <table>
                    <asp:GridView ID="FamilyDetailsGrid" runat="server" AutoGenerateColumns="false" ShowHeader="true" Width="100%" OnRowDataBound="FamilyDetailsGrid_RowDataBound">
                        <Columns>
                            <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="25px" />
                        </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Relation" runat="server" Style="font-weight: bold;" Text='<%#Eval("Person") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <asp:Label ID="Person_Age" runat="server" Text='<%#Eval("Person_Age") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Profession">
                                <ItemTemplate>
                                    <asp:Label ID="Profession" runat="server" Text='<%#Eval("Profession") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: Center">No Records Entered</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </table>
        </div>

        <!-- Right Column -->
        <div class="column right-column">
            <!-- Table 6 -->
            <div class="column left">
                <table style="font-size: 12px">
                    <tr>
                        <th colspan="3" style="font-weight: bold; font-size: 14px; text-align: center">BENEFICIARY DETAILS</th>
                    </tr>
                    <tr>
                        <td width="7px">22</td>
                        <td width="220px" style="font-weight: bold;">UNIT NAME</td>
                        <td>
                            <asp:Label ID="Unitname" runat="server" Text='<%#Eval("Unitname") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="7px">23</td>
                        <td style="font-weight: bold;">LINE OF ACTIVITY</td>
                        <td>
                            <asp:Label ID="Lineofactivity" runat="server" Text='<%#Eval("Lineofactivity") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="7px">24</td>
                        <td style="font-weight: bold;">PRODUCT NAME</td>
                        <td>
                            <asp:Label ID="productname" runat="server" Text='<%#Eval("productname") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="7px">25</td>
                        <td style="font-weight: bold;">UNIT OF PRODUCTION PER ANNUM</td>
                        <td>
                            <asp:Label ID="unitsofproduction" runat="server" Text='<%#Eval("unitsofproduction") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="7px">26</td>
                        <td style="font-weight: bold;">DATE OF COMMENCEMENT OF PRODUCTION(DCP) [DD/MM/YYYY]</td>
                        <td>
                            <asp:Label ID="Dateofcommencementproduction" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="7px">27</td>
                        <td style="font-weight: bold;">EMPLOYMENT</td>
                        <td>
                            <asp:Label ID="Employement" runat="server" Text='<%#Eval("Employement") %>'></asp:Label></td>
                    </tr>
                </table>
            </div>
            <!-- Table 7 -->
            <div class="column right">
                <table style="font-size: 12px">
                    <tr>
                        <th colspan="3" style="font-weight: bold; font-size: 14px; text-align: center">UNIT FINANCIALS(AMOUNT IN LAKHS.)</th>
                    </tr>
                    <tr>
                        <td width="7px">28</td>
                        <td width="200px" style="font-weight: bold;">INVESTMENT</td>
                        <td>
                            <asp:Label ID="Investment" runat="server" Text='<%#Eval("Investment") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="7px">29</td>
                        <td style="font-weight: bold;">BENEFICIARY CONTRIBUTION</td>
                        <td>
                            <asp:Label ID="Benificarycontribution" runat="server" Text='<%#Eval("Benificarycontribution") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="7px">30</td>
                        <td style="font-weight: bold;">BANK LOAN</td>
                        <td>
                            <asp:Label ID="Bankloan" runat="server" Text='<%#Eval("Bankloan") %>'></asp:Label></td>
                    </tr>
                    <%--<tr>
                <td width="7px">30</td>
                <td  style="font-weight:bold;">PRODUCTION</td>
                <td><asp:Label ID="production" runat="server"  Text='<%#Eval("production") %>'></asp:Label></td>
            </tr>--%>
                    <tr>
                        <td width="7px">31</td>
                        <td style="font-weight: bold;">SUBSIDY CLAIM</td>
                        <td>
                            <asp:Label ID="Subsidyclaim" runat="server" Text='<%#Eval("Subsidyclaim") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="7px">32</td>
                        <td style="font-weight: bold;">MM ADJUSTMENT</td>
                        <td>
                            <asp:Label ID="Mmadjustments" runat="server" Text='<%#Eval("Mmadjustments") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="Pmegp_ID" runat="server" Visible="false" Text='<%#Eval("PmegpID") %>'></asp:Label></td>
                    </tr>
                </table>
            </div>

            <!-- Table 8 -->
            <table style="font-size: 12px;">
                <tr>
                    <th colspan="3" style="font-weight: bold; font-size: 14px; text-align: center">PRESENT STATE</th>
                </tr>
                <tr>
                    <td width="7px">33</td>
                    <td width="300px" style="font-weight: bold;">ANNUAL SALES(Rs. IN LAKHS)</td>
                    <td>
                        <asp:Label ID="Annualsales" runat="server" Text='<%#Eval("Annualsales") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">34</td>
                    <td style="font-weight: bold;">ANNUAL PROFITS(Rs. IN LAKHS)</td>
                    <td>
                        <asp:Label ID="Annualprofit" runat="server" Text='<%#Eval("Annualprofit") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">35</td>
                    <td style="font-weight: bold;">LOAN REPAYMENT COMPLETED(Y/N)</td>
                    <td>
                        <asp:Label ID="Loanrepaymentcompleted" runat="server" Text='<%#Eval("Loanrepaymentcompleted") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">36</td>
                    <td style="font-weight: bold;">PHYSICAL VERIFICATION DATE [DD/MM/YYYY]</td>
                    <td>
                        <asp:Label ID="Physicalvericationdate" runat="server"></asp:Label></td>
                </tr>
            </table>

            <!-- Image Section 1 -->
            <div class="image-section">
                <asp:Image ID="Image1" runat="server" alt="Image 1" CssClass="image" />
            </div>

            <!-- Image Section 2 -->
            <div class="image-section">
                <asp:Image ID="Image2" runat="server" alt="Image 2" CssClass="image1" />
            </div>

            <!-- Table 9 -->

            <table style="font-size: 12px;">
                <tr>
                    <th colspan="4" style="font-weight: bold; font-size: 14px; text-align: center">IMPACT ASSESMENT</th>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td style="font-weight: bold; text-align: center;">BEFORE</td>
                    <td style="font-weight: bold; text-align: center;">AFTER</td>
                </tr>
                <tr>
                    <td width="7px">37</td>
                    <td width="350px" style="font-weight: bold;">ASSETS VALUE(AMOUNT IN LAKHS)</td>
                    <td>
                        <asp:Label ID="B_Assetvalue" runat="server" Text='<%#Eval("B_Assetvalue") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="A_Assetvalue" runat="server" Text='<%#Eval("A_Assetvalue") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">38</td>
                    <td style="font-weight: bold;">HOUSE(AREA IN Sq.yards)</td>
                    <td>
                        <asp:Label ID="B_House" runat="server" Text='<%#Eval("B_House") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="A_House" runat="server" Text='<%#Eval("A_House") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">39</td>
                    <td style="font-weight: bold;">LAND(AREA IN ACRES)</td>
                    <td>
                        <asp:Label ID="B_Land" runat="server" Text='<%#Eval("B_Land") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="A_Land" runat="server" Text='<%#Eval("A_Land") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">40</td>
                    <td style="font-weight: bold;">VEHICLES(2/4 WHEELER)</td>
                    <td>
                        <asp:Label ID="B_Vehicles" runat="server" Text='<%#Eval("B_Vehicles") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="A_Vehicles" runat="server" Text='<%#Eval("A_Vehicles") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">41</td>
                    <td style="font-weight: bold;">HEALTH(TREATMENT FROM GOVT/PVT)</td>
                    <td>
                        <asp:Label ID="B_Health" runat="server" Text='<%#Eval("B_Health") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="A_Health" runat="server" Text='<%#Eval("A_Health") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">42</td>
                    <td style="font-weight: bold;">CHILDREN EDUCATION(GOVT/PVT)</td>
                    <td>
                        <asp:Label ID="B_Childreneducation" runat="server" Text='<%#Eval("B_Childreneducation") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="A_Childreneducation" runat="server" Text='<%#Eval("A_Childreneducation") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td width="7px">43</td>
                    <td style="font-weight: bold;">RE-INVESTMENT(EXPANSION)(AMOUNT IN LAKHS)</td>
                    <td>
                        <asp:Label ID="B_Reinvestments" runat="server" Text='<%#Eval("B_Reinvestments") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="A_Reinvestments" runat="server" Text='<%#Eval("A_Reinvestments") %>'></asp:Label></td>
                </tr>
            </table>
            <br />
            <button id="printButton" class="primary">Print</button>
        </div>
    </form>
    <script>
        document.getElementById('printButton').addEventListener('click', function () {
            window.print();
        });
    </script>
</body>
</html>
