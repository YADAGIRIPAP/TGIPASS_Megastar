<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmIPOMonthlyReportUpdate.aspx.cs" Inherits="UI_TSiPASS_frmIPOMonthlyReportUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div class="container" id="minmumbox">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget-box">
                                    <div class="widget-content nopadding">
                                        <div id="home" class="container tab-pane active">
                                            <div class="row">
                                                <div class="col-sm-2 form-group">
                                                </div>
                                                <div class="col-sm-8 form-group" align="center">
                                                    <h4> Application Form Submission Summary</h4>
                                                </div>
                                                <div class="col-sm-2 form-group">
                                                </div>

                                            </div>

                                              <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <%--<tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                                    valign="top" colspan="3">
                                                   
                                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" 
                                                    Height="32px" OnClientClick="OpenPopup();" TabIndex="10" Text="Lookup" Width="90px" />
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style3">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%; margin-top: 0px;">

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" align="right">
                                                                 <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                                    Width="180px">IPO Name</asp:Label>
                                                                </td>
                                                            <td style="width: 200px;">
                                                               :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                               <b>  <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="180px"></asp:Label></b>
                                                                </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                               
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" align="right" class="auto-style1">
                                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="165px">Month</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlmonth" runat="server" class="form-control txtbox" TabIndex="3"
                                                                    Height="33px" Width="180px" AutoPostBack="True">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">January</asp:ListItem>
                                                                    <asp:ListItem Value="2">February</asp:ListItem>
                                                                    <asp:ListItem Value="3">March</asp:ListItem>
                                                                    <asp:ListItem Value="4">April</asp:ListItem>
                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                    <asp:ListItem Value="6">June</asp:ListItem>
                                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                                    <asp:ListItem Value="8">August</asp:ListItem>
                                                                    <asp:ListItem Value="9">September</asp:ListItem>
                                                                    <asp:ListItem Value="10">October</asp:ListItem>
                                                                    <asp:ListItem Value="11">November</asp:ListItem>
                                                                    <asp:ListItem Value="12">December</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                           
                                                             <td style="padding: 5px; margin: 5px" align="right">
                                                                <asp:Label ID="Label365" runat="server" CssClass="LBLBLACK" Width="113px">Year</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" align="left">
                                                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="4"
                                                                    Width="113px" AutoPostBack="True">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                       
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                               
                                                
                                            </tr>
                                           

                                        
                                        </table>
                                    </div>

                                            <div class="row">
                                                <div class="col-sm-2 form-group">
                                                </div>
                                                <div class="col-sm-8 form-group">
                                                    <table style="width: 100%" class="table table-hover">
                                                          
                                                        <thead class="thead-dark" style="align-content:center">
                                                            <tr>
                                                                <th style="width: 10%">SI.No</th>
                                                                <th style="width: 70%">Name of the Form</th>
                                                                <th style="width: 20%">Status</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 10%">
                                                                    <label class="control-label">
                                                                        1
                                                                    </label>
                                                                </td>
                                                                <td style="width: 70%">
                                                                    <label class="control-label">
                                                                        Stressed asset bank wise report
                                                                    </label>
                                                                </td>
                                                                <td style="width: 20%">
                                                                    <asp:label class="control-label" id="lblStressedassetbank" runat="server">
                                                                        
                                                                    </asp:label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 10%">
                                                                    <label class="control-label">
                                                                        2
                                                                    </label>
                                                                </td>
                                                                <td style="width: 70%">
                                                                    <label class="control-label">
                                                                       Bank Visit Report(Loan Sanctioned Report)
                                                                    </label>
                                                                </td>
                                                                <td style="width: 20%">
                                                                    <asp:label class="control-label" id="lblBANKVISITREPORT" runat="server">
                                                                        
                                                                    </asp:label>
                                                                  <%--  <asp:image ID="img1" runat="server" Height="20px" Width="20px" ImageUrl="~/images/fill-new.jpg" />--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 10%">
                                                                    <label class="control-label">
                                                                        3
                                                                    </label>
                                                                </td>
                                                                <td style="width: 70%">
                                                                    <label class="control-label">
                                                                       Vehicle Inspection
                                                                    </label>
                                                                </td>
                                                                <td style="width: 20%">
                                                                    
                                                                     <asp:label class="control-label" id="lblVEHICLEINSPECTION" runat="server">
                                                                        
                                                                    </asp:label>
                                                                </td>
                                                            </tr>
                                                               <tr>
                                                                <td style="width: 10%">
                                                                    <label class="control-label">
                                                                        4
                                                                    </label>
                                                                </td>
                                                                <td style="width: 70%">
                                                                    <label class="control-label">
                                                                        Closed Units
                                                                    </label>
                                                                </td>
                                                                <td style="width: 20%">
                                                                    <asp:label class="control-label" id="lblClosedUnits" runat="server">
                                                                   
                                                                    </asp:label>
                                                                   
                                                                </td>
                                                            </tr>
                                                        
                                                            <tr>
                                                                <td style="width: 10%">
                                                                    <label class="control-label">
                                                                        5
                                                                    </label>
                                                                </td>
                                                                <td style="width: 70%">
                                                                    <label class="control-label">
                                                                        PMEGP & MUDRA Registration
                                                                        
                                                                    </label>
                                                                </td>
                                                                <td style="width: 20%">
                                                                    <asp:label class="control-label" id="lblPMEGPMUDRA" runat="server">
                                                                   
                                                                    </asp:label>
                                                                  
                                                                </td>
                                                            </tr>
                                                          
                                                         
                                                            <tr>
                                                                <td style="width: 10%">
                                                                    <label class="control-label">
                                                                        6
                                                                    </label>
                                                                </td>
                                                                <td style="width: 70%">
                                                                    <label class="control-label">
                                                                        Industrial Catalogue
                                                                    </label>
                                                                </td>
                                                                <td style="width: 20%">
                                                                   
                                                                     <asp:label class="control-label" id="lblIndustrialCatalogue" runat="server">
                                                                   
                                                                    </asp:label>
                                                                </td>
                                                            </tr>

                                                                <tr>
                                                                <td style="width: 10%">
                                                                    <label class="control-label">
                                                                        7
                                                                    </label>
                                                                </td>
                                                                <td style="width: 70%">
                                                                    <label class="control-label">
                                                                        TS-IPASS
                                                                    </label>
                                                                </td>
                                                                <td style="width: 20%">
                                                                    <asp:label class="control-label" id="lblTSIPASS" runat="server">
                                                                        
                                                                    </asp:label>
                                                                    
                                                                </td>
                                                            </tr>
                                                              <tr>
                                                                <td style="width: 10%">
                                                                    <label class="control-label">
                                                                        8
                                                                    </label>
                                                                </td>
                                                                <td style="width: 70%">
                                                                    <label class="control-label">
                                                                        	Advance Subsidy
                                                                    </label>
                                                                </td>
                                                                <td style="width: 20%">
                                                                   
                                                                     <asp:label class="control-label" id="lblAdvanceSubsidy" runat="server">
                                                                   
                                                                    </asp:label>
                                                                </td>
                                                            </tr>
                                                           
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="col-sm-2 form-group">
                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <div class="col-sm-2 form-group">
                                                </div>
                                                 <div class="col-sm-8 form-group">
                                                     <asp:HyperLink id="MyLink" NavigateUrl="IPOReportPrintPage.aspx" CssClass="blink1" runat="server">Click Here to Verify Details</asp:HyperLink>

                                                </div>
                                                <div class="col-sm-8 form-group" align="center">
                                                    <asp:Button ID="BtnSave1" CssClass="btn btn-blue px-4 title5" runat="server" Text="Submit Application Form" OnClick="BtnSave1_Click"/>
                                                </div>
                                                <div class="col-sm-2 form-group">

                                                </div>

                                            </div>

                                             <div class="row">
                                                <div class="col-sm-2 form-group">
                                                </div>
                                                <div class="col-sm-8 form-group" align="center">
                                                   <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-2 form-group">

                                                </div>

                                            </div>
                                            <div>
                                                
                                            </div>
                                           
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>




</asp:Content>

