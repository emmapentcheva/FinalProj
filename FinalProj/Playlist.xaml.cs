using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Playlist.xaml
    /// </summary>
    public partial class Playlist : Window
    {
        public Playlist()
        {
            InitializeComponent();
            fillcombobox();
        }

        public void fillcombobox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pentc\Desktop\FinalProj\FinalProj\SpitifyDatabases.mdf;Integrated Security=True");
            string query = "select * from NewPlaylist";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString(1);
                    comboBox1.Items.Add(sname);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_lol(object sender, RoutedEventArgs e)
        {
            NewPlay np = new NewPlay();
            np.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Created mv = new Created();

            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pentc\Desktop\FinalProj\FinalProj\SpitifyDatabases.mdf;Integrated Security=True");

            try
            {
                sqlCon.Open();
                string query = "Select * from NewPlaylist where PlaylistName = '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    mv.playlistnamer.Text = reader["PlaylistName"].ToString();
                    mv.Show();
                    this.Close();
                }
            }
            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                sqlCon.Close();

            }

            SqlConnection sqlCon1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pentc\Desktop\FinalProj\FinalProj\SpitifyDatabases.mdf;Integrated Security=True");
            try
            {
                sqlCon.Open();
                string query = "select Name, Artist, Album from MyPlay where Playlist = '" + mv.playlistnamer.Text + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                SqlDataAdapter word = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                word.Fill(dt);
                mv.DataGridmeow.ItemsSource = dt.DefaultView;
                word.Update(dt);
                MessageBox.Show("The Data is Complete");
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
