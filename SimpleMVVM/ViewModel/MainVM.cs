using SimpleMVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVVM.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) 
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int _number1;
        public int Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                OnPropertyChanged("Number3"); // уведомление View о том, что изменилась сумма
            }
        }

        private int _number2;
        public int Number2
        {
            get { return _number2; }
            set 
            { 
                _number2 = value; 
                OnPropertyChanged("Number3"); 
            }
        }

        public int Number3
        {
            get
            {
                return MathFuncs.GetSumOf(Number1, Number2);
            }
        }
    }
}
