using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    using Accessibility;
    using System;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persone persone;
        Contatti contatti;
        public MainWindow()
        {
            InitializeComponent();

            /*Considerando che potrebbe servirci spostare il codice su altre interfacce come Maui, ho inserito
            un metodo Start() che richiama le operazioni da eseguire a inizio file, in modo da poter spostare
            facilmente il metodo Start() in un'altra interfaccia*/
            Start();
        }

        private void Start()
        {
            try
            {
                persone = new Persone("Persona.csv");
                contatti = new Contatti("dati.csv");
                dg.ItemsSource = contatti;
                dg1.ItemsSource = new Persone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dg_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Contatto c = e.Row.Item as Contatto;
            if (c.Nome == null && c.Cognome == null)
            {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.White;
            }
        }

        private void dg1_LoadingRow(object sender, SelectionChangedEventArgs e)
        {
            Contatto pe = e.AddedItems[0] as Contatto;
            Persone list = new Persone();
            foreach(Persona p in persone)
            {
                try
                {
                    if (p.IdPersona == pe.N)
                    {
                        list.Add(p);
                    }
                }
                catch { }
                
            }
            dg1.ItemsSource = list;
        }
    }
}
