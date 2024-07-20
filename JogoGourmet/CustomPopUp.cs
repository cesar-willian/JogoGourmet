using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmet
{
    public partial class CustomPopUp : Form
    {
        public string CustomResult { get; set; }
        public CustomPopUp(string message, string title)
        {
            InitializeComponent();

            this.lblMessage.Text = message;
            this.Text = title;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CustomResult = txtResult.Text;
            this.Close();
        }
    }
}
