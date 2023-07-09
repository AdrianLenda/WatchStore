namespace WatchStore.Domain
{
    public class Watch
    {
        // Identyfikator zegarka
        public int Id { get; set; }

        // Marka zegarka
        public string Brand { get; set; }

        // Model zegarka
        public string Model { get; set; }

        // Cena zegarka
        public decimal Price { get; set; }

        // Opis zegarka
        public string Description { get; set; }

        // URL do obrazka zegarka
        public string ImageUrl { get; set; }

        // Czy zegarek jest dostępny w magazynie
        public bool InStock { get; set; }

        // Kategoria zegarka
        public string Category { get; set; }

        public string Manufacturer { get; set; }
        public string ReleaseDate { get; set; }
        public decimal DiscountPrice { get; set; }
        // Kolekcja zamówień, które zawierają ten zegarek
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}