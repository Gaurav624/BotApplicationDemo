namespace MyBotApplicationDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Price
    {
        public int? LocationId { get; set; }

        public int? TheatreCategoryId { get; set; }

        public int? SeatCategoryId { get; set; }

        public int? MovieId { get; set; }

        [Key]
        public decimal Prices { get; set; }

        public virtual Location Location { get; set; }

        public virtual MovieDetail MovieDetail { get; set; }

        public virtual SeatsCategory SeatsCategory { get; set; }

        public virtual TheatreCategory TheatreCategory { get; set; }
    }
}
