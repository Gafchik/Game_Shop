using Game_Shop.Model_EF;
using Game_Shop.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

            lock (typeof(View_Model_Game))
            {
                using (Model_Game_Shop BDD = new Model_Game_Shop())
                {
                    if (BDD.Games.ToList().Exists(i => i.Game_Name == (SelectedItem as string)))
                    {
                            BDD.Games.Remove(BDD.Games.ToList().Find(i => i.Game_Name == (SelectedItem as string)));
                            BDD.SaveChanges();
                    }
                    else
                        MessageBox.Show("Что-то пошло нет так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        internal static void Info_Game(object SelectedItem)
        {
            var window_info = new Window_Rezult();

            if (BD.Games.ToList().Exists(i => i.Game_Name == (SelectedItem as string)))
            {
                window_info.Get_Game(BD.Games.ToList().Find(i => i.Game_Name == (SelectedItem as string)));
                window_info.ShowDialog();
            }
            else
                MessageBox.Show("Что-то пошло нет так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #region edit row game
        internal static void In_Game_Edit_Style_id(Game curent_game, string Game_Style)
        {
            lock (typeof(View_Model_Game))
            {
                using (Model_Game_Shop BDD = new Model_Game_Shop())
                {
                    curent_game.Game_Studio_id = BD.Styles.ToList().Find(i => i.Style_Game_Name == Game_Style).Id;
                    BDD.SaveChanges();
                }
            }
        }

        internal static void In_Game_Edit_Game_Count_Sell(Game curent_game, string Game_Sells)
        {
            lock (typeof(View_Model_Game))
            {
                using (Model_Game_Shop BDD = new Model_Game_Shop())
                {
                    curent_game.Game_Count_Sell = Convert.ToInt32(Game_Sells);
                    BDD.SaveChanges();
                }
            }
        }

        internal static void In_Game_Edit_Game_Mod_id(Game curent_game, string Game_Mod)
        {
            lock (typeof(View_Model_Game))
            {
                using (Model_Game_Shop BDD = new Model_Game_Shop())
                {
                    curent_game.Game_Mod_id = BD.Mod_Game.ToList().Find(i => i.Mod_Game_Name == Game_Mod).Id;
                    BDD.SaveChanges();
                }
            }
        }

        internal static void In_Game_Edit_Year_Releas(Game curent_game, Calendar calendar)
        {
            lock (typeof(View_Model_Game))
            {
                using (Model_Game_Shop BDD = new Model_Game_Shop())
                {
                    curent_game.Game_Year_Releas = new DateTime(calendar.SelectedDate.Value.Year, calendar.SelectedDate.Value.Month, calendar.SelectedDate.Value.Day);
                    BDD.SaveChanges();
                }
            }
        }

        internal static void In_Game_Edit_Studio_id(Game curent_game, string Game_Studio)
        {
            lock (typeof(View_Model_Game))
            {
                using (Model_Game_Shop BDD = new Model_Game_Shop())
                {
                    curent_game.Game_Studio_id = BD.Studios.ToList().Find(i => i.Studio_Name == Game_Studio).Id;
                    BDD.SaveChanges();
                }
            }
        }

        internal static void In_Game_Edit_Name(Game curent_game, string text)
        {
            lock (typeof(View_Model_Game))
            {
                using (Model_Game_Shop BDD = new Model_Game_Shop())
                {
                    curent_game.Game_Name = text;
                    BDD.SaveChanges();
                }
            }
        }
        #endregion

    }

}
