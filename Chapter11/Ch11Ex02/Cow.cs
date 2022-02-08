namespace Ch11Ex02
{
    public class Cow:Animal
    {
        public void Milk() => Console.WriteLine($"{name} has been milked.");
        public Cow(string newName) : base(newName) { }
    }
}
