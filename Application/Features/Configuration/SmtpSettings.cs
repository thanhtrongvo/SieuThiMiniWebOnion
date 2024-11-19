﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Configuration
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public string SenderEmail { get; set; } // Thêm thuộc tính này nếu chưa có
        public string SenderName { get; set; }  // Thêm thuộc tính này nếu chưa có
    }
}
