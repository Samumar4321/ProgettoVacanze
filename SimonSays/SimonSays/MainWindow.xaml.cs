using System;
using System.Collections.Generic;
using System.IO.Ports;
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


namespace SimonSays
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort COM;
        Classifica scoreboard;
        bool status = false;
        Game current;
        public MainWindow()
        {
            InitializeComponent();
            scoreboard = new Classifica();
            string[] ports = SerialPort.GetPortNames();
            comboBoxCOM.ItemsSource = ports;
            current = new Game();

        }

        public MainWindow(Classifica c, Game g)
        {
            InitializeComponent();
            scoreboard = c;
            current = g;
        }

        private void COM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string serial = COM.ReadTo("-");
            current.fromSerialToData(serial);
            status = true;

        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            GamesWindow s = new GamesWindow(scoreboard, current);
            s.Show();
            this.Close();
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            current.NomeGiocatore = txtName.Text;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Game temp = new Game();
            Game.copyGame(current, temp);
            scoreboard.Add(temp);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (status)
            {
                loadingImg.Visibility = Visibility.Hidden;
                lblName.IsEnabled = true;
                lblName.Visibility = Visibility.Visible;
                lblName.Content = "Nome: ";
                btnName.IsEnabled = true;
                btnName.Visibility = Visibility.Visible;

                txtName.IsEnabled = true;
                txtName.Visibility = Visibility.Visible;
                txtName.Text = current.NomeGiocatore;

                lblScore.IsEnabled = true;
                lblScore.Visibility = Visibility.Visible;
                lblScore.Content = "Punti: " + current.Punteggio;

                lblRound.IsEnabled = true;
                lblRound.Visibility = Visibility.Visible;
                lblRound.Content = "Round: " + current.Round;

                lblDate.IsEnabled = true;
                lblDate.Visibility = Visibility.Visible;
                lblDate.Content = "Data: " + current.DataPartita;

                lblHour.IsEnabled = true;
                lblHour.Visibility = Visibility.Visible;
                lblHour.Content = "Durata ore: " + current.DurataGiocoOre;

                lblMin.IsEnabled = true;
                lblMin.Visibility = Visibility.Visible;
                lblMin.Content = "Durata minuti: " + current.DurataGiocoMinuti;

                lblSec.IsEnabled = true;
                lblSec.Visibility = Visibility.Visible;
                lblSec.Content = "Durata secondi: " + current.DurataGiocoSecondi;

                btnAdd.IsEnabled = true;
                btnAdd.Visibility = Visibility.Visible;
                status = false;
            }
        }


        private void comboBoxCOM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string port = (string)comboBoxCOM.SelectedItem;
            COM = new SerialPort(port, 9600);
            COM.DataReceived += COM_DataReceived;
            COM.Open();
        }
    }
}