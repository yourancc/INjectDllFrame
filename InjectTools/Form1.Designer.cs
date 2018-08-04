namespace InjectTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.text_filepath = new System.Windows.Forms.TextBox();
            this.button_file_path = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.text_dllpath = new System.Windows.Forms.TextBox();
            this.button_dll_path = new System.Windows.Forms.Button();
            this.Dialog_GamaPath = new System.Windows.Forms.OpenFileDialog();
            this.Dialog_DllPath = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.text_debug = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "游戏路径:";
            // 
            // text_filepath
            // 
            this.text_filepath.Font = new System.Drawing.Font("宋体", 15F);
            this.text_filepath.Location = new System.Drawing.Point(118, 12);
            this.text_filepath.Name = "text_filepath";
            this.text_filepath.Size = new System.Drawing.Size(542, 30);
            this.text_filepath.TabIndex = 6;
            this.text_filepath.Text = "D:\\Users\\cc.cc-PC.000\\Desktop\\测试.exe";
            // 
            // button_file_path
            // 
            this.button_file_path.Location = new System.Drawing.Point(666, 12);
            this.button_file_path.Name = "button_file_path";
            this.button_file_path.Size = new System.Drawing.Size(34, 30);
            this.button_file_path.TabIndex = 5;
            this.button_file_path.Text = "..";
            this.button_file_path.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button_file_path.UseVisualStyleBackColor = true;
            this.button_file_path.Click += new System.EventHandler(this.button_file_path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "DLL路径:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // text_dllpath
            // 
            this.text_dllpath.Font = new System.Drawing.Font("宋体", 15F);
            this.text_dllpath.Location = new System.Drawing.Point(118, 58);
            this.text_dllpath.Name = "text_dllpath";
            this.text_dllpath.Size = new System.Drawing.Size(542, 30);
            this.text_dllpath.TabIndex = 9;
            this.text_dllpath.Text = "D:\\Users\\cc.cc-PC.000\\Desktop\\SimpleDll.dll";
            // 
            // button_dll_path
            // 
            this.button_dll_path.Location = new System.Drawing.Point(666, 58);
            this.button_dll_path.Name = "button_dll_path";
            this.button_dll_path.Size = new System.Drawing.Size(34, 30);
            this.button_dll_path.TabIndex = 8;
            this.button_dll_path.Text = "..";
            this.button_dll_path.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button_dll_path.UseVisualStyleBackColor = true;
            this.button_dll_path.Click += new System.EventHandler(this.button_dll_path_Click);
            // 
            // Dialog_GamaPath
            // 
            this.Dialog_GamaPath.FileName = "Dialog_GamaPath";
            this.Dialog_GamaPath.FileOk += new System.ComponentModel.CancelEventHandler(this.Dialog_GamaPath_FileOk);
            // 
            // Dialog_DllPath
            // 
            this.Dialog_DllPath.FileName = "Dialog_GamaPath";
            this.Dialog_DllPath.FileOk += new System.ComponentModel.CancelEventHandler(this.Dialog_DllPath_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "远程线程注入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_debug
            // 
            this.text_debug.Location = new System.Drawing.Point(169, 117);
            this.text_debug.Multiline = true;
            this.text_debug.Name = "text_debug";
            this.text_debug.Size = new System.Drawing.Size(455, 197);
            this.text_debug.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "全局HOOK注入";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 375);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.text_debug);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_dllpath);
            this.Controls.Add(this.button_dll_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_filepath);
            this.Controls.Add(this.button_file_path);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_filepath;
        private System.Windows.Forms.Button button_file_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_dllpath;
        private System.Windows.Forms.Button button_dll_path;
        private System.Windows.Forms.OpenFileDialog Dialog_GamaPath;
        private System.Windows.Forms.OpenFileDialog Dialog_DllPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox text_debug;
        private System.Windows.Forms.Button button2;
    }
}

