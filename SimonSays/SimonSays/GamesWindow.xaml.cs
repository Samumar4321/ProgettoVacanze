using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SimonSays
{
    /// <summary>
    /// Logica di interazione per GamesWindow.xaml
    /// </summary>
    public partial class GamesWindow : Window
    {
        Classifica c;
        Game current;
        Gestione gest = new Gestione("ScoreBoard.txt");

        public GamesWindow()
        {
            InitializeComponent();
        }

        public GamesWindow(Classifica c, Game g)
        {
            InitializeComponent();
            this.c = c;
            this.c.defaultSort();
            current = g;


        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow(c, current);
            w.Show();
            this.Close();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            
            Classifica temp = new Classifica();
            for (int i = 0; i < c.Count; i++)
            {
                temp.Add(c[i]);
            }
            temp = gest.load();
            temp.defaultSort();
            ScoreBoard.ItemsSource = temp;
        }

        private void btnLimited_Click(object sender, RoutedEventArgs e)
        {
            ScoreBoard.ItemsSource = this.c;
        }

        private void btnEraseScoreboard_Click(object sender, RoutedEventArgs e)
        {
            gest.erase();
        }

        private void btnSaveScoreboard_Click(object sender, RoutedEventArgs e)
        {
            gest.appendElements(c);
        }

        private void btnErasetempScoreboard_Click(object sender, RoutedEventArgs e)
        {
            c.RemoveAll();

        }
    }
}
