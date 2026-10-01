using System;
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            FilesTable.Rows.Clear();
            string path = DirPathTextBox.Text;

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Введите путь к каталогу");
                return;
            }

            try
            {
                var files = FileService.GetDirectoryFiles(path);
                if (files.Count == 0)
                {
                    MessageBox.Show("В директории нет файлов");
                }

                foreach (var file in files)
                {
                    FilesTable.Rows.Add(file.Name, file.LastModified, file.Type, file.Size);
                }
            }

            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show("Директория не найдена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}");
            }
        }
    }
}
