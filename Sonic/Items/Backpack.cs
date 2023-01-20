using Merlin2d.Game.Items;
using System.Collections;

namespace Sonic.Items
{
    public class Backpack : IInventory
    {
        private IItem[] items;
        private int capacity;

        public Backpack(int capacity) { 
            items = new IItem[capacity];
            this.capacity = capacity;
        }

        public void AddItem(IItem item)
        {
            for (int i = 0; i < capacity; i++) {
                if (items[i] == null)
                {
                    items[i] = item;
                    return;
                }
            }

            throw new FullInventoryException("The backpack is full");
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            foreach (IItem item in items) {
                if (item != null)
                    yield return item;
                else
                    yield break;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IItem GetItem()
        {
            return items[0];
        }

        public void RemoveItem(IItem item)
        {
            int index = Array.IndexOf(items, item);

            if (index != -1) {
                this.RemoveItem(index);
            }
        }

        public void RemoveItem(int index)
        {
            items[index] = null;
        }

        public void ShiftLeft()
        {
            IItem[] temp = new IItem[capacity];
            Array.Copy(items, 1, temp, 0, capacity - 1);
            items[items.Length - 1] = items[0];
            Array.Copy(temp, 0, items, 0, capacity);
        }

        public void ShiftRight()
        {
            IItem[] temp = new IItem[capacity];
            Array.Copy(items, 0, temp, 1, capacity - 1);
            items[0] = items[items.Length - 1];
            Array.Copy(temp, 0, items, 0, capacity);
        }
    }
}
