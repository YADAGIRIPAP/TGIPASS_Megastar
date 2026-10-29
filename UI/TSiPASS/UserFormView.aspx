<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="UserFormView.aspx.cs" Inherits="UI_TSIPASS_UserFormView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style type="text/css">
        .panel-title {
            position: relative;
            font-weight: normal;
            cursor: pointer;
        }

            .panel-title::after {
                content: "\f107";
                color: #333;
                top: -2px;
                right: 0px;
                position: absolute;
                font-family: "FontAwesome";
            }

            .panel-title[aria-expanded="true"]::after {
                content: "\f106";
            }
    </style>

     <script type="text/javascript">


         function printDiv(divName) {

             var printContents = document.getElementById(divName).innerHTML;

             var originalContents = document.body.innerHTML;



             document.body.innerHTML = printContents;

             window.print();

             document.body.innerHTML = originalContents;
         }
         </script>
    
    <div class="row">
        <div class="col-md-12">
             <div class="panel-group" id="accordion">
                    <!-- First Panel -->
                    <div class="panel panel-default" id="divName">
                        <div class="panel-heading">
     <div style="background-color:lightblue">
        
                   <table class="table">

                                <tr>
                                    <td ><img style="text-align:left" width="50px" height="50px" src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/tsiiclogo.png" /></td>
                                    <td style="text-align:left;font-weight:bold ">Telangana State Industrial Infracture Corporation Ltd.<br />
                                (A GOVT OF TELANGANA STATE UNDERTAKING) </td>

                                    <td> <img style="text-align:right"  width="50px" height="50px" src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/tsipasslogo.png" /> </td>
                                </tr>

                            </table>
                        </div>
                            </div>
                        <center>

                            <div class="panel-heading">
                            <h4 class="panel-title" data-toggle="collapse" data-target="#collapseOne"> 
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse in">
                            <div class="panel-body">
                                 <table bgcolor="White" width="100%" style="font-family: Verdana; ">
                                    <tr>
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                             Applicant And Unit Details
                                        </td>


                                     


                                    </tr>
                                    <tr style="width: 800px">


                                      
                      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Application No.</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblApplicationNo" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">District</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblAppliedRm" runat="server"></span>
                                        </td>
                                        
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                           <td style="padding:0px; margin: 0px">
                                           <asp:Image runat="server" ID="ImagePreview" Height="100px" Width="100px" ImageAlign="Right" />
                                       </td>
                                    </tr>
                                    <tr style="width: 800px">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Unit Name</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblUnitname" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Industrial Park Name</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblUnitType" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr style="width: 800px">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Selected Plot</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblApplicantName" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Area(in Sqmts)</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblTypeOfApplication" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr style="width: 800px">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Price(Rs)</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblEmNo" runat="server"></span>
                                        </td>

                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> Application Submitted</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span31" runat="server"></span>
                                        </td>
                                       <%-- <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 0px; margin: 0px; width: 20px">E.M Date</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 0px; margin: 0px">
                                            <span id="lblEmDate" runat="server"></span>
                                        </td>--%>
                                    </tr>
                                    <tr style="width: 800px" runat="server" visible="false">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Plot Description</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblLineofActivity" runat="server"></span>
                                        </td>
                                       
                                    </tr>

                                       
                                      <tr>
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                             Address of the Registered Office
                                        </td>
                                    </tr>
                                      
                                     <tr style="width: 800px">
                                    

                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Name of the Firm Applicant</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblfirmname" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Door No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbldoorno" runat="server"></span>
                                        </td>
                                      
                                    </tr>
                                     <tr style="width: 800px" >
                                       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Street 1</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblstreet1" runat="server"></span>
                                        </td>
                                      
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Street 2</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblstreet2" runat="server"></span>
                                        </td>
                                      
                                    </tr>
                                       
                                       <tr style="width: 800px" >
                                             <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">State</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblstate" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">District</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbldistrict" runat="server"></span>
                                        </td>
                                      
                                    </tr>
                                       <tr style="width: 800px" >

                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Mandal</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblmandal" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Village</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblvillage" runat="server"></span>
                                        </td>
                                       
                                    </tr>
                                     <tr style="width: 800px" >

                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Pincode</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblpincode" runat="server"></span>
                                        </td>

                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Telephone No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbltelphone" runat="server"></span>
                                             <span id="lbltelphone1" runat="server"></span>
                                        </td>
                                      

                                    </tr>
                                     <tr style="width: 800px">

                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Fax No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblfaxno" runat="server"></span>
                                             <span id="lblfaxnos" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Category</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblregoffice" runat="server"></span>
                                        </td>
                                      
                                    </tr>
                                    <tr>

                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Type of Organisation</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lbltypeorganistaion" runat="server"></span>
                                        </td>

                                         <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">If the Type Oraganisation is Govt. Dept</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="Span13" runat="server"></span>
                                        </td>

                                        </tr>
                                       
                                    <tr>
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                             Communication Address
                                        </td>
                                    </tr>
                                      <tr style="width: 800px">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Door No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbldoornocom" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Street 1</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblcomstreet1" runat="server"></span>
                                        </td>
                                    </tr>
                                       <tr style="width: 800px">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Street 2</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcomstreet2" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">State</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblcomstate" runat="server"></span>
                                        </td>
                                    </tr>
                                       
                                       <tr style="width: 800px">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">District</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcomdist" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Mandal</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblcommandal" runat="server"></span>
                                        </td>
                                    </tr>
                                       <tr style="width: 800px">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Village</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcomvilage" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Pincode</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblcompincode" runat="server"></span>
                                        </td>
                                    </tr>
                                     <tr style="width: 800px">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Telephone No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcomtelephone1" runat="server"></span>
                                                  <span id="lblcomtelephone2" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Fax No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblfaxno1" runat="server"></span>
                                               <span id="lblfaxno2" runat="server"></span>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                            Firm Registration Details
                                        </td>
                                    </tr>
                                   
                                 
                                          
                                                <tr style="width: 800px">
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Year of Establistment</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblYearestablishment" runat="server"></span>
                                                    </td>
                                                </tr>
                                                <tr style="width: 800px">
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Registration No</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblregistrationno" runat="server"></span>
                                                    </td>
                                                </tr>
                                                <tr style="width: 800px">
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Year of Commencement</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblyearcommencement" runat="server"></span>
                                                    </td>
                                                </tr>
                                                <tr style="width: 800px">
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Registering Authority</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblregisterringquthority" runat="server"></span>
                                                    </td>
                                                </tr>

                                                  <tr>
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                           Previous Allotment Details
                                        </td>
                                    </tr>
                                                <tr>
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Plot No</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblplotno1" runat="server"></span>
                                                    </td>
                                               
                                                
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">House </td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblhouse" runat="server"></span>
                                                    </td>
                                                </tr>
                                          
                                        
                                      
                                                <tr>
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Shop</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblshop" runat="server"></span>
                                                    </td>
                                              
                                               
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Shed Name</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblshedname" runat="server"></span>
                                                    </td>
                                                </tr>
                                                <tr style="width: 800px">
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Other Details</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblotherdetails" runat="server"></span>
                                                    </td>
                                      
                                             
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> Status Allotted /Lease Name</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblstatusallloted" runat="server"></span>
                                                    </td>
                                                </tr>

                                                 
                                                    <tr>
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                           Contact Information
                                        </td>
                                    </tr>
                                                <tr style="width: 800px">
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Surname</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblsurname" runat="server"></span>
                                                    </td>
                                         
                                                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Firstname</td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                                    <td style="text-align: left; padding: 5px; margin: 5px">
                                                        <span id="lblfirstname" runat="server"></span>
                                                    </td>
                                                </tr>
                                                     <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Door No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontactdoor" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Street 1</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblcontactstreet1" runat="server"></span>
                                        </td>
                                    </tr>
                                     
                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Street 2</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontactstreet" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">State</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblcontactstate" runat="server"></span>
                                        </td>
                                    </tr>
                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">District</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontactdist" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Mandal</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblcontactmandal" runat="server"></span>
                                        </td>
                                    </tr>
                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Village</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblvillagecontact" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Pincode</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblpincodecontact" runat="server"></span>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Mobile No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblmobileno" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Telephone No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lbltelephonecontact" runat="server"></span>
                                            <span id="lbltelephonecontact1" runat="server"></span>
                                        </td>
                                    </tr>
                                                   <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Fax No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontactfaxno" runat="server"></span>
                                            <span id="lblcontactfaxno1" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Email</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblemailcontact" runat="server"></span>
                                        </td>
                                    </tr>
                                               
                                       
                                   

                                                   <tr>
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                           Financial Information
                                        </td>
                                                       </tr>

                                            <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Functional Responsiblites in Proposed Project</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblproposedproject" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Assets(Rs in Lakhs)</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblassets" runat="server"></span>
                                        </td>
                                    </tr>

                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Liabilities(Rs in Lakhs)</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblliabiliites" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Other Assets(Rs in Lakhs)</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblotherassets" runat="server"></span>
                                        </td>
                                    </tr>
                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Details of Immovable Assets ,Land,and Building etc</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbldetailsimmovable" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Any other Information</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span id="lblanyotherinformaion" runat="server"></span>
                                        </td>
                                    </tr>
                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Pan No</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblpanno" runat="server"></span>
                                        </td>
                                       
                                    </tr>

                                     <tr style="height:40px">
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                          Addittional Promotor Details
                                            </td>
                                            
                                              <tr style="height:40px;">

