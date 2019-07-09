using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp.Domain
{
    public partial class RekenmachineForm : Form
    {
        public RekenmachineForm()
        {
            InitializeComponent();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void ButtonIs_Click(object sender, EventArgs e)
        {
            textBox1.Text = RekenmachineClassLibrary.BerekenClass.Bereken(textBox1.Text).ToString();
        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void ButtonMin_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void ButtonMaal_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void ButtonDeel_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void ButtonOpenHaakje_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void ButtonSluitHaakje_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void ButtonVeranderTeken_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[0] != '-')
            {
                textBox1.Text = "-" + textBox1.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
            }      
        }

        private void ButtonInvert_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int result))
            {
                textBox1.Text = "1/" + textBox1.Text;
            }
            else
            {
                textBox1.Text = "1/(" + textBox1.Text + ")";
            }
        }

        private void ButtonCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void ButtonKwadraat_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^2";
        }

        private void ButtonSqrt_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^(1/2)";
        }
    }
}
