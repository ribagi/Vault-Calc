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
using System.Text.RegularExpressions;

namespace Vault_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Vault v;
        private Ring r;
        private RingDialog ringDialog;

        public MainWindow()
        {
            InitializeComponent();
            v = new Vault();
            r = new Ring();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void Calculate()
        {
            if (Layer != null 
                && Head != null 
                && Tail != null 
                && Speed != null 
                && v != null 
                && r != null
                && !Layer.Text.Equals("") 
                && !Head.Text.Equals("") 
                && !Tail.Text.Equals(""))
            {
                try
                {
                    v.layer = Int32.Parse(Layer.Text);

                    v.x = Convert.ToInt32(Head.Text);
                    v.y = Convert.ToInt32(Tail.Text);
                    v.checkDouble = check.IsChecked.Value;

                    Cost.Text = Convert.ToString(v.Cost() + r.TotalCost());
                    X_Time.Text = Convert.ToString(v.X_time(Int32.Parse(Speed.Text)));
                    Y_Time.Text = Convert.ToString(v.Y_time(Int32.Parse(Speed.Text)));
                    X.Text = Convert.ToString(v.X_layer());
                    Y.Text = Convert.ToString(v.Y_layer());
                }
                catch (Exception e)
                {
                    System.IO.File.WriteAllText("Stack.trace", e.StackTrace);
                    System.Windows.MessageBox.Show("Error has accored! Please submit the file 'Stack.trace' to the issue section of the main Github.");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ringDialog = new RingDialog();
            ringDialog.Rings = r;
            ringDialog.Main = this;
            ringDialog.Show();
        }

        private void DoubleBase_Checked(object sender, RoutedEventArgs e)
        {
            Calculate();

        }

        private void DoubleBase_Unchecked(object sender, RoutedEventArgs e)
        {
            Calculate();

        }

        private void Layer_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();

        }

        private void Head_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();

        }

        private void Tail_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();

        }

        private void Speed_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();

        }

        private void Cost_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void X_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Y_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void YTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void XTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
