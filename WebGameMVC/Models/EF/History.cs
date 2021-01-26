namespace WebGameMVC.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        public long ID { get; set; }

        public long? UserID { get; set; }

        public long? StageID { get; set; }

        public long? DungeonID { get; set; }

        public int? Flag { get; set; }

        public long? Exp { get; set; }

        [StringLength(50)]
        public string AvatarMonster { get; set; }

        public virtual Account Account { get; set; }

        public virtual Dungeon Dungeon { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
