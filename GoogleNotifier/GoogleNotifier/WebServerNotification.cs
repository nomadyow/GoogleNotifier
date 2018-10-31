using System;
using System.Windows.Forms;


namespace GoogleNotifier
{
    public partial class FormWebServerNotification : Form
    {
        public FormWebServerNotification()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
