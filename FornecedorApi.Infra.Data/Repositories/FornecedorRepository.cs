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
    public class FornecedorRepository: IFornecedorRepository
    {
        public void Create(Fornecedor entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Fornecedor.Add(entity);
                dataContext.SaveChanges();

            }
        }

        public void Update(Fornecedor entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();

            }
        }

        public void Delete(Fornecedor entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Fornecedor.Remove(entity);
                dataContext.SaveChanges();

            }
        }

        public List<Fornecedor> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Fornecedor
                    .OrderBy(c => c.Nome)
                    .ToList();

            }
        }

        public Fornecedor GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Fornecedor.FirstOrDefault(f => f.IdFornecedor == id);

            }
        }
    }
}
