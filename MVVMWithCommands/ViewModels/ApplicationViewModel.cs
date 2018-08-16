using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MVVMWithCommands.Models;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MVVMWithCommands.Commands;

namespace MVVMWithCommands.ViewModels
{
    class ApplicationViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Book> _books = new ObservableCollection<Book>();
        public ObservableCollection<Book> Books
        {
            get
            {
                return _books;
            }
        }

        private Book _selectedBook;

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set {
                _selectedBook = value;
                OnProppertyChanged();
            }
        }

        private DelegateCommand _addCommand;

        public DelegateCommand AddCommand
        {
            get
            {
                if(_addCommand == null)
                {
                    _addCommand = new DelegateCommand(
                        obj => {
                            Book b = new Book();
                            Books.Insert(0, b);
                            SelectedBook = b;
                        }
                        );
                }
                return _addCommand;
                    
            }
        }
        

        public ApplicationViewModel()
        {
            InitBooks();
        }
        private void InitBooks()
        {
            _books.Add(new Book { Title = "C#", Author="Richter", Count=15});
            _books.Add(new Book { Title = "C++", Author = "Deitel", Count = 10 });
            _books.Add(new Book { Title = "Html", Author = "Ktoto", Count = 25 });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnProppertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

            //PropertyChanged?.invoke(this, new PropertyChangedEventArgs(prop))
        }
    }
}
