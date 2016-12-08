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
        BmiModel model;

        public TextBox TxtHeight { get { return this.txtHeight; } }
        public TextBox TxtWeight { get { return this.txtWeight; } }
        public TextBox TxtBmi { get { return this.txtBmi; } }

        public Form1()
        {
            InitializeComponent();
            this.controller = new BmiController(this);
        }

        public BmiModel Model
        {
            get { return this.model; }
            set
            {
                this.model = value;
                this.model.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "Height")
                    {
                        Debug.WriteLine("Height changed");
                        double d;
                        if (!(double.TryParse(this.txtHeight.Text, out d) && d == this.model.Height))
                            this.txtHeight.Text = this.model.Height.ToString("F2");
                    }
                    else if (args.PropertyName == "Weight")
                    {
                        Debug.WriteLine("Weight changed");
                        double d;
                        if (!(double.TryParse(this.txtWeight.Text, out d) && d == this.model.Weight))
                            this.txtWeight.Text = this.model.Weight.ToString("F2");
                    }
                    else if (args.PropertyName == "Bmi")
                    {
                        Debug.WriteLine("Bmi changed");
                        this.ShowBmi(this.model.Bmi);
                    }
                };
            }
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
