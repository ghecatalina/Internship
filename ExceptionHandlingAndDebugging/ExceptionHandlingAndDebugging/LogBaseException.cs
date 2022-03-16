using System.Runtime.Serialization;

[Serializable]
internal class LogBaseException : ArithmeticException
{
    public LogBaseException()
    {
    }

    public LogBaseException(string? message) : base(message)
    {
    }

    public LogBaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected LogBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}