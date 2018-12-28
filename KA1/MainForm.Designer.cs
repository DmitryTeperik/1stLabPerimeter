namespace KA1
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
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.prgbLoad = new System.Windows.Forms.ProgressBar();
            this.btnAbort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(12, 12);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(500, 500);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.Click += new System.EventHandler(this.pbMain_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(12, 518);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(93, 518);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // prgbLoad
            // 
            this.prgbLoad.Location = new System.Drawing.Point(174, 518);
            this.prgbLoad.Name = "prgbLoad";
            this.prgbLoad.Size = new System.Drawing.Size(257, 23);
            this.prgbLoad.TabIndex = 3;
            // 
            // btnAbort
            // 
            this.btnAbort.Enabled = false;
            this.btnAbort.Location = new System.Drawing.Point(437, 518);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 4;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 551);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.prgbLoad);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.pbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "KA1";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ProgressBar prgbLoad;
        private System.Windows.Forms.Button btnAbort;
    }
}

