using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Persistencia;
using MetroFramework.Forms;
using System.IO;
using System.Drawing.Printing;

namespace QuestionarioForms
{
    public partial class FormRelatorioAluno : MetroForm
    {

        
        public FormRelatorioAluno()
        {
            InitializeComponent();

           


            comboTurma.Items.Clear();
            foreach (var turma in Turma.obterTodos())
            {
                comboTurma.Items.Add(turma);
            }

            comboTurma.DisplayMember = "Nome";
        }

        private void comboTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            limparTela();

            if (comboTurma.SelectedIndex >= 0)
            {
                Turma turma = comboTurma.SelectedItem as Turma;

                comboAluno.Items.Clear();
                foreach (var aluno in turma.Aluno)
                {
                    comboAluno.Items.Add(aluno);
                }

                comboAluno.DisplayMember = "Nome";
                comboQuestionario.Items.Clear();
            }
            else
            {
                comboAluno.Items.Clear();
                comboQuestionario.Items.Clear();
            }
        }

        private void comboAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            limparTela();

            if (comboAluno.SelectedIndex >= 0)
            {
                Aluno aluno = comboAluno.SelectedItem as Aluno;

                comboQuestionario.Items.Clear();
                foreach (var resultado in aluno.Resultado)
                {
                    comboQuestionario.Items.Add(resultado.Questionario);
                }

                comboQuestionario.DisplayMember = "Nome";
            }
            else
            {
                comboQuestionario.Items.Clear();
            }
        }

        private void comboQuestionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboQuestionario.SelectedIndex >= 0)
            {
                carregarResultado(comboQuestionario.SelectedItem as Questionario);
            }
            else
            {
                limparTela();
            }
        }

        private void limparTela()
        {
            
        }

        private void carregarResultado(Questionario questionario)
        {
            Aluno aluno = comboAluno.SelectedItem as Aluno;

            lblNomeAlunoTxt.Text = aluno.Nome;
            lblQuestionarioNomeTxt.Text = questionario.Nome;

            Resultado resultado =
                Resultado.obterTodos()
                    .Find(r => r.Aluno_id.Equals(aluno.idAluno) && r.Questionario_id.Equals(questionario.idQuestionario));

            txtAcertos.Text = resultado.TotalAcertos.ToString();
            txtErros.Text = resultado.TotalErros.ToString();

            if (resultado.Questao == null)
            {
                lblFinalizadoTxt.Text = "Sim";
            }
            else
            {
                lblFinalizadoTxt.Text = "Não";
            }


            List<Pontuacao> vetPontuacaoAluno =
                aluno.Pontuacao.ToList().FindAll(p => (p.Questao != null) && p.Questao.Questionario_id.Equals(questionario.idQuestionario));

            vetPontuacaoAluno.Sort((ps1, ps2) => DateTime.Compare((DateTime)ps1.DataHora, (DateTime)ps2.DataHora));

            txtCaminho.Text = "";
            if (vetPontuacaoAluno.Count > 0)
            {

                foreach (var pontuacao in vetPontuacaoAluno)
                {
                    txtCaminho.Text += pontuacao.Questao.Ordem + ";";
                }

                txtCaminho.Text = txtCaminho.Text.Remove(txtCaminho.Text.Length - 1);

                gridPontuacao.Columns.Clear();

                gridPontuacao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


                gridPontuacao.Columns.Add("Col1", "Questão");
                gridPontuacao.Columns.Add("Col2", "Acertou");
                gridPontuacao.Columns.Add("Col3", "Tempo(seg)");
                gridPontuacao.Columns.Add("Col4", "Tentativas");
                gridPontuacao.Columns.Add("Col5", "DataHora");
                gridPontuacao.Columns.Add("Col6", "Opções Clicadas");

                gridPontuacao.Rows.Clear();

                foreach (var pontuacao in vetPontuacaoAluno)
                {
                    gridPontuacao.Rows.Add(pontuacao.OrdemQuestao, pontuacao.AcertouString, pontuacao.Tempo,
                        pontuacao.TentativaString,
                        pontuacao.DataHora, pontuacao.CliquesFormatado);
                }

                btnExportarCsv.Enabled = true;
                btnExportarTurma.Enabled = true;

            }
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "CSV|*.csv";
            dialog.DefaultExt = ".csv";
            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                string path = dialog.FileName;
                var sb = new StringBuilder();

                var headers = gridPontuacao.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(";", headers.Select(column =>  column.HeaderText ).ToArray()));

                foreach (DataGridViewRow row in gridPontuacao.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(";", cells.Select(cell =>  cell.Value ).ToArray()));
                }

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

                ((Master)MdiParent).MensagemSucesso("Relatório Exportado!");
            }


           
        }

        private void btnExportarTurma_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "CSV|*.csv";
            dialog.DefaultExt = ".csv";
            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                string path = dialog.FileName;
                var sb = new StringBuilder();

                Aluno aluno = comboAluno.SelectedItem as Aluno;
                Questionario questionario = comboQuestionario.SelectedItem as Questionario;


                List<Resultado> vetResultado =
                    Resultado.obterTodos()
                        .FindAll(r => r.Aluno.Turma.idTurma.Equals(aluno.Turma.idTurma) && r.Questionario_id.Equals(questionario.idQuestionario));


                int count = vetResultado.Count;

                string headers =
                        "Aluno;Questionario;Acertos;Erros;Caminho;Caminho Acertos;Caminho Erros;Caminho Acerto Com Dica;Caminho Erro Com Dica;";

                foreach (var questao in questionario.Questao.OrderBy(o => o.Ordem))
                {
                    headers += "Q " + questao.Ordem + "_Tipo" + ";";
                    headers += "Q " + questao.Ordem + "_Disciplina" + ";";
                    headers += "Q " + questao.Ordem + "_Competencia" + ";";
                    headers += "Q " + questao.Ordem + "_Peso" + ";";
                    headers += "Q " + questao.Ordem + "_Eixo" + ";";
                    headers += "Q " + questao.Ordem + "_Acertou" + ";";
                    headers += "Q " + questao.Ordem + "_Tempo" + ";";
                    headers += "Q " + questao.Ordem + "_Tentativas" + ";";
                }

                headers = headers.Remove(headers.Length - 1);
                sb.AppendLine(headers);

                foreach (var resultado in vetResultado)
                {

                    string resultCSV = "";

                    List<Pontuacao> vetPontuacaoAluno =
                        resultado.Aluno.Pontuacao.ToList().FindAll(p => (p.Questao != null) && p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                    vetPontuacaoAluno.Sort((ps1, ps2) => DateTime.Compare((DateTime)ps1.DataHora, (DateTime)ps2.DataHora));

                    resultCSV += resultado.Aluno.Nome + ";";
                    resultCSV += questionario.Nome + ";";
                    resultCSV += resultado.TotalAcertos.ToString() + ";";
                    resultCSV += resultado.TotalErros.ToString() + ";";



                    string caminhoCompleto = "";
                    string caminhoAcertos = "";
                    string caminhoErros = "";
                    string caminhoAcertouDicas = "";
                    string caminhoErrouDicas = "";

                    if (vetPontuacaoAluno.Count > 0)
                    {
                        foreach (var pontuacao in vetPontuacaoAluno)
                        {
                            caminhoCompleto += pontuacao.Questao.Ordem + ",";

                            if (pontuacao.Questao.Hint != null && pontuacao.Questao.Hint == true)
                            {
                                if (pontuacao.Acertou == true)
                                {
                                    caminhoAcertouDicas += pontuacao.Questao.Ordem + ",";
                                    caminhoAcertos += pontuacao.Questao.Ordem + ",";  
                                }
                                else
                                {
                                    caminhoErrouDicas += pontuacao.Questao.Ordem + ",";
                                    caminhoErros += pontuacao.Questao.Ordem + ",";
                                }
                            }
                            else
                            {
                                if(pontuacao.Acertou == true)
                                    caminhoAcertos += pontuacao.Questao.Ordem + ",";    
                                else
                                    caminhoErros += pontuacao.Questao.Ordem + ",";  
                            }
                        }
                    }

                    if (caminhoCompleto.Length > 0)
                    {
                        caminhoCompleto = caminhoCompleto.Remove(caminhoCompleto.Length - 1);

                        if (caminhoAcertos.Length > 1)
                            caminhoAcertos = caminhoAcertos.Remove(caminhoAcertos.Length - 1);

                        if (caminhoErros.Length > 1)
                            caminhoErros = caminhoErros.Remove(caminhoErros.Length - 1);

                        if (caminhoAcertouDicas.Length > 1)
                            caminhoAcertouDicas = caminhoAcertouDicas.Remove(caminhoAcertouDicas.Length - 1);

                        if (caminhoErrouDicas.Length > 1)
                            caminhoErrouDicas = caminhoErrouDicas.Remove(caminhoErrouDicas.Length - 1);

                        resultCSV += caminhoCompleto.ToString() + ";";
                        resultCSV += caminhoAcertos.ToString() + ";";
                        resultCSV += caminhoErros.ToString() + ";";
                        resultCSV += caminhoAcertouDicas.ToString() + ";";
                        resultCSV += caminhoErrouDicas.ToString() + ";";

                        foreach (var questao in questionario.Questao.OrderBy(o => o.Ordem))
                        {
                            Pontuacao pont = vetPontuacaoAluno.Find(p => p.Questao_id.Equals(questao.idQuestao));

                            resultCSV += questao.TipoQuestao.Nome + ";";
                            resultCSV += questao.Disciplina.Nome + ";";
                            resultCSV += questao.Competencia + ";";
                            resultCSV += questao.Peso + ";";
                            resultCSV += questao.Area.Nome + ";";

                            if (pont != null)
                            {
                                resultCSV += pont.AcertouString + ";";
                                resultCSV += Math.Truncate((double) pont.Tempo).ToString() + ";";
                                resultCSV += pont.TentativaString + ";";
                            }
                            else
                            {
                                resultCSV += ";;;";
                            }
                        }

                        sb.AppendLine(resultCSV);
                    }

                }

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

                ((Master)MdiParent).MensagemSucesso("Relatório Exportado!");
            }
        }

       

        private void btnImprimir_Click(object sender, EventArgs e)
        {
           
        }

        

      

    }
}
