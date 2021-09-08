using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuhuZoo.Models
{
    public enum Gender { Non_Binary, Female, Male, Hermaphrodite, Other }
    //Made sealed, so class cannot be inherited from.
    sealed class ZooKeeper : BaseClass
    {
        public string Email { get; set; }
        public List<Animal> AnimalListProperty { get; set; }

        public List<Animal> AnimalList = new List<Animal>();
    }
}
