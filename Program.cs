using System;
using System.Collections;
using System.Collections.Generic;

namespace Advanced_Collections
{
    public class Cooking
    {
        private string recipe;
        private string ingredients;
        public string Ingredients { get; set; }
        public virtual void ShoppingList() //allow method to be overridden by child class
        {
            Console.WriteLine("Ingredients: " + ingredients);
        }
    }

    public class Baking :Cooking
    {
        //Array of equipments
        string[] equipments = new string[6];
        //using hashtable with non integral index
        Hashtable hashtable = new Hashtable();
        Stack stack = new Stack();
        Queue queue = new Queue();

        public override void ShoppingList() //override method from parent class 
        {
            Console.WriteLine("Ingredients needed: " + Ingredients);
        }
        // Method for equipment array
        public void equipmentArray()
        {
            equipments[0] = "Baking Tray";
            equipments[1] = "Cake Tin";
            equipments[2] = "Stand Mixer";
            equipments[3] = "Rolling Pin";
            equipments[4] = "Wodden Spoon";
            equipments[5] = "Bowl";
            Console.WriteLine(equipments[4]); // display value Wooden Spoon from array
            Console.WriteLine(equipments[5]);
        }
        //method for equipment HashTable
        public Hashtable equipmentHashTable()
        {
            hashtable.Add(1, "My First Value");
            hashtable.Add("second", "New entry");
            hashtable.Add(3, new object());
            hashtable.Add(4, new Baking());
            return hashtable;
        }
        public Stack eqipmentStack()
        {
            stack.Push(1);
            stack.Push("second");
            stack.Push(3);
            stack.Push(new object());
            return stack;
        }
        public Queue equipmentQueue()
        {
            queue.Enqueue(1);
            queue.Enqueue("second");
            queue.Enqueue(3);
            queue.Enqueue(new object());
            return queue;
        }
    }

    public class Frying
    {
        //System.Collection.Generics namespace
        ArrayList ls = new ArrayList();
        Dictionary<int, string> dict = new Dictionary<int, string>();
        public void InsertIntoArrayListWithError()
        {
            ls.Add(1);
            ls.Add(4.6);
            ls.Add(new Cooking());
            ls.Add(false);

            bool thirdEntry = (bool)ls[2]; // this is a runtime disaster waiting to occur
                                           // you cannot cast a cooking instance to a bool
        }
        //List<T>
        List<string> list = new List<string>();
        List<double> listd = new List<double>();
        List<Cooking> listcooking = new List<Cooking>();
        List<Baking> listbacking = new List<Baking>();

        public void InsertIntoGenerics()
        {
            list.Add("Markson");
            list.Add("5");
            list.Add("Jane");
            string firstItem = list[0];
            listcooking.Add(new Baking());
        }
        public Dictionary<int, string> equipmentDictionary()
        {
            dict.Add(1, "Myfirst Value");
            dict.Add(2, "Second Entry");
            dict.Add(3, "new object()");
            dict.Add(4, "new Baking()");
            return dict;
        }
    }

    public class Boiling
    {
        // Practice with loops
        public void TryingLoops()
        {
            int[] tenDucks = { 4, 6, 7, 8, 9, 6, 7, 6, 2, 4, 5, 6 };

            for (int i = 0; i < tenDucks.Length; i++)
            {
                Console.WriteLine("The value of tenDucks now is " + tenDucks[i]);
            }
            // Use a while loop if the number of iteration is not known
            int j = 5;
            while (j < 10)
            {
                Console.WriteLine("J less than 10 is: " + j);
                j++;
            }
            //if the loop must run at least once whatever the condition then use the do while loop
            int k = 10;
            do
            {
                Console.WriteLine("Always run at least once");
                k++;
            } while (k < 10);
            //foreach loop (you can use it with dictionary)
            foreach (var item in tenDucks)
            {
                Console.WriteLine(item);
            }
            //nested loops
            int[,] gameBoard = new int[5,7];
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int t = 0; t < gameBoard.GetLength(1); t++)
                {
                    gameBoard[i, t] = i + t;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cooking shoppingList = new Cooking();
            shoppingList.ShoppingList();
            Console.WriteLine("You need to buy these ingredients: ");
            Baking equipment = new Baking();
            Console.WriteLine("You need to use this equipment: " + equipment);
            equipment.equipmentArray();
            Hashtable ht = equipment.equipmentHashTable();
            Console.WriteLine(ht[1]);
            Console.WriteLine(ht["second"]);
            Stack st = equipment.eqipmentStack();
            Queue qu = equipment.equipmentQueue();
            Console.WriteLine(st.Peek());
            Console.WriteLine(st.Pop());
            Console.WriteLine(qu.Dequeue());
            Frying fr = new Frying();
            Dictionary<int, string> di = fr.equipmentDictionary();
            Console.WriteLine(di[1]);

            Boiling bl = new Boiling();
            bl.TryingLoops();

        }
    }
}

