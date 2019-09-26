using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCatalogo.BO
{
    public class ProductoBO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Color { get; set; }

        public string Cantidad { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }
    }
}
