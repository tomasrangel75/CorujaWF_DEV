using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Persistencia;

namespace Prova
{
    public class Controlador
    {
        private QuestEntities contexto;

        private static Controlador _controlador;
        public Questionario questionario;
        public Questao questaoAtual;

        public static Controlador getControlador()
        {
            if (_controlador == null)
            {
                _controlador = new Controlador();
            }

            return _controlador;
        }

        public List<Instituicao> getEscola()
        {
            return contexto.Instituicao.ToList();
        }

        public List<Turma> getTurmas()
        {
            return contexto.Turma.ToList();
        }

        public List<Aluno> getAlunos()
        {
            return contexto.Aluno.ToList();
        }

        public Pontuacao getPontuacaoAluno(long idAluno, long idQuestao)
        {
            Pontuacao pontuacao =
                contexto.Pontuacao.ToList().Find(p => p.Aluno_id.Equals(idAluno) && p.Questao_id.Equals(idQuestao));

            return pontuacao;
        }

        public Resultado getResultadoAluno(long idAluno)
        {
            Resultado resultado =
                contexto.Resultado.ToList()
                    .Find(r => r.Aluno_id.Equals(idAluno) && r.Questionario_id.Equals(questionario.idQuestionario));

            return resultado;
        }

        public bool verificaQuestionario(string conexao, out string mensagem)
        {
            mensagem = "";

            try
            {
                contexto = Gerenciador.getContextoProva(conexao);

                questionario = contexto.Questionario.FirstOrDefault();

                // Verifica se contém arquivo de questionario
                if (questionario.Arquivo != null)
                {
                    string caminho = questionario.Arquivo.NomeFisico;

                    if (!String.IsNullOrEmpty(caminho))
                    {
                        caminho = questionario.DiretorioProva + caminho;

                        if (!File.Exists(caminho))
                        {
                            mensagem = "Arquivo de vídeo do questionário não está na pasta!" +
                                       "Deveria conter esse arquivo: " + caminho;
                            return false;
                        }
                    }
                }

                // Verifica a existencia das questoes
                foreach (var questao in questionario.Questao.OrderBy(q => q.Ordem))
                {
                    string caminhoQuestao = questao.DiretorioProva;

                    if (!Directory.Exists(caminhoQuestao))

                    {
                        mensagem = "A pasta da questão: " + questao.Ordem + "de nome: " + questao.idQuestao +
                                   " não está na pasta do questionário: " + questao.DiretorioProva;
                        return false;
                    }

                    foreach (ItemQuestao itemQuestao in questao.ItemQuestao)
                    {
                        foreach (var itemArquivo in itemQuestao.ItemArquivo)
                        {
                            string caminhoArquivo = itemArquivo.Arquivo.NomeFisico;

                            if (!String.IsNullOrEmpty(caminhoArquivo))
                            {
                                caminhoArquivo = questao.DiretorioProva + caminhoArquivo;

                                if (!File.Exists(caminhoArquivo))
                                {
                                    mensagem = "Um arquivo de uma questão está faltando! Questão: " + questao.Ordem +
                                               " Arquivo: " + itemArquivo.Arquivo.Nome + " Ele deveria estar em: " +
                                               caminhoArquivo;
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                mensagem = "Houve um problema ao ler o Banco de Dados!";
                return false;
            }

            return true;
        }

        public void incluirAluno(Aluno aluno)
        {
            if (aluno != null)
            {
                aluno.adicionar(aluno);
            }
        }

        public void incluirEscola(Instituicao escola)
        {
            if (escola != null)
            {
                escola.adicionar(escola);
            }
        }

        public void incluirTurma(Turma turma)
        {
            if (turma != null)
            {
                turma.adicionar(turma);
            }
        }

        public Aluno getAluno()
        {
            List<Aluno> vetAlunos =
                contexto.Aluno.ToList()
                    .FindAll(a => a.DataCadastro != null)
                    .OrderByDescending(d => d.DataCadastro)
                    .ToList();

            if (vetAlunos.Count > 0)
            {
                return vetAlunos[0];
            }

            return null;
        }

        public void apagarAluno (Aluno aluno)
        {
            contexto.Aluno.Remove(aluno);
            contexto.SaveChanges();
        }

        public void apagarTurma (Turma turma)
        {
            contexto.Turma.Remove(turma);
            contexto.SaveChanges();
        }

        public void apagarEscola (Instituicao escola)
        {
            contexto.Instituicao.Remove(escola);
            contexto.SaveChanges();
        }

        public void limparAlunosAtuais()
        {
            List<Aluno> vetAlunos =
                contexto.Aluno.ToList()
                    .FindAll(a => a.DataCadastro != null).ToList();

            foreach (var aluno in vetAlunos)
            {
                aluno.DataCadastro = null;
                aluno.atualizar(aluno);
            }
        }

        public void inicializaAplicacao(string conexao)
        {
            contexto = Gerenciador.getContextoProva(conexao);
            Gerenciador.setContextoProva(contexto);

            questionario = contexto.Questionario.FirstOrDefault();

        }

        public void apagarProvaAtual()
        {
            Aluno aluno = getAluno();
            limparAlunosAtuais();

            contexto.Pontuacao.ToList().FindAll(p => p.Aluno_id == aluno.idAluno).ForEach(p => p.deletar(p));
            contexto.Resultado.ToList().FindAll(r => r.Aluno_id == aluno.idAluno).ForEach(p => p.deletar(p));

            contexto.SaveChanges();
        }
    }
}
