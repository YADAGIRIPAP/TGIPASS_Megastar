<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="AdminUploads.aspx.cs" Inherits="UI_TSiPASS_AdminUploads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- PAGE LEVEL STYLES -->
    <link href="assets/css/bootstrap-fileupload.min.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />


    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Admin Page</a> </li>
        </ol>
    </div>
    <div id="success" runat="server" visible="false" class="alert alert-success">
        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Gallery Uploads
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label class="control-label col-lg-4">Pre Defined Image</label>
                        <div class="">
                            <div class="fileupload fileupload-new" data-provides="fileupload">
                                <div class="fileupload-new thumbnail" style="width: 300px; height: 250px;">
                                    <img src="assets/img/demoUpload.jpg" style="max-width: 300px; height: 250px;" alt="" />
                                </div>
                                <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 300px; max-height: 250px; line-height: 20px;"></div>
                                <div>
                                    <span class="btn btn-file btn-primary">
                                        <span class="fileupload-new">Select image</span>
                                        <span class="fileupload-exists">Change</span>
                                        <input id="MyFileUpload" runat="server" class="fileupload-new" type="file" /></span>
                                    <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="fileupload">Remove</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:Button ID="btnsave" class="btn btn-success fileupload-exists" Width="120px" runat="server" Text="Save Image" OnClick="btnsave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <!--   Basic Table  -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    Post Latest News
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Text area</label>
                        <textarea class="form-control" id="txtnews" runat="server" rows="9"></textarea><br />
                         <asp:Button ID="btnpostnews" class="btn btn-success" Width="120px" runat="server" Text="Post News" OnClick="btnpostnews_Click" />
                    </div>
                </div>
            </div>
            <!-- End  Basic Table  -->
        </div>
    </div>

      <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                   CM Photo Upload
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label class="control-label col-lg-4">Pre Defined Image</label>
                        <div class="">
                            <div class="fileupload fileupload-new" data-provides="fileupload">
                                <div class="fileupload-new thumbnail" style="width: 200px; height: 150px;">
                                    <img src="assets/img/demoUpload.jpg" style="max-width: 200px; height: 150px;" alt="" />
                                </div>
                                <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 200px; max-height: 150px; line-height: 20px;"></div>
                                <div>
                                    <span class="btn btn-file btn-primary">
                                        <span class="fileupload-new">Select image</span>
                                        <span class="fileupload-exists">Change</span>
                                        <input id="CMphoto" runat="server" class="fileupload-new" type="file" /></span>
                                    <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="fileupload">Remove</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:Button ID="btnCMupload" class="btn btn-success fileupload-exists" Width="120px" runat="server" Text="Save Image" OnClick="btnCMupload_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <!--   Basic Table  -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    I.T Minister Photo Upload
                </div>
               <div class="panel-body">
                    <div class="form-group">
                        <label class="control-label col-lg-4">Pre Defined Image</label>
                        <div class="">
                            <div class="fileupload fileupload-new" data-provides="fileupload">
                                <div class="fileupload-new thumbnail" style="width: 200px; height: 150px;">
                                    <img src="assets/img/demoUpload.jpg" style="max-width: 200px; height: 150px;" alt="" />
                                </div>
                                <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 200px; max-height: 150px; line-height: 20px;"></div>
                                <div>
                                    <span class="btn btn-file btn-primary">
                                        <span class="fileupload-new">Select image</span>
                                        <span class="fileupload-exists">Change</span>
                                        <input id="ITminsterphoto" runat="server" class="fileupload-new" type="file" /></span>
                                    <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="fileupload">Remove</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:Button ID="btnitminster" class="btn btn-success fileupload-exists" Width="120px" runat="server" Text="Save Image" OnClick="btnitminster_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End  Basic Table  -->
        </div>
    </div>
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.js"></script>
    <!-- PAGE LEVEL SCRIPTS -->
    <script src="assets/js/bootstrap-fileupload.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>
</asp:Content>

