namespace DIYBeers.Application.CustomExceptions;

public class NotFoundException(string message) : Exception(message)
{
}