using Microsoft.Win32;
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

namespace Lab08
{
    
    public partial class Owner : Window
    {
        public string path; string str = ""; string script = "";
        public Owner()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    path = openFileDialog.FileName;
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    imgDynamic.Source = new BitmapImage(fileUri);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            
            string connectionString = $"server=DESKTOP-LAFI17U\\MSSQLSERVER06;DataBase = Lab08;Trusted_Connection = Yes;";
            
            SqlTransaction tx = null;
            MessageBox.Show(owner.Text + dateofbirth.Text+ passport.Text+ path);
            script = "INSERT INTO OwnerOfAccount (AccOwner, Passport, pic) VALUES('" + owner.Text + "', '" + passport.Text + "', '" +  path +"')";

            try
            {
                if (script != "")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(script, connection);
                        tx = connection.BeginTransaction();
                        command.Transaction = tx;
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            str = $"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t\t\t\t\t\t\n";

                            while (reader.Read())
                            {
                                object department = reader.GetValue(0);
                                object number = reader.GetValue(1);
                                object price = reader.GetValue(2);
                                object data = reader.GetValue(3);
                                str += $"{department}\t\t\t{number}\t\t{price}\t{data}\t\n";
                            }
                        }
                        MessageBox.Show(str);
                        reader.Close();

                        tx.Commit();
                    }
                }
                else
                {
                    MessageBox.Show("enter script!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tx.Rollback();
            }
        }
    }
}
