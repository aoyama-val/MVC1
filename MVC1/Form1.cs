using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MVC1
{
    public partial class Form1 : Form
    {
        BmiController controller;

        public Form1()
        {
            InitializeComponent();

            this.controller = new BmiController(this);

            this.txtHeight.TextChanged += new EventHandler(this.controller.OnHeightChangedByUser);
            this.txtWeight.TextChanged += new EventHandler(this.controller.OnWeightChangedByUser);
        }

        public void ShowHeight(double height)
        {
            this.txtHeight.Text = height.ToString("F2");
        }

        public void ShowWeight(double weight)
        {
            this.txtWeight.Text = weight.ToString("F2");
        }

        public void ShowBmi(double bmi)
        {
            this.txtBmi.Text = bmi.ToString("F2");
            if (bmi >= 26)
                this.txtBmi.BackColor = Color.Red;
            else if (bmi >= 23)
                this.txtBmi.BackColor = Color.Yellow;
            else
                this.txtBmi.BackColor = Color.LawnGreen;
        }
    }
}
