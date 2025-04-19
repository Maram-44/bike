using System;
using System.Collections.Generic;
using System.Data;
//using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace bike
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SqlConnection connection()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("sitting.json").Build();
            SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);
            return conn;
        }

        public MainWindow()
        {
            InitializeComponent();
            loadStaff();
        }

        //fill datagrid
        void loadStaff()
        {
            connection().Open();
            SqlCommand cmd = new SqlCommand("show_financialDues", connection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            connection().Close();
            DataTable dt =new DataTable();
            adapter.Fill(dt);
            StaffDataGrid.ItemsSource =dt.DefaultView;

        }



        private object _lastSelectedItem = null;

        private void StaffDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StaffDataGrid.SelectedItem != null && StaffDataGrid.SelectedItem == _lastSelectedItem)
            {
                StaffDataGrid.SelectedItem = null;
                _lastSelectedItem = null;
            }
            else
            {
                _lastSelectedItem = StaffDataGrid.SelectedItem;
            }
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit action clicked.");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete action clicked.");
        }

        private void ViewImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is DataRowView row)
            {
                // تأكد أن الصورة موجودة في عمود اسمه "imagePath" مثلاً
                string imagePath = row["imagePath"]?.ToString();

                if (!string.IsNullOrEmpty(imagePath))
                {
                    ImageViewer viewer = new ImageViewer(imagePath);
                    viewer.Owner = this;
                    viewer.ShowDialog();
                }
                else
                {
                    MessageBox.Show("لا توجد صورة متاحة.");
                }
            }
        }


        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is DataRowView row)
            {
                var result = MessageBox.Show("Shure", "Are you shure for acceptable this opration?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection conn = connection())
                    {
                        SqlCommand cmd = new SqlCommand("UpdateStatusForFinancialDues", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] pram = new SqlParameter[2];

                        pram[0] = new SqlParameter("@status", SqlDbType.NVarChar, 20);
                        pram[0].Value = "acceptable";

                        pram[1] = new SqlParameter("@oprationId", SqlDbType.Int);
                        pram[1].Value = Convert.ToInt32(row["Opration Number"]);

                        cmd.Parameters.AddRange(pram);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    loadStaff();
                }
            }
        }


        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is DataRowView row)
            {
                var result = MessageBox.Show("Shure", "Are you shure for reject this opration?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection conn = connection())
                    {
                        SqlCommand cmd = new SqlCommand("UpdateStatusForFinancialDues", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] pram = new SqlParameter[2];

                        pram[0] = new SqlParameter("@status", SqlDbType.NVarChar, 20);
                        pram[0].Value = "unacceptable";

                        pram[1] = new SqlParameter("@oprationId", SqlDbType.Int);
                        pram[1].Value = Convert.ToInt32(row["Opration Number"]);

                        cmd.Parameters.AddRange(pram);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    loadStaff();
                }
            }
        }



        private void StaffDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
