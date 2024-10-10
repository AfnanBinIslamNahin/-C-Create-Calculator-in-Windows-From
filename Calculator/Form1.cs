using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        //Fields
        Double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (txtdisplay1.Text == "0" || enterValue) txtdisplay1.Text = string.Empty;
            enterValue = false;
           Button button =  (Button)sender;
            if (button.Text == ".") 
            {
                if (!txtdisplay1.Text.Contains("."))
                    txtdisplay1.Text = txtdisplay1.Text + button.Text;
            }
            else txtdisplay1.Text = txtdisplay1.Text + button.Text;

        }

        private void BtnMathOperation_click(object sender, EventArgs e)
        {
            if (result != 0) button28.PerformClick();
            else result = Double.Parse(txtdisplay1.Text);
            Button button = (Button)sender;
            operation = button.Text;
            enterValue = true;
            if (txtdisplay1.Text != "0")
            {
                txtdisplay2.Text = fstNum = $"{result}{operation}";
                txtdisplay1.Text = string.Empty;
            } 

        }

        private void button28_Click(object sender, EventArgs e)
        {
            secNum = txtdisplay1.Text;
            txtdisplay2.Text =$"{ txtdisplay2.Text} { txtdisplay1.Text}=";
            if (txtdisplay1.Text != string.Empty)
            {
                if (txtdisplay1.Text == "0") txtdisplay2.Text = string.Empty;
                switch(operation)
                {
                    case "+":
                        txtdisplay1.Text = (result + Double.Parse(txtdisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={txtdisplay1.Text}\n");
                        break;
                    case "-":
                        txtdisplay1.Text = (result - Double.Parse(txtdisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={txtdisplay1.Text}\n");

                        break;
                    case "x":
                        txtdisplay1.Text = (result * Double.Parse(txtdisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={txtdisplay1.Text}\n");

                        break;
                    case "/":
                        txtdisplay1.Text = (result / Double.Parse(txtdisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={txtdisplay1.Text}\n");

                        break;
                    default:
                        txtdisplay2.Text = $"{txtdisplay1.Text}";
                        break;
                }
                result = Double.Parse(txtdisplay1.Text);
                operation = string.Empty;


            }
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            PnlHistory.Height = (PnlHistory.Height == 5) ? PnlHistory.Height = 345 : 5;

        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            RtBoxDisplayHistory.Clear();
            if (RtBoxDisplayHistory.Text == string.Empty)
                RtBoxDisplayHistory.Text = "There is no history yet";

        }

        private void RtBoxDisplayHistory_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtdisplay1.Text = "0";
            txtdisplay2.Text = string.Empty;
            result = 0;


        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtdisplay1.Text = "0";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtdisplay1.Text.Length > 0)
                txtdisplay1.Text = txtdisplay1.Text.Remove(txtdisplay1.Text.Length - 1, 1);
            if (txtdisplay1.Text == string.Empty) txtdisplay1.Text = "0";
        }

        private void BtnOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            switch (operation)
            {
                case "√":
                    txtdisplay2.Text = $"√({txtdisplay1.Text})";
                    txtdisplay1.Text = Convert.ToString(Math.Sqrt(Double.Parse(txtdisplay1.Text)));
                    break;
                case "^2":
                    txtdisplay2.Text = $"({txtdisplay1.Text})^2";
                    txtdisplay1.Text = Convert.ToString(Convert.ToDouble(txtdisplay1.Text)* Convert.ToDouble(txtdisplay1.Text));
                    break;
                case "1/x":
                    txtdisplay2.Text = $"1/({txtdisplay1.Text})";
                    txtdisplay1.Text = Convert.ToString(1.0/ Convert.ToDouble(txtdisplay1.Text));
                    break;
                case "%":
                    txtdisplay2.Text = $"%({txtdisplay1.Text})";
                    txtdisplay1.Text = Convert.ToString( Convert.ToDouble(txtdisplay1.Text)/ Convert.ToDouble(100));

                    break;
                case "'":
                 
                    txtdisplay1.Text = Convert.ToString(-1*Convert.ToDouble(txtdisplay1.Text));
                    break;


            }
            RtBoxDisplayHistory.AppendText($"{txtdisplay2.Text}={txtdisplay1.Text}\n");

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void txtdisplay1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
