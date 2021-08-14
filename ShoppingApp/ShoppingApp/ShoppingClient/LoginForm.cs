using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingClient
{
    public partial class LoginForm : Form
    {
        private readonly IShoppingClient m_clientdata;
        public LoginForm(IShoppingClient clientdata)
        {
            InitializeComponent();
            m_clientdata = clientdata;
            Connectbtn.Enabled = false;
        }

        private async void Connectbtn_Click(object sender, EventArgs e)
        {
            string readline = string.Empty;
            try
            {
                Connectbtn.Enabled = AccNoTxtBox.Enabled = false;
                if (!m_clientdata.IsClosed && HostNaTxtBox.Text != m_clientdata.HostName && AccNoTxtBox.Text != m_clientdata.AccountNu.ToString())
                {
                    m_clientdata.Exit();
                }

                if (m_clientdata.IsClosed)
                {
                    int accNo;
                    m_clientdata.HostName = HostNaTxtBox.Text;
                    if (int.TryParse(AccNoTxtBox.Text, out accNo))
                    {

                        m_clientdata.Start();
                        m_clientdata.AccountNu = accNo;
                        await m_clientdata.LoginForm(accNo);
                        readline = m_clientdata.Connectionstatus;

                    }
                    else 
                    {
                        readline = "CONNECT_ERROR";
                    }
                }
                

                Connectbtn.Enabled = AccNoTxtBox.Enabled = true;
                
                //readline = m_clientdata.Connectionstatus;
                if (readline == null)
                {
                    MessageBox.Show("Server Unavailable", "Server Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else if ("CONNECT_ERROR" == readline)
                {
                    MessageBox.Show("The Account No is not valid.", "Client Number Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
               
                else if (readline != "CONNECT_ERROR" )
                {
                    LoginForm.ActiveForm.Hide();
                    PurchaseForm frm = new PurchaseForm(m_clientdata);
                    frm.Show();
                }

            }
            catch (InvalidOperationException)
            {
                if (!m_clientdata.IsClosed)
                    MessageBox.Show("Already Connected", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }

        private void AccNoTxtBox_TextChanged(object sender, EventArgs e)
        {
            Connectbtn.Enabled = (!string.IsNullOrEmpty(AccNoTxtBox.Text));
        }
    }
}
