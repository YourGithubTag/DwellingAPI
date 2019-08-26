using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellingAPI.Model
{
    public partial class Items
    {
        [Column("ItemID")]
        public int ItemId { get; set; }
        public string Room { get; set; }
        [StringLength(100)]
        public string ItemName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Category { get; set; }
        public string Wear { get; set; }
        public int? ItemPriority { get; set; }
        [StringLength(7)]
        public string Starred { get; set; }
    }
}
