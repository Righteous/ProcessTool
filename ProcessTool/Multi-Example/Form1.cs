using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Multi_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListProcesses();
        }

        public void ListProcesses()
        {
            Process[] CurrentProcesses = Process.GetProcesses();
            foreach(Process TheProcesses in CurrentProcesses)
            {
                ListViewItem add = new ListViewItem(TheProcesses.Id.ToString());
                add.SubItems.Add(TheProcesses.ProcessName.ToString());
                listView1.Items.Add(add);
            }
        }

        private void killProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string ProcessToKill = listView1.SelectedItems[0].SubItems[1].Text;
                DialogResult ConfirmKill = MessageBox.Show("Do you wanna kill the process [" + ProcessToKill + "]", "Kill Process Confirmation", MessageBoxButtons.YesNo);
                if (ConfirmKill == DialogResult.Yes)
                {
                    try
                    {
                        Process[] KillProcess = Process.GetProcessesByName(ProcessToKill);
                        foreach (Process MultiProcess in KillProcess)
                        {
                            MultiProcess.Kill();
                        }
                        listView1.Items.Clear();
                        ListProcesses();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Process Kill Aborted");
                }
            }
        }

        private void refreshToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ListProcesses();
        }
    }
}
