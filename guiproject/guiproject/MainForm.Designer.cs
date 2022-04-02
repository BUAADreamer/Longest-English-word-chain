
namespace guiproject
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonw = new System.Windows.Forms.Button();
            this.buttonm = new System.Windows.Forms.Button();
            this.buttonc = new System.Windows.Forms.Button();
            this.buttonh = new System.Windows.Forms.Button();
            this.buttont = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(147, 62);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 95);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择单词文件导入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(505, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 95);
            this.button2.TabIndex = 1;
            this.button2.Text = "输入单词文本";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(1393, 62);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(219, 95);
            this.button3.TabIndex = 2;
            this.button3.Text = "导出分析结果";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 184);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(779, 748);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "在此输入单词文本";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(1094, 62);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(219, 95);
            this.button4.TabIndex = 4;
            this.button4.Text = "开始分析";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(959, 326);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(779, 605);
            this.textBox2.TabIndex = 5;
            // 
            // buttonn
            // 
            this.buttonn.Location = new System.Drawing.Point(1115, 184);
            this.buttonn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonn.Name = "buttonn";
            this.buttonn.Size = new System.Drawing.Size(50, 35);
            this.buttonn.TabIndex = 6;
            this.buttonn.Text = "-n";
            this.buttonn.UseVisualStyleBackColor = true;
            this.buttonn.Click += new System.EventHandler(this.buttonn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(959, 230);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = "命令参数";
            // 
            // buttonw
            // 
            this.buttonw.Location = new System.Drawing.Point(1189, 184);
            this.buttonw.Margin = new System.Windows.Forms.Padding(4);
            this.buttonw.Name = "buttonw";
            this.buttonw.Size = new System.Drawing.Size(50, 35);
            this.buttonw.TabIndex = 8;
            this.buttonw.Text = "-w";
            this.buttonw.UseVisualStyleBackColor = true;
            this.buttonw.Click += new System.EventHandler(this.buttonw_Click);
            // 
            // buttonm
            // 
            this.buttonm.Location = new System.Drawing.Point(1263, 184);
            this.buttonm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonm.Name = "buttonm";
            this.buttonm.Size = new System.Drawing.Size(50, 35);
            this.buttonm.TabIndex = 9;
            this.buttonm.Text = "-m";
            this.buttonm.UseVisualStyleBackColor = true;
            this.buttonm.Click += new System.EventHandler(this.buttonm_Click);
            // 
            // buttonc
            // 
            this.buttonc.Location = new System.Drawing.Point(1115, 230);
            this.buttonc.Margin = new System.Windows.Forms.Padding(4);
            this.buttonc.Name = "buttonc";
            this.buttonc.Size = new System.Drawing.Size(50, 35);
            this.buttonc.TabIndex = 10;
            this.buttonc.Text = "-c";
            this.buttonc.UseVisualStyleBackColor = true;
            this.buttonc.Click += new System.EventHandler(this.buttonc_Click);
            // 
            // buttonh
            // 
            this.buttonh.Location = new System.Drawing.Point(1189, 230);
            this.buttonh.Margin = new System.Windows.Forms.Padding(4);
            this.buttonh.Name = "buttonh";
            this.buttonh.Size = new System.Drawing.Size(50, 35);
            this.buttonh.TabIndex = 11;
            this.buttonh.Text = "-h";
            this.buttonh.UseVisualStyleBackColor = true;
            this.buttonh.Click += new System.EventHandler(this.buttonh_Click);
            // 
            // buttont
            // 
            this.buttont.Location = new System.Drawing.Point(1263, 230);
            this.buttont.Margin = new System.Windows.Forms.Padding(4);
            this.buttont.Name = "buttont";
            this.buttont.Size = new System.Drawing.Size(50, 35);
            this.buttont.TabIndex = 12;
            this.buttont.Text = "-t";
            this.buttont.UseVisualStyleBackColor = true;
            this.buttont.Click += new System.EventHandler(this.buttont_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1115, 276);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 35);
            this.button8.TabIndex = 13;
            this.button8.Text = "-r";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1341, 200);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(312, 30);
            this.textBox3.TabIndex = 14;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1428, 256);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 35);
            this.button5.TabIndex = 15;
            this.button5.Text = "清空命令参数";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1857, 1081);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.buttont);
            this.Controls.Add(this.buttonh);
            this.Controls.Add(this.buttonc);
            this.Controls.Add(this.buttonm);
            this.Controls.Add(this.buttonw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "最长单词链分析软件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonw;
        private System.Windows.Forms.Button buttonm;
        private System.Windows.Forms.Button buttonc;
        private System.Windows.Forms.Button buttonh;
        private System.Windows.Forms.Button buttont;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox4;
    }
}

