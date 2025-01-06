using FurnitureCrud.DataAccess.Entity;
using FurnitureCrud.Repoistory;
using FurnitureCrud.Services.DTOs;

namespace FurnitureCrud.Services;

public class FurnitureSevices : IFurnitureSevices
{

    private readonly IFurnitureRepo _furnitures;
    public FurnitureSevices()
    {
        _furnitures = new FurnitureRepo();
    }
    private Furniture ConvertToEntity(FurnitureCreateDto obj)
    {
        return new Furniture()
        {
            Name = obj.Name,
            Brand = obj.Brand,
            Color = obj.Color,
            Price = obj.Price,
            Weight = obj.Weight,
            Material = obj.Material,
            Dimensions = obj.Description,
            IsAvailable = obj.IsAvailable,
            Description = obj.Description,
            YearManufactured = obj.YearManufactured,
        };
    }
    private FurnitureGetDto ConvertToEntity(Furniture obj)
    {
        return new FurnitureGetDto()
        {
            Id = obj.Id,
            Name = obj.Name,
            Brand = obj.Brand,
            Color = obj.Color,
            Price = obj.Price,
            Weight = obj.Weight,
            Material = obj.Material,
            Dimensions = obj.Description,
            IsAvailable = obj.IsAvailable,
            Description = obj.Description,
            YearManufactured = obj.YearManufactured,
        };
    }
    private Furniture ConvertToEntity(FurnitureGetDto obj)
    {
        return new Furniture()
        {
            Id = obj.Id,
            Name = obj.Name,
            Brand = obj.Brand,
            Color = obj.Color,
            Price = obj.Price,
            Weight = obj.Weight,
            Material = obj.Material,
            Dimensions = obj.Description,
            IsAvailable = obj.IsAvailable,
            Description = obj.Description,
            YearManufactured = obj.YearManufactured,
        };
    }
    public Furniture AddFurniture(FurnitureCreateDto added)
    {
        var add = ConvertToEntity(added);
        _furnitures.AddFurniture(add);
        return add;
    }

    public void DeleteFurniture(Guid id)
    {
        _furnitures.DeleteFurniture(id);
    }

    public List<FurnitureCreateDto> GetAllFurniture(Furniture obj)
    {
        var list = new List<FurnitureCreateDto>();
        foreach (var furniture in _furnitures.GetAllFurniture())
        {
            list.Add(ConvertToEntity(obj));
        }
        return list;
    }
    public void UpdateFurniture(FurnitureGetDto obj)
    {
        var entity = ConvertToEntity(obj);
        _furnitures.UpdatedFurniture(entity);
    }
    public void ValidateFurnitureCreate()
    {

    }

}
