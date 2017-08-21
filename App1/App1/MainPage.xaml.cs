using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void addNumber(double number)
        {
            if (char.IsNumber(result.Text.Last()))
            {
                if(result.Text.Length == 1 && result.Text == "0")
                {
                    result.Text = string.Empty;
                }
                result.Text += number;
            }
            else
            {
                if (number != 0)
                {
                    result.Text += number;
                }
            }
        }

        private void bt7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btDot_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btPlus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btMinus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btMultiply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btDivide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bteClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCancle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btEqual_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
