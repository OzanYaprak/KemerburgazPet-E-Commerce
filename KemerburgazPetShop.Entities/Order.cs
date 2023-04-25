using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Entities
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }

        //PAYMENT
        public string PaymentID { get; set; }
        public string PaymentToken { get; set; }
        public string ConversationID { get; set; }


        public List<OrderItem> OrderItems { get; set; }


        public EnumOrderState OrderState { get; set; }
        public EnumPaymentTypes PaymentTypes { get; set; }

    }

    public enum EnumOrderState
    {
        waiting = 0,
        Unpaid = 1,
        Completed = 2
    }

    public enum EnumPaymentTypes
    {
        CreditCart = 0,
        Eft = 1
    }
}
