<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Maintenance.aspx.cs" Inherits="Maintenance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Temporarily Unavailable</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <style>
        * {
            box-sizing: border-box;
        }

        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background: #f4f8fc;
            color: #17365d;
        }

        .page {
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 25px;
        }

        .content {
            width: 100%;
            max-width: 650px;
            text-align: center;
            background: #ffffff;
            padding: 45px 30px;
            border-radius: 16px;
            box-shadow: 0 8px 35px rgba(30, 70, 110, 0.08);
        }

        .server-icon {
            width: 150px;
            height: 110px;
            margin: 0 auto 25px;
            position: relative;
        }

        .server-box {
            background: #234c72;
            height: 30px;
            border-radius: 7px;
            margin-bottom: 8px;
            box-shadow: inset 0 -4px rgba(0, 0, 0, 0.12);
        }

            .server-box::after {
                content: "";
                display: block;
                float: right;
                width: 10px;
                height: 10px;
                margin: 10px 12px;
                border-radius: 50%;
                background: #ff6565;
            }

        .warning {
            position: absolute;
            right: -20px;
            top: 30px;
            font-size: 48px;
            color: #ff624d;
            background: white;
            border-radius: 50%;
            line-height: 1;
        }

        h1 {
            font-size: 34px;
            margin: 10px 0;
        }

        h2 {
            font-size: 21px;
            font-weight: normal;
            color: #41648b;
            margin: 15px 0;
        }

        p {
            font-size: 16px;
            line-height: 1.7;
            color: #667b91;
        }

        .button {
            display: inline-block;
            margin-top: 18px;
            padding: 14px 30px;
            background: #1675cc;
            color: white;
            border: none;
            border-radius: 7px;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
        }

            .button:hover {
                background: #105da6;
            }

        .note {
            margin-top: 25px;
            font-size: 13px;
            color: #8799ab;
        }

        @media (max-width: 480px) {
            .content {
                padding: 35px 20px;
            }

            h1 {
                font-size: 28px;
            }
        }
    </style>  
</head>
<body>
    <form id="form1" runat="server">
        <div class="page">
            <div class="content">

                <div class="server-icon">
                    <div class="server-box"></div>
                    <div class="server-box"></div>
                    <div class="server-box"></div>
                    <div class="warning">&#9888;</div>
                </div>

                <h1>Server is temporarily unavailable</h1>

                <h2>We are working on it...</h2>

                <p>                    
                    Our team is working to restore the service
                    as soon as possible.               
                </p>        

            </div>
        </div>
    </form>
</body>
</html>
