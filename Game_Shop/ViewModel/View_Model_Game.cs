using Game_Shop.Model_EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Shop.ViewModel
{
   public class View_Model_Game
    {        
        public static List<Game> Games;
        public static List<Mod_Game> Mod_Game;
        public static List<Studio> Studios;
        public static List<Style> Styles;
        static View_Model_Game()
        {
            using (Model_Game_Shop MGS = new Model_Game_Shop())
            {
                Games = MGS.Games.ToList();
            }
            using (Model_Game_Shop MGS = new Model_Game_Shop())
            {
                Mod_Game = MGS.Mod_Game.ToList();
            }
            using (Model_Game_Shop MGS = new Model_Game_Shop())
            {
                Studios = MGS.Studios.ToList();
            }
            using (Model_Game_Shop MGS = new Model_Game_Shop())
            {
                Styles = MGS.Styles.ToList();
            }
        }

        internal static void Dell_Game(IEnumerable itemsSource)
        {
            throw new NotImplementedException();
        }
    }
}
