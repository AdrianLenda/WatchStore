using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain
{
    public class Order
    {
        // Identyfikator zamówienia
        public int Id { get; set; }

        // Identyfikator użytkownika, który złożył zamówienie
        public int UserId { get; set; }

        // Użytkownik, który złożył zamówienie
        public User User { get; set; }

        // Data i czas złożenia zamówienia
        public DateTime OrderDate { get; set; }

        // Status zamówienia (np. "Pending", "Shipped", "Delivered")
        public string Status { get; set; }

        // Adres dostawy
        public string DeliveryAddress { get; set; }

        public string TrackingNumber { get; set; }

        // Kolekcja elementów zamówienia
        public ICollection<OrderItem> OrderItems { get; set; }

        // Metoda obliczająca całkowitą wartość zamówienia
        public decimal GetTotal()
        {
            return OrderItems.Sum(item => item.Watch.Price * item.Quantity);
        }
    }
}
