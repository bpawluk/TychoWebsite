using System;

namespace TychoWebsite.Shared.Persistence;

public class DocumentNotFoundException : Exception
{
    public DocumentNotFoundException() { }

    public DocumentNotFoundException(string message) : base(message) { }

    public DocumentNotFoundException(string message, Exception inner) : base(message, inner) { }
}