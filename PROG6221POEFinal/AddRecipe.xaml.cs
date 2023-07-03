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

namespace PROG6221POEFinal
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        public AddRecipe()
        {
            InitializeComponent();
        }

        List<Recipe> recipes;

        public AddRecipe(List<Recipe> recipes)
        {
            this.recipes = recipes;
            InitializeComponent();
        }

        private void Main_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow run = new MainWindow(recipes);
        }
    }
}
