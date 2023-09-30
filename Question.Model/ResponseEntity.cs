using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Model
{
    public class ResponseEntity<T>
    {
        public ResponseEntity(T t, bool _isError)
        {
            result = t;
            IsError = _isError;
        }
        public ResponseEntity(T t, bool _isError, string _exceptionMessage, string _message)
        {
            result = t;
            IsError = _isError;
            Error = new ErrorEntity(_exceptionMessage, _message);
        }
        public bool IsError { get; set; }
        public T result { get; set; }
        public ErrorEntity Error { get; set; }

    }
}
