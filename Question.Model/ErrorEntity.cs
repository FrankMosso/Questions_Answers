using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Model
{
    public class ErrorEntity
    {
        public ErrorEntity(string _exception, string _message) 
        {
            ExceptionMessage = _exception;
            Message = _message;
        }
        public string ExceptionMessage { get; set; }
        public string Message { get; set; }
    }
}
