namespace Game_Shop.Model_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {     

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Game_Name { get; set; }

        public int Game_Studio_id { get; set; }

        public int Game_Style_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Game_Year_Releas { get; set; }

        public int Game_Mod_id { get; set; }

        public int Game_Count_Sell { get; set; }

        public virtual Mod_Game Mod_Game { get; set; }

        public virtual Studio Studio { get; set; }

        public virtual Style Style { get; set; }
    }
}
