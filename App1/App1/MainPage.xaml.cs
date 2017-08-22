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

            result.Text = 0.ToString();
        }

        private void AddNumber(double number)
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
        
        enum Operation { MINUS=1,PLUS=2,DIVIDE=3,MULTIPLY=4,PERCEN=5,NUMBER=6 }
        private void AddOperation(Operation operation)
        {
            if (result.Text.Length == 1 && result.Text == "0") return;

            if (!char.IsNumber(result.Text.Last()))
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }

            switch (operation)
            {
                case Operation.MINUS: result.Text += "-"; break;
                case Operation.PLUS: result.Text += "+"; break;
                case Operation.DIVIDE: result.Text += "÷"; break;
                case Operation.MULTIPLY: result.Text += "x"; break;
                case Operation.PERCEN: result.Text += "%"; break;

            }
        }

        private void bt7_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(7);
        }

        private void bt8_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(8);
        }

        private void bt9_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(9);
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(4);
        }

        private void bt5_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(5);
        }

        private void bt6_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(6);
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(1);
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(2);
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(3);
        }

        private void bt0_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(0);
        }

        private void btPlus_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operation.PLUS);
        }

        private void btMinus_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operation.MINUS);
        }

        private void btMultiply_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operation.MULTIPLY);
        }

        private void btDivide_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operation.DIVIDE);
        }

        private void bteClear_Click(object sender, RoutedEventArgs e)
        {
            result.Text = 0.ToString();
        }

        private void btPercen_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operation.PERCEN);
        }

        #region Equal
        private class Operand
        {
            public Operation operation = Operation.NUMBER;      //default
            public double value = 0;

            public Operand left = null;
            public Operand right = null;
        }

        private Operand BuildTreeOperand()      //get expression from result.Text and build a tree with it
        {
            Operand tree = null;
            string expression = result.Text;
            if (!char.IsNumber(expression.Last()))
            {
                expression = expression.Substring(0, expression.Length - 1);
            }
            string numberStr = string.Empty;
            foreach(char c in expression.ToCharArray())
            {
                if(char.IsNumber(c)||c == '.' || numberStr == string.Empty && c == '-')
                {
                    numberStr += c;
                }
                else
                {
                    AddOperandToTree(ref tree, new Operand() { value = double.Parse(numberStr) });
                    numberStr = string.Empty;

                    Operation op = Operation.MINUS;       //default
                    switch (c)
                    {
                        case '-': op = Operation.MINUS; break;
                        case '+': op = Operation.PLUS; break;
                        case 'x': op = Operation.MULTIPLY; break;
                        case '÷': op = Operation.DIVIDE; break;
                        case '%': op = Operation.PERCEN; break;
                    }
                    AddOperandToTree(ref tree, new Operand() { operation = op });
                }
            }
            //last number
            AddOperandToTree(ref tree, new Operand() { value = double.Parse(numberStr) });
            return tree;
        }

        private void AddOperandToTree(ref Operand tree, Operand elem)
        {
            if (tree == null)
            {
                tree = elem;
            }
            else
            {
                if (elem.operation < tree.operation)
                {
                    Operand auxTree = tree;
                    tree = elem;
                    elem.left = auxTree;
                }
                else
                {
                    AddOperandToTree(ref tree.right, elem);     //recursive
                }
            }
        }

        private double Calc(Operand tree)
        {
            if (tree.left == null && tree.right == null)        //it's a number
            {
                return tree.value;
            }
            else    //it's an operation (+,-,/,*)
            {
                double subResult = 0;
                switch (tree.operation)
                {
                    case Operation.MINUS: subResult = Calc(tree.left) - Calc(tree.right); break;
                    case Operation.PLUS: subResult = Calc(tree.left) + Calc(tree.right); break;
                    case Operation.MULTIPLY: subResult = Calc(tree.left) * Calc(tree.right); break;
                    case Operation.DIVIDE: subResult = Calc(tree.left) / Calc(tree.right); break;
                    case Operation.PERCEN: subResult = (Calc(tree.left) * Calc(tree.right) / 100); break;
                }
                return subResult;
            }
        }

        private void btEqual_Click(object sender, RoutedEventArgs e)
        {
            //gate
            if (string.IsNullOrEmpty(result.Text)) return;
            Operand tree = BuildTreeOperand();      //from string in result.Text

            double value = Calc(tree);      //evaluate tree to culculate finish result
            result.Text = value.ToString();
        }
    }
}
#endregion