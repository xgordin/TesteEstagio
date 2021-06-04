using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TesteEstagio {
    class Aluno {
        private static Random rand = new Random();
                
        public class Alunos {
                       
         
            public string Name { get; set; }
            public int Nota1 { get; set; }
            public int Nota2 { get; set; }
            public int Nota3 { get; set; }
            public int NotaFinal { get; set; }
            public int NotaComp { get; set; }
            public double Media { get; set; }
            public double MediaFinal { get; set; }
            public string Status { get; set; }


            public Alunos( string nome, int nota1, int nota2, int nota3, int notafinal, int notaComp, double media, double mediaFinal, string status) {
                this.Name = nome;

                this.Nota1 = nota1;
                this.Nota2 = nota2;
                this.Nota3 = nota3;
                this.NotaFinal = notafinal;
                this.NotaComp = notaComp;
                this.Status = status;
                this.Media = media;
                this.MediaFinal = mediaFinal;

            }
        }


        static List<Alunos> alunos;
        static void Main() {

            //Declaração de Variáveis

            //Variáveis de peso das notas
            int Peso1 = 1;
            double Peso2 = Peso1 + (Peso1 * 0.2);
            double Peso3 = Peso1 + (Peso1 * 0.4);
            int PesoEsp = 2;

            //Base de dados dos Randomicos 
            string[] PrimeiroNome = { "Michael", "Dwigth", "Jim","Mason","Jacob","William","Ethan","James",
                "Alexander","Michael","Benjamin","Elijah","Daniel","Aiden","Logan","Matthew","Lucas", };
            string[] SobreNome = { "da Silva", "Santos", "Maria", "Rocha", "da Cunha", "Scott", "Halpert", "Schrut" };


            int GerarNota() {
                return rand.Next(0, 11);
            }
            string GerarNome() {
                return PrimeiroNome[rand.Next(0, 17)] + " " + SobreNome[rand.Next(0, 8)];
            }
            void CriarAluno() {

                alunos.Add(new Alunos(GerarNome(), GerarNota(), GerarNota(), GerarNota(), notafinal: 0, notaComp: 0, media: 0, mediaFinal: 0, "Provas não realizadas"));
            }

            alunos = new List<Alunos>();

            //Criando os Alunos
            for (int i = 1; i <= 20; i++) {
                CriarAluno();
            }

            //Laço de atribuição de Médias, status 
            for (int i = 0; i < alunos.Count; i++) {

                var CalcMedia = (alunos[i].Nota1 * Peso1 + alunos[i].Nota2 * Peso2 + alunos[i].Nota3 * Peso3) / (Peso1 + Peso2 + Peso3);
                alunos[i].Media = (double)CalcMedia;

                if (alunos[i].Media >= 6) {
                    alunos[i].Status = "Aprovado";
                } else if (alunos[i].Media < 4) {
                    alunos[i].Status = "Reprovado";
                } else {
                    alunos[i].Status = "Prova Final";

                    if (alunos[i].Status == "Prova Final") {
                        alunos[i].NotaFinal = GerarNota();
                    var CalcMediaFinal = (alunos[i].Media + alunos[i].NotaFinal) / 2;

                    alunos[i].Media = CalcMediaFinal;

                    if (alunos[i].Media >= 5) {
                        alunos[i].Status = "Aprovado";
                    } else {
                        alunos[i].Status = "Reprovado";
                    }


                    }
                }

            }

            //ordenando alunos pela média, para filtrar os 5 melhores
            alunos.Sort((m1, m2) => m2.Media.CompareTo(m1.Media));

                Console.WriteLine("Os 5 melhores alunos e suas médias");
            //Aplicando a prova da competição
            for (int i = 0; i < 5; i++) {

                alunos[i].NotaComp = GerarNota();
                var CalcMediaF = (alunos[i].Nota1 * Peso1 + alunos[i].Nota2 * Peso1 + alunos[i].Nota3 * Peso1 + alunos[i].NotaFinal * Peso1 + alunos[i].NotaComp * PesoEsp) /
                                 (Peso1 + Peso1 + Peso1 + Peso1 + PesoEsp);

                alunos[i].MediaFinal = CalcMediaF;
                
                Console.WriteLine($"Nome: {alunos[i].Name} -  Média parcial: {alunos[i].Media:f1} - Nota da Competição: {alunos[i].NotaComp} -  Média Final: {alunos[i].MediaFinal}");
                

            }
            //Ordenando para declarar o indice [0] como vencedor
            alunos.Sort((m1, m2) => m2.MediaFinal.CompareTo(m1.MediaFinal));

            Console.WriteLine("\n");
            Console.WriteLine($"Parabéns, {alunos[0].Name}! Você é Campeão da competição Escolar, com a Média final {alunos[0].MediaFinal:f1}");



         

        }
    }
}

