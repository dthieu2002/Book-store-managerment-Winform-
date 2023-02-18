using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_DotNet_2022.Models;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_DotNet_2022.Models
{
    internal class UserMng
    {
        private List<User> users = new List<User>();
        public UserMng():base()
        {
            // Connection DB
            DB.connection();

            String query = "Select * From tblUser";
            SqlCommand cmd = new SqlCommand(query, DB.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    string Username = (string)reader.GetValue(0);
                    string Password = (string)reader.GetValue(1);
                    string FullName = (string)reader.GetValue(2);
                    string CCCD = (string)reader.GetValue(3);
                    string Address = (string)reader.GetValue(4);
                    string Phone = (string)reader.GetValue(5);
                    string Role = (string)reader.GetValue(6);

                    users.Add(new User(Username, Password, FullName, CCCD, Address, Phone, Role));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Has exception: " + e.ToString());
            }
            finally{
                reader.Close();
                DB.disconnection();
            }
        }

        public User getUserObj(string username)
        {
            foreach(User user in this.users)
            {
                if (user.getUsername().Equals(username)) return user;
            }
            return null;
        }

        public bool accountExists(string username, string password)
        {
            foreach(User user in this.users)
            {
                if(user.getUsername() == username)
                {
                    if (user.getPassword() == password) return true;
                }
            }
            return false;
        }

        public bool addUser(User newUser)
        {
            // Connection to db
            DB.connection();

            // 1:Use Stored Procedure to add user
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DB.conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertUser"; // name of StoredProcedure

            int numRecord = 0; // number of record affected

            try
            {
                // 2:Asign value for StoredProcedure
                cmd.Parameters.Add(new SqlParameter("@Username", newUser.getUsername()));
                cmd.Parameters.Add(new SqlParameter("@Password", newUser.getPassword()));
                cmd.Parameters.Add(new SqlParameter("@FullName", newUser.getFullName()));
                cmd.Parameters.Add(new SqlParameter("@CCCD", newUser.getCCCD()));
                cmd.Parameters.Add(new SqlParameter("@Address", newUser.getAddress()));
                cmd.Parameters.Add(new SqlParameter("@Phone", newUser.getPhone()));
                cmd.Parameters.Add(new SqlParameter("@Role", newUser.getRole()));

                // 3:Execute NonQuery
                numRecord = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("Has exception: "+e.ToString());
            }
            finally
            {
                DB.disconnection(); // dissconnection to db
            }

            if (numRecord > 0)
            {
                // add user is newly added into userList
                this.users.Add(newUser); // important
                return true;
            }
            return false;
        }

        public bool deleteUser(string username)
        {
            // Connection to db
            DB.connection();

            // Delete user in tblOrdersDetail ( 23/10 ) 
            
            string query = "Delete From tblOrders_Detail " +
                           "Where Exists( Select* From tblOrders Where tblOrders.OrdersId = tblOrders_Detail.OrdersId " +
                                "And tblOrders.Username = '"+username+"')";
            SqlCommand cmd = new SqlCommand(query, DB.conn);
            cmd.ExecuteNonQuery();

            // Delete user in tblProcessing_Orders ( 25 / 10)
            query = "Delete from tblProcessing_Orders "+
                    "Where Exists(" +
                        "Select * From tblOrders Where tblOrders.OrdersId = tblProcessing_Orders.OrdersId And tblOrders.Username = '"+username+"'"+
                    ")";
            cmd = new SqlCommand(query, DB.conn);
            cmd.ExecuteNonQuery();

            // Delete user in tblOrders ( 23 / 10)
            query = "Delete from tblOrders Where Username = '" + username + "'";
            cmd = new SqlCommand(query, DB.conn);
            cmd.ExecuteNonQuery();

            // Delete user in tblUser
            cmd = new SqlCommand();
            cmd.CommandText = "DeleteUser";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = DB.conn;

            int numRecords = 0;

            try
            {
                cmd.Parameters.Add(new SqlParameter("@Username", username));
                numRecords = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                // Disconnection to db
                DB.disconnection();
            }
            
            if(numRecords > 0)
            {
                // delete user in uses list
                this.users.Remove(this.getUserObj(username));
                return false;
            }
            return false;
        }

        public bool updateUser(User userUpdate)
        {
            // Connection DB
            DB.connection();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateUser";
            cmd.Connection = DB.conn;

            int numRecords = 0; // number of record affect
            try
            {
                // Set parameter for StoredProcedure
                cmd.Parameters.Add(new SqlParameter("@Username", userUpdate.getUsername()));
                cmd.Parameters.Add(new SqlParameter("@Password", userUpdate.getPassword()));
                cmd.Parameters.Add(new SqlParameter("@FullName", userUpdate.getFullName()));
                cmd.Parameters.Add(new SqlParameter("@CCCD", userUpdate.getCCCD()));
                cmd.Parameters.Add(new SqlParameter("@Address", userUpdate.getAddress()));
                cmd.Parameters.Add(new SqlParameter("@Phone", userUpdate.getPhone()));

                // execute store procedure
                numRecords = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                // disconnection to DB
                DB.disconnection();
            }

            if (numRecords > 0)
            {
                // delete old user
                this.users.Remove(this.getUserObj(userUpdate.getUsername()));

                // add user update into listUser
                this.users.Add(userUpdate);

                return true;
            }
            else return false;
        }
    }
}
