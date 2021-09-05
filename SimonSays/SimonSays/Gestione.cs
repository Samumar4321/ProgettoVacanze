using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSays
{
    class Gestione
    {
        private string fileName;
        public Gestione(string n)
        {
            fileName = n;
        }
        public bool save(Classifica l)
        {
            string temp = "";
            temp = l.toCSV();
            saveAllString(temp);
            return true;
        }
        public bool appendElement(Game abb)
        {
            string temp = "";
            temp = abb.toCSV() + "\n";
            saveAppend(temp);
            return true;
        }
        public bool appendElements(Classifica temp)
        {
            string t = temp.toCSV();
            saveAppend(t);
            return true;
        }

        public Classifica load()
        {
            string temp = "";
            Classifica l = new Classifica();
            using (StreamReader st = File.OpenText(fileName))
            {
                while ((temp = st.ReadLine()) != null)
                {
                    Game abb = new Game();
                    abb.fromCSV(temp);
                    l.Add(abb);
                }
            }
            return l;
        }

        public void saveAllString(string s)
        {
            File.WriteAllText(fileName, s);
        }
        public void saveAppend(string e)
        {
            File.AppendAllText(fileName, e);
        }

        public string readAllString()
        {
            string s = File.ReadAllText(fileName);
            return s;
        }
        public void erase()
        {
            File.WriteAllText(fileName, "");
        }
    }
}
