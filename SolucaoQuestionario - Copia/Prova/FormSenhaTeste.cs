using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Prova
{
    public partial class FormSenhaTeste : MetroFramework.Forms.MetroForm
    {
        private string nome;
        public bool exportou;

        public FormSenhaTeste()
        {
            InitializeComponent();

            txtSenha.PasswordChar = '*';


        }

        private void btnSenhaOk_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text == "testeabc@!")//testeabc@!
            {
                ConfigurationManager.AppSettings.Set("teste","1");
                Close();
            }
            else
            {
                MessageBox.Show("Senha inválida.");
                ConfigurationManager.AppSettings.Set("teste", "0");
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSenhaOk.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
