using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using LayerByte.Logmatrix.Models;

namespace LayerByte.Logmatrix.Services;

public sealed class SecurityReportService
{
    public ObservableCollection<ReportItem> BuildReport()
    {
        var items = new ObservableCollection<ReportItem>
        {
            new("Project", "Logmatrix"),
            new("Focus", "Windows/application log analysis dashboard."),
            new("Machine", Environment.MachineName),
            new("OS", Environment.OSVersion.ToString()),
            new("Processes", Process.GetProcesses().Length.ToString())
        };
        return items;
    }

    public string HashFile(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
        {
            throw new FileNotFoundException("Choose a readable local file.", path);
        }
        using var stream = File.OpenRead(path);
        return Convert.ToHexString(SHA256.HashData(stream)).ToLowerInvariant();
    }
}
