using System.DirectoryServices.ActiveDirectory;
using Library.Persistencia;
using MetroFramework.Forms;
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

namespace QuestionarioForms
{
    public partial class FormImportar : MetroForm
    {
        private Aluno alunoProva;
        private Questionario questionarioLocal;
        private Questionario questionarioProva;

        public FormImportar()
        {
            InitializeComponent();

            btnImportarQuestoes.Select();

            comboQuestionarioDestino.Items.Clear();

            foreach (var quest in Questionario.obterTodos().OrderBy(o => o.Nome))
            {
                comboQuestionarioDestino.Items.Add(quest);
            }

            comboQuestionarioDestino.DisplayMember = "Nome";
        }

        #region Importar Questoes

        private void btnSelecaoBancoQuestao_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            //dialog.FileName = "DBQUEST";
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            dialog.Title = "Selecione o Banco de Origem";

            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                string caminho = dialog.FileName;

                if (!caminho.EndsWith("DBQUEST"))
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione um Banco válido (Arquivo DBQUEST).");
                    return;
                }

                if (File.Exists(caminho))
                {
                    bool sucesso = Gerenciador.inicializaBancoImporatar(caminho);

                    if (sucesso)
                    {
                        List<Questionario> vetQuestionarios = Gerenciador.retornaQUestionariosImportacao();

                        if (vetQuestionarios.Count <= 0)
                        {
                            ((Master)MdiParent).MensagemAlerta("Esse banco não contém questionários.");
                            return;
                        }


                        comboQuestionarioQuestao.Items.Clear();

                        foreach (var quest in vetQuestionarios.OrderBy(o => o.Nome))
                        {
                            comboQuestionarioQuestao.Items.Add(quest);
                        }

                        comboQuestionarioQuestao.DisplayMember = "Nome";
                        pnlAbrirBancoQuestao.Enabled = true;
                    }
                    else
                    {
                        ((Master) MdiParent).MensagemAlerta("Selecione um Banco válido (Arquivo DBQUEST).");
                    }
                }
                else
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione um Banco válido (Arquivo DBQUEST).");
                }
            }
        }

        private void btnImportarQuestoes_Click(object sender, EventArgs e)
        {
            List<Questao> vetQuestoesMarcadas = new List<Questao>();

            for (int i = 0; i < ckListQuestoes.Items.Count; i++)
            {
                if (ckListQuestoes.GetItemChecked(i))
                {
                    vetQuestoesMarcadas.Add(ckListQuestoes.Items[i] as Questao);
                }
            }

            if (vetQuestoesMarcadas.Count == 0)
            {
                ((Master)MdiParent).MensagemAlerta("Selecione pelo menos uma questão para importar.");
                return;
            }

            if (comboQuestionarioDestino.SelectedIndex < 0)
            {
                ((Master)MdiParent).MensagemAlerta("Selecione um questionário de destino.");
                return;
            }

            foreach (var questao in vetQuestoesMarcadas)
            {
                string caminhoQuestao = Gerenciador._caminhoImportar + questao.idBase.ToString() + "\\";

                if (!Directory.Exists(caminhoQuestao))
                {
                    ((Master)MdiParent).MensagemErro("A questão de ordem: " + questao.Ordem + ", identificador: " + questao.idQuestao +" não está com seus arquivos na mesma pasta do banco.");
                    return;
                }
            }

            Questionario questionarioLocal = (Questionario)comboQuestionarioDestino.SelectedItem;

            List<Questao> vetQuestoesNovas;

            bool manterOrdemOrigem = ckManterOrdem.Checked;

            bool sucesso = Gerenciador.importarQuestoes(vetQuestoesMarcadas, questionarioLocal, out vetQuestoesNovas, manterOrdemOrigem);

            if (sucesso)
            {
                foreach (var questao in vetQuestoesMarcadas)
                {
                    string origem = Gerenciador._caminhoImportar + questao.idBase.ToString() + "\\";

                    Questao questaoNova = vetQuestoesNovas.Find(q => q.idBase.Equals(questao.idQuestao));

                    string destino = questaoNova.Diretorio;

                    DirectoryCopy(origem, destino, true);
                }

                // Copia os videos
                DirectoryInfo dir = new DirectoryInfo(Gerenciador._caminhoImportar);
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Name.StartsWith("Video"))
                    {
                        string temppath = Path.Combine(questionarioLocal.Diretorio, file.Name);
                        file.CopyTo(temppath, true);
                    }
                    
                }

                Gerenciador.limparImportacao(vetQuestoesNovas);

                ((Master)MdiParent).MensagemSucesso("Questões importadas!");
            }
            else
            {
                ((Master)MdiParent).MensagemErro("Erro ao importar as questões!");
            }
        }

        private void comboQuestionarioQuestao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboQuestionarioQuestao.SelectedIndex >= 0)
            {
                Questionario questionario = (Questionario)comboQuestionarioQuestao.SelectedItem;

                ckListQuestoes.Items.Clear();

                try
                {
                    foreach (var quest in questionario.Questao.OrderBy(o => o.Ordem))
                    {
                        ckListQuestoes.Items.Add(quest);
                    }
                }
                catch (Exception)
                {
                    ((Master)MdiParent).MensagemErro("Erro! Banco de Origem inválido! ");
                    comboQuestionarioQuestao.SelectedIndex = -1;
                    return;
                }

                ckListQuestoes.DisplayMember = "NomeTela";
            }
        }

        private void ckMarcarQUestoes_CheckedChanged(object sender, EventArgs e)
        {
            bool marcar = ckMarcarQUestoes.Checked;

            for (int i = 0; i < ckListQuestoes.Items.Count; i++)
            {
                ckListQuestoes.SetItemChecked(i, marcar);
            }
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
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
                    DirectoryCopy(subdir.FullName, temppath, true);
                }
            }
        }

        #endregion
   

        #region importarProva

        private void btnSelecaoBancoProva_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            //dialog.FileName = "DBQUEST";
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            dialog.Title = "Selecione o Banco de Origem";

            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                string caminho = dialog.FileName;

                //if (!caminho.EndsWith("DBQUEST"))
                //{
                //    ((Master)MdiParent).MensagemAlerta("Selecione um Banco válido (Arquivo DBQUEST).");
                //    return;
                //}

                if (File.Exists(caminho))
                {
                    bool sucesso = Gerenciador.inicializaBancoImporatar(caminho);

                    if (sucesso)
                    {
                        List<Questionario> vetQuestionarios = Gerenciador.retornaQUestionariosImportacao();

                        if (vetQuestionarios.Count <= 0)
                        {
                            ((Master)MdiParent).MensagemAlerta("Esse banco não contém questionários.");
                            return;
                        }


                        Aluno aluno = Gerenciador.retornaAlunoImportacao();

                        if (aluno == null)
                        {
                            ((Master)MdiParent).MensagemAlerta("Esse banco não contém resultados.");
                            return;
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(aluno.Nome))
                            {
                                lblNomeAlunoProva.Text = aluno.Nome;
                            }
                            else
                            {
                                lblNomeAlunoProva.Text = "Aluno não cadastrou nome na prova.";
                                
                            }
                        }

                        Questionario questionario = vetQuestionarios[0];

                        Questionario questionarioDestino =
                            Questionario.obterTodos()
                                .Find(q => q.idQuestionario.Equals(questionario.idBase));

                        lblNomeQuestionarioProva.Text = questionarioDestino.Nome;

                        comboTurma.Items.Clear();
                        foreach (var turma in Turma.obterTodos())
                        {
                            comboTurma.Items.Add(turma);
                        }

                        comboTurma.DisplayMember = "Nome";

                        pnlDestinoProva.Enabled = true;
                        alunoProva = aluno;
                        questionarioLocal = questionarioDestino;
                        questionarioProva = questionario;

                    }
                    else
                    {
                        ((Master)MdiParent).MensagemAlerta("Selecione um Banco válido (Arquivo DBQUEST).");
                    }
                }
                else
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione um Banco válido (Arquivo DBQUEST).");
                }
            }
        }

        private void comboTurma_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboTurma.SelectedIndex >= 0)
            {
                comboAluno.Items.Clear();
                foreach (var aluno in ((Turma)comboTurma.SelectedItem).Aluno.OrderBy(a => a.Nome))
                {
                    comboAluno.Items.Add(aluno);
                }

                comboAluno.DisplayMember = "Nome";
                comboAluno.Enabled = true;
            }
            else
            {
                comboAluno.Enabled = false;
                comboAluno.Items.Clear();
            }
        }

        private void btnImportarProva_Click(object sender, EventArgs e)
        {
            if ((comboTurma.SelectedIndex >= 0) && (comboAluno.SelectedIndex >= 0))
            {
                Aluno alunoLocal = comboAluno.SelectedItem as Aluno;
                string mensagem;

                bool sucesso = Gerenciador.importarProva(alunoLocal, alunoProva, questionarioLocal, questionarioProva, out mensagem);

                if (sucesso)
                {
                    ((Master)MdiParent).MensagemSucesso("Resultados da Prova importados!");
                }
                else
                {
                    if (String.IsNullOrEmpty(mensagem))
                    {
                        ((Master) MdiParent).MensagemErro("Erro ao importar os Resultados da Prova!");
                    }
                    else
                    {
                        ((Master)MdiParent).MensagemErro(mensagem);
                    }
                }
            }
            else
            {
                ((Master)MdiParent).MensagemAlerta("Selecione um Aluno para importar a prova!");
            }
        }

        #endregion
    }
}
