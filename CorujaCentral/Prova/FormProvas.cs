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
using System.IO;
using Prova;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Text.RegularExpressions;
using System.Security.AccessControl;

namespace Prova
{
    public partial class FormProvas : Form
    {

        public class VerificaPasta
        {
            public string[] Pasta(string path)
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    MessageBox.Show("Isso é um arquivo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    return Directory.GetDirectories(path,"Avaliação*");
                }
                else
                {
                    MessageBox.Show("Não é um diretório Valido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
        }


        public FormProvas()
        {
            InitializeComponent();

            string diretorio = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CorujaEdu";
            ConfigurationManager.AppSettings.Set("diretorio", diretorio);

            string local = ConfigurationManager.AppSettings["diretorio"];
            VerificaPasta ehPasta = new VerificaPasta();
            string[] pastas = ehPasta.Pasta(local);

            foreach (string pasta in pastas)
            {
                string[] arquivos = Directory.GetFiles(pasta + "\\", "DBQUEST*");
                foreach (string arquivo in arquivos)
                {
                    if (arquivo == pasta + "\\DBQUEST")
                    {
                        comboProvas.Items.AddRange(new object[] { pasta.Replace(local + "\\","") });
                    }
                    else
                    {
                        comboProvas.Items.AddRange(new object[]
                        {
                            pasta.Replace(local + "\\","") + " -" + arquivo.Replace(pasta + "\\DBQUEST","")
                        });
                    }
                }
            } 
        }

        private void comboProvas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Activate();            
            string diretorio = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CorujaEdu";
            string Provas = "";
            string DBQUESTS = "";
            if (comboProvas.SelectedItem.ToString().Split('-').Length == 1)
            {
                Provas = diretorio + "\\" + comboProvas.SelectedItem.ToString();
                DBQUESTS = "\\DBQUEST";
            }
            else
            {
                Provas = diretorio + "\\" + comboProvas.SelectedItem.ToString().Split('-')[0].Trim(' ');
                DBQUESTS = "\\DBQUEST" + comboProvas.SelectedItem.ToString().Split('-')[1];
            }
            ConfigurationManager.AppSettings.Set("diretorio", diretorio);
            ConfigurationManager.AppSettings.Set("dbquest", DBQUESTS);
        }

        private void btnOkProvas_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("escolheu", "1");
            
            Close();
        }

        private void comboProvas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnAbrir.Enabled = true;
        }

        private void FormProvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if(ConfigurationManager.AppSettings["escolheu"] != "1")
                {
                    ConfigurationManager.AppSettings.Set("escolheu", "0");
                }
            }
        }

        private void chkHabilitaRemocao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitaRemocao.Checked == true)
            {
                btnDeletar.Enabled = true;
            }
            else
            {
                btnDeletar.Enabled = false;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string diretorio = ConfigurationManager.AppSettings["diretorio"];
            string Provas = ConfigurationManager.AppSettings["avalFullPath"];
            string DBQUESTS = ConfigurationManager.AppSettings["dbquest"];
            string deleteFile = Provas + DBQUESTS;

            btnAbrir.Enabled = false;

            if(System.IO.File.Exists(deleteFile))
            {
                try
                {
                    
                    System.IO.File.Delete(deleteFile);
                    comboProvas.Items.Remove(comboProvas.SelectedItem.ToString());
                    if (Directory.GetFiles(Provas + "\\", "DBQUEST*").Count() == 0)
                    {
                        System.IO.Directory.Delete(Provas, true);
                    }
                }
                catch (System.IO.IOException ei)
                {
                    Console.WriteLine(ei.Message);
                }
            }
        }

        private void FormProvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboProvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnAbrir.Enabled)
            {
                ConfigurationManager.AppSettings.Set("escolheu", "1");
                Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
