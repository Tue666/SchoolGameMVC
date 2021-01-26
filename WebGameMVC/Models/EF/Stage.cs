namespace WebGameMVC.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stage")]
    public partial class Stage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stage()
        {
            Histories = new HashSet<History>();
        }

        public long ID { get; set; }

        public int? Location_X { get; set; }

        public int? Location_Y { get; set; }

        public long? DungeonID { get; set; }

        public int? Exp { get; set; }

        public int? Type { get; set; }

        [StringLength(50)]
        public string AvatarMonster { get; set; }

        [StringLength(50)]
        public string NameStage { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        public double? Money { get; set; }

        public int? Stamina { get; set; }

        public long? Level { get; set; }

        public bool? Status { get; set; }

        public virtual Dungeon Dungeon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> Histories { get; set; }
    }
}
