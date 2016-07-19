namespace MyBotApplicationDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Theatre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Theatre()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TheatreId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? LocationId { get; set; }

        public int? MovieId { get; set; }

        public int ScreenId { get; set; }

        public int? CategoryId { get; set; }

        public virtual Location Location { get; set; }

        public virtual MovieDetail MovieDetail { get; set; }

        public virtual TheatreCategory TheatreCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
