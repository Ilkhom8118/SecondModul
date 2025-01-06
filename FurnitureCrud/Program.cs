using FurnitureCrud.Services;
using FurnitureCrud.Services.DTOs;

namespace FurnitureCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFurnitureSevices service = new FurnitureSevices();
            //var obj = new FurnitureCreateDto()
            //{
            //    Name = "salom",
            //    Color = "red"
            //};
            //service.AddFurniture(obj);

            var id = "9f02b036-f165-493c-a213-9acc324233b2";
            var delete = new FurnitureGetDto()
            {
                Id = Guid.Parse(id),
                Name = "qalesan"
            };
            //service.DeleteFurniture(Guid.Parse(id));


            service.UpdateFurniture(delete);
        }
    }
}
