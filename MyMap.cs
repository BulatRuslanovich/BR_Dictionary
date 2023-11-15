using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class MyMap<TKey, TValue>
    {
		private int size = 100;
        private Item<TKey, TValue>[] Items;
		public MyMap()
		{
			Items = new Item<TKey, TValue>[100];
		}

		public void Add(Item<TKey, TValue> item) {
			var hash = GetHash(item.Key);

			if (Items[hash] == null) {
				Items[hash] = item;
			} else {
				var placed = false;
				for (int i = hash; i < size; ++i) {
					if (Items[i].Key.Equals(item.Key)) {
						return;
					}

					if (Items[i] == null) {
						Items[i] = item;
						placed = true;
						break;
					}
				}

				if (!placed) {
					for (int i = 0; i < hash; ++i) {
						if (Items[i].Key.Equals(item.Key)) {
							return;
						}

						if (Items[i] == null) {
							Items[i] = item;
							placed = true;
							break;
						}
					}
				}

				if (!placed) {
					throw new Exception("Map is full");
				}
			}
		}

		public void Remove(TKey key) {
			var hash = GetHash(key);

			if (Items[hash].Key.Equals(key)) {
				Items[hash] = null;
			} else {
				
			}
		}

		private int GetHash(TKey key) {
			return key.GetHashCode() % size;
		}
    }
}