using System.Windows.Forms.DataVisualization.Charting;
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
    public partial class FormImportarProvas : MetroForm
    {
        private List<ItemImportacao> vetItensImportacao;

        public Instituicao escolaAtual;

        public FormImportarProvas()
        {
            InitializeComponent();

            comboEscola.Items.Clear();
            foreach (var escola in Instituicao.obterTodos())
            {
                comboEscola.Items.Add(escola);
            }

            comboEscola.DisplayMember = "Nome";

            CustomPanel panelNovo = new CustomPanel();
            panelNovo.AutoScroll = true;
            panelNovo.Size = new Size(972, 357);
            panelNovo.Visible = true;
            panelNovo.PerformLayout();

            panel1.Controls.Add(panelNovo);
            panelNovo.Controls.Add(gridTotal);
            this.Refresh();

        }

        #region importarProva

        private void btnSelecaoBancoProva_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;

            dialog.CheckPathExists = true;
            dialog.Multiselect = true;
            dialog.Title = "Selecione os Bancos de Origem";
            int altura = 0;

            DialogResult result = dialog.ShowDialog();

            Instituicao escola = new Instituicao();
            if (comboEscola.SelectedIndex >= 0)
            {
                escola = comboEscola.SelectedItem as Instituicao;
                escolaAtual = escola;
            }
            else
            {
                ((Master)MdiParent).MensagemAlerta("Selecione uma Escola");
                return;
            }

            if (result.Equals(DialogResult.OK))
            {
                string[] filesNames = dialog.FileNames;

                vetItensImportacao = new List<ItemImportacao>();

                gridTotal.Columns.Clear();
                gridTotal.Rows.Clear();

                gridTotal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridTotal.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);


                gridTotal.RowHeadersVisible = false;
                gridTotal.AllowUserToAddRows = false;

                gridTotal.Columns.Add("Col0", "importado");
                gridTotal.Columns.Add("Col1", "Arquivo");
                gridTotal.Columns.Add("Col2", "Aluno Prova");
                gridTotal.Columns.Add("Col3", "Questionario");

                DataGridViewComboBoxColumn colunaComboTurma = new DataGridViewComboBoxColumn();
                colunaComboTurma.Width = 400;
                colunaComboTurma.ValueMember = "idturma";
                colunaComboTurma.DisplayMember = "Nome";
                colunaComboTurma.HeaderText = "Seleção Turma";
                gridTotal.Columns.Add(colunaComboTurma);

                DataGridViewComboBoxColumn colunaComboAlunos = new DataGridViewComboBoxColumn();
                colunaComboAlunos.Width = 400;
                colunaComboAlunos.ValueMember = "idAluno";
                colunaComboAlunos.DisplayMember = "Nome";
                colunaComboAlunos.HeaderText = "Seleção Aluno";
                gridTotal.Columns.Add(colunaComboAlunos);

                gridTotal.EditingControlShowing += gridTotal_EditingControlShowing;

                


                foreach (var fileName in filesNames)
                {
                    if (File.Exists(fileName))
                    {
                        ItemImportacao item = new ItemImportacao();

                        bool sucesso = Gerenciador.inicializaBancoImporatar(fileName);

                        if (sucesso)
                        {
                            List<Questionario> vetQuestionarios = Gerenciador.retornaQUestionariosImportacao();

                            if (vetQuestionarios.Count <= 0)
                            {
                                ((Master)MdiParent).MensagemAlerta("Esse banco não contém questionários. Banco:" + fileName);
                                gridTotal.Rows.Clear();
                                vetItensImportacao.Clear();
                                return;
                            }

                            Aluno aluno = Gerenciador.retornaAlunoImportacao();

                            if (aluno == null)
                            {
                                ((Master)MdiParent).MensagemAlerta("Esse banco não contém resultados. Banco: " + fileName);
                                vetItensImportacao.Clear();
                                gridTotal.Rows.Clear();
                                return;
                            }
                            else
                            {
                                Questionario questionario = vetQuestionarios[0];

                                Questionario questionarioDestino =
                                    Questionario.obterTodos()
                                        .Find(q => q.idQuestionario.Equals(questionario.idBase));

                                if (questionarioDestino == null)
                                {
                                    ((Master)MdiParent).MensagemAlerta("Esse banco contém uma prova que não existe no sistema. Banco: " + fileName);
                                    vetItensImportacao.Clear();
                                    gridTotal.Rows.Clear();
                                    return;
                                }

                                string nomeQuestionario = questionarioDestino.Nome;


                                int indexOfLastSep = fileName.LastIndexOf(@"\") + 1;

                                string nomeFormatado = fileName.Substring(indexOfLastSep);

                                int indexPrimeiroDivisor = nomeFormatado.IndexOf("_", nomeFormatado.IndexOf("_") + 1);
                                int indexSegundoDivisor = nomeFormatado.IndexOf("_", indexPrimeiroDivisor + 1);

                                string nomeTurma = "";

                                if (indexPrimeiroDivisor == -1 || indexSegundoDivisor == -1)
                                {
                                    nomeTurma = "";
                                }
                                else
                                {
                                    nomeTurma = nomeFormatado.Substring(indexPrimeiroDivisor + 1,
                                        (indexSegundoDivisor - indexPrimeiroDivisor) - 1);
                                }


                                gridTotal.Rows.Add("Não", nomeFormatado, aluno.Nome, nomeQuestionario);

                                (gridTotal.Rows[gridTotal.Rows.Count - 1].Cells[4] as DataGridViewComboBoxCell)
                                       .DataSource = escola.Turma.ToList();

                                // Tem o nome da turma
                                if (!String.IsNullOrEmpty(nomeTurma))
                                {
                                    Turma turma = escola.Turma.ToList().Find(t => t.Nome.Replace("_", "").Equals(nomeTurma));

                                    if (turma != null)
                                    {
                                        (gridTotal.Rows[gridTotal.Rows.Count - 1].Cells[4] as DataGridViewComboBoxCell)
                                            .Value = turma.idTurma;

                                        (gridTotal.Rows[gridTotal.Rows.Count - 1].Cells[5] as DataGridViewComboBoxCell)
                                            .DataSource = turma.Aluno.ToList();

                                        // Se tiver o nome do aluno no arquivo tenta já selecionar o aluno na combo
                                        int indexPrimeiroDivisorAluno = nomeFormatado.IndexOf("_", indexSegundoDivisor + 1);
                                        int indexSegundoDivisorAluno = nomeFormatado.IndexOf("_", indexPrimeiroDivisorAluno + 1);

                                        string nomeAluno = "";

                                        if (indexPrimeiroDivisorAluno == -1 || indexSegundoDivisorAluno == -1)
                                        {
                                            nomeAluno = "";
                                        }
                                        else
                                        {
                                            nomeAluno = nomeFormatado.Substring(indexPrimeiroDivisorAluno + 1,
                                                (indexSegundoDivisorAluno - indexPrimeiroDivisorAluno) - 1);
                                        }

                                        if (!String.IsNullOrEmpty(nomeAluno))
                                        {
                                            nomeAluno = nomeAluno.ToLower().Trim();

                                            Aluno alunoCombo =
                                                turma.Aluno.ToList()
                                                    .Find(
                                                        a => a.Nome.Replace("_", "").ToLower().Trim().Equals(nomeAluno));

                                            if (alunoCombo != null)
                                            {
                                                (gridTotal.Rows[gridTotal.Rows.Count - 1].Cells[5] as DataGridViewComboBoxCell)
                                                     .Value = alunoCombo.idAluno;
                                            }
                                        }
                                    }
                                }

                                altura += 23;

                                item.questionarioLocal = questionarioDestino;
                                item.questionarioProva = questionario;
                                item.alunoProva = aluno;
                                item.caminhoBanco = fileName;

                                vetItensImportacao.Add(item);
                            }
                        }
                        else
                        {
                            ((Master)MdiParent).MensagemAlerta("Banco inválido: " + fileName);
                            vetItensImportacao.Clear();
                            gridTotal.Rows.Clear();
                        }
                    }
                    else
                    {
                        ((Master)MdiParent).MensagemAlerta("Selecione Bancos válidos (Arquivos DBQUEST). Problema com o arquivo: " + fileName);
                        vetItensImportacao.Clear();
                        gridTotal.Rows.Clear();
                    }
                }

                pnlDestinoProva.Enabled = true;
              //  pnlDestinoProva.AutoScroll = true;
                
                btnImportarProva.Enabled = true;

               // panel1.Height = altura + 30;
                gridTotal.Height = altura+ 30;

                pnlDestinoProva.Refresh();
            }
        }

        private void gridTotal_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gridTotal.CurrentCell.ColumnIndex == 4 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var currentcell = gridTotal.CurrentCellAddress;
            var sendingCB = sender as DataGridViewComboBoxEditingControl;

            if (currentcell.X == 4)
            {
                string nomeTurmaSelecionada = sendingCB.EditingControlFormattedValue.ToString();

                Turma turma = escolaAtual.Turma.ToList().Find(t => t.Nome.Equals(nomeTurmaSelecionada));

                if (turma != null)
                {
                    (gridTotal.Rows[currentcell.Y].Cells[4] as DataGridViewComboBoxCell)
                        .Value = turma.idTurma;

                    (gridTotal.Rows[currentcell.Y].Cells[5] as DataGridViewComboBoxCell).Value = null;

                    if (turma.Aluno != null && turma.Aluno.Count > 0)
                    {
                        (gridTotal.Rows[currentcell.Y].Cells[5] as DataGridViewComboBoxCell)
                            .DataSource = turma.Aluno.ToList();
                    }
                }
            }
        }

        private void btnImportarProva_Click(object sender, EventArgs e)
        {
            string mensagemFinal = "";

            if (vetItensImportacao.Count == 0)
            {
                ((Master)MdiParent).MensagemAlerta("Selecione arquivos para importar." + " Nenhuma importação realizada");
                return;
            }

            int indiceGrid = 0;
            foreach (var itemImportacao in vetItensImportacao)
            {
                var idTurmaSelecionado = (gridTotal.Rows[indiceGrid].Cells[4] as DataGridViewComboBoxCell).Value;

                if (idTurmaSelecionado == null)
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione uma Turma para cada arquivo para importar a prova!" + " Nenhuma importação realizada");
                    return;
                }

                var idAlunoSelecionado = (gridTotal.Rows[indiceGrid].Cells[5] as DataGridViewComboBoxCell).Value;

                if (idAlunoSelecionado == null)
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione um Aluno para cada arquivo para importar a prova!" + " Nenhuma importação realizada");
                    return;
                }


                Turma turma = escolaAtual.Turma.ToList().Find(t => t.idTurma.Equals(idTurmaSelecionado));

                int idAluno = Convert.ToInt32(idAlunoSelecionado);

                Aluno alunoParaImportar = turma.Aluno.ToList().Find(a => a.idAluno == idAluno);

                if (alunoParaImportar == null)
                {
                    ((Master)MdiParent).MensagemAlerta("Erro ao importar: " + itemImportacao.caminhoBanco + " Aluno Selecionado para importar não foi encontrado. " + " Nenhuma importação realizada");
                    return;
                }
            }

            indiceGrid = 0;
            string arquivosImportados = "";
            foreach (var itemImportacao in vetItensImportacao)
            {
                var idTurmaSelecionado = (gridTotal.Rows[indiceGrid].Cells[4] as DataGridViewComboBoxCell).Value;
                var idAlunoSelecionado = (gridTotal.Rows[indiceGrid].Cells[5] as DataGridViewComboBoxCell).Value;

                int idAluno = Convert.ToInt32(idAlunoSelecionado);
                int idTurma = Convert.ToInt32(idTurmaSelecionado);

                Turma turma = escolaAtual.Turma.ToList().Find(t => t.idTurma.Equals(idTurma));

                Aluno alunoParaImportar = turma.Aluno.ToList().Find(a => a.idAluno == idAluno);

                bool sucessoInit = Gerenciador.inicializaBancoImporatar(itemImportacao.caminhoBanco);

                bool sucessoArquivoAtual = true;

                if (sucessoInit)
                {
                    Aluno alunoLocal = alunoParaImportar;
                    string mensagem;

                    bool sucesso = Gerenciador.importarProva(alunoLocal, itemImportacao.alunoProva, itemImportacao.questionarioLocal, itemImportacao.questionarioProva, out mensagem);

                    if (!sucesso)
                    {
                        if (String.IsNullOrEmpty(mensagem))
                        {
                            sucessoArquivoAtual = false;
                            mensagemFinal += " - Erro ao importar arquivo: " + itemImportacao.caminhoBanco + "\r\n";
                        }
                        else
                        {
                            sucessoArquivoAtual = false;
                            mensagemFinal += " - " + mensagem + " Arquivo: " + itemImportacao.caminhoBanco + "\r\n";
                        }
                    }
                }
                else
                {
                    sucessoArquivoAtual = false;
                    mensagemFinal += " - Erro ao importar arquivo: " + itemImportacao.caminhoBanco + "\r\n";
                }

                int indexOfLastSep = itemImportacao.caminhoBanco.LastIndexOf(@"\") + 1;

                string nomeFormatado = itemImportacao.caminhoBanco.Substring(indexOfLastSep);

                if (sucessoArquivoAtual)
                {
                    arquivosImportados += nomeFormatado + ", ";
                    gridTotal.Rows[indiceGrid].Cells[0].Value = "Sim";
                    gridTotal.Refresh();
                }

                indiceGrid++;
            }

            if (String.IsNullOrEmpty(mensagemFinal))
            {
                ((Master) MdiParent).MensagemSucesso("Todos os arquivos foram importados com sucesso!");
            }
            else
            {
                ((Master)MdiParent).MensagemAlerta(mensagemFinal);
            }
        }

        #endregion

        private void lblTurma_Click(object sender, EventArgs e)
        {

        }

        private void comboEscola_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEscola.SelectedIndex >= 0)
            {
                btnSelecaoBancoProva.Enabled = true;
            }
            else
            {
                btnSelecaoBancoProva.Enabled = false;
            }
        }
    }

    internal class ItemImportacao
    {
        public Aluno alunoProva { get; set; }
        public Aluno alunoLocal { get; set; }

        public string caminhoBanco { get; set; }

        public Questionario questionarioLocal { get; set; }

        public Questionario questionarioProva { get; set; }
    }

    public class CustomPanel : System.Windows.Forms.Panel
    {
        protected override System.Drawing.Point ScrollToControl(System.Windows.Forms.Control activeControl)
        {
            // Returning the current location prevents the panel from
            // scrolling to the active control when the panel loses and regains focus
            return this.DisplayRectangle.Location;
        }
    }
}
