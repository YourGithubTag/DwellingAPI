using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellingAPI.Model
{
    public partial class Rooms
    {
        public Rooms()
        {
            Items = new HashSet<Items>();
        }

        [Column("RoomID")]
        public int RoomId { get; set; }
        [StringLength(1)]
        public string RoomState { get; set; }
        public int? RoomPriority { get; set; }
        [StringLength(100)]
        public string RoomName { get; set; }

        [InverseProperty("RoomNavigation")]
        public virtual ICollection<Items> Items { get; set; }
    }
}
