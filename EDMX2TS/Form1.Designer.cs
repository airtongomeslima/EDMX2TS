namespace EDMX2TS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tx_entity = new System.Windows.Forms.TextBox();
            this.tx_irepository = new System.Windows.Forms.TextBox();
            this.tx_repository = new System.Windows.Forms.TextBox();
            this.tx_service = new System.Windows.Forms.TextBox();
            this.tx_filename = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txRepositoryTest = new System.Windows.Forms.TextBox();
            this.txServiceTest = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select output folder:";
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Location = new System.Drawing.Point(121, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "c:\\...\\src\\yourproject\\";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 127);
            this.textBox2.MaxLength = 99999999;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(423, 496);
            this.textBox2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 113);
            this.button2.TabIndex = 4;
            this.button2.Text = "Generate ->";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Entity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(745, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "IRepository";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(523, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Repository";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1048, 644);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 41);
            this.button3.TabIndex = 11;
            this.button3.Text = "Save Files";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(745, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Service";
            // 
            // tx_entity
            // 
            this.tx_entity.Location = new System.Drawing.Point(526, 78);
            this.tx_entity.MaxLength = 99999999;
            this.tx_entity.Multiline = true;
            this.tx_entity.Name = "tx_entity";
            this.tx_entity.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tx_entity.Size = new System.Drawing.Size(213, 263);
            this.tx_entity.TabIndex = 15;
            this.tx_entity.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tx_Click);
            // 
            // tx_irepository
            // 
            this.tx_irepository.Location = new System.Drawing.Point(748, 78);
            this.tx_irepository.MaxLength = 99999999;
            this.tx_irepository.Multiline = true;
            this.tx_irepository.Name = "tx_irepository";
            this.tx_irepository.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tx_irepository.Size = new System.Drawing.Size(213, 263);
            this.tx_irepository.TabIndex = 16;
            this.tx_irepository.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tx_Click);
            // 
            // tx_repository
            // 
            this.tx_repository.Location = new System.Drawing.Point(526, 360);
            this.tx_repository.MaxLength = 99999999;
            this.tx_repository.Multiline = true;
            this.tx_repository.Name = "tx_repository";
            this.tx_repository.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tx_repository.Size = new System.Drawing.Size(213, 263);
            this.tx_repository.TabIndex = 17;
            this.tx_repository.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tx_Click);
            // 
            // tx_service
            // 
            this.tx_service.Location = new System.Drawing.Point(748, 360);
            this.tx_service.MaxLength = 99999999;
            this.tx_service.Multiline = true;
            this.tx_service.Name = "tx_service";
            this.tx_service.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tx_service.Size = new System.Drawing.Size(213, 263);
            this.tx_service.TabIndex = 18;
            this.tx_service.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tx_Click);
            // 
            // tx_filename
            // 
            this.tx_filename.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tx_filename.Location = new System.Drawing.Point(613, 30);
            this.tx_filename.Name = "tx_filename";
            this.tx_filename.Size = new System.Drawing.Size(366, 20);
            this.tx_filename.TabIndex = 19;
            this.tx_filename.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tx_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(523, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "File Name Base:";
            // 
            // txRepositoryTest
            // 
            this.txRepositoryTest.Location = new System.Drawing.Point(967, 360);
            this.txRepositoryTest.MaxLength = 99999999;
            this.txRepositoryTest.Multiline = true;
            this.txRepositoryTest.Name = "txRepositoryTest";
            this.txRepositoryTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txRepositoryTest.Size = new System.Drawing.Size(213, 263);
            this.txRepositoryTest.TabIndex = 24;
            this.txRepositoryTest.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tx_Click);
            // 
            // txServiceTest
            // 
            this.txServiceTest.Location = new System.Drawing.Point(967, 78);
            this.txServiceTest.MaxLength = 99999999;
            this.txServiceTest.Multiline = true;
            this.txServiceTest.Name = "txServiceTest";
            this.txServiceTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txServiceTest.Size = new System.Drawing.Size(213, 263);
            this.txServiceTest.TabIndex = 23;
            this.txServiceTest.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tx_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(964, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "RepositoryTest";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(964, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "ServiceTest";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Metadata URL:";
            // 
            // textBox3
            // 
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox3.Location = new System.Drawing.Point(99, 78);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(259, 20);
            this.textBox3.TabIndex = 25;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(364, 78);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "Find";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(99, 104);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 17);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "Use Basic Auth";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(121, 36);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(237, 20);
            this.textBox4.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Project Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 697);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txRepositoryTest);
            this.Controls.Add(this.txServiceTest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tx_filename);
            this.Controls.Add(this.tx_service);
            this.Controls.Add(this.tx_repository);
            this.Controls.Add(this.tx_irepository);
            this.Controls.Add(this.tx_entity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDM 2 TS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tx_entity;
        private System.Windows.Forms.TextBox tx_irepository;
        private System.Windows.Forms.TextBox tx_repository;
        private System.Windows.Forms.TextBox tx_service;
        private System.Windows.Forms.TextBox tx_filename;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txRepositoryTest;
        private System.Windows.Forms.TextBox txServiceTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
    }
}

