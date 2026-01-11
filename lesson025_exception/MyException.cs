namespace MyExceptions
{
    public class NameEmptyException : Exception
    {
        public NameEmptyException() : base("Ten khong duoc rong") { }
    }

    public class AgeInvalidException : Exception
    {
        public int Age { set; get; }
        public AgeInvalidException(int _Age) : base("Tuoi khong hop le")
        {
            Age = _Age;
        }
        public void Detail()
        {
            Console.WriteLine($"Tuoi = {Age}, khong nam trong khoang [18;100]");
        }
    }
}