using System;
using System.Collections.Generic;
using System.Text;

namespace employes.models
{
    public class Employes
    {
        public string cedula { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string salario { get; set; }
    }

    public class AllEmployes
    {
        public string cedula { get; set; }
        public string name_completo { get; set; }
        public string salario { get; set; }
    }
}
