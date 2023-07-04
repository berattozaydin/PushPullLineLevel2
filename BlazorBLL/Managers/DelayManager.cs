using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class DelayManager
    {
        Manager mgr;
        public DelayManager(Manager mgr)
        {

            this.mgr=mgr;

        }
        public ReturnResult<List<DelayDto>> GetDelayList()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM delay");
            var delayList = mgr.Db.Fetch<DelayDto>(sql);
            return new ReturnResult<List<DelayDto>> 
            {
                IsSuccess=1,
                Msg="Duruş Listesi Getirildi",
                result=delayList
            };
        }
        public ReturnResult<DelayDto> GetDelay(int delayId)
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM delay where delay_id = @0",delayId);
            var res = mgr.Db.FirstOrDefault<DelayDto>(sql);
            return new ReturnResult<DelayDto>
            {
                IsSuccess=1,
                Msg="Duruş Getirildi",
                result=res
            };
        }
    }
}
