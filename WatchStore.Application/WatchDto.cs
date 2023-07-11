using System.Collections.Generic;

namespace WatchStore.Application.DTOs
{
    public class WatchDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Features { get; set; }
    }
}