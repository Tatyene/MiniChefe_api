namespace MiniChefe.Models
{
    public class Receita
    {
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public double Custo { get; set; }
        public double Tempo_Preparo { get; set; }
        public int id_Ingrediente { get; set; }
        public int id_Porcoes { get; set; }
        public int id_Preparo { get; set; }
        public byte Imagem { get; set; }
        public string Tipo { get; set; }

    }
}
