# TesteEstagio
Prova de entrevista de estágio em C#

Processo de funcionamento do sistema

* Definidas duas principais classes do programa
  1.  private static Random rand = new Random(); -> responsável por criar os randomicos de nomes e notas;
  2.  public class Alunos -> onde recebe todos os atributos dos alunos

* Criada uma List<Alunos>: onde serão armazenadas todas as informações dos alunos
 
* Declaração de variáveis e métodos 
  - Pesos das notas
  - Base de dados para nomes randomicos
  - Métodos de Gerar nomes, notas e criar alunos
  
 * Etapas de funcionamento:
  1. Cria os alunos usando um laço
  2. Realiza o cálculo das médias dos alunos, filtra e condiciona as médias atribuindo o valor para os status
    a. Aprovado = media >=6
    b. Reprovado = media < 4
    c. Prova Final

  3. Atribui o valor da Prova Final apenas aos alunos que possuem o status "Prova Final"
  4. Ordena os alunos pelas médias e aplica um laço for nos 5 primeiros indices. Lógicamente, os que possuem as maiores médias
  5. Aos 5 alunos, gera nota da competição, e realiza o calculo da média final da competição;
  6. Organiza novamente os alunos pela Média final da competição
  7. Declara o aluno[0] como campeão
              
             Console.WriteLine($"Parabéns, {alunos[0].Name}! Você é Campeão da competição Escolar, com a Média final {alunos[0].MediaFinal:f1}");

  FIM
