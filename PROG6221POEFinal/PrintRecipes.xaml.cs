using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for PrintRecipes.xaml
    /// </summary>
    public partial class PrintRecipes : Window, INotifyPropertyChanged
    {
        public PrintRecipes()
        {
            DataContext = this;
            InitializeComponent();
        }

        List<Recipe> recipes;

        public PrintRecipes(List<Recipe> recipes)
        {
            DataContext = this;
            this.recipes = recipes;
            InitializeComponent();
        }

        private void Main_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow run = new MainWindow(recipes);
        }

        private String recipePrintList;

        public event PropertyChangedEventHandler? PropertyChanged;

        public String RecipePrintList
        {
            get { return recipePrintList; }
            set 
            { 
                recipePrintList = value; 
                OnPropertyChanged();
            }
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            recipePrintList = createPrintList(recipes);
        }

        public String createPrintList(List<Recipe> recipes)
        {
            String value = "";
            for (int i = 0; i < recipes.Count; i++)
            {
                int calorieCount = 0;
                for (int j = 0; j < recipes.ElementAt(i).getIngredientsArray().Length; j++)
                {
                    calorieCount += Convert.ToInt32(recipes.ElementAt(i).getIngredientsObject(i, 5));
                }

                value += ("\n{0}: Recipe Name: {1}, Total Calories: {2}", i + 1, calorieCount);
            }
            return value;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
