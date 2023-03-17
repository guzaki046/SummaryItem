using SummaryItem.Entities.Enums;
using System.Globalization;
using System.Text;

namespace SummaryItem.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime moment, OrderStatus orderStatus, Client client)
        {
            Moment = moment;
            OrderStatus = orderStatus;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItems.Remove(item);
        }

        public double Total()
        {
            double total = 0.0;
            foreach (OrderItem i in OrderItems)
            {
                total += i.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(OrderStatus.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString());
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items: ");
            foreach (OrderItem i in OrderItems)
            {
                sb.Append(i.Product.Name);
                sb.Append(", $");
                sb.Append(i.Product.Price);
                sb.Append(", Quantity: ");
                sb.Append(i.Quantity);
                sb.Append(", Subtotal: $");
                sb.AppendLine(i.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.Append("Total price: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
