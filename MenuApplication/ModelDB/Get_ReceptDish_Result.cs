//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MenuApplication.ModelDB
{
    using System;
    
    public partial class Get_ReceptDish_Result
    {
        public string NameOrganization { get; set; }
        public string NameSubdivision { get; set; }
        public int IDDish { get; set; }
        public string NameDish { get; set; }
        public string ExpandedNameDish { get; set; }
        public string NumberInCollectionOfRecipes { get; set; }
        public string WeightDish { get; set; }
        public int IDTypeDish { get; set; }
        public int IDIngredient { get; set; }
        public string NameIngredient { get; set; }
        public string NameTypeIngredient { get; set; }
        public Nullable<float> ProteinIn100Portion { get; set; }
        public Nullable<float> FatIn100Portion { get; set; }
        public Nullable<float> CarbohydrateIn100Portion { get; set; }
        public Nullable<float> CalorificValueIn100Portion { get; set; }
        public int IDProduct { get; set; }
        public float NormOn100Portion { get; set; }
        public Nullable<decimal> PriceFor1Kg { get; set; }
        public Nullable<float> SummForIngredient { get; set; }
        public System.DateTime BeginDate { get; set; }
    }
}