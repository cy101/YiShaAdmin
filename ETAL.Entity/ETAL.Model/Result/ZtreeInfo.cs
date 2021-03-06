﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETAL.Util;

namespace ETAL.Model.Result
{
    public class ZtreeInfo
    {
        [JsonConverter(typeof(StringJsonConverter))]
        public long? id { get; set; }

        [JsonConverter(typeof(StringJsonConverter))]
        public long? pId { get; set; }

        public string name { get; set; }
    }
}