<td align="left" colspan="8" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px;">
                                            <asp:GridView ID="Addlpromotordetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                            Height="62px" 
                                                                            Width="100%">
                                                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address " />
                                                                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                                                                <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                                                                                <asp:BoundField DataField="Experience" HeaderText="Experience" />
                                                                                <asp:BoundField DataField="Networth" HeaderText="Networth(Rs.in crores)" />


                                                                                   


                                                                            </Columns>

                                                                        </asp:GridView>
                                        </td>

                                              </tr>

                                             

                                              
                                                       </tr>

                                    <tr>
                                        <td colspan="10" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>General Information </b></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Type of Venture</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbltypeventure" runat="server"></span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Project Status</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblprojectstatus" runat="server"></span>
                                         </td>
                                    </tr>
                                     <tr>
                                         <td style="padding: 10px; margin: 5px; font-weight: bold; width:5px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Project Category</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblprojeccategory" runat="server"></span>

                                              <span id="lblprojeccategory1" runat="server"></span>
                                               <span id="lblprojeccategory2" runat="server"></span>
                                         </td>
                                    
                                           
                                         </td>
                                     </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Project Name/ Description</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblprojectname" runat="server"></span>
                                        </td>
                                     
                                    </tr>



                                         <tr style="height:40px">
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                          Proposed  Project
                                            </td>
                                            
                                              <tr style="height:40px;">

