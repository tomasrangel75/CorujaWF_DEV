using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using Library.Persistencia;
using MetroFramework.Controls;
using System.IO;
using QuestionarioForms.DataSets;
using CrystalDecisions.Shared;

namespace QuestionarioForms
{
    public partial class FormRelatorioReportTurma : MetroFramework.Forms.MetroForm
    {
        public FormRelatorioReportTurma()
        {
            InitializeComponent();

             comboEscola.Items.Clear();
            foreach (var escola in Instituicao.obterTodos())
            {
                comboEscola.Items.Add(escola);
            }

            comboEscola.DisplayMember = "Nome";
        }



        private void comboEscola_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEscola.SelectedIndex >= 0)
            {
                Instituicao escola = comboEscola.SelectedItem as Instituicao;

                if (escola.Turma.Count > 0)
                {
                    comboTurma.Enabled = true;
                    comboTurma.Items.Clear();
                    foreach (var turma in escola.Turma)
                    {
                        comboTurma.Items.Add(turma);
                    }

                    comboTurma.DisplayMember = "Nome";
                }
            }
            else
            {
                comboTurma.Enabled = false;
            }
        }

        private void comboTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurma.SelectedIndex >= 0)
            {
                Turma turma = comboTurma.SelectedItem as Turma;

                List<Questionario> vetQuestionario = new List<Questionario>();

                foreach (var aluno in turma.Aluno)
                {
                    foreach (var pontuacao in aluno.Pontuacao)
                    {
                        if ((pontuacao.Questao != null) && !vetQuestionario.Contains(pontuacao.Questao.Questionario))
                        {
                            vetQuestionario.Add(pontuacao.Questao.Questionario);
                        }
                    }
                }


                if (vetQuestionario.Count >= 0)
                {
                    comboQuestionario.Enabled = true;
                    comboQuestionario.Items.Clear();
                    foreach (var quest in vetQuestionario)
                    {
                        comboQuestionario.Items.Add(quest);
                    }

                    comboQuestionario.DisplayMember = "Nome";
                }
            }
            else
            {
                comboQuestionario.Enabled = false;
            }
        }


        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            if (comboQuestionario.SelectedIndex >= 0)
            {
                gridMatematica.Columns.Clear();
                gridMatematica.Rows.Clear();

                gridPortugues.Columns.Clear();
                gridPortugues.Rows.Clear();

                gridAprendizagem.Columns.Clear();
                gridAprendizagem.Rows.Clear();


                // Pega a turma e questionario selecionados
                Turma turma = comboTurma.SelectedItem as Turma;
                Questionario questionario = comboQuestionario.SelectedItem as Questionario;

                // Computa as árvores
                // CARRREGA AS AREAS CONTEMPLADAS NO RELATORIO

                List<AreaCalculada> vetAreaCalculada = new List<AreaCalculada>();

                List<Questao> vetQuestoesValidas = questionario.Questao.ToList();
                vetQuestoesValidas.RemoveAll(q => q.TipoQuestao_id == 4);
                List<Area> vetAreasRelatorio = new List<Area>();


                // PORTUGUES >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                List<Area> areasPortugues = new List<Area>();

                vetQuestoesValidas.ForEach(q => areasPortugues.Add(q.Area));
                areasPortugues = areasPortugues.ToList().FindAll(a => a.Disciplina_id == 1).Distinct().ToList();

                vetAreasRelatorio.AddRange(areasPortugues);


                // MATEMATICA >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                List<Area> areasMatematica = new List<Area>();

                vetQuestoesValidas.ForEach(q => areasMatematica.Add(q.Area));
                areasMatematica = areasMatematica.ToList().FindAll(a => a.Disciplina_id == 2).Distinct().ToList();

                vetAreasRelatorio.AddRange(areasMatematica);

                // APRENDIZAGEM >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                List<Area> areasAprendizagem = new List<Area>();

                vetQuestoesValidas.ForEach(q => areasAprendizagem.Add(q.Area));
                areasAprendizagem = areasAprendizagem.ToList().FindAll(a => a.Disciplina_id == 3).Distinct().ToList();

                vetAreasRelatorio.AddRange(areasAprendizagem);
      
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                areasPortugues = areasPortugues.OrderBy(a => a.idArea).ToList();
                areasMatematica = areasMatematica.OrderBy(a => a.idArea).ToList();
                areasAprendizagem = areasAprendizagem.OrderBy(a => a.idArea).ToList();



                vetAreasRelatorio = vetAreasRelatorio.OrderBy(a => a.idArea).ToList();




                foreach (var area in vetAreasRelatorio)
                {
                    List<Questao> vetQuestoesArea = vetQuestoesValidas.FindAll(p => p.Area_id.Equals(area.idArea));

                    int maxOrd = (int)vetQuestoesValidas.OrderByDescending(q => q.Ordem).ToList()[0].Ordem;

                    GrafoQuestionario novoGrafo = new GrafoQuestionario();
                    novoGrafo.gerarGrafo(vetQuestoesArea, maxOrd);

                    AreaCalculada areaAzul = new AreaCalculada();
                    areaAzul.area = area;
                    areaAzul.cor = 3;
                    int minAzul = -1;
                    int maxAzul = -1;
                    novoGrafo.getMinMaxCor(3, out minAzul, out maxAzul);
                    areaAzul.min = minAzul;
                    areaAzul.max = maxAzul;

                    AreaCalculada areVerde = new AreaCalculada();
                    areVerde.area = area;
                    areVerde.cor = 2;
                    int minVerde = -1;
                    int maxVerde = -1;
                    novoGrafo.getMinMaxCor(2, out minVerde, out maxVerde);
                    areVerde.min = minVerde;
                    areVerde.max = maxVerde;

                    AreaCalculada areaAmarelo = new AreaCalculada();
                    areaAmarelo.area = area;
                    areaAmarelo.cor = 1;
                    int minAmarelo = -1;
                    int maxAmarelo = -1;
                    novoGrafo.getMinMaxCor(1, out minAmarelo, out maxAmarelo);
                    areaAmarelo.min = minAmarelo;
                    areaAmarelo.max = maxAmarelo;

                    AreaCalculada areaVermelho = new AreaCalculada();
                    areaVermelho.area = area;
                    areaVermelho.cor = 0;
                    int minVermelho = -1;
                    int maxVermelho = -1;
                    novoGrafo.getMinMaxCor(0, out minVermelho, out maxVermelho);
                    areaVermelho.min = minVermelho;
                    areaVermelho.max = maxVermelho;

                    vetAreaCalculada.Add(areaAzul);
                    vetAreaCalculada.Add(areVerde);
                    vetAreaCalculada.Add(areaAmarelo);
                    vetAreaCalculada.Add(areaVermelho);
                }



                // Calcula a pontuação da Turma

                List<ItemReportTurma> vetItensRelatorio = new List<ItemReportTurma>();
             
                foreach (var area in vetAreasRelatorio)
                {
                    ItemReportTurma itemRelatorio = new ItemReportTurma();
                    itemRelatorio.turma = turma;

                    // Calcula o score da turma
                    int corTurma;
                    itemRelatorio.score = calculaResultadoTurma(vetAreaCalculada, turma, questionario, area, out corTurma);
                    itemRelatorio.cor = corTurma;
                    itemRelatorio.area = area;

                    itemRelatorio.scoreEscola = calculaResultadoEscola(vetAreaCalculada, turma, questionario, area);

                    vetItensRelatorio.Add(itemRelatorio);
                }


                // PORTUGUES >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                gridPortugues.Columns.Clear();
                gridPortugues.Rows.Clear();

                gridPortugues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridPortugues.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                
                gridPortugues.RowHeadersVisible = false;
                gridPortugues.AllowUserToAddRows = false;

                gridPortugues.Columns.Add("Col1", "Eixo");

                DataGridViewColumn colunaGrafico = new DataGridViewProgressColumn();
                colunaGrafico.HeaderText = "Gráfico";
                colunaGrafico.Name = "Col2";

                gridPortugues.Columns.Add(colunaGrafico);
                gridPortugues.Columns.Add("Col3", "Média Turma");
                gridPortugues.Columns.Add("Col3", "Média Escola");

                gridPortugues.Rows.Clear();

                foreach (var area in areasPortugues)
                {

                    if (area.Nome.Equals("Treino1"))
                    {
                        continue;
                    };

                    ItemReportTurma itemReport = vetItensRelatorio.Find(i => i.area.idArea == area.idArea);

                    if (itemReport != null)
                    {
                        if (itemReport.score >= 0)
                        {

                            double socreFormatado = Math.Round(itemReport.score, 1);
                            string grafico = itemReport.cor.ToString() + ";" + socreFormatado.ToString();
                            double socreTurmaFormatado = Math.Round(itemReport.scoreEscola, 1);

                            gridPortugues.Rows.Add(area.Nome, grafico, socreFormatado.ToString(), socreTurmaFormatado.ToString());
                        }
                        else
                        {
                            gridPortugues.Rows.Add(area.Nome, "-1", "", "");
                        }
                    }
                    
                }


                // MATEMATICA >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                gridMatematica.Columns.Clear();
                gridMatematica.Rows.Clear();

                gridMatematica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridMatematica.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                gridMatematica.RowHeadersVisible = false;
                gridMatematica.AllowUserToAddRows = false;

                gridMatematica.Columns.Add("Col1", "Eixo");

                DataGridViewColumn colunaGrafico2 = new DataGridViewProgressColumn();
                colunaGrafico2.HeaderText = "Gráfico";
                colunaGrafico2.Name = "Col2";

                gridMatematica.Columns.Add(colunaGrafico2);
                gridMatematica.Columns.Add("Col3", "Média Turma");
                gridMatematica.Columns.Add("Col3", "Média Escola");

                gridMatematica.Rows.Clear();

                foreach (var area in areasMatematica)
                {

                    if (area.Nome.Equals("Treino1"))
                    {
                        continue;
                    };


                    ItemReportTurma itemReport = vetItensRelatorio.Find(i => i.area.idArea == area.idArea);

                    if (itemReport != null)
                    {
                        if (itemReport.score >= 0)
                        {
                            double socreFormatado = Math.Round(itemReport.score, 1);
                            string grafico = itemReport.cor.ToString() + ";" + socreFormatado.ToString();
                            double socreTurmaFormatado = Math.Round(itemReport.scoreEscola, 1);

                            gridMatematica.Rows.Add(area.Nome, grafico, socreFormatado.ToString(), socreTurmaFormatado.ToString());
                        }
                        else
                        {
                            gridMatematica.Rows.Add(area.Nome, "-1", "", "");
                        }
                    }

                }

                // PORTUGUES >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                gridAprendizagem.Columns.Clear();
                gridAprendizagem.Rows.Clear();

                gridAprendizagem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridAprendizagem.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);


                gridAprendizagem.RowHeadersVisible = false;
                gridAprendizagem.AllowUserToAddRows = false;

                gridAprendizagem.Columns.Add("Col1", "Eixo");

                DataGridViewColumn colunaGrafico3 = new DataGridViewProgressColumn();
                colunaGrafico.HeaderText = "Gráfico";
                colunaGrafico.Name = "Col2";

                gridAprendizagem.Columns.Add(colunaGrafico3);
                gridAprendizagem.Columns.Add("Col3", "Média Turma");
                gridAprendizagem.Columns.Add("Col3", "Média Escola");

                gridAprendizagem.Rows.Clear();

                foreach (var area in areasAprendizagem)
                {
                    if(area.Nome.Equals("Treino1"))
                    {
                        continue;
                    };


                    ItemReportTurma itemReport = vetItensRelatorio.Find(i => i.area.idArea == area.idArea);

                    if (itemReport != null)
                    {
                        if (itemReport.score >= 0)
                        {

                            double socreFormatado = Math.Round(itemReport.score, 1);
                            string grafico = itemReport.cor.ToString() + ";" + socreFormatado.ToString();
                            double socreTurmaFormatado = Math.Round(itemReport.scoreEscola, 1);

                            gridAprendizagem.Rows.Add(area.Nome, grafico, socreFormatado.ToString(), socreTurmaFormatado.ToString());
                        }
                        else
                        {
                            gridAprendizagem.Rows.Add(area.Nome, "-1", "", "");
                        }
                    }

                }
            }

            btnCSV.Enabled = true;

            btnPDF.Enabled = true;
            btnPDFMt.Enabled = true;
            metroButton1.Enabled = true;
            metroButton2.Enabled = true;
        }

        public double calculaScore(List<AreaCalculada> vetAreaCalculada, int cor, Area area, double pontuacaoAluno)
        {
            double resultadoFinal = -1;

            int maxArea = -1;
            int minArea = -1;

            AreaCalculada calculoArea = vetAreaCalculada.Find(a => a.cor == cor && a.area.idArea == area.idArea);

            if (calculoArea != null)
            {
                maxArea = calculoArea.max;
                minArea = calculoArea.min;

                double pontBalanceada = pontuacaoAluno - minArea;
                double rangeArea = maxArea - minArea;

                double resultadoParcial = 0;
                if (pontBalanceada > 0 && rangeArea > 0)
                {
                    resultadoParcial = pontBalanceada/rangeArea;
                    resultadoParcial = resultadoParcial*25;
                }

                if (cor == 0)
                    resultadoFinal = resultadoParcial;
                else if (cor == 1)
                    resultadoFinal = 25 + resultadoParcial;
                else if (cor == 2)
                    resultadoFinal = 50 + resultadoParcial;
                else if (cor == 3)
                    resultadoFinal = 75 + resultadoParcial;
            }

            return resultadoFinal;
        }

        public double calculaResultadoTurma(List<AreaCalculada> vetAreaCalculada, Turma turma, Questionario questionario, Area area, out int corTurma)
        {
            int divisor = 0;
            double acumulador = 0;
            corTurma = -1;

            foreach (var alunoAtual in turma.Aluno)
            {
                List<Pontuacao> vetPontuacaoAluno =
                   alunoAtual.Pontuacao.ToList()
                       .FindAll(
                           p =>
                               (p.Questao != null) &&
                               (p.Questao.Questionario_id.Equals(questionario.idQuestionario)) &&
                               (p.Questao.TipoQuestao_id != 4) && p.Questao.Area_id == area.idArea);

                if (vetPontuacaoAluno.Count > 0)
                {
                    vetPontuacaoAluno = vetPontuacaoAluno.OrderBy(p => p.DataHora).ToList();

                    // Calcula a pontuacao do aluno
                    int pontuacaoReal = 0;
                    foreach (var pontuacao in vetPontuacaoAluno)
                    {
                        if (pontuacao.Acertou == true)
                        {
                            if (pontuacao.Questao.Hint == true)
                            {
                                pontuacaoReal += 1;
                            }
                            else
                            {
                                pontuacaoReal += 2;
                            }
                        }
                    }

                    // pega a cor
                    Pontuacao ultima = vetPontuacaoAluno.Last();

                    int corUltima = 0;

                    if (ultima.Acertou == true)
                    {
                        Color ultimaCor = ColorTranslator.FromHtml(ultima.Questao.Cor);

                        ItemRelatorioAluno.corRelatorio ultimaCorParse =
                            ItemRelatorioAluno.convertCorRelatorioFromColor(ultimaCor);
                        corUltima = (int)ultimaCorParse;
                    }
                    else
                    {
                        Color ultimaCor = ColorTranslator.FromHtml(ultima.Questao.Cor);

                        ItemRelatorioAluno.corRelatorio ultimaCorParse =
                            ItemRelatorioAluno.convertCorRelatorioFromColor(ultimaCor);
                        corUltima = (int)ultimaCorParse;
                        if (corUltima > 0)
                            corUltima = corUltima - 1;
                    }

                    int cor = corUltima;

                    if (pontuacaoReal >= 0)
                    {
                        // Calcula o score final do aluno
                        double score = calculaScore(vetAreaCalculada, cor, area,
                            pontuacaoReal);

                        divisor++;
                        acumulador += score;
                    }
                }
            }

            double resultadoTurma = -1;

            if (divisor > 0)
            {
                resultadoTurma = acumulador/divisor;
            }

            if (resultadoTurma >= 75)
                corTurma = 3;
            else if (resultadoTurma >= 50)
                corTurma = 2;
            else if (resultadoTurma >= 25)
                corTurma = 1;
            else
                corTurma = 0;


            return resultadoTurma;
        }

        public double calculaResultadoEscola(List<AreaCalculada> vetAreaCalculada, Turma turma, Questionario questionario, Area area)
        {
            int divisor = 0;
            double acumulador = 0;

            List<Aluno> vetAlunos = new List<Aluno>();

            foreach (var turmaEscola in turma.Instituicao.Turma)
            {
                foreach (var aluno in turmaEscola.Aluno)
                {
                    if (
                        aluno.Pontuacao.ToList()
                            .Exists(p => (p.Questao != null) && p.Questao.Questionario.idQuestionario == questionario.idQuestionario))
                    {
                        vetAlunos.Add(aluno);
                    }
                }
            }

            foreach (var alunoAtual in vetAlunos)
            {
                List<Pontuacao> vetPontuacaoAluno =
                   alunoAtual.Pontuacao.ToList()
                       .FindAll(
                           p =>
                               (p.Questao != null) &&
                               (p.Questao.Questionario_id.Equals(questionario.idQuestionario)) &&
                               (p.Questao.TipoQuestao_id != 4) && p.Questao.Area_id == area.idArea);

                if (vetPontuacaoAluno.Count > 0)
                {
                    vetPontuacaoAluno = vetPontuacaoAluno.OrderBy(p => p.DataHora).ToList();

                    // Calcula a pontuacao do aluno
                    int pontuacaoReal = 0;
                    foreach (var pontuacao in vetPontuacaoAluno)
                    {
                        if (pontuacao.Acertou == true)
                        {
                            if (pontuacao.Questao.Hint == true)
                            {
                                pontuacaoReal += 1;
                            }
                            else
                            {
                                pontuacaoReal += 2;
                            }
                        }
                    }

                    // pega a cor
                    Pontuacao ultima = vetPontuacaoAluno.Last();

                    int corUltima = 0;

                    if (ultima.Acertou == true)
                    {
                        Color ultimaCor = ColorTranslator.FromHtml(ultima.Questao.Cor);

                        ItemRelatorioAluno.corRelatorio ultimaCorParse =
                            ItemRelatorioAluno.convertCorRelatorioFromColor(ultimaCor);
                        corUltima = (int)ultimaCorParse;
                    }
                    else
                    {
                        Color ultimaCor = ColorTranslator.FromHtml(ultima.Questao.Cor);

                        ItemRelatorioAluno.corRelatorio ultimaCorParse =
                            ItemRelatorioAluno.convertCorRelatorioFromColor(ultimaCor);
                        corUltima = (int)ultimaCorParse;
                        corUltima = corUltima - 1;
                    }

                    int cor = corUltima;

                    if (pontuacaoReal >= 0)
                    {
                        // Calcula o score final do aluno
                        double score = calculaScore(vetAreaCalculada, cor, area,
                            pontuacaoReal);

                        divisor++;
                        acumulador += score;
                    }
                }
            }

            double resultadoEscola = -1;

            if (divisor > 0)
            {
                resultadoEscola = acumulador / divisor;
            }


            return resultadoEscola;
        }

        private void btnCSV_Click(object sender, EventArgs e)
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

                var headers = gridPortugues.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(";", headers.Select(column => column.HeaderText).ToArray()));

                foreach (DataGridViewRow row in gridPortugues.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();

                    sb.AppendLine(string.Join(";", cells.Select(cell => formataValor(cell.Value, cell.ColumnIndex)).ToArray()));
                }

                foreach (DataGridViewRow row in gridMatematica.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();

                    sb.AppendLine(string.Join(";", cells.Select(cell => formataValor(cell.Value, cell.ColumnIndex)).ToArray()));
                }

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

                ((Master)MdiParent).MensagemSucesso("Relatório Exportado!");
            }
        }

        private string formataValor(object valor, int ind)
        {
            if (valor == null)
                return "";

            if (ind == 1)
            {
                if (valor.ToString() == "-1" || valor == null || valor.ToString() == "")
                {
                    valor = "Branco";
                }
                else
                {
                    try
                    {
                        int cor = Convert.ToInt32(valor.ToString().Substring(0, 1));

                        valor = "Branco";

                        if (cor == 0)
                        {
                            valor = "Vermelho";
                        }
                        else if (cor == 1)
                        {
                            valor = "Amarelo";
                        }
                        else if (cor == 2)
                        {
                            valor = "Verde";
                        }
                        else if (cor == 3)
                        {
                            valor = "Azul";
                        }
                    }
                    catch (Exception ex)
                    {
                        return "";
                    }
                }
            }

            return valor.ToString();
        }

        private void btnPDFMt_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridMatematica.Rows.Count > 0)
                {
                    FormPDF formpdf = new FormPDF();

                    formpdf.ShowDialog();

                    string nomeProfessor = formpdf.nomeProfessor;

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.AddExtension = true;
                    dialog.Filter = "PDF|*.pdf";
                    dialog.DefaultExt = ".pdf";

                    DialogResult result = dialog.ShowDialog();

                    if (result.Equals(DialogResult.OK))
                    {
                        string path = dialog.FileName;

                        PDFReportTurma report = new PDFReportTurma();

                        // Constroi DataSet
                        DataSetReport ds = new DataSetReport();


                        foreach (DataGridViewRow linha in gridMatematica.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {

                                    row[1] = linha.Cells[1].Value.ToString().Substring(2, count - 2) + "%";

                                    row[2] = linha.Cells[2].Value.ToString() + "%";
                                    row[3] = linha.Cells[3].Value.ToString() + "%";

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }


                        (ds.DataTable1.Rows[0] as DataRow)[0] = "Números";
                        (ds.DataTable1.Rows[1] as DataRow)[0] = "Operações e pensamento algébrico";
                        (ds.DataTable1.Rows[2] as DataRow)[0] = "Espaço e forma";
                        (ds.DataTable1.Rows[3] as DataRow)[0] = " Grandezas, medidas e tratamento da informação";


                        // Constroi Report
                        PageMargins margem = report.PrintOptions.PageMargins;
                        margem.bottomMargin = 0;
                        margem.leftMargin = 0;
                        margem.rightMargin = 0;
                        margem.topMargin = 0;

                        report.PrintOptions.ApplyPageMargins(margem);

                        //report.SetDataSource(ds);
                        report.Database.Tables[0].SetDataSource(ds);

                        Turma turma = (comboTurma.SelectedItem as Turma);
                        Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                        Pontuacao pontuacao =
                            Pontuacao.obterTodos()
                                .Find(
                                    p =>
                                        p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                        p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                        // Popula as Variaveis fixas do Report
                        (report.Section2.ReportObjects["txtProfessor"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = nomeProfessor;
                       
                        (report.Section2.ReportObjects["txtEscola"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            (comboEscola.SelectedItem as Instituicao).Nome;
                        (report.Section2.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            ((DateTime)pontuacao.DataHora).ToShortDateString();

                        (report.Section2.ReportObjects["txtDisciplina"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            "REPORT TURMA - MATEMÁTICA";

                        (report.Section2.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                             turma.Nome;


                        (report.Section2.ReportObjects["Text2"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Eixo";

                        (report.Section2.ReportObjects["Text3"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Gráfico";

                        (report.Section2.ReportObjects["Text4"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Média Turma";

                        (report.Section2.ReportObjects["Text6"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Média Escola";


                        // Exporta o Report
                        report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        report.ExportToDisk(ExportFormatType.PortableDocFormat, path);

                        ((Master)MdiParent).MensagemSucesso("PDF Exportado!");
                    }
                }
                else
                {
                    ((Master)MdiParent).MensagemErro("Não contém resultados suficientes para gerar o relatório!");
                }
            }
            catch (Exception)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridPortugues.Rows.Count > 0)
                {
                    FormPDF formpdf = new FormPDF();

                    formpdf.ShowDialog();

                    string nomeProfessor = formpdf.nomeProfessor;

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.AddExtension = true;
                    dialog.Filter = "PDF|*.pdf";
                    dialog.DefaultExt = ".pdf";

                    DialogResult result = dialog.ShowDialog();

                    if (result.Equals(DialogResult.OK))
                    {
                        string path = dialog.FileName;

                        PDFReportTurma report = new PDFReportTurma();

                        // Constroi DataSet
                        DataSetReport ds = new DataSetReport();


                        foreach (DataGridViewRow linha in gridPortugues.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {


                                    row[1] = linha.Cells[1].Value.ToString().Substring(2, count - 2) + "%";

                                    row[2] = linha.Cells[2].Value.ToString() + "%";
                                    row[3] = linha.Cells[3].Value.ToString() + "%";

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }


                        (ds.DataTable1.Rows[0] as DataRow)[0] = "Escuta dos sons da Língua Portuguesa";
                        (ds.DataTable1.Rows[1] as DataRow)[0] = "Sistema de escrita alfabética";
                        (ds.DataTable1.Rows[2] as DataRow)[0] = "Produção de texto escrito";
                        (ds.DataTable1.Rows[3] as DataRow)[0] = "Leitura e compreensão de texto";



                        // Constroi Report
                        PageMargins margem = report.PrintOptions.PageMargins;
                        margem.bottomMargin = 0;
                        margem.leftMargin = 0;
                        margem.rightMargin = 0;
                        margem.topMargin = 0;

                        report.PrintOptions.ApplyPageMargins(margem);

                        //report.SetDataSource(ds);
                        report.Database.Tables[0].SetDataSource(ds);

                        Turma turma = (comboTurma.SelectedItem as Turma);
                        Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                        Pontuacao pontuacao =
                            Pontuacao.obterTodos()
                                .Find(
                                    p =>
                                        p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                        p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                        // Popula as Variaveis fixas do Report
                        (report.Section2.ReportObjects["txtProfessor"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = nomeProfessor;

                        (report.Section2.ReportObjects["txtEscola"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            (comboEscola.SelectedItem as Instituicao).Nome;
                        (report.Section2.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            ((DateTime)pontuacao.DataHora).ToShortDateString();

                        (report.Section2.ReportObjects["txtDisciplina"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            "RELATÓRIO DA TURMA \n LÍNGUA PORTUGUESA";

                        (report.Section2.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                             turma.Nome;


                        (report.Section2.ReportObjects["Text2"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Eixo";

                        (report.Section2.ReportObjects["Text3"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Gráfico";

                        (report.Section2.ReportObjects["Text4"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Média Turma";

                        (report.Section2.ReportObjects["Text6"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Média Escola";


                        // Exporta o Report
                        report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        report.ExportToDisk(ExportFormatType.PortableDocFormat, path);

                        ((Master)MdiParent).MensagemSucesso("PDF Exportado!");
                    }
                }
                else
                {
                    ((Master)MdiParent).MensagemErro("Não contém resultados suficientes para gerar o relatório!");
                }
            }
            catch (Exception)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }

        public int getColorFromScore(float score)
        {
            if(score > 0)
            {
                if(score < 25)
                    return 0;
                if(score < 50)
                    return 1;
                if(score < 75)
                    return 2;
                return 3;
            }

            return -1;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            string escola = this.txtEscola.Text;
            string dtAplic = this.txtAplic.Text;


            DataSetRepEscTurPt ds1 = new DataSetRepEscTurPt();
            DataSetRepEscTurMat ds2 = new DataSetRepEscTurMat();
         

            // PORTUGUES >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (gridPortugues.Rows.Count > 0)
            {
                foreach (DataGridViewRow linha in gridPortugues.Rows)
                {
                    DataRow row = ds1.DataTable1.NewRow();
                    row[0] = linha.Cells[0].Value.ToString();
                    float mediaTurma = -1;
                    float mediaEscola = -1;

                    if (linha.Cells.Count > 2)
                    {
                        string mt = linha.Cells[2].Value.ToString();
                        if(float.TryParse(mt, out mediaTurma))
                        {
                           
                            row[1] = getColorFromScore(mediaTurma).ToString();
                            row[2] = mt;
                        }
                    }

                    if (linha.Cells.Count > 3)
                    {
                        string me = linha.Cells[3].Value.ToString();
                        if(float.TryParse(me, out mediaEscola))
                        {

                            row[3] = getColorFromScore(mediaEscola).ToString();
                            row[4] = me;
                        }
                    }

                    ds1.DataTable1.Rows.Add(row);
                }
            }


            // MATEMATICA >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (gridMatematica.Rows.Count > 0)
            {
                foreach (DataGridViewRow linha in gridMatematica.Rows)
                {
                    DataRow row = ds2.DataTable1.NewRow();
                    row[0] = linha.Cells[0].Value.ToString();
                    float mediaTurma = -1;
                    float mediaEscola = -1;

                    if (linha.Cells.Count > 2)
                    {
                        string mt = linha.Cells[2].Value.ToString();
                        if(float.TryParse(mt, out mediaTurma))
                        {

                            row[1] = getColorFromScore(mediaTurma).ToString();
                            row[2] = mt;
                        }
                    }

                    if (linha.Cells.Count > 3)
                    {
                        string me = linha.Cells[3].Value.ToString().ToString();
                        if(float.TryParse(me, out mediaEscola))
                        {
                            
                            row[3] = getColorFromScore(mediaEscola);
                            row[4] = me;
                        }
                    }

                    ds2.DataTable1.Rows.Add(row);
                }
            }

                                 


            if ((ds1.DataTable1.Rows.Count > 0) || (ds2.DataTable1.Rows.Count > 0))
            {
              
                string nomeTurma = "";
                string nomeQuest = "";
                string rootPath = ""; string path = "";


                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    rootPath = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Selecionar caminho");
                    return;
                }

                nomeQuest = comboQuestionario.Text;
                nomeTurma = comboTurma.Text;
                path = rootPath + "\\" + nomeQuest + "_" + nomeTurma + ".pdf";



                PDFReportEscTur report = new PDFReportEscTur();

                

                    Turma turma = (comboTurma.SelectedItem as Turma);
                    Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                    Pontuacao pontuacao =
                        Pontuacao.obterTodos()
                            .Find(
                                p =>
                                    p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                    p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                    (report.Section1.ReportObjects["Text3"] as
                      CrystalDecisions.CrystalReports.Engine.TextObject)
                      .Text = escola;

                    (report.Section1.ReportObjects["Text4"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                          .Text
                          =
                          dtAplic;

                    (report.Section1.ReportObjects["Text7"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                          .Text
                          =
                           turma.Nome;

                if (gridPortugues.Rows.Count > 0) { report.Subreports["RepPT"].SetDataSource(ds1); }
                else { report.Section2.SectionFormat.EnableSuppress = true; }


                if (gridMatematica.Rows.Count > 0) { report.Subreports["RepMT"].SetDataSource(ds2); }
                else { report.Section3.SectionFormat.EnableSuppress = true; }


                // Exporta o Report
                report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    report.ExportToDisk(ExportFormatType.PortableDocFormat, path);


                ((Master)MdiParent).MensagemSucesso("PDF Exportado!");
                    

            }
            else
            {
                ((Master)MdiParent).MensagemErro("Não contém resultados suficientes para gerar o relatório!");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DataSetRepEscTurApr ds3 = new DataSetRepEscTurApr();

            string escola = this.txtEscola.Text;
            string dtAplic = this.txtAplic.Text;


            // APRENDIZAGEM >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (gridAprendizagem.Rows.Count > 0)
            {
                foreach (DataGridViewRow linha in gridAprendizagem.Rows)
                {
                    DataRow row = ds3.DataTable1.NewRow();
                    row[0] = linha.Cells[0].Value.ToString();
                    float mediaTurma = -1;
                    float mediaEscola = -1;

                    if (linha.Cells.Count > 2)
                    {
                        string mt = linha.Cells[2].Value.ToString();
                        if (float.TryParse(mt, out mediaTurma))
                        {

                            row[1] = getColorFromScore(mediaTurma).ToString();
                            row[2] = mt;
                        }
                    }

                    if (linha.Cells.Count > 3)
                    {
                        string me = linha.Cells[3].Value.ToString().ToString();
                        if (float.TryParse(me, out mediaEscola))
                        {

                            row[3] = getColorFromScore(mediaEscola);
                            row[4] = me;
                        }
                    }

                    ds3.DataTable1.Rows.Add(row);
                }
            }



            if ((ds3.DataTable1.Rows.Count > 0))
            {

                string nomeTurma = "";
                string nomeQuest = "";
                string rootPath = ""; string path = "";


                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    rootPath = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Selecionar caminho");
                    return;
                }

                nomeQuest = comboQuestionario.Text;
                nomeTurma = comboTurma.Text;
                path = rootPath + "\\" + nomeQuest + "_" + nomeTurma + ".pdf";



                PDFReportEscTurApr report = new PDFReportEscTurApr();



                Turma turma = (comboTurma.SelectedItem as Turma);
                Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                Pontuacao pontuacao =
                    Pontuacao.obterTodos()
                        .Find(
                            p =>
                                p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                (report.Section1.ReportObjects["Text3"] as
                  CrystalDecisions.CrystalReports.Engine.TextObject)
                  .Text = escola;

                (report.Section1.ReportObjects["Text4"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                      .Text
                      = dtAplic;

                (report.Section1.ReportObjects["Text7"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                      .Text
                      =
                       turma.Nome;
                

                if (gridAprendizagem.Rows.Count > 0) { report.Subreports["RepMT"].SetDataSource(ds3); }
                else { report.Section3.SectionFormat.EnableSuppress = true; }


                // Exporta o Report
                report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                report.ExportToDisk(ExportFormatType.PortableDocFormat, path);


                ((Master)MdiParent).MensagemSucesso("PDF Exportado!");


            }
            else
            {
                ((Master)MdiParent).MensagemErro("Não contém resultados suficientes para gerar o relatório!");
            }

        }
    }

    public class ItemReportTurma
    {
        public Area area { get; set; }

        public Turma turma { get; set; }

        public int cor { get; set; }

        public double score { get; set; }

        public double scoreEscola { get; set; }

    }
}
