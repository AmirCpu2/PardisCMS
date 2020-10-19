using Pardis.Product.BLL.ViewModel;
using Pardis.Product.DAL.Repasitory;
using Pardis.PublicFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.BLL.Functions
{
    public class GenericBLL<TVModel, TMModel> where TVModel : class, new() where TMModel : class
    {
        public static Account CurrentUser => SSO.CurrentAccount;
        protected static GenericRepository<TMModel> InstanceRepository { get; } = GenericRepository<TMModel>.Instance;

        public static GenericBLL<TVModel, TMModel> InstanceGeneric { get; } = new GenericBLL<TVModel, TMModel>();
        public virtual IQueryable<TMModel> GetAll_asQuery(Expression<Func<TMModel, bool>> expression = null)
        {
            var result = InstanceRepository.GetAll();
            return (expression == null) ? result : result.Where(expression);
        }
        public virtual IQueryable<TMModel> GetList_asQueryById(int[] idList)
        {
            var query = InstanceRepository.GetAll().Where(ContainExpression(idList.ToList()));
            return query;
        }
        private Expression<Func<TMModel, bool>> ContainExpression(List<int> ListToCheck)
        {
            var param = Expression.Parameter(typeof(TMModel), "q");

            var body = Expression.Call(Expression.Constant(ListToCheck),
                "Contains",
                Type.EmptyTypes,
                Expression.PropertyOrField(param, "Id"));

            var lambda = Expression.Lambda<Func<TMModel, bool>>(body, param);
            return lambda;
        }
        public virtual IEnumerable<TVModel> GetList<TKeyModel>(int? takeCount = null,
            Expression<Func<TMModel, bool>> whereExpression = null, Expression<Func<TMModel, TKeyModel>> orderExpression = null)
        {
            var a = InstanceRepository.GetAll();
            if (whereExpression != null)
                a = a.Where(whereExpression);
            if (orderExpression != null)
                a = a.OrderByDescending(orderExpression);
            if (takeCount.HasValue)
                a = a.Take(takeCount.Value);

            var result = a.AsEnumerable().Select(Mapper.Map<TMModel, TVModel>).ToList();
            return result;
        }
        public virtual IEnumerable<TVModel> GetList(int? takeCount = null,
            Expression<Func<TMModel, bool>> whereExpression = null, Expression<Func<TMModel, TVModel>> orderExpression = null)
        {
            return GetList<TVModel>(takeCount, whereExpression, orderExpression);
        }
        public TVModel GetOne(Expression<Func<TMModel, bool>> expression)
        {
            return Mapper.Map<TMModel, TVModel>(this.GetAll_asQuery(expression).FirstOrDefault());
        }
        public virtual TVModel AddOrUpdate(TVModel vModel)
        {
            try
            {
                var model = Mapper.Map<TVModel, TMModel>(vModel);
                InstanceRepository.AddOrUpdate(model);
                InstanceRepository.Save();

                return Mapper.Map<TMModel, TVModel>(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public virtual bool Clear(TVModel model)
        {
            try
            {
                InstanceRepository.Delete(InstanceRepository.Find(model.GetIdFromModel()));
                InstanceRepository.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Type GetTypeEx(string fullTypeName)
        {
            return Type.GetType(fullTypeName) ??
                   AppDomain.CurrentDomain.GetAssemblies()
                       .Select(a => a.GetType(fullTypeName))
                       .FirstOrDefault(t => t != null);
        }

    }
}
