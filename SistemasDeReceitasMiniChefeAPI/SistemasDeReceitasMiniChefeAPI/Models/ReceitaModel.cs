namespace SistemasDeReceitasMiniChefeAPI.Models
{
    public class ReceitaModel
    {
        public int id { get; set; }

        public string? titulo { get; set; }

        public string? descricao { get; set; }

        public string? ingredientes { get; set; }

        public string preparo { get; set; }

        //public byte[]? imagem { get; set; }
    }
}
