using System.Collections.Generic;

namespace MasterarbeitRestServer.Models 
{
    public class Autor
    {
        public int ID { get; set; }
        public string VORNAME { get; set; }
        public string NACHNAME { get; set; }
        public int ALTER { get; set; }
        public string ORT { get; set; }
        public string LAND { get; set; }
        public int GROESSE { get; set; }
        public List<Buch> BUECHER { get; set; }
    }
}