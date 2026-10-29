using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cls_nswsgetlistdocuments
/// </summary>
public class Cls_nswsgetlistdocuments
{
    //public Cls_nswsgetlistdocuments()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}


    public class Response
    {
        public string documentId { get; set; }
        public string fileTitle { get; set; }
        public string contentType { get; set; }
        public string uploadedDate { get; set; }
        public string approvalId { get; set; }
        public string swsId { get; set; }
        public string investorReqId { get; set; }
        public string mnstryDprtmntId { get; set; }
        public string version { get; set; }
        public string latestVersion { get; set; }
        public string md5Hash { get; set; }
    }

    public class Responseofpulllistdocapi
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Response> response { get; set; }
    }

    //public class resinsertnswsfile
    //{
    //    public string documentId { get; set; }
    //    public string fileTitle { get; set; }
    //    public string contentType { get; set; }
    //    public string uploadedDate { get; set; }
    //    public string approvalId { get; set; }
    //    public string swsId { get; set; }
    //    public string investorReqId { get; set; }
    //    public string mnstryDprtmntId { get; set; }
    //    public string version { get; set; }
    //    public string latestVersion { get; set; }
    //    public string md5Hash { get; set; }
    //    public string tsipassAppID { get; set; }
    //    public string CategoryType { get; set; }
    //    public string intDeptID { get; set; }
    //    public string intApprovalID { get; set; }
    //    public string NSWSContentID { get; set; }
    //    public string responsedata { get; set; }
    //    public string filepath { get; set; }
    //}

}