using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService()
        {
            _empleadoRepository = new EmpleadoRepository();
        }

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            if (empleadoRepository == null)
                throw new ArgumentNullException(nameof(empleadoRepository));

            _empleadoRepository = empleadoRepository;
        }

        public bool Registrar(Empleado empleado)
        {
            ValidarEmpleado(empleado);

            List<Empleado> empleados =
                _empleadoRepository.ObtenerTodos();

            bool correoRegistrado = empleados.Any(
                e => e.Correo.Equals(
                    empleado.Correo,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (correoRegistrado)
            {
                throw new InvalidOperationException(
                    "Ya existe un empleado registrado con ese correo."
                );
            }

            return _empleadoRepository.Insertar(empleado);
        }

        public bool Actualizar(Empleado empleado)
        {
            ValidarEmpleado(empleado);

            if (empleado.Id <= 0)
            {
                throw new ArgumentException(
                    "El identificador del empleado no es válido."
                );
            }

            Empleado empleadoExistente =
                _empleadoRepository.ObtenerPorId(empleado.Id);

            if (empleadoExistente == null)
                return false;

            List<Empleado> empleados =
                _empleadoRepository.ObtenerTodos();

            bool correoRegistrado = empleados.Any(
                e => e.Id != empleado.Id &&
                     e.Correo.Equals(
                         empleado.Correo,
                         StringComparison.OrdinalIgnoreCase
                     )
            );

            if (correoRegistrado)
            {
                throw new InvalidOperationException(
                    "El correo ya pertenece a otro empleado."
                );
            }

            return _empleadoRepository.Actualizar(empleado);
        }

        public bool Eliminar(int idEmpleado)
        {
            if (idEmpleado <= 0)
            {
                throw new ArgumentException(
                    "El identificador del empleado no es válido."
                );
            }

            Empleado empleado =
                _empleadoRepository.ObtenerPorId(idEmpleado);

            if (empleado == null)
                return false;

            return _empleadoRepository.Eliminar(idEmpleado);
        }

        public Empleado ObtenerPorId(int idEmpleado)
        {
            if (idEmpleado <= 0)
            {
                throw new ArgumentException(
                    "El identificador del empleado no es válido."
                );
            }

            return _empleadoRepository.ObtenerPorId(idEmpleado);
        }

        public List<Empleado> ObtenerTodos()
        {
            return _empleadoRepository.ObtenerTodos();
        }

        private void ValidarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado));

            if (string.IsNullOrWhiteSpace(empleado.Nombre))
            {
                throw new ArgumentException(
                    "El nombre del empleado no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(empleado.Telefono))
            {
                throw new ArgumentException(
                    "El teléfono del empleado no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(empleado.Correo))
            {
                throw new ArgumentException(
                    "El correo del empleado no puede estar vacío."
                );
            }

            empleado.Nombre = empleado.Nombre.Trim();
            empleado.Telefono = empleado.Telefono.Trim();
            empleado.Correo = empleado.Correo.Trim();
        }
    }
}
