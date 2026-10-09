namespace FileManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.DirPathTextBox = new System.Windows.Forms.TextBox();
            this.FilesTable = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileLastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DirPathTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FilesTable, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 62);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 357);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к директории";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(509, 22);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(147, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // DirPathTextBox
            // 
            this.DirPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirPathTextBox.Location = new System.Drawing.Point(3, 22);
            this.DirPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DirPathTextBox.Name = "DirPathTextBox";
            this.DirPathTextBox.Size = new System.Drawing.Size(500, 22);
            this.DirPathTextBox.TabIndex = 2;
            // 
            // FilesTable
            // 
            this.FilesTable.AllowUserToAddRows = false;
            this.FilesTable.AllowUserToDeleteRows = false;
            this.FilesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FilesTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.FilesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileLastModified,
            this.FileType,
            this.FileSize});
            this.tableLayoutPanel1.SetColumnSpan(this.FilesTable, 2);
            this.FilesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesTable.Location = new System.Drawing.Point(3, 61);
            this.FilesTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FilesTable.Name = "FilesTable";
            this.FilesTable.RowHeadersVisible = false;
            this.FilesTable.RowHeadersWidth = 51;
            this.FilesTable.RowTemplate.Height = 24;
            this.FilesTable.Size = new System.Drawing.Size(1007, 294);
            this.FilesTable.TabIndex = 3;
            this.FilesTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilesTable_CellDoubleClick);
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Имя файла";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // FileLastModified
            // 
            this.FileLastModified.HeaderText = "Дата изменения";
            this.FileLastModified.MinimumWidth = 6;
            this.FileLastModified.Name = "FileLastModified";
            this.FileLastModified.ReadOnly = true;
            // 
            // FileType
            // 
            this.FileType.HeaderText = "Тип";
            this.FileType.MinimumWidth = 6;
            this.FileType.Name = "FileType";
            this.FileType.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "Размер файла";
            this.FileSize.MinimumWidth = 6;
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(521, 424);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(235, 27);
            this.btnSaveData.TabIndex = 1;
            this.btnSaveData.Text = "Сохранение данных в XML/JSON";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(787, 424);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(235, 27);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Загрузка данных из XML/JSON";
            this.btnLoadData.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 546);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilesTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox DirPathTextBox;
        private System.Windows.Forms.DataGridView FilesTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileLastModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnLoadData;
    }
}

