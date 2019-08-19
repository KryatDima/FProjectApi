using FProject.Contracts;
using FProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Mapping
{
    public class BasketToViewModel
    {
        //public static BasketViewModel Convert(BasketDTO basket)
        //{
        //    if (basket == null) throw new ArgumentNullException(nameof(basket));

        //    return new BasketViewModel
        //    {
        //        Id=basket.Id,
        //        items=b
        //    };
        //}

        //public static List<ProductViewModel> Convert(IEnumerable<ProductDTO> products)
        //{
        //    if (products == null) throw new ArgumentNullException(nameof(products));

        //    var model = products.Select(p => Convert(p)).ToList();
        //    return model;
        //}

        public static BasketItemViewModel Convert(BasketItemsDTO items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return new BasketItemViewModel
            {
                Id = items.Id,
                BasketId=items.BasketId,
                ProductId=items.ProductId,
                Quantity=items.Quantity
            };
        }

        public static List<BasketItemViewModel> Convert(IEnumerable<BasketItemsDTO> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var model = items.Select(p => Convert(p)).ToList();
            return model;
        }
    }
}
