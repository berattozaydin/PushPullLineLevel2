using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class EvtAlmManager
    {
        readonly Manager mgr;
        public EvtAlmManager(Manager mgr)
        {
            this.mgr = mgr;
        }
        public ReturnResult<List<EvtAlmDto>> GetAllEvtAlm(EvtAlarmParams baseParameter)
        {
            var sql = "SELECT * FROM event_alarm";
            /*if (baseParameter.FilterValue!="")
            {
                sql += " WHERE 1=1 AND " + baseParameter.Property +" LIKE " + $"'%{baseParameter.FilterValue}%'";
            }*/
            if (!string.IsNullOrEmpty(baseParameter.SortField))
                sql +=" ORDER BY "+baseParameter.SortField;

            var res = mgr.Db.Fetch<EvtAlmDto>(sql);
            return new ReturnResult<List<EvtAlmDto>>
            {
                IsSuccess = 1,
                Msg = "Evt_ALM listesi getirildi",
                result = res
            };
        }
    }
}
