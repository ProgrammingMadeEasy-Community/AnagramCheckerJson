
using System.Text.Json;

namespace AnagramCheckerJson
{
    public class Program
    {
        public static void Main(string[] args)
        {
			try
			{
				var jsonFile = "C:\\Projects\\AnagramCheckerJson\\AnageamCheckerJson\\AnagramList.json";
                if (!File.Exists(jsonFile))
                {
                    Console.WriteLine("File not found");
                    return;
                }

				string jsonData = File.ReadAllText(jsonFile);
				var items = JsonSerializer.Deserialize<Anagramlist>(jsonData);

                if(items.List1.Count != items.List2.Count)
                {
                    Console.WriteLine("Invalid json.");
                    return;
                }

                for(int i = 0; i<items.List1.Count; i++)
                {
                    var result = IsAnagram(items.List1[i], items.List2[i]);
                    Console.WriteLine(items.List1[i] + " " + items.List2[i] + " = " +  result);
                }
			}
			catch (Exception ex)
			{

				throw new Exception (ex.Message);
			}

        }

        public static bool IsAnagram(string word1, string word2) 
        {
            if (word1.Length != word2.Length)
                return false;

            var chars = new Dictionary<char, int>();
            for (int i = 0; i < word1.Length; i++)
            {
                if (!chars.ContainsKey(word1[i]))
                {
                    chars.Add(word1[i], 1);  
                }
                else
                {
                    chars[word1[i]]++;
                }
            }

            for (int i = 0; i < word2.Length; i++)
            {
                if (chars.ContainsKey(word2[i]) && chars[word2[i]] > 0)
                {
                    chars[word2[i]]--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
}
