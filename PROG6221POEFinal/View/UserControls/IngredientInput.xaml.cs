using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PROG6221POEFinal.View.UserControls
{
    /// <summary>
    /// Interaction logic for IngredientInput.xaml
    /// </summary>
    public partial class IngredientInput : UserControl, INotifyPropertyChanged
    {
        public IngredientInput()
        {
            DataContext = this;
            InitializeComponent();
        }

        private String nextPage;

        public event PropertyChangedEventHandler? PropertyChanged;

        public String NextPage
        {
            get { return nextPage; }
            set 
            { 
                nextPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NextPage"));
            }
        }

    }
}
