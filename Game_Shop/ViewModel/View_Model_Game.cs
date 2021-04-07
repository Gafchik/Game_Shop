using Game_Shop.Model_EF;
using Game_Shop.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game_Shop.ViewModel
{
   public class View_Model_Game
    {
        public static Model_Game_Shop BD;
       
        static View_Model_Game()
        {
            BD = new Model_Game_Shop();
           
        }

        internal static void Dell_Game(object SelectedItem)
        {


            if (BD.Games.ToList().Exists(i => i.Game_Name == (SelectedItem as string)))
            {
                BD.Games.ToList().Remove(BD.Games.ToList().FirstOrDefault(i => i.Game_Name == (SelectedItem as string)));
                BD.SaveChanges();
            }
            else
                MessageBox.Show("Что-то пошло нет так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
       
        }

        internal static void Info_Game(object SelectedItem)
        {
            var window_info = new Window_Rezult();
           
            if (BD.Games.ToList().Exists(i => i.Game_Name == (SelectedItem as string)))
            {
                window_info.Get_Game( BD.Games.ToList().Find(i => i.Game_Name == (SelectedItem as string)));
                window_info.ShowDialog();
            }
            else
                MessageBox.Show("Что-то пошло нет так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        internal static void Edit(Game curent_game, string Name, DateTime selectedDate, string Sells, string style, string studio, string mod)
        {
            var edit_game = BD.Games.Find(curent_game);
            edit_game.Game_Name = Name;
            edit_game.Game_Studio_id = BD.Studios.ToList().Find(i => i.Studio_Name == studio).Id;
            edit_game.Game_Style_id = BD.Styles.ToList().Find(i => i.Style_Game_Name == style).Id;
            edit_game.Game_Year_Releas = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);
            edit_game.Game_Mod_id = BD.Mod_Game.ToList().Find(i => i.Mod_Game_Name == mod).Id;
            edit_game.Game_Count_Sell = Convert.ToInt32(Sells);
            BD.SaveChanges();
        }
    }
    
}
