using System;
using System.Runtime.Serialization;

namespace nothinbutdotnetstore.web.core
{
  public class CommandNotRegisteredException : Exception
  {
    public IContainRequestInformation request { get; private set; }

    public CommandNotRegisteredException(IContainRequestInformation request)
    {
      this.request = request;
    }

    public CommandNotRegisteredException(string message) : base(message)
    {
    }

    public CommandNotRegisteredException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected CommandNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}