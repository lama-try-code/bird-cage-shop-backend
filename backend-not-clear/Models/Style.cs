﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Models
{
    public partial class Style
    {
        public Style()
        {
            Image = new HashSet<Image>();
            ProductCustom = new HashSet<ProductCustom>();
            Size = new HashSet<Size>();
            StyleProduct = new HashSet<StyleProduct>();
        }

        [Key]
        [Column("StyleID")]
        [StringLength(10)]
        public string StyleId { get; set; }
        [Required]
        [StringLength(30)]
        public string StyleName { get; set; }
        [StringLength(200)]
        public string StyleDescription { get; set; }
        public bool Status { get; set; }
        public bool IsCustom { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }

        [InverseProperty("Style")]
        public virtual ICollection<Image> Image { get; set; }
        [InverseProperty("ProductStyleNavigation")]
        public virtual ICollection<ProductCustom> ProductCustom { get; set; }
        [InverseProperty("Style")]
        public virtual ICollection<Size> Size { get; set; }
        [InverseProperty("Style")]
        public virtual ICollection<StyleProduct> StyleProduct { get; set; }
    }
}