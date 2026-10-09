using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form
    {
        private List<FileItem> _files = new List<FileItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadDirectory(string path)
        {
            FilesTable.Rows.Clear();
            _files.Clear();

            if (Directory.GetParent(path) != null)
            {
                FilesTable.Rows.Add("...");
            }

            try
            {
                _files = FileService.GetDirectoryFiles(path);
                if (_files.Count == 0)
                {
                    MessageBox.Show("В директории нет файлов");
                    return;
                }
                foreach (var file in _files)
                {
                    FilesTable.Rows.Add(file.Name, file.LastModified, file.Type, FileService.GetFormattedSize(file.Size));
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Директория не найдена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string path = DirPathTextBox.Text;

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Введите путь к каталогу");
                return;
            }

            LoadDirectory(path);
        }

        private void FilesTable_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string fileName = FilesTable.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
            if (fileName == "...")
            {
                string parentPath = Directory.GetParent(DirPathTextBox.Text).FullName;
                DirPathTextBox.Text = parentPath;
                LoadDirectory(parentPath);
                return;
            }

            string fileType = FilesTable.Rows[e.RowIndex].Cells["FileType"].Value.ToString();
            if (fileType != "Каталог")
            {
                MessageBox.Show("Файл данной строки не является каталогом");
                return;
            }

            string newPath = Path.Combine(DirPathTextBox.Text, fileName);
            DirPathTextBox.Text = newPath;

            LoadDirectory(newPath);
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (_files == null || _files.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = DirPathTextBox.Text; 
                saveFileDialog.Title = "Сохранить данные таблицы"; 

                saveFileDialog.Filter = "Формат XML (*.xml)|*.xml|Формат JSON (*.json)|*.json";
                saveFileDialog.AddExtension = true; 
                saveFileDialog.CheckPathExists = true; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string fileExtension = Path.GetExtension(filePath);
                    try
                    {
                        if (fileExtension == ".xml")
                        {
                            DataSerialization.SaveDataAsXML(filePath, _files);
                        } else if (fileExtension == ".json")
                        {
                            DataSerialization.SaveDataAsJSON(filePath, _files);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
                    }
                }
            }
        }
    }
}
