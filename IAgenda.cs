namespace WppConsole
{
    public interface IAgenda
    {
        // CRUD

        void Cadastrar(Contato _contato);
        void Excluir(Contato _contato);
        void Listar();
    }
}