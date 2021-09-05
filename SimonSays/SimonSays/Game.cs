using System;

namespace SimonSays
{
    public class Game
    {
        private string playerName;
        private long score;
        private int round;
        private int timePlayedMin;
        private int timePlayedSec;
        private int timePlayedHours;
        private string gameDay;

        public string NomeGiocatore { get => playerName; set => playerName = value; }
        public long Punteggio { get => score; set => score = value; }
        public int Round { get => round; set => round = value; }
        public int DurataGiocoOre { get => timePlayedHours; set => timePlayedHours = value; }
        public int DurataGiocoMinuti { get => timePlayedMin; set => timePlayedMin = value; }
        public int DurataGiocoSecondi { get => timePlayedSec; set => timePlayedSec = value; }
        public string DataPartita { get => gameDay; set => gameDay = value; }

        public Game()
        {
            this.playerName = "";
            this.score = 0;
            this.round = 0;
            this.timePlayedMin = 0;
            this.timePlayedSec = 0;
            this.timePlayedHours = 0;
            this.gameDay = DateTime.Today.ToString("yyyy-MM-dd");
        }
        public Game(string playerName, long score, int round, int timePlayedMin, int timePlayedSec, int timePlayedHours, string gameDay)
        {
            this.playerName = playerName;
            this.score = score;
            this.round = round;
            this.timePlayedMin = timePlayedMin;
            this.timePlayedSec = timePlayedSec;
            this.timePlayedHours = timePlayedHours;
            this.gameDay = gameDay;
        }
        public string toString()
        {
            return "Nome: " + playerName + "     " + "N° Round: " + Round.ToString() + "     " + "Punteggio: " + Punteggio.ToString() + "     " + "Ore giocate: " + timePlayedHours.ToString() + "     " 
                + "Min giocati: " + timePlayedMin.ToString() + "     " + "sec giocati: " + timePlayedSec.ToString() + "     " + "Data: " + gameDay + "     ";
        }

        public string toCSV()
        {
            return playerName + ";" + Round.ToString() + ";" + Punteggio.ToString() + ";" + timePlayedHours.ToString() + ";" +
                   timePlayedMin.ToString() + ";" + timePlayedSec.ToString() + ";" + gameDay + ";";
        }
        public void fromCSV(string csv)
        {
            string[] temp = csv.Split(';');
            playerName = temp[0];
            Round = Convert.ToInt32(temp[1]);
            Punteggio = Convert.ToInt64(temp[2]);
            DurataGiocoOre = Convert.ToInt32(temp[3]);
            DurataGiocoMinuti = Convert.ToInt32(temp[4]);
            DurataGiocoSecondi = Convert.ToInt32(temp[5]);
            gameDay = temp[6];
        }
        public void fromSerialToData(string serial)
        {
            string[] s = serial.Split(';');
            round = Convert.ToInt32(s[0]);
            score = Convert.ToInt64(s[1]);
            millisToTime(Convert.ToInt64(s[2]));
            gameDay = DateTime.Today.ToString("yyyy-MM-dd");
        }
        private void millisToTime(long millis)
        {
            int mod = 0;
            int sec = (int)(millis / 1000);

            timePlayedHours = (sec / 3600);
            mod = sec % 3600;

            DurataGiocoMinuti = mod / 60;
            mod = mod % 60;

            DurataGiocoSecondi = mod;

        }
        public static void copyGame(Game original, Game copy)
        {
            copy.NomeGiocatore = original.NomeGiocatore;
            copy.Punteggio = original.Punteggio;
            copy.Round = original.Round;
            copy.DataPartita = original.DataPartita;
            copy.DurataGiocoOre = original.DurataGiocoOre;
            copy.DurataGiocoMinuti = original.DurataGiocoMinuti;
            copy.DurataGiocoSecondi = original.DurataGiocoSecondi;
        }

    }
}
