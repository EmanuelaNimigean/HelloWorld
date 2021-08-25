namespace CSfeatures
{
    internal class Coffee
    {
        public string type { get;}

        public Coffee()
        {

        }

        public Coffee(string type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return type;
        }
    }
}