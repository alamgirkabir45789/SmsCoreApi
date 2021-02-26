using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Notice
    {
        public int NoticeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NoticeFile { get; set; }
    }
}
