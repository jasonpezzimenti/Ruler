using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruler
{
    public partial class Authors : Form
    {
        public Authors()
        {
            InitializeComponent();

            listView1.ContextMenu = contextMenu1;
        }

        private void Authors_Shown(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();

            item.Text = "Resizing window";

            item.SubItems.Add("seyyed hamed monem");
            item.SubItems.Add("https://www.codeproject.com/Tips/709121/Move-and-Resize-Controls-on-a-Form-at-Runtime-With");
            item.SubItems.Add("https://www.codeproject.com/info/cpol10.aspx");
            item.SubItems.Add("13/05/2023");

            listView1.Items.Add(item);
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(listView1.Items[0].SubItems[2].Text);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Process.Start(listView1.Items[0].SubItems[3].Text);
        }
    }
}
