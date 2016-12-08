using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MVC1
{
    public class BmiModel : INotifyPropertyChanged
    {
        double height;
        double weight;
        double bmi;
        public double Height { get { return this.height; } set { this.height = value; NotifyPropertyChanged(); } }
        public double Weight { get { return this.weight; } set { this.weight = value; NotifyPropertyChanged(); } }
        public double Bmi { get { return this.bmi; } set { this.bmi = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                Debug.WriteLine("fire PropertyChanged");
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Calc()
        {
            this.Bmi = this.Weight / (this.Height * this.Height / 10000.0);
        }
    }
}
