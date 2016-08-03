using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Library.Persistencia
{
    public class Gerenciador
    {
        private static QuestEntities _contexto;

        private static QuestEntities _contextoImportar;
        private static QuestEntities _contextoAluno;
        public static string _caminhoImportar;

        public static QuestEntities getContexto()
        {
            if(_contexto == null)
            {
                _contexto = new QuestEntities();
            }

            return _contexto;
        }

        public static QuestEntities getContextoProva(string conexao)
        {
            if(_contextoAluno == null)
                _contextoAluno = new QuestEntities(conexao);

            return _contextoAluno;
        }

        public static void setContextoProva(QuestEntities cont)
        {
            _contexto = cont;
        }

     // Export DB
        public static void exportarBanco(Questionario questionario, List<Turma> vetTurma, string caminhoBanco)
        {
            string conn = ConfigurationManager.
                    ConnectionStrings["BancoExportar"].ConnectionString;

            conn = conn.Replace("#PARAMETRO#", caminhoBanco);

            // Exportação do BANCO
           
            // Cria o Banco do Aluno
            QuestEntities dbAluno = new QuestEntities(conn);
          //  dbAluno.Database.CreateIfNotExists();
            dbAluno.Database.Initialize(true);

            // Cria o questionario
            Questionario questionarioAluno = new Questionario();
            questionarioAluno.idQuestionario = questionario.idQuestionario;
            questionarioAluno.idBase = questionario.idQuestionario;
            questionarioAluno.Nome = questionario.Nome;
            questionarioAluno.RepetePergunta = questionario.RepetePergunta;
            questionarioAluno.Descricao = questionario.Descricao;
            questionarioAluno.Cor = questionario.Cor;
            questionarioAluno.Nivel_id = questionario.Nivel_id;

            // Cria o arquivo do questionário a ser exportado

        

            if (questionario.Arquivo != null)
            {
                Arquivo arquivoQuestionario = new Arquivo();
                arquivoQuestionario.Nome = questionario.Arquivo.Nome;
                if (questionario.Arquivo_id != null) arquivoQuestionario.idArquivo = (long) questionario.Arquivo_id;
                arquivoQuestionario.NomeFisico = questionario.Arquivo.NomeFisico;
                arquivoQuestionario.CaminhoFisico = questionario.Arquivo.CaminhoFisico;
                arquivoQuestionario.Extensao = questionario.Arquivo.Extensao;
                arquivoQuestionario.TipoArquivo_id = questionario.Arquivo.TipoArquivo_id;
                questionarioAluno.Arquivo = arquivoQuestionario;

                dbAluno.Arquivo.Add(arquivoQuestionario);
            }

            // Adiciona o questionário no Banco
            
            dbAluno.Questionario.Add(questionarioAluno);

            // Adiciona as áreas
            foreach (var area in Area.obterTodos().OrderBy(a => a.idArea))
            {
                Area areaAluno = new Area();
                areaAluno.idArea = area.idArea;
                areaAluno.Nome = area.Nome;
                areaAluno.Disciplina_id = area.Disciplina_id;

                dbAluno.Area.Add(areaAluno);
            }

            // Adiciona as questões e seus relacionamentos
            foreach (Questao questao in questionario.Questao)
            {
                Questao questaoAluno = new Questao();
                questaoAluno.Titulo = questao.Titulo;
                questaoAluno.Cor = questao.Cor;
                questaoAluno.Ordem = questao.Ordem;
                questaoAluno.PosicaoPergunta = questao.PosicaoPergunta;
                questaoAluno.PosicaoRespostas = questao.PosicaoRespostas;
                questaoAluno.Questionario = questionarioAluno;
                questaoAluno.Tentativas = questao.Tentativas;
                questaoAluno.TipoQuestao_id = questao.TipoQuestao_id;
                questaoAluno.idQuestao = questao.idQuestao;
                questaoAluno.idBase = questao.idQuestao;
                questaoAluno.Disciplina_id = questao.Disciplina_id;
                questaoAluno.Area_id = questao.Area_id;
                questaoAluno.Peso = questao.Peso;
                questaoAluno.TAG = questao.TAG;
                questaoAluno.Hint = questao.Hint;
                questaoAluno.Enfileirada = questao.Enfileirada;
                questaoAluno.Ano = questao.Ano;
                questaoAluno.Semestre = questao.Semestre;
                questaoAluno.Competencia = questao.Competencia;

                dbAluno.Questao.Add(questaoAluno);

                foreach (var item in questao.ItemQuestao)
                {
                    ItemQuestao itemAlunoQuestao  = new ItemQuestao();
                    itemAlunoQuestao.idItemQuestao = item.idItemQuestao;
                    itemAlunoQuestao.idBase = item.idItemQuestao;
                    itemAlunoQuestao.Questao_id = questaoAluno.idQuestao;
                    itemAlunoQuestao.Titulo = item.Titulo;
                    itemAlunoQuestao.OpcaoCorreta = item.OpcaoCorreta;
                    itemAlunoQuestao.EPergunta = item.EPergunta;
                    itemAlunoQuestao.Eresposta = item.Eresposta;
                    itemAlunoQuestao.ETentativa = item.ETentativa;
                    itemAlunoQuestao.OrdemTela = item.OrdemTela;
                    itemAlunoQuestao.OrdemResposta = item.OrdemResposta;
                    itemAlunoQuestao.ContemImagem = item.ContemImagem;
                    itemAlunoQuestao.ContemAudio = item.ContemAudio;

                    dbAluno.ItemQuestao.Add(itemAlunoQuestao);

                    foreach (var itemArquivo in item.ItemArquivo)
                    {
                        Arquivo arquivoAluno = new Arquivo();
                        arquivoAluno.idArquivo = itemArquivo.Arquivo_id;
                        arquivoAluno.Nome = itemArquivo.Arquivo.Nome;
                        arquivoAluno.NomeFisico = itemArquivo.Arquivo.NomeFisico;
                        arquivoAluno.CaminhoFisico = itemArquivo.Arquivo.CaminhoFisico;
                        arquivoAluno.Extensao = itemArquivo.Arquivo.Extensao;
                        arquivoAluno.TipoArquivo_id = itemArquivo.Arquivo.TipoArquivo_id;

                        dbAluno.Arquivo.Add(arquivoAluno);

                        ItemArquivo itemArqAluno = new ItemArquivo();
                        itemArqAluno.ItemQuestao_id = itemAlunoQuestao.idItemQuestao;
                        itemArqAluno.Arquivo_id = arquivoAluno.idArquivo;
                        itemArqAluno.Posicao = itemArquivo.Posicao;
                        itemArqAluno.Tamanho = itemArquivo.Tamanho;
                        itemArqAluno.X = itemArquivo.X;
                        itemArqAluno.Y = itemArquivo.Y;

                        dbAluno.ItemArquivo.Add(itemArqAluno);

                    }

                }
            }

            // Salva parcialmente para poder criar os saltos em seguida com o banco já preenchido
            dbAluno.SaveChanges();

            // Adiciona os Saltos

            List<Salto> vetSalto = new List<Salto>();
            questionario.Questao.ToList().ForEach(q => vetSalto.AddRange(q.Salto));

            foreach (var salto in vetSalto)
            {
                Salto saltoAluno = new Salto();
                saltoAluno.idSalto = salto.idSalto;
                saltoAluno.ItemQuestao = dbAluno.ItemQuestao.ToList()
                    .Find(i => i.idBase.Equals(salto.ItemQuestao_id));
                saltoAluno.Questao =
                    dbAluno.Questao.ToList().Find(q => q.idBase.Equals(salto.QuestaoDestino_id));
                saltoAluno.SaltarAoErrar = salto.SaltarAoErrar;
                saltoAluno.VoltarDoSalto = salto.VoltarDoSalto;

                dbAluno.Salto.Add(saltoAluno);
            }

            if (vetTurma.Count > 0)
            {
                List<Instituicao> vetEscolasIncluidas = new List<Instituicao>();

                foreach (var turma in vetTurma)
                {
                    Instituicao escola = null;

                    if (!vetEscolasIncluidas.Exists(e => e.idInstituicao.Equals(turma.Instituicao.idInstituicao)))
                    {
                        escola = new Instituicao();
                        escola.Nome = turma.Instituicao.Nome;
                        escola.idInstituicao = turma.Instituicao.idInstituicao;
                        vetEscolasIncluidas.Add(escola);
                        dbAluno.Instituicao.Add(escola);
                    }
                    else
                    {
                        escola = vetEscolasIncluidas.Find(e => e.idInstituicao.Equals(turma.Instituicao_id));
                    }

                    Turma turmaDbAluno = new Turma();
                    turmaDbAluno.Nome = turma.Nome;
                    turmaDbAluno.Instituicao = escola;


                    dbAluno.Turma.Add(turmaDbAluno);

                    foreach (var aluno in turma.Aluno)
                    {
                        Aluno alunoDbAluno = new Aluno();
                        alunoDbAluno.Nome = aluno.Nome;
                        alunoDbAluno.Turma = turmaDbAluno;

                        dbAluno.Aluno.Add(alunoDbAluno);
                    }
                }
            }


            dbAluno.SaveChanges();

        }

     // Import DB
        #region Importacao

        public static bool inicializaBancoImporatar(string caminho)
        {
            bool iniciou = true;

            string conn = ConfigurationManager.
                   ConnectionStrings["BancoExportar"].ConnectionString;

            conn = conn.Replace("#PARAMETRO#", caminho);

            try
            {
                // Cria o Banco do Aluno
                _contextoImportar = new QuestEntities(conn);
               // _contextoImportar.Database.CreateIfNotExists();
                _contextoImportar.Database.Initialize(true);

                // Tenta obter questionarios
                List<Questionario> vetQUestionario = _contextoImportar.Questionario.ToList();


                if (File.Exists(caminho))
                {
                    FileInfo info = new FileInfo(caminho);

                    _caminhoImportar = info.DirectoryName + "\\";
                }

            }
            catch (Exception)
            {
                iniciou = false;
            }

            return iniciou;
        }

        public static List<Questionario> retornaQUestionariosImportacao()
        {
            return _contextoImportar.Questionario.ToList();
        }

        public static Aluno retornaAlunoImportacao()
        {
            Aluno aluno = _contextoImportar.Aluno.ToList().Find(a => a.DataCadastro != null);

            return aluno;
        }

        public static bool importarProva(Aluno alunoLocal, Aluno alunoProva, Questionario questionarioLocal,
            Questionario questionarioProva, out string mensagem)
        {
            bool sucesso = false;
            mensagem = "";

            try
            {
                QuestEntities contextoLocal = Gerenciador.getContexto();

                List<Pontuacao> vetPontuacaoImportar =
                    _contextoImportar.Pontuacao.ToList()
                        .FindAll(p => p.Questao.Questionario.idBase.Equals(questionarioLocal.idQuestionario));

                if (vetPontuacaoImportar.Count > 0)
                {

                    //Apaga as pontuacoes existentes
                    List<Pontuacao> vetPontExistente = contextoLocal.Pontuacao.ToList()
                        .FindAll(
                            p =>
                                p.Aluno_id.Equals(alunoLocal.idAluno) &&
                                p.Questao.Questionario.idQuestionario.Equals(questionarioLocal.idQuestionario));

                    if (vetPontExistente.Count > 0)
                    {
                        vetPontExistente.ToList().ForEach(i => i.deletar(i));
                    }

                    foreach (var pontuacao in vetPontuacaoImportar)
                    {
                        Pontuacao pontuacaoNova =
                            contextoLocal.Pontuacao.ToList()
                                .Find(
                                    p =>
                                        p.Aluno_id.Equals(alunoLocal.idAluno) &&
                                        p.Questao_id.Equals((long) pontuacao.Questao.idBase));

                        if (pontuacaoNova == null)
                        {
                            pontuacaoNova = new Pontuacao();
                            pontuacaoNova.Aluno = alunoLocal;
                            pontuacaoNova.Questao_id = (long) pontuacao.Questao.idBase;
                            pontuacaoNova.Acertou = pontuacao.Acertou;
                            pontuacaoNova.Tentativas = pontuacao.Tentativas;
                            pontuacaoNova.Tempo = pontuacao.Tempo;
                            pontuacaoNova.Mouse = pontuacao.Mouse;
                            pontuacaoNova.Clicks = pontuacao.Clicks;
                            pontuacaoNova.DataHora = pontuacao.DataHora;
                            contextoLocal.Pontuacao.Add(pontuacaoNova);
                        }
                        else
                        {
                            pontuacaoNova.Acertou = pontuacao.Acertou;
                            pontuacaoNova.Tentativas = pontuacao.Tentativas;
                            pontuacaoNova.Tempo = pontuacao.Tempo;
                            pontuacaoNova.Mouse = pontuacao.Mouse;
                            pontuacaoNova.Clicks = pontuacao.Clicks;
                            pontuacaoNova.DataHora = pontuacao.DataHora;

                            pontuacaoNova.atualizar(pontuacaoNova);
                        }
                    }

                    Resultado resultado =
                        questionarioProva.Resultado.ToList().Find(r => r.Aluno_id.Equals(alunoProva.idAluno));

                    Resultado resultadoNovo =
                        questionarioLocal.Resultado.ToList().Find(r => r.Aluno_id.Equals(alunoLocal.idAluno));

                    if (resultadoNovo == null)
                    {
                        resultadoNovo = new Resultado();
                        resultadoNovo.Questionario = questionarioLocal;
                        resultadoNovo.Aluno = alunoLocal;
                        resultadoNovo.TotalAcertos = resultado.TotalAcertos;
                        resultadoNovo.TotalErros = resultado.TotalErros;
                        if (resultado.Questao != null)
                            resultadoNovo.UltimaQuestao_id = resultado.Questao.idBase;

                        contextoLocal.Resultado.Add(resultadoNovo);
                    }
                    else
                    {
                        resultadoNovo.TotalAcertos = resultado.TotalAcertos;
                        resultadoNovo.TotalErros = resultado.TotalErros;
                        if (resultado.Questao != null)
                            resultadoNovo.UltimaQuestao_id = resultado.Questao.idBase;

                        resultadoNovo.atualizar(resultadoNovo);
                    }

                    contextoLocal.SaveChanges();

                    sucesso = true;
                }
                else
                {
                    sucesso = false;
                    mensagem = "Erro! Banco a ser importado não possui resultado.";
                }
            }
            catch (Exception)
            {
                sucesso = false;                
            }

            return sucesso;
        }

        public static bool importarQuestoes(List<Questao> vetquestao, Questionario questionarioLocal, out List<Questao> vetQuestoesNovas, bool manterOrdem)
        {
            bool sucesso = true;
            vetQuestoesNovas = new List<Questao>();

            try
            {
                QuestEntities contextoLocal = Gerenciador.getContexto();

                int ultimaOrdem = 0;

                if (!manterOrdem)
                {
                    // Pega a ultima ordem do questionario local para começar a inserir as questoes novas a partir dela              
                    if (questionarioLocal.Questao.Count > 0)
                    {
                        ultimaOrdem = (int) questionarioLocal.Questao.ToList().OrderBy(q => q.Ordem).Last().Ordem;
                    }
                }


                // Adiciona as questões e seus relacionamentos
                foreach (Questao questao in vetquestao)
                {
                    Questao questaoAluno = new Questao();
                    questaoAluno.Titulo = questao.Titulo;
                    questaoAluno.Cor = questao.Cor;
                    questaoAluno.PosicaoPergunta = questao.PosicaoPergunta;
                    questaoAluno.PosicaoRespostas = questao.PosicaoRespostas;
                    questaoAluno.Questionario = questionarioLocal;
                    questaoAluno.Tentativas = questao.Tentativas;
                    questaoAluno.TipoQuestao_id = questao.TipoQuestao_id;
                   // questaoAluno.idQuestao = questao.idQuestao;
                    questaoAluno.idBase = questao.idQuestao;
                    questaoAluno.Disciplina_id = questao.Disciplina_id;
                    questaoAluno.Peso = questao.Peso;
                    questaoAluno.TAG = questao.TAG;
                    questaoAluno.Hint = questao.Hint;
                    questaoAluno.Enfileirada = questao.Enfileirada;
                    questaoAluno.Ano = questao.Ano;
                    questaoAluno.Semestre = questao.Semestre;
                    questaoAluno.Competencia = questao.Competencia;

                    questaoAluno.Ordem = questao.Ordem + ultimaOrdem;

                    // Procura a área no questionario local
                    bool adiciona = true;
                    foreach (
                        var areaLocal in
                            contextoLocal.Area.ToList().FindAll(a => a.Disciplina_id.Equals(questao.Area.Disciplina_id)))
                    {
                        if (questao.Area.Nome.Trim().ToLower().Equals(areaLocal.Nome.Trim().ToLower()))
                        {
                            questaoAluno.Area_id = areaLocal.idArea;
                            adiciona = false;
                            break;
                        }
                    }

                    // não encontrou a área então adiciona
                    if (adiciona)
                    {
                        Area areaAluno = new Area();
                        areaAluno.idArea = questao.Area.idArea;
                        areaAluno.Nome = questao.Area.Nome;
                        areaAluno.Disciplina_id = questao.Area.Disciplina_id;

                        contextoLocal.Area.Add(areaAluno);

                        questaoAluno.Area_id = areaAluno.idArea;
                    }
                   

                    contextoLocal.Questao.Add(questaoAluno);
                    vetQuestoesNovas.Add(questaoAluno);

                    foreach (var item in questao.ItemQuestao)
                    {
                        ItemQuestao itemAlunoQuestao = new ItemQuestao();
                      //  itemAlunoQuestao.idItemQuestao = item.idItemQuestao;
                        itemAlunoQuestao.idBase = item.idItemQuestao;
                        itemAlunoQuestao.Questao = questaoAluno;
                        itemAlunoQuestao.Titulo = item.Titulo;
                        itemAlunoQuestao.OpcaoCorreta = item.OpcaoCorreta;
                        itemAlunoQuestao.EPergunta = item.EPergunta;
                        itemAlunoQuestao.Eresposta = item.Eresposta;
                        itemAlunoQuestao.ETentativa = item.ETentativa;
                        itemAlunoQuestao.OrdemTela = item.OrdemTela;
                        itemAlunoQuestao.OrdemResposta = item.OrdemResposta;
                        itemAlunoQuestao.ContemImagem = item.ContemImagem;
                        itemAlunoQuestao.ContemAudio = item.ContemAudio;

                        contextoLocal.ItemQuestao.Add(itemAlunoQuestao);

                        foreach (var itemArquivo in item.ItemArquivo)
                        {
                            Arquivo arquivoAluno = new Arquivo();
                            //arquivoAluno.idArquivo = itemArquivo.Arquivo_id;
                            arquivoAluno.Nome = itemArquivo.Arquivo.Nome;
                            arquivoAluno.NomeFisico = itemArquivo.Arquivo.NomeFisico;
                            arquivoAluno.CaminhoFisico = itemArquivo.Arquivo.CaminhoFisico;
                            arquivoAluno.Extensao = itemArquivo.Arquivo.Extensao;
                            arquivoAluno.TipoArquivo_id = itemArquivo.Arquivo.TipoArquivo_id;

                            contextoLocal.Arquivo.Add(arquivoAluno);

                            ItemArquivo itemArqAluno = new ItemArquivo();
                            itemArqAluno.ItemQuestao = itemAlunoQuestao;
                            itemArqAluno.Arquivo = arquivoAluno;
                            itemArqAluno.Posicao = itemArquivo.Posicao;
                            itemArqAluno.Tamanho = itemArquivo.Tamanho;
                            itemArqAluno.X = itemArquivo.X;
                            itemArqAluno.Y = itemArquivo.Y;

                            contextoLocal.ItemArquivo.Add(itemArqAluno);

                        }

                    }
                }

                // Salva parcialmente para poder criar os saltos em seguida com o banco já preenchido
                contextoLocal.SaveChanges();

                // Adiciona os Saltos

                List<Salto> vetSalto = new List<Salto>();
                vetquestao.ForEach(q => vetSalto.AddRange(q.Salto));

                foreach (var salto in vetSalto)
                {
                    Salto saltoAluno = new Salto();
                   // saltoAluno.idSalto = salto.idSalto;
                    saltoAluno.ItemQuestao = contextoLocal.ItemQuestao.ToList()
                        .Find(i => i.idBase.Equals(salto.ItemQuestao_id));
                    saltoAluno.Questao =
                        contextoLocal.Questao.ToList().Find(q => q.idBase.Equals(salto.QuestaoDestino_id));
                    saltoAluno.SaltarAoErrar = salto.SaltarAoErrar;
                    saltoAluno.VoltarDoSalto = salto.VoltarDoSalto;

                    contextoLocal.Salto.Add(saltoAluno);
                }

                contextoLocal.SaveChanges();
            }
            catch (Exception)
            {
                sucesso = false;
            }

            return sucesso;
        }

        public static void limparImportacao(List<Questao> vetQuestoes )
        {
            QuestEntities contextoLocal = Gerenciador.getContexto();

            foreach (var questao in vetQuestoes)
            {
                questao.idBase = null;
                questao.atualizar(questao);

                foreach (var itemQuestao in questao.ItemQuestao)
                {
                    itemQuestao.idBase = null;
                    itemQuestao.atualizar(itemQuestao);
                }
            }

            contextoLocal.SaveChanges();

        }

        #endregion

        // Efetua atualizacoes de dados fixos do banco de novas versões
        public static void atualizaBanco()
        {
            // Novo tipo Pscicogenese Criado
            TipoQuestao tipoPsicogenese = getContexto().TipoQuestao.ToList().Find(t => t.Nome.Equals("Psicogenese"));

            if (tipoPsicogenese == null)
            {
                TipoQuestao tipoNovo = new TipoQuestao();
                tipoNovo.Nome = "Psicogenese";
                tipoNovo.idTipoQuestao = 4;

                getContexto().TipoQuestao.Add(tipoNovo);
                getContexto().SaveChanges();
            }

            // Mudança no nome dos niveis
            List<Nivel> vetNiveis = getContexto().Nivel.ToList();

            if (vetNiveis.OrderBy(n => n.idNivel).ToList()[0].Nome != "1")
            {
                int contN = 1;
                foreach (var nivel in vetNiveis.OrderBy(n => n.idNivel))
                {
                    nivel.Nome = contN.ToString();
                    nivel.atualizar(nivel);
                    contN++;
                }
            }

            // Adição da Disciplina de Treino
            Disciplina disciplinaTreino = getContexto().Disciplina.ToList().Find(d => d.Nome.Equals("Treino"));

            if (disciplinaTreino == null)
            {
                Disciplina novaDisciplinaTreino = new Disciplina();
                novaDisciplinaTreino.Nome = "Treino";
                novaDisciplinaTreino.idDisciplina = 3;
                getContexto().Disciplina.Add(novaDisciplinaTreino);
                getContexto().SaveChanges();
            }

        }
    }
}
