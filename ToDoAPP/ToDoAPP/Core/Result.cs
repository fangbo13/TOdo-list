using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAPP.Core
{
    public class Result<T> where T : class
    {
        /// <summary>
        /// 结果代码
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 结果消息
        /// </summary>
        public string ResultMsg { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T ResultData { get; set; }

        public bool IsSuccess => ResultCode?.Trim() == "200";
    }
}
