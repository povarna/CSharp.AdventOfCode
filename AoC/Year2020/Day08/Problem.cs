namespace AoC.Year2020.Day08;
public class Problem
{
    public int Part1(string input) => Run(Parse(input)).acc;

    public int Part2(string input) {
        var instructions = Patches(Parse(input));
        foreach (var instruction in instructions)
        {
            foreach (var i in instruction ) {
                Console.WriteLine($"{i}");
            }
            System.Console.WriteLine("---------");
        }

        return instructions
            .Select(Run)
            .First(res => res.terminated).acc;
    }

    Stm[] Parse(string input) =>
        input.Split("\n")
            .Select(line => line.Split(" "))
            .Select(parts => new Stm(parts[0], int.Parse(parts[1])))
            .ToArray();

    IEnumerable<Stm[]> Patches(Stm[] program) =>
        Enumerable.Range(0, program.Length)
            .Where(line => program[line].op != "acc")
            .Select(lineToPatch =>
                program.Select((stm, line) =>
                    line != lineToPatch ? stm :
                    stm.op == "jmp" ? stm with { op = "nop" } :
                    stm.op == "nop" ? stm with { op = "jmp" } :
                    throw new Exception()
                ).ToArray()
            );

    (int acc, bool terminated) Run(Stm[] program)
    {
        var (ip, acc, seen) = (0, 0, new HashSet<int>());

        while (true)
        {
            if (ip >= program.Length)
            {
                return (acc, true);
            }
            else if (seen.Contains(ip))
            {
                return (acc, false);
            }
            else
            {
                seen.Add(ip);
                var stm = program[ip];
                switch (stm.op)
                {
                    case "nop": ip++; break;
                    case "acc": ip++; acc += stm.arg; break;
                    case "jmp": ip += stm.arg; break;
                };
            }
        }
    }
}

record Stm(string op, int arg);
