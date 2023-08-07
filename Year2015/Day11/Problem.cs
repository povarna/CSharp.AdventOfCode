namespace Year2015.Day11;
public class Problem
{

    public string Part1(string input)
    {
        foreach (var word in Words(input)) {
            if (word.IsPasswordValid()) {
                return word;
            }
        }
        return "";
    }

    public int Part2(string input)
    {
        return -1;
    }

    private IEnumerable<string> Words(string word) {
        while(true) {
            var sb = new System.Text.StringBuilder();
            for (var i = word.Length - 1; i>=0; i--) {
                var ch = word[i] + 1;
                if(ch > 'z') {
                    ch = 'a';
                    sb.Insert(0, (char)ch);
                } else {
                    sb.Insert(0, (char)ch);
                    sb.Insert(0, word.Substring(0, i));
                    i = 0;
                }
            }
            word = sb.ToString();
            yield return word;
        }
    }

}