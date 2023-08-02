using System;
using System.Security.Permissions;

namespace services;

public class ConcursException:Exception
{
    public ConcursException() { }

    public ConcursException(string message):base(message) { }

    public ConcursException(String message,Exception innerException):base(message,innerException){}
}