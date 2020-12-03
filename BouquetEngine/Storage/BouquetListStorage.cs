using System;
using System.Collections.Generic;
using BouquetEngine.Model;
namespace BouquetEngine.Storage
{
    public class BouquetListStorage : IBouquetStorage
    {
        private readonly List<Bouquet> _bouquetList;
        public BouquetListStorage()
        {
            _bouquetList = new List<Bouquet>();
            _bouquetList.Add(new Bouquet(Guid.NewGuid(), "Luxury", 75.00, "Luxury",
                                         "https://cdn11.bigcommerce.com/s-a4z7rskb8w/images/stencil/original/products/379/760/romance-24-rose-bouquet-burnaby-florist-AR2035__21642.1583956443.jpg"));
            _bouquetList.Add(new Bouquet(Guid.NewGuid(), "Romantic", 65.00, "Romantic",
                                         "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRkN5eoLavL3yDv45JsKULCoLKLJy_GJ8dbVQ&usqp=CAU"));
            _bouquetList.Add(new Bouquet(Guid.NewGuid(), "Peony Bouquet", 39.99, "Peony Bouquet",
                                          "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRKPYTk8xyP94dllDuP66vZjt6NMMzgm7zUDxCyuYduOl-pLE2Jml2eDJFnScM_4GzzWMMJb2Cl&usqp=CAc"));
            _bouquetList.Add(new Bouquet(Guid.NewGuid(), "Colorful", 45.00, "Colorful",
                                           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnUs3JfKkfBkOtfARvPce_a3jr9m61x1nvR-hBii8sW1lHHoOXtAMz97QFLNS2WFyUVs5Tnuw&usqp=CAc"));
            _bouquetList.Add(new Bouquet(Guid.NewGuid(), "Large mixed sunflower rose bouquet.", 85.00, "Large mixed sunflower rose bouquet.",
                                           "https://flower-delivery-bangkok.com/wp-content/uploads/2019/05/flower-delivery-bangkok-401.jpg"));
            _bouquetList.Add(new Bouquet(Guid.NewGuid(), "Red rose bouquet", 55.00, "Red rose bouquet",
                                           "https://flower-delivery-bangkok.com/wp-content/uploads/2019/04/flower-delivery-bangkok-406-500x583.jpg"));
            _bouquetList.Add(new Bouquet(Guid.NewGuid(), "White roses", 95.00, "White roses",
                                            "https://flower-delivery-bangkok.com/wp-content/uploads/2019/04/bangkok-flower-delivery-33-500x583.jpg"));
        }


        public List<Bouquet> GetAll()
        {
            return _bouquetList;

        }
    }
}