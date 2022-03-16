using System.Runtime.Serialization;

[Serializable]
internal class LogArgumentException : ArithmeticException
{
    public LogArgumentException()
    {
    }

    public LogArgumentException(string? message) : base(message)
    {
    }

    public LogArgumentException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected LogArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}