<td align="left" colspan="8" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px;">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                            Height="62px" 
                                                                            Width="100%">
                                                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                                      <asp:BoundField DataField="product" HeaderText="Product" />
                                                                <asp:BoundField DataField="Itemcode" HeaderText="Product Code
ITC (HS) / NIC (HS)" />
                                                                <asp:BoundField DataField="Unitmeasurement" HeaderText="Unit of
Measurement" />
                                                                <asp:BoundField DataField="Installedcapacity" HeaderText="Installed Capacity" />
                                                                


                                                                                   


                                                                            </Columns>

                                                                        </asp:GridView>
                                        </td>

                                              </tr>

                                             

                                              
                                                       </tr>

                                     
                                       <tr>
                                        <td colspan="4" style="height: 10px"></td>
                                    </tr>


                                       <tr style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">

                                            <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             Phase1
                                         </td>

                                       
                                       <%--  <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                            Phase2
                                         </td>

                                           
                                       <%--  <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                            Phase3
                                         </td>
                                     </tr>

                                     <tr>

                                            <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Expected Date of commencement of commercial operation</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblexpectedcommercial" runat="server"></span>
                                         </td>

                                       
                                         <%--<td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblexpectedcommercialphase2" runat="server"></span>
                                         </td>

                                           
                                      <%--   <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblexpectedcommercialphase3" runat="server"></span>
                                         </td>
                                     </tr>
                                          <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Expected Date of commencement of Construction</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblexpecteddateconstruction" runat="server"></span>
                                        </td>

                  
                                   <%--     <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblexpecteddateconstructionphase2" runat="server"></span>
                                        </td>
                                                
                                       <%-- <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblexpecteddateconstructionphase3" runat="server"></span>
                                        </td>
                                       
                                    </tr>

                                     <tr>

                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Expected Date of Trial Operation</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblexpecteddatetrialoperation" runat="server"></span>
                                         </td>

                                       
<%--                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblexpecteddatetrialoperationphase2" runat="server"></span>
                                         </td>

