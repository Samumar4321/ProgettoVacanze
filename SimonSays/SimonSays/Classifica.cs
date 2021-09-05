using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSays
{
    public class Classifica : List<Game>
    {
        public Classifica()
        {

        }
        public void defaultSort()
        {
            Game temp;
            for (int j = 0; j < this.Count; j++)
            {
                for (int i = 0; i < this.Count-1; i++)
                {
                    if (this.ElementAt(i).Punteggio < this.ElementAt(i+1).Punteggio)
                    {
                        temp = this[i + 1];
                        this[i + 1] = this[i];
                        this[i] = temp;
                    }                    
                }
            }
        }        
        public void RemoveAll()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                this.RemoveAt(i);
            }
        }
        public string toCSV()
        {
            string s = "";
            for (int i = 0; i < this.Count; i++)
            {
                s += this[i].toCSV() + "\n";                
            }
            return s;
        }
        public string toString()
        {
            string s = "";
            for (int i = 0; i < this.Count; i++)
            {
                s += this[i].toString() + "\n";
            }
            return s;
        }
    }
}
