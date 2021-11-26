using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EHS.DataAccess.DAService.Core
{
    public interface IModelDAService<TModel> where TModel : class
    {

        IEnumerable<TModel> GetAll();


        TModel Insert(TModel model);
        void Insert(params TModel[] models);
        void Insert(IEnumerable<TModel> models);


        void Update(TModel model);
        void Update(params TModel[] models);
        void Update(IEnumerable<TModel> models);


        void Delete(TModel model);
        void Delete(params TModel[] models);
        void Delete(IEnumerable<TModel> models);
    }
}
