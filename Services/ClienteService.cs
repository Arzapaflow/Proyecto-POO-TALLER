using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ??
                throw new ArgumentNullException(nameof(clienteRepository));
        }

        public bool Registrar(Cliente cliente)
        {
            Validar(cliente);

            return _clienteRepository.Insertar(cliente);
        }

        public bool Actualizar(Cliente cliente)
        {
            Validar(cliente);

            return _clienteRepository.Actualizar(cliente);
        }

        public bool Eliminar(int idCliente)
        {
            return _clienteRepository.Eliminar(idCliente);
        }

        public Cliente ObtenerPorId(int idCliente)
        {
            return _clienteRepository.ObtenerPorId(idCliente);
        }

        public List<Cliente> ObtenerTodos()
        {
            return _clienteRepository.ObtenerTodos();
        }

        private void Validar(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");


            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Correo))
                throw new ArgumentException("El correo es obligatorio.");
        }
    }
}
