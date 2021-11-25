using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin
{
    public partial class Register : Form
    {
        Config db = new Config();
        public Register()
        {
            InitializeComponent();
            db.Connect("userdata");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string username = textBoxUsername1.Text;
            string password = textBoxPassword.Text;
            bool isInvalid = name.Equals("") || username.Equals("") || password.Equals("");

            if (isInvalid)
            {
                textBoxName.Focus();
                MessageBox.Show("Data tidak boleh kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = "Ingin register data?";
            string caption = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                db.Execute("INSERT INTO user_info (names, username, password) VALUES "
                    + "('" + textBoxName.Text + "', '" + textBoxUsername.Text + "', '" + textBoxPassword.Text + "')"
                );
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
