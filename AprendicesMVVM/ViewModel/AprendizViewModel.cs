

namespace AprendicesMVVM.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading.Tasks;
    using AprendicesMVVM.Model;
    using DemoMVVMAprendices.Model;
    using Model.Services;
    using Xamarin.Forms;

    public class AprendizViewModel:Notificable
    {
        private ObservableCollection<Aprendiz> aprendices;
        public ObservableCollection<Aprendiz> Aprendices
        {
            get { return aprendices; }
            set
            {
                if(aprendices == value)
                {
                    return;
                }
                aprendices = value;
                OnPropertyChanged();
            }
        }

        public Command CargarAprendizCommand { get; set; }

        private bool isEnabled;

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if(isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
                OnPropertyChanged();
            }
        }
        public AprendizViewModel()
        {
            Aprendices = new ObservableCollection<Aprendiz>();
            CargarAprendizCommand = new Command((obj) => CargarAprendices());
        }

        private async void CargarAprendices()
        {
            if (!IsEnabled)
            {
                IsEnabled = true;
                await Task.Delay(3000);
                Data listAprendices = CaracterizacionAprendices.CargarAprendices();
                Aprendices = listAprendices.Aprendices;
                IsEnabled = false;
            }
        }
    }
}
