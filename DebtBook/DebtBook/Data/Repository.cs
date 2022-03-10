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
    
    private static readonly string path = "debtors.json";

    internal static ObservableCollection<Debtor>? ReadFile()
    {
        var json = File.ReadAllText(path);
        
        return JsonConvert.DeserializeObject<ObservableCollection<Debtor>>(json);
    }
    internal static void SaveFile(ObservableCollection<Debtor> debtors)
    {
        TextWriter writer = new StreamWriter(path);
        var json = JsonConvert.SerializeObject(debtors.ToList());
        writer.WriteLine(json);
        writer.Close();
    }
}
