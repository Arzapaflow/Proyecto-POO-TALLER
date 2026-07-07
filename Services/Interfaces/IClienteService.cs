using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IClienteService
    {
        bool Registrar(Cliente cliente);

        bool Actualizar(Cliente cliente);

        bool Eliminar(int idCliente);

        Cliente ObtenerPorId(int idCliente);

        List<Cliente> ObtenerTodos();
    }
}
