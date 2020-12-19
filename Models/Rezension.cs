using System;

namespace MasterarbeitRestServer.Models
{
    public class Rezension
    {
        public int ID { get; set; }
        public int BUCH_ID { get; set; }
        public DateTime DATUM { get; set; }
        public int STERNE { get; set; }
    }
}