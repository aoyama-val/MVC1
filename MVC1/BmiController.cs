using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC1
{
    class BmiController
    {
        Form1 form;
        BmiModel model;

        public BmiController(Form1 form)
        {
            this.model = new BmiModel();

            this.form = form;
            this.form.TxtHeight.TextChanged += this.OnHeightChangedByUser;
            this.form.TxtWeight.TextChanged += this.OnWeightChangedByUser;

            this.form.Model = this.model;

            this.model.Height = 178;
            this.model.Weight = 76;
            this.model.Calc();
        }

        public void OnHeightChangedByUser(Object sender, EventArgs args)
        {
            TextBox tb = (TextBox)sender;
            var strHeight = tb.Text;
            Debug.WriteLine($"height = {strHeight}");

            double height;
            if (double.TryParse(strHeight, out height))
            {
                this.model.Height = height;
            }
            this.model.Calc();
        }

        public void OnWeightChangedByUser(Object sender, EventArgs args)
        {
            TextBox tb = (TextBox)sender;
            var strWeight = tb.Text;
            Debug.WriteLine($"weight = {strWeight}");

            double weight;
            if (double.TryParse(strWeight, out weight))
            {
                this.model.Weight = weight;
            }
            this.model.Calc();
        }
    }
}
