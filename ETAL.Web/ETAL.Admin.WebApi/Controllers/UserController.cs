﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ETAL.Business.OrganizationManage;
using ETAL.Entity.OrganizationManage;
using ETAL.Enum;
using ETAL.Model.Result.SystemManage;
using ETAL.Util;
using ETAL.Util.Model;
using ETAL.Web.Code;

namespace ETAL.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class UserController : ControllerBase
    {
        private UserBLL userBLL = new UserBLL();

        #region 获取数据       
        #endregion

        #region 提交数据
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<TData<OperatorInfo>> Login([FromQuery] string userName, [FromQuery] string password)
        {
            TData<OperatorInfo> obj = new TData<OperatorInfo>();
            TData<UserEntity> userObj = await userBLL.CheckLogin(userName, password, (int)PlatformEnum.WebApi);
            if (userObj.Tag == 1)
            {
                await new UserBLL().UpdateUser(userObj.Result);
                await Operator.Instance.AddCurrent(userObj.Result.ApiToken);
                obj.Result = await Operator.Instance.Current(userObj.Result.ApiToken);
            }
            obj.Tag = userObj.Tag;
            obj.Message = userObj.Message;
            return obj;
        }

        /// <summary>
        /// 用户退出登录
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public TData LoginOff([FromQuery] string token)
        {
            var obj = new TData();
            Operator.Instance.RemoveCurrent(token);
            obj.Message = "登出成功";
            return obj;
        }
        #endregion
    }
}