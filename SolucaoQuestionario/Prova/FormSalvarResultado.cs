using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Prova
{
    public partial class FormSalvarResultado : MetroFramework.Forms.MetroForm
    {
        private string nome;
        public bool exportou;

        public FormSalvarResultado(string nome, string aluno)
        {
            InitializeComponent();

            lblAlunoExportado.Text = aluno;

            txtSenha.PasswordChar = '*';
            this.nome = nome;


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text == "abc@!")
            {

                FolderBrowserDialog dialogSalva = new FolderBrowserDialog();
                
                DialogResult resultadoSalva = dialogSalva.ShowDialog();

                string path = ConfigurationManager.AppSettings["diretorio"];

                if (resultadoSalva == DialogResult.OK)
                {

                    string nomeSalva = dialogSalva.SelectedPath;
                    path = nomeSalva;
                }  
                else
                {
                    return;
                }
                            

                if (!Directory.Exists(path + "\\Resultados"))
                {
                    Directory.CreateDirectory(path + "\\Resultados");
                }

                string prova = ConfigurationManager.AppSettings["avalFullPath"];
                string dbquest = prova + ConfigurationManager.AppSettings["dbquest"];

                if (Directory.Exists(prova))
                {
                    if (File.Exists(dbquest))
                    {
                        File.Copy(dbquest, path + "\\Resultados\\" + nome,true);
                        
                        Controlador.getControlador().apagarProvaAtual();

                        exportou = true;
                        this.Activate();
                        lblSalvou.Visible = true;
                        lblSalvou.Text = "Resultados salvos em:\n" + path + "\\Resultados\nArquivo: " + nome + "\nPara enviar clique nesse link:";
                        lblLink.Visible = true;
                        lblSenha.Visible = false;
                        lblAlunoExportado.Visible = false;
                        txtSenha.Enabled = false;
                        txtSenha.Visible = false;
                        btnSalvar.Enabled = false;
                        btnFechar.Focus();

                    }
                }
            }
            else
            {
                MessageBox.Show("Senha inválida.");
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.PerformClick();
            }
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFechar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://canal.corujaedu.com.br/course/view.php?id=2#module-55");
                Close();
            }
            catch { }
        }
    }
}
