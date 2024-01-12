namespace Product.Domain.Aggregates.Product.Exceptions;

public class DuplicateCommentException : Exception
{
    public DuplicateCommentException() : base(message: "Comment is duplicated")
    {
        
    }
    public DuplicateCommentException(string msg) : base(message: msg)
    {
        
    }
}