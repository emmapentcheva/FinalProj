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

namespace FinalProj
{
    /// <summary>
    /// Interaction logic for NewPlay.xaml
    /// </summary>
    public partial class NewPlay : Window
    {
        public NewPlay()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pentc\Desktop\FinalProj\FinalProj\SpitifyDatabases.mdf;Integrated Security=True");

            try
            {
                sqlCon.Open();
                string query = "INSERT INTO NewPlaylist([PlaylistName])values('" + txtplayname.Text + "')";

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Saved");

                Playlist gf = new Playlist();
                gf.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
