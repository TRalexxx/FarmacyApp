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
using AppContext = PharmacyApp.Model.AppContext;

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

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(AddDrug);

                return addCommand;
            }
        }

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(DeleteDrug);

                return deleteCommand;
            }

        }

        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(UpdateDrug);

                return updateCommand;
            }
        }

        public MainVM()
        {
            using (AppContext context = new AppContext())
            {
                Drugs = new ObservableCollection<Drug>();

                List<Drug> baseUsers = context.Drugs.ToList();

                if (baseUsers != null)
                {
                    foreach (var item in baseUsers)
                    {
                        Drugs.Add(item);
                    }
                }
            }
            if (Drugs.Count > 0) SelectedDrug = Drugs[0];
        }

        public void AddDrug()
        {
            using (AppContext context = new AppContext())
            {
                context.Drugs.Add(new Drug() { Name = "enter name", Description = "enter descriprion", Photo = "ented photo url" });
                context.SaveChanges();

                Drugs.Clear();

                List<Drug> baseUsers = context.Drugs.ToList();

                if (baseUsers != null)
                {
                    foreach (var item in baseUsers)
                    {
                        Drugs.Add(item);
                    }
                }
            }            
        }

        public void UpdateDrug()
        {
            using (AppContext context = new AppContext())
            {
                context.Drugs.Update(SelectedDrug);
                context.SaveChanges();

                Drugs.Clear();

                List<Drug> baseUsers = context.Drugs.ToList();

                if (baseUsers != null)
                {
                    foreach (var item in baseUsers)
                    {
                        Drugs.Add(item);
                    }
                }
            }
        }

        public void DeleteDrug()
        {
            using (AppContext context = new AppContext())
            {
                context.Drugs.Remove(SelectedDrug);
                context.SaveChanges();

                Drugs.Clear();

                List<Drug> baseUsers = context.Drugs.ToList();

                if (baseUsers != null)
                {
                    foreach (var item in baseUsers)
                    {
                        Drugs.Add(item);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
