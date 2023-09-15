namespace MiniChefe.Models
{
    public class Avaliacao
    {
        public int id { get; set; }
        public int id_Receita { get; set; }
        public int id_Usuario { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }
    }
}
