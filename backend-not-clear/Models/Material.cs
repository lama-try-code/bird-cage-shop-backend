﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Models
{
    public partial class Material
    {
        public Material()
        {
            Color = new HashSet<Color>();
            Image = new HashSet<Image>();
            MaterialProduct = new HashSet<MaterialProduct>();
            ProductCustom = new HashSet<ProductCustom>();
        }

        [Key]
        [Column("MaterialID")]
        [StringLength(10)]
        public string MaterialId { get; set; }
        [Required]
        [StringLength(50)]
        public string MaterialName { get; set; }
        [Column("SizeID")]
        [StringLength(10)]
        public string SizeId { get; set; }
        public bool IsCustom { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }

        [ForeignKey("SizeId")]
        [InverseProperty("Material")]
        public virtual Size Size { get; set; }
        [InverseProperty("Material")]
        public virtual ICollection<Color> Color { get; set; }
        [InverseProperty("Material")]
        public virtual ICollection<Image> Image { get; set; }
        [InverseProperty("Material")]
        public virtual ICollection<MaterialProduct> MaterialProduct { get; set; }
        [InverseProperty("ProductMaterialNavigation")]
        public virtual ICollection<ProductCustom> ProductCustom { get; set; }
    }
}