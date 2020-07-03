namespace WppConsole
{
    public class Mensagem
    {
        public string Texto { get; set; }
        
        public Contato Destinatario { get; set; } 

        /// <summary>
        /// Enviar mensagem
        /// </summary>
        /// <param name="_contato"> Contato para quem a mensagem será enviada </param>
        /// <returns> mensagem enviada </returns>
        public string Enviar(Contato _contato)
        {
            Destinatario = _contato;
            
            Texto = System.Console.ReadLine();

            return $"Texto: {Texto}\nPara: {Destinatario.Nome} {Destinatario.Telefone}";
        }
        }
}