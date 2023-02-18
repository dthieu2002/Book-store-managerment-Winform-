using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DotNet_2022.Models
{
    public class Orders // One orders have many orders_detail
    {
        //=== Properties
        //private int ordersId; OLD
        private List<OrdersDetail> ordersDetailList = new List<OrdersDetail>();

        //=== Method
        public Orders()
        {
            
        }

        public void addOrdersDetail(Book book, int amount)
        {
            OrdersDetail? ordersDetail = this.bookIdExists(book.getBookId());
        
            if(ordersDetail != null)//Change amount
            {
                int oldAmount = ordersDetail.getAmount();
                ordersDetail.setAmount(amount+oldAmount);
            }
            else// Add new order detail
            {
                ordersDetail = new OrdersDetail(book, amount);
                this.ordersDetailList.Add(ordersDetail);
            }
        }

        public OrdersDetail? bookIdExists(int bookId)
        {
            foreach(OrdersDetail ordersDetail in this.ordersDetailList)
            {
                if (ordersDetail.getBookId() == bookId) return ordersDetail;
            }
            return null;
        }

        public void removeOrdersDetail(OrdersDetail ordersDetail)
        {
            this.ordersDetailList.Remove(ordersDetail);
        }

        public decimal getTotalPrice()
        {
            decimal sum = 0;
            foreach(OrdersDetail item in this.ordersDetailList)
            {
                sum += item.getBook().getBookPrice() * item.getAmount();
            }
            return sum;
        }

        public void resetOrders()
        {
            this.ordersDetailList.Clear();
        }

        public List<OrdersDetail> getOrdersDetailList() { return this.ordersDetailList; }
        
    }
}
