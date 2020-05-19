using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;

namespace TechnoTent.Models.ViewModel
{
    public class ItemsVM
    {
        public int Id { get; set; }
        public string VendorCode { get; set; }
        //[Required]
        //в наличии
        public bool inStock { get; set; }
        //[Required]
        public int CategoryId { get; set; }
        public string CategoryUrl { get; set; }
        public string CategoryName { get; set; }
        //[Required]
        public string CategoryNameUa { get; set; }
        //[Required]
        public string CategoryNameRu { get; set; }
        //[Required]
        public string CategoryNameEn { get; set; }
        public string SubCategoryUrl { get; set; }
        public string SubCategoryName { get; set; }
        //[Required]
        public string SubCategoryNameUa { get; set; }
        //[Required]
        public string SubCategoryNameRu { get; set; }
        //[Required]
        public string SubCategoryNameEn { get; set; }
        public string NameUrl { get; set; }
        public string Name { get; set; }
        //[Required]
        public string NameUa { get; set; }
        //[Required]
        public string NameRu { get; set; }
        //[Required]
        public string NameEn { get; set; }
        public string Price { get; set; }
        double priceUa;
        [Required]
        public double PriceUa
        {
            get
            {
                return priceUa;
            }
            set
            {
                if (value < 0)
                    priceUa = 0;
                else
                    priceUa = value;
            }
        }
        [Required]
        double priceEn;
        [Required]
        public double PriceEn
        {
            get
            {
                return priceEn;
            }
            set
            {
                if (value < 0)
                    priceEn = 0;
                else
                    priceEn = value;
            }
        }
        
        public bool PriceUndefined { get; set; }
        //акция
        public bool IsStock { get; set; }
        public double StockPrice { get; set; }
        //public string Brand { get; set; }
        public HttpPostedFileBase[] Images { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Covering { get; set; }
        //[Required]
        public string CoveringUa { get; set; }
        //[Required]
        public string CoveringRu { get; set; }
        //[Required]
        public string CoveringEn { get; set; }
        public string Specification { get; set; }
        //[Required]
        //public string SpecificationUa { get; set; }
        ////[Required]
        //public string SpecificationRu { get; set; }
        ////[Required]
        //public string SpecificationEn { get; set; }
        public string Thread { get; set; }
        //[Required]
        //public string ThreadUa { get; set; }
        ////[Required]
        //public string ThreadRu { get; set; }
        ////[Required]
        //public string ThreadEn { get; set; }
        //[Required]
        public string TotalWeight { get; set; }
        //[Required]
        public double Width { get; set; }
        //[Required]
        public string Winding { get; set; }
        //[Required]
        public string Strength { get; set; }
        //[Required]
        public string BreakingStrength { get; set; }
        public string AdhesionStrength { get; set; }
        //[Required]
        //public string AdhesionStrengthUa { get; set; }
        ////[Required]
        //public string AdhesionStrengthRu { get; set; }
        ////[Required]
        //public string AdhesionStrengthEn { get; set; }
        //[Required]
        public string Temperature { get; set; }
        public string Color { get; set; }
        //[Required]
        //public string ColorUa { get; set; }
        ////[Required]
        //public string ColorRu { get; set; }
        //[Required]
        //public string ColorEn { get; set; }
        public string Manufacturer { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Season { get; set; }
        public string Material { get; set; }
        public string Density { get; set; }
        public string Size { get; set; }
        public string WarrantyPeriod { get; set; }
        public string PreparationTime { get; set; }
        public string SparesType { get; set; }
        public string TextileProductType { get; set; }
        public string Description { get; set; }
        public string DescriptionItem { get; set; }
        public string ItemStatus { get; set; }
        public bool ProductBuyTypeMeter { get; set; }
        public bool IndividualOrder { get; set; }
        //public IEnumerable<PVCAwingsVM> PVCAwings { get; set; }
        public List<string> Brands { get; set; }
        public List<string> Colors { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public List<string> BrandsForFilters { get; set; }
        public string FilterBrand { get; set; }
        public List<ItemsVM> SimilarItems { get; set; }
        //Кол-во отфильтрованных товаров
        public int ItemsCount { get; set; }
    }
}