using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace MVVMWithCommands.Models
{
    class Book : INotifyPropertyChanged
    {
        private string _title;
        private string _author;
        private int _count;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnProppertyChanged("Title");
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author= value;
                OnProppertyChanged("Author");
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnProppertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnProppertyChanged([CallerMemberName]string prop = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

            //PropertyChanged?.invoke(this, new PropertyChangedEventArgs(prop))
        }
    }
}
