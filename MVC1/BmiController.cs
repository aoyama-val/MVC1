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
            this.form = form;
            this.model = new BmiModel()
            {
                Height = 178,
                Weight = 76
            };
           
            this.model.HeightChanged += (sender, args) =>
            {
                var bmi = this.model.Calc();
                this.form.ShowBmi(bmi);
            };

            this.model.WeightChanged += (sender, args) =>
            {
                var bmi = this.model.Calc();
                this.form.ShowBmi(bmi);
            };

            var initialBmi = this.model.Calc();
            this.form.ShowHeight(this.model.Height);
            this.form.ShowWeight(this.model.Weight);
            this.form.ShowBmi(initialBmi);
        }

        public void OnHeightChangedByUser(Object sender, EventArgs args)
        {
            TextBox tb = (TextBox)sender;
            var strHeight = tb.Text;
            Debug.WriteLine($"height = {strHeight}");
            this.model.SetHeightByString(strHeight);
        }

        public void OnWeightChangedByUser(Object sender, EventArgs args)
        {
            TextBox tb = (TextBox)sender;
            var strWeight = tb.Text;
            Debug.WriteLine($"weight = {strWeight}");
            this.model.SetWeightByString(strWeight);
        }
    }
}
