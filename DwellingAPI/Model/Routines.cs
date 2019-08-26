using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellingAPI.Model
{
    public partial class Routines
    {
        [Column("RoutineID")]
        public int RoutineId { get; set; }
        [Column("TODO")]
        [StringLength(200)]
        public string Todo { get; set; }
        public int? Tag { get; set; }
        public int? Category { get; set; }
        public int? RoutinePriority { get; set; }
        [StringLength(7)]
        public string Starred { get; set; }
    }
}
