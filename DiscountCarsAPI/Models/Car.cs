namespace DiscountCarsAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Year { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public string VinNumber { get; set; } = string.Empty;
        
    }
}
