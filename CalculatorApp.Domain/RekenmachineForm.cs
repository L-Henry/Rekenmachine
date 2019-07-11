using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp.WinForms
{
    public partial class RekenmachineForm : Form
    {
        public bool GetalIngevuld { get; set; }
        public bool GetalIngevuldParserPanel { get; set; }
        public string Bewerking { get; set; }
        public string Getal1 { get; set; }
        public string Getal2 { get; set; }

        public RekenmachineForm()
        {
            InitializeComponent();
        }

        private void RekenmachineForm_Load(object sender, EventArgs e)
        {
            panelParser.Visible = false;
            textBox1.Text = "0";
            comboBox.SelectedIndex = 0;

            this.Size = new Size(650, 550);
            this.MinimumSize = Size;
            this.MaximumSize = Size;

            button0.Click += Button_Click;
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
            button4.Click += Button_Click;
            button5.Click += Button_Click;
            button6.Click += Button_Click;
            button7.Click += Button_Click;
            button8.Click += Button_Click;
            button9.Click += Button_Click;
            buttonP0.Click += ButtonP_Click;
            buttonP1.Click += ButtonP_Click;
            buttonP2.Click += ButtonP_Click;
            buttonP3.Click += ButtonP_Click;
            buttonP4.Click += ButtonP_Click;
            buttonP5.Click += ButtonP_Click;
            buttonP6.Click += ButtonP_Click;
            buttonP7.Click += ButtonP_Click;
            buttonP8.Click += ButtonP_Click;
            buttonP9.Click += ButtonP_Click;

        }

        // Panel beheer
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                if (panelParser.Visible)
                {
                    panelParser.Visible = false;
                    panelKlassiek.Visible = true;
                    textBox1.Text = "0";
                    GetalIngevuld = false;
                }
            }
            else if (comboBox.SelectedIndex == 1)
            {
                if (panelKlassiek.Visible)
                {
                    panelKlassiek.Visible = false;
                    panelParser.Location = new Point(12, 60);
                    panelParser.Visible = true;
                    textBoxP1.Text = "0";
                    GetalIngevuldParserPanel = false;
                }
            }
        }

        //panelKlassiek
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (!GetalIngevuld && (Bewerking == "invert"))
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (!GetalIngevuld)
            {
                textBox1.Text = "";
            }
            textBox1.Text += button.Text;
            GetalIngevuld = true;
        }

        private void ButtonIs_Click(object sender, EventArgs e)
        {
            if (Bewerking == "invert")
            {
                listBox1.Items.Add(textBox2.Text + " = " + textBox1.Text);
                Bewerking = null;
            }
            else if (Bewerking == null)
            {
                Getal1 = textBox1.Text;
                listBox1.Items.Add(Getal1 + " = " + Getal1);
            }
            else if (GetalIngevuld && textBox1.Text != "-")
            {
                Getal2 = textBox1.Text;
                GetalIngevuld = false;
                textBox1.Text = CalculatorApp.Library.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
                textBox2.Text += " " + Getal2 + " = " + textBox1.Text;
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = "";
            }
            else if (textBox1.Text.Any(c => char.IsDigit(c)) && textBox1.Text != "-")
            {
                Getal1 = textBox1.Text;
                textBox1.Text = CalculatorApp.Library.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
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
                textBox1.Text = CalculatorApp.Library.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
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
                textBox1.Text = CalculatorApp.Library.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
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
                textBox1.Text = CalculatorApp.Library.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
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
                textBox1.Text = CalculatorApp.Library.BerekenClass.Bereken(double.Parse(Getal1), double.Parse(Getal2), Bewerking).ToString();
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
            if (textBox2.Text.Length < 1)
            {
                Getal1 = textBox1.Text;
                textBox1.Text = (1 / double.Parse(textBox1.Text)).ToString();
                textBox2.Text += "1/(" + Getal1 + ")";
                //GetalIngevuld = false;
            }
            else
            {
                Getal1 = textBox1.Text;
                textBox1.Text = (1 / double.Parse(textBox1.Text)).ToString();
                textBox2.Text += "1/(" + Getal1 + ")";
                //GetalIngevuld = true;
            }
            Bewerking = "invert";
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

        //Parser rekenmachine
        private void ButtonP_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (!GetalIngevuldParserPanel)
            {
                textBoxP1.Text = "";
            }
            textBoxP1.Text += button.Text;
            GetalIngevuldParserPanel = true;
        }

        private void ButtonOpenHaakje_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuldParserPanel)
            {
                textBoxP1.Text = "";
            }
            GetalIngevuldParserPanel = true;
            textBoxP1.Text += "(";
        }

        private void ButtonSluitHaakje_Click(object sender, EventArgs e)
        {
            if (!GetalIngevuldParserPanel)
            {
                textBoxP1.Text = "";
            }
            GetalIngevuldParserPanel = true;
            textBoxP1.Text += ")";
        }

        private void ButtonPDeel_Click(object sender, EventArgs e)
        {
            if (GetalIngevuldParserPanel)
            {
                textBoxP1.Text += "/";
            }
        }

        private void ButtonPMaal_Click(object sender, EventArgs e)
        {
            if (GetalIngevuldParserPanel)
            {
                textBoxP1.Text += "*";
            }
        }

        private void ButtonPMin_Click(object sender, EventArgs e)
        {
            if (GetalIngevuldParserPanel)
            {
                textBoxP1.Text += "-";
            }
        }

        private void ButtonPPlus_Click(object sender, EventArgs e)
        {
            if (GetalIngevuldParserPanel)
            {
                textBoxP1.Text += "+";
            }
        }

        private void ButtonPSqr_Click(object sender, EventArgs e)
        {
            if (GetalIngevuldParserPanel)
            {
                textBoxP1.Text += "^2";
            }
        }

        private void ButtonPSqrt_Click(object sender, EventArgs e)
        {
            if (GetalIngevuldParserPanel)
            {
                textBoxP1.Text += "^0,5";
            }
        }

        private void ButtonPDel_Click(object sender, EventArgs e)
        {
            textBoxP1.Text = textBoxP1.Text.Substring(0, textBoxP1.Text.Length - 1);
            if (textBoxP1.Text == "" || textBoxP1.Text == "-")
            {
                GetalIngevuldParserPanel = false;
            }
        }

        private void ButtonPComma_Click(object sender, EventArgs e)
        {
                textBoxP1.Text += ",";
        }

        private void ButtonPCE_Click(object sender, EventArgs e)
        {
            textBoxP1.Text = "0";
            textBoxP2.Text = "";
            GetalIngevuldParserPanel = false;
        }

        private void ButtonPInvert_Click(object sender, EventArgs e)
        {
            if (GetalIngevuldParserPanel)
            {
                textBoxP1.Text = "1/(" + textBoxP1.Text + ")";
            }
        }

        private void ButtonPTeken_Click(object sender, EventArgs e)
        {
            if (GetalIngevuldParserPanel)
            {
                textBoxP1.Text = "-(" + textBoxP1.Text + ")";
            }
        }

        private void ButtonPIs_Click(object sender, EventArgs e)
        {
            textBoxP2.Text = textBoxP1.Text;
            textBoxP1.Text = CalculatorApp.Library.MijnParserRekenmachine.Bereken(textBoxP1.Text).ToString();
            listBox1.Items.Add(textBoxP2.Text + " = " + textBoxP1.Text);
        }

        private void ButtonClearHistory_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }


    }
}
