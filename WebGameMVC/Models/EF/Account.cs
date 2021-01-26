namespace WebGameMVC.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Collections = new HashSet<Collection>();
            Histories = new HashSet<History>();
        }

        public long ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string PassWord { get; set; }

        public int? Sex { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }

        [StringLength(50)]
        public string Wings { get; set; }

        public int? Type { get; set; }

        [StringLength(50)]
        public string SchoolName { get; set; }

        public int? Grade { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        public int? Level { get; set; }

        public int? Exp { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int? Stamina { get; set; }

        public int? Rank { get; set; }

        public DateTime? CreateDay { get; set; }

        public double? Money { get; set; }

        public bool? Status { get; set; }

        public int? RankExp { get; set; }

        public int? TotalBattle { get; set; }

        public int? WinBattle { get; set; }

        public virtual Ranking Ranking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection> Collections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> Histories { get; set; }
    }
}
