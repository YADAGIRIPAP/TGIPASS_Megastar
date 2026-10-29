<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MobileTowerApplicationPrint.aspx.cs" Inherits="UI_TSiPASS_MobileTowerApplicationPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            border: 2px solid ActiveCaptionText;
            padding: 8px;
        }

        }
         .auto-style1 {
             height: 46px;
         }
    </style>
 <%--   <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>MOBILE TOWER APPLICATION FORM</h3>
                </div>
                <br />
                <div align="center">
                  
                    
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                         <tr >
                             <td style="padding: 5px; margin: 5px" valign="top" align="center" class="auto-style6">
                                
                                 <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                        
                                     <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                              <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="200px">District<font color="red">*</font></asp:Label>
                                                           </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             <span> <asp:Label ID="lbldistrict" runat="server"></asp:Label></span></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                             <asp:Label ID="Label53" runat="server" CssClass="LBLBLACK" Width="200px"> Mandal&nbsp;<span style="color: red">*</span></asp:Label>
                                                           
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <span> <asp:Label ID="lblproposedmandal" runat="server" Width="180px"></asp:Label></span>
                                                            </td>
                                                    </tr>
                                 </table>
                        
                             </td>
                         </tr>
                               <tr  runat="server" Id="traddressoftheapplicationheader"  >
                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True"><h4>Address Of The Applicant</h4></asp:Label>
                                </td>

                            </tr>
                            <tr runat="server" Id="traddressoftheapplicationdetails" >
                                <td>
                               
                        <table bgcolor="White" width="95%" border="2px" style="font-family: Verdana; font-size: small;">
                            <tbody><tr>
                                <td>
                                    <div id="updatepanels1">	
                                            <table style="width: 95%" cellspacing="2" cellpadding="2" border="2px">
                                                <tbody>

                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"><asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Name of the Infrastructure Provider Companie</asp:Label></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                               <span> <asp:Label ID="lblname" runat="server" Width="180px"></asp:Label></span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                             <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="200px">Door No./Flat No.</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             
                                                             <span> <asp:Label ID="lbldoor" runat="server" Width="180px"></asp:Label></span>
                                                            </td>

                                                   </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="200px"> Road/Street</asp:Label>
                                                           </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            
                                                             <span> <asp:Label ID="lblroad" runat="server"></asp:Label></span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                             <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="200px"> Area</asp:Label>
                                                            
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             
                                                             <span> <asp:Label ID="lblarea" runat="server"></asp:Label></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="200px"> Mandal</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             <span> <asp:Label ID="lblmandal" runat="server"></asp:Label></span>
                                                           </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px"> District</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                         
                                                             <span> <asp:Label ID="lbldistrct" runat="server"></asp:Label></span>
                                                           </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px">  PIN Code</asp:Label>
                                                           </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             
                                                             <span> <asp:Label ID="lblpin" runat="server"></asp:Label></span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                             <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="200px"> E-mail</asp:Label>
                                                           </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            
                                                             <span> <asp:Label ID="lblmail" runat="server"></asp:Label></span>
                                                            </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                               </div>
                                </td>
                            </tr>
                        </tbody></table>
                  
                                </td>
                            </tr>
                             <tr>
                                 <td style="padding: 5px; margin: 5px; height:10px">
                                </td>
                                 </tr>
                              <tr runat="server" Id="trLocationOfTheProposedSiteheader">
                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True"><h4>Location Of The Proposed Site</h4></asp:Label>
                                </td>

                            </tr>
                              <tr runat="server" Id="trLocationOfTheProposedSitedetails">
                                <td>
                     
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tbody><tr>
                                <td>
                                    <div id="updatepanels3">
	
                                            <table style="width: 95%; height: 133px" cellspacing="2" cellpadding="2" border="2px">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px">Plot Nos.</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            
                                                             <span> <asp:Label ID="lblplot" runat="server" Width="180px"></asp:Label></span>
                                                        </td>
                                                            
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">Sanctioned Layout No.(if any)</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            
                                                             <span> <asp:Label ID="lbllayout" runat="server" Width="180px"></asp:Label></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="200px">Survey No.</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           
                                                             <span> <asp:Label ID="lblsurvey" runat="server"></asp:Label></span>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="200px">Premises/Door No.</asp:Label>
                                                            </td>
                                                        <td style="text-align: left">
                                                         
                                                            <table>
                                                                <tr>
                                                                    
                                                                        <td style="padding: 1px; margin: 1px; text-align: left;">
                                                           
                                                                             <span> <asp:Label ID="lblrevward" runat="server"></asp:Label></span>
                                                                    </td>
                                                                    <td style="padding: 0px; margin: 0px; text-align: left;">-</td>
                                                                  <td>
                                                                      
                                                                       <span> <asp:Label ID="lblrevblock" runat="server"></asp:Label></span>
                                                                  </td>
                                                                    <td style="padding: 0px; margin: 0px; text-align: left;">-</td>
                                                                    <td >
                                                        
                                                                         <span> <asp:Label ID="lbldoorno" runat="server"></asp:Label></span>
                                                             </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="200px">Example.</asp:Label>
                                                            
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <span id="lblrevward" style="display:inline-block;width:30px;">8</span>&nbsp;
                                                            -
                                                            <span id="Label1" style="display:inline-block;width:20px;">5</span>&nbsp; -
                                                            <span id="Label2" style="display:inline-block;width:60px;">120/A</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="200px">Road/Street No.</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            
                                                             <span> <asp:Label ID="lblstreetroad" runat="server"></asp:Label></span>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Election Ward No.</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            
                                                             <span> <asp:Label ID="lblward" runat="server"></asp:Label></span>
                                                           </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="200px">Election Block No.</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           
                                                         <span> <asp:Label ID="lblblock" runat="server"></asp:Label></span>    
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="200px">Circle</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <span> <asp:Label ID="lblcircle" runat="server"></asp:Label></span>


                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="200px">Locality</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <span> <asp:Label ID="txtloc" runat="server"></asp:Label></span> 
                                                           </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                             <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="200px">Area</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                          
                                                             <span> <asp:Label ID="lblaarea" runat="server"></asp:Label></span>
                                                            
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label51" runat="server" CssClass="LBLBLACK" Width="200px">GPS Co-ordinates</asp:Label>
                                                           </td>
                                                        
                                                        <td align="left" colspan="3">
                                                            <table width="50%" >
                                                                <tr>
                                                                        <td style="padding: 1px; margin: 1px; text-align: left;">
                                                             
                                                                             <span> <asp:Label ID="lblgpsdd" runat="server"></asp:Label></span>
                                                                    </td>
                                                                    <td style="padding: 0px; margin: 0px; text-align: left;"> Degrees&nbsp;</td>
                                                                  <td>
                                                                       
                                                                       <span> <asp:Label ID="lblgpsmm" runat="server"></asp:Label></span>
                                                                  </td>
                                                                    <td style="padding: 0px; margin: 0px; text-align: left;">  Minutes&nbsp;</td>
                                                                    <td >
                                                                        <span> <asp:Label ID="lblgpsss" runat="server"></asp:Label></span>
                                                                    </td>
                                                                    <td style="padding: 0px; margin: 0px; text-align: left;width:100px"> &nbsp; Secounds</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr runat="server" Id="trcircle" visible="false" >
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="200px">Circle</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlcircle" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1">
                                                                                <asp:ListItem value="0">--Select--</asp:ListItem>
                                                                                <asp:ListItem value="1049">1-Kapra</asp:ListItem>     
                                                                                <asp:ListItem value="1057">2-Uppal</asp:ListItem>     
                                                                                <asp:ListItem value="1051">3-Hayathnagar</asp:ListItem>     
																				<asp:ListItem value="1004">6-Malakpet</asp:ListItem>
																				<asp:ListItem value="1005">9-Charminar</asp:ListItem>
																				<asp:ListItem value="1054">11-Rajendra Nagar</asp:ListItem>
																				<asp:ListItem value="1007">12-Mehdipatnam</asp:ListItem>
																				<asp:ListItem value="1008">14-Gosha Mahal</asp:ListItem>
																				<asp:ListItem value="1009">15-Musheerabad</asp:ListItem>
																				<asp:ListItem value="1010">17-Khairatabad</asp:ListItem>
																				<asp:ListItem value="1055">20-Serilingampally</asp:ListItem>
																				<asp:ListItem value="1012">21-Chanda Nagar</asp:ListItem>
																				<asp:ListItem value="1013">22-R C Puram and Patancheruvu </asp:ListItem>
																				<asp:ListItem value="1050">23-Moosapet</asp:ListItem>
																				<asp:ListItem value="1053">25-Qutbullapur</asp:ListItem>
																				<asp:ListItem value="1047">27-Alwal</asp:ListItem>
																				<asp:ListItem value="1052">28-Malkajigiri</asp:ListItem>
																				<asp:ListItem value="1018">29-Secunderabad</asp:ListItem>
																				<asp:ListItem value="1064">5-Saroornagar</asp:ListItem>
																				<asp:ListItem value="1058">18-Jubilee Hills</asp:ListItem>
																				<asp:ListItem value="1059">16-Amberpet</asp:ListItem>
																				<asp:ListItem value="1060">13-Karwan</asp:ListItem>
																				<asp:ListItem value="1068">26-Gajularamaram</asp:ListItem>
																				<asp:ListItem value="1069">30-Begumpet</asp:ListItem>
																				<asp:ListItem value="1061">24-Kukatpally</asp:ListItem>
																				<asp:ListItem value="1062">4-L B Nagar</asp:ListItem>
																				<asp:ListItem value="1063">7-Santoshnagar</asp:ListItem>
																				<asp:ListItem value="1065">8-Chandrayangutta</asp:ListItem>
																				<asp:ListItem value="1066">10-Falaknuma</asp:ListItem>
																				<asp:ListItem value="1067">19-Yousufguda</asp:ListItem>												
                                                                                </asp:DropDownList>

                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        
