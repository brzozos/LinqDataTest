using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqData;

namespace RegisterUI
{
    public partial class Start : Form
    {
        public string ConnectionString { get; set; }
        private string text = null;
        public Start()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

            ConnectionString = DatabaseConnection.GetConnectionString("LocalTestDB");
        }

        private void Name_TextChanged(object sender, EventArgs e)
        {
            text = Name.Text;

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<dynamic> data = DatabaseConnection.ExecuteQuery($"Select * from STUDENT where NAME_STUDENT = \"{ text } \"", "LocalTestDB");

            output.Text = data.First();
        }
    }
}
