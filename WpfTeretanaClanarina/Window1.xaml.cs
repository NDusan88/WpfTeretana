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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Clanovi> clanovi = new List<Clanovi>();
        public Window1()
        {
            InitializeComponent();
        }

        private void OsveziListu()
        {
            clanovi = new List<Clanovi>();
            SqlConnection SqlConn = new SqlConnection(@"Data Source=DESKTOP-3QT4TNV\SQLEXPRESS;Initial Catalog=Teretana;Integrated Security=True");
            SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_ListaZahteva", SqlConn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                Clanovi cl = new Clanovi();
                int ClanoviId = read.GetInt32(0);
                string Ime = read.GetString(1);
                string Prezime = read.GetString(2);
                DateTime VremeOd = read.GetDateTime(3);
                DateTime VremeDo = read.GetDateTime(4);

                cl.ClanoviId = ClanoviId;
                cl.Ime = Ime;
                cl.Prezime = Prezime;
                cl.VremeOd = VremeOd;
                cl.VremeDo = VremeDo;
                clanovi.Add(cl);
            }
            SqlConn.Close();
            listView.ItemsSource = null;
            listView.ItemsSource = clanovi;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OsveziListu();
            listView.SelectedIndex = 0;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Clanovi item = (Clanovi)listView.SelectedItem;
                textBoxIme.Text = item.Ime;
                textBoxPrezime.Text = item.Prezime;
                textBoxVremeOd.Text = item.VremeOd.ToShortDateString();
                textBoxVremeDo.Text = item.VremeDo.ToShortDateString();
            }
            catch
            {
                OsveziListu();
            }
           
        }

        private void buttonUclani_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedIndex > -1)
            {
                clanovi.Clear();
                SqlConnection SqlConn = new SqlConnection(@"Data Source=DESKTOP-3QT4TNV\SQLEXPRESS;Initial Catalog=Teretana;Integrated Security=True");
                SqlConn.Open();
                SqlTransaction trans = SqlConn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("INSERT INTO Clanarina(ClanoviId) VALUES (@ClanoviId)", SqlConn, trans);
                cmd.Parameters.Add(new SqlParameter("@ClanoviId", (listView.SelectedItem as Clanovi).ClanoviId));
                SqlCommand cmd1 = new SqlCommand("INSERT INTO AktivnaClanarina(ClanoviId) VALUES (@ClanoviId)", SqlConn, trans);
                cmd1.Parameters.Add(new SqlParameter("@ClanoviId", (listView.SelectedItem as Clanovi).ClanoviId));
                cmd.Transaction = trans;
                cmd1.Transaction = trans;

                int ubaci = cmd.ExecuteNonQuery();
                int ubaci1 = cmd1.ExecuteNonQuery();
                if (ubaci == 0 || ubaci1 == 0)
                {
                    trans.Rollback();
                    MessageBox.Show("Doslo je do greske");
                }
                else
                {
                    trans.Commit();
                    textBoxIme.Clear();
                    textBoxPrezime.Clear();
                    textBoxVremeOd.Clear();
                    textBoxVremeDo.Clear();
                    OsveziListu();
                    SqlConn.Close();
                    MessageBox.Show("Zahtev obradjen");
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali clana"); 
            }
        }

        private void buttonNazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            Close();
            m.ShowDialog();
        }
    }
}