</div>
                                </td>
                            </tr>
                        </tbody></table>
                 
                                </td>
                            </tr>
                             <tr>
                                 <td style="padding: 5px; margin: 5px; height:10px">
                                </td>
                                 </tr>
                            <tr runat="server" Id="trDetailsOfTheProposedTITheader" >
                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                    <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True"><h4>Details Of The Proposed TIT</h4></asp:Label>
                                </td>

                            </tr>

                            <tr runat="server" Id="trDetailsOfTheProposedTITdetails" >
                                <td>
                                  
                                    <table style="width: 720px; height: 60px" cellspacing="2" cellpadding="2" border="1">
                                        <tbody>
                                            <tr>
                                                <td style="height: 12px" colspan="4">
                                                    <strong>Site Area (in Sq.m)</strong></td>
                                            </tr>

                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                     <asp:Label ID="lblDocid" runat="server" CssClass="LBLBLACK" Width="200px">As Per Documents</asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="lblsubmitplan" runat="server" CssClass="LBLBLACK" Width="200px">As Per Submitted Plan</asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Lblroadwideningarea" runat="server" CssClass="LBLBLACK" Width="200px">Road Widening Area</asp:Label>

                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="LblNetarea" runat="server" CssClass="LBLBLACK" Width="200px">Net Area</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">

                                                 
                                                     <span> <asp:Label ID="lbldocument" runat="server"></asp:Label></span>
                                              </td>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                  
                                                     <span> <asp:Label ID="lblsubplan" runat="server"></asp:Label></span>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">

                                                    
                                                     <span> <asp:Label ID="lblwidenarea" runat="server"></asp:Label></span>

                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                 
                                                     <span> <asp:Label ID="lblnet" runat="server"></asp:Label></span>
                                                    </td>
                                            </tr>
                                        </tbody>
                                    </table>
                               
                                </td>
                            </tr>
                            <tr>
                                 <td style="padding: 5px; margin: 5px; height:10px">
                                </td>
                                 </tr>
                            <tr runat="server" Id="trSetBacksofRoomheader" >
                                <td>
                                   
                                            <table style="width: 720px; height: 60px" cellspacing="2" cellpadding="2" border="1">
                                                <tbody>
                                                    <tr>
                                                        <td style="height: 12px" colspan="4">
                                                            <strong>Set Backs of Room/Tower(Minimum-3mtrs)</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="lbleasth" runat="server" CssClass="LBLBLACK" Width="200px">East</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             <asp:Label ID="lblwesth" runat="server" CssClass="LBLBLACK" Width="200px">West</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             <asp:Label ID="lblnorthh" runat="server" CssClass="LBLBLACK" Width="200px">North</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             <asp:Label ID="lblsouthh" runat="server" CssClass="LBLBLACK" Width="200px">South</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           
                                                             <span> <asp:Label ID="lbleast" runat="server"></asp:Label></span>mtrs</td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            
                                                             <span> <asp:Label ID="lblwest" runat="server"></asp:Label></span>
                                                            mtrs
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                    
                                                             <span> <asp:Label ID="lblnorth" runat="server"></asp:Label></span>mtrs
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                          
                                                             <span> <asp:Label ID="lblsouth" runat="server"></asp:Label></span>mtrs
                                                           </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                    
                                </td>
                            </tr>
                              <tr>
                                 <td style="padding: 5px; margin: 5px; height:10px">
                                </td>
                                 </tr>
                            <tr runat="server" Id="trSetBacksofRoomdetails">
                                <td>
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div id="updatepanels6">
                                                                <table style="width: 95%; height: 133px" cellspacing="2" cellpadding="2" border="2px">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                 <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Proposals &nbsp;<span style="color: red">*</span></asp:Label>                                                                               </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                           <span> <asp:Label ID="lblproposal" runat="server" Width="180px"></asp:Label></span>
                                                                                
                                                                                </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                                 <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="200px">Accessory Room</asp:Label></td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <table id="rtnaccroom">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                                <span>
                                                                                                    <asp:Label ID="lblaccroom" runat="server" Width="180px"></asp:Label>
                                                                                                </span>
                                                                                                </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="200px">Generator Room</asp:Label></td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <table id="rtngenroom">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td colspan ="2" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                                <span> <asp:Label ID="lblgenroom" runat="server"></asp:Label></span>
                                                                                                 </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="200px"> Whether Proposed &nbsp;<span style="color: red">*</span></asp:Label>
                                                                               
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                  
                                                                                <span> <asp:Label ID="lblproposed" runat="server"></asp:Label></span>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">Vacant Land Tax Identification No.</asp:Label>
                                                                                
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                                 
                                                                                 <span> <asp:Label ID="lblvltno" runat="server"></asp:Label></span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: right;" class="auto-style1">
                                                                                 <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="200px"> Property Tax Identification No.</asp:Label>
                                                                               
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                                    
                                                                                 <span> <asp:Label ID="lblptino" runat="server"></asp:Label></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="200px">  Building Permit No.</asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                      
                                                                                 <span> <asp:Label ID="lblperno" runat="server"></asp:Label></span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                                <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="200px">  Occupancy Certificate No.</asp:Label>  </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                               
                                                                                 <span> <asp:Label ID="lblocccer" runat="server"></asp:Label></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="200px"> Tower Construction.</asp:Label>
                                                                                
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <table id="rtbtncon">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                                <span> <asp:Label ID="lbltbtncon" runat="server"></asp:Label></span></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                                 <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="200px"> Name of Owner</asp:Label></td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                     
                                                                                 <span> <asp:Label ID="lblowner" runat="server"></asp:Label></span>
                                                                            </td>                                                                                
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="200px"> Net Work Agency/Firm Name&nbsp;<span style="color: red">*</span></asp:Label>
                                                                               </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <span> <asp:Label ID="lblnetwork" runat="server"></asp:Label></span>

                                                                                
                                                                               </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                                <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="200px"> Lessee / License Agrement</asp:Label>
                                                                                </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <table id="rtnlessee">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                               <span> <asp:Label ID="lbllessee" runat="server"></asp:Label></span></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Lease Years
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                      
                                                                                 <span> <asp:Label ID="lblleaseyears" runat="server"></asp:Label></span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                                <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="200px"> Authorised Agent</asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <table id="rtnauagent">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">

                                                                                                  <span> <asp:Label ID="lblnauagent" runat="server"></asp:Label></span></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="200px"> Authorised Agent Name</asp:Label>
                                                                               </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    
                                                                                <span> <asp:Label ID="lblauagentname" runat="server"></asp:Label></span>
                                                                               </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                        </tr>

                                                                        <tr runat="server" id="trdrodownr" visible="false">

                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:DropDownList ID="ddlproposal" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem value="1">GROUND BASED TOWER (GBT)</asp:ListItem>
                                                                                <asp:ListItem value="2">ROOF TOP TOWER (RTT)</asp:ListItem>
                                                                                <asp:ListItem value="3">ROOF TOP POLES (RTP)</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                               </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                     <asp:DropDownList ID="ddlproposed" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                               </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                   <asp:DropDownList ID="ddlnet" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1">
                                                                                <asp:ListItem value="0">--Select--</asp:ListItem>
                                                                                <asp:ListItem value="1">AIRTEL</asp:ListItem>
                                                                                <asp:ListItem value="2">AIRCELL</asp:ListItem>
                                                                                <asp:ListItem value="3">IDEA</asp:ListItem>
                                                                                <asp:ListItem value="4">RELIANCE</asp:ListItem>
                                                                                <asp:ListItem value="5">TATA</asp:ListItem>
                                                                                <asp:ListItem value="6">TATA DOCOMO</asp:ListItem>
                                                                                <asp:ListItem value="7">TATA INDICOM</asp:ListItem>
                                                                                <asp:ListItem value="8">VODAFONE</asp:ListItem>
                                                                                <asp:ListItem value="9">UNINOR</asp:ListItem>
                                                                                <asp:ListItem value="10">BSNL</asp:ListItem>
                                                                                <asp:ListItem value="11">T24</asp:ListItem>
                                                                                <asp:ListItem value="12">VIRGIN</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                              
                                                                            </td>
                                                                              
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                </td>
                            </tr>

                            <tr runat="server" Id="trLicenseTechnicalPersonalheader" >
                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                    <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True"><h4>License Technical Personal</h4></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" Id="trLicenseTechnicalPersonaldetails" >
                                <td>
                                            <table style="width: 95%; height: 133px" cellspacing="2" cellpadding="2" border="2px">
                                                <tbody>
                                                    <tr>
                                                        <td  style="padding: 5px; margin: 5px; text-align: left;">
                                                             <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px"> Architect Name</asp:Label>
                                                        </td>
                                                        <td  style="padding: 5px; margin: 5px; text-align: left;">
                                                               
                                                            <span> <asp:Label ID="lblarchitectname" runat="server" Width="180px"></asp:Label></span>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Width="200px"> Architect License No</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                           
                                                            <span> <asp:Label ID="lblarchitectno" runat="server" Width="180px"></asp:Label></span>
                                                           </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="200px"> Architect Address</asp:Label></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                 
                                                            <span> <asp:Label ID="lblarchitectaddress" runat="server"></asp:Label></span>
                                                           </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="200px"> Engineer Name</asp:Label></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                
                                                            <span> <asp:Label ID="lblengname" runat="server"></asp:Label></span>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label41" runat="server" CssClass="LBLBLACK" Width="200px"> Engineer License No</asp:Label> </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                 
                                                            <span> <asp:Label ID="lblengno" runat="server"></asp:Label></span>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="200px"> Engineer Address</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                              
                                                             <span> <asp:Label ID="lblengaddress" runat="server"></asp:Label></span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="200px"> Surveyor Name</asp:Label></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                
                                                            <span> <asp:Label ID="lblsurvename" runat="server"></asp:Label></span>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                             <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="200px"> Surveyor License No.</asp:Label>
                                                            </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                  
                                                            <span> <asp:Label ID="lblsurveno" runat="server"></asp:Label></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label44" runat="server" CssClass="LBLBLACK" Width="200px"> Surveyor Address</asp:Label></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                              
                                                             <span> <asp:Label ID="lblsurveaddress" runat="server"></asp:Label></span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="200px"> Structural Engineer</asp:Label></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                          
                                                            <span> <asp:Label ID="lblstreng" runat="server"></asp:Label></span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                            <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="200px"> Structural Engineer License No.</asp:Label></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                 
                                                            <span> <asp:Label ID="lblstrenglicno" runat="server"></asp:Label></span>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                                        <br />
                                        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                            type="button" value="Print" />
                                        &nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx">HOME</a>
                                    </div>
                                </div>
        </div>
    </form>
</body>
</html>
