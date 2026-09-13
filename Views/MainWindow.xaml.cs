using System.Collections.ObjectModel;
using System.Windows;
using LayerByte.Logmatrix.Models;
using LayerByte.Logmatrix.Services;

namespace LayerByte.Logmatrix.Views;

public partial class MainWindow : Window
{
    public ObservableCollection<ReportItem> Items { get; }

    public MainWindow()
    {
        InitializeComponent();
        Items = new SecurityReportService().BuildReport();
        DataContext = this;
    }
}
