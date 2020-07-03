using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WppConsole
{
    public class Agenda : IAgenda
    {

        List<Contato> contatos = new List<Contato>();

        private const string PATH = "Database/agenda.csv";
        private const string Folder = "C:/Users/User/Desktop/EAD SENAI/EAD DEV/Aula_31/WppConsole/Database";

        public Agenda()
        {
            //Cria o arquivo caso não exista
            if(!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
            //Cria o arquivo caso não exista
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Cadastrar Contatos
        /// </summary>
        /// <param name="_contato"> Contato a ser adicionado à agenda </param>
        public void Cadastrar(Contato _contato)
        {
            contatos.Add(_contato);
            string[] linhas = new string[] { PrepararLinhaCSV(_contato) };
            File.AppendAllLines(PATH, linhas);

        }

        /// <summary>
        ///  Excluir contato
        /// </summary>
        /// <param name="_contato"> contato excluido </param>
        public void Excluir(Contato _contato)
        { 
            contatos.Remove(_contato);
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                contatos.Remove(_contato);
            }
        }

        public void Alterar(Contato _contato, Contato _contatoAlterado)
        {
            contatos.Remove(_contato);

            contatos.Add(_contatoAlterado);
        }

        // Adicionar a lista e mostrar
        /// <summary>
        /// Ler lista
        /// </summary>
        public void Listar()
        {
            List<Contato> agendaE = new List<Contato>();

            foreach(Contato c in contatos)
            {

                System.Console.WriteLine($"{c.Nome} - {c.Telefone}");

                agendaE.Add(c);
            }
            agendaE = agendaE.OrderBy(z => z.Nome).ToList();
        }

        /// <summary>
        /// Preparar linha do csv
        /// </summary>
        /// <param name="c"> contato linha </param>
        /// <returns>linha</returns>
        public string PrepararLinhaCSV(Contato c){
            
            return $"nome={c.Nome};telefone={c.Telefone}";

        }
    }
}