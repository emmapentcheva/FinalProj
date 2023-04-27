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
    /// Interaction logic for idk.xaml
    /// </summary>
    public partial class idk : Window
    {
        public idk()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pentc\Desktop\FinalProj_\FinalProj\SpitifyDatabases.mdf;Integrated Security=True");
            try
            {
                sqlCon.Open();
                String query = "Insert into TodaysHits(Name,Artist,Album)values('" + txtname.Text + "','" + txtartist.Text + "','" + txtalbum.Text + "')";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added!");
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pentc\Desktop\FinalProj_\FinalProj\SpitifyDatabases.mdf;Integrated Security=True");
            try
            {
                sqlCon.Open();
                String query = "delete TodaysHits where Name = '" + this.txtname.Text + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted!");
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Playlist p = new Playlist();
            p.Show();
            this.Close();
        }
    }
}
