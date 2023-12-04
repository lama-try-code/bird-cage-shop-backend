﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Models
{
    public partial class MaterialProduct
    {
        [Key]
        [Column("MaterialID")]
        [StringLength(10)]
        public string MaterialId { get; set; }
        [Key]
        [Column("ProductID")]
        [StringLength(10)]
        public string ProductId { get; set; }
        public bool Status { get; set; }

        [ForeignKey("MaterialId")]
        [InverseProperty("MaterialProduct")]
        public virtual Material Material { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("MaterialProduct")]
        public virtual Product Product { get; set; }
    }
}