namespace Mixer
{
    public class Musica
    {
        public string Arquivo { get; set; }
        public Musica() { } 
        public Musica(string arquivo)
        {
            Arquivo = arquivo;
        }
    }
}