namespace FurnitureCrud.Services.DTOs;

public class FurnitureCreateDto
{
    public string Name { get; set; }

    public string Material { get; set; }

    public string Color { get; set; }

    public string Dimensions { get; set; }

    public decimal Price { get; set; }

    public string Brand { get; set; }

    public double Weight { get; set; }

    public bool IsAvailable { get; set; }

    public int YearManufactured { get; set; }

    public string Description { get; set; }
}
