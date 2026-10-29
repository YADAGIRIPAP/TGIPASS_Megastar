<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCOI_SPEECH.aspx.cs" Inherits="UI_TSiPASS_frmCOI_SPEECH" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .leftalign {
            text-align: left;
        }

        .rightalign {
            text-align: right;
        }

        .floatleft {
            float: left;
        }

        body {
            background-color: #ffffff;
        }
    </style>
    <style type="text/css">
        .auto-style3 {
            text-align: justify;
        }

        p.Style {
            margin-bottom: .0001pt;
            text-autospace: none;
            font-size: 12.0pt;
            font-family: "Times New Roman","serif";
            margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
    </style>
     <script type="text/javascript">

       function myFunction() {
           //document.getElementById("Div2").style.visibility = "hidden";
           document.getElementById("Div2").style.display = "none";
           //$("#Button2").hide();
           window.print();
           // $("#Button2").show();
           document.getElementById("Div2").style.display = "block";
       }
   </script>
</head>
<body>

    <form id="form1" runat="server" style="font-family: 'Times New Roman'; font-size: 1em;">
        <div class="container" style="border: 3px solid #000000; text-align: center; font-family: 'Times New Roman'; font-size: 1em;">
            <div style="padding-top: 10px; font-family: 'Times New Roman'; font-size: 1em;">
            </div>
            <b style="font-family: 'Times New Roman'; font-size: 1em;">
                <asp:Label Font-Bold="true" Font-Size="Large" ID="lblheadTPRIDE" runat="server">Director of Industries</asp:Label></b><br />
            <b style="font-family: 'Times New Roman'; font-size: 1em;">
                <asp:Label ID="lblCoiDipcHead" Font-Bold="true" Font-Size="Large" runat="server"
                    Text="Note on Industries Department"></asp:Label></b>&nbsp;<b style="font-family: 'Times New Roman'; font-size: 1em;"><asp:Label ID="lblyear" Visible="false" Font-Bold="true" Font-Size="Large" Text="<<>>" runat="server"></asp:Label></b>
            <br />
            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <p class="floatleft auto-style3">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Government of Telangana has identified industrialization as the key strategy for the economic growth of the State. With a view to attract international and national investments in the industrial sector and to create employment opportunities even in the backward areas of the State, the Government of Telangana has taken innovative initiatives and framed the New Industrial Policy, with a vision of "Research to Innovation; Innovation to Industry; Industry to Prosperity" and Slogan of Telangana Industrial Policy is "In Telangana — Innovate, Incubate, Incorporate". The New Industrial Policy 2015 has provided a business regulatory environment where doing business has become as easy as "shaking hands". </span>
                </p>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 12px; font-family: 'Times New Roman'; font-size: 1em;">
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15" style="font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft" style="font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">Industrial Policy Frame Work: </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3" style="font-family: 'Times New Roman'; font-size: 1em;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The Industrial Policy focused on creating State of the art infrastructure, providing hassle free mechanism for obtaining clearances, creating conducive atmosphere for doing business and incentivisation of the investments to the extent unparalleled by any other State government policies. The Industrial Policy Framework has a mandate of" Minimum Inspection and Maximum Facilitation" for departments that have a responsibility in the industrialization of the State. It emphasizes on effective Industrial Clearance mechanism which functions at three levels- Mega Projects, Large Industries and SMEs.<br />
                    <br />
                    <p class="floatleft auto-style3">
                        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The most important initiative of the Government is earmarking government lands to the industrial sector. Telangana government has identified an extent of 150,000 acres of Government land has been transferred to Telangana State Industrial Investment Corporation (TSIIC) which is ready to be occupied for industrial purposes. In addition, TSIIC also has 300 ready to occupy Industrial Parks. Activity based parks being developed topromote industrialization in Pharmacity Hyderabad at Mucherla in RangareddyDistrict, MegaTextile park at Warangal , Medical devices park at Sulthanpur(V) in SangareddyDistrict, &nbsp;Electronics Manufacturing Cluster at Maheshwaram(V) Food park at Buggapahad (V) Khammam District, MSME Industrial Park at Dandumalkapur (V) YadadriBhonagiri District, Spice park at VelpurNizamabadDistrict,Agroprocessing park at Bandamilaram(V) in Siddipet District,Autonagar at Miryalaguda (V) &amp;Kundanpally, Nalgonda District,Autonagar at RamagundamPeddapally district and Plastic park 
                    at Thummalur(V) Rangareddy District etc,.<o:p></o:p></span>
                    </p>
                    <p class="floatleft auto-style3">
                        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The Government of Telangana committed to providing quality and uninterrupted power supply to the industrial sector. The State has successfully overcome the power shortage problem and has provided uninterrupted power to Industrial sector.<o:p></o:p></span>
                    </p>
                    <p class="floatleft auto-style3">
                        <span>To support industrialization, the Government of Telangana has earmarked 10% of water from all existing and new irrigation sources for industrial use<o:p></o:p></span>
                    </p>
                    &nbsp;</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3" style="font-family: 'Times New Roman'; font-size: 1em;">TS-iPASS (Telangana State Industrial Project Approval And Self Certification System):
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">

                <p class="floatleft auto-style3" style="margin-top: 12.7pt; margin-right: 2.85pt; margin-bottom: 0cm; margin-left: .2pt; margin-bottom: .0001pt; mso-add-space: auto; text-align: justify; text-indent: 35.5pt; line-height: 16.75pt; mso-line-height-rule: exactly; font-family: 'Times New Roman'; font-size: 1em;">
                    The Government of Telangana has enacted the TS-iPASS (Telangana State Industrial Project Approval and Se1f Certification System) Act for providing all approvals to the entrepreneurs within set time limits based on a self-certification furnished by the entrepreneurs. Mega projects will get automatic approvals on submission of the self-certification. All applicants will be bestowed with a right to clearance under the TS-iPASS. There is a provision of imposing penalties to the officers who fail to provide the clearance within set time.
                </p>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <p class="Style" style="margin-top: 12.7pt; margin-right: 2.85pt; margin-bottom: 0cm; margin-left: .2pt; margin-bottom: .0001pt; mso-add-space: auto; text-align: justify; text-indent: 35.5pt; line-height: 16.75pt; mso-line-height-rule: exactly; font-family: 'Times New Roman'; font-size: 1em;">
                    Till date <b>
                        <asp:Label ID="lbltotalnoofunits" runat="server" Text="<<>>"></asp:Label></b> units with proposed investment of <b>
                            <asp:Label ID="lbltotalinvestment" runat="server" Text="<<>>"></asp:Label>
                            Cr.</b> and proposed employment of <b>
                                <asp:Label ID="lbltotalemployment" runat="server" Text="<<>>"></asp:Label></b>
                    &nbsp;<span>have obtained approvals. A total of
                    <b>
                        <asp:Label ID="lbltotalunits_commenced" runat="server" Text="<<>>"></asp:Label></b>
                        &nbsp; units with an investment of <b>
                            <asp:Label ID="lbltotalinvestment_commenced" runat="server" Text="<<>>"></asp:Label>
                            Cr</b> and providing employment to <b>
                                <asp:Label ID="lbltotalemployment_commenced" runat="server" Text="<<>>"></asp:Label></b> persons have commenced operations.  <b>
                                    <asp:Label ID="lblpercentageofunits" runat="server" Text="<<>>" Visible="false"></asp:Label></b> &nbsp;</span>
                </p>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3">Ease of Doing Business(EODB):   </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <p class="floatleft auto-style3">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The Department for Promotion of Industry and Internal Trade (DPIIT), Ministry of Commerce &amp; Industry, Government of India has taken up a series of measures to improve Ease of Doing Business. The emphasis has been on simplification and rationalization of the existing rules and introduction of Information technology to make governance more efficient and effective. DIPP, every year is communicating a set of reforms to all states and is ranking the states based on level of compliance of these reforms by the states</span>
                </p>
                <p class="floatleft auto-style3">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Telangana stood among the top states in Ease of Doing Business (EODB). For the year <b>
                        <asp:Label ID="lblyear_EODB" runat="server" Text="<<>>"></asp:Label></b> , DPIIT has communicated set of <b>
                            <asp:Label ID="LBLSETODREFORMS" runat="server" Text="<<>>"></asp:Label></b> reforms to be implemented across various departments and the ranking methodology is purely based on feedback score.  <b>
                                <asp:Label ID="LBLYEAR_TOPACHIEVER" runat="server" Visible="false" Text="<<>>"></asp:Label></b><o:p></o:p></span>
                </p>
                
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3">Simplification of Acts & Regulations:    </span>
            </div>
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
            <p class="floatleft auto-style3">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
DPIIT, GoI shared certain acts and regulations pertaining to Telangana State and requested to examine various state acts and regulations in order to rationalize/simplify the existing processes of implementation of the same.
A total of 1278 compliances pertaining to 7 Departments are identified for reduction and all compliances are reduced as per the guidelines given by the DPIIT. <o:p></o:p></span>
                </p>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3" style="font-family: 'Times New Roman'; font-size: 1em;">T-IDEA 	(Telangana State Industrial Development and Entrepreneur Advancement):

                </span>
            </div>
            <br />
            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 2px; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3" style="font-family: 'Times New Roman'; font-size: 1em;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The Government of Telangana, through its T-IDEA (Telangana State Industrial Development and Entrepreneur advancement) Incentive scheme 2014 is providing various kinds of incentives to the entrepreneurs. The incentives include Investment Subsidy, Land cost, Stamp Duty, VAT reimbursement, Power cost, Pavala Vaddi reimbursement and many more. These incentives will be released through a transparent on line system in a graft free manner. Government will provide Tailor made benefits to the Mega projects. These incentives will also be extended to the eligible existing industries to stabilize them. 
                <br />
                    <br />
                    <p class="StyleCxSpFirst">
                        <span>Under T-IDEA Scheme, From 02-06-2014, <b>
                            <asp:Label ID="lblclaims_tidea" runat="server" Text="<<>>"></asp:Label></b> claims were sanctioned for an amount of <b>Rs.
                                <asp:Label ID="lblamount_tidea" runat="server" Text="<<>>"></asp:Label>&nbsp;Cr</b><o:p></o:p></span>
                    </p>
                    <p class="StyleCxSpLast">
                        <span>For financial year <b>
                            <asp:Label ID="lblfinancialyear_tidea" runat="server" Text="<<>>"></asp:Label></b>,<b>
                                <asp:Label ID="lblfinancialyearclaims_tidea" runat="server" Text="<<>>"></asp:Label></b> claims were sanctioned for an amount of <b>Rs.<asp:Label ID="lblclaimwisesanctionedamount_tidea" runat="server" Text="<<>>"></asp:Label>&nbsp;Cr</b>
                            <o:p></o:p>
                        </span>
                    </p>
                    <p class="StyleCxSpLast" visible="false" runat="server" >
                        <span>For the financial year <b>2022-2023</b>, Rs.<b>
                            <asp:Label ID="lblbudgetallocated_tidea" runat="server" Text="<<>>"></asp:Label>
                            &nbsp;Cr</b> budjet was allocated,&nbsp;<b>Rs.<asp:Label ID="lblreleasedamount_tidea" runat="server" Text="<<>>"></asp:Label>&nbsp;Cr&nbsp;</b>released, <b>Rs.<asp:Label ID="lblpendingamount_tidea" runat="server" Text="<<>>"></asp:Label>
                                &nbsp;Cr</b><o:p>&nbsp;pending,<b>Rs.<asp:Label ID="lblutilizedamount_tidea" runat="server" Text="<<>>"></asp:Label>&nbsp;Cr</b>&nbsp;utilized.</o:p></span>
                    </p>

                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3" style="font-family: 'Times New Roman'; font-size: 1em;">T -PRIDE (Telangana State Program for Rapid Incubation of Dalit Entrepreneurs):  </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <p class="floatleft auto-style3">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Government of Telangana has recognized an unfortunate reality that a very minute proportion of the existing industrial units are owned by the SC/ST entrepreneurs. As the Social Justice is the foundation of the New State of Telangana, the New Industrial Policy has provided a number of additional benefits to the SC/ST entrepreneurs to increase the entrepreneurship among theSC/STs.
                        <o:p></o:p>
                    </span>
                </p>
                <p class="floatleft auto-style3">
                    <span>An exclusive policy, T-PRIDE (Telangana State Program for Rapid Incubation of Dalit Entrepreneurs), has been announced by the Government of Telangana offering special incentives such as preferential allotment of industrial plots in industrial parks, Providing direct funding and margin money, arranging sub contracts with large industries, additional investment subsidies and other subsidies, creating a pool of civil contractors and etc., Special incentives are also being offered to the women entrepreneurs.
                        <o:p></o:p>
                    </span>
                </p>
                <p class="floatleft auto-style3" runat="server">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Till this day <b>
                        <asp:Label ID="lblNOOFSCAPPLICATIONS" runat="server" Text="<<>>"></asp:Label></b> No of Schedule caste applications are sanctioned subsidies to the tune of <b>Rs.<asp:Label ID="LBLSCSANCTIONEDAMOUNT" runat="server" Text="<<>>"></asp:Label></b> Crores under SCP, for Scheduled tribes <b>
                            <asp:Label ID="LBLNOOFSTAPPLICATIONS" runat="server" Text="<<>>"></asp:Label></b> No of Applications to the tune of <b>Rs.<asp:Label ID="LBLSTSANCTIONEDAMOUNT" runat="server" Text="<<>>"></asp:Label></b> Crores Subsidies sanctioned under TSP and <b>
                                <asp:Label ID="LBLNOOFPHCAPPLICATIONS" runat="server" Text="<<>>"></asp:Label></b> no of applications to the tune of <b>Rs.<asp:Label ID="LBLPHCSANCTIONEDAMOUNT" runat="server" Text="<<>>"></asp:Label>
                                    Cr.</b>  were sanctioned under PHC category.</span>
                </p>
               <%-- <p class="floatleft auto-style3" visible="false" runat="server" >
                    <span>For the financial year <b>2022-2023</b>, Rs.<b>
                        <asp:Label ID="lblbudgetallocatedtpride" runat="server" Text="<<>>"></asp:Label>
                        &nbsp;Cr</b> budjet was allocated,&nbsp;<b>Rs.<asp:Label ID="lblbudgetreleasedtpride" runat="server" Text="<<>>"></asp:Label>&nbsp;Cr&nbsp;</b>released, <b>Rs.<asp:Label ID="lblbudgetpendingtpride" runat="server" Text="<<>>"></asp:Label>
                            &nbsp;Cr</b><o:p>&nbsp;pending,<b>Rs.<asp:Label ID="lblbudgetutilizedtpride" runat="server" Text="<<>>"></asp:Label>&nbsp;Cr</b>&nbsp;utilized.</o:p></span>
                </p>--%>


            </div>
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3">Revival of Sick Units:   </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Government of Telangana set up Industrial Health Clinic as a non-banking finance company (NBFC) , with an initial corpus contribution of 10 Cr, with the following objectives.<asp:Label ID="lblhealthclinicamount" runat="server" Text="<<>>" Visible="false"></asp:Label>
                    
                    <%--of which &nbsp;<b>Rs.--%>
                        <asp:Label ID="lbltelanganagovtfount" runat="server" Text="<<>>" Visible="false"></asp:Label>
                       <%-- Cr</b> is funded by Telangana Govt. --%></br>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.Providing diagnostic and clinical facilities for sick and incipient sick enterprises in co-ordination with the existing financial institutions and extending financial support to the new MSMEs.</br>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2.Help the MSMEs in revival and rehabilitation through effective guidance and timely supplementation of financial resources.
Identify Stategic partnership firms for creating a comfort zone to</br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; the banks to revive the MSEs so that the units come out of NPA status.</br></br>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Till now more than <b>
                            <asp:Label ID="lblsickunits" runat="server" Text="<<>>"></asp:Label></b> sick units were assisted by TIHCL.<br />
                    <p class="StyleCxSpFirst">
                        <br />
                        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For revival of Ramagundam Fertilizers &amp;chemicals limited Telangana state Government has confirmed the equity of 11 % Equity and till this day 154 Crores is released and Rs 105 Cr towards Power line infrastructure, approach road and for the laying of water pipeline
                            <o:p></o:p>
                        </span>
                    </p>
                    <p class="StyleCxSpLast">
                        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sirpur Paper mills Ltd, Asifabad Dist was revived by sanctioning tailor made incentives by recognizing the Mega project status. The unit has recommenced production, thereby protecting the thousands of employee&#39;s employment and their lively hood. So far an amount of Rs. 87.07 Cr was released to M/ s Sirpur Paper Mills.<o:p></o:p></span>
                    </p>
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3">Udyam Registration:   </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 1px; font-family: 'Times New Roman'; font-size: 1em;">             
                <span class="floatleft auto-style3">The Ministry of Micro, Small and Medium Enterprises of Government of India has brought in, wef July 1, 2020 a new system of Online registration for MSMEs and extending whole range of benefits to MSMEs from raw material at subsidized cost, finance and marketing support to a wide variety of schemes. 
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 1px; font-family: 'Times New Roman'; font-size: 1em;">
               <br />
                <span class="floatleft auto-style3">Till date <b>
                    <asp:Label ID="lbltilldate" runat="server" Text="<<>>" Visible="false"></asp:Label></b> ,<b><asp:Label ID="lblmsmeunits" runat="server" Text="<<>>"> </asp:Label></b> &nbsp;MSME Units have registered under UDYAM Registration in the State of Telangana.
                </span>
            </div>
            <div class="floatleft auto-style3" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                &nbsp;&nbsp;&nbsp;
Telangana State Micro and Small Enterprises Facilitation Council:           
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Telangana Government established six regional Micro and Small Enterprises Facilitation Councils at Rangareddy, MedchalMalkajgiri, Warangal, Karimnagar, YadadriBhuvanagiri and Sangareddydistricts with concerned GM, DIC as Chairperson for resolving delayed payments issues of MSMEs.
                   <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Till date <b>
                        <asp:Label ID="LBLNOOFAPPLICATIONSFILED" runat="server" Text="<<>>"></asp:Label></b> applications have been filed and <b>
                            <asp:Label ID="lblcases" runat="server" Text="<<>>"></asp:Label></b>&nbsp;cases involving an amount of Rs.<b><asp:Label ID="LBLDISPOSEDAMOUNT" runat="server" Text="<<>>"></asp:Label>
                                Cr.</b> were disposed of by the Councils. </span>
            </div>
            <div class="floatleft auto-style3" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                &nbsp;&nbsp;&nbsp;
Technology Centres / Extension Centres:      

            </div>
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3"> 
                <p class="floatleft auto-style3">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; One Technology Centre Hyderabad, MSME Tool Room (erstwhile Central Institute of Tool Design, Balanagar)and one extension centre at Karimnagarare established with an investment of </span><b>Rs
                        <asp:Label ID="LBLINVESTMENT" runat="server" Text="&lt;&lt;&gt;&gt;"></asp:Label>&nbsp;Lacks</b>
                    </p>
                </span>
            </div>
            <br />
            <div class="floatleft auto-style3" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                &nbsp;&nbsp;&nbsp;
Micro and Small Enterprises Cluster Development Program:     

            </div>
            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To take economic Development to all parts of the State, new industrial clusters and upgradation of existing industrial estates has been taken up in nearly 20 Districts under the Cluster Development Program.<o:p></o:p></span>
                </span>
            </div>
            <br />
            <div class="floatleft auto-style3" style="padding-top: 6px; font-weight: bold; font-family: 'Times New Roman'; font-size: 1em;">
                &nbsp;&nbsp;&nbsp;
Initiatives:      

            </div>
            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatleft auto-style3">
                <p class="floatleft auto-style3">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Government of Telangana formed new Initiative, Research and Innovation Circle Of Hyderabad <b>(RICH)</b>as Company Under the Companies Act to Provide and promote synergies among interested/ relevant entrepreneurs, industrial establishments, start-up companies, resources providers, research and development institutes, educational and service institutions individuals or incubation or innovator groups to function in partnership and/or collaborative mode and coordinate all inputs including design thinking, project execution and business management for corporate, scientists and entrepreneurs<o:p></o:p></span>
                    </p>

                    <p class="MsoNormal">
                        <b><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; T-Hub</span></b><span> is the State Incubator empowering start-ups and creating a network of stakeholders for accelerating innovation.<o:p></o:p></span>
                    </p>
                    <p class="MsoNormal">
                        <b><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WE-HUB</span></b><span> was created as Women Centric incubator.
                            <o:p></o:p>
                        </span>
                    </p>

                    <b><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TASK </span></b><span>(Telangana Academy for Skill and Knowledge) trained more than 7 lakh individuals</span><p class="MsoNormal">
                        &nbsp;
                    </p>

                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-family: 'Times New Roman'; font-size: 1em;">
                <span class="floatright auto-style3" style="text-align: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                   <b style="text-align: right"><span style="text-align: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Director Of Industries </span></b>
                    <p class="MsoNormal">
                        &nbsp;
                    </p>
                </span>
            </div>
        </div>
        <div class="container" id="Div2" runat="server" style="text-align: center; vertical-align: bottom">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
            </div>
        </div>
    </form>
</body>
</html>

