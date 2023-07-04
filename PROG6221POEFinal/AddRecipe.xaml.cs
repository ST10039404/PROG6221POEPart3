using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Printing;
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
        List<Recipe> recipes;
        object[,] ingredients;
        string[] steps;
        int ingredientCount;
        int stepCount;

        public AddRecipe()
        {
            ingredientCount = 0;
            stepCount = 0;
            InitializeComponent();
        }

        public AddRecipe(List<Recipe> recipes)
        {
            ingredientCount = 0;
            stepCount = 0;
            this.recipes = recipes;
            InitializeComponent();
        }

        private void Main_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow run = new MainWindow(recipes);
        }

        private void createStep_Click(object sender, RoutedEventArgs e)
        {
            createMyStep();
        }

        private void createIngredient_Click(object sender, RoutedEventArgs e)
        {
            createMyIngredient();
        }

        public object[,] createMyIngredient()
        {
            int quantity;
            int calories;

            if (!String.IsNullOrWhiteSpace(nameInput.Text) && Int32.TryParse(quantityInput.Text, out quantity) && !String.IsNullOrWhiteSpace(measurementInput.Text) && Int32.TryParse(caloriesInput.Text, out calories) && !String.IsNullOrWhiteSpace(foodGroupInput.Text))
                {
                    ingredients[ingredientCount, 0] = nameInput.Text;
                    ingredients[ingredientCount, 1] = quantity;
                    ingredients[ingredientCount, 2] = measurementInput.Text;
                    ingredients[ingredientCount, 3] = 1;
                    ingredients[ingredientCount, 4] = calories;
                    ingredients[ingredientCount, 5] = foodGroupInput.Text;

                    ingredientCount += 1;

                    nameInput.Clear();
                    quantityInput.Clear();
                    measurementInput.Clear();
                    caloriesInput.Clear();
                    foodGroupInput.Clear();
                }
            else
                {
                MessageBox.Show("Please re-enter ingredient details as one of the details are incorrect.");
                }
            return ingredients;
        }

        public string[] createMyStep()
        {
            if (!String.IsNullOrWhiteSpace(stepDescriptionInput.Text))
            {
                steps[stepCount] += stepDescriptionInput.Text;

                stepCount += 1;

                stepDescriptionInput.Clear();
            }
            else
            {
                MessageBox.Show("Step Description is Null or Only White Spaces.");
            }
            
            return steps;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            String recipeName = recipeNameInput.Text;
            Recipe newRecipe = new Recipe(recipeName, ingredients, steps);
            recipes.Add(newRecipe);
            MessageBox.Show("Recipe Submited!");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(steps, 0, steps.Length);

            nameInput.Clear();
            quantityInput.Clear();
            measurementInput.Clear();
            caloriesInput.Clear();
            foodGroupInput.Clear();
            stepDescriptionInput.Clear();

            ingredientCount = 0;
            stepCount = 0;

            MessageBox.Show("Recipe Cleared!");
        }
    }
}
