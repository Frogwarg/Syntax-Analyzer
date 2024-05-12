namespace OutputTree
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorsTxt = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textTxt = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.leksemsTable = new System.Windows.Forms.DataGridView();
            this.Leksema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meaning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prevExprBtn = new System.Windows.Forms.Button();
            this.nextExprBtn = new System.Windows.Forms.Button();
            this.expressionTxt = new System.Windows.Forms.RichTextBox();
            this.loadBtn = new System.Windows.Forms.Button();
            this.grammarTxt = new System.Windows.Forms.TextBox();
            this.outTxt = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.leksemsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorsTxt
            // 
            this.errorsTxt.Location = new System.Drawing.Point(315, 347);
            this.errorsTxt.Name = "errorsTxt";
            this.errorsTxt.Size = new System.Drawing.Size(339, 272);
            this.errorsTxt.TabIndex = 25;
            this.errorsTxt.Text = "";
            this.errorsTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputStringTxt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ошибки:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Текст:";
            // 
            // textTxt
            // 
            this.textTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textTxt.Location = new System.Drawing.Point(12, 115);
            this.textTxt.Name = "textTxt";
            this.textTxt.Size = new System.Drawing.Size(297, 504);
            this.textTxt.TabIndex = 22;
            this.textTxt.Text = "";
            this.textTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputStringTxt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Таблица лексем:";
            // 
            // leksemsTable
            // 
            this.leksemsTable.AllowUserToAddRows = false;
            this.leksemsTable.AllowUserToDeleteRows = false;
            this.leksemsTable.AllowUserToResizeColumns = false;
            this.leksemsTable.AllowUserToResizeRows = false;
            this.leksemsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.leksemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leksemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Leksema,
            this.Type,
            this.Meaning});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.leksemsTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.leksemsTable.Location = new System.Drawing.Point(315, 21);
            this.leksemsTable.Name = "leksemsTable";
            this.leksemsTable.Size = new System.Drawing.Size(339, 302);
            this.leksemsTable.TabIndex = 20;
            // 
            // Leksema
            // 
            this.Leksema.HeaderText = "Лексема";
            this.Leksema.Name = "Leksema";
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.Name = "Type";
            // 
            // Meaning
            // 
            this.Meaning.HeaderText = "Значение";
            this.Meaning.Name = "Meaning";
            // 
            // prevExprBtn
            // 
            this.prevExprBtn.Enabled = false;
            this.prevExprBtn.Location = new System.Drawing.Point(11, 62);
            this.prevExprBtn.Name = "prevExprBtn";
            this.prevExprBtn.Size = new System.Drawing.Size(107, 34);
            this.prevExprBtn.TabIndex = 19;
            this.prevExprBtn.Text = "Предыдущее выражение";
            this.prevExprBtn.UseVisualStyleBackColor = true;
            this.prevExprBtn.Click += new System.EventHandler(this.prevExprBtn_Click);
            // 
            // nextExprBtn
            // 
            this.nextExprBtn.Enabled = false;
            this.nextExprBtn.Location = new System.Drawing.Point(124, 62);
            this.nextExprBtn.Name = "nextExprBtn";
            this.nextExprBtn.Size = new System.Drawing.Size(100, 34);
            this.nextExprBtn.TabIndex = 18;
            this.nextExprBtn.Text = "Следующее выражение";
            this.nextExprBtn.UseVisualStyleBackColor = true;
            this.nextExprBtn.Click += new System.EventHandler(this.nextExprBtn_Click);
            // 
            // expressionTxt
            // 
            this.expressionTxt.Location = new System.Drawing.Point(11, 5);
            this.expressionTxt.Name = "expressionTxt";
            this.expressionTxt.Size = new System.Drawing.Size(213, 49);
            this.expressionTxt.TabIndex = 17;
            this.expressionTxt.Text = "";
            this.expressionTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputStringTxt_KeyPress);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(230, 21);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(79, 24);
            this.loadBtn.TabIndex = 16;
            this.loadBtn.Text = "Загрузить";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // grammarTxt
            // 
            this.grammarTxt.Enabled = false;
            this.grammarTxt.Location = new System.Drawing.Point(660, 21);
            this.grammarTxt.Multiline = true;
            this.grammarTxt.Name = "grammarTxt";
            this.grammarTxt.Size = new System.Drawing.Size(150, 75);
            this.grammarTxt.TabIndex = 26;
            // 
            // outTxt
            // 
            this.outTxt.Location = new System.Drawing.Point(660, 125);
            this.outTxt.Name = "outTxt";
            this.outTxt.Size = new System.Drawing.Size(150, 494);
            this.outTxt.TabIndex = 27;
            this.outTxt.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Вывод:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(657, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Правила грамматики:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(435, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1066, 758);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(813, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Дерево вывода:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 631);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.outTxt);
            this.Controls.Add(this.grammarTxt);
            this.Controls.Add(this.errorsTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.leksemsTable);
            this.Controls.Add(this.prevExprBtn);
            this.Controls.Add(this.nextExprBtn);
            this.Controls.Add(this.expressionTxt);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Андронатий 21ПИ";
            ((System.ComponentModel.ISupportInitialize)(this.leksemsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox errorsTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView leksemsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leksema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meaning;
        private System.Windows.Forms.Button prevExprBtn;
        private System.Windows.Forms.Button nextExprBtn;
        private System.Windows.Forms.RichTextBox expressionTxt;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.TextBox grammarTxt;
        private System.Windows.Forms.RichTextBox outTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
    }
}

