namespace WebGameMVC.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        public long ID { get; set; }

        public long? SubID { get; set; }

        public long? GradeID { get; set; }

        [Column("Question")]
        [StringLength(500)]
        public string Question1 { get; set; }

        [StringLength(100)]
        public string Answer_A { get; set; }

        [StringLength(100)]
        public string Answer_B { get; set; }

        [StringLength(100)]
        public string Answer_C { get; set; }

        [StringLength(100)]
        public string Answer_D { get; set; }

        [StringLength(50)]
        public string Right_Answer { get; set; }

        public long? Level { get; set; }

        public bool? Status { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
