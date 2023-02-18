using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace BTL_DotNet_2022.Models
{
    internal static class DB
    {
        public static SqlConnection conn = null;
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\ProjectDotNet2022\BTL_DotNet_2022\Database\QuanLyCuaHangSach.mdf;Integrated Security=True;Connect Timeout=30";
        //public static string connectionString = Properties.Settings.Default.QLCSH_ConnectionString;
        public static void connection()
        {
            if(DB.conn == null)
            {
                DB.conn = new SqlConnection(DB.connectionString);
            }
            if(DB.conn.State != ConnectionState.Open)
            {
                DB.conn.Open();
            }
        }

        public static void disconnection()
        {
            // close connection database
            DB.conn.Close();
            DB.conn.Dispose();
            DB.conn = null;
        }


        public static DataTable getDataTable(string tableName)
        {
            // connection to database
            DB.connection();
            DataTable tb = new DataTable();

            string query = "Select * From " + tableName;
            SqlDataAdapter adapter = new SqlDataAdapter(query, DB.conn);
            adapter.Fill(tb);

            // disconnection to database and return value
            DB.disconnection();
            return tb;
        }

        public static DataTable getDataTableWithClause(string query)
        {
            // connection to database
            DB.connection();
            DataTable tb = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, DB.conn);
            adapter.Fill(tb);

            // disconnection to database and return value
            DB.disconnection();
            return tb;
        }

        public static List<Book> getBookList()
        {
            // Connection to database
            DB.connection();

            List<Book> books = new List<Book>();
            string query = "Select * From tblBook Order By BookId";
            SqlCommand cmd = new SqlCommand(query, DB.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    int BookId = (int)reader.GetValue(0);
                    string BookName = reader.GetString(1);
                    string BookGenre = reader.GetString(2);
                    string BookAuthor = reader.GetString(3);
                    decimal BookPrice = (decimal)reader.GetValue(4);
                    DateTime ReleaseDate = reader.GetDateTime(5).Date;
                    string BookImage = reader.GetString(6);
                    int InventoryQuantity = (int)reader.GetValue(7);

                    // add into list book
                    books.Add(new Book(BookId,
                                       BookName,
                                       BookGenre,
                                       BookAuthor,
                                       BookPrice, 
                                       ReleaseDate,
                                       BookImage,
                                       InventoryQuantity));
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                // disconnection DB
                DB.disconnection();
                reader.Close();
            }
            return books;
        }

        public static Orders getOrders(int ordersId)
        {
            Orders orders = new Orders();
            BookMng bookMng = new BookMng();

            DB.connection();
            string query = "Select * From tblOrders_Detail " +
                           "Where OrdersId = '"+ordersId+"'";
            SqlCommand cmd = new SqlCommand(query, DB.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Book? book = bookMng.getBook(Convert.ToInt32(reader.GetValue(1)));
                    int amount = (int)reader.GetValue(2);

                    orders.addOrdersDetail( book, amount );
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                DB.disconnection();
                reader.Close();
            }

            return orders;
        }

        public static void addOrders(string username, Orders orders)
        {
            try
            {
                DB.connection();

                // User procedure to insert orders
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertOrders";
                cmd.Connection = DB.conn;

                // Add parameter for stored procedure
                cmd.Parameters.Add(new SqlParameter("@Username", username));

                // Execute
                cmd.ExecuteNonQuery(); // Add orders

                // Step 2: Get ordersId of orders newly add
                string query = "Select Top 1 OrdersId From tblOrders "+
                               "Where Username = '"+username+"' " +
                               "Order by OrdersId DESC";

                cmd = new SqlCommand(query, DB.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int ordersId = (int)reader.GetValue(0);
                reader.Close();

                // Step 3: Add orders detail
                foreach(OrdersDetail item in orders.getOrdersDetailList())
                {
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertOrders_Detail";
                    cmd.Connection = DB.conn;

                    // set param
                    cmd.Parameters.Add(new SqlParameter("@OrdersId", ordersId));
                    cmd.Parameters.Add(new SqlParameter("@BookId", item.getBookId()));
                    cmd.Parameters.Add(new SqlParameter("@Amount", item.getAmount()));

                    // Execute
                    cmd.ExecuteNonQuery();
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                DB.disconnection();
            }
        }

        public static void changeOrdersStatus(int ordersId, string newOrdersState)
        {
            try
            {
                DB.connection();

                string query = "Update tblOrders " +
                               "Set OrdersStatus = '" + newOrdersState + "' " +
                               "Where OrdersId = " + ordersId.ToString();
                SqlCommand cmd = new SqlCommand(query, DB.conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                DB.disconnection();

            }
        }

        public static void addProcessing_Orders(int ordersId, string username)
        {
            try
            {
                DB.connection();

                // Use stored procedure to add processing orders
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertProcessing_Orders";
                cmd.Connection = DB.conn;

                // Set parameter for storedProcedure
                cmd.Parameters.Add(new SqlParameter("@OrdersId", ordersId));
                cmd.Parameters.Add(new SqlParameter("@Username", username));

                cmd.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                DB.disconnection();
            }
        }
    }
}
