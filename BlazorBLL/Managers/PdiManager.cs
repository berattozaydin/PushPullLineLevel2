using BlazorDAL;
using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class PdiManager
    {
        Manager mgr;
        public PdiManager(Manager mgr)
        {
            this.mgr = mgr;
        }
        public ReturnResult UpdatePdi(PDI pdi)
        {
            //mgr.Db.Update(customerOrderDto);
            /*var args = new EVTALM
            {
                 = Environment.MachineName,
                user_name = mgr.Identity.Name,
                log_method = "UpdateCustomerOrder",
                log_description = customerOrderDto.EN_COIL_ID + " Güncellendi.",
                dati = DateTime.Now
            };*/
            var res = (int)mgr.Db.Update(pdi);
            if (res > 0)
            {
                return new ReturnResult
                {
                    IsSuccess = 1,
                    Msg = pdi.EN_COIL_ID + " Başarıyla Güncellendi."
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess = 0,
                    Msg = pdi.EN_COIL_ID + " Güncellenemedi."
                };
            }
        }
        public ReturnResult AddPdi(PDI pdi)
        {
            var res = (int)mgr.Db.Insert(pdi);
            if (res > 0)
            {
                return new ReturnResult
                {
                    IsSuccess = 1,
                    Msg = pdi.EN_COIL_ID + " Eklendi."
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess=0,
                    Msg=pdi.EN_COIL_ID + " Eklenemedi."
                };
            }

        }
        public ReturnResult<List<PDI>> GetPdiList()
        {

            var list = mgr.Db.Fetch<PDI>();
            return new ReturnResult<List<PDI>>
            {
                IsSuccess = 1,
                Msg = "Bobin listesi getirildi.",
                result = list
            };
        }
        public ReturnResult<PdiDto> GetPdi(string enCoilId)
        {
            var res = mgr.Db.FirstOrDefault<PdiDto>("SELECT * FROM dbo.pdi Where en_coil_id = @0", enCoilId);

            return new ReturnResult<PdiDto>
            {
                IsSuccess = 1,
                Msg = "Bobin bilgisi getirildi.",
                result = res
            };
        }
        /*public ReturnResult<List<CustomerOrderStatus>> GetCustomerOrderStatusList()
        {
            string sql = "Select * From \"CustomerOrderStatus\"";
            var res = mgr.Db.Fetch<CustomerOrderStatus>(sql);
            return new ReturnResult<List<CustomerOrderStatus>>
            {
                IsSuccess=1,
                Msg = "Bobin durum listesi getirildi.",
                result = res
            };
        }*/
        public ReturnResult DeletePdi(PdiDto pdiDto)
        {
            var deleteCustomerOrder = (int)mgr.Db.Delete<PDI>("WHERE en_coil_id=@0", pdiDto.EN_COIL_ID);

            if (deleteCustomerOrder > 0)
            {
                return new ReturnResult
                {
                    IsSuccess = 1,
                    Msg = (pdiDto.EN_COIL_ID + " Silindi.")
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess = 0,
                    Msg = (pdiDto.EN_COIL_ID + " Silinemedi")
                };
            }

        }
        /*public ReturnResult ChangePdiStatus(PdiDto customerOrderDto)
        {
            var checkPdi = mgr.Db.FirstOrDefault<PdiDto>("WHERE \"CustomerOrderId\"=@0", customerOrderDto.CustomerOrderId);
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
        }*/

    }
}
