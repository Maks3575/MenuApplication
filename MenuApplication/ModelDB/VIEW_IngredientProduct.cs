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
    using System.Collections.Generic;
    
    public partial class VIEW_IngredientProduct
    {
        public int IDIngredient { get; set; }
        public string NameIngredient { get; set; }
        public string NameTypeIngredient { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrate { get; set; }
        public Nullable<float> CalorificValue { get; set; }
        public int IDProduct { get; set; }
        public decimal Price { get; set; }
        public float Mass { get; set; }
        public Nullable<float> PriceFor1Kg { get; set; }
        public System.DateTime BeginDate { get; set; }
        public int IDSubdivision { get; set; }
    }
}