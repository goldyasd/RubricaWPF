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
        List<Persona> persone = new List<Persona>();
        public MainWindow()
        {
            InitializeComponent();

            List<Contatto> contatti = new List<Contatto>();
            
            StreamReader sr = new StreamReader("dati.csv");
            StreamReader sr1 = new StreamReader("Persona.csv");
            sr1.ReadLine();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string stringa = sr.ReadLine(); 
                if(stringa.Split(';').Length == 3)
                {
                    
                    contatti.Add(new Contatto(stringa));

                }
            }
            for(int i = contatti.Count + 1; i <= 100; i++)
            {
                    contatti.Add(new Contatto(i));
            }
            while (!sr1.EndOfStream)
            {
                string s = sr1.ReadLine();
                persone.Add(new Persona(Convert.ToInt32(s.Split(';')[0]), Enum.Parse<Type>(s.Split(';')[1]), s.Split(';')[2]));
            }
            dg.ItemsSource = contatti;
            dg1.ItemsSource = new List<Persona>();

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
            List<Persona> list = new List<Persona>();
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
