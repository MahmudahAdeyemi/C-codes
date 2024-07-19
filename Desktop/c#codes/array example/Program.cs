        Dictionary <int,int> mydictionary = new Dictionary<int, int> ();
        int [] arr1 = new int [] {2,3,1,3,2,4,6,7,9,2,19};
        int [] arr2 = new int [] {2,1,4,3,9,6};
        mydictionary = arr1.ToDictionary(x => x);
        foreach (var item in arr2)
        {
            if (!(mydictionary.ContainsKey(item)))
            {
                mydictionary[item] = (int)mydictionary[item] + 1;
            }
        }

        List<int> mylist = new List<int>();
        foreach (var item in mydictionary)
        {
            for (int i = 0; i < item.Value; i++)
            {
                mylist.Add(item.Key);
            }
        }
        arr1 = mylist.Select(x => x).ToArray();