<%--                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblexpecteddatetrialoperationphase3" runat="server"></span>
                                         </td>
                                     </tr>
                                       <tr>
                                        <td colspan="4" style="height: 10px"></td>
                                    </tr>



                                          

                                     
                                       



                                   

                                      <tr>
                                          <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                          Estimated Project Cost(RS in Lakhs)
                                            </td>
                                    
                                    </tr>

                                                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                         Phase1
                                        </td>


                                      <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Phase2
                                        </td>
                                           
                                       <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Phase3
                                        </td>

                                          </tr> 

                                        
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Land</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblland" runat="server"></span>
                                        </td>
                                         <%-- <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbllandphase2" runat="server"></span>
                                        </td>
                                        <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbllandphase3" runat="server"></span>
                                        </td>

                                      
                                    </tr>
                                        <tr>


                                              <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Buildings</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblbuildings" runat="server"></span>
                                         </td>
                                            
                                        <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Buildings</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblbuildingsphase2" runat="server"></span>
                                         </td>
                                            
                                          <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Buildings</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblbuildingsphase3" runat="server"></span>
                                         </td>
                                      
                                     
                                    </tr>
                                        <tr>

                                              <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Imported</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblimported" runat="server"></span>
                                        </td>
                                              <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Imported</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblimportedphase2" runat="server"></span>
                                        </td>
                                          <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Imported</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblimportedphase3" runat="server"></span>
                                        </td>
                                      
                                       
                                    </tr>
                                        <tr>

                                               <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Indigenous</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblindigenous" runat="server"></span>
                                         </td>

                                            
                                           <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Indigenous</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblindigenousphase2" runat="server"></span>
                                         </td>
                                            
                                          <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Indigenous</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblindigenousphase3" runat="server"></span>
                                         </td>
                                    
                                    </tr>
                                     <tr>
                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Auxillary Equipment</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblauxilaryequipment" runat="server"></span>
                                        </td>

                                         
                                    <%--       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Auxillary Equipment</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblauxilaryequipmentphase2" runat="server"></span>
                                        </td>

                                         
                                      <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Auxillary Equipment</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblauxilaryequipmentphase3" runat="server"></span>
                                        </td>
                                     
                                    
                                    </tr>
                                     <tr>

                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Work Captial Margin</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblworkcaptail" runat="server"></span>
                                        </td>
                                  <%--          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Work Captial Margin</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblworkcaptailphase2" runat="server"></span>
                                        </td>
                                        <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Work Captial Margin</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblworkcaptailphase3" runat="server"></span>
                                        </td>

                                     </tr>
                                     <tr>
                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contingencies</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontingencies" runat="server"></span>
                                        </td>

                                         <%-- <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contingencies</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontingenciesphase2" runat="server"></span>
                                        </td>
                                        <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contingencies</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontingenciesphase3" runat="server"></span>
                                        </td>
                                     

                                     </tr>

                                     <tr>

                                            <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Preliminary and pre operative Expenses</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblpremlinary" runat="server"></span>
                                         </td>
                                      <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Preliminary and pre operative Expenses</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblpremlinaryphase2" runat="server"></span>
                                         </td>
                                    <%--       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Preliminary and pre operative Expenses</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblpremlinaryphase3" runat="server"></span>
                                         </td>
                                     </tr>

                                     <tr>

                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Misc.Fixed Assets</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblmiscfixed" runat="server"></span>
                                         </td>

                                        <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Misc.Fixed Assets</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblmiscfixedphase2" runat="server"></span>
                                         </td>
                                       <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Misc.Fixed Assets</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblmiscfixedphase3" runat="server"></span>
                                         </td>
                                     </tr>
                                         <tr>


                                                 <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbltotals" runat="server"></span>
                                         </td>

                                             
                                           <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbltotalsphase2" runat="server"></span>
                                         </td>
                                             
                                         <%--        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbltotalsphase3" runat="server"></span>
                                         </td>
                                         </tr>

                                   <tr>
                                          <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                       Equity and Debt Information (Rs. in Lakhs)
                                            </td>
                                    
                                    </tr>

                                      <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">Equity</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            
                                        </td>
                                     </tr>
                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Domestic</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span1" runat="server"></span>
                                        </td>

                                           </tr>
                                     <tr>
                                         <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Foreign</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span2" runat="server"></span>
                                        </td>
                                           </tr>
                                     <tr>
                                         <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total Equity	</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span3" runat="server"></span>
                                        </td>

                                          </tr> 

                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">Debit</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            
                                        </td>
                                     </tr>

                                        <tr>
                                      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          
                                        </td>
                                      
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Name</td>
                                   
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Amount</td>

                                       
                                     </tr>
                                     <tr>

                                         <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                         	Others (Please specify) 
                                        </td>
                                      


                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">  <span id="Span4" runat="server"></span></td>
                              
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> <span id="Span5" runat="server"></span></td>
                                     <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                              
                                 </td>



                                    </tr>
                                     <tr>
                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Total Equity + Debt
                                        </td>

                                              <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"><span id="Span7" runat="server"></span></td>
                                    <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                               
                                        </td>

                                         </tr>


                                     
                                   <tr>
                                          <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                      Approval (Please fill the applicable)
                                            </td>
                                    
                                    </tr>


                                       <tr>


                                                 <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">
                                    Foreign Investment Promotion Committee / Reserve Bank of India Approval No.</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span6" runat="server"></span>
                                         </td>
                                              <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> Foreign Investment  Date
                                  </td>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span11" runat="server"></span>
                                         </td>

                                       
                                           </tr>
                                            <tr>
                                                 <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">IEM</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span8" runat="server"></span>
                                         </td>
                                                 <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">IEM Date</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span12" runat="server"></span>
                                         </td>
                                              
                                                </tr>
                                     <tr>

                                             
                                                 <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Letter of Intent (LOI) No.</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span9" runat="server"></span>
                                         </td>

                                         <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">LOI Date</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span15" runat="server"></span>
                                         </td>

                                          
                                         </tr>
                                     <tr>

                                              <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">EOU No.</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span10" runat="server"></span>
                                         </td>

                                         
                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Eou Date</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span17" runat="server"></span>
                                         </td>

                                         
                                          
                                         </tr>


                                         <tr>
                                        <td colspan="10" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Direct Employment</b></td>
                                    </tr>


                                                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                         Phase1
                                        </td>


                                       <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Phase2
                                        </td>
                                           
                                     <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Phase3
                                        </td>

                                          </tr> 

                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Unskilled </td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblunskilled" runat="server"></span>
                                        </td>


                                    <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Unskilled </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblunskilledphase2" runat="server"></span>
                                        </td>
                                           
                                       <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Unskilled </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblunskilledphase3" runat="server"></span>
                                        </td>

                                          </tr> 

                                      <tr>
                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Skilled</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblskilled" runat="server"></span>
                                         </td>

                                      <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Skilled</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblskilledphase2" runat="server"></span>
                                         </td>

                                    <%--       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Skilled</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblskilledphase3" runat="server"></span>
                                         </td>

                                     </tr>
                                      
                                     <tr>
                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Supervisory</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblsupervisory" runat="server"></span>
                                        </td>
                                      <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Supervisory</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblsupervisoryphase2" runat="server"></span>
                                        </td>
                                 <%--        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Supervisory</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblsupervisoryphase3" runat="server"></span>
                                        </td>
                                         </tr>

                                     <tr>
                                                    
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Managerial</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblmanagerial" runat="server"></span>
                                         </td>

                                     <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Managerial</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblmanagerialphase2" runat="server"></span>
                                         </td>

                                       <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Managerial</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblmanagerialphase3" runat="server"></span>
                                         </td>
                                         </tr>



                                     <tr>
                               

                                             <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbltotalworkers" runat="server"></span>
                                        </td>

                                     <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbltotalworkersphase2" runat="server"></span>
                                        </td>
                                        <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbltotalworkersphase3" runat="server"></span>
                                        </td>
                                    </tr>

                                    
                                        
                                       
                                 

                                        <tr>
                                        <td colspan="10" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Indirect Employment</b></td>
                                    </tr>
                                     <tr>

  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Max no of Workers Proposed to be employ in the Factories</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblmaxnoworkers" runat="server"></span>
                                         </td>
                                     </tr>


                                       <tr>
                                        <td colspan="10" style="text-align:left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Gender Details</b></td>
                                    </tr>


                                      <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Phase1
                                        </td>

                                         <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Phase2
                                        </td>

                                          <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                           phase3
                                        </td>
                                       
                                    </tr>
                                         <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Male</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span14" runat="server"></span>
                                        </td>

                                        <%--       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Male</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span26" runat="server"></span>
                                        </td>

                                  <%--             <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Male</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span27" runat="server"></span>
                                        </td>
                                       
                                    </tr>


                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Female</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span28" runat="server"></span>
                                        </td>

                                       <%--        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Female</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span29" runat="server"></span>
                                        </td>

                                      <%--         <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Female</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="Span30" runat="server"></span>
                                        </td>
                                       
                                    </tr>
                                     

                                      <tr style="height:40px">
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                           Rawmaterials  Consumption
                                            </td>
                                            
                                              <tr style="height:40px;">

