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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        List<Clanovi> clanovi = new List<Clanovi>();
        public Window3()
        {
            InitializeComponent();
        }

        private void buttonNazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            Close();
            m.ShowDialog();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Clanovi items = (Clanovi)listView.SelectedItem;
                textBoxIme.Text = items.Ime;
                textBoxPrezime.Text = items.Prezime;
                textBoxVremeDo.Text = items.VremeDo.ToShortDateString();
            }
            catch
            {
                clanovi.Clear();
                Osvezi();
            }
        }
        private void Osvezi()
        {
            SqlConnection SqlConn = new SqlConnection(@"Data Source=DESKTOP-3QT4TNV\SQLEXPRESS;Initial Catalog=Teretana;Integrated Security=True");
            SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_ListaDeaktivnihClanova", SqlConn);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Clanovi cl = new Clanovi();

                string Ime = read.GetString(0);
                string Prezime = read.GetString(1);
                DateTime VremeDo = read.GetDateTime(2);

                cl.Ime = Ime;
                cl.Prezime = Prezime;
                cl.VremeDo = VremeDo;

                clanovi.Add(cl);
            }
            listView.ItemsSource = null;
            listView.ItemsSource = clanovi;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Osvezi();
            dtpVremeDo.SelectedDate = DateTime.Now.AddDays(30);
        }

        private void buttonProduzi_Click(object sender, RoutedEventArgs e)
        {         
            SqlConnection SqlConn = new SqlConnection(@"Data Source=DESKTOP-3QT4TNV\SQLEXPRESS;Initial Catalog=Teretana;Integrated Security=True");
            SqlConn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Clanovi SET VremeDo = @VremeDo WHERE Ime = @Ime", SqlConn);
            cmd.Parameters.Add(new SqlParameter("@VremeDo", dtpVremeDo.SelectedDate));
            cmd.Parameters.Add(new SqlParameter("@Ime", textBoxIme.Text));
            int ubaci = cmd.ExecuteNonQuery();

            if (ubaci == 0)
            {
                MessageBox.Show("Doslo je do greske");
            }
            else
            {
                SqlConn.Close();
                Osvezi();
                textBoxIme.Clear();
                textBoxPrezime.Clear();
                textBoxVremeDo.Clear();
                MessageBox.Show("Clanarina produzena");
            }
        }
    }
}
