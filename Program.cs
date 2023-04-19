if (IsValidMarbleRun(args[0], out int segments, out int teleports, out string errorMessage))
{
    Console.WriteLine($"segments: {segments},  teleports: {teleports}");
}
else { Console.WriteLine(errorMessage); }


bool IsValidMarbleRun(string input, out int segments, out int teleports, out string errorMessage)
{
    int i = 0;
    segments = 0;
    teleports = 0;
    errorMessage = string.Empty;
    char oldChar = '0';
    var listOfpassedIndex = new List<int>();

    while (i < input.Length)
    {
        listOfpassedIndex.Add(i);
        if (input[i] == '<') { i--; segments++; oldChar = '<'; }
        else if (input[i] == '>') { i++; segments++; oldChar = '>'; }
        else
        {
            if (oldChar == '<')
            {
                while (input[i] != '>' && input[i] != '<') { i--; }
                i++;
            }
            
            string index = string.Empty;
            int a = i;

            while (input[a] != '<' && input[a] != '>')
            {
                index += input[a].ToString();
                a++;
            }

            i = ReturnNumber(index); teleports++;
        }
        if (listOfpassedIndex.Contains(i))
        {
            errorMessage = "Endless loop!!";
            segments = -1;
            teleports = -1;
            return false;
        }
    }

    return true;
}
int ReturnNumber(string number)
{
    if (number.StartsWith("0x"))
    {
        return Convert.ToInt32(number.Substring(2), 16); 
    }
    return Convert.ToInt32(number);
}