<td align="left" colspan="8" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px;">
                                            <asp:GridView ID="rawmaterialconsumption" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Height="62px"  Width="100%">
                                                                                            <HeaderStyle BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" ForeColor="#FFFFFF" Height="40px" />
                                                                                            <RowStyle CssClass="GridviewScrollC1Item" Height="40px" />
                                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                                            <FooterStyle BackColor="#009688" CssClass="GridviewScrollC1Footer" ForeColor="#FFFFFF" Height="40px" />
                                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" Height="40px" />
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
                                                                                                <asp:BoundField DataField="Descriptionitem" HeaderText="Description of Item" />
                                                                                                <asp:BoundField DataField="Itemcode" HeaderText="	Item Code ITC
(HS) / NIC(HS)" />
                                                                                                <asp:BoundField DataField="DailyConsumption" HeaderText="Daily Consumption
at Full Capacity" />
                                                                                                <asp:BoundField DataField="unitmeasurement" HeaderText="Unit of


Measurement	" />
                                                                                               
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                        </td>

                                              </tr>

                                             

                                              
                                                       </tr>

                                          <tr style="height:40px">
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                           Manufacturing Process
                                            </td>

		
		
	</tr>

                                     <tr>
                                     <td colspan="3"> Please give a brief description of process technology used along with a flow chart ( to be enclosed )


                                     </td>
                                         </tr>
                                     <tr>
                                     <td colspan="3">                                   <asp:TextBox ID="txtprovidedetails" runat="server" class="form-control txtbox" Height="150px" TabIndex="1" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
                                   </tr>
                                     <tr>
	<td colspan="3">  Do you have any technical collaboration?</td>

                                     <td> <asp:RadioButtonList ID="rdIaLa_Lst" runat="server"  RepeatDirection="Horizontal">

                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                                                   
                                                                                                </asp:RadioButtonList></td>
                                         </tr>
                                   
	<td colspan="3" align="left">If Yes provide details</td>

	<tr>
		<td colspan="3">                                   <asp:TextBox ID="TextBox1" runat="server" class="form-control txtbox" Height="150px" TabIndex="1" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
	</tr>
	<tr>
		<td colspan="3" align="left">If the Process technology involves usage of steam, the details of steam generator i.e, Boiler - furnish details of capacity and fuel to be used.</td>
	</tr>
	<tr>
		<td colspan="3">                                   <asp:TextBox ID="TextBox2" runat="server" class="form-control txtbox" Height="150px" TabIndex="1" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
	</tr>


                                             
                          



                                                        <tr style="height:40px">
                                        <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px ;background-color: #80B3FF">
                                           List of Plant and Machinery with the Capacity in KWA required
                                            </td>
                                            
                                              <tr style="height:40px;">

