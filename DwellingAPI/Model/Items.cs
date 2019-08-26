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
        public int? Room { get; set; }
        [StringLength(100)]
        public string ItemName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int? Tag { get; set; }
        public int? Category { get; set; }
        public int? Wear { get; set; }
        public int? ItemPriority { get; set; }
        [StringLength(7)]
        public string Starred { get; set; }
    }
}
