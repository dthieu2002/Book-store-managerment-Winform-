using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DotNet_2022.Models
{
    public class Book
    {
        //=== Properties 
        private int BookId;
        private string BookName = string.Empty;
        private string BookGenre = string.Empty;
        private string BookAuthor = string.Empty ;
        private decimal BookPrice;
        private DateTime ReleaseDate;
        private string BookImage = string.Empty;
        private int InventoryQuantity;

        private int AmountSold; // Only in case ( get top 3 book seller )

        //=== Method
        public Book()
        {

        }
        public Book(int BookId, string BookName, string BookGenre, string BookAuthor, decimal BookPrice, DateTime ReleaseDate, string BookImage, int InventoryQuantity)
        {
            this.BookId = BookId;
            this.BookName = BookName;
            this.BookGenre = BookGenre;
            this.BookAuthor = BookAuthor;
            this.BookPrice = BookPrice;
            this.ReleaseDate = ReleaseDate;
            this.BookImage = BookImage;
            this.InventoryQuantity = InventoryQuantity;
        }

        public int getBookId() { return this.BookId; }
        public void setBookId(int BookId) { this.BookId = BookId; }

        public string getBookName() { return this.BookName; }
        public void setBookName(string BookName) { this.BookName = BookName; }

        public string getBookGenre() { return this.BookGenre; }
        public void setBookGenre(string BookGenre) { this.BookGenre = BookGenre; }

        public string getBookAuthor() { return this.BookAuthor; }
        public void setBookAuthor(string BookAuthor) { this.BookAuthor = BookAuthor; }

        public decimal getBookPrice() { return this.BookPrice; }
        public void setBookPrice(decimal BookPrice) { this.BookPrice = BookPrice; } 

        public DateTime getReleaseDate() { return this.ReleaseDate; }
        public void setReleaseDate(DateTime ReleaseDate) { this.ReleaseDate = ReleaseDate; } 
        
        public string getBookImage() { return this.BookImage; }
        public void setBookImage(string BookImage) { this.BookImage = BookImage; }  

        public int getInventoryQuantity() { return this.InventoryQuantity; }
        public void setInventoryQuantity(int InventoryQuantity) { this.InventoryQuantity = InventoryQuantity; } 

        public int getAmountSold() { return this.AmountSold; }
        public void setAmountSold(int AmountSold) { this.AmountSold = AmountSold; } 
    }
}
