using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using LinqData;
using System.Configuration;

namespace RegisterUI
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void getdata_Click(object sender, EventArgs e)
        {
            Loader.GetData(input, output, new Student());
            
        }

    }
}
