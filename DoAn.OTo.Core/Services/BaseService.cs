using DoAn.OTo.Core.BuidAttribute;
using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Exceptions;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Services
{
    public class BaseService<OToEmpty> :IBaseService<OToEmpty>
    {
        IBaseRepository<OToEmpty> _baseRepository;
        public BaseService(IBaseRepository<OToEmpty> baseRepository) 
        {
            _baseRepository = baseRepository;
        }


        public int DeleteService(Guid entityID)
        {
            var res = _baseRepository.Delete(entityID);
            return res;
        }

        public int InsertService(OToEmpty entity)
        {
            
            ValidateData(entity);
            var res = _baseRepository.Inssert(entity);
            return res;
        }

        public int UpdateService(OToEmpty entity , Guid entityID)
        {
            ValidateCheck(entityID);
            ValidateData(entity);
            var res = _baseRepository.Update(entity , entityID);
            return res;
        }

        

        private bool ValidateData(OToEmpty entity)
        {
            var props = entity.GetType().GetProperties();
            // Kiểm tra các prop được đánh dấu k đc phép để trống 
            var propNotEmpties = entity.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(NotEmpty)));
            
            foreach (var prop in propNotEmpties)
            {
               var propValue = prop.GetValue(entity);
                var propName = prop.Name;
                var nameDisplay = string.Empty;
                var propertyNames = prop.GetCustomAttributes(typeof(ProppertyName),true);
                if(propertyNames.Length > 0)
                {
                    nameDisplay = (propertyNames[0] as ProppertyName).Name;
                }
                if(propValue == null || string.IsNullOrEmpty(propValue.ToString()))
                {
                    nameDisplay = (nameDisplay == string.Empty ? propName : nameDisplay);
                    throw new ValidateException($"Thông tin {nameDisplay} không được phép để trống ! ");
                }
            }
            return true;
        }
        protected virtual void ValidateCheck(Guid id)
        {
            
        }

       
    }
}
