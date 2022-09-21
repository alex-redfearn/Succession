namespace Succession.People
{
    public interface IPerson
    {
        string Name { get; }

        // Ranges from zero to one.
        decimal RoyalBlood { get; }
    }
}