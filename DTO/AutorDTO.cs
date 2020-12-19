using System.Collections.Generic;

namespace MasterarbeitRestServer.DTO 
{
    public class AutorDTO
    {
        public int ID { get; set; }
        public string VORNAME { get; set; }
        public string NACHNAME { get; set; }
        public int LEBENSALTER { get; set; }
        public string ORT { get; set; }
        public string LAND { get; set; }
        public int GROESSE { get; set; }
        //public string ADRESSE { get; set; }


        public List<string> Buecher { get; set; } = new List<string>();
    }
}