using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DotNet_2022.Models
{
    public class OrdersDetail
    {
        // Properties
        private Book book;
        private int amount;

        // Method
        public OrdersDetail(Book book, int amount)
        {
            this.book = book;
            this.amount = amount;
        }

        public int getBookId() { return this.book.getBookId(); }
        public Book getBook() { return this.book; }
        public int getAmount()
        {
            return this.amount;
        }
        public void setAmount(int amount)
        {
            this.amount = amount;
        }
    }
}
