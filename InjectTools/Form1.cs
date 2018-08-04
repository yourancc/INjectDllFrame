using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.youran.cheat;
namespace InjectTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_file_path_Click(object sender, EventArgs e)
        {
            Dialog_GamaPath.ShowDialog();
        }

        private void button_dll_path_Click(object sender, EventArgs e)
        {
            Dialog_DllPath.ShowDialog();
        }

        private void Dialog_GamaPath_FileOk(object sender, CancelEventArgs e)
        {
            text_filepath.Text = Dialog_GamaPath.FileName;
        }

        private void Dialog_DllPath_FileOk(object sender, CancelEventArgs e)
        {
            text_dllpath.Text = Dialog_DllPath.FileName;
        }
        /// <summary>
        /// 使用远程线程的方式注入模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //int hwnd = (int)plug.FindWindow("测试", "测试窗口");
            int hwnd = (int)plug.FindWindow("EOSUnrealWWindowsViewportWindow", "战神之路");
            text_debug.Text = "窗口句柄：" + hwnd.ToString() + "\r\n";
            Text = text_debug.Text + "模块路径：" + text_dllpath.Text + "\n";
            bool flag = plug.DLLTools.injectDllByRemoteThread(hwnd,text_dllpath.Text);
            if (!flag)
            {
                int flagmath = plug.GetLastError();
                text_debug.Text = text_debug.Text + "错误代码：" + flagmath.ToString() + "\n";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
