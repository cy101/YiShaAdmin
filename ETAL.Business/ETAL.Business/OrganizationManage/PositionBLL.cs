﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ETAL.Entity.OrganizationManage;
using ETAL.Service.OrganizationManage;
using ETAL.Util.Model;
using ETAL.Util.Extension;
using ETAL.Model.Param.OrganizationManage;

namespace ETAL.Business.OrganizationManage
{
    public class PositionBLL
    {
        private PositionService positionService = new PositionService();

        #region 获取数据
        public async Task<TData<List<PositionEntity>>> GetList(PositionListParam param)
        {
            TData<List<PositionEntity>> obj = new TData<List<PositionEntity>>();
            obj.Result = await positionService.GetList(param);
            obj.TotalCount = obj.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PositionEntity>>> GetPageList(PositionListParam param, Pagination pagination)
        {
            TData<List<PositionEntity>> obj = new TData<List<PositionEntity>>();
            obj.Result = await positionService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PositionEntity>> GetEntity(long id)
        {
            TData<PositionEntity> obj = new TData<PositionEntity>();
            obj.Result = await positionService.GetEntity(id);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<int>> GetMaxSort()
        {
            TData<int> obj = new TData<int>();
            obj.Result = await positionService.GetMaxSort();
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PositionEntity entity)
        {
            TData<string> obj = new TData<string>();
            if (positionService.ExistPositionName(entity))
            {
                obj.Message = "职位名称已经存在！";
                return obj;
            }
            await positionService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await positionService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion
    }
}
