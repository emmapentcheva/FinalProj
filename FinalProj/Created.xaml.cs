using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for Created.xaml
    /// </summary>
    public partial class Created : Window
    {
        public Created()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pentc\Desktop\Spitify\Spitify\Databses.mdf;Integrated Security=True");
            try
            {
                sqlCon.Open();
                string query = "select Name, Artist, Album from MyPlay";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                SqlDataAdapter word = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                word.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddSong a = new AddSong();
            a.Show();
            this.Close();
        }
    }
}
