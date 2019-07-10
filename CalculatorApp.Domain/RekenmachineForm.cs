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
        public bool GetalIngevuld { get; set; }
        public string Bewerking { get; set; }
        public string Getal1 { get; set; }
        public string Getal2 { get; set; }
        public string VoorlopingResult { get; set; }

        public RekenmachineForm()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            textBox1.Text += 1;
            GetalIngevuld = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 2;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 3;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 4;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 5;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 6;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 7;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 8;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 9;
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            GetalIngevuld = true;
            textBox1.Text += 0;
        }

        private void ButtonIs_Click(object sender, EventArgs e)
        {
            if (Bewerking == null)
            {
                Getal1 = textBox1.Text;
                listBox1.Items.Add(Getal1 + " = " + Getal1);
            }
            else if (GetalIngevuld && textBox1.Text != "-")
            {
                Getal2 = textBox1.Text;
                GetalIngevuld = false;
                textBox1.Text = RekenmachineClassLibrary.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
                textBox2.Text += " " + Getal2 + " = " + textBox1.Text;
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = "";
            }
            else if (textBox1.Text.Any(c => char.IsDigit(c)) && textBox1.Text != "-")
            {
                Getal1 = textBox1.Text;
                textBox1.Text = RekenmachineClassLibrary.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
                textBox2.Text += Getal1 + " " + Bewerking + " " + Getal2 + " = " + textBox1.Text;
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = "";
            }
        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(','))
            {
                GetalIngevuld = true;
                textBox1.Text += ",";
            }
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (GetalIngevuld && textBox1.Text != "-" && ( textBox2.Text.Contains("+") || textBox2.Text.Contains("-") || textBox2.Text.Contains("*") || textBox2.Text.Contains("/")) )
            {
                Getal2 = textBox1.Text;
                textBox1.Text = RekenmachineClassLibrary.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
                Getal1 = textBox1.Text;
                GetalIngevuld = false;
                Bewerking = "+";
                textBox2.Text += Getal2 + " " + Bewerking + " ";
            }

            else if (textBox2.Text.Length < 1)
            {
                Getal1 = textBox1.Text;
                GetalIngevuld = false;
                Bewerking = "+";
                textBox2.Text += Getal1 + " " + Bewerking + " ";
            }
        }

        private void ButtonMin_Click(object sender, EventArgs e)
        {
            if (GetalIngevuld && textBox1.Text != "-" && (textBox2.Text.Contains("+") || textBox2.Text.Contains("-") || textBox2.Text.Contains("*") || textBox2.Text.Contains("/")))
            {
                Getal2 = textBox1.Text;
                textBox1.Text = RekenmachineClassLibrary.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
                Getal1 = textBox1.Text;
                GetalIngevuld = false;
                Bewerking = "-";
                textBox2.Text += Getal2 + " " + Bewerking + " ";
            }

            else if (textBox2.Text.Length < 1)
            {
                Getal1 = textBox1.Text;
                GetalIngevuld = false;
                Bewerking = "-";
                textBox2.Text += Getal1 + " " + Bewerking + " ";
            }
        }

        private void ButtonMaal_Click(object sender, EventArgs e)
        {
            if (GetalIngevuld && textBox1.Text != "-" && (textBox2.Text.Contains("+") || textBox2.Text.Contains("-") || textBox2.Text.Contains("*") || textBox2.Text.Contains("/")))
            {
                Getal2 = textBox1.Text;
                textBox1.Text = RekenmachineClassLibrary.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
                Getal1 = textBox1.Text;
                GetalIngevuld = false;
                Bewerking = "*";
                textBox2.Text += Getal2 + " " + Bewerking + " ";
            }

            else if (textBox2.Text.Length < 1)
            {
                Getal1 = textBox1.Text;
                GetalIngevuld = false;
                Bewerking = "*";
                textBox2.Text += Getal1 + " " + Bewerking + " ";
            }
        }

        private void ButtonDeel_Click(object sender, EventArgs e)
        {
            if (GetalIngevuld && textBox1.Text != "-" && (textBox2.Text.Contains("+") || textBox2.Text.Contains("-") || textBox2.Text.Contains("*") || textBox2.Text.Contains("/")))
            {
                Getal2 = textBox1.Text;
                textBox1.Text = RekenmachineClassLibrary.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
                Getal1 = textBox1.Text;
                GetalIngevuld = false;
                Bewerking = "/";
                textBox2.Text += Getal2 + " " + Bewerking + " ";
            }

            else if (textBox2.Text.Length < 1)
            {
                Getal1 = textBox1.Text;
                GetalIngevuld = false;
                Bewerking = "/";
                textBox2.Text += Getal1 + " " + Bewerking + " ";
            }
        }

        private void ButtonVeranderTeken_Click(object sender, EventArgs e)
        {
            textBox1.Text  = (double.Parse(textBox1.Text) * -1).ToString();        
        }

        private void ButtonInvert_Click(object sender, EventArgs e)
        {
            textBox1.Text  = (1 / double.Parse(textBox1.Text)).ToString();
        }

        private void ButtonCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            GetalIngevuld = false;
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            Getal1 = null;
            Getal2 = null;
            GetalIngevuld = false;
            Bewerking = null;
            textBox1.Text = "0";
            textBox2.Text = "";
        }

        private void ButtonKwadraat_Click(object sender, EventArgs e)
        {
            Getal1 = textBox1.Text;
            textBox1.Text = Math.Pow(double.Parse(textBox1.Text), 2).ToString();
            listBox1.Items.Add(Getal1 + "^2 = " + textBox1.Text);
            Bewerking = null;
        }

        private void ButtonSqrt_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox1.Text) >= 0)
            {
                Getal1 = textBox1.Text;
                textBox1.Text = Math.Pow(double.Parse(textBox1.Text), 0.5).ToString();
                listBox1.Items.Add($"sqrt({Getal1}) = {textBox1.Text}");
                Bewerking = null;
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if (textBox1.Text == "" || textBox1.Text == "-")
            {
                GetalIngevuld = false;
            }
        }

        private void ButtonPercent_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text) / 100).ToString();
        }
    }
}
