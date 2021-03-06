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
    
    public partial class Ingredient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingredient()
        {
            this.ItemDishes = new HashSet<ItemDish>();
            this.Products = new HashSet<Product>();
        }
    
        public int IDIngredient { get; set; }
        public string NameIngredient { get; set; }
        public int IDTypeIngredient { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrate { get; set; }
        public Nullable<float> CalorificValue { get; set; }
    
        public virtual TypeIngredient TypeIngredient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemDish> ItemDishes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
