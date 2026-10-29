using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_DIPCmeetingsPendencyWise : System.Web.UI.Page
{
    int meetings, slcwithin, slcbeyond, dlcwithin, dlcbeyond, totlwithin, totlbeyond;
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {          
            fillgrid();
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        string District;
        District = Session["DistrictID"].ToString();
        
        SqlParameter[] p = new SqlParameter[] {
               new SqlParameter("@District",SqlDbType.VarChar),               
                new SqlParameter("@financialYear",SqlDbType.VarChar)
           };
        p[0].Value = District;
        p[1].Value = ddlfinyear.SelectedValue;
        dsnew = gen.GenericFillDs("USP_GET_DIPC_MEETINGS_ABSTRACT_NEW_PENDENCYWISE", p);
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();

        }
        else
        {

            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }

     

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int meetings1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NOofMeetings"));
            meetings = meetings + meetings1;

            int slcwithin1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WITHIN_SLC"));
            slcwithin = slcwithin + slcwithin1;
            int slcbeyond1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BEYOND_SLC"));
            slcbeyond = slcbeyond + slcbeyond1;

            int dlcwithin1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WITHIN_DLC"));
            dlcwithin = dlcwithin + dlcwithin1;
            int dlcbeyond1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BEYOND_DLC"));
            dlcbeyond= dlcbeyond + dlcbeyond1;

            int totlwithin1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WITHINNEW"));
            totlwithin = totlwithin + totlwithin1;
            int totlbeyond1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BEYOND"));
            totlbeyond = totlbeyond + totlbeyond1;

            Label lbldist = (e.Row.FindControl("DISTID") as Label);

            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=A&District=" + lbldist.Text.Trim() + "&Year=" + ddlfinyear.SelectedValue;
            }

            HyperLink h3= (HyperLink)e.Row.Cells[3].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=AA&District=" + lbldist.Text.Trim() + "&Year=" + ddlfinyear.SelectedValue;
            }

            HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=B&District=" + lbldist.Text.Trim() + "&Year=" + ddlfinyear.SelectedValue;
            }

            HyperLink h5 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=C&District=" + lbldist.Text.Trim() + "&Year=" + ddlfinyear.SelectedValue;
            }

            HyperLink h6 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=D&District=" + lbldist.Text.Trim() + "&Year=" + ddlfinyear.SelectedValue;
            }

            HyperLink h7 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=E&District=" + lbldist.Text.Trim() + "&Year=" + ddlfinyear.SelectedValue;
            }

            HyperLink h8 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=F&District=" + lbldist.Text.Trim() + "&Year=" + ddlfinyear.SelectedValue;
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = meetings.ToString();
            e.Row.Cells[3].Text = slcwithin.ToString();
            e.Row.Cells[4].Text = slcbeyond.ToString();

            e.Row.Cells[5].Text = dlcwithin.ToString();
            e.Row.Cells[6].Text = dlcbeyond.ToString();

            e.Row.Cells[7].Text = totlwithin.ToString();
            e.Row.Cells[8].Text = totlbeyond.ToString();

            //string Dist = "%";
            //HyperLink h2 = new HyperLink() ;
            //h2.Text= meetings.ToString();
            //if (h2.Text != "0")
            //{
            //    h2.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=A&District=" + Dist + "&Year=" + ddlfinyear.SelectedValue;
            //    e.Row.Cells[2].Controls.Add(h2);
            //}
            //HyperLink h3 = new HyperLink();
            //h3.Text = slcwithin.ToString();
            
            //if (h3.Text != "0")
            //{
            //    h3.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=AA&District=" + Dist + "&Year=" + ddlfinyear.SelectedValue;
            //    e.Row.Cells[3].Controls.Add(h3);
            //}

            //HyperLink h4 = new HyperLink();
            //h4.Text = slcbeyond.ToString();
            //if (h4.Text != "0")
            //{
            //    h4.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=B&District=" + Dist + "&Year=" + ddlfinyear.SelectedValue;
            //    e.Row.Cells[4].Controls.Add(h4);
            //}

            //HyperLink h5 = new HyperLink();
            //h5.Text = dlcwithin.ToString();
            //if (h5.Text != "0")
            //{
            //    h5.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=C&District=" + Dist + "&Year=" + ddlfinyear.SelectedValue;
            //    e.Row.Cells[5].Controls.Add(h5);
            //}

            //HyperLink h6 = new HyperLink();
            //h6.Text = dlcbeyond.ToString();
            //if (h6.Text != "0")
            //{
            //    h6.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=D&District=" + Dist + "&Year=" + ddlfinyear.SelectedValue;
            //    e.Row.Cells[6].Controls.Add(h6);
            //}

            //HyperLink h7 = new HyperLink();
            //h7.Text = totlwithin.ToString();
            //if (h7.Text != "0")
            //{
            //    h7.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=E&District=" + Dist + "&Year=" + ddlfinyear.SelectedValue;
            //    e.Row.Cells[7].Controls.Add(h7);
            //}

            //HyperLink h8 = new HyperLink();
            //h8.Text = totlbeyond.ToString();
            //if (h8.Text != "0")
            //{
            //    h8.NavigateUrl = "frmdipcmeetindsDrill.aspx?status=F&District=" + Dist + "&Year=" + ddlfinyear.SelectedValue;
            //    e.Row.Cells[8].Controls.Add(h8);
            //}
            //h2.ForeColor = System.Drawing.Color.White;
            //h3.ForeColor = System.Drawing.Color.White;
            //h4.ForeColor = System.Drawing.Color.White;
            //h5.ForeColor = System.Drawing.Color.White;
            //h6.ForeColor = System.Drawing.Color.White;
            //h7.ForeColor = System.Drawing.Color.White;
            //h8.ForeColor = System.Drawing.Color.White;
         
        }


        }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(2, 2, DataControlRowType.EmptyDataRow, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 3;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderGridRow.BackColor = ColorTranslator.FromHtml("#009688");
            HeaderGridRow.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            HeaderGridRow.BorderStyle = BorderStyle.Solid;
            HeaderGridRow.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
            HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

            //HeaderCell = new TableCell();
            //HeaderCell.Text = "";
            //HeaderCell.ColumnSpan = 1;
            //HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "SLC PENDENCY";
            HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "DLC PENDENCY";
            HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "TOTAL PENDENCY";
            HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);


            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);


            GridViewRow HeaderGridRownew = new GridViewRow(5, 9, DataControlRowType.EmptyDataRow, DataControlRowState.Insert);
            TableCell HeaderCellnew = new TableCell();
            HeaderCellnew.Text = "";
            HeaderCellnew.ColumnSpan = 3;
            HeaderGridRownew.Cells.Add(HeaderCellnew);

            HeaderCellnew = new TableCell();
            HeaderCellnew.Text = "No.of Applications Pending";
            HeaderCellnew.ColumnSpan = 6;
            HeaderGridRownew.Cells.Add(HeaderCellnew);

            HeaderGridRownew.BackColor = ColorTranslator.FromHtml("#009688");
            HeaderGridRownew.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            HeaderGridRownew.BorderStyle = BorderStyle.Solid;
            HeaderGridRownew.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
            HeaderGridRownew.HorizontalAlign = HorizontalAlign.Center;
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRownew);



        }


    }
}