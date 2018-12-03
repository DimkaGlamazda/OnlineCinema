namespace OnlineCinema.DB.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int MovieId { get; set; }

        public int SessionId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Session Session { get; set; }
    }
}
