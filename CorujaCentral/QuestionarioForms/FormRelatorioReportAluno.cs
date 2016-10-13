using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using Library.Persistencia;
using MetroFramework.Controls;
using System.IO;
using QuestionarioForms.DataSets;
using CrystalDecisions.Shared;


namespace QuestionarioForms
{
    public partial class FormRelatorioReportAluno : MetroFramework.Forms.MetroForm
    {
        public FormRelatorioReportAluno()
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
                btnTdsAlunosEscola.Enabled = true;
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

                if (turma.Aluno.Count > 0)
                {
                    comboAluno.Enabled = true;
                    comboAluno.Items.Clear();
                    foreach (var aluno in turma.Aluno)
                    {
                        comboAluno.Items.Add(aluno);
                    }

                    comboAluno.DisplayMember = "Nome";
                }
            }
            else
            {
                comboAluno.Enabled = false;
            }
        }

        private void comboAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAluno.SelectedIndex >= 0)
            {
                Aluno aluno = comboAluno.SelectedItem as Aluno;

                List<Questionario> vetQuestionario = new List<Questionario>();

              
                foreach (var resultado in aluno.Resultado)
                {
                    if (!vetQuestionario.Contains(resultado.Questionario))
                    {
                        vetQuestionario.Add(resultado.Questionario);
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
                btnCSV.Enabled = true;
                btnPDF.Enabled = true;
                btnPDFMt.Enabled = true;
                btnEspecialista.Enabled = true;
                btnEspecRel.Enabled = true;
                metroButton1.Enabled = true;
                metroButton2.Enabled = true;

                gridMatematica.Columns.Clear();
                gridMatematica.Rows.Clear();

                gridPortugues.Columns.Clear();
                gridPortugues.Rows.Clear();

                gridtreino.Columns.Clear();
                gridtreino.Rows.Clear();


                // Pega o aluno e questionario selecionados
                Aluno aluno = comboAluno.SelectedItem as Aluno;
                Questionario questionario = comboQuestionario.SelectedItem as Questionario;

                // Psicogenese
                List<Pontuacao> vetPontuacaoAlunoPsico =
                         aluno.Pontuacao.ToList().FindAll(p => (p.Questao != null) && (p.Questao.Questionario_id.Equals(questionario.idQuestionario)) && (p.Questao.TipoQuestao_id == 4));

              //  vetPontuacaoAlunoPsico.Sort((ps1, ps2) => DateTime.Compare((DateTime)ps1.DataHora, (DateTime)ps2.DataHora));



                // Computa as árvores
                // CARRREGA AS AREAS CONTEMPLADAS NO RELATORIO

                List<AreaCalculada> vetAreaCalculada = new List<AreaCalculada>();

                List<Questao> vetQuestoesValidas = questionario.Questao.ToList();
                vetQuestoesValidas.RemoveAll(q => q.TipoQuestao_id == 4);
                List<Area> vetAreasRelatorio = new List<Area>();

                List<Area> areasPortugues = new List<Area>();

                vetQuestoesValidas.ForEach(q => areasPortugues.Add(q.Area));
                areasPortugues = areasPortugues.ToList().FindAll(a => a.Disciplina_id == 1).Distinct().ToList();

                vetAreasRelatorio.AddRange(areasPortugues);

                List<Area> areasMatematica = new List<Area>();

                vetQuestoesValidas.ForEach(q => areasMatematica.Add(q.Area));
                areasMatematica = areasMatematica.ToList().FindAll(a => a.Disciplina_id == 2).Distinct().ToList();

                vetAreasRelatorio.AddRange(areasMatematica);

                List<Area> areasTreino = new List<Area>();

                vetQuestoesValidas.ForEach(q => areasTreino.Add(q.Area));
                areasTreino = areasTreino.ToList().FindAll(a => (a.Disciplina_id == 3) && (!a.Nome.Contains("Treino"))).Distinct().ToList();

                vetAreasRelatorio.AddRange(areasTreino);

                areasPortugues = areasPortugues.OrderBy(a => a.idArea).ToList();
                areasMatematica = areasMatematica.OrderBy(a => a.idArea).ToList();
                areasTreino = areasTreino.OrderBy(a => a.idArea).ToList();
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



                // Calcula a pontuação do Aluno

                List<ItemReportAluno> vetItensRelatorio = new List<ItemReportAluno>();

                List<Pontuacao> vetPontuacaoAluno =
                    aluno.Pontuacao.ToList()
                        .FindAll(
                            p =>
                                (p.Questao != null) &&
                                (p.Questao.Questionario_id.Equals(questionario.idQuestionario)) &&
                                (p.Questao.TipoQuestao_id != 4));

                if (vetPontuacaoAluno.Count > 0)
                {
                    // Pega a cor das Areas do aluno
                    foreach (var area in vetAreasRelatorio)
                    {
                        ItemReportAluno itemRelatorio = new ItemReportAluno();
                        itemRelatorio.aluno = aluno;
                        itemRelatorio.area = area;

                        List<Pontuacao> pontuacoesNaArea =
                            vetPontuacaoAluno.ToList().FindAll(p => p.Questao.Area_id.Equals(area.idArea));

                        if (pontuacoesNaArea.Count > 0)
                        {
                            pontuacoesNaArea = pontuacoesNaArea.OrderBy(p => p.DataHora).ToList();

                            // Calcula a pontuacao do aluno
                            int pontuacaoReal = 0;
                            foreach (var pontuacao in pontuacoesNaArea)
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

                            itemRelatorio.pontuacaoReal = pontuacaoReal;

                            Pontuacao ultima = pontuacoesNaArea.Last();

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

                            itemRelatorio.cor = corUltima;
                        }
                        else
                        {
                            itemRelatorio.cor = -1;
                            itemRelatorio.pontuacaoReal = -1;
                        }

                        if (itemRelatorio.pontuacaoReal >= 0)
                        {
                            // Calcula o score final do aluno
                            itemRelatorio.score = calculaScore(vetAreaCalculada, itemRelatorio.cor, area,
                                itemRelatorio.pontuacaoReal);

                            // Calcula o score da turma
                            itemRelatorio.scoreTurma = calculaPontuacaoTurma(vetAreaCalculada, aluno, questionario, area);
                        }

                        vetItensRelatorio.Add(itemRelatorio);
                    }
                }

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
                gridPortugues.Columns.Add("Col3", "Pontuação");
                gridPortugues.Columns.Add("Col3", "Média Turma");

                gridPortugues.Rows.Clear();

                foreach (var area in areasPortugues)
                {
                    ItemReportAluno itemReport = vetItensRelatorio.Find(i => i.area.idArea == area.idArea);

                    if (itemReport != null)
                    {
                        if (itemReport.pontuacaoReal >= 0 && itemReport.score >= 0)
                        {

                            double socreFormatado = Math.Round(itemReport.score, 1);

                            switch (itemReport.cor)
                            {
                                case 1:
                                    //26 - 50  Amarelo
                                    if (socreFormatado < 26) socreFormatado = 26;
                                    if (socreFormatado > 50) socreFormatado = 50;
                                    if (itemReport.scoreTurma < 26) itemReport.scoreTurma = 26;
                                    if (itemReport.scoreTurma > 50) itemReport.scoreTurma = 50;



                                    break;

                                case 2:
                                    //51 - 75  verde
                                    if (socreFormatado < 51) socreFormatado = 51;
                                    if (socreFormatado > 75) socreFormatado = 75;
                                    if (itemReport.scoreTurma < 51) itemReport.scoreTurma = 51;
                                    if (itemReport.scoreTurma > 75) itemReport.scoreTurma = 75;

                                    break;

                                case 3:
                                    //76 - 100  azul
                                    if (socreFormatado < 76) socreFormatado = 76;
                                    if (socreFormatado > 100) socreFormatado = 100;
                                    if (itemReport.scoreTurma < 76) itemReport.scoreTurma = 76;
                                    if (itemReport.scoreTurma > 100) itemReport.scoreTurma = 100;
                                    break;

                                case 4:
                                    // 0 - 25  vermelho
                                    if (socreFormatado < 0) socreFormatado = 0;
                                    if (socreFormatado > 25) socreFormatado = 25;
                                    if (itemReport.scoreTurma < 0) itemReport.scoreTurma = 0;
                                    if (itemReport.scoreTurma > 25) itemReport.scoreTurma = 25;

                                    break;

                                case 0:
                                    //  0 - 25  vermelho
                                    if (socreFormatado < 0) socreFormatado = 0;
                                    if (socreFormatado > 25) socreFormatado = 25;
                                    if (itemReport.scoreTurma < 0) itemReport.scoreTurma = 0;
                                    if (itemReport.scoreTurma > 25) itemReport.scoreTurma = 25;

                                    break;

                                default:
                                    break;
                            }
                            

                            string grafico = itemReport.cor.ToString() + ";" + socreFormatado.ToString();
                            double socreTurmaFormatado = Math.Round(itemReport.scoreTurma, 1);

                            gridPortugues.Rows.Add(area.Nome, grafico, socreFormatado.ToString(), socreTurmaFormatado.ToString());
                        }
                        else
                        {
                            gridPortugues.Rows.Add(area.Nome, "-1", "", "");
                        }
                    }
                    
                }

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
                gridMatematica.Columns.Add("Col3", "Pontuação");
                gridMatematica.Columns.Add("Col3", "Média Turma");

                gridMatematica.Rows.Clear();

                foreach (var area in areasMatematica)
                {
                    ItemReportAluno itemReport = vetItensRelatorio.Find(i => i.area.idArea == area.idArea);

                    if (itemReport != null)
                    {
                        if (itemReport.pontuacaoReal >= 0 && itemReport.score >= 0)
                        {
                            double socreFormatado = Math.Round(itemReport.score, 1);

                            switch (itemReport.cor)
                            {
                                case 1:
                                    //26 - 50  Amarelo
                                    if (socreFormatado < 26) socreFormatado = 26;
                                    if (socreFormatado > 50) socreFormatado = 50;
                                    if (itemReport.scoreTurma < 26) itemReport.scoreTurma = 26;
                                    if (itemReport.scoreTurma > 50) itemReport.scoreTurma = 50;



                                    break;

                                case 2:
                                    //51 - 75  verde
                                    if (socreFormatado < 51) socreFormatado = 51;
                                    if (socreFormatado > 75) socreFormatado = 75;
                                    if (itemReport.scoreTurma < 51) itemReport.scoreTurma = 51;
                                    if (itemReport.scoreTurma > 75) itemReport.scoreTurma = 75;

                                    break;

                                case 3:
                                    //76 - 100  azul
                                    if (socreFormatado < 76) socreFormatado = 76;
                                    if (socreFormatado > 100) socreFormatado = 100;
                                    if (itemReport.scoreTurma < 76) itemReport.scoreTurma = 76;
                                    if (itemReport.scoreTurma > 100) itemReport.scoreTurma = 100;
                                    break;

                                case 4:
                                    // 0 - 25  vermelho
                                    if (socreFormatado < 0) socreFormatado = 0;
                                    if (socreFormatado > 25) socreFormatado = 25;
                                    if (itemReport.scoreTurma < 0) itemReport.scoreTurma = 0;
                                    if (itemReport.scoreTurma > 25) itemReport.scoreTurma = 25;

                                    break;

                                case 0:
                                    //  0 - 25  vermelho
                                    if (socreFormatado < 0) socreFormatado = 0;
                                    if (socreFormatado > 25) socreFormatado = 25;
                                    if (itemReport.scoreTurma < 0) itemReport.scoreTurma = 0;
                                    if (itemReport.scoreTurma > 25) itemReport.scoreTurma = 25;

                                    break;

                                default:
                                    break;
                            }


                            string grafico = itemReport.cor.ToString() + ";" + socreFormatado.ToString();
                            double socreTurmaFormatado = Math.Round(itemReport.scoreTurma, 1);

                            gridMatematica.Rows.Add(area.Nome, grafico, socreFormatado.ToString(), socreTurmaFormatado.ToString());
                        }
                        else
                        {
                            gridMatematica.Rows.Add(area.Nome, "-1", "", "");
                        }
                    }

                }

                gridtreino.Columns.Clear();
                gridtreino.Rows.Clear();

                gridtreino.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridtreino.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);


                gridtreino.RowHeadersVisible = false;
                gridtreino.AllowUserToAddRows = false;

                gridtreino.Columns.Add("Col1", "Eixo");

                DataGridViewColumn colunaGrafico3 = new DataGridViewProgressColumn();
                colunaGrafico3.HeaderText = "Gráfico";
                colunaGrafico3.Name = "Col2";

                gridtreino.Columns.Add(colunaGrafico3);
                gridtreino.Columns.Add("Col3", "Pontuação");
                gridtreino.Columns.Add("Col3", "Média Turma");

                gridtreino.Rows.Clear();

                foreach (var area in areasTreino)
                {
                    ItemReportAluno itemReport = vetItensRelatorio.Find(i => i.area.idArea == area.idArea);

                    if (itemReport != null)
                    {
                        if (itemReport.pontuacaoReal >= 0 && itemReport.score >= 0)
                        {

                            double socreFormatado = Math.Round(itemReport.score, 1);

                            switch (itemReport.cor)
                            {
                                case 1:
                                    //26 - 50  Amarelo
                                    if (socreFormatado < 26) socreFormatado = 26;
                                    if (socreFormatado > 50) socreFormatado = 50;
                                    if (itemReport.scoreTurma < 26) itemReport.scoreTurma = 26;
                                    if (itemReport.scoreTurma > 50) itemReport.scoreTurma = 50;



                                    break;

                                case 2:
                                    //51 - 75  verde
                                    if (socreFormatado < 51) socreFormatado = 51;
                                    if (socreFormatado > 75) socreFormatado = 75;
                                    if (itemReport.scoreTurma < 51) itemReport.scoreTurma = 51;
                                    if (itemReport.scoreTurma > 75) itemReport.scoreTurma = 75;

                                    break;

                                case 3:
                                    //76 - 100  azul
                                    if (socreFormatado < 76) socreFormatado = 76;
                                    if (socreFormatado > 100) socreFormatado = 100;
                                    if (itemReport.scoreTurma < 76) itemReport.scoreTurma = 76;
                                    if (itemReport.scoreTurma > 100) itemReport.scoreTurma = 100;
                                    break;

                                case 4:
                                    // 0 - 25  vermelho
                                    if (socreFormatado < 0) socreFormatado = 0;
                                    if (socreFormatado > 25) socreFormatado = 25;
                                    if (itemReport.scoreTurma < 0) itemReport.scoreTurma = 0;
                                    if (itemReport.scoreTurma > 25) itemReport.scoreTurma = 25;

                                    break;

                                case 0:
                                    //  0 - 25  vermelho
                                    if (socreFormatado < 0) socreFormatado = 0;
                                    if (socreFormatado > 25) socreFormatado = 25;
                                    if (itemReport.scoreTurma < 0) itemReport.scoreTurma = 0;
                                    if (itemReport.scoreTurma > 25) itemReport.scoreTurma = 25;

                                    break;

                                default:
                                    break;
                            }

                            string grafico = itemReport.cor.ToString() + ";" + socreFormatado.ToString();
                            double socreTurmaFormatado = Math.Round(itemReport.scoreTurma, 1);

                            gridtreino.Rows.Add(area.Nome, grafico, socreFormatado.ToString(), socreTurmaFormatado.ToString());
                        }
                        else
                        {
                            gridtreino.Rows.Add(area.Nome, "-1", "", "");
                        }
                    }

                }

                // Psicogenese
                gridpsico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridpsico.RowHeadersVisible = false;

                gridpsico.Columns.Add("Col1", "Palavra-alvo");
                gridpsico.Columns.Add("Col2", "Produção");
                gridpsico.Columns.Add("Col3", "Hipótese");

                gridpsico.Rows.Clear();

                foreach (var pontuacao in vetPontuacaoAlunoPsico)
                {
                    string palavra =
                        pontuacao.Questao.ItemQuestao.ToList()
                            .Find(i => i.EPergunta != null && i.EPergunta == true)
                            .Titulo;

                    try
                    {
                        if (palavra.IndexOf("(") > 0)
                        {
                            palavra = palavra.Substring(0, palavra.IndexOf("(")).Replace(";", "");
                        }

                        string resposta = pontuacao.Mouse;

                        int classificacaoBanco = (int)pontuacao.Tentativas;

                        TipoQuestao.TipoPsicogenese tipoClassificado = (TipoQuestao.TipoPsicogenese)classificacaoBanco;

                        string classificacao = "";

                        if (tipoClassificado == TipoQuestao.TipoPsicogenese.Alfabetico)
                            classificacao = "Alfabético";
                        else if (tipoClassificado == TipoQuestao.TipoPsicogenese.Ortografico)
                            classificacao = "Ortográfico";
                        else if (tipoClassificado == TipoQuestao.TipoPsicogenese.PreSilabico)
                            classificacao = "Pré-Silábico";
                        else if (tipoClassificado == TipoQuestao.TipoPsicogenese.SilabicoComValor)
                            classificacao = "Silábico com Valor";
                        else if (tipoClassificado == TipoQuestao.TipoPsicogenese.SilabicoSemValor)
                            classificacao = "Silábico sem Valor";

                        gridpsico.Rows.Add(palavra, resposta, classificacao);
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
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

        public double calculaPontuacaoTurma(List<AreaCalculada> vetAreaCalculada, Aluno aluno, Questionario questionario, Area area)
        {
            Turma turma = aluno.Turma;
            int divisor = 0;
            double acumulador = 0;

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

            return resultadoTurma;
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
            valor = "Branco";

            try
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
                }
            }
            catch (Exception ex)
            {
            }

            return valor.ToString();
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

                        PDFReportAluno report = new PDFReportAluno();

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
                        (ds.DataTable1.Rows[2] as DataRow)[0] = "Planejamento do texto escrito";
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
                        (report.Section2.ReportObjects["txtTurma"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            turma.Nome;
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
                            "REPORT ALUNO - PORTUGUÊS";

                        (report.Section2.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            (comboAluno.SelectedItem as Aluno).Nome;


                        (report.Section2.ReportObjects["Text2"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Eixo";

                        (report.Section2.ReportObjects["Text3"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Gráfico";

                        (report.Section2.ReportObjects["Text4"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Pontuação";

                        (report.Section2.ReportObjects["Text6"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Média Turma";


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
            catch (Exception ex)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
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

                        PDFReportAluno report = new PDFReportAluno();

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
                        (ds.DataTable1.Rows[3] as DataRow)[0] = "Grandezas, medidas e tratamento da informação";


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
                        (report.Section2.ReportObjects["txtTurma"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            turma.Nome;
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
                            "RELATÓRIO ALUNO - MATEMÁTICA";

                        (report.Section2.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            (comboAluno.SelectedItem as Aluno).Nome;


                        (report.Section2.ReportObjects["Text2"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Eixo";

                        (report.Section2.ReportObjects["Text3"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Gráfico";

                        (report.Section2.ReportObjects["Text4"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Pontuação";

                        (report.Section2.ReportObjects["Text6"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Média Turma";


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
            catch (Exception ex)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }

        public void pdfEscola (string professor = null, string nomeArquivo = null)
        {
            try
            {
                if ((gridMatematica.Rows.Count > 0) || (gridPortugues.Rows.Count > 0) || (gridtreino.Rows.Count > 0))
                {
                    FormPDF formpdf = new FormPDF();
                    string nomeProfessor;
                    if (professor == null)
                    {
                        formpdf.ShowDialog();
                        nomeProfessor = formpdf.nomeProfessor;
                    }
                    else nomeProfessor = professor;

                    string path;
                    DialogResult result;
                    if (nomeArquivo == null)
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.AddExtension = true;
                        dialog.Filter = "PDF|*.pdf";
                        dialog.DefaultExt = ".pdf";

                        result = dialog.ShowDialog();
                        path = dialog.FileName;
                    }
                    else
                    {
                        result = DialogResult.OK;
                        path = nomeArquivo;
                    }

                    if (result.Equals(DialogResult.OK))
                    {
                        PDFEspecialista report = new PDFEspecialista();

                        // Constroi DataSet
                        DataSetReport ds = new DataSetReport();
                        DataSetReport2 ds2 = new DataSetReport2();
                        DataSetReport3 ds3 = new DataSetReport3();
                        DataSetPsico dsp = new DataSetPsico();

                        foreach (DataGridViewRow linha in gridPortugues.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                try
                                {
                                    int count = linha.Cells[1].Value.ToString().Length;

                                    row[1] = "&nbsp;";

                                    row[3] = linha.Cells[2].Value.ToString();
                                    row[2] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        if (gridPortugues.Rows.Count > 0) { (ds.DataTable1.Rows[0] as DataRow)[0] = "Escuta dos sons da Língua Portuguesa"; }
                        if (gridPortugues.Rows.Count > 1) { (ds.DataTable1.Rows[1] as DataRow)[0] = "Escrita alfabética"; }
                        if (gridPortugues.Rows.Count > 2) { (ds.DataTable1.Rows[3] as DataRow)[0] = "Leitura e compreensão de texto"; }
                        if (gridPortugues.Rows.Count > 3) { (ds.DataTable1.Rows[2] as DataRow)[0] = "Planejamento do texto escrito"; }

                        foreach (DataGridViewRow linha in gridMatematica.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds2.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {

                                    row[1] = "&nbsp;";

                                    row[2] = linha.Cells[2].Value.ToString();
                                    row[3] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds2.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        if (gridMatematica.Rows.Count > 0) { (ds2.DataTable1.Rows[0] as DataRow)[0] = "Números"; }
                        if (gridMatematica.Rows.Count > 1) { (ds2.DataTable1.Rows[1] as DataRow)[0] = "Operações"; }
                        if (gridMatematica.Rows.Count > 2) { (ds2.DataTable1.Rows[2] as DataRow)[0] = "Espaço e forma"; }
                        if (gridMatematica.Rows.Count > 3) { (ds2.DataTable1.Rows[3] as DataRow)[0] = "Grandezas e tratamento da informação"; }



                        foreach (DataGridViewRow linha in gridtreino.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds3.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {
                                    row[1] = "&nbsp;";

                                    row[2] = linha.Cells[2].Value.ToString();
                                    row[3] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds3.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        if (gridtreino.Rows.Count > 0) { (ds3.DataTable1.Rows[0] as DataRow)[0] = "Processamento da Informação"; }
                        if (gridtreino.Rows.Count > 1) { (ds3.DataTable1.Rows[1] as DataRow)[0] = "Memória de Trabalho"; }
                        if (gridtreino.Rows.Count > 2) { (ds3.DataTable1.Rows[2] as DataRow)[0] = "Linguagem - Cognição Social"; }
                        if (gridtreino.Rows.Count > 3) { (ds3.DataTable1.Rows[3] as DataRow)[0] = "Linguagem - Vocabulário e Compreensão"; }


                        // Psicogenese
                        foreach (DataGridViewRow linha in gridpsico.Rows)
                        {

                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = dsp.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();
                                if (linha.Cells[1].Value != null)
                                {
                                    row[1] = linha.Cells[1].Value.ToString();
                                }
                                row[2] = linha.Cells[2].Value.ToString();

                                dsp.DataTable1.Rows.Add(row);
                            }
                        }



                        // Constroi Report
                        PageMargins margem = report.PrintOptions.PageMargins;
                        margem.bottomMargin = 0;
                        margem.leftMargin = 0;
                        margem.rightMargin = 0;
                        margem.topMargin = 0;

                        report.PrintOptions.ApplyPageMargins(margem);


                        if (gridPortugues.Rows.Count > 0) { report.Subreports["subportugues"].SetDataSource(ds); }
                        else { report.PageHeaderSection2.SectionFormat.EnableSuppress = true; }

                        if (gridMatematica.Rows.Count > 0) { report.Subreports["submatematica"].SetDataSource(ds2); }
                        else { report.PageHeaderSection3.SectionFormat.EnableSuppress = true; }

                        //  if (gridtreino.Rows.Count > 0) { report.Subreports["subtreino"].SetDataSource(ds3); }
                        //else { report.PageHeaderSection1.SectionFormat.EnableSuppress = true; }

                        if (gridpsico.Rows.Count > 0) { report.Subreports["subpsico"].SetDataSource(dsp); }
                        else { report.Section2.SectionFormat.EnableSuppress = true; }

                        report.PageHeaderSection1.SectionFormat.EnableSuppress = true;

                        Turma turma = (comboTurma.SelectedItem as Turma);
                        Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                        Pontuacao pontuacao =
                            Pontuacao.obterTodos()
                                .Find(
                                    p =>
                                        p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                        p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                        // Popula as Variaveis fixas do Report
                        (report.ReportHeaderSection1.ReportObjects["txtProfissional"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = nomeProfessor;

                        //  DateTime dtNasc = ((DateTime)(comboAluno.SelectedItem as Aluno).DataNascimento);

                        // (report.ReportHeaderSection1.ReportObjects["txtIdade"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                        //   .Text = (new DateTime(DateTime.Now.Subtract(dtNasc).Ticks).Year - 1).ToString();


                        (report.ReportHeaderSection1.ReportObjects["txtEscola"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                          .Text = (comboEscola.SelectedItem as Instituicao).Nome;


                        (report.ReportHeaderSection1.ReportObjects["txtAno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = turma.Nome;

                        (report.ReportHeaderSection1.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            ((DateTime)pontuacao.DataHora).ToShortDateString();


                        (report.ReportHeaderSection1.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            (comboAluno.SelectedItem as Aluno).Nome;



                        // Exporta o Report
                        report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        report.ExportToDisk(ExportFormatType.PortableDocFormat, path);

                        if (nomeArquivo == null) ((Master)MdiParent).MensagemSucesso("PDF Exportado!");
                    }
                }
                else
                {
                    ((Master)MdiParent).MensagemErro("Não contém resultados suficientes para gerar o relatório!");
                }
            }
            catch (Exception ex)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }

        private void btnEspecialista_Click(object sender, EventArgs e)
        {
            pdfEscola();
        }
               
        private void btnEspecRel_Click(object sender, EventArgs e)
        {
            try
            {
                if ((gridMatematica.Rows.Count > 0) || (gridPortugues.Rows.Count > 0) || (gridtreino.Rows.Count > 0))
                {

                    string nomeAluno = "";
                    string nomeTurma = "";
                    string nomeQuest = "";
                    string rootPath = ""; string path = "";
                    string ano = "";

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
                    nomeAluno = comboAluno.Text;
                    ano = nomeQuest.Substring(3, 1).ToString();

                    path = rootPath + "\\" + nomeQuest + "_" + nomeTurma + "_" + nomeAluno + ".pdf";


                    PDFEspecialistaV2 report = new PDFEspecialistaV2();
                  

                    // Constroi DataSet
                        DataSetReport ds = new DataSetReport();
                        DataSetReport2 ds2 = new DataSetReport2();
                        DataSetReport3 ds3 = new DataSetReport3();
                        DataSetPsico dsp = new DataSetPsico();

                        foreach (DataGridViewRow linha in gridPortugues.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {
                                    row[1] = "&nbsp;";

                                    row[3] = linha.Cells[2].Value.ToString();
                                    row[2] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        if (gridPortugues.Rows.Count > 0) { (ds.DataTable1.Rows[0] as DataRow)[0] = "Escuta dos sons da Língua Portuguesa"; }
                        if (gridPortugues.Rows.Count > 1) { (ds.DataTable1.Rows[1] as DataRow)[0] = "Escrita alfabética"; }
                        if (gridPortugues.Rows.Count > 2) { (ds.DataTable1.Rows[3] as DataRow)[0] = "Leitura e compreensão de texto"; }
                        if (gridPortugues.Rows.Count > 3) { (ds.DataTable1.Rows[2] as DataRow)[0] = "Planejamento do texto escrito"; }







                        foreach (DataGridViewRow linha in gridMatematica.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds2.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {

                                    row[1] = "&nbsp;";

                                    row[2] = linha.Cells[2].Value.ToString();
                                    row[3] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds2.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        if (gridMatematica.Rows.Count > 0) { (ds2.DataTable1.Rows[0] as DataRow)[0] = "Números"; }
                        if (gridMatematica.Rows.Count > 1) { (ds2.DataTable1.Rows[1] as DataRow)[0] = "Operações"; }
                        if (gridMatematica.Rows.Count > 2) { (ds2.DataTable1.Rows[2] as DataRow)[0] = "Espaço e forma"; }
                        if (gridMatematica.Rows.Count > 3) { (ds2.DataTable1.Rows[3] as DataRow)[0] = "Grandezas e tratamento da informação"; }



                        foreach (DataGridViewRow linha in gridtreino.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds3.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {

                                    row[1] = "&nbsp;";

                                    row[2] = linha.Cells[2].Value.ToString();
                                    row[3] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds3.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        if (gridtreino.Rows.Count > 0) { (ds3.DataTable1.Rows[0] as DataRow)[0] = "Processamento da Informação"; }
                        if (gridtreino.Rows.Count > 1) { (ds3.DataTable1.Rows[1] as DataRow)[0] = "Memória de Trabalho"; }
                        if (gridtreino.Rows.Count > 2) { (ds3.DataTable1.Rows[2] as DataRow)[0] = "Linguagem - Cognição Social"; }
                        if (gridtreino.Rows.Count > 3) { (ds3.DataTable1.Rows[3] as DataRow)[0] = "Linguagem - Vocabulário e Compreensão"; }


                        // Psicogenese
                        foreach (DataGridViewRow linha in gridpsico.Rows)
                        {

                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = dsp.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();
                                if (linha.Cells[1].Value == null)
                                {
                                    row[1] = "";
                                }
                                else
                                {
                                    row[1] = linha.Cells[1].Value.ToString();
                                }
                                row[2] = linha.Cells[2].Value.ToString();

                                dsp.DataTable1.Rows.Add(row);
                            }
                        }



                        // Constroi Report
                        PageMargins margem = report.PrintOptions.PageMargins;
                        margem.bottomMargin = 0;
                        margem.leftMargin = 0;
                        margem.rightMargin = 0;
                        margem.topMargin = 0;

                        report.PrintOptions.ApplyPageMargins(margem);


                        if (gridPortugues.Rows.Count > 0) { report.Subreports["subportugues"].SetDataSource(ds); }
                        else { report.PageHeaderSection2.SectionFormat.EnableSuppress = true; }

                        if (gridMatematica.Rows.Count > 0) { report.Subreports["submatematica"].SetDataSource(ds2); }
                        else { report.PageHeaderSection3.SectionFormat.EnableSuppress = true; }

                        if (gridtreino.Rows.Count > 0) { report.Subreports["subtreino"].SetDataSource(ds3); }
                        else { report.PageHeaderSection1.SectionFormat.EnableSuppress = true; }

                        if (gridpsico.Rows.Count > 0) { report.Subreports["subpsico"].SetDataSource(dsp); }
                        else { report.Section2.SectionFormat.EnableSuppress = true; }


                        Turma turma = (comboTurma.SelectedItem as Turma);
                        Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                        Pontuacao pontuacao =
                            Pontuacao.obterTodos()
                                .Find(
                                    p =>
                                        p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                        p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                        // Popula as Variaveis fixas do Report
                        (report.ReportHeaderSection1.ReportObjects["txtProfissional"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = turma.Nome;

                          DateTime dtNasc = ((DateTime)(comboAluno.SelectedItem as Aluno).DataNascimento);

                         (report.ReportHeaderSection1.ReportObjects["txtIdade"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                           .Text = (new DateTime(DateTime.Now.Subtract(Convert.ToDateTime(dtNasc)).Ticks).Year - 1).ToString();


                         //(report.ReportHeaderSection1.ReportObjects["txtOBS"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                         //     .Text = nomeProfessor;


                        (report.ReportHeaderSection1.ReportObjects["txtAno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = ano;

                        (report.ReportHeaderSection1.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            ((DateTime)pontuacao.DataHora).ToShortDateString();


                        (report.ReportHeaderSection1.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            (comboAluno.SelectedItem as Aluno).Nome;



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
            catch (Exception ex)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }

        private void btnTdsAlunosEscola_Click(object sender, EventArgs e)
        {
            if(comboEscola.SelectedItem != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string auxPath;
                    string path = dialog.FileName;
                    Instituicao escola = comboEscola.SelectedItem as Instituicao;
                    List<Questionario> vetQuestionario;

                    if (escola.Turma.Count > 0)
                    {
                        foreach (var turma in escola.Turma)
                        {
                            comboTurma.SelectedItem = turma;
                            comboTurma.Update();
                            if (turma.Aluno.Count > 0)
                            {
                                foreach (var aluno in turma.Aluno)
                                {
                                    comboQuestionario.Items.Clear();
                                    gridMatematica.ClearSelection();
                                    gridPortugues.ClearSelection();

                                    comboAluno.SelectedItem = aluno;
                                    comboAluno.Update();
                                    vetQuestionario = new List<Questionario>();

                                    foreach (var resultado in aluno.Resultado)
                                    {
                                        if (!vetQuestionario.Contains(resultado.Questionario))
                                        {
                                            vetQuestionario.Add(resultado.Questionario);
                                        }
                                    }
                                    
                                    if (vetQuestionario.Count > 0)
                                    {
                                        foreach (var quest in vetQuestionario)
                                        {
                                            auxPath = "";
                                            auxPath = path + "_" + escola.Nome.ToString() + "_" + turma.Nome.ToString() + "_" + aluno.Nome.ToString() + "_" + quest.Nome.ToString() + ".pdf";
                                            comboQuestionario.SelectedItem = quest;
                                            comboQuestionario.Update();
                                            btnGerarRelatorio.PerformClick();
                                            pdfEscola(" ", auxPath);

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            // RELATORIO MATEMATICA OU APRENDIZAGEM

            try
            {
                if ((gridMatematica.Rows.Count > 0) || (gridPortugues.Rows.Count > 0) || (gridtreino.Rows.Count > 0))
                {
                    string dataAplicacao = txtDtAplic.Text;
                    string nomeAluno = "";
                    string nomeTurma = "";
                    string nomeQuest = "";
                    string rootPath = "";string path = "";

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
                    nomeAluno = comboAluno.Text;

                    path = rootPath + "\\" + nomeQuest + "_" + nomeTurma + "_" + nomeAluno + ".pdf";
                    
                  
                        PDFAluno report = new PDFAluno();

                        // Constroi DataSet
                        DataSetReport ds = new DataSetReport();
                        DataSetReport2 ds2 = new DataSetReport2();
                        DataSetReport3 ds3 = new DataSetReport3();
                        DataSetPsico dsp = new DataSetPsico();

                        foreach (DataGridViewRow linha in gridPortugues.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {
                                    row[1] = "&nbsp;";

                                    row[3] = linha.Cells[2].Value.ToString();
                                    row[2] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        if (gridPortugues.Rows.Count > 0) { (ds.DataTable1.Rows[0] as DataRow)[0] = "Escuta dos sons da Língua Portuguesa"; }
                        if (gridPortugues.Rows.Count > 1) { (ds.DataTable1.Rows[1] as DataRow)[0] = "Escrita alfabética"; }
                        if (gridPortugues.Rows.Count > 2) { (ds.DataTable1.Rows[3] as DataRow)[0] = "Leitura e compreensão de texto"; }
                        if (gridPortugues.Rows.Count > 3) { (ds.DataTable1.Rows[2] as DataRow)[0] = "Planejamento do texto escrito"; }







                        foreach (DataGridViewRow linha in gridMatematica.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds2.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {

                                    row[1] = "&nbsp;";

                                    row[2] = linha.Cells[2].Value.ToString();
                                    row[3] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds2.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        if (gridMatematica.Rows.Count > 0) { (ds2.DataTable1.Rows[0] as DataRow)[0] = "Números"; }
                        if (gridMatematica.Rows.Count > 1) { (ds2.DataTable1.Rows[1] as DataRow)[0] = "Operações"; }
                        if (gridMatematica.Rows.Count > 2) { (ds2.DataTable1.Rows[2] as DataRow)[0] = "Espaço e forma"; }
                        if (gridMatematica.Rows.Count > 3) { (ds2.DataTable1.Rows[3] as DataRow)[0] = "Grandezas e tratamento da informação"; }



                        foreach (DataGridViewRow linha in gridtreino.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds3.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {

                                    row[1] = "&nbsp;";

                                    row[2] = linha.Cells[2].Value.ToString();
                                    row[3] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds3.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        if (gridtreino.Rows.Count > 0) { (ds3.DataTable1.Rows[0] as DataRow)[0] = "Processamento da Informação"; }
                        if (gridtreino.Rows.Count > 1) { (ds3.DataTable1.Rows[1] as DataRow)[0] = "Memória de Trabalho"; }
                        if (gridtreino.Rows.Count > 2) { (ds3.DataTable1.Rows[2] as DataRow)[0] = "Linguagem - Cognição Social"; }
                        if (gridtreino.Rows.Count > 3) { (ds3.DataTable1.Rows[3] as DataRow)[0] = "Linguagem - Vocabulário e Compreensão"; }


                        // Psicogenese
                        foreach (DataGridViewRow linha in gridpsico.Rows)
                        {

                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = dsp.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();
                                if (linha.Cells[1].Value == null)
                                {
                                    row[1] = "";
                                }
                                else
                                {
                                    row[1] = linha.Cells[1].Value.ToString();
                                }
                                row[2] = linha.Cells[2].Value.ToString();

                                dsp.DataTable1.Rows.Add(row);
                            }
                        }



                        // Constroi Report
                        PageMargins margem = report.PrintOptions.PageMargins;
                        margem.bottomMargin = 0;
                        margem.leftMargin = 0;
                        margem.rightMargin = 0;
                        margem.topMargin = 0;

                        report.PrintOptions.ApplyPageMargins(margem);


                        if (gridPortugues.Rows.Count > 0) { report.Subreports["subportugues"].SetDataSource(ds); }
                        else { report.PageHeaderSection2.SectionFormat.EnableSuppress = true; }

                        if (gridMatematica.Rows.Count > 0) { report.Subreports["submatematica"].SetDataSource(ds2); }
                        else { report.PageHeaderSection3.SectionFormat.EnableSuppress = true; }

                        if (gridtreino.Rows.Count > 0) { report.Subreports["subtreino"].SetDataSource(ds3); }
                        else { report.PageHeaderSection1.SectionFormat.EnableSuppress = true; }

                        if (gridpsico.Rows.Count > 0) { report.Subreports["subpsico"].SetDataSource(dsp); }
                        else { report.Section2.SectionFormat.EnableSuppress = true; }


                        Turma turma = (comboTurma.SelectedItem as Turma);
                        Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                        Pontuacao pontuacao =
                            Pontuacao.obterTodos()
                                .Find(
                                    p =>
                                        p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                        p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                        // Popula as Variaveis fixas do Report
                        (report.ReportHeaderSection1.ReportObjects["txtProfissional"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = turma.Nome;


                        (report.ReportHeaderSection1.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = dataAplicacao;                            


                        (report.ReportHeaderSection1.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            (comboAluno.SelectedItem as Aluno).Nome;

                   

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
            catch (Exception ex)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            // RELATORIO LINGUA PORTUGUESA E HÍBRIDOS

            try
            {
                if ((gridMatematica.Rows.Count > 0) || (gridPortugues.Rows.Count > 0) || (gridtreino.Rows.Count > 0))
                {
                   
                    string dataAplicacao = txtDtAplic.Text;
  
                    string nomeAluno = "";
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
                    nomeAluno = comboAluno.Text;

                    path = rootPath + "\\" + nomeQuest + "_" + nomeTurma + "_" + nomeAluno + ".pdf";


                    PDFAlunoLP report = new PDFAlunoLP();

                        // Constroi DataSet
                        DataSetReport ds = new DataSetReport();
                        DataSetReport2 ds2 = new DataSetReport2();
                        DataSetReport3 ds3 = new DataSetReport3();
                        DataSetPsico dsp = new DataSetPsico();

                        foreach (DataGridViewRow linha in gridPortugues.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {
                                    row[1] = "&nbsp;";

                                    row[3] = linha.Cells[2].Value.ToString();
                                    row[2] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        if (gridPortugues.Rows.Count > 0) { (ds.DataTable1.Rows[0] as DataRow)[0] = "Escuta dos sons da Língua Portuguesa"; }
                        if (gridPortugues.Rows.Count > 1) { (ds.DataTable1.Rows[1] as DataRow)[0] = "Escrita alfabética"; }
                        if (gridPortugues.Rows.Count > 2) { (ds.DataTable1.Rows[3] as DataRow)[0] = "Leitura e compreensão de texto"; }
                        if (gridPortugues.Rows.Count > 3) { (ds.DataTable1.Rows[2] as DataRow)[0] = "Planejamento do texto escrito"; }







                        foreach (DataGridViewRow linha in gridMatematica.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds2.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {

                                    row[1] = "&nbsp;";

                                    row[2] = linha.Cells[2].Value.ToString();
                                    row[3] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds2.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        if (gridMatematica.Rows.Count > 0) { (ds2.DataTable1.Rows[0] as DataRow)[0] = "Números"; }
                        if (gridMatematica.Rows.Count > 1) { (ds2.DataTable1.Rows[1] as DataRow)[0] = "Operações"; }
                        if (gridMatematica.Rows.Count > 2) { (ds2.DataTable1.Rows[2] as DataRow)[0] = "Espaço e forma"; }
                        if (gridMatematica.Rows.Count > 3) { (ds2.DataTable1.Rows[3] as DataRow)[0] = "Grandezas e tratamento da informação"; }



                        foreach (DataGridViewRow linha in gridtreino.Rows)
                        {
                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds3.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();

                                int count = linha.Cells[1].Value.ToString().Length;

                                try
                                {

                                    row[1] = "&nbsp;";

                                    row[2] = linha.Cells[2].Value.ToString();
                                    row[3] = linha.Cells[3].Value.ToString();

                                    row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                    ds3.DataTable1.Rows.Add(row);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        if (gridtreino.Rows.Count > 0) { (ds3.DataTable1.Rows[0] as DataRow)[0] = "Processamento da Informação"; }
                        if (gridtreino.Rows.Count > 1) { (ds3.DataTable1.Rows[1] as DataRow)[0] = "Memória de Trabalho"; }
                        if (gridtreino.Rows.Count > 2) { (ds3.DataTable1.Rows[2] as DataRow)[0] = "Linguagem - Cognição Social"; }
                        if (gridtreino.Rows.Count > 3) { (ds3.DataTable1.Rows[3] as DataRow)[0] = "Linguagem - Vocabulário e Compreensão"; }


                        // Psicogenese
                        foreach (DataGridViewRow linha in gridpsico.Rows)
                        {

                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = dsp.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();
                                if (linha.Cells[1].Value == null)
                                {
                                    row[1] = "";
                                }
                                else
                                {
                                    row[1] = linha.Cells[1].Value.ToString();
                                }
                                row[2] = linha.Cells[2].Value.ToString();

                                dsp.DataTable1.Rows.Add(row);
                            }
                        }



                        // Constroi Report
                        PageMargins margem = report.PrintOptions.PageMargins;
                        margem.bottomMargin = 0;
                        margem.leftMargin = 0;
                        margem.rightMargin = 0;
                        margem.topMargin = 0;

                        report.PrintOptions.ApplyPageMargins(margem);


                        if (gridPortugues.Rows.Count > 0) { report.Subreports["subportugues"].SetDataSource(ds); }
                        else { report.PageHeaderSection2.SectionFormat.EnableSuppress = true; }

                        if (gridMatematica.Rows.Count > 0) { report.Subreports["submatematica"].SetDataSource(ds2); }
                        else { report.PageHeaderSection3.SectionFormat.EnableSuppress = true; }

                        if (gridtreino.Rows.Count > 0) { report.Subreports["subtreino"].SetDataSource(ds3); }
                        else { report.PageHeaderSection1.SectionFormat.EnableSuppress = true; }

                        if (gridpsico.Rows.Count > 0) { report.Subreports["subpsico"].SetDataSource(dsp); }
                        else { report.Section2.SectionFormat.EnableSuppress = true; }


                        Turma turma = (comboTurma.SelectedItem as Turma);
                        Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                        Pontuacao pontuacao =
                            Pontuacao.obterTodos()
                                .Find(
                                    p =>
                                        p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                        p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                        // Popula as Variaveis fixas do Report
                        (report.ReportHeaderSection1.ReportObjects["txtProfissional"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = turma.Nome;
                    

                        (report.ReportHeaderSection1.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = dataAplicacao;


                        (report.ReportHeaderSection1.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            (comboAluno.SelectedItem as Aluno).Nome;



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
            catch (Exception ex)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }

        private void btnEspecRelatApr_Click(object sender, EventArgs e)
        {

            
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((gridMatematica.Rows.Count > 0) || (gridPortugues.Rows.Count > 0) || (gridtreino.Rows.Count > 0))
                {

                    string nomeAluno = "";
                    string nomeTurma = "";
                    string nomeQuest = "";
                    string rootPath = ""; string path = "";
                    string ano = "";

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
                    nomeAluno = comboAluno.Text;
                    ano = nomeQuest.Substring(3, 1).ToString();

                    path = rootPath + "\\" + nomeQuest + "_" + nomeTurma + "_" + nomeAluno + ".pdf";


                    PDFEspecialistaV2_APR report = new PDFEspecialistaV2_APR();


                    // Constroi DataSet
                    DataSetReport3 ds3 = new DataSetReport3();
                  
                   foreach (DataGridViewRow linha in gridtreino.Rows)
                    {
                        if (linha.Cells[0].Value != null)
                        {
                            DataRow row = ds3.DataTable1.NewRow();

                            row[0] = linha.Cells[0].Value.ToString();

                            int count = linha.Cells[1].Value.ToString().Length;

                            try
                            {

                                row[1] = "&nbsp;";

                                row[2] = linha.Cells[2].Value.ToString();
                                row[3] = linha.Cells[3].Value.ToString();

                                row[4] = linha.Cells[1].Value.ToString().Substring(0, 1);

                                ds3.DataTable1.Rows.Add(row);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }


                    if (gridtreino.Rows.Count > 0) { (ds3.DataTable1.Rows[0] as DataRow)[0] = "Processamento da Informação"; }
                    if (gridtreino.Rows.Count > 1) { (ds3.DataTable1.Rows[1] as DataRow)[0] = "Memória de Trabalho"; }
                    if (gridtreino.Rows.Count > 2) { (ds3.DataTable1.Rows[2] as DataRow)[0] = "Linguagem - Cognição Social"; }
                    if (gridtreino.Rows.Count > 3) { (ds3.DataTable1.Rows[3] as DataRow)[0] = "Linguagem - Vocabulário e Compreensão"; }


              
                    // Constroi Report
                    PageMargins margem = report.PrintOptions.PageMargins;
                    margem.bottomMargin = 0;
                    margem.leftMargin = 0;
                    margem.rightMargin = 0;
                    margem.topMargin = 0;

                    report.PrintOptions.ApplyPageMargins(margem);

             

                    if (gridtreino.Rows.Count > 0) { report.Subreports["subtreino"].SetDataSource(ds3); }
                    else { report.PageHeaderSection1.SectionFormat.EnableSuppress = true; }

                    Turma turma = (comboTurma.SelectedItem as Turma);
                    Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                    Pontuacao pontuacao =
                        Pontuacao.obterTodos()
                            .Find(
                                p =>
                                    p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                    p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                    // Popula as Variaveis fixas do Report
                    (report.ReportHeaderSection1.ReportObjects["txtProfissional"] as
                        CrystalDecisions.CrystalReports.Engine.TextObject)
                        .Text = turma.Nome;

                    DateTime dtNasc = ((DateTime)(comboAluno.SelectedItem as Aluno).DataNascimento);

                    (report.ReportHeaderSection1.ReportObjects["txtIdade"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                      .Text = (new DateTime(DateTime.Now.Subtract(Convert.ToDateTime(dtNasc)).Ticks).Year - 1).ToString();

                    (report.ReportHeaderSection1.ReportObjects["txtAno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                        .Text = ano;

                    (report.ReportHeaderSection1.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                        .Text
                        =
                        ((DateTime)pontuacao.DataHora).ToShortDateString();


                    (report.ReportHeaderSection1.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                        .Text
                        =
                        (comboAluno.SelectedItem as Aluno).Nome;



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
            catch (Exception ex)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }
    }



    public class AreaCalculada
    {
        public Area area { get; set; }
        public int max { get; set; }
        public int min { get; set; }

        public int cor { get; set; }
    }

    public class ItemReportAluno
    {
        public Area area { get; set; }

        public Aluno aluno { get; set; }

        public int cor { get; set; }

        public int pontuacaoReal { get; set; }

        public double score { get; set; }

        public double scoreTurma { get; set; }

    }

    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }

    class DataGridViewProgressCell : DataGridViewImageCell
    {
        // Used to make custom cell consistent with a DataGridViewImageCell
        static Image emptyImage;
        static DataGridViewProgressCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewProgressCell()
        {
            this.ValueType = typeof(string);
        }
        // Method required to make the Progress Cell consistent with the default Image Cell. 
        // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        protected override object GetFormattedValue(object value,
                            int rowIndex, ref DataGridViewCellStyle cellStyle,
                            TypeConverter valueTypeConverter,
                            TypeConverter formattedValueTypeConverter,
                            DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }
        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                double valor = 0;
                Color corBarra = Color.White;

                if (value.ToString() == "-1" || value == null || value.ToString() == "")
                {
                    valor = 0;
                }
                else
                {

                    try
                    {

                        string valorStr = value.ToString().Remove(0, 2);
                        valor = double.Parse(valorStr);

                        int cor = Convert.ToInt32(value.ToString().Substring(0, 1));

                        if (cor == 0)
                        {
                            corBarra = Color.Tomato;
                        }
                        else if (cor == 1)
                        {
                            corBarra = Color.Yellow;
                            valor = valor - 25;
                        }
                        else if (cor == 2)
                        {
                            corBarra = Color.FromArgb(203, 235, 108);
                            valor = valor - 50;
                        }
                        else if (cor == 3)
                        {
                            corBarra = Color.DeepSkyBlue;
                            valor = valor - 75;
                        }

                        valor = valor * 4;
                    }
                    catch (Exception ex)
                    {
                        valor = 0;
                        corBarra = Color.White;
                    }

                }

                int progressVal = (int) valor;


              //  float percentage = ((float) progressVal/100.0f);
                float percentage = ((float)100.0f);
                float percentageReal = ((float)progressVal);
                    // Need to convert to float before division; otherwise C# returns int which is 0 for anything but 100%.
                Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                Brush foreColorBrush = new SolidBrush(corBarra);
                // Draws the cell grid
                base.Paint(g, clipBounds, cellBounds,
                    rowIndex, cellState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                if (percentage > 0.0)
                {
                    // Draw the progress bar and the text
                    g.FillRectangle(new SolidBrush(corBarra), cellBounds.X + 2,
                        cellBounds.Y + 2, Convert.ToInt32((percentage*cellBounds.Width - 4)), cellBounds.Height - 4);
                    g.DrawString(percentageReal.ToString() + "%", cellStyle.Font, new SolidBrush(Color.Black),
                        cellBounds.X + (cellBounds.Width / 2) - 5, cellBounds.Y + 2);
                    //g.DrawString("", cellStyle.Font, foreColorBrush,
                    //    cellBounds.X + (cellBounds.Width/2) - 5, cellBounds.Y + 2);

                }
                else
                {
                    // draw the text
                    if (this.DataGridView.CurrentRow.Index == rowIndex)
                    {
                        g.DrawString("", cellStyle.Font,
                            new SolidBrush(Color.Black), cellBounds.X + 6, cellBounds.Y + 2);
                        //g.DrawString("", cellStyle.Font,
                        //    new SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2);
                    }
                    else
                        g.DrawString("", cellStyle.Font, foreColorBrush, cellBounds.X + 6,
                            cellBounds.Y + 2);
                }
                
            }
            catch (Exception ex) { }

        }
    }
}
