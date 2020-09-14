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

namespace prb.arrays02.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string[,] names;
        int position;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            names = new string[5, 2];
            names[0, 0] = "Annie";
            names[1, 0] = "Wim";
            names[2, 0] = "Inge";
            names[3, 0] = "Karel";
            names[4, 0] = "Celine";
            names[0, 1] = "Gent";
            names[1, 1] = "Brussel";
            names[2, 1] = "Beernem";
            names[3, 1] = "Oostende";
            names[4, 1] = "Brugge";

            lstNames.Items.Add(names[0, 0]);
            lstNames.Items.Add(names[1, 0]);
            lstNames.Items.Add(names[2, 0]);
            lstNames.Items.Add(names[3, 0]);
            lstNames.Items.Add(names[4, 0]);

            btnUpdate.IsEnabled = false;

        }

        private void lstNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtName.Text = "";
            txtCity.Text = "";
            btnUpdate.IsEnabled = false;
            position = -1;

            if (lstNames.SelectedItem != null)
            {
                string searchName = (string)lstNames.SelectedItem;
                txtName.Text = searchName;
                if (searchName == names[0, 0]) position = 0;
                else if (searchName == names[1, 0]) position = 1;
                else if (searchName == names[2, 0]) position = 2;
                else if (searchName == names[3, 0]) position = 3;
                else if (searchName == names[4, 0]) position = 4;

                if(position != -1)
                {
                    btnUpdate.IsEnabled = true;
                    txtCity.Text = names[position, 1];
                }

            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string updateName = txtName.Text.Trim();
            string updateCity = txtCity.Text.Trim();

            names[position, 0] = updateName;
            names[position, 1] = updateCity;

            lstNames.Items[position] = updateName;
            btnUpdate.IsEnabled = false;
        }
    }
}
