namespace WebGameMVC.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pet")]
    public partial class Pet
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public long? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
