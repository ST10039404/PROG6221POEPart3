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

namespace PROG6221POEFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(List<Recipe> recipes)
        {
            this.recipes = recipes;
            InitializeComponent();
        }

        private void MenuButtonButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe run = new AddRecipe(recipes);
        }

        private void MenuButton2Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipe run = new DisplayRecipe(recipes);
        }

        private void MenuButton3Button_Click(object sender, RoutedEventArgs e)
        {
            FactorialChange run = new FactorialChange(recipes);
        }

        private void MenuButton4Button_Click(object sender, RoutedEventArgs e)
        {
            PrintRecipes run = new PrintRecipes(recipes);
        }

        private void MenuButton5Button_Click(object sender, RoutedEventArgs e)
        {
            ClearRecipes run = new ClearRecipes(recipes);
        }

        private void MenuButton6Button_Click(object sender, RoutedEventArgs e)
        {
            FilterRecipes run = new FilterRecipes(recipes);
        }

        private void Main_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow run = new MainWindow(recipes);
        }
    }
}
