namespace MasterarbeitRestServer.Models 
{
    public class Autor
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }
        public int Groesse { get; set; }
        public string Adresse { get; set; }
        public string Ort { get; set; }
        public string Land { get; set; }
    }
}