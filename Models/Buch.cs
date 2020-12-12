using System;

namespace MasterarbeitRestServer.Models
{
    public class Buch
    {
        public int Id { get; set; }
        public int Autor_Id { get; set; }
        public string Titel { get; set; }
        public string ISBN { get; set; }
        public DateTime Erscheinungsdatum { get; set; }
        public string Verlag { get; set; }
        public int Auflage { get; set; }
        public string Sprache { get; set; }
        public string Druckort { get; set; }
    }
}