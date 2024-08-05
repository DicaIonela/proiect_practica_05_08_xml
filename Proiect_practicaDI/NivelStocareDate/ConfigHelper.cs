using LibrarieClase;
using Proiect_practicaDI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace NivelStocareDate
{
    public class ConfigHelper
    {
        private const int NR_MAX = 50;
        private string numeFisier;
        public static Utilizator[] GetUtilizatori()
        {
            NameValueCollection utilizatoriSection = (NameValueCollection)ConfigurationManager.GetSection("utilizatoriSection");
            Utilizator[] utilizatori = new Utilizator[utilizatoriSection.Count];
            int index = 0;
            foreach (string key in utilizatoriSection)
            {
                string[] values = utilizatoriSection[key].Split(';');
                utilizatori[index++] = new Utilizator
                {
                    Nume = key,
                    Numar = values[0],
                    AdresaMAC = values[1]
                };
            }
            return utilizatori;
        }
        public static Utilizator[] CautaUtilizator(string criteriu)
        {
            //int nrUtilizatori = 0;
            Utilizator[] utilizatori = GetUtilizatori();
            List<Utilizator> utilizatorigasiti = new List<Utilizator>();/*se creeaza o lista pentru utilizatorii gasiti*/
            foreach (Utilizator utilizator in utilizatori)/*se parcurge tabloul de obiecte*/
            {
                if (utilizator != null && (utilizator.Nume.Contains(criteriu) || (utilizator.Numar.Contains(criteriu))))/*se verifica daca numele contine caracterele introduse/numarul*/
                {
                    utilizatorigasiti.Add(utilizator);/*daca numele a indeplinit conditia, se va adauga obiectul la lista de utilizatori gasiti*/
                }
            }
            return utilizatorigasiti.ToArray();
        }
        public static TestBench[] Gettb()
        {
            NameValueCollection tbSection = (NameValueCollection)ConfigurationManager.GetSection("testBenchSection");
            TestBench[] testBenchuri = new TestBench[tbSection.Count];
            int index = 0;
            foreach (string key in tbSection)
            {
                testBenchuri[index++] = new TestBench
                {
                    Tb = key,
                    AdresaMAC = tbSection[key]
                };
            }
            return testBenchuri;
        }
        public static TestBench[] CautaTB(string criteriu)
        {
            TestBench[] testBenchuri = Gettb();
            List<TestBench> tbgasite = new List<TestBench>();/*se creeaza o lista pentru TB-URILE gasiti*/
            foreach (TestBench testBench in testBenchuri)/*se parcurge tabloul de obiecte*/
            {
                if (testBench.Tb.Trim().Equals(criteriu.Trim(), StringComparison.OrdinalIgnoreCase))/*se verifica daca numele contine caracterele introduse*/
                {
                    tbgasite.Add(testBench);/*daca numele a indeplinit conditia, se va adauga obiectul la lista de TB-URI gasite*/
                }
            }
            return tbgasite.ToArray();
        }
    }
}

