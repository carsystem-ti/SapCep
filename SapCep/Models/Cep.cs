using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapCep.Models
{
    public class Cep
    {
        public string cep { get; set; } //    "": "06184-150",
        public string logradouro { get; set; } /// "logradouro": "Rua Canela",
        public string complemento { get; set; }  //"complemento": "",
        public string bairro { get; set; } //"bairro": "Cidade das Flores",
        public string localidade { get; set; } //"localidade": "Osasco",
        public string uf { get; set; } // "uf": "SP",
        public string unidade { get; set; } /// "unidade": "",
        public string ibge { get; set; } /// "ibge": "3534401",
        public string gia { get; set; } /// "gia": "4923"

        public List<Cep> Clientes { get; set; }
    }
}