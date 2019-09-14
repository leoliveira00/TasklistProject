using System;
using System.Linq;
using System.Collections.Generic;
using TasklistProject1.Data;
using TasklistProject1.Models;
using System.Globalization;

namespace TasklistProject.Data
{
    public static class DbInitializer
    {
        /*
         * Entity Framework criará um banco de dados vazio. 
         * O método Initialize é chamado depois que o banco de dados é criado para populá-lo com os dados de teste.
         * O código verifica se há registros no banco de dados e, se não há, pressupõe-se que o banco de dados é novo 
         * e precisa ser propagado com os dados de teste.
         */
        public static void Initialize(TasklistContext context)
        {
            /*
             * Cria o banco de dados automaticamente
             */
            context.Database.EnsureCreated();
            
            /*
             * Não executa inserção se o banco já estiver povoado
             */
            if (context.Tasklists.Any())
            {
                return;
            }

            /*
             * Dados de teste
             */
            var tasklists = new List<Tasklist>
            {
                new Tasklist
                {
                    TaskTitulo = "Lorem ipsum dolor sit amet"
                    ,TaskDescricao = "Proin laoreet, enim vitae sagittis interdum, felis erat efficitur nunc, at venenatis " +
                                     "est ligula eu nulla. Aliquam ultricies, mi vitae semper sagittis, augue leo accumsan " +
                                     "nisi, non luctus sapien urna in sem. Integer gravida sem non nisi faucibus, id viverra orci hendrerit"
                    ,TaskDataCriacao = DateTime.Parse("2019-09-14", new CultureInfo("pt-BR"))
                    ,TaskStatus = Status.ABERTO
                }
                ,new Tasklist
                {
                    TaskTitulo = "Donec ultricies velit vel quam venenatis"
                    ,TaskDescricao = "In interdum sed mi sed lobortis. Pellentesque sollicitudin lacus eget rhoncus ultrices. Nullam " +
                                     "lacinia venenatis orci a tempus."
                    ,TaskDataCriacao = DateTime.Parse("2019-09-14", new CultureInfo("pt-BR"))
                    ,TaskStatus = Status.ABERTO
                }
                ,new Tasklist
                {
                    TaskTitulo = "Aliquam ac molestie est"
                    ,TaskDescricao = "Nulla condimentum eget mauris quis ultrices. Ut euismod finibus felis, vitae condimentum metus " +
                                     "convallis id. Phasellus sodales, dui ut tempus ultricies, nisi elit lacinia purus, quis viverra " +
                                     "justo lectus ultrices velit."
                    ,TaskDataCriacao = DateTime.Parse("2019-09-14", new CultureInfo("pt-BR"))
                    ,TaskStatus = Status.ABERTO
                }
                ,new Tasklist
                {
                    TaskTitulo = "Pellentesque laoreet sagittis est"
                    ,TaskDescricao = "Phasellus vitae risus erat. Suspendisse ullamcorper fringilla purus sagittis pharetra. Nam sed " +
                                     "sollicitudin dolor. Nullam ullamcorper eleifend sem in scelerisque. Integer aliquet mi ultrices orci " +
                                     "laoreet accumsan. Duis et nibh id tortor scelerisque pellentesque. Maecenas vehicula et ipsum ac faucibus. " +
                                     "Aenean sed orci nec ex venenatis iaculis vitae non ante."
                    ,TaskDataCriacao = DateTime.Parse("2019-09-14", new CultureInfo("pt-BR"))
                    ,TaskStatus = Status.ABERTO
                }
            };

            /*
             * Percorre a lista adicionando as entidades ao contexto do banco de dados.
             */
            tasklists.ForEach(t => context.Tasklists.Add(t));
            context.SaveChanges();
        }
    }
}
