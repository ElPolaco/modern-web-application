using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNAI.API.Models.InputModels.Products
{
    public class ProductInputModel
    {
        /// <summary>
        /// Nazwa
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Cena
        /// </summary>
        [Range(0,Int32.MaxValue)]
        public int Price { get; set; }
        /// <summary>
        /// id kategorii
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
    }
}