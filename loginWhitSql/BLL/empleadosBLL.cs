﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginWhitSql.BLL_logica_
{
    internal class empleadosBLL
    {
        public int ID { get; set; }
        public string NombreEmpleado { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Departamento { get; set; }
        public string Correo { get; set; }
        public byte[] FotoEmpleado { get; set;  }
    

    }
}
