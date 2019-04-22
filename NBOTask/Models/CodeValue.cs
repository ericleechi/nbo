using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NBOTask.Models
{
    public interface IDisplayAble
    {
        string Display { set; get; }
    }

    public interface ICodeValue: IDisplayAble
    {
        string Code { set; get; }
        string Value { set; get; }
    }

    public class CodeValue : ICodeValue
    {
        public CodeValue()
        {

        }
        public CodeValue(string code, string value)
        {
            this.Code = code;
            this.Value = value;
            this.Display = value;
        }
        public CodeValue(string code, string value,string display): this(code,value)
        {
            this.Display = display;
        }
        public string Code { set; get; }
        public string Value { set; get; }
        public string Display { set; get; }
    }
}
