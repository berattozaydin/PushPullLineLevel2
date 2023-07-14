using BlazorDAL;
using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class LevelerManager
    {
        Manager mgr;
        public LevelerManager(Manager mgr)
        {
            this.mgr = mgr;
        }
        public ReturnResult<List<LEVELER_SETTING>> GetAllLevelerSettingList()
        {
            var res = mgr.Db.Fetch<LEVELER_SETTING>();
            if (res == null)
                return new ReturnResult<List<LEVELER_SETTING>>
                {
                    IsSuccess=0,
                    Msg="Leveler Ayar listesi bulunamadı."
                };
            return new ReturnResult<List<LEVELER_SETTING>>
            {
                IsSuccess=1,
                Msg="Leveler Ayar listesi getirildi.",
                result=res
            };
        }
        public ReturnResult<LEVELER_SETTING> GetLevelerSetting(int levelerSettingId)
        {
            var res = mgr.Db.FirstOrDefault<LEVELER_SETTING>("WHERE id = @0", levelerSettingId);
            if (res ==  null)
                return new ReturnResult<LEVELER_SETTING>
                {
                    IsSuccess=0,
                    Msg= levelerSettingId +" numaralı leveler ayarı bulunamadı."
                };
            return new ReturnResult<LEVELER_SETTING>
            {
                IsSuccess=1,
                Msg=levelerSettingId+" numaralı leveler ayarı getirildi.",
                result=res
            };
        }
        public ReturnResult AddLevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var res = (int)mgr.Db.Insert(levelerSetting);
            if (res>0)
                return new ReturnResult
                {
                    IsSuccess=1,
                    Msg="Leveler Ayarı eklendi."
                };
            else
                return new ReturnResult 
                { 
                    IsSuccess=0, 
                    Msg="Leveler ayarı eklenemedi." 
                };
        }
        public ReturnResult UpdateLevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var res = (int)mgr.Db.Update(levelerSetting);
            if (res>0)
                return new ReturnResult
                {
                    IsSuccess=1,
                    Msg=levelerSetting.ID +" numaraları leveler ayarı güncellendi."
                };
            else
                return new ReturnResult
                {
                    IsSuccess=0,
                    Msg = levelerSetting.ID + " numaralı leveler ayarı güncellenemedi."
                };
        }
        public ReturnResult DeleteLevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var res = mgr.Db.FirstOrDefault<LEVELER_SETTING>("WHERE id = @0", levelerSetting.ID);
            if (res==null)
                return new ReturnResult
                {
                    IsSuccess=0,
                    Msg=levelerSetting.ID +" numaralı leveler ayarı bulunamadı."
                };
            mgr.Db.Delete(res);
            return new ReturnResult
            {
                IsSuccess=1,
                Msg=levelerSetting.ID + " numaralı leveler ayarı silindi."
            };
        }

    }
}
