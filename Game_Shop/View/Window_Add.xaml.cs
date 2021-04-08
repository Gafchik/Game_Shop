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

            Model_EF.Game temp_Game = new Model_EF.Game();
            temp_Game.Game_Name = TextBlock_Game_Name.Text;
            if (TextBlock_New_Game_Studio.Text != "")
            {
                View_Model_Game.BD.Studios.Add(new Model_EF.Studio() { Studio_Name = TextBlock_New_Game_Studio.Text });
                View_Model_Game.BD.SaveChanges();
                temp_Game.Game_Studio_id = View_Model_Game.BD.Studios.ToList().Find(i => i.Studio_Name == TextBlock_New_Game_Studio.Text).Id;
            }
            else
                temp_Game.Game_Studio_id = View_Model_Game.BD.Studios.ToList().Find(i => i.Studio_Name == ComboBox_Game_Studio.SelectedItem.ToString()).Id;

            if (TextBlock_New_Game_Stile.Text != "")
            {
                View_Model_Game.BD.Styles.Add(new Model_EF.Style() { Style_Game_Name = TextBlock_New_Game_Stile.Text });
                View_Model_Game.BD.SaveChanges();
                temp_Game.Game_Studio_id = View_Model_Game.BD.Styles.ToList().Find(i => i.Style_Game_Name == TextBlock_New_Game_Stile.Text).Id;
            }
            else
                temp_Game.Game_Style_id = View_Model_Game.BD.Styles.ToList().Find(i => i.Style_Game_Name == ComboBox_Game_Style.SelectedItem.ToString()).Id;

            try
            {
                temp_Game.Game_Year_Releas = Calendar.SelectedDate.Value;
            }
            catch (Exception)
            {
                temp_Game.Game_Year_Releas = DateTime.Now;
            }
           // temp_Game.Game_Year_Releas = new DateTime(Calendar.SelectedDate.Value.Year, Calendar.SelectedDate.Value.Month, Calendar.SelectedDate.Value.Day);
            temp_Game.Game_Mod_id = View_Model_Game.BD.Mod_Game.ToList().Find(i => i.Mod_Game_Name == ComboBox_Game_Mod.SelectedItem.ToString()).Id;
            temp_Game.Game_Count_Sell = Convert.ToInt32(TextBlock_Game_Sells.Text);


            View_Model_Game.BD.Games.Add(temp_Game);
            
            View_Model_Game.BD.SaveChanges();
            MessageBox.Show("Информация успешно добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
            //    In_Game_Edit_Style_id

            //TextBlock_New_Game_Stile 

            // TextBlock_New_Game_Studio 

            //   TextBlock_Game_Name 

            //  ComboBox_Game_Style 

            //   ComboBox_Game_Studio 

            //  Calendar 

            //  ComboBox_Game_Mod 

            //  TextBlock_Game_Sells 

            //   Button_ADD 

        }




    }
}
