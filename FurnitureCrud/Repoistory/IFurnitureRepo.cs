using FurnitureCrud.DataAccess.Entity;

namespace FurnitureCrud.Repoistory;

public interface IFurnitureRepo
{
    Furniture AddFurniture(Furniture added);
    Furniture GetById(Guid id);
    void DeleteFurniture(Guid id);
    void UpdatedFurniture(Furniture obj);
    List<Furniture> GetAllFurniture();
}