<td align="left" colspan="8" style="padding: 10px; margin: 5px; font-weight: bold; border-radius:1px;">
                                              <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Height="62px" Width="100%"
                                                                                      >
                                                                                            <HeaderStyle BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" ForeColor="#FFFFFF" Height="40px" />
                                                                                            <RowStyle CssClass="GridviewScrollC1Item" Height="40px" />
                                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                                            <FooterStyle BackColor="#009688" CssClass="GridviewScrollC1Footer" ForeColor="#FFFFFF" Height="40px" />
                                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" Height="40px" />
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
                                                                                                <asp:BoundField DataField="descplantmachinery" HeaderText="Description of Plant & Machinery" />

                                                                                                <asp:BoundField DataField="capacitykw" HeaderText="Capacity in Kilo Watt" />




                                                                                                
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                        </td>

                                                    <tr>

                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Whether factory / unit will be having any high pressure reaction vessels?</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal">
                                               <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                                                   
                                                                                                </asp:RadioButtonList>
                                           
                                        </td>
                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">If yes, number of such vessels may be indicated </td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">

                                          <asp:TextBox runat="server" ID="txtvessel"></asp:TextBox>
                                         
                                        </td>
                                                        </tr>

                                              </tr>

                                             

                                              
                                                       </tr>



                                       <tr>


  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Requirement of Industrial Shed(Plinth area in Sqmts)</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblindusshed" runat="server"></span>
                                         </td>
                                     </tr>
                                    

                                     
                      
                                      
                                       <tr>
                                        <td colspan="10" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Area of Land  Required for your Proposed Project </b></td>
                                    </tr>


                                              <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                         Phase1
                                        </td>


                                   <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Phase2
                                        </td>
                                           
                                      <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Phase3
                                        </td>

                                          </tr> 
                                         <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Plant and Factory Buildings</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblplantfactory" runat="server"></span>
                                        </td>

                                          <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Plant and Factory Buildings</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblplantfactoryphase2" runat="server"></span>
                                        </td>

                                          <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Plant and Factory Buildings</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblplantfactoryphase3" runat="server"></span>
                                        </td>
                                        
                                    </tr>

                                     <tr>

                                         <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Administration Buildings</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbladmininistration" runat="server"></span>
                                         </td>

                                    <%--        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Administration Buildings</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbladmininistrationphase2" runat="server"></span>
                                         </td>

                                <%--            <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Administration Buildings</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbladmininistrationphase3" runat="server"></span>
                                         </td>
                                     </tr>


                                         <tr>


                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Storage and Warehousing</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblstorageandwarehousing" runat="server"></span>
                                        </td>

                                             

                                      <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Storage and Warehousing</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblstorageandwarehousingphase2" runat="server"></span>
                                        </td>

                                             

                                    <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Storage and Warehousing</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblstorageandwarehousingphase3" runat="server"></span>
                                        </td>
                                       
                                    </tr>

                                     <tr>


                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Roads,water storage,Substation etc</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblroad" runat="server"></span>
                                         </td>

                                    <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Roads,water storage,Substation etc</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblroadphase2" runat="server"></span>
                                         </td>

                                        <%-- <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Roads,water storage,Substation etc</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblroadphase3" runat="server"></span>
                                         </td>
                                     </tr>

                                         <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Open Areas,Green belt etc</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblopenarea" runat="server"></span>
                                        </td>
                                       <%--        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Open Areas,Green belt etc</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblopenareaphase2" runat="server"></span>
                                        </td>

                                           <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Open Areas,Green belt etc</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblopenareaphase3" runat="server"></span>
                                        </td>

                                          </tr>
                                     <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbltotal" runat="server"></span>
                                         </td>

