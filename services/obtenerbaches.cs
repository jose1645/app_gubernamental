using sombrero.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sombrero.services
{
    public interface obtenerbaches
    {
        public Task<List<bache>> obtener();
    }
}
