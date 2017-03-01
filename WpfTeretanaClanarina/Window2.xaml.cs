using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfTeretanaClanarina
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        List<Clanovi> clanovi = new List<Clanovi>();
        public Window2()
        {
            InitializeComponent();
        }
        private void Osvezi()
        {
            SqlConnection SqlConn = new SqlConnection(@"Data Source=DESKTOP-3QT4TNV\SQLEXPRESS;Initial Catalog=Teretana;Integrated Security=True");
            SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_ListaAktivnihClanova", SqlConn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                Clanovi cl = new Clanovi();
                //int AktivnaClanarinaId = read.GetInt32(0);
                string Ime = read.GetString(0);
                string Prezime = read.GetString(1);
                DateTime VremeDo = read.GetDateTime(2);

                //cl.AktivnaClanarinaId = AktivnaClanarinaId;
                cl.Ime = Ime;
                cl.Prezime = Prezime;
                cl.VremeDo = VremeDo;

                clanovi.Add(cl);
            }
            SqlConn.Close();
            listView.ItemsSource = null;
            listView.ItemsSource = clanovi;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Osvezi();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clanovi item = (Clanovi)listView.SelectedItem;
            textBoxIme.Text = item.Ime;
            textBoxPrezime.Text = item.Prezime;
            textBoxVremeDo.Text = item.VremeDo.ToShortDateString();
        }

        private void buttonNazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            Close();
            m.ShowDialog();
        }
    }
}
