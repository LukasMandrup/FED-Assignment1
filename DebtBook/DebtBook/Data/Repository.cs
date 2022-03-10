using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DebtBook.Models;

namespace DebtBook.Data;

public class Repository
{
    internal static ObservableCollection<Debtor> ReadFile(string fileName)
    {
        // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
        TextReader reader = new StreamReader(fileName);
        // Deserialize all the agents.
        var debtors = (ObservableCollection<Debtor>)serializer.Deserialize(reader);
        reader.Close();
        return debtors;
    }
    internal static void SaveFile(string fileName, ObservableCollection<Debtor> agents)
    {
        // Create an instance of the XmlSerializer class and specify the type of object to serialize.
        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
        TextWriter writer = new StreamWriter(fileName);
        // Serialize all the agents.
        serializer.Serialize(writer, agents);
        writer.Close();
    }
}