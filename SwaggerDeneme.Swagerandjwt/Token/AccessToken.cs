﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.Swagerandjwt.Token
{
    public class AccessToken
    {
        public string Token { get; set; }  // Token Değeri
        public DateTime Expiration { get; set; } // Token geçerlilik süresi
    }
}
