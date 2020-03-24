using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbItems
    {
        public int Id { get; set; }
        public string VendorCode {get; set; }
        //в наличии
        public bool inStock { get; set; }
        public int CategoryId { get; set; }
        public string CategoryNameUa { get; set; }
        public string CategoryNameRu { get; set; }
        public string CategoryNameEn { get; set; }
        public string SubCategoryNameUa { get; set; }
        public string SubCategoryNameRu { get; set; }
        public string SubCategoryNameEn { get; set; }
        public string NameUa { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        //public string Brand { get; set; }
        //акция
        public bool IsStock { get; set; }
        public double StockPriceUa { get; set; }
        public double StockPriceEn { get; set; }
        public double PriceUa { get; set; }
        public double PriceEn { get; set; }
        public string PriceUndefined { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string CoveringUa { get; set; }
        public string CoveringRu { get; set; }
        public string CoveringEn { get; set; }
        public string SpecificationUa { get; set; }
        public string SpecificationRu { get; set; }
        public string SpecificationEn { get; set; }
        //нить
        public string ThreadUa { get; set; }
        public string ThreadRu { get; set; }
        public string ThreadEn { get; set; }
        public string TotalWeight { get; set; }
        public double Width { get; set; }
        //обмотка
        public string Winding { get; set; }
        //прочность
        public string Strength { get; set; }
        //прочность на розрыв
        public string BreakingStrength { get; set; }
        //прочность при адгезии
        public string AdhesionStrength { get; set; }
        public string Temperature { get; set; }
        public string ManufacturerUa { get; set; }
        public string ManufacturerRu { get; set; }
        public string ManufacturerEn { get; set; }
        public string CountryOfOriginUa { get; set; }
        public string CountryOfOriginRu { get; set; }
        public string CountryOfOriginEn { get; set; }
        public string SeasonUa { get; set; }
        public string SeasonRu { get; set; }
        public string SeasonEn { get; set; }
        public string MaterialUa { get; set; }
        public string MaterialRu { get; set; }
        public string MaterialEn { get; set; }
        public string DensityUa { get; set; }
        public string DensityRu { get; set; }
        public string DensityEn { get; set; }
        public string SizeUa { get; set; }
        public string SizeRu { get; set; }
        public string SizeEn { get; set; }
        //гарантийный срок
        public string WarrantyPeriod { get; set; }
        //public string WarrantyPeriodRu { get; set; }
        //public string WarrantyPeriodEn { get; set; }
        //Время изготовления
        public string PreparationTime { get; set; }
        //public string PreparationTimeRu { get; set; }
        //public string PreparationTimeEn { get; set; }
        //тип запчасти
        public string SparesTypeUa { get; set; }
        public string SparesTypeRu { get; set; }
        public string SparesTypeEn { get; set; }
        public string TextileProductTypeUa { get; set; }
        public string TextileProductTypeRu { get; set; }
        public string TextileProductTypeEn { get; set; }
        public string ColorUa { get; set; }
        public string ColorRu { get; set; }
        public string ColorEn { get; set; }
        public string Description { get; set; }
        public string ItemStatus { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionUa { get; set; }
        public string DescriptionEn { get; set; }
        public bool IndividualOrders { get; set; }
        //поштучно или метры
        public bool ProductBuyTypeMeter { get; set; }
        //кол-во выполненных заказов
        public int OrderCount { get; set; }
    }
}