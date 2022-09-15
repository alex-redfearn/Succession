using System.Collections.Generic;

namespace Succession.People
{
    public interface IPerson
    {
        string Name { get; }

        decimal RoyalBlood { get; }

        List<Royal> Children { get; }
    }
}