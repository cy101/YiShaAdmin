﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETAL.Entity.SystemManage;
using ETAL.Model;
using ETAL.Model.Param.SystemManage;
using ETAL.Service.SystemManage;
using ETAL.Util.Extension;
using ETAL.Util.Model;

namespace ETAL.Business.SystemManage
{
    public class LogLoginBLL
    {
        private LogLoginService logLoginService = new LogLoginService();

        #region 获取数据
        public async Task<TData<List<LogLoginEntity>>> GetList(LogLoginListParam param)
        {
            TData<List<LogLoginEntity>> obj = new TData<List<LogLoginEntity>>();
            obj.Result = await logLoginService.GetList(param);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<LogLoginEntity>>> GetPageList(LogLoginListParam param, Pagination pagination)
        {
            TData<List<LogLoginEntity>> obj = new TData<List<LogLoginEntity>>();
            obj.Result = await logLoginService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<LogLoginEntity>> GetEntity(long id)
        {
            TData<LogLoginEntity> obj = new TData<LogLoginEntity>();
            obj.Result = await logLoginService.GetEntity(id);
            obj.Tag = 1;
            return obj;
        }

        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(LogLoginEntity entity)
        {
            TData<string> obj = new TData<string>();
            await logLoginService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await logLoginService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> RemoveAllForm()
        {
            TData obj = new TData();
            await logLoginService.RemoveAllForm();
            obj.Tag = 1;
            return obj;
        }
        #endregion
    }
}