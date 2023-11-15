namespace MyDictionary
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, Map!");
			var easyMap = new MyEasyMap<int, string>
			{
				new Item<int, string>(21, "triangle"),
				new Item<int, string>(52, "represent"),
				new Item<int, string>(31, "coming"),
				new Item<int, string>(45, "muscle"),
				new Item<int, string>(15, "throughout"),
				new Item<int, string>(26, "stems"),
				new Item<int, string>(61, "told"),
				new Item<int, string>(61, "nearest"),
				new Item<int, string>(38, "again"),
				new Item<int, string>(95, "massage")
			};

			easyMap.Remove(96);
			foreach (var item in easyMap)
			{
				System.Console.WriteLine(item);
			}

			System.Console.WriteLine(easyMap.Search(21) ?? "null");
			System.Console.WriteLine(easyMap.Search(242) ?? "null");
		}
	}
}
