using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC1
{
    class BmiModel
    {
        double height;
        double weight;
        public double Height { get { return this.height; } set { this.height = value; if (this.HeightChanged != null) { this.HeightChanged(this, null); } } }
        public double Weight { get { return this.weight; } set { this.weight = value; if (this.WeightChanged != null) { this.WeightChanged(this, null); } } }
        public event EventHandler HeightChanged;
        public event EventHandler WeightChanged;

        public void SetHeightByString(string strHeight)
        {
            double height;
            if (double.TryParse(strHeight, out height))
            {
                this.Height = height;
            }
        }

        public void SetWeightByString(string strWeight)
        {
            double weight;
            if (double.TryParse(strWeight, out weight))
            {
                this.Weight = weight;
            }
        }

        public double Calc()
        {
            var result = this.Weight / (this.Height * this.Height / 10000.0);
            return result;
        }
    }
}
