using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Serialization;

namespace FileManager
{
    /// <summary>
    /// Класс для работы с форматами XML и JSON 
    /// </summary>
    internal class DataSerialization
    {
        public static void SaveDataAsXML(string filePath, List<FileItem> files)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FileItem>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, files);
            }          
        }

        public static void SaveDataAsJSON(string filePath, List<FileItem> files)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            string jsonString = JsonSerializer.Serialize(files, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<FileItem> LoadDataAsXML(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FileItem>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (List<FileItem>)serializer.Deserialize(reader);
            }
        }

        public static List<FileItem> LoadDataAsJSON(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return JsonSerializer.Deserialize<List<FileItem>>(reader.ReadToEnd());
            }
        }
    }
}
