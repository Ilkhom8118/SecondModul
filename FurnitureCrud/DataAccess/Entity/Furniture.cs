namespace FurnitureCrud.DataAccess.Entity;

public class Furniture
{
    public Guid Id { get; set; }
    // Furniture nomi (masalan, "Stol", "Kreslo")
    public string Name { get; set; }

    // Materiali (masalan, "Yog'och", "Metall")
    public string Material { get; set; }

    // Rang (masalan, "Oq", "Qora")
    public string Color { get; set; }

    // O'lchami (Kenglik x Uzunlik x Balandlik)
    public string Dimensions { get; set; }

    // Narxi
    public decimal Price { get; set; }

    // Brend nomi (agar mavjud bo'lsa)
    public string Brand { get; set; }

    // Mebelning vazni (kg)
    public double Weight { get; set; }

    // Stokda mavjudmi yoki yo'qmi
    public bool IsAvailable { get; set; }

    // Ishlab chiqarilgan yili
    public int YearManufactured { get; set; }

    // Qisqacha ta'rifi
    public string Description { get; set; }

}
