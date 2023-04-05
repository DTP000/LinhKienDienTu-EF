using Abp.Application.Services;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using LinhKienDienTu.Orders.Dto;
using LinhKienDienTu.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.UI;
using System;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace LinhKienDienTu.Orders
{
    [AbpAuthorize]
    public class OrderAppService : AsyncCrudAppService<Order, OrderDto, int, PagedOrderResultRequestDto, CreateOrderDto, EditOrderDto>, IOrderAppService
    {
        IRepository<OrderDetail> _repositoryOrderDetail;
        public OrderAppService(IRepository<Order> Repository, IRepository<OrderDetail> repositoryOrderDetail) : base(Repository)
        {
            _repositoryOrderDetail = repositoryOrderDetail;
        }

        public override Task<OrderDto> CreateAsync(CreateOrderDto input)
        {
            try
            {
                return base.CreateAsync(input);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Thêm dữ liệu lỗi");
            }
        }

        public override async Task<OrderDto> UpdateAsync(EditOrderDto input)
        {
            try
            {
                if (input.OrderDetails != null && input.OrderDetails.Count > 0 && input.OrderDetails.Any(x => x.Id == 0))
                {
                    _repositoryOrderDetail.Delete(x => x.OrderId == input.Id);
                }
                var entity = await Repository.GetAllIncluding(x => x.OrderDetails)
                    .Where(x => x.Id == input.Id)
                    .FirstOrDefaultAsync();

                if (entity == null)
                    throw new UserFriendlyException("Id không tìm thấy");

                ObjectMapper.Map(input, entity);
                await Repository.UpdateAsync(entity);
                return MapToEntityDto(entity);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Cập nhật dữ liệu lỗi");
            }
        }

        public override Task<OrderDto> GetAsync(EntityDto<int> input)
        {
            try
            {
                return base.GetAsync(input);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Lấy dữ liệu lỗi");
            }
        }

        protected override IQueryable<Order> CreateFilteredQuery(PagedOrderResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Name.Contains(input.Keyword) && x.IsDeleted == Common.IsDeleted.CHUA_XOA);
        }

        public async Task<OrderDto> GetExtensionsAsync(int id)
        {
            try
            {
                var entity = await Repository.GetAll()
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = ObjectMapper.Map<OrderDto>(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Lấy dữ liệu lỗi");
            }
        }
    }
}

