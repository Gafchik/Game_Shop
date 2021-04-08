using Game_Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game_Shop.View
{
   public enum serch_mod
    {
        For_Game_Name,
        Fore_Game_Studio,
        Fore_Game_Style,
        Fore_Game_Year_Releas,
        Fore_Game_Mod,
        Fore_Max_Game_Count_Sell,
        Fore_Min_Game_Count_Sell
    }
    /// <summary>
    /// Логика взаимодействия для Window_serch.xaml
    /// </summary>
    public partial class Window_serch : Window
    {
        serch_mod select;
        public Window_serch()
        {
            InitializeComponent();
            Loaded += Window_serch_Loaded;
            Combo_box_Selected_serch.SelectionChanged += Combo_box_Selected_serch_SelectionChanged;
            select = serch_mod.Fore_Game_Mod;
            butt_search.Click += Butt_search_Click;
        }

        private void Butt_search_Click(object sender, RoutedEventArgs e)
        {
            if (Combo_box_Selected_serch2.Items.Count == 0)
            {
                MessageBox.Show("Нужно выбрать второй параметр поиска", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (rezult.Items.Count > 0)
                    rezult.Items.Clear();
                switch (select)
                {
                    case serch_mod.For_Game_Name:
                        break;
                    case serch_mod.Fore_Game_Studio:
                        View_Model_Game.BD.Games.ToList().FindAll(i=> i.Game_Studio_id ==
                        View_Model_Game.BD.Studios.ToList().Find(q => q.Studio_Name == Combo_box_Selected_serch2.SelectedItem.ToString()).Id)
                        .ForEach(i => rezult.Items.Add(i.Game_Name));
                        break;
                    case serch_mod.Fore_Game_Style:
                        View_Model_Game.BD.Games.ToList().FindAll(i => i.Game_Style_id ==
                         View_Model_Game.BD.Styles.ToList().Find(q => q.Style_Game_Name == Combo_box_Selected_serch2.SelectedItem.ToString()).Id)
                         .ForEach(i => rezult.Items.Add(i.Game_Name));
                        break;
                    case serch_mod.Fore_Game_Year_Releas:
                        break;
                    case serch_mod.Fore_Game_Mod:
                        View_Model_Game.BD.Games.ToList().FindAll(i => i.Game_Mod_id ==
                         View_Model_Game.BD.Mod_Game.ToList().Find(q => q.Mod_Game_Name == Combo_box_Selected_serch2.SelectedItem.ToString()).Id)
                         .ForEach(i => rezult.Items.Add(i.Game_Name));
                        break;
                    case serch_mod.Fore_Max_Game_Count_Sell:
                        break;
                    case serch_mod.Fore_Min_Game_Count_Sell:
                        break;
                    default:
                        break;
                }

            }
        }

        private void Combo_box_Selected_serch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (sender as ComboBox);
             select = serch_mod.Fore_Game_Mod;
            switch (combo.SelectedItem.ToString())
            {
                case "Поиск по названию":
                    select = serch_mod.For_Game_Name;
                    break;
                case "Поиск по студии":
                    select = serch_mod.Fore_Game_Studio;
                    break;
                case "Поиск по стилю":
                    select = serch_mod.Fore_Game_Style;
                    break;
                case "Поиск по дате выпуска":
                    select = serch_mod.Fore_Game_Year_Releas;
                    break;
                case "Поиск по онлайн модификации":
                    select = serch_mod.Fore_Game_Mod;
                    break;
                case "Поиск максимальное количество продаж":
                    select = serch_mod.Fore_Max_Game_Count_Sell;
                    break;
                case "Поиск минимальное количество продаж":
                    select = serch_mod.Fore_Min_Game_Count_Sell;
                    break;
                default:
                    break;
            }
            second_box();


        }
        private void second_box()
        {
            Combo_box_Selected_serch2.Items.Clear();
            switch (select)
            {
                case serch_mod.For_Game_Name:
                    break;
                case serch_mod.Fore_Game_Studio:
                    View_Model_Game.BD.Studios.ToList().ForEach(i => Combo_box_Selected_serch2.Items.Add(i.Studio_Name));
                    break;
                case serch_mod.Fore_Game_Style:
                    View_Model_Game.BD.Styles.ToList().ForEach(i => Combo_box_Selected_serch2.Items.Add(i.Style_Game_Name));
                    break;
                case serch_mod.Fore_Game_Year_Releas:
                    break;
                case serch_mod.Fore_Game_Mod:
                    View_Model_Game.BD.Mod_Game.ToList().ForEach(i => Combo_box_Selected_serch2.Items.Add(i.Mod_Game_Name));
                    break;
                case serch_mod.Fore_Max_Game_Count_Sell:
                    break;
                case serch_mod.Fore_Min_Game_Count_Sell:
                    break;
                default:
                    break;
            }
            Combo_box_Selected_serch2.SelectedIndex = 0;
        }
        private void Window_serch_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (serch_mod item in Enum.GetValues(typeof( serch_mod)))
            {
                switch (item)
                {
                    case serch_mod.For_Game_Name:
                        Combo_box_Selected_serch.Items.Add("Поиск по названию");
                        break;
                    case serch_mod.Fore_Game_Studio:
                        Combo_box_Selected_serch.Items.Add("Поиск по студии");
                        break;
                    case serch_mod.Fore_Game_Style:
                         Combo_box_Selected_serch.Items.Add("Поиск по стилю");
                        break;
                    case serch_mod.Fore_Game_Year_Releas:
                         Combo_box_Selected_serch.Items.Add("Поиск по дате выпуска");
                        break;
                    case serch_mod.Fore_Game_Mod:
                         Combo_box_Selected_serch.Items.Add("Поиск по онлайн модификации");
                        break;
                    case serch_mod.Fore_Max_Game_Count_Sell:
                         Combo_box_Selected_serch.Items.Add("Поиск максимальное количество продаж");
                        break;
                    case serch_mod.Fore_Min_Game_Count_Sell:
                         Combo_box_Selected_serch.Items.Add("Поиск минимальное количество продаж");
                        break;
                    default:
                        break;
                }
                second_box();
            }
        }
    }
}
