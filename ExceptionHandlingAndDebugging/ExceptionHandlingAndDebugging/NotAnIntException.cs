using System.Runtime.Serialization;

[Serializable]
internal class NotAnIntException : Exception
{
    public NotAnIntException()
    {
    }

    public NotAnIntException(string? message) : base(message)
    {
    }

    public NotAnIntException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NotAnIntException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}