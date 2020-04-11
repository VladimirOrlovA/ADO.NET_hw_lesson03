using ADO.NET_hw_lesson03.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace ADO.NET_hw_lesson03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string _ConnStr;
        static SqlConnection _Connection;
        static Frame _MainFrame;
        public MainWindow()
        {
            InitializeComponent();
            _ConnStr = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
            _Connection = new SqlConnection(_ConnStr);
            _MainFrame = frMainFrame;
        }

        private void btnTablesEquipment_Click(object sender, RoutedEventArgs e)
        {
            string command = "SELECT TOP(10) * FROM TablesEquipment";
            _MainFrame.Navigate(new PageTableView(command, _Connection, "TablesEquipment"));
        }

        private void btnTablesManufacturer_Click(object sender, RoutedEventArgs e)
        {
            string command = "SELECT TOP(10) * FROM TablesManufacturer";
            _MainFrame.Navigate(new PageTableView(command, _Connection, "TablesManufacturer"));
        }

        private void btnTablesStopReason_Click(object sender, RoutedEventArgs e)
        {
            string command = "SELECT TOP(10) * FROM TablesStopReason";
            _MainFrame.Navigate(new PageTableView(command, _Connection, "TablesStopReason"));
        }
    }
}
