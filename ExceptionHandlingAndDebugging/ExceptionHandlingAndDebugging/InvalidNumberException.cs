using System.Runtime.Serialization;

[Serializable]
internal class InvalidNumberException : NotAnIntException
{
    public InvalidNumberException()
    {
    }

    public InvalidNumberException(string? message) : base(message)
    {
    }

    public InvalidNumberException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InvalidNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}