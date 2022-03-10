using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DebtBook.Models;
using Newtonsoft.Json;

namespace DebtBook.Data;

public static class Repository
{
    public static readonly string DebtorsPath = "debtors.json";

    internal static ObservableCollection<Debtor> ReadFile(string path)
    {
        var json = File.ReadAllText(path);
        
        return JsonConvert.DeserializeObject<ObservableCollection<Debtor>>(json);
    }
    internal static void SaveFile(string path, ObservableCollection<Debtor> debtors)
    {
        TextWriter writer = new StreamWriter(path);
        var json = JsonConvert.SerializeObject(debtors.ToList());
        writer.WriteLine(json);
        writer.Close();
    }
}
