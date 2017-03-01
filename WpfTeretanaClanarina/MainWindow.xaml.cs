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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTeretanaClanarina
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Clanovi> clanovi = new List<Clanovi>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OsveziListu()
        {
            SqlConnection SqlConn = new SqlConnection(@"Data Source=DESKTOP-3QT4TNV\SQLEXPRESS;Initial Catalog=Teretana;Integrated Security=True");
            SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.View_CitajListu", SqlConn);
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
            textBoxIme.Focus();
            dtpOd.SelectedDate = DateTime.Now;
            dtpDo.SelectedDate = DateTime.Now.AddDays(30);
            OsveziListu();
            Window3 w3 = new Window3();
            w3.Visibility = Visibility.Hidden;
            w3.ShowDialog();
            if (w3.listView.HasItems)
            {
                MessageBox.Show("U listi je clan sa isteklom clanarinom", "Poruka", MessageBoxButton.OK, MessageBoxImage.Warning);
                w3.Close();
            }
            else
            {
                w3.Close();
            }
        }

        private void buttonUpisi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxIme.Text.Trim()) || string.IsNullOrWhiteSpace(textBoxPrezime.Text.Trim()) || dtpOd.SelectedDate < DateTime.Now.AddDays(-1) || dtpDo.SelectedDate < dtpOd.SelectedDate)
            {
                MessageBox.Show("Niste uneli ispravne podatke");              
            }
            else
            {
                clanovi.Clear();
                SqlConnection SqlConn = new SqlConnection(@"Data Source=DESKTOP-3QT4TNV\SQLEXPRESS;Initial Catalog=Teretana;Integrated Security=True");
                SqlConn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Clanovi(Ime,Prezime,VremeOd,VremeDo) VALUES(@Ime,@Prezime,@VremeOd,@VremeDo)", SqlConn);
                cmd.Parameters.Add(new SqlParameter("@Ime", textBoxIme.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@Prezime", textBoxPrezime.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@VremeOd", dtpOd.SelectedDate));
                cmd.Parameters.Add(new SqlParameter("@VremeDo", dtpDo.SelectedDate));

                int ubaci = cmd.ExecuteNonQuery();

                if (ubaci == 0)
                {
                    MessageBox.Show("Doslo je do greske");
                }
                else
                {
                    OsveziListu();
                    textBoxIme.Clear();
                    textBoxPrezime.Clear();
                    textBoxIme.Focus();
                    MessageBox.Show("Dodat u Listu");
                }            
            }
        }

        private void buttonObradi_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            Close();
            w1.ShowDialog();
        }

        private void buttonAktivneClanarine_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            Close();
            w2.ShowDialog();
        }

        private void buttonIstekleClanarine_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            Close();
            w3.ShowDialog();
        }
    }
}
