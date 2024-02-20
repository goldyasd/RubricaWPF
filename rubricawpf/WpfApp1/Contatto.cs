using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Contatto
    {
        private int n;
        private string nome;
        private string cognome;

        public Contatto(string s)
        {
            string[] s1 = s.Split(';');
            n = Convert.ToInt32(s1[0]);
            nome = s1[1];
            cognome = s1[2];
        }

        public Contatto(int n) {
            this.n = n;
        }

        public Contatto(int n,string nome, string cognome)
        {
            this.n = n;
            this.nome = nome;
            this.cognome = cognome;
        }

        public int N { get  => n; set => n = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }



    }
    internal class Contatti : List<Contatto>
    {
        public Contatti() { }
        public Contatti(string nomefile)
        {
            StreamReader sr = new StreamReader(nomefile);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string stringa = sr.ReadLine();
                if (stringa.Split(';').Length == 3)
                {

                    Add(new Contatto(stringa));

                }
            }
            for (int i = base.Count + 1; i <= 100; i++)
            {
                Add(new Contatto(i));
            }
            sr.Close();
        }
    }
}
