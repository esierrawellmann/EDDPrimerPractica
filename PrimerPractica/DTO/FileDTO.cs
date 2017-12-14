using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica.DTO
{
    public class FileDTO
    {
        [JsonProperty("archivo")]
        public Archivo archivo { get; set; }
    }

    public class Archivo {
        [JsonProperty("pila")]
        public Pila pila { get; set; }
        [JsonProperty("cola")]
        public Cola cola { get; set; }
    }

    public class Pila {
        [JsonProperty("matrices")]
        public Matrices matrices { get; set; }
    }
    public class Cola {
        [JsonProperty("matrices")]
        public Matrices matrices { get; set; }
    }

    public class Matrices
    {
        [JsonProperty("matriz")]
        public List<Matriz> matriz { get; set; }
}

    public class Matriz : Nodo { 
        [JsonProperty("size_x")]
        public string size_x { get; set; }
        [JsonProperty("size_y")]
        public string size_y { get; set; }
        [JsonProperty("valores")]
        public Valores valores { get; set; }

    }

    public class Valores {
        [JsonProperty("valor")]
        public List<Valor> valor { get; set; }
    }
    public class Valor : Nodo
    {
        [JsonProperty("pos_x")]
        public string pos_x { get; set; }
        [JsonProperty("pos_y")]
        public string pos_y { get; set; }
        [JsonProperty("dato")]
        public string dato { get; set; }
    }
}
