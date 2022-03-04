using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Module
{
    public class Checklist
    {
        public string Id { get; set; }
        // 标题
        public string Title { get; set; }

        // 字体图标代码
        public string IconFont { get; set; }
      
        // 颜色
        public string BackColor { get; set; }

        // 明细统计的数量
        public int Count { get; set; }
    }
}
