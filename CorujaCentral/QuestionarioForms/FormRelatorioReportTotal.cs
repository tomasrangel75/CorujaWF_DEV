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
    public partial class FormRelatorioReportTotal : MetroFramework.Forms.MetroForm
    {
        private bool listarAlunos;

        public FormRelatorioReportTotal()
        {
            InitializeComponent();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            listarAlunos = ckAlunos.Checked;

            if (listarAlunos)
            {
                gerarRelatorioPorAluno();
            }
            else
            {
                gerarRelatorioPorTurma();
            }

            btnCSV.Enabled = true;
        }

        public void gerarRelatorioPorTurma()
        {
            gridTotal.Columns.Clear();
            gridTotal.Rows.Clear();

            gridTotal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTotal.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);


            gridTotal.RowHeadersVisible = false;
            gridTotal.AllowUserToAddRows = false;

            gridTotal.Columns.Add("Col1", "Escola");
            gridTotal.Columns.Add("Col2", "Turma");
            gridTotal.Columns.Add("Col3", "Questionario");
            gridTotal.Columns.Add("Col4", "Eixo");

            DataGridViewColumn colunaGrafico = new DataGridViewProgressColumn();
            colunaGrafico.HeaderText = "Gráfico";
            colunaGrafico.Name = "Col5";

            gridTotal.Columns.Add(colunaGrafico);
            gridTotal.Columns.Add("Col6", "Média Turma");
            gridTotal.Columns.Add("Col7", "Média Escola");

            gridTotal.Rows.Clear();


            foreach (var inst in Instituicao.obterTodos())
            {
                Instituicao escola = inst as Instituicao;

                foreach (var turma in escola.Turma)
                {
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

                    foreach (var questionario in vetQuestionario)
                    {
                        carregaTurmaQuestionario(turma, questionario);
                    }
                }

            }
        }

        public void gerarRelatorioPorAluno()
        {
            gridTotal.Columns.Clear();
            gridTotal.Rows.Clear();

            gridTotal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTotal.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);


            gridTotal.RowHeadersVisible = false;
            gridTotal.AllowUserToAddRows = false;

            gridTotal.Columns.Add("Col1", "Escola");
            gridTotal.Columns.Add("Col2", "Turma");
            gridTotal.Columns.Add("Col3", "Questionario");
            gridTotal.Columns.Add("Col4", "Aluno");
            gridTotal.Columns.Add("Col5", "Eixo");

            DataGridViewColumn colunaGrafico = new DataGridViewProgressColumn();
            colunaGrafico.HeaderText = "Gráfico";
            colunaGrafico.Name = "Col6";

            gridTotal.Columns.Add(colunaGrafico);
            gridTotal.Columns.Add("Col7", "Pontuação");
            gridTotal.Columns.Add("Col8", "Média Turma");
            gridTotal.Columns.Add("Col9", "Média Escola");

            gridTotal.Columns.Add("Col10", "Caminho");
            gridTotal.Columns.Add("Col11", "Acertou");
            gridTotal.Columns.Add("Col12", "Errou");
            gridTotal.Columns.Add("Col13", "Acertou Dica");
            gridTotal.Columns.Add("Col14", "Errou Dica");
            gridTotal.Columns.Add("Col14", "ID Aluno");


            gridTotal.Rows.Clear();


            foreach (var inst in Instituicao.obterTodos())
            {
                Instituicao escola = inst as Instituicao;

                foreach (var turma in escola.Turma)
                {
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

                    foreach (var questionario in vetQuestionario)
                    {
                        foreach (var aluno in turma.Aluno)
                        {
                            if (
                                aluno.Pontuacao.ToList()
                                    .Exists(
                                        p =>
                                            (p.Questao != null) &&
                                            (p.Questao.Questionario_id == questionario.idQuestionario)))
                            {
                                carregaAlunoQuestionario(aluno, turma, questionario);
                            }
                        }
                    }
                }

            }
        }

        public void carregaAlunoQuestionario(Aluno aluno, Turma turma, Questionario questionario)
        {
            // Computa as árvores
            // CARRREGA AS AREAS CONTEMPLADAS NO RELATORIO

            List<AreaCalculada> vetAreaCalculada = new List<AreaCalculada>();

            List<Questao> vetQuestoesValidas = questionario.Questao.ToList();
            vetQuestoesValidas.RemoveAll(q => q.TipoQuestao_id == 4);
            List<Area> vetAreasRelatorio = new List<Area>();

            List<Area> areasTotal = new List<Area>();

            vetQuestoesValidas.ForEach(q => areasTotal.Add(q.Area));
            areasTotal = areasTotal.ToList().Distinct().ToList();

            areasTotal = areasTotal.OrderBy(a => a.idArea).ToList();

            vetAreasRelatorio.AddRange(areasTotal);


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

            List<ItemReportTotalAluno> vetItensRelatorio = new List<ItemReportTotalAluno>();

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
                    ItemReportTotalAluno itemRelatorio = new ItemReportTotalAluno();
                    itemRelatorio.aluno = aluno;
                    itemRelatorio.area = area;
                    itemRelatorio.escola = turma.Instituicao;
                    itemRelatorio.turma = turma;
                    itemRelatorio.questionario = questionario;

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

                        itemRelatorio.scoreEscola = calculaResultadoEscola(vetAreaCalculada, turma, questionario, area);

                        // Calcula o caminho
                       // vetPontuacaoAluno.Sort((ps1, ps2) => DateTime.Compare((DateTime)ps1.DataHora, (DateTime)ps2.DataHora));

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
                                    if (pontuacao.Acertou == true)
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
                        }

                        itemRelatorio.caminhoCompleto = caminhoCompleto;
                        itemRelatorio.caminhoAcertos = caminhoAcertos;
                        itemRelatorio.caminhoErros = caminhoErros;
                        itemRelatorio.caminhoAcertouDicas = caminhoAcertouDicas;
                        itemRelatorio.caminhoErrouDicas = caminhoErrouDicas;


                    }

                    vetItensRelatorio.Add(itemRelatorio);
                }
            }

            foreach (var area in areasTotal)
            {
                ItemReportTotalAluno itemReport = vetItensRelatorio.Find(i => i.area.idArea == area.idArea);

                if (itemReport != null)
                {
                    if (itemReport.pontuacaoReal >= 0 && itemReport.score >= 0)
                    {

                        double socreFormatado = Math.Round(itemReport.score, 1);
                        string grafico = itemReport.cor.ToString() + ";" + socreFormatado.ToString();
                        double socreTurmaFormatado = Math.Round(itemReport.scoreTurma, 1);

                        double socreEscolaFormatado = Math.Round(itemReport.scoreEscola, 1);

                        gridTotal.Rows.Add(itemReport.escola.Nome, itemReport.turma.Nome, itemReport.questionario.Nome,
                            itemReport.aluno.Nome, area.Nome, grafico, socreFormatado.ToString(), 
                            socreTurmaFormatado.ToString(), socreEscolaFormatado.ToString(),
                            itemReport.caminhoCompleto, itemReport.caminhoAcertos, itemReport.caminhoErros, itemReport.caminhoAcertouDicas, itemReport.caminhoErrouDicas,
                            aluno.idAluno.ToString()
                            );
                    }
                    else
                    {
                        gridTotal.Rows.Add("", "", "", "", area.Nome, "-1", "", "", "", "", "", "", "", "", "");
                    }
                }
            }

        }

        public void carregaTurmaQuestionario(Turma turma, Questionario questionario)
        {

            // Computa as árvores
            // CARRREGA AS AREAS CONTEMPLADAS NO RELATORIO

            List<AreaCalculada> vetAreaCalculada = new List<AreaCalculada>();

            List<Questao> vetQuestoesValidas = questionario.Questao.ToList();
            vetQuestoesValidas.RemoveAll(q => q.TipoQuestao_id == 4);
            List<Area> vetAreasRelatorio = new List<Area>();

            List<Area> areasTotal = new List<Area>();

            vetQuestoesValidas.ForEach(q => areasTotal.Add(q.Area));
            areasTotal = areasTotal.ToList().Distinct().ToList();

            areasTotal = areasTotal.OrderBy(a => a.idArea).ToList();

            vetAreasRelatorio.AddRange(areasTotal);

            foreach (var area in vetAreasRelatorio)
            {
                List<Questao> vetQuestoesArea = vetQuestoesValidas.FindAll(p => p.Area_id.Equals(area.idArea));

                int maxOrd = (int) vetQuestoesValidas.OrderByDescending(q => q.Ordem).ToList()[0].Ordem;

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

            List<ItemReportTotal> vetItensRelatorio = new List<ItemReportTotal>();

            foreach (var area in vetAreasRelatorio)
            {
                ItemReportTotal itemRelatorio = new ItemReportTotal();
                itemRelatorio.turma = turma;
                itemRelatorio.escola = turma.Instituicao;
                itemRelatorio.questionario = questionario;

                // Calcula o score da turma
                int corTurma;
                itemRelatorio.score = calculaResultadoTurma(vetAreaCalculada, turma, questionario, area, out corTurma);
                itemRelatorio.cor = corTurma;
                itemRelatorio.area = area;

                itemRelatorio.scoreEscola = calculaResultadoEscola(vetAreaCalculada, turma, questionario, area);

                vetItensRelatorio.Add(itemRelatorio);
            }

            foreach (var area in areasTotal)
            {

                ItemReportTotal itemReport = vetItensRelatorio.Find(i => i.area.idArea == area.idArea);

                if (itemReport != null)
                {
                    if (itemReport.score >= 0)
                    {

                        double socreFormatado = Math.Round(itemReport.score, 1);
                        string grafico = itemReport.cor.ToString() + ";" + socreFormatado.ToString();
                        double socreTurmaFormatado = Math.Round(itemReport.scoreEscola, 1);

                        gridTotal.Rows.Add(itemReport.escola.Nome, itemReport.turma.Nome, itemReport.questionario.Nome,
                            area.Nome, grafico, socreFormatado.ToString(), socreTurmaFormatado.ToString());
                    }
                    else
                    {
                        gridTotal.Rows.Add(itemReport.escola.Nome, itemReport.turma.Nome, itemReport.questionario.Nome,
                            area.Nome, "-1", "", "");
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

        public double calculaResultadoTurma(List<AreaCalculada> vetAreaCalculada, Turma turma, Questionario questionario,
            Area area, out int corTurma)
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
                        corUltima = (int) ultimaCorParse;
                    }
                    else
                    {
                        Color ultimaCor = ColorTranslator.FromHtml(ultima.Questao.Cor);

                        ItemRelatorioAluno.corRelatorio ultimaCorParse =
                            ItemRelatorioAluno.convertCorRelatorioFromColor(ultimaCor);
                        corUltima = (int) ultimaCorParse;
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

        public double calculaResultadoEscola(List<AreaCalculada> vetAreaCalculada, Turma turma,
            Questionario questionario, Area area)
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
                            .Exists(
                                p =>
                                    (p.Questao != null) &&
                                    p.Questao.Questionario.idQuestionario == questionario.idQuestionario))
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
                        corUltima = (int) ultimaCorParse;
                    }
                    else
                    {
                        Color ultimaCor = ColorTranslator.FromHtml(ultima.Questao.Cor);

                        ItemRelatorioAluno.corRelatorio ultimaCorParse =
                            ItemRelatorioAluno.convertCorRelatorioFromColor(ultimaCor);
                        corUltima = (int) ultimaCorParse;
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
                resultadoEscola = acumulador/divisor;
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

                var headers = gridTotal.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(";", headers.Select(column => column.HeaderText).ToArray()));

                foreach (DataGridViewRow row in gridTotal.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();

                    sb.AppendLine(string.Join(";",
                        cells.Select(cell => formataValor(cell.Value, cell.ColumnIndex)).ToArray()));
                }

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

                ((Master) MdiParent).MensagemSucesso("Relatório Exportado!");
            }
        }

        private string formataValor(object valor, int ind)
        {
            if (valor == null)
                return "";

            int indiceGrafico = 4;

            if (listarAlunos)
                indiceGrafico = 5;



            if (ind == indiceGrafico)
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

            return valor.ToString();
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
                resultadoTurma = acumulador / divisor;
            }

            return resultadoTurma;
        }
    }

    public class ItemReportTotal
    {
        public Instituicao escola { get; set; }

        public Questionario questionario { get; set; }

        public Area area { get; set; }

        public Turma turma { get; set; }

        public int cor { get; set; }

        public double score { get; set; }

        public double scoreEscola { get; set; }

    }

    public class ItemReportTotalAluno
    {
        public Instituicao escola { get; set; }

        public Questionario questionario { get; set; }

        public Turma turma { get; set; }

        public Area area { get; set; }

        public Aluno aluno { get; set; }

        public int cor { get; set; }

        public int pontuacaoReal { get; set; }

        public double score { get; set; }

        public double scoreTurma { get; set; }

        public double scoreEscola { get; set; }

        public string caminhoCompleto { get; set; }
        public string caminhoAcertos { get; set; }
        public string caminhoErros { get; set; }
        public string caminhoAcertouDicas { get; set; }
        public string caminhoErrouDicas { get; set; }

    }

}
