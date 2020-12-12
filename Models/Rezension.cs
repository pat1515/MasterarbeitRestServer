using System;

namespace MasterarbeitRestServer.Models
{
    public class Rezension
    {
        public int Id { get; set; }
        public int Buch_Id { get; set; }
        public DateTime Datum { get; set; }
        public int Sterne { get; set; }
    }
}