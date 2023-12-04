﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Models
{
    public partial class Bird
    {
        public Bird()
        {
            BirdProduct = new HashSet<BirdProduct>();
            Image = new HashSet<Image>();
        }

        [Key]
        [Column("BirdID")]
        [StringLength(10)]
        public string BirdId { get; set; }
        [Required]
        [StringLength(10)]
        public string BirdSize { get; set; }
        [Required]
        [StringLength(10)]
        public string BirdType { get; set; }
        [Required]
        [StringLength(50)]
        public string BirdName { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool Status { get; set; }

        [ForeignKey("BirdSize")]
        [InverseProperty("Bird")]
        public virtual Size BirdSizeNavigation { get; set; }
        [ForeignKey("BirdType")]
        [InverseProperty("Bird")]
        public virtual BirdType BirdTypeNavigation { get; set; }
        [InverseProperty("Bird")]
        public virtual ICollection<BirdProduct> BirdProduct { get; set; }
        [InverseProperty("Bird")]
        public virtual ICollection<Image> Image { get; set; }
    }
}