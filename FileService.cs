using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    internal class FileItem
    {
        public string Name { get; set; }
        public DateTime LastModified { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
    }

    internal class FileService
    {
        public static List<FileItem> GetDirectoryFiles(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            var files = new List<FileItem>();
            var directoryInfo = new DirectoryInfo(path);

            foreach (FileSystemInfo file in directoryInfo.GetFileSystemInfos())
            {
                files.Add(new FileItem
                {
                    Name = file.Name,
                    LastModified = file.LastWriteTime,
                    Type = file.Attributes.HasFlag(FileAttributes.Directory) ? "Каталог" : file.Extension,
                    Size = file is FileInfo fileInfo ? fileInfo.Length : 0
                });
            }

            return files;
        }
    }
}