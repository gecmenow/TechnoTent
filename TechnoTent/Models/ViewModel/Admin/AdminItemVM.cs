using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel.Admin
{
    public class AdminItemVM
    {
        public int Id { get; set; }
        public string VendorCode { get; set; }
        public bool inStock { get; set; }
        //[Required]
        public string CategoryNameUa { get; set; }
        //[Required]
        public string CategoryNameRu { get; set; }
        //[Required]
        public string CategoryNameEn { get; set; }
        public List<string> CategoriesList { get; set; } 
        //[Required]
        public string SubCategoryNameUa { get; set; }
        //[Required]
        public string SubCategoryNameRu { get; set; }
        //[Required]
        public string SubCategoryNameEn { get; set; }
        public List<string> SubCategoriesList { get; set; }
        //[Required]
        public string NameUa { get; set; }
        //[Required]
        public string NameRu { get; set; }
        //[Required]
        public string NameEn { get; set; }
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
        public string PriceUndefined { get; set; }
        //акция
        public bool IsStock { get; set; }
        public double StockPriceUa { get; set; }
        public double StockPriceEn { get; set; }
        //public string Brand { get; set; }
        public HttpPostedFileBase[] Images { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        //[Required]
        public string CoveringUa { get; set; }
        //[Required]
        public string CoveringRu { get; set; }
        //[Required]
        public string CoveringEn { get; set; }
        //[Required]
        public string SpecificationUa { get; set; }
        //[Required]
        public string SpecificationRu { get; set; }
        //[Required]
        public string SpecificationEn { get; set; }
        //[Required]
        public string ThreadUa { get; set; }
        //[Required]
        public string ThreadRu { get; set; }
        //[Required]
        public string ThreadEn { get; set; }
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
        //[Required]
        public string AdhesionStrength { get; set; }
        //[Required]
        public string Temperature { get; set; }
        //[Required]
        public string ColorUa { get; set; }
        //[Required]
        public string ColorRu { get; set; }
        //[Required]
        public string ColorEn { get; set; }
        public string ManufacturerRu { get; set; }
        public string ManufacturerUa { get; set; }
        public string ManufacturerEn { get; set; }
        public string CountryOfOriginRu { get; set; }
        public string CountryOfOriginUa { get; set; }
        public string CountryOfOriginEn { get; set; }
        public string SeasonRu { get; set; }
        public string SeasonUa { get; set; }
        public string SeasonEn { get; set; }
        public string MaterialRu { get; set; }
        public string MaterialUa { get; set; }
        public string MaterialEn { get; set; }
        public string DensityUa { get; set; }
        public string DensityRu { get; set; }
        public string DensityEn { get; set; }
        public string SizeUa { get; set; }
        public string SizeRu { get; set; }
        public string SizeEn { get; set; }
        public string WarrantyPeriod { get; set; }
        public string PreparationTime { get; set; }
        //тип запчасти
        public string SparesTypeUa { get; set; }
        public string SparesTypeRu { get; set; }
        public string SparesTypeEn { get; set; }
        public string SpecificationeUa { get; set; }
        public string SpecificationeRu { get; set; }
        public string SpecificationeEn { get; set; }
        public string TextileProductTypeRu { get; set; }
        public string TextileProductTypeUa { get; set; }
        public string TextileProductTypeEn { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionUa { get; set; }
        public string DescriptionEn { get; set; }
        public string ItemStatus { get; set; }
        public bool ProductBuyTypeMeter { get; set; }
    }
}