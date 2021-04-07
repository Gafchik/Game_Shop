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
    /// Логика взаимодействия для Window_add.xaml
    /// </summary>
    public partial class Window_add : Window
    {
        public Window_add()
        {
            InitializeComponent();
            Button_ADD.Click += Button_ADD_Click;
            Loaded += Window_add_Loaded;
        }

        private void Window_add_Loaded(object sender, RoutedEventArgs e)
        {        
            View_Model_Game.BD.Styles.ToList().ForEach(i => ComboBox_Game_Style.Items.Add(i.Style_Game_Name.ToString()));         
            View_Model_Game.BD.Studios.ToList().ForEach(i => ComboBox_Game_Studio.Items.Add(i.Studio_Name.ToString()));
            View_Model_Game.BD.Mod_Game.ToList().ForEach(i => ComboBox_Game_Mod.Items.Add(i.Mod_Game_Name.ToString()));
            ComboBox_Game_Style.SelectedIndex = 0;
            ComboBox_Game_Studio.SelectedIndex = 0;
            ComboBox_Game_Mod.SelectedIndex = 0;
        }

        private void Button_ADD_Click(object sender, RoutedEventArgs e)
        {

            foreach (UIElement item in Stack.Children)
            {
                if (item is TextBox)
                {
                    if ((item as TextBox).Text == "")
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                   
                }
            }
            
            
           
        }
    }
}
