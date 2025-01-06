using FurnitureCrud.DataAccess.Entity;
using System.Text.Json;

namespace FurnitureCrud.Repoistory;

public class FurnitureRepo : IFurnitureRepo
{
    private List<Furniture> furnitures;
    private string Path;
    public FurnitureRepo()
    {
        Path = "../../../DataAccess/Data/Furniture.json";
        furnitures = new List<Furniture>();
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }
        furnitures = GetAllFurnitures();

    }

    private void SaveInformation(List<Furniture> furniture)
    {
        var json = JsonSerializer.Serialize(furnitures);
        File.WriteAllText(Path, json);
    }
    private List<Furniture> GetAllFurnitures()
    {
        var json = File.ReadAllText(Path);
        var file = JsonSerializer.Deserialize<List<Furniture>>(json);
        return file;
    }
    public Furniture AddFurniture(Furniture added)
    {
        added.Id = Guid.NewGuid();
        furnitures.Add(added);
        SaveInformation(furnitures);
        return added;
    }

    public void DeleteFurniture(Guid id)
    {
        var guId = GetById(id);
        if (guId is null)
        {
            Console.WriteLine("Null");
        }
        furnitures.Remove(guId);
        SaveInformation(furnitures);
    }

    public List<Furniture> GetAllFurniture()
    {
        return GetAllFurnitures();
    }

    public Furniture GetById(Guid id)
    {
        foreach (var furniture in furnitures)
        {
            if (furniture.Id == id)
            {
                return furniture;
            }
        }
        return null;
    }

    public void UpdatedFurniture(Furniture obj)
    {
        var id = GetById(obj.Id);
        var index = furnitures.IndexOf(id);
        furnitures[index] = obj;
        SaveInformation(furnitures);
    }
}
