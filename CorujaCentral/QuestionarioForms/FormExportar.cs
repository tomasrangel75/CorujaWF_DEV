using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Library.Persistencia;
using MetroFramework.Forms;

namespace QuestionarioForms
{
    public partial class FormExportar : MetroForm
    {
        public FormExportar()
        {
            InitializeComponent();

            carregar();
        }

        public void carregar()
        {
            comboQuestionario.Items.Clear();

            foreach (var quest in Questionario.obterTodos().OrderBy(o => o.Nome))
            {
                comboQuestionario.Items.Add(quest);
            }

            comboQuestionario.DisplayMember = "Nome";

            comboEscola.Items.Clear();
            foreach (var escola in Instituicao.obterTodos())
            {
                comboEscola.Items.Add(escola);
            }

            comboEscola.DisplayMember = "Nome";
        }

        private void comboQuestionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboQuestionario.SelectedIndex >= 0)
            {
                btnExportar.Enabled = true;
            }
            else
            {
                btnExportar.Enabled = false;
            }
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            ArgumentoExportacao argumento = new ArgumentoExportacao();


            if (comboQuestionario.SelectedIndex < 0)
            {
                ((Master)MdiParent).MensagemAlerta("Selecione um Questionário.");
                return;
            }

            List<Turma> vetTurmas = new List<Turma>();

            for (int i = 0; i < ckTurmas.Items.Count; i++)
            {
                if (ckTurmas.GetItemChecked(i))
                {
                    vetTurmas.Add(ckTurmas.Items[i] as Turma);
                }
            }

            argumento.vetTurmas = vetTurmas;

            Questionario questionario = ((Questionario)comboQuestionario.SelectedItem);
            argumento.questionario = questionario;

            progress.Maximum = 100;
            progress.Step = 1;
            progress.Value = 0;
            backgroundWorker1.RunWorkerAsync(argumento);
            backgroundWorker1.WorkerReportsProgress = true;
            
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, int? taxa)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            int? atualizacoa = taxa;

            if (atualizacoa == null)
            {
                int count = dirs.Count();

                atualizacoa = 85/count;
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }
            

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, true, atualizacoa);
                }

                backgroundWorker1.ReportProgress((int)atualizacoa);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value += e.ProgressPercentage;
        }

        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            DialogResult res = new DialogResult();
            string fileName = null;

            ArgumentoExportacao argumento = (ArgumentoExportacao)e.Argument;

            Questionario questionario = argumento.questionario;

            Invoke((MethodInvoker) delegate
            {
                SaveFileDialog dialog = new SaveFileDialog();
                res = dialog.ShowDialog();
                fileName = dialog.FileName;
            });

               

                if (res.Equals(DialogResult.OK))
                {

                    string nomePasta = fileName;

                    // Verificar o local do Banco
                    string localBancoAplicacao = AppDomain.CurrentDomain.BaseDirectory + "\\Banco\\DBQUEST";

                    string localBancoUsuario = nomePasta + "\\DBQUEST";

                    // Cria o Banco pela primeira vez se ele não existe ainda na maquina do usuario
                    if (!File.Exists(localBancoUsuario))
                    {
                        if (!Directory.Exists(nomePasta))
                        {
                            Directory.CreateDirectory(nomePasta);
                        }
                    }

                    // Cria o Banco de Dados para exportar
                    File.Copy(localBancoAplicacao, localBancoUsuario);

                    // Salva o questionario no Banco novo
                    Gerenciador.exportarBanco(questionario, argumento.vetTurmas, localBancoUsuario);

                    string pastaQuestionario = questionario.Diretorio;

                    backgroundWorker1.ReportProgress(15);

                    DirectoryCopy(pastaQuestionario, nomePasta, true, null);

                    Invoke((MethodInvoker)delegate
                    {
                        ((Master)MdiParent).MensagemSucesso("Questionário Exportado!");
                    });
                }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progress.Value = 0;
        }

        private void comboEscola_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEscola.SelectedIndex >= 0)
            {
                Instituicao escola = comboEscola.SelectedItem as Instituicao;

                if (escola.Turma.Count > 0)
                {
                    ckTurmas.Items.Clear();
                    ckTurmas.Enabled = true;

                    foreach (var turma in escola.Turma)
                    {
                        ckTurmas.Items.Add(turma);
                    }

                    ckTurmas.DisplayMember = "Nome";
                }
            }
            else
            {
                ckTurmas.Enabled = false;
            }
        }


    }

    public class ArgumentoExportacao
    {
        public Questionario questionario { get; set; }
        public List<Turma> vetTurmas { get; set; }
    }
}
