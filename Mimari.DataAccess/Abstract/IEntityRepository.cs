using Mimari.Ado.Abstract;
using Mimari.Ado.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimari.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        DataSet GetAllDataSet();
        List<T> GetAllList();
        T GetId(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
