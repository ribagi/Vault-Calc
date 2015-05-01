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
using System.Text.RegularExpressions;

namespace Vault_Calculator
{
    /// <summary>
    /// Interaction logic for RingDialog.xaml
    /// </summary>
    public partial class RingDialog : Window
    {
        private Ring _rings;
        internal Ring Rings { get { return _rings; } set { _rings = value; } }

        private MainWindow main;
        public MainWindow Main {get { return main; }set { main = value; }}

        public string ReinforcementTotalText { get; set; }
        public string DiamondsTotalText { get; set; }
        public string StartText { get; set; }
        public string NumberText { get; set; }
        public string SpaceText { get; set; }
        public string ReinforceText { get; set; }
        public int Total { get; set; }
        public int Reinforce { get; set; }

        public RingDialog()
        {
            InitializeComponent();
            _rings = new Ring();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Calculate()
        {
            if (ReinforcementsTotal != null 
                && DiamondsTotal != null
                && Start != null
                && Rings != null
                && Space != null
                && Height != null
                && !Start.Text.Equals("")
                && !Number.Text.Equals("")
                && !Space.Text.Equals("")
                && !ReinforceCost.Text.Equals("")
                && !Height.Text.Equals(""))
            {
                try
                {
                    _rings.Start = Int32.Parse(Start.Text);
                    _rings.Rings = Int32.Parse(Number.Text);
                    _rings.Space = Int32.Parse(Space.Text);
                    _rings.Height = Int32.Parse(Height.Text);
                    Reinforce = Int32.Parse(ReinforceCost.Text);
                    int total = _rings.TotalCost();
                    ReinforcementsTotal.Text = (total).ToString();
                    DiamondsTotal.Text = ((int)Math.Ceiling((double)total / Reinforce)).ToString();

                    StartText = Start.Text;
                    NumberText = Number.Text;
                    SpaceText = Space.Text;
                    Total = total;
                    ReinforceText = ReinforceCost.Text;
                    ReinforcementTotalText = ReinforcementsTotal.Text;
                    DiamondsTotalText = DiamondsTotal.Text;

                    ChangeMainWindow();
                }
                catch (Exception e)
                {
                    System.IO.File.WriteAllText("Stack.trace", e.StackTrace);
                    System.Windows.MessageBox.Show("Error has accored! Please submit the file 'Stack.trace' to the issue section of the main Github.");
                }
            }
        }

        private void ChangeMainWindow()
        {
            main.Calculate();
        }

        private void Iron_Checked(object sender, RoutedEventArgs e)
        {
            Diamond.IsChecked = false;
            Stone.IsChecked = false;
            ReinforceCost.Text = "12";
            DiamondsTotal.Text = ((int)Math.Ceiling(Int32.Parse(ReinforcementsTotal.Text) / 12.0)).ToString();
            ChangeMainWindow();
        }

        private void Diamond_Checked(object sender, RoutedEventArgs e)
        {
            Iron.IsChecked = false;
            Stone.IsChecked = false;
            ReinforceCost.Text = "1";
            DiamondsTotal.Text = ((int)Math.Ceiling(Int32.Parse(ReinforcementsTotal.Text) / 1.0)).ToString();
            ChangeMainWindow();
        }

        private void Stone_Checked(object sender, RoutedEventArgs e)
        {
            Diamond.IsChecked = false;
            Iron.IsChecked = false;
            ReinforceCost.Text = "150";
            DiamondsTotal.Text = ((int)Math.Ceiling(Int32.Parse(ReinforcementsTotal.Text) / 150.0)).ToString();
            ChangeMainWindow();
        }

        private void RadiusChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        private void RingChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        private void SpaceChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        private void ReinforcementCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        private void Height_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }
    }
}
