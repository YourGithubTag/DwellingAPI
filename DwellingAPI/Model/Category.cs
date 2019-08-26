using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellingAPI.Model
{
    public partial class Category
    {

        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Column("Category")]
        [StringLength(1)]
        public string Category1 { get; set; }
    }
}
