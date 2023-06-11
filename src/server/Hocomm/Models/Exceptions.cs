using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Models;


[Serializable]
public class HttpException : Exception
{
    public HttpException() { }
    public HttpException(string message) : base(message) { }
    public HttpException(string message, Exception inner) : base(message, inner) { }
    protected HttpException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    public HttpException(HttpStatusCode code, string message) : base(message)
    {
        StatusCode = code;
    }

    public HttpStatusCode StatusCode { get; set; }
}
