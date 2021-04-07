using Game_Shop.Model_EF;
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
    /// <summary>
    /// Логика взаимодействия для Window_Rezult.xaml
    /// </summary>
    public partial class Window_Rezult : Window
    {
        public Game curent_game;
        public void Get_Game(Game itemsSource) => curent_game = itemsSource;

        public Window_Rezult()
        {
            InitializeComponent();
            Loaded += Window_Rezult_Loaded;
            CheckBox_Edit.Checked += CheckBox_Edit_Checked;
            CheckBox_Edit.Unchecked += CheckBox_Edit_Unchecked;
            Button_Save.Click += Button_Save_Click;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            View_Model_Game.Edit(curent_game,
TextBlock_Game_Name.Text,
Calendar.SelectedDate.Value,
TextBlock_Game_Sells.Text,
ComboBox_Game_Style.SelectedItem.ToString(),
ComboBox_Game_Studio.SelectedItem.ToString(),
ComboBox_Game_Mod.SelectedItem.ToString());
            Load();

        }



        private void CheckBox_Edit_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBlock_Game_Name.IsEnabled = false;
            ComboBox_Game_Style.IsEnabled = false;
            ComboBox_Game_Studio.IsEnabled = false;
            Calendar.IsEnabled = false;
            ComboBox_Game_Mod.IsEnabled = false;
            TextBlock_Game_Sells.IsEnabled = false;
            Button_Save.IsEnabled = false;
          
        }

        private void CheckBox_Edit_Checked(object sender, RoutedEventArgs e)
        {
            TextBlock_Game_Name.IsEnabled = true;
            ComboBox_Game_Style.IsEnabled = true;
            ComboBox_Game_Studio.IsEnabled = true;
            Calendar.IsEnabled = true;
            ComboBox_Game_Mod.IsEnabled = true;
            TextBlock_Game_Sells.IsEnabled = true;
            Button_Save.IsEnabled = true;
        }
        private void Load()
        {
            TextBlock_Game_Name.Text = curent_game.Game_Name;
            Calendar.SelectedDate = curent_game.Game_Year_Releas;
            TextBlock_Game_Sells.Text = curent_game.Game_Count_Sell.ToString();

            View_Model_Game.BD.Styles.ToList().ForEach(i => ComboBox_Game_Style.Items.Add(i.Style_Game_Name.ToString()));
            ComboBox_Game_Style.SelectedIndex = View_Model_Game.BD.Styles.ToList().IndexOf(View_Model_Game.BD.Styles.ToList().Find(i => i.Id == curent_game.Game_Style_id));

            View_Model_Game.BD.Studios.ToList().ForEach(i => ComboBox_Game_Studio.Items.Add(i.Studio_Name.ToString()));
            ComboBox_Game_Studio.SelectedIndex = View_Model_Game.BD.Studios.ToList().IndexOf(View_Model_Game.BD.Studios.ToList().Find(i => i.Id == curent_game.Game_Studio_id));

            View_Model_Game.BD.Mod_Game.ToList().ForEach(i => ComboBox_Game_Mod.Items.Add(i.Mod_Game_Name.ToString()));
            ComboBox_Game_Mod.SelectedIndex = View_Model_Game.BD.Mod_Game.ToList().IndexOf(View_Model_Game.BD.Mod_Game.ToList().Find(i => i.Id == curent_game.Game_Mod_id));

        }
        private void Window_Rezult_Loaded(object sender, RoutedEventArgs e) => Load();
      
    }
}
