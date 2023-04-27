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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pentc\Desktop\Spitify\Spitify\Databses.mdf;Integrated Security=True");

            try
            {
                sqlCon.Open();
                string query = "INSERT INTO SignUp(Username, [First Name], [Last Name], Email, Password, [Repeat Password])values('" + txtusername.Text + "', '" + txtfirstname.Text + "', '" + txtlastname.Text + "', '" + txtemail.Text + "', '" + psspassword.Password + "', '" + pssreppassword.Password + "')";

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Saved");

                LogIn gf = new LogIn();
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
