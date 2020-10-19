using Pardis.Product.BLL.ViewModel;
using Pardis.PublicFunction.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MM = Pardis.Product.DAL.Models;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.Product.BLL.Functions
{
    public partial class ContentBLL<TVModel, TMModel> : GenericBLL<TVModel, TMModel> where TMModel : class, MM.IContent where TVModel : VM.Content, new()
    {

        public TVModel GetOneById(int? id)
        {
            if (!id.HasValue)
                return null;
            var content = GetAll_asQuery(q => q.Id == id).Take(1).FirstOrDefault();
            return Mapper.Map<TMModel, TVModel>(content);
        }

        public bool CheckAccessDenied(int? contentId)
        {
            if (!contentId.HasValue || contentId == 0)
                return false;
            //return false;
            return !GetAll_asQuery(q => q.Id == contentId).Any();
        }

        public JsonResult ShowJqGrid(Jqgrid model)
        {
            return ShowJqGrid<TVModel>(model);
        }

        public JsonResult ShowJqGrid<OutModel>(Jqgrid model, string MapperName = null, Expression<Func<TMModel, object>> customInclude = null) where OutModel : class
        {
            try
            {
                int pageIndex = (model.page ?? 1) - 1;
                int pageSize = model.rows ?? 10;


                IQueryable<TMModel> todoListsResults = (IQueryable<TMModel>)(model.InitialToDoListResults);


                if (customInclude != null)
                    todoListsResults = todoListsResults.Include(customInclude);

                if (todoListsResults == null)
                    return null;
                //
                todoListsResults = todoListsResults.Include(q => q.Content);
                if (model.ShowDelete != ShowDeleted.ShowAll)
                    todoListsResults = todoListsResults.Where(q => q.Content.IsDelete == (model.ShowDelete == ShowDeleted.JustDeleted));
                if (model.ShowArchive != ShowArchive.ShowAll)
                    todoListsResults = todoListsResults.Where(q => q.Content.IsArchive == (model.ShowArchive == ShowArchive.JustArchive));


                

                if (model.ContainIdList.Any())
                {
                    model.ContainIdList.RemoveAll(q => q == 0);
                    model.ContainIdList = model.ContainIdList.Distinct().ToList();
                    todoListsResults = todoListsResults.Where(q => model.ContainIdList.Contains(q.Id));
                }

                //Search Toolbar
                todoListsResults = new JqGridSearch().ApplyFilter(todoListsResults, model._search, model.searchField, model.searchString,
                    model.searchOper, model.filters, model.form, model.CustomSearch);

                int totalRecords = todoListsResults.Count();
                var totalPages = (int)Math.Ceiling(totalRecords / (float)pageSize);

                if (model.page > totalPages)
                {
                    model.page = 1;
                    pageIndex = 0;
                }

                if (!string.IsNullOrWhiteSpace(model.sidx) && !string.IsNullOrWhiteSpace(model.sord))
                    todoListsResults = todoListsResults.OrderBy(model.sidx + " " + model.sord);

                var jsonRows = todoListsResults
                .Skip(pageIndex * pageSize)
                .Take(pageSize).AsEnumerable()
                .Select(q => (MapperName == null) ? Mapper.Map<TMModel, OutModel>(q) : Mapper.Map<TMModel, OutModel>(q, MapperName))
                .ToList();

                var jsonObject = new JsonResult()
                {
                    Data = new
                    {
                        total = totalPages,
                        model.page,
                        records = totalRecords,
                        rows = jsonRows
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = Int32.MaxValue
                };

                return jsonObject;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
