using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellingAPI.Model
{
    public partial class Tags
    {
        public Tags()
        {
            Items = new HashSet<Items>();
        }

        [Column("TagID")]
        public int TagId { get; set; }
        [StringLength(1)]
        public string Tag { get; set; }

        [InverseProperty("TagNavigation")]
        public virtual ICollection<Items> Items { get; set; }
    }
}
