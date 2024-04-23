using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using vipief.Model;
using vipief.View;
using vipief.ViewModel.Helpers;

namespace vipief.ViewModel
{
    internal class MainViewModel : BindingHelper
    {

        #region

        public BindableCommand AddCommand { get; set; }

        public BindableCommand NextWindow { get; set; }

        #endregion


        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private string _selectedItem1;
        public string SelectedItem1
        {
            get { return _selectedItem1; }
            set
            {
                _selectedItem1 = value;
                OnPropertyChanged();
            }
        }

        private string _amountVvod;
        public string AmountVvod
        {
            get { return _amountVvod; }
            set
            {
                _amountVvod = value;
                OnPropertyChanged();
            }
        }

        private string _amountVivod;
        public string AmountVivod
        {
            get { return _amountVivod; }
            set
            {
                _amountVivod = value;
                OnPropertyChanged(nameof(AmountVivod));
            }
        }


        private ObservableCollection<Value> values;
        public ObservableCollection<Value> Values
        {
            get { return values; }
            set
            {
                values = value;
                OnPropertyChanged();
            }
        }

        public void Next()
        {
            FIRSTZAGLUSKA fIRSTZAGLUSKA = new FIRSTZAGLUSKA();
            fIRSTZAGLUSKA.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainWindow)
                {
                    window.Close();
                    break;
                }
            }
            
        }


        public MainViewModel()
        {
            AddCommand = new BindableCommand(_ => Converter());
            NextWindow = new BindableCommand(_ => Next());

            Values = new ObservableCollection<Value>()
            { 
                new Value("RUB"),
                new Value("USD"),
                new Value("EUR"),
            };
        }

        public void Converter()
        {
            if (SelectedItem == "RUB" && SelectedItem1 == "USD") 
            {
                double vvod = Convert.ToDouble(AmountVvod);

                AmountVivod = Convert.ToString(vvod * 93);
                
            }
            else if (SelectedItem == "RUB" && SelectedItem1 == "EUR")
            {
                double vvod = Convert.ToDouble(AmountVvod);

                AmountVivod = Convert.ToString(vvod * 99);
            }
            else if (SelectedItem == "USD" && SelectedItem1 == "RUB")
            {
                double vvod = Convert.ToDouble(AmountVvod);

                AmountVivod = Convert.ToString(vvod * 93);
            }
            else if (SelectedItem == "USD" && SelectedItem1 == "EUR")
            {
                double vvod = Convert.ToDouble(AmountVvod);

                AmountVivod = Convert.ToString(vvod * 0.94);
            }
            else if (SelectedItem == "EUR" && SelectedItem1 == "RUB")
            {
                double vvod = Convert.ToDouble(AmountVvod);

                AmountVivod = Convert.ToString(vvod * 99);
            }
            else if (SelectedItem == "EUR" && SelectedItem1 == "USD")
            {
                double vvod = Convert.ToDouble(AmountVvod);

                AmountVivod = Convert.ToString(vvod * 1.07);
            }
            else if (SelectedItem == SelectedItem1)
            {
                AmountVivod = AmountVvod;
            }
        }
    }
}
