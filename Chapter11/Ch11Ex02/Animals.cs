using System.Collections;

namespace Ch11Ex02
{
    public class Animals : CollectionBase
    {
        public void Add(Animal newAnimal) => List.Add(newAnimal);

        public void Remove(Animal newAnimal) => List.Remove(newAnimal);

        public Animal this[int animalIndex]
        {
            get => (Animal)List[animalIndex];
            set => List[animalIndex] = value;
        }
    }
}
