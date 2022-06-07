using System.ComponentModel.DataAnnotations.Schema;

namespace DiamondsAPI.Models
{
    public class Diamond
    {
        public long Id { get; set; }
        public string Shape { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Size { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ListPrice { get; set; }

        public Diamond(string shape, decimal size, string color, string clarity, decimal price, decimal listPrice)
        {
            Shape = shape;
            Size = size;
            Color = color;
            Clarity = clarity;
            Price = price;
            ListPrice = listPrice;
        }
        public Diamond()
        {

        }

    }
}