<%--                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbltotalphase2" runat="server"></span>
                                         </td>


                                        <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Total</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lbltotalphase3" runat="server"></span>
                                         </td>
                                    </tr>


                                        <tr>
                                        <td colspan="10" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Energy consumption in KVA ( Power required for the project ) </b></td>
                                  

                                                         <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">	TSTransco Supply</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span16" runat="server"></span>
                                         </td>

                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Own Generation</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span18" runat="server"></span>
                                         </td>


                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">DG Set</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span19" runat="server"></span>
                                         </td>
                                    </tr>

                                              </tr>



                                
                                      
                                       <tr>
                                        <td colspan="10" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Energy Requirement </b></td>
                                    </tr>

                                              <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                         Phase1
                                        </td>


                            <%--             <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Phase2
                                        </td>
                                           
                                       <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Phase3
                                        </td>

                                          </tr> 
                                         <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Power Requirements from TSTRANSCO(in KVA)</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblppowerreqirement" runat="server"></span>
                                        </td>

                                       <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Power Requirements from TSTRANSCO(in KVA)</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblppowerreqirementphase2" runat="server"></span>
                                        </td>


                                        <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Power Requirements from TSTRANSCO(in KVA)</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblppowerreqirementphase3" runat="server"></span>
                                        </td>
                                     
                                    </tr>

                                     <tr>

                                            <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contracted Max Demand(in KVA)</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblcontractedmax" runat="server"></span>
                                         </td>

                                    <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contracted Max Demand(in KVA)</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblcontractedmaxphase2" runat="server"></span>
                                         </td>
                                   <%--       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contracted Max Demand(in KVA)</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblcontractedmaxphase3" runat="server"></span>
                                         </td>
                                     </tr>
                                         <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Required Power supply line(KV)</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblrequirepowersupply" runat="server"></span>
                                        </td>
                                  <%--            <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Required Power supply line(KV)</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblrequirepowersupplyphase2" runat="server"></span>
                                        </td>

                                           <%--        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Required Power supply line(KV)</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblrequirepowersupplyphase3" runat="server"></span>
                                        </td>
                                      
                                      
                                    </tr>

                                     <tr>

                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Voltage rating at which HTsupplies required</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblvoltagerating" runat="server"></span>
                                         </td>

                                 <%--        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Voltage rating at which HTsupplies required</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblvoltageratingphase2" runat="server"></span>
                                         </td>

                                      <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Voltage rating at which HTsupplies required</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblvoltageratingphase3" runat="server"></span>
                                         </td>
                                     </tr>

                                     <tr>

                                           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Connected Load(KW)</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblconnectedlaod" runat="server"></span>
                                        </td>
                                <%--           <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Connected Load(KW)</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblconnectedlaodphase2" runat="server"></span>
                                        </td>
                                        <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Connected Load(KW)</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblconnectedlaodphase3" runat="server"></span>
                                        </td>
                                     </tr>
                                         <tr>
                                      
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Load Factor</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblloadfactor" runat="server"></span>
                                         </td>

                                         <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Load Factor</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblloadfactorphase2" runat="server"></span>
                                         </td>
                                      <%--        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Load Factor</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblloadfactorphase3" runat="server"></span>
                                         </td>
                                    </tr>


                                    

                                     
                                                  


                                    
                                      
                                     
                           
                                    
                                     
                                      <tr>
                                        <td colspan="10" style="text-align:left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Probable Date of Requirement of Power Supply </b></td>
                                    </tr>


                                      <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Phase1
                                        </td>

                                   <%--            <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Phase2
                                        </td>

                                             <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                           phase3
                                        </td>
                                       
                                    </tr>
                                         <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contruction Phase Date</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontructionphasedate" runat="server"></span>
                                        </td>

                                         <%--      <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contruction Phase Date</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontructionphasedatephase2" runat="server"></span>
                                        </td>

                                          <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Contruction Phase Date</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblcontructionphasedatephase3" runat="server"></span>
                                        </td>
                                       
                                    </tr>

                                     <tr>

                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Commercial Production Date</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblcommercialproductiondate" runat="server"></span>
                                         </td>

                                      <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Commercial Production Date</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblcommercialproductiondatephase2" runat="server"></span>
                                         </td>

                                       <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Commercial Production Date</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblcommercialproductiondatephase3" runat="server"></span>
                                         </td>
                                     </tr>
                                               </tr>
                                       <tr>
                                        <td colspan="10" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Peak water Requirement(KL per Day) </b></td>
                                    </tr>
                                        
                             
                                      <tr>
                                        <td colspan="6" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;"><b>Temporary(during construction) </b></td>
                                    </tr>

                                      <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                              Phase1
                                        </td>

                                       <%--         <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Phase2
                                        </td>

                                            <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Phase3
                                        </td>
                                       
                                    </tr>
                                         <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Domestic</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbldomestic1" runat="server"></span>
                                        </td>

                                <%--                <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Domestic</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbldomestic1phase2" runat="server"></span>
                                        </td>

                                            <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Domestic</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lbldomestic1phase3" runat="server"></span>
                                        </td>
                                       
                                    </tr>

                                     <tr>


                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Industrial</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Industrialtemp" runat="server"></span>
                                         </td>

                                        <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Industrial</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Industrialtempphase2" runat="server"></span>
                                         </td>

                                    <%--       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Industrial</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Industrialtempphase3" runat="server"></span>
                                         </td>
                                     </tr>

                                      <tr>
                                        <td colspan="6" style="text-align: left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;"><b>Permanent(Commercial Production Phase) </b></td>
                                    </tr>
                                      <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Domestic</td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblpermanentdomestic" runat="server"></span>
                                        </td>
                                     <%--  <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Domestic</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblpermanentdomesticphase2" runat="server"></span>
                                        </td>

                                   <%--       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Domestic</td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span id="lblpermanentdomesticphase3" runat="server"></span>
                                        </td>
                                    </tr>

                                     <tr>

                                          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Industrial</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblpermindustrial" runat="server"></span>
                                         </td>

                                       <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Industrial</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblpermindustrialphase2" runat="server"></span>
                                         </td>

                                <%--          <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Industrial</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="lblpermindustrialphase3" runat="server"></span>
                                         </td>
                                     </tr>

                                     
                                       <tr>
                                        <td colspan="10" style="text-align:left; padding: 5px; margin: 5px; padding-left:25px; border-radius:1px;background-color: #80B3FF""><b>Details of Effluents </b></td>
                                    </tr>


                                       <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"></td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                         Phase1
                                        </td>


                                        <%-- <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            Phase2
                                        </td>
                                           
                                      <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px; width: 220px"> </td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                          Phase3
                                        </td>

                                          </tr> 
                                      <tr>
                                      
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Effluents Quantity (m3/day)</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span20" runat="server"></span>
                                         </td>

                                           <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Effluents Quantity (m3/day)</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span21" runat="server"></span>
                                         </td>
                                          <%--    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">Effluents Quantity (m3/day)</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span22" runat="server"></span>
                                         </td>
                                    </tr>
                                        <tr>
                                      
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">	Solid Waste (kg/day)</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span23" runat="server"></span>
                                         </td>

                                           <%--   <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">	Solid Waste (kg/day)</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span24" runat="server"></span>
                                         </td>
                                         <%--     <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">	Solid Waste (kg/day)</td>--%>
                                         <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                         <td style="padding: 5px; margin: 5px">
                                             <span id="Span25" runat="server"></span>
                                         </td>
                                    </tr>
                                     <tr>

                                       <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px"></td>
                                         <td style="text-align: left; padding: 5px; margin: 5px; width: 220px">	Brief description on types of effluents generated, treatment proposed and Disposal System Description</td>
                                         <td style="padding: 5px; margin: 5px; width: 1px">:</td>
                                         <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtdesceff" runat="server" class="form-control txtbox" Height="150px" TabIndex="1" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                         </td>
                                    </tr>

                                     </table>
                                 
                                 
                                
                                 
                            </div>
                        </div>
                            </center>
                     <center>
                     <%--  <input type="button" class="btn btn-warning"  Height="40px" Width="250px"  onclick="printDiv('collapseOne')" value="print" />--%>

                        <%-- <a class="btn btn-warning"   style="height:40px;width:100px" href="userformview.aspx">Print</a>--%>
                        <%-- <a href='userformview.aspx? ApplicationId=<%# Eval("AppId")%>&RmType=<%# Eval("Type")%>'>print</a>--%>


                         <input type="button" class="btn-warning btn"  style="width:50px" onclick="printDiv('divName')" value="print" />

                         
                       
                           </center>
                    </div>
                 
                     
                           
                
                 
                    <!-- Second Panel -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" data-toggle="collapse" data-target="#collapseTwo">Attachments
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <h5>Check Lists</h5>
                                <table class="table table-bordered table-condensed">
                                    <thead>
                                        <tr>
                                            <th>Attachment Name</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyAttachments" runat="server">
                                        <tr>
                                            <td class="col-md-8"></td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
              </div>

            </div>
        </div>
   
</asp:Content>

