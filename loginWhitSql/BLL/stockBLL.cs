using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginWhitSql.BLL
{
    internal class stockBLL
    {
       public int Id { get; set; }
       public string Descripcion{ get; set; }
       public int Cantidad { get; set; }
       public int Precio { get; set; }
       public byte[] FotoStock { get; set; }

    }
}
