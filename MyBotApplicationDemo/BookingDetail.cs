namespace MyBotApplicationDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookingDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingId { get; set; }

        public int? UserId { get; set; }

        public int? MovieId { get; set; }

        public int? SeatId { get; set; }

        public int? ShowId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScreenId { get; set; }

        public int? LanguageId { get; set; }

        public int? TheatreId { get; set; }

        public int? LocationId { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime BookingDate { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime BookedOn { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Price { get; set; }

        public virtual Language Language { get; set; }

        public virtual Location Location { get; set; }

        public virtual MovieDetail MovieDetail { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual Show Show { get; set; }

        public virtual Theatre Theatre { get; set; }

        public virtual User User { get; set; }
    }
}
