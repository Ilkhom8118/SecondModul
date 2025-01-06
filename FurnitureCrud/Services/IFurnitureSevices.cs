using FurnitureCrud.DataAccess.Entity;
using FurnitureCrud.Services.DTOs;

namespace FurnitureCrud.Services;

public interface IFurnitureSevices
{
    Furniture AddFurniture(FurnitureCreateDto added);
    void DeleteFurniture(Guid id);
    void UpdateFurniture(FurnitureGetDto obj);
    List<FurnitureCreateDto> GetAllFurniture(Furniture obj);

}