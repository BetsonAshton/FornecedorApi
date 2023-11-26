using FornecedorApi.Domain.Entities;
using FornecedorApi.Domain.Interfaces.Repositories;
using FornecedorApi.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Infra.Data.Repositories
{
    public class EnderecoRepository: IEnderecoRepository
    {
        public void Create(Endereco entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Endereco.Add(entity);
                dataContext.SaveChanges();

            }
        }

        public void Update(Endereco entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();

            }
        }

        public void Delete(Endereco entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Endereco.Remove(entity);
                dataContext.SaveChanges();

            }
        }

        public List<Endereco> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Endereco
                    .OrderBy(e => e.Logradouro)
                    .ToList();

            }
        }

        public Endereco GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Endereco.FirstOrDefault(c => c.IdEndereco == id);

            }
        }
    }
}
