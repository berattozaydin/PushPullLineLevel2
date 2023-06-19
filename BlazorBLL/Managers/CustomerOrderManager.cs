using BlazorDAL;
using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class CustomerOrderManager
    {
        Manager mgr;
        public CustomerOrderManager(Manager mgr)
        {
            this.mgr = mgr;
        }
        public ReturnResult UpdateCustomerOrder(CustomerOrder customerOrderDto)
        {
            mgr.Db.Update(customerOrderDto);
            var args = new event_alarm
            {
                machine_name = Environment.MachineName,
                user_name = mgr.Identity.Name,
                log_method = "UpdateCustomerOrder",
                log_description = customerOrderDto.CustomerOrderId + " Güncellendi.",
                dati = DateTime.Now
            };
            var res = (int)mgr.Db.Update(args);
            if (res > 0)
            {
                return new ReturnResult
                {
                    IsSuccess = 1,
                    Msg = customerOrderDto.CustomerOrderId + " Başarıyla Güncellendi."
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess = 0,
                    Msg = customerOrderDto.CustomerOrderId + " Güncellenemedi."
                };
            }
        }
        public ReturnResult AddCustomerOrder(CustomerOrder customerOrderDto)
        {
            var res = (int)mgr.Db.Insert(customerOrderDto);
            if (res > 0)
            {
                return new ReturnResult
                {
                    IsSuccess = 1,
                    Msg = customerOrderDto.CustomerOrderId + " Eklendi."
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess=0,
                    Msg=customerOrderDto.CustomerOrderId + " Eklenemedi."
                };
            }

        }
        public ReturnResult<List<CustomerOrderDto>> GetCustomerOrderList()
        {
            var res = PetaPoco.Sql.Builder
                .Append("SELECT \"CustomerOrderId\"," +
                "cs.\"Name\" as \"CustomerOrderStatusName\", cus.\"CompanyName\" as \"CustomerOrderCustomerName\"," +
                "\"OrderNumber\",co.\"Name\",co.\"Remark\" From \"CustomerOrder\" AS co " +
                "LEFT JOIN \"CustomerOrderStatus\" as cs on cs.\"CustomerOrderStatusId\" = co.\"CustomerOrderStatusId\"" +
                "LEFT JOIN \"Customer\" as cus on cus.\"CustomerId\" = co.\"CustomerId\" ");
            var list = mgr.Db.Fetch<CustomerOrderDto>(res);
            return new ReturnResult<List<CustomerOrderDto>>
            {
                IsSuccess = 1,
                Msg = "Bobin listesi getirildi.",
                result = list
            };
        }
        public ReturnResult<CustomerOrder> GetCustomerOrder(string CustomerOrderId)
        {
            var res = mgr.Db.FirstOrDefault<CustomerOrder>("SELECT * FROM \"CustomerOrder\" Where \"CustomerOrderId\" = @0", CustomerOrderId);

            return new ReturnResult<CustomerOrder>
            {
                IsSuccess = 1,
                Msg = "Bobin bilgisi getirildi.",
                result = res
            };
        }
        public ReturnResult<List<CustomerOrderStatus>> GetCustomerOrderStatusList()
        {
            string sql = "Select * From \"CustomerOrderStatus\"";
            var res = mgr.Db.Fetch<CustomerOrderStatus>(sql);
            return new ReturnResult<List<CustomerOrderStatus>>
            {
                IsSuccess=1,
                Msg = "Bobin durum listesi getirildi.",
                result = res
            };
        }
        public ReturnResult DeleteCustomerOrder(CustomerOrderDto customerOrderId)
        {
            var deleteCustomerOrder = (int)mgr.Db.Delete<CustomerOrder>("WHERE \"CustomerOrderId\"=@0", customerOrderId.CustomerOrderId);

            if (deleteCustomerOrder > 0)
            {
                return new ReturnResult
                {
                    IsSuccess = 1,
                    Msg = (customerOrderId.CustomerOrderId + " Silindi.")
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess = 0,
                    Msg = (customerOrderId.CustomerOrderId + " Silinemedi")
                };
            }

        }
        public ReturnResult ChangePdiStatus(CustomerOrder customerOrderDto)
        {
            var checkPdi = mgr.Db.FirstOrDefault<CustomerOrderDto>("WHERE \"CustomerOrderId\"=@0", customerOrderDto.CustomerOrderId);
            if (checkPdi == null)
            {
                return new ReturnResult
                {
                    IsSuccess = 0,
                    Msg = (customerOrderDto.CustomerOrderId + " numaralı bobin bulunamadı.")
                };
            }
            var changePdiStatus = mgr.Db.Update(customerOrderDto);

            if (changePdiStatus > 0)
            {

                return new ReturnResult
                {
                    IsSuccess = 1,
                    Msg = (customerOrderDto.CustomerOrderId + " numaralı bobinin durumu güncellendi.")
                };

            }
            else
            {

                return new ReturnResult
                {
                    IsSuccess = 0,
                    Msg = (customerOrderDto.CustomerOrderId + " numaralı bobinin durumu güncellenemedi.")
                };

            }
        }

    }
}
