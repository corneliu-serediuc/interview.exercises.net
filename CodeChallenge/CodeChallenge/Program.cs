// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;

string Reverse(string s) => string.Concat(s.Reverse());
int SumEven(int[] numbers) => numbers.Where(n => n % 2 == 0).Sum();
bool HasDuplicates(int[] numbers) => numbers.Distinct().Count() != numbers.Length;

char FirstUniqueChar(string s) {
    var counts = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
    return s.FirstOrDefault(c => counts[c] == 1, "_");
};

bool IsValid(string input) {
    var stack = new Stack<char>();


}

IEnumerable<int> GetIndices(int[] input, int target){
    var dict = new Dictionary<int, int>();
    for (int i=0; i<input.Count()-1; i++)
        for(int j=i; j<input.Count(); j++) {
            if(input[i] + input[j] == target) return [i,j];
        }

    return Enumerable.Empty<int>();
}

IEnumerable<int> Intersect(IEnumerable<int> collection1, IEnumerable<int> collection2){
    var hash = new HashSet<int>();
    var common = new HashSet<int>();

    foreach(var val1 in collection1)
    {
        hash.Add(val1);
    }

    foreach(var val2 in collection2)
    {
        if(!hash.Add(val2)) common.Add(val2);
    }

    return common;
}


string? LongestWord(string s) => s.Split(' ').MaxBy(w => w.Length);
int SecondMax(int[] numbers) => numbers.Distinct().Where(n => n != numbers.Max()).Max();
bool IsPalindrome(string s) => string.Equals(s.ToLowerInvariant(), string.Concat(s.Reverse()).ToLowerInvariant());
int MostFrequent(int[] numbers) => numbers.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count()).MaxBy(n => n.Value).Key;
int MissingNumber(IEnumerable<int> input) => input.OrderBy(n => n).Chunk(2).Where(c => c[1]-c[0]>1).Select(x => x[0]+1).Single();
IEnumerable<int> FindDuplicates(IEnumerable<int> input) => input.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count()).Where(x => x.Value > 1).Select(x => x.Key).ToArray();
char FirstUnique



IEnumerable<int> numbers = [4, 3, 2, 7, 8, 2, 3, 1];
var scrumbled = new int[] { 10, 5, 8, 20, 15 };
var input = new int[] { 1, 3, 3, 2, 1, 1, 3 };
var sentence = "The quick brown fox jumps over the lazy dog";

Console.WriteLine(string.Join(", ", FindDuplicates(numbers)));
// Console.WriteLine(Reverse("Hello, World!"));
// Console.WriteLine(SumEven(numbers));
// Console.WriteLine(HasDuplicates(numbers));
// Console.WriteLine(FirstUniqueChar("Hello, World of Hate!"));
// Console.WriteLine(LongestWord(sentence));
// Console.WriteLine(SecondMax(scrumbled));
// Console.WriteLine(MostFrequent(input));
// Console.WriteLine(MissingNumber(numbers));

// var limiter = new RateLimiter(5, TimeSpan.FromSeconds(1));
// Parallel.For(0, 10, i =>
// {
//     if (limiter.TryRequest())
//     {
//         Console.WriteLine($"Request {i} processed.");
//     }
//     else
//     {
//         Console.WriteLine($"Request {i} rejected.");
//     }
// });