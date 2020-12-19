using System;

namespace MasterarbeitRestServer.DTO 
{
    public class BuchDTO
    {
        public int ID { get; set; }
        public int AUTOR_ID { get; set; }
        public string TITEL { get; set; }
        public string ISBN { get; set; }
        public DateTime ERSCHEINUNGSDATUM { get; set; }
        public string VERLAG { get; set; }
        public int AUFLAGE { get; set; }
        public string SPRACHE { get; set; }
        public string DRUCKORT { get; set; }
    }
}