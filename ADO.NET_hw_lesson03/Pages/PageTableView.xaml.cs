using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

namespace ADO.NET_hw_lesson03.Pages
{
    /// <summary>
    /// Interaction logic for PageTableView.xaml
    /// </summary>
    public partial class PageTableView : Page
    {
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTableMapping tableMapping;

        public PageTableView(string command, SqlConnection connection, string tableName)
        {
            InitializeComponent();
            dataAdapter = new SqlDataAdapter(command, connection);
            tableMapping = dataAdapter.TableMappings.Add("Table", tableName);
            FillTable(tableName);
        }

        private void FillTable(string tableName)
        {
            dataSet = new DataSet(tableName);
            dataAdapter.Fill(dataSet);
            dataSet.Tables[0].TableName = tableName;
            dgTable.ItemsSource = dataSet.Tables[tableName].DefaultView;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataSet);
        }

        private void dgTable_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            btnSave.IsEnabled = true;
        }
    }
}
