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
    /// Interaction logic for DisplayRecipe.xaml
    /// </summary>
    public partial class DisplayRecipe : Window
    {
        public DisplayRecipe()
        {
            InitializeComponent();
        }

        List<Recipe> recipes;

        public DisplayRecipe(List<Recipe> recipes)
        {
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


        private void IndexUpdate_Click(object sender, RoutedEventArgs e)
        {
            int x;
            bool y = Int32.TryParse(currIndexInput.Text, out x);
            if (y == true && recipes.ElementAt(x) != null)
            {
                currIndex = x;
                currIndexBlock.Text = Convert.ToString(x);
                currIndexInput.Clear();
            }
            else
            {
                MessageBox.Show("Error the index you have entered is invalid, \nPlease enter only numbers within the list of indexes\nWithin the list of recipes.", "Incorrect Index Assignment");
                currIndexInput.Clear();
            }

            
        }

        public void updateValues(List<Recipe> recipes)
        {
            string Ingredients = createIngredientString(recipes, currIndex);
            string Steps = createStepsString(recipes, currIndex); ;
            nameBlock.Text = recipes.ElementAt(currIndex).getRecipeName();
            ingredientsBlock.Text = Ingredients;
            stepsBlock.Text = Steps;
        }

        public string createIngredientString(List<Recipe> recipes, int index)
        {
            Recipe x = recipes.ElementAt(index);
            string ingredientString = "";
            for (int i = 0; i < recipes.Count; i++)
            {
                ingredientString += ("\nIngredient {0}: {1}, {2} {3}; Calories: {4}, Food Group {5}",i+1,x.getIngredientsObject(i, 0), (Convert.ToInt32(x.getIngredientsObject(i, 1))*(Convert.ToInt32(x.getIngredientsObject(i, 3)))), x.getIngredientsObject(i, 2), x.getIngredientsObject(i, 4), x.getIngredientsObject(i, 5));
            }
            return ingredientString;
        }

        public string createStepsString(List<Recipe> recipes, int index)
        {
            Recipe x = recipes.ElementAt(index);
            string stepsString = "";
            for (int i = 0; i < recipes.Count; i++)
            {
                stepsString += ("\nStep {0}: {1}", i + 1, x.getStepsObject(i));
            }
            return stepsString;
        }
    }
}
