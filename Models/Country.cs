namespace CountryAPI.Models
{

    // todos estão permitindo valores nulos [testado]
    public record Country
    {
        public string? Name { get; set; } 
        public Flag? Flags { get; set; }  
    }

    public record Flag
    {
        public string? Png { get; set; }   
        public string? Svg { get; set; }   
    }
}

/* caso queira inicar as propriedades com valores padrão
{
    public record Country
    {
        public string Name { get; set; } = string.Empty;  // Inicializa com string vazia
        public Flag Flags { get; set; } = new Flag();     // Inicializa com uma nova instância de Flag
    }

    public record Flag
    {
        public string Png { get; set; } = string.Empty;   // Inicializa com string vazia
        public string Svg { get; set; } = string.Empty;   // Inicializa com string vazia
    }
}
*/