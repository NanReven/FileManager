using System;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form
    {
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

            if (Directory.GetParent(path) != null)
            {
                FilesTable.Rows.Add("...");
            }

            try
            {
                var files = FileService.GetDirectoryFiles(path);
                if (files.Count == 0)
                {
                    MessageBox.Show("В директории нет файлов");
                    return;
                }
                foreach (var file in files)
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
    }
}
