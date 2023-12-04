using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comida
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private ObservableCollection<Plato> listaPlatos;
        public ObservableCollection<Plato> ListaPlatos
        {
            get { return listaPlatos; }
            set
            {
                listaPlatos = value;
                NotifyPropertyChanged("ListaPlatos");
            }
        }

        private ObservableCollection<String> tiposComida;
        public ObservableCollection<String> TiposComida
        {
            get { return tiposComida; }
            set
            {
                tiposComida = value;
                NotifyPropertyChanged("TiposComida");
            }
        }

        private Plato platoSeleccionado;      
        public Plato PlatoSeleccionado
        {
            get { return platoSeleccionado; }
            set
            {
                platoSeleccionado = value;
                NotifyPropertyChanged("PlatoSeleccionado");
            }
        }

        public MainWindowVM()
        {
            ListaPlatos = Plato.GetSamples(@"recursos\FotosPlatos");
            TiposComida = new ObservableCollection<String> { "China", "Americana", "Mejicana" }; 
        }

        public void QuitarSeleccionado()
        {
            PlatoSeleccionado = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        // Declarar método para invocar el evento.
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
