using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace YandexTranslator
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public AppViewModel() 
        {
        }
        private string input_s;
        private string output_s;
        private string selectedInputL = "Russian";
        private string selectedOutputL = "English";
        private RelayCommand command;
        private RelayCommand clearCommand;
        private RelayCommand reverseCommand;
        public string Input_s
        {
            get
            {
                return this.input_s;
            }
            set
            {
                input_s = value;
                OnPropertyChanged(nameof(Input_s));
            }
        }
        public string Output_s
        {
            get
            {
                return this.output_s;
            }
            set
            {
                output_s = value;
                OnPropertyChanged(nameof(Output_s));
            }
        }
        public string SelectedOutputL
        {
            get
            {
                return selectedOutputL;
            }
            set
            {
                selectedOutputL = value;
                OnPropertyChanged(nameof(SelectedOutputL));
            }
        }
        public string SelectedInputL
        {
            get
            {
                return selectedInputL;
            }
            set
            {
                selectedInputL = value;
                OnPropertyChanged(nameof(SelectedInputL));
            }
        }
        public List<string> OutputLang
        {
            get
            {
                return new List<string>
                {
                    "English",
                    "Russian"
                };
            }
        }
        public List<string> InputLang
        {
            get
            {
                return new List<string>
                {
                    "English",
                    "Russian"
                };
            }
        }
        public List<string> Code
        {
            get
            {
                return new List<string>
                {
                    "en",
                    "ru"
                };
            }
        }
        public string GetLang()
        {
            return Code.ElementAt(InputLang.IndexOf(selectedInputL)) + "-" + Code.ElementAt(InputLang.IndexOf(selectedOutputL));
        }
        public RelayCommand AddCommand
        {
            get
            {
                if (command == null)
                {
                    command = new RelayCommand(() => {
                        Console.WriteLine(input_s);
                        YandexTranslate yt = new YandexTranslate();
                        Output_s = yt.Translate_(input_s, GetLang());
                    });
                }
                return command;
            }
        }
        public RelayCommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(() => {
                        Output_s = "";
                        Input_s = "";
                    });
                }
                return clearCommand;
            }
        }
        public RelayCommand ReverseCommand
        {
            get
            {
                if (reverseCommand == null)
                {
                    reverseCommand = new RelayCommand(() => {
                        string s = SelectedInputL;
                        SelectedInputL = SelectedOutputL;
                        SelectedOutputL = s;
                    });
                }
                return reverseCommand;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
