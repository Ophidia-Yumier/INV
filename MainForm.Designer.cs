namespace INVENTORY
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UpdateDataBtn = new System.Windows.Forms.Button();
            this.InsertDataBtn = new System.Windows.Forms.Button();
            this.ClearTableBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SelectRoomTypesBtn = new System.Windows.Forms.Button();
            this.SelectRoomsBtn = new System.Windows.Forms.Button();
            this.SelectFloorsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(194, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(721, 375);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UpdateDataBtn);
            this.groupBox1.Controls.Add(this.InsertDataBtn);
            this.groupBox1.Controls.Add(this.ClearTableBtn);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(188, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // UpdateDataBtn
            // 
            this.UpdateDataBtn.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateDataBtn.Location = new System.Drawing.Point(171, 406);
            this.UpdateDataBtn.Name = "UpdateDataBtn";
            this.UpdateDataBtn.Size = new System.Drawing.Size(157, 36);
            this.UpdateDataBtn.TabIndex = 5;
            this.UpdateDataBtn.Text = "Изменить запись";
            this.UpdateDataBtn.UseVisualStyleBackColor = true;
            this.UpdateDataBtn.Click += new System.EventHandler(this.UpdateDataBtn_Click);
            // 
            // InsertDataBtn
            // 
            this.InsertDataBtn.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InsertDataBtn.Location = new System.Drawing.Point(6, 406);
            this.InsertDataBtn.Name = "InsertDataBtn";
            this.InsertDataBtn.Size = new System.Drawing.Size(159, 36);
            this.InsertDataBtn.TabIndex = 4;
            this.InsertDataBtn.Text = "Добавить запись";
            this.InsertDataBtn.UseVisualStyleBackColor = true;
            this.InsertDataBtn.Click += new System.EventHandler(this.InsertDataBtn_Click);
            // 
            // ClearTableBtn
            // 
            this.ClearTableBtn.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearTableBtn.Location = new System.Drawing.Point(588, 406);
            this.ClearTableBtn.Name = "ClearTableBtn";
            this.ClearTableBtn.Size = new System.Drawing.Size(139, 36);
            this.ClearTableBtn.TabIndex = 6;
            this.ClearTableBtn.Text = "Очистить окно";
            this.ClearTableBtn.UseVisualStyleBackColor = true;
            this.ClearTableBtn.Click += new System.EventHandler(this.ClearTableBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SelectRoomTypesBtn);
            this.groupBox2.Controls.Add(this.SelectRoomsBtn);
            this.groupBox2.Controls.Add(this.SelectFloorsBtn);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 159);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Таблицы";
            // 
            // SelectRoomTypesBtn
            // 
            this.SelectRoomTypesBtn.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectRoomTypesBtn.Location = new System.Drawing.Point(6, 71);
            this.SelectRoomTypesBtn.Name = "SelectRoomTypesBtn";
            this.SelectRoomTypesBtn.Size = new System.Drawing.Size(158, 36);
            this.SelectRoomTypesBtn.TabIndex = 2;
            this.SelectRoomTypesBtn.Text = "Типы помещений";
            this.SelectRoomTypesBtn.UseVisualStyleBackColor = true;
            this.SelectRoomTypesBtn.Click += new System.EventHandler(this.SelectRoomTypesBtn_Click);
            // 
            // SelectRoomsBtn
            // 
            this.SelectRoomsBtn.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectRoomsBtn.Location = new System.Drawing.Point(6, 113);
            this.SelectRoomsBtn.Name = "SelectRoomsBtn";
            this.SelectRoomsBtn.Size = new System.Drawing.Size(158, 36);
            this.SelectRoomsBtn.TabIndex = 3;
            this.SelectRoomsBtn.Text = "Помещения";
            this.SelectRoomsBtn.UseVisualStyleBackColor = true;
            this.SelectRoomsBtn.Click += new System.EventHandler(this.SelectRoomsBtn_Click);
            // 
            // SelectFloorsBtn
            // 
            this.SelectFloorsBtn.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectFloorsBtn.Location = new System.Drawing.Point(6, 29);
            this.SelectFloorsBtn.Name = "SelectFloorsBtn";
            this.SelectFloorsBtn.Size = new System.Drawing.Size(158, 36);
            this.SelectFloorsBtn.TabIndex = 1;
            this.SelectFloorsBtn.Text = "Этажи";
            this.SelectFloorsBtn.UseVisualStyleBackColor = true;
            this.SelectFloorsBtn.Click += new System.EventHandler(this.SelectFloorsBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 472);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инвентаризация здания";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SelectRoomTypesBtn;
        private System.Windows.Forms.Button SelectRoomsBtn;
        private System.Windows.Forms.Button SelectFloorsBtn;
        private System.Windows.Forms.Button UpdateDataBtn;
        private System.Windows.Forms.Button InsertDataBtn;
        private System.Windows.Forms.Button ClearTableBtn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

