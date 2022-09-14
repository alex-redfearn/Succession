namespace Succession.People
{
    public class Royal : IPerson
    {
        public string Name { get; private set; }
        public decimal RoyalBlood { get; private set; }
        public IPerson Father { get; private set; }
        public IPerson Mother { get; private set; }

        public Royal(string name, IPerson father, IPerson mother)
        {
            Name = name;
            Father = father;
            Mother = mother;
            RoyalBlood = CalculateRoyalBlood(father, mother);
        }

        private decimal CalculateRoyalBlood(IPerson father, IPerson mother)
        {
            return ((father.RoyalBlood + mother.RoyalBlood) / 2);
        }
    }
}