using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ForRent { get; set; }
        public bool Arended { get; set; }
        public string Arendator { get; set; }
        public int ArendatorNumber { get; set; }

    }
}
