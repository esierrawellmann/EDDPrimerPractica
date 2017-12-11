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
        Archivo archivo { get; set; }
    }

    public class Archivo {
        [JsonProperty("pila")]
        Pila pila { get; set; }
        [JsonProperty("cola")]
        Cola cola { get; set; }
    }

    public class Pila {
        [JsonProperty("matrices")]
        Matrices matrices { get; set; }
    }
    public class Cola {
        [JsonProperty("matrices")]
        Matrices matrices { get; set; }
    }

    public class Matrices
    {
        [JsonProperty("matriz")]
        List<Matriz> matriz { get; set; }
}

    public class Matriz {
        [JsonProperty("size_x")]
        string size_x { get; set; }
        [JsonProperty("size_y")]
        string size_y { get; set; }
        [JsonProperty("valores")]
        Valores valores { get; set; }

    }

    public class Valores {
        [JsonProperty("valor")]
        List<Valor> valor { get; set; }
    }
    public class Valor
    {
        [JsonProperty("pos_x")]
        string pos_x { get; set; }
        [JsonProperty("pos_y")]
        string pos_y { get; set; }
        [JsonProperty("dato")]
        string dato { get; set; }
    }
}
