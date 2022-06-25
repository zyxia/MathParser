namespace TokenParser.Functions
{
    public class Param
    {
        public readonly string Name;
        public readonly float Value = 0;

        public Param(string name, float value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}