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

namespace SqlServerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void connection_OpenClose(object sender, System.Data.StateChangeEventArgs e)
        {
            SqlConnection connection = sender as SqlConnection;


            ServerNameTextBlock.Text = connection.DataSource;
            DBNameTextBlock.Text = connection.Database;
           
        }
        public void ConnectButton_Click(object sender, RoutedEventArgs e)
        {

            if (Username.Text == "admin" && Password.Password == "admin")
            {
                string conStr = @"Data Source = DESKTOP-0LP9EBH; Initial Catalog = Hospital; Integrated Security = true;";
                ellipse.Fill = Brushes.Green;
                StateLabel.Content = "Connected";
                SqlConnection connection = new SqlConnection(conStr);


                connection.StateChange += connection_OpenClose;

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


            else
            {

                MessageBox.Show("Incorrect username or password!");
            }

        }
        public void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            string conStr = @"Data Source = DESKTOP-0LP9EBH; Initial Catalog = Hospital; Integrated Security = true;";
            SqlConnection connection = new SqlConnection(conStr);
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ellipse.Fill = Brushes.Red;
            StateLabel.Content = "Disconnected";
            ServerNameTextBlock.Text ="";
            DBNameTextBlock.Text = "";
            Username.Text = "";
            Password.Password = "";
        }

        
    }
}
