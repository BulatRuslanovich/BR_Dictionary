using System.Collections;

namespace MyDictionary {
    public class MyMap<TKey, TValue> : IEnumerable {
        private int size = 100;
        private Item<TKey, TValue>[] Items;
        private List<TKey> Keys = new List<TKey>();
        public MyMap() {
            Items = new Item<TKey, TValue>[100];
        }

        public void Add(Item<TKey, TValue> item) {
            var hash = GetHash(item.Key);

            if (Keys.Contains(item.Key)) {
                return;
            }

            if (Items[hash] == null) {
                Keys.Add(item.Key);
                Items[hash] = item;
            } else {
                var placed = false;
                for (int i = hash; i < size; ++i) {
                    if (Items[i] == null) {
                        Keys.Add(item.Key);
                        Items[i] = item;
                        placed = true;
                        break;
                    }

                    // if (Items[i].Key.Equals(item.Key)) {
                    //     return;
                    // }
                }

                if (!placed) {
                    for (int i = 0; i < hash; ++i) {
                        if (Items[i] == null) {
                            Keys.Add(item.Key);
                            Items[i] = item;
                            placed = true;
                            break;
                        }

                        // if (Items[i].Key.Equals(item.Key)) {
                        //     return;
                        // }
                    }
                }

                if (!placed) {
                    throw new Exception("Map is full");
                }
            }
        }

        public IEnumerator GetEnumerator() {
            foreach (var item in Items) {
                if (item != null) {
                    yield return item;
                }
            }
        }

        public void Remove(TKey key) {
            var hash = GetHash(key);

            if (!Keys.Contains(key)) {
                return;
            }

            if (Items[hash] == null) {
                for (int i = 0; i < size; i++) {
                    if (Items[i].Key.Equals(key)) {
                        Items[i] = null;
                        Keys.Remove(key);
                    }
                }

                return;
            }

            if (Items[hash].Key.Equals(key)) {
                Items[hash] = null;
                Keys.Remove(key);
            } else {
                var placed = false;
                for (int i = hash; i < size; ++i) {
                    if (Items[i] == null) {
                        return;
                    }

                    if (Items[i] != null && Items[i].Key.Equals(key)) {
                        Items[hash] = null;
                        Keys.Remove(key);
                        return;
                    }
                }

                if (!placed) {
                    for (int i = 0; i < hash; ++i) {
                        if (Items[i] == null) {
                            return;
                        }

                        if (Items[i].Key.Equals(key)) {
                            Items[hash] = null;
                            Keys.Remove(key);
                            return;
                        }
                    }
                }
            }
        }

        public TValue Search(TKey key) {
            var hash = GetHash(key);

            if (!Keys.Contains(key)) {
                return default;
            }

            if (Items[hash] == null) {
                foreach (var item in Items) {
                    if (item.Key.Equals(key)) {
                        return item.Value;
                    }
                }
            }

            if (Items[hash].Key.Equals(key)) {
                return Items[hash].Value;
            } else {
                var placed = false;
                for (int i = hash; i < size; ++i) {
                    if (Items[i] == null) {
                        return default;
                    }

                    if (Items[i].Key.Equals(key)) {
                        return Items[hash].Value;
                    }
                }

                if (!placed) {
                    for (int i = 0; i < hash; ++i) {
                        if (Items[i] == null) {
                            return default;
                        }

                        if (Items[i].Key.Equals(key)) {
                            return Items[hash].Value;
                        }
                    }
                }

                return default;
            }
        }

        private int GetHash(TKey key) {
            return key.GetHashCode() % size;
        }
    }
}