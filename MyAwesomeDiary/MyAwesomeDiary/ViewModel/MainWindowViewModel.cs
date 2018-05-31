using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MyAwesomeDiary.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        public ICommand OpenDiaryCommand { get; set; }
        public MainWindowViewModel()
        {
            OpenDiaryCommand = new RelayCommand<MainWindow>(p => { return true; }, p =>
            {
                p.DiaryUC.Visibility = Visibility.Visible;
            });
        }
    }
}
