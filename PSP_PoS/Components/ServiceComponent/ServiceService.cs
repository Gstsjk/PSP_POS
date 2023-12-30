using Microsoft.EntityFrameworkCore;
using PSP_PoS.Data;

namespace PSP_PoS.Components.ServiceComponent
{
    public class ServiceService : IServiceService
    {
        private readonly DataContext _context;

        public ServiceService(DataContext context)
        {
            _context = context;
        }

        public List<ServiceReadDto> GetAllServices()
        {
            List<Service> services = _context.Services.
                Include(service => service.Category).
                Include(service => service.Discount).
                ToList();

            List<ServiceReadDto> serviceReadDtos = new List<ServiceReadDto>();

            foreach(var service in services)
            {
                ServiceReadDto serviceReadDto = new ServiceReadDto(service);
                serviceReadDtos.Add(serviceReadDto);
            }
            return serviceReadDtos;
        }
        public ServiceReadDto GetServiceById(Guid serviceId)
        {
            var service =  _context.Services.
                Include(t => t.Category).
                Include(t => t.Discount).
                FirstOrDefault(t => t.Id == serviceId)!;
            ServiceReadDto serviceReadDto = new ServiceReadDto(service);
            return serviceReadDto;
        }
        public Service AddService(ServiceCreateDto serviceCreateDto)
        {
            Service service = new Service(serviceCreateDto);
            service.Category = _context.Categories.Find(service.CategoryId)!;
            _context.Services.Add(service);
            _context.SaveChanges();
            return service;
        }

        public bool AddDiscountToService(Guid serviceId, Guid discountId)
        {
            Service? service = GetServiceByIdModel(serviceId);
            service.DiscountId = discountId;
            service.Discount = _context.Discounts.Find(discountId);
            _context.Services.Update(service);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateService(ServiceCreateDto serviceCreateDto, Guid id)
        {
            Service? service = _context.Services.FirstOrDefault(t => t.Id == id);
            if(service == null)
            {
                return false;
            }
            service.UpdateService(serviceCreateDto);
            _context.Services.Update(service);
            _context.SaveChanges();
            return true;
        }
        public void DeleteService(Guid serviceId)
        {
            Service service = _context.Services.FirstOrDefault(t => t.Id == serviceId)!;
            if(service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
        public bool RemoveDiscountFromService(Guid serviceId)
        {
            Service? service = GetServiceByIdModel(serviceId);
            service.DiscountId = null;
            service.Discount = null;
            _context.Services.Update(service);
            _context.SaveChanges();
            return true;
        }
        public bool IfCategoryIdValid(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IfDiscountIdValid(Guid id)
        {
            var discount = _context.Discounts.Find(id);
            if (discount != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IfServiceIdValid(Guid id)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Service GetServiceByIdModel(Guid serviceId)
        {
            return _context.Services.
                Include(t => t.Category).
                Include(t => t.Discount).
                FirstOrDefault(t => t.Id == serviceId)!;
        }
    }
}
