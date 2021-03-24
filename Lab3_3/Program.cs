using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab3_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string str1 = @"
Program prog1;
var s:string;
r:real;
i,j,n:integer;
begin
r:=0;
readln(s);
for i:=1 to length(s) do begin
n:=0;
for j:=1 to length(s) do begin
if s[i]=s[j] then n:=n+1;
end;
r:=r+1/n;
end;
writeln('количество различных букв = ', r:1:0);
end.";
            var regEx = new Regex(@"\D[a-zA-Z][a-zA-Z0-9]*");
            var matches = regEx.Matches(str1);
            var stringBuilder = new StringBuilder();
            foreach (var match in matches)
            {
                stringBuilder.Append(match + " ");
            }

            regEx = new Regex(@"(\b(?!Program|var|string|real|integer|begin|readln|for|to|length|do|if|then|end|writeln)\w*.)");
            matches = regEx.Matches(stringBuilder.ToString());
            stringBuilder = new StringBuilder();
            foreach (var match in matches)
            {
                var str = match.ToString();
                if (str != null && !str.Equals(" "))
                {
                    stringBuilder.Append(match);
                }
            }
            
            Console.WriteLine(stringBuilder);
        }
    }
}