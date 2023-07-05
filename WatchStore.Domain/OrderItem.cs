using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain
{
    public class OrderItem
    {
        // Identyfikator elementu zamówienia
        public int Id { get; set; }

        // Identyfikator zamówienia, do którego należy ten element
        public int OrderId { get; set; }

        // Zamówienie, do którego należy ten element
        public Order Order { get; set; }

        // Identyfikator zegarka, który jest częścią tego elementu zamówienia
        public int WatchId { get; set; }

        // Zegarek, który jest częścią tego elementu zamówienia
        public Watch Watch { get; set; }

        // Ilość zegarków w tym elemencie zamówienia
        public int Quantity { get; set; }

        // Cena jednostkowa zegarka w momencie złożenia zamówienia
        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal Tax { get; set; }

        // Metoda obliczająca całkowitą wartość elementu zamówienia
        public decimal GetTotal()
        {
            return UnitPrice * Quantity;
        }
    }
}
