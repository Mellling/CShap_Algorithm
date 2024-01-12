namespace StudyTest
{
    internal class ListTest
    {
        static void Main(string[] args)
        {
            // 실습 1 ~ 4
            /*List<int> list = OneToNum(10);

            foreach (int i in list) 
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();*/

            // 실습 5
            /*List<int> list = new List<int>();

            list.Add(1);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(3);

            if (list.IndexOf(2) == -1)
            {
                list.Add(2);
            }
            else 
            {
                list.Remove(2);
            }

            if (list.IndexOf(7) == -1)
            {
                list.Add(7);
            }
            else
            {
                list.Remove(7);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{ list[i]} ");
            }
            Console.WriteLine();*/

            // A++)
            Inventory inventory = new Inventory();

            inventory.AddItem("롱소드");
            inventory.AddItem("인어의 눈물");
            inventory.AddItem("초보자의 갑옷");
            inventory.ShowInventory();


            inventory.RemoveItem("롱소드");
            inventory.RemoveItem("인어의 눈물");
            inventory.RemoveItem("중급자의 갑옷");
            inventory.ShowInventory();
        }

        // 실습 1 ~ 4
        /*static public List<int> OneToNum(int num)
        {
            List<int> list = new List<int>();
            for (int i = 0; i <= num; i++) 
            {
                list.Add(i);
            }

            list.Remove(0);

            return list;
        }*/
    }

    // 실습 5
    /*public class List<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int size;

        public List() 
        {
            items = new T[DefaultCapacity];
            size = 0;
        }


        public int IndexOf(T item)
        {
            if (item == null)
            {
                for (int i = 0; i < size; i++)
                {
                    if (null == items[i])
                        return i;
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (item.Equals(items[i]))
                        return i;
                }
            }

            return -1;
        }

        public void Add(T item)
        {
            if (size >= items.Length)
            {
                int newCapacity = items.Length * 2;
                T[] newList = new T[newCapacity];
                Array.Copy(items, 0, newList, 0, size);
                items = newList;
            }

            items[size++] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                size--;
                Array.Copy(items, index + 1, items, index, size - index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public int Count { get { return size; } }
    }*/

    // A++)
    public class Inventory
    {
        private List<string> inventory;
        public Inventory() 
        {
            inventory = new List<string>();
        }

        public void AddItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"인벤토리에 아이템 \"{item}\" 을/를 넣었습니다.");
        }

        public void RemoveItem(string item)
        {
            if (inventory.Remove(item) == false)
            {
                Console.WriteLine("인벤토리 안에 해당 아이템이 존재하지 않습니다.");
            }
            else
            {
                Console.WriteLine($"인벤토리 안에서 아이템 \"{item}\" 을/를 제거했습니다.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n---------- 인벤토리 ----------");

            for (int i = 0; i < inventory.Count; i++) 
            {
                Console.WriteLine($"{i + 1}. {inventory[i]}");
            }

            Console.WriteLine("------------------------------\n");
        }
    }
}
