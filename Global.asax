<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        PreSendRequestHeaders += Application_PreSendRequestHeaders;

        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }
    void Applcation_BeginRequest(object sender, EventArgs e)
    {
        if (Request.Headers["Cookie"] != null)
        {
            // Get the cookies from the request
            var cookies = Request.Headers["Cookie"];

            // Check if the SameSite attribute is already set in the cookies
            if (!cookies.Contains("SameSite="))
            {
                // Set the SameSite attribute for the cookies
                Response.AddHeader("Set-Cookie", "{cookies}; SameSite=Lax");
            }
        }
        Response.Headers.Remove("Server");
    }
    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        string rawUrl = Request.RawUrl;
        if (rawUrl.Contains("<") || rawUrl.Contains(">"))
        {
            Response.Redirect("https://ipass.telangana.gov.in/tshome.aspx", true);
        }

    }

    void Session_Start(object sender, EventArgs e)
    {
        //if (Session["uid"] == null || Session["uid"].ToString() == "")
        //{
        //  HttpContext.Current.Response.Redirect("~/tshome.aspx");
        //}
    }
    protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Headers.Remove("Server");
        HttpContext.Current.Response.Headers.Remove("X-Powered-By");
        HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
        HttpContext.Current.Response.Headers.Remove("X-Server");
        //Response.Headers.Set("Server", "My Web Server");
        HttpContext.Current.Response.Headers.Add("Server", "My Web Server");
        //var httpContext = HttpContext.Current;
        //if (httpContext != null)
        //{
        //    var cookieValueSuffix = ";  SameSite=none";

        //    var cookies = httpContext.Response.Cookies;
        //    for (var i = 0; i < cookies.Count; i++)
        //    {
        //        var cookie = cookies[i];
        //        cookie.Value += cookieValueSuffix;
        //    }
        //}
        //if ((Context.Request.UrlReferrer == null || Context.Request.Url.Host != Context.Request.UrlReferrer.Host))
        //{
        //    Context.Response.Redirect("~/tshome.aspx", false);
        //}
        string rawUrl = Request.RawUrl;
        if (rawUrl.Contains("<") || rawUrl.Contains(">"))
        {
            Response.Redirect("https://ipass.telangana.gov.in/tshome.aspx", true);
        }
    }
    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        // Define the expected Host header value
        //string expectedHost = "http://218.185.250.36"; // Replace with your expected Host header

        // Get the incoming Host header from the request
        //string requestHost = HttpContext.Current.Request.Headers["Host"];

        //// Check if the Host header matches the expected value
        ////if (!string.Equals(requestHost, expectedHost, StringComparison.OrdinalIgnoreCase))
        //if (!(requestHost.Contains("https://ipass.telangana.gov.in/")))
        //{
        //    // Log the unauthorized request or take other appropriate action (e.g., return an error response)
        //    Response.Headers.Remove("Server");
        //    HttpContext.Current.Response.StatusCode = 403; // Forbidden
        //    HttpContext.Current.Response.StatusDescription = "Invalid Host Header";
        //    HttpContext.Current.Response.End();
        //    Response.Headers.Remove("Server");
        //}
        string rawUrl = Request.RawUrl;
        if (rawUrl.Contains("<") || rawUrl.Contains(">"))
        {
            string encodedUrl = Server.UrlEncode(rawUrl);
            Response.Redirect("https://ipass.telangana.gov.in/tshome.aspx", true);
        }

    }
    void Session_End(object sender, EventArgs e)
    {

        //if (Session["uid"] == null || Session["uid"].ToString() == "")
        //{
        //    HttpContext.Current.Response.Redirect("~/tshome.aspx");
        //}

    }

</script>
