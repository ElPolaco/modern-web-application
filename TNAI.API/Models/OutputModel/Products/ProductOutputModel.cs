using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNAI.API.Models.OutputModel.Products
{
    public class ProductOutputModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nazwa
        /// </summary>
            public string Name { get; set; }
        /// <summary>
        /// cena
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// id kategorii
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// nazwa kategorii
        /// </summary>
        public string CategoryName { get; set; }  
    }
}