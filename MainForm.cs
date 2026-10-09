using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form
    {
        /// Список файлов и папок текущей директории
        private List<FileItem> _files = new List<FileItem>();
        /// Флаг режима просмотра отчета
        private bool _isReportMode = false;
        /// Актуальный путь текущей директории
        private string _currentPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Функция для заполнения таблицы.
        /// При ошибке восстанавливает текущий путь к директории в поле ввода.
        /// </summary>
        private void LoadDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Директория не найдена");
                if (_currentPath != null)
                    DirPathTextBox.Text = _currentPath;
                return;
            }

            _isReportMode = false;
            _currentPath = path;
            DirPathTextBox.Text = path;

            try
            {
                List<FileItem> files = FileService.GetDirectoryFiles(path);

                FilesTable.Rows.Clear();
                _files.Clear();
                _files = files;

                if (_files.Count == 0)
                {
                    MessageBox.Show("В директории нет файлов");
                    return;
                }

                if (Directory.GetParent(path) != null)
                {
                    FilesTable.Rows.Add("...");
                }

                UpdateTable();
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

        /// <summary>
        /// Обработчик двойного клика по строке таблицы для перехода в каталог или родительскую директорию.
        /// Блокирует навигацию в режиме просмотра отчета и запрещает переход в скрытые каталоги.
        /// </summary>
        private void FilesTable_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (_isReportMode)
            {
                MessageBox.Show("Навигация недоступна в режиме просмотра отчета");
                return;
            }

            string fileName = FilesTable.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
            if (fileName == "...")
            {
                string parentPath = Directory.GetParent(_currentPath).FullName;
                LoadDirectory(parentPath);
                return;
            }

            string fileType = FilesTable.Rows[e.RowIndex].Cells["FileType"].Value.ToString();
            if (fileType != "Каталог")
            {
                MessageBox.Show("Файл данной строки не является каталогом");
                return;
            } 

            string newPath = Path.Combine(_currentPath, fileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(newPath);
            if (directoryInfo.Attributes.HasFlag(FileAttributes.Hidden))
            {
                MessageBox.Show("Каталог скрыт");
                return;
            }

            LoadDirectory(newPath);
        }

        /// <summary>
        /// Функция для экспорта данных текущей таблицы в формате XML/JSON.
        /// </summary>
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

        /// <summary>
        /// Функция для импорта в таблицу из формата XML/JSON.
        /// </summary>
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = DirPathTextBox.Text;
                openFileDialog.Title = "Загрузить таблицу";

                openFileDialog.Filter = "Формат XML (*.xml)|*.xml|Формат JSON (*.json)|*.json";
                openFileDialog.AddExtension = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileExtension = Path.GetExtension(filePath);
                    try
                    {
                        if (fileExtension == ".xml")
                        {
                            _files = DataSerialization.LoadDataAsXML(filePath);
                        }
                        else if (fileExtension == ".json")
                        {
                            _files = DataSerialization.LoadDataAsJSON(filePath);
                        }

                        _isReportMode = true;
                        DirPathTextBox.Text = "Режим просмотра отчета";

                        UpdateTable();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
                    }
                }
            }
        }

        private void UpdateTable()
        {
            if (_files == null) return;
            if (_isReportMode) FilesTable.Rows.Clear();

            foreach (FileItem file in _files)
            {
                int index = FilesTable.Rows.Add(file.Name, file.LastModified, file.Type, FileService.GetFormattedSize(file.Size));
                if (file.Type == "Каталог")
                {
                    FilesTable.Rows[index].DefaultCellStyle.BackColor = Color.PowderBlue;
                }
            }
        }
    }
}