using Game_Shop.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game_Shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Button_Add.Click += Button_Add_Click;
            Button_Dell.Click += Button_Dell_Click;
            Button_info.Click += Button_info_Click;
            Button_Serch.Click += Button_Serch_Click;
            Loaded += MainWindow_Loaded;
           
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) => Load();
       
        private void Load()
        {
            if (Combo_box_Game.Items.Count != 0)
                Combo_box_Game.Items.Clear();
            View_Model_Game.BD.Games.ToList().ForEach(i => Combo_box_Game.Items.Add(i.Game_Name.ToString()));
            Combo_box_Game.SelectedIndex = 0;
        }
        private void Button_Serch_Click(object sender, RoutedEventArgs e) => new Window_serch().ShowDialog();
        private void Button_info_Click(object sender, RoutedEventArgs e) { View_Model_Game.Info_Game(Combo_box_Game.SelectedItem); Load(); }
        private void Button_Dell_Click(object sender, RoutedEventArgs e) => View_Model_Game.Dell_Game(Combo_box_Game.SelectedItem);
        private void Button_Add_Click(object sender, RoutedEventArgs e)=> new Window_add().ShowDialog();
       
    }
}
