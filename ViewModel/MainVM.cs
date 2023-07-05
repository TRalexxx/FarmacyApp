using GalaSoft.MvvmLight.Command;
using PharmacyApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.ViewModel
{
    class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<Drug> Drugs { get; set; }

        private Drug selectedDrug;

        public Drug SelectedDrug
        {
            get { return selectedDrug; }
            set { selectedDrug = value; OnPropertyChanged("SelectedDrug"); }
        }

        private RelayCommand myVar;

        public RelayCommand MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
