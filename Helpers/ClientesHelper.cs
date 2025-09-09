using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaTecnicaKaprielian.Dtos;
using PruebaTecnicaKaprielian.Extensions;
using PruebaTecnicaKaprielian.Interfaces;
using PruebaTecnicaKaprielian.Models;
using PruebaTecnicaKaprielian.Repositories;

namespace PruebaTecnicaKaprielian.Helpers
{
    public class ClientesHelper
    {
        public static async Task<ActionResult> GetAll(IUnitOfWork unitOfWork)
        {
            ClientesRepository clientesRepository = new(unitOfWork);

            var result = await clientesRepository.FindAllAsync();
 
            return new ContentResult { StatusCode= result == null ? 204 : 200, ContentType = "application/json", Content = JsonConvert.SerializeObject(result) };
        }

        public static async Task<ActionResult> Get(IUnitOfWork unitOfWork,int id)
        {
            ClientesRepository clientesRepository = new(unitOfWork);

            var result = await clientesRepository.FindByAsync(x=>x.Id == id);

            return new ContentResult { StatusCode = result == null ? 204 : 200, ContentType = "application/json", Content = JsonConvert.SerializeObject(result) };
        }

        public static async Task<ActionResult> GetByName(IUnitOfWork unitOfWork, string name)
        {
            ClientesRepository clientesRepository = new(unitOfWork);

            var result = await clientesRepository.FindByAsync(x => x.Nombres.Contains(name));

            return new ContentResult { StatusCode = result == null ? 204 : 200, ContentType = "application/json", Content = JsonConvert.SerializeObject(result) };
        }

        public static async Task<ActionResult> Create(IUnitOfWork unitOfWork,ClientesDto clientes)
        {
            ClientesRepository clientesRepository = new(unitOfWork);

            Clientes clientesToSave = new() 
            { 
                Nombres = clientes.Nombres,
                Apellidos = clientes.Apellidos,
                Cuit = clientes.Cuit,
                Domicilio = clientes.Domicilio,
                Email = clientes.Email,
                FechaNacimiento = clientes.FechaNacimiento,
                TelefonoCelular = clientes.TelefonoCelular
            };

            await clientesRepository.AddAsync(clientesToSave);

            return new ContentResult { StatusCode = 200, ContentType = "application/json", Content = "Cliente creado con exito" };
        }

        public static async Task<ActionResult> Update(IUnitOfWork unitOfWork, ClienteUpdateDto clientes)
        {
            ClientesRepository clientesRepository = new(unitOfWork);

            Clientes clienteToUpdate = await clientesRepository.FindByAsync(x=>x.Id == clientes.Id);

            if (clienteToUpdate == null)
                return new ContentResult { StatusCode = 200, ContentType = "application/json", Content = "No se encuentra el cliente que busca" };

            clienteToUpdate.Nombres = clientes.Nombres;
            clienteToUpdate.Apellidos = clientes.Apellidos;
            clienteToUpdate.FechaNacimiento = clientes.FechaNacimiento;
            clienteToUpdate.Cuit = clientes.Cuit;
            clienteToUpdate.TelefonoCelular = clientes.TelefonoCelular;
            clienteToUpdate.Email = clientes.Email;
            clienteToUpdate.Domicilio = clientes.Domicilio;

            await clientesRepository.UpdateAsync(clienteToUpdate);

            return new ContentResult { StatusCode = 200, ContentType = "application/json", Content = "Cliente actualizado con exito" };
        }
    }
}
