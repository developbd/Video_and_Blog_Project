using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Bdbay
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Session["UserFastName"] != null && Session["UserLastName"] != null)
            {
                string Row = "";
                check chk = new check();
                chk.ConfigarationName = "video";
                int todaydate = Convert.ToInt32(DateTime.Now.ToString("dd"));
                int todayMonth = Convert.ToInt32(DateTime.Now.ToString("MM"));
                for (int i = 1; i <= todaydate; i++)
                {
                    int view = chk.int32Check("select count(*) from DailyView where Date=" + i + " and Month=" + todayMonth + " and UserID='" + Session["UserID"].ToString() + "' ");
                    Row += "[" + i + "," + view + "],";
                }

                scriptShow.Controls.Add(new LiteralControl(@"<script type='text/javascript'>google.charts.load('current', {packages: ['corechart', 'line']});google.charts.setOnLoadCallback(drawBasic);function drawBasic() { var data = new google.visualization.DataTable(); data.addColumn('number', 'Day'); data.addColumn('number', 'View');data.addRows([" + Row + "]);var options = { hAxis: {title: 'Montly View'},vAxis: {title: 'Daily View'}};var chart = new google.visualization.LineChart(document.getElementById('chart_div')); chart.draw(data, options);}</script>"));
            }
            else
            {
                Response.Redirect("Login");
            }
        }
    }
}