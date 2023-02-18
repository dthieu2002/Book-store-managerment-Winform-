using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DotNet_2022.Models
{
    public class User
    {
        private string Username = string.Empty;
        private string Password = string.Empty;
        private string FullName = string.Empty;
        private string CCCD = string.Empty;
        private string Address = string.Empty;
        private string Phone = string.Empty;
        private string Role = string.Empty;

        public User()
        {

        }
        public User(string username, string password, string fullName, string cCCD, string address, string phone, string role)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            CCCD = cCCD;
            Address = address;
            Phone = phone;
            Role = role;
        }

        public string getUsername() { return this.Username; }  
        public string getPassword() { return this.Password; }
        public string getFullName() { return this.FullName; }
        public string getCCCD() { return this.CCCD; }
        public string getAddress() { return this.Address; }
        public string getPhone() { return this.Phone; }
        public string getRole() { return this.Role; }

        public void setUsername(string Username)
        {
            this.Username = Username;
        }
        public void setPassword(string Password)
        {
            this.Password = Password;
        }
        public void setFullName(string FullName)
        {
            this.FullName = FullName;
        }
        public void setCCCD(string CCCD)
        {
            this.CCCD = CCCD;
        }
        public void setAddress(string Address)
        {
            this.Address = Address;
        }
        public void setPhone(string Phone)
        {
            this.Phone = Phone;
        }

    }
}
