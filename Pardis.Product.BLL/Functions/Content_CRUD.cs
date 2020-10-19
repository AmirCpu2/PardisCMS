using Pardis.Product.BLL.ViewModel;
using Pardis.Product.DAL.Repasitory;
using Pardis.PublicFunction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;
using VM = Pardis.Product.BLL.ViewModel;


namespace Pardis.Product.BLL.Functions
{
    public partial class ContentBLL<TVModel, TMModel> : GenericBLL<TVModel, TMModel> where TMModel : class, MM.IContent where TVModel : VM.Content, new()
    {
        public static ContentBLL<TVModel, TMModel> InstanceContent { get; } = new ContentBLL<TVModel, TMModel>();
        
        public virtual TVModel AddOrUpdate(TVModel vModel, bool runCustomFunction = true)
        {
            try
            {
                if (vModel == null) return null;
                var editFlag = false;
                var contentType = TvModelContentType;

                if (runCustomFunction)
                {
                    var customFunctionResult = RunFunctionFromModelBLL<TVModel>("AddOrUpdateCustom", vModel);
                    if (customFunctionResult != null)
                        return customFunctionResult;
                }

                var model = Mapper.Map<TVModel, TMModel>(vModel);

                var content = new MM.Content() { Id = model.GetIdFromModel() };
                if (content.Id == 0)
                {
                    content = new MM.Content()
                    {
                        Id = content.Id,
                        CreatorId = CurrentUser.Id,
                        RegisterDate = DateTime.Now,
                        ContentType = (short)contentType,
                        IsArchive = content.IsArchive,
                        IsDelete = content.IsDelete
                    };
                }
                else
                {
                    var contentTemp = GenericRepository<MM.Content>.Instance.GetAll()
                        .FirstOrDefault(q => q.Id == content.Id);

                    if (content.Id > 0 && contentTemp != null)
                    {
                        content = contentTemp;
                        editFlag = true;
                    }
                    else
                        content.Id = 0;
                }

                content.IsArchive = vModel?.IsArchive ?? false;
                content.IsDelete = vModel?.IsDelete ?? false;

                GenericRepository<MM.Content>.Instance.AddOrUpdate(content);
                GenericRepository<TMModel>.Instance.AddOrUpdate(model);
                
                if (!editFlag)
                {
                    //this lines join a content to Tables or file or etc and should just run in CREATE MODE
                    content.GetType().GetProperty(typeof(TMModel).Name)?.SetValue(content, model);
                }
                
                GenericRepository<TMModel>.Instance.Save();

                var final = Mapper.Map<TMModel, TVModel>(model);
                
                return final;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                    throw;
            }
        }
        
        public bool Remove(int id, bool remove = true)
        {
            if (CheckAccessDenied(id))
                return false;
            var removedObj = GenericRepository<MM.Content>.Instance.GetAll().FirstOrDefault(q => q.Id == id);
            if (removedObj == null)
                return false;
            removedObj.IsDelete = remove;

            GenericRepository<MM.Content>.Instance.AddOrUpdate(removedObj);
            GenericRepository<MM.Content>.Instance.Save();

            return true;
        }
        
        public bool Remove(TVModel entity)
        {
            return this.Remove(entity.Id, entity?.IsDelete ?? true);
        }
        
        public int RemoveRange(List<int> idList, bool remove = true)
        {
            var removeCount = 0;
            foreach (var item in idList)
            {
                if (Remove(item, remove))
                    removeCount++;
            }
            return removeCount;
        }
        
        public int RemoveRange(string joinIdListWithComma, bool remove = true)
        {
            var idList = joinIdListWithComma.Split(',').Select(int.Parse).ToList();
            return RemoveRange(idList, remove);
        }
        
        public bool Archive(int id, bool archive = true)
        {
            if (CheckAccessDenied(id))
                return false;
            var removedObj = GenericRepository<MM.Content>.Instance.GetAll().FirstOrDefault(q => q.Id == id);

            if (removedObj == null)
                return false;

            removedObj.IsArchive = archive;

            GenericRepository<MM.Content>.Instance.AddOrUpdate(removedObj);
            GenericRepository<MM.Content>.Instance.Save();

            return true;
        }
        
        public bool Archive(TVModel entity)
        {
            return this.Archive(entity.Id, entity?.IsArchive ?? true);
        }

        public int ArchiveRange(List<int> idList, bool archive = true)
        {
            var archiveCount = 0;
            foreach (var item in idList)
            {
                if (Remove(item, archive))
                    archiveCount++;
            }
            return archiveCount;
        }

        public int ArchiveRange(string joinIdListWithComma, bool archive = true)
        {
            var idList = joinIdListWithComma.Split(',').Select(int.Parse).ToList();
            return ArchiveRange(idList, archive);
        }

        private static Model RunFunctionFromModelBLL<Model>(string functionName, Model q) where Model : class
        {
            var className = $"Pardis.Product.BLL.Functions.{typeof(Model).Name}BLL";
            Type findClass = Type.GetType(className);
            if (findClass == null)
                return null;
            var instance = Activator.CreateInstance(findClass);

            //MethodInfo methodInfo = findClass.GetMethod(functionName, BindingFlags.Instance | BindingFlags.Public);
            MethodInfo methodInfo = findClass.GetMethods().FirstOrDefault(qq => qq.Name == functionName && !qq.IsGenericMethod);

            if (methodInfo == null)
                return null;
            if (methodInfo.GetBaseDefinition() != methodInfo)//check function is a override method
                return null;
            return methodInfo.Invoke(instance, new object[] { q }) as Model;
        }

    }
    
}
