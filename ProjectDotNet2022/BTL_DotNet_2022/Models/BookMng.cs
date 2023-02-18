using BTL_DotNet_2022.FrmMaster;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DotNet_2022.Models
{
    internal class BookMng
    {
        //=== Properties
        private List<Book> books = new List<Book>();

        //=== Method
        public BookMng()
        {
            this.books = DB.getBookList();
        }

        public List<Book> getListBook() { return this.books; }

        public Book? getBook(int BookId)
        {
            foreach(Book book in this.books)
            {
                if(book.getBookId() == BookId) return book;
            }
            return null;
        }

        public List<Book> getListBookWithClause(string query)
        {
            List<Book> books = new List<Book>();

            try
            {
                // Connection DB
                DB.connection();

                SqlCommand cmd = new SqlCommand(query, DB.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add
                    (
                        new Book
                            (
                                (int)reader.GetValue(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                (Decimal)reader.GetValue(4),
                                reader.GetDateTime(5),
                                reader.GetString(6),
                                (int)reader.GetValue(7)
                            )
                    );
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {

                // Disconnection DB
                DB.disconnection();
            }

            return books;
        }

        public bool addBook(Book book)
        {
            int numRecords = 0;

            try
            {
                // connect Database
                DB.connection();

                // Use procedure to add book
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertBook";
                cmd.Connection = DB.conn;

                // Set param for procedure
                cmd.Parameters.Add(new SqlParameter("@BookName",book.getBookName()));
                cmd.Parameters.Add(new SqlParameter("@BookGenre", book.getBookGenre()));
                cmd.Parameters.Add(new SqlParameter("@BookAuthor", book.getBookAuthor()));
                cmd.Parameters.Add(new SqlParameter("@BookPrice", book.getBookPrice()));
                cmd.Parameters.Add(new SqlParameter("@ReleaseDate", book.getReleaseDate()));
                cmd.Parameters.Add(new SqlParameter("@BookImage", book.getBookImage()));
                cmd.Parameters.Add(new SqlParameter("@InventoryQuantity", book.getInventoryQuantity()));

                numRecords = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                // Disconnect database
                DB.disconnection();
            }

            if(numRecords>0)
            {
                // Refresh data in book list ( unneccessary )
                //this.books = DB.getBookList();
                return true;
            }
            return false;
        }

        public bool deleteBook(Book book)
        {
            int numRecords = 0;

            try
            {
                // Connection db
                DB.connection();

                // Delete all records have book id of parameter in <tblOrders_Detail>
                string query = "Delete From tblOrders_Detail " +
                               "Where BookId = "+book.getBookId().ToString();
                SqlCommand cmd = new SqlCommand(query, DB.conn);
                cmd.ExecuteNonQuery();

                // Execute delete book in tblBook
                query = "Delete From tblBook Where BookId='" + book.getBookId().ToString() + "'";
                cmd = new SqlCommand(query, DB.conn);
                numRecords = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                // Disconnection DB
                DB.disconnection();
            }

            if(numRecords > 0)
            {
                //this.books.Remove(book); unnecessary
                return true;
            }
            return false;
        }

        public bool editBook(Book book)
        {
            int numRecords = 0;
            try
            {
                // Connect db
                DB.connection();

                // Use store procedure ( EditBook ) to edit book
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "EditBook";
                cmd.Connection = DB.conn;

                cmd.Parameters.Add(new SqlParameter("@BookId", book.getBookId()));
                cmd.Parameters.Add(new SqlParameter("@BookName", book.getBookName()));
                cmd.Parameters.Add(new SqlParameter("@BookGenre", book.getBookGenre()));
                cmd.Parameters.Add(new SqlParameter("@BookAuthor", book.getBookAuthor()));
                cmd.Parameters.Add(new SqlParameter("@BookPrice", book.getBookPrice()));
                cmd.Parameters.Add(new SqlParameter("@ReleaseDate", book.getReleaseDate()));
                cmd.Parameters.Add(new SqlParameter("@BookImage", book.getBookImage()));
                cmd.Parameters.Add(new SqlParameter("@InventoryQuantity", book.getInventoryQuantity()));

                numRecords = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                // Disconnect db
                DB.disconnection();
            }


            if (numRecords > 0)
            {
                return true;
            }
            return false;
        }


        public List<Book> getBookSeller(string numRecord="", string orderBy = "ASC")
        {
            List<Book> books = new List<Book>();
            // Connect db
            DB.connection();

            /*string query = "Select Top 3 BookId, Sum(Amount) From tblOrders_Detail " +
                           "Group By BookId " +
                           "Order By Sum(Amount) DESC";*/ 

            string query = "Select "+numRecord+" BookId ,Sum(Amount) From tblOrders_Detail "+
                            "Where Exists(  Select * From tblOrders "+
                                            "Where tblOrders.OrdersId = tblOrders_Detail.OrdersId "+
                                            "And tblOrders.OrdersStatus = 'accept'" +
                                        ")"+
                            "Group by BookId "+
                            "Order By Sum(Amount) "+orderBy;
            SqlCommand cmd = new SqlCommand(query, DB.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Book? bookRead = this.getBook((int)reader.GetValue(0));
                    bookRead.setAmountSold((int)reader.GetValue(1));

                    books.Add(bookRead);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                // Disconnect db
                reader.Close();
                DB.disconnection();
            }

            return books;
        }

    }
}
