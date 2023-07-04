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
    /// Interaction logic for FactorialChange.xaml
    /// </summary>
    public partial class FactorialChange : Window
    {
        public FactorialChange()
        {
            DataContext = this;
            InitializeComponent();
        }

        List<Recipe> recipes;

        public FactorialChange(List<Recipe> recipes)
        {
            DataContext = this;
            this.recipes = recipes;
            InitializeComponent();
        }

        private void Main_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow run = new MainWindow(recipes);
        }

        private int currIndex;

        public int CurrIndex
        {
            get { return currIndex; }
            set { currIndex = value; }
        }


        private void NewIndex_Click(object sender, RoutedEventArgs e)
        {
            int x;
            bool y = Int32.TryParse(indexNew.Text, out x);
            if (y == true && recipes.ElementAt(x)!=null)
            {
                currIndex = x;
                currIndexBlock.Text = Convert.ToString(x);
                indexNew.Clear();
            }
            else
            {
                MessageBox.Show("Error the index you have entered is invalid, \nPlease enter only numbers within the list of indexes\nWithin the list of recipes.", "Incorrect Index Assignment");
                indexNew.Clear();
            }
        }

        private void NewFactorial_Click(object sender, RoutedEventArgs e)
        {
            int x;
            bool y = Int32.TryParse(factorialNew.Text, out x);
            if (y == true && recipes.ElementAt(x) != null)
            {
                for (int i = 0; i < recipes.ElementAt(currIndex).getIngredientsArray().GetLength(0); i++)
                {
                    recipes.ElementAt(currIndex).setIngredientsObject(i, 3, x);
                }
                factorialBlock.Text = factorialNew.Text;
                factorialNew.Clear();
            }
            else 
            {
                MessageBox.Show("Please enter only numbers into the factorial quantity.", "Incorrect Factorial Assignment");
                factorialNew.Clear();
            }
        }
    }
}
