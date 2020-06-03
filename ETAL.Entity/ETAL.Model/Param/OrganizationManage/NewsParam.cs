using System;
using System.Collections.Generic;
using ETAL.Model.Param.SystemManage;

namespace ETAL.Model.Param.OrganizationManage
{
    public class NewsListParam : BaseAreaParam
    {
        public string NewsTitle { get; set; }
        public int? NewsType { get; set; }
        public string NewsTag { get; set; }
    }
}
