using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class AnimalFactory
    {
        public IAnimal Get(IAnimalProfile classifier)
        {
            IAnimal animal = null;

            switch (classifier.Type)
            {
                case Enums.AnimalType.Bird:
                    if (classifier.CanFly)
                    {
                        return new Parrot();
                    }

                    return new Ostrich();

                case Enums.AnimalType.Mammal:
                    if (classifier.IsPreditor)
                    {
                        return new Tiger();
                    }

                    return new Elephant();
            }

            return animal;
        }
    }
}