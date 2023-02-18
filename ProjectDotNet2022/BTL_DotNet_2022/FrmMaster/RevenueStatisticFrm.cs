using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BTL_DotNet_2022.Models;
using System.Data.SqlClient;

namespace BTL_DotNet_2022.FrmMaster
{
    public partial class RevenueStatisticFrm : Form
    {
        // date
        private int currentDay = Convert.ToInt32(DateTime.Now.ToString("dd"));
        private int currentMonth = Convert.ToInt32(DateTime.Now.ToString("MM"));
        private int currentYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));

        public RevenueStatisticFrm()
        {
            InitializeComponent();

            // Initial cbx statistic follow
            cbxStatisticFollow.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxStatisticFollow.Items.Add("Follow day: "+ DateTime.Now.ToString("dd") +"  ("+ DateTime.Now.ToString("dd-MM-yyyy") +")");
            cbxStatisticFollow.Items.Add("Follow month: " + DateTime.Now.ToString("MM") + "  (" + DateTime.Now.ToString("dd-MM-yyyy") + ")");
            cbxStatisticFollow.Items.Add("Follow year: " + DateTime.Now.ToString("yyyy"));

            // lsv
            lsvDataAnalys.View = View.Details; // Important
            lsvDataAnalys.HeaderStyle = ColumnHeaderStyle.None;
            lsvDataAnalys.Columns.Add("Title", 100);
            lsvDataAnalys.Columns.Add("Value", 220);
        }

        private void showPlot(string plotTitle,string xLable, double[] dataX, string yLable, double[] dataY)
        {
            var plt = new ScottPlot.Plot(400, 300);
            //plt.AddScatter(dataX, dataY);
            var bar = plt.AddBar(dataY, dataX);

            bar.ShowValuesAboveBars = true;

            plt.XLabel(xLable);
            plt.YLabel(yLable);
            plt.Title(plotTitle);

            //plt.SaveFig("C:\\Users\\Admin\\Downloads\\thuanhieu.png");

            FormsPlotViewer x = new ScottPlot.FormsPlotViewer(plt);
            x.TopLevel = false;
            panel3.Controls.Add(x);

            x.FormBorderStyle = FormBorderStyle.None;
            x.Dock = DockStyle.Fill;
            x.Show();
        }

        private void cbxStatisticFollow_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            lsvDataAnalys.Items.Clear();

            int index = cbxStatisticFollow.SelectedIndex;
            switch (index)
            {
                case 0: // ===== Folow day =====
                    
                    //Step 1: set dataX ( hour from 0 to 23 )
                    double[] dataX = new double[24];
                    for (int i = 0; i < 24; i++) dataX[i]=i;
                    
                    //Step 2: set dataY ( sum of all orders in each hour)
                    double[] dataY = new double[24];
                    for(int i = 0; i < 24; i++)
                    {
                        dataY[i]=0;

                        // Get all orders id has been "accept" in ( hour i - current month - current year)
                        string query = "Select OrdersId From tblOrders "+
                                    "Where Datepart(hour, OrdersDate) = '"+i+"' "+
                                    "And Datepart(day, OrdersDate) = '"+ this.currentDay +"' "+
                                    "And Datepart(month, OrdersDate) = '"+this.currentMonth+"' "+
                                    "And Datepart(year, OrdersDate) = '"+this.currentYear+"' "+
                                    "And OrdersStatus = 'accept'";
                        DB.connection();
                        SqlCommand cmd = new SqlCommand(query, DB.conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        
                        List<int> ordersIdList = new List<int>();
                        while (reader.Read())
                        {
                            ordersIdList.Add((int)reader.GetValue(0));
                        }
                        reader.Close();
                        DB.disconnection();

                        foreach (int ordersId in ordersIdList)
                        {
                            dataY[i] += (double) DB.getOrders(ordersId).getTotalPrice();   
                        }
                    }

                    //Step 3: Show plot
                    this.showPlot("Revenue statistic today: " + DateTime.Now.ToString("dd-MM-yyyy"),
                                  "Hour ( 0 -> 23)",
                                  dataX,
                                  "Revenue ($)",
                                  dataY);

                    // Step 4: Show data alanys
                    this.showDataAnalys(dataY);

                    break;
                case 1: // In month
                    //Step 1: set dataX ( day from 1 to day of current month )
                    int dayOfMonth = this.GetDayOfMonth(this.currentMonth, this.currentYear);
                    double[] dataXM = new double[dayOfMonth];
                    for (int i = 0; i < dayOfMonth; i++) dataXM[i] = i+1;

                    //Step 2: set dataY ( sum of all orders in each day)
                    double[] dataYM = new double[dayOfMonth];
                    for (int i = 0; i < dayOfMonth; i++)
                    {
                        dataYM[i] = 0;

                        // Get all orders id has been "accept" in ( day 1 -> day ... of current month - current year)
                        string query = "Select OrdersId From tblOrders " +
                                    "Where Datepart(day, OrdersDate) = '" + (i+1) + "' " +
                                    "And Datepart(month, OrdersDate) = '" + this.currentMonth + "' " +
                                    "And Datepart(year, OrdersDate) = '" + this.currentYear + "' " +
                                    "And OrdersStatus = 'accept'";
                        DB.connection();
                        SqlCommand cmd = new SqlCommand(query, DB.conn);
                        SqlDataReader reader = cmd.ExecuteReader();

                        List<int> ordersIdList = new List<int>();
                        while (reader.Read())
                        {
                            ordersIdList.Add((int)reader.GetValue(0));
                        }
                        reader.Close();
                        DB.disconnection();

                        foreach (int ordersId in ordersIdList)
                        {
                            dataYM[i] += (double)DB.getOrders(ordersId).getTotalPrice();
                        }
                    }

                    //Step 3: Show plot
                    this.showPlot("Revenue statistic this month: " + DateTime.Now.ToString("MMMM - yyyy"),
                                  "Day ( 1 -> "+dayOfMonth+")",
                                  dataXM,
                                  "Revenue ($)",
                                  dataYM);

                    // Step 4: Show data alanys
                    this.showDataAnalys(dataYM);

                    break;
                case 2: // In year
                    //Step 1: set dataX ( day from 1 to day of current month )
                    double[] dataXY = new double[12];
                    for (int i = 0; i < 12; i++) dataXY[i] = i + 1;

                    //Step 2: set dataY ( sum of all orders in each day)
                    double[] dataYY = new double[12];
                    for (int i = 0; i < 12; i++)
                    {
                        dataYY[i] = 0;

                        // Get all orders id has been "accept" in ( month 1 -> month 12 of current year)
                        string query = "Select OrdersId From tblOrders " +
                                    "Where Datepart(month, OrdersDate) = '" + (i+1) + "' " +
                                    "And Datepart(year, OrdersDate) = '" + this.currentYear + "' " +
                                    "And OrdersStatus = 'accept'";
                        DB.connection();
                        SqlCommand cmd = new SqlCommand(query, DB.conn);
                        SqlDataReader reader = cmd.ExecuteReader();

                        List<int> ordersIdList = new List<int>();
                        while (reader.Read())
                        {
                            ordersIdList.Add((int)reader.GetValue(0));
                        }
                        reader.Close();
                        DB.disconnection();

                        foreach (int ordersId in ordersIdList)
                        {
                            dataYY[i] += (double)DB.getOrders(ordersId).getTotalPrice();
                        }
                    }

                    //Step 3: Show plot
                    this.showPlot("Revenue statistic this year: " + DateTime.Now.ToString("yyyy"),
                                  "Month ( 1 -> 12 )",
                                  dataXY,
                                  "Revenue ($)",
                                  dataYY);

                    // Step 4: Show data alanys
                    this.showDataAnalys(dataYY);

                    break;
            }         
        }

        private void showDataAnalys(double[] arr)
        {
            ListViewItem item = new ListViewItem("Highest: ");
            item.SubItems.Add(arr.Max().ToString() + "$");
            lsvDataAnalys.Items.Add(item);

            item = new ListViewItem("Lowest: ");
            item.SubItems.Add(arr.Min().ToString() + "$");
            lsvDataAnalys.Items.Add(item);

            item = new ListViewItem("Average: ");
            item.SubItems.Add(arr.Average().ToString() + "$");
            lsvDataAnalys.Items.Add(item);

        }

        private int GetDayOfMonth(int month, int year)
        {
            if(month<1 || month > 12)
            {
                throw new Exception("Number of month is not valid!");
            }

            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    return 31;
                case 2:
                    // Check leap year
                    if (year % 400 == 0) return 29;
                    if (year % 4 == 0 && year % 100 != 0) return 29;
                    return 28;
                default:
                    return 30;

            }
            
        }

    }
}
