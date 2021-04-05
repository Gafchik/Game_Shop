using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Game_Shop.Model_EF
{
    public partial class Model_Game_Shop : DbContext
    {
        public Model_Game_Shop()
            : base("name=Model_Game_Shop")
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Mod_Game> Mod_Game { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<Style> Styles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mod_Game>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Mod_Game)
                .HasForeignKey(e => e.Game_Mod_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Studio>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Studio)
                .HasForeignKey(e => e.Game_Studio_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Style>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Style)
                .HasForeignKey(e => e.Game_Style_id)
                .WillCascadeOnDelete(false);
        }
    }
}
