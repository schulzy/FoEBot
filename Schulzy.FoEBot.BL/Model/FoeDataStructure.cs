namespace Schulzy.FoEBot.BL.Model
{
    internal abstract class FoeDataStructure
    {
        protected FoeDataStructure(string name)
        {
            Name = name;
        }

        public virtual string Name { get; }
    }
}