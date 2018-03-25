using System.ComponentModel;

namespace CityBikeNYC.Data
{
    public class StationExtendedInfo
    {
        [Category("Ubicación"), DisplayName("Dirección")]
        public string stAddress1 { get; set; }
        [Category("General"), DisplayName("Huecos disponibles")]
        public string availableDocks { get; set; }
        [Category("General"), DisplayName("Huecos totales")]
        public string totalDocks { get; set; }
        [Category("Ubicación"), DisplayName("Latitud")]
        public string latitude { get; set; }
        [Category("Ubicación"), DisplayName("Longitud")]
        public string longitude { get; set; }
        [Category("General"), DisplayName("Código status")]
        public string statusKey { get; set; }
        [Category("General"), DisplayName("Estación de test")]
        public string testStation { get; set; }
        [Category("General"), DisplayName("Fecha últimos datos")]
        public string lastCommunicationTime { get; set; }
    }
}
