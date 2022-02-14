using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public class MapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public MapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        public struct KeyValue<K, V>
        {
            public K key { get; set; }
            public V value { get; set; }
        }
        public LinkedList<KeyValue<K, V>> Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { key = key, value = value };
            linkedList.AddLast(item);
            return linkedList;
        }
        public int GetArrayPosition(K Key)
        {
            int position = Key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public LinkedList<KeyValue<K,V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public V Get(K Key)
        {
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.key.Equals(Key))
                {
                    return item.value;
                }
            }
            return default(V);
        }
        public void Remove(K Key)
        {
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem= default(KeyValue<K,V>);
            foreach (KeyValue<K,V> item in linkedList)
            {
                if (item.key.Equals(Key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
    }
}

