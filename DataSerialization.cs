using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Serialization;

namespace FileManager
{
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
    }
}
