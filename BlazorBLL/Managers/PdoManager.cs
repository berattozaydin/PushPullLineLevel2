using BlazorDAL;
using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class PdoManager
    {
        Manager mgr;
        public PdoManager(Manager mgr)
        {
            this.mgr=mgr;
        }
        public ReturnResult<List<PDO>> GetAllPdoList()
        {
            var res = mgr.Db.Fetch<PDO>();
            if (res == null)
                return new ReturnResult<List<PDO>>
                {
                    IsSuccess=0,
                    Msg="Ürün bobin listesi yok"
                };
            return new ReturnResult<List<PDO>>
            {
                IsSuccess=1,
                Msg="Ürün bobin listesi getirildi",
                result=res
            };
        }
        public ReturnResult<PdoDto> GetPdo(string exCoilId)
        {
            var res = mgr.Db.FirstOrDefault<PdoDto>("SELECT * FROM dbo.pdo WHERE ex_coil_id = @0", exCoilId);
            if (res == null)
                return new ReturnResult<PdoDto>
                {
                    IsSuccess=0,
                    Msg="Ürün bobin yok."
                };
            return new ReturnResult<PdoDto>
            {
                IsSuccess=1,
                Msg=exCoilId+" Ürün Bobin Getirildi",
                result=res
            };

        }
        public ReturnResult AddPdo(PDO pdo)
        {
            var res = (int)mgr.Db.Insert(pdo);
            if (res>0)
            {
                return new ReturnResult
                {
                    IsSuccess=1,
                    Msg=pdo.EX_COIL_ID +" bobini eklendi."
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess=0,
                    Msg=pdo.EX_COIL_ID +" bobini eklenemedi."
                };
            }

        }
        public ReturnResult UpdatePdo(PDO pdo)
        {
            var res = (int)mgr.Db.Update(pdo);
            if (res>0)
            {
                return new ReturnResult
                {
                    IsSuccess=1,
                    Msg=pdo.EX_COIL_ID +" bobini güncellendi."
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess=0,
                    Msg=pdo.EX_COIL_ID +" bobini güncellenemedi."
                };
            }
        }
        public ReturnResult DeletePdo(PDO pdo)
        {
            var res = (int)mgr.Db.Delete(pdo);
            if (res>0)
            {
                return new ReturnResult
                {
                    IsSuccess=1,
                    Msg=pdo.EX_COIL_ID +" bobini silindi."
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess=0,
                    Msg=pdo.EX_COIL_ID +" bobini silinemedi."
                };
            }

        }
    }
}
