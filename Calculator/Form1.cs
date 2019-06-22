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
    /// <summary>
    /// Coded by Taylan Alp 'SatanJager' Mühür for educational purposes.
    /// </summary>
    public partial class Form1 : Form
    {

        double resultValue = 0;
        string operationPerformed = "";

        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((txtSonuc.Text == "0") || (isOperationPerformed))
            {
                txtSonuc.Clear();
            }

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ",")
            {
                if (!txtSonuc.Text.Contains(","))
                {
                    txtSonuc.Text = txtSonuc.Text + button.Text;
                }
            }
            else
            {
                txtSonuc.Text = txtSonuc.Text + button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnEqual.PerformClick();
                operationPerformed = button.Text;
                lblSonuc.Text = resultValue + "" + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(txtSonuc.Text);
                lblSonuc.Text = resultValue + "" + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "0";
            lblSonuc.Text = "";
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "0";
            lblSonuc.Text = "";
            resultValue = 0;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    txtSonuc.Text = (resultValue + double.Parse(txtSonuc.Text)).ToString();
                    break;
                case "-":
                    txtSonuc.Text = (resultValue - double.Parse(txtSonuc.Text)).ToString();
                    break;
                case "*":
                    txtSonuc.Text = (resultValue * double.Parse(txtSonuc.Text)).ToString();
                    break;
                case "/":
                    txtSonuc.Text = (resultValue / double.Parse(txtSonuc.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(txtSonuc.Text);
            lblSonuc.Text = "";
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coded by Taylan Alp 'SatanJager' Mühür for educational purposes.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( "Programı kapamak mı istiyorsunuz?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
