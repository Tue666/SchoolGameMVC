namespace WebGameMVC.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Collection")]
    public partial class Collection
    {
        public long ID { get; set; }

        public long? UserID { get; set; }

        public long? CategoryID { get; set; }

        public long? ThingID { get; set; }

        [StringLength(50)]
        public string ImageThing { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDay { get; set; }

        public virtual Account Account { get; set; }

        public virtual Category Category { get; set; }
    }
}
