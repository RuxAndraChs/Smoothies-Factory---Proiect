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

namespace Smoothies_Factory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int mBanana = 0;
        private int mOrange = 0;
        private int mMango = 0;
        private int mMocha = 0;
        private int mPurple = 0;
        private int mChia = 0;
        private int mPower = 0;
        private int mMint = 0;
        private int mBlue = 0;
        private double Total = 0;
        private SmoothiesType selectedSmoothie;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bananaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mBanana++;
            txtB_S.Text = mBanana.ToString();

        }

        private void orangeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mOrange++;
            txtO_A.Text = mOrange.ToString();
        }

        private void mangoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mMango++;
            txtM_P.Text = mMango.ToString();
        }

        private void mochaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mMocha++;
            txtMocha.Text = mMocha.ToString();
        }

        private void purpleMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mPurple++;
            txtPurple.Text = mPurple.ToString();
        }

        private void chiaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mChia++;
            txtChia.Text = mChia.ToString();
        }

        private void powerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mPower++;
            txtPower.Text = mPower.ToString();
        }

        private void mintMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mMint++;
            txtMint.Text = mMint.ToString();
        }

        private void blueMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mBlue++;
            txtBlueBerry.Text = mBlue.ToString();
        }

        private void MakingSmoothies_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;

            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " smoothies are beeing mixed!";
            this.Title = mesaj;
        }
        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        KeyValuePair<SmoothiesType, double>[] PriceList = {
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.Banana_Strawberry, 12.5),
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.Orange_Apple,11),
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.Mango_Peach,11.5),
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.Mocha_Coffe,10),
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.Purple_Rain,13.4),
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.Chia_Cleanse,15.6),
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.Power_UP,20),
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.Mint_Chocolate,21),
            new KeyValuePair<SmoothiesType, double>(SmoothiesType.BlueBerry_Madness,20.5),
        };

        private void framePrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";

        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<SmoothiesType, double> selectedEntry =
                (KeyValuePair<SmoothiesType, double>)cmbType.SelectedItem;
            selectedSmoothie = selectedEntry.Key;
        }

        private int ValidateQuantity(SmoothiesType selectedSmoothie)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;

            switch (selectedSmoothie)
            {
                case SmoothiesType.Banana_Strawberry:
                    if (q > mBanana)
                        r = 0;
                    break;
                case SmoothiesType.Orange_Apple:
                    if (q > mOrange)
                        r = 0;
                    break;
                case SmoothiesType.Mango_Peach:
                    if (q > mMango)
                        r = 0;
                    break;
                case SmoothiesType.Mocha_Coffe:
                    if (q > mMocha)
                        r = 0;
                    break;
                case SmoothiesType.Purple_Rain:
                    if (q > mPurple)
                        r = 0;
                    break;
                case SmoothiesType.Chia_Cleanse:
                    if (q > mChia)
                        r = 0;
                    break;
                case SmoothiesType.Power_UP:
                    if (q > mPower)
                        r = 0;
                    break;
                case SmoothiesType.Mint_Chocolate:
                    if (q > mMint)
                        r = 0;
                    break;
                case SmoothiesType.BlueBerry_Madness:
                    if (q > mBlue)
                        r = 0;
                    break;

            }
            return r;
        }

        private void btnAddToSale_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedSmoothie) > 0)
            {
                lstSale.Items.Add(txtQuantity.Text + " " + selectedSmoothie.ToString() +
               ":" + txtPrice.Text + " " + double.Parse(txtQuantity.Text) *
               double.Parse(txtPrice.Text));
                Total = Total + double.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Nu avem destule ingrediente pentru prepararea numarului cerut de Smoothieuri!");
            }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = "0";
            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") - 1))
                {
                    case "Banana_Strawberry":
                        mBanana = mBanana - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtB_S.Text = mBanana.ToString();
                        break;
                    case "Orange_Apple":
                        mOrange = mOrange - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtO_A.Text = mOrange.ToString();
                        break;
                    case "Mango_Peach":
                        mMango = mMango - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtM_P.Text = mMango.ToString();
                        break;
                    case "Mocha_Coffe":
                        mMocha = mMocha - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtMocha.Text = mMocha.ToString();
                        break;
                    case "Purple_Rain":
                        mPurple = mPurple - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtPurple.Text = mPurple.ToString();
                        break;
                    case "Chia_Cleanse":
                        mChia = mChia - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtChia.Text = mChia.ToString();
                        break;
                    case "Power_UP":
                        mPower = mPower - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtPower.Text = mPower.ToString();
                        break;
                    case "Mint_Chocolate":
                        mMint = mMint - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtMint.Text = mMint.ToString();
                        break;
                    case "BlueBerry_Madness":
                        mBlue = mBlue - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtBlueBerry.Text = mBlue.ToString();
                        break;
                }
            }
            lstSale.Items.Clear();
        }

        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if(!(e.Key>=Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Se pot introduce numai cifre!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
