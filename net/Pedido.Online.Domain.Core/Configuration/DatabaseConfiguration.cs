namespace Pedido.Online.Domain.Core.Configuration
{
    public class DatabaseConfiguration
    {
        public const string ConfigSectionPath = "ConnectionStrings";

        public string SqlConnection { get; set; }
        public string NoSqlConnection { get; set; }
        public string NoSqlDatabase { get; set; }
    }
}
