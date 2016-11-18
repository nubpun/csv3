using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv3
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in ReadCsv3("airquality.csv"))
            {
                Console.WriteLine(item["Name"] + " " + item["Solar"]);                
            }
        }
        static IEnumerable<Dictionary<string, object>> ReadCsv3(string path)
        {
            using (var textReader = new StreamReader(path))
            {
                var head = textReader.ReadLine();
                var columns = head.Split(',');
                while (true)
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var str = textReader.ReadLine();
                    if (str == null)
                        yield break;
                    string[] fields = str.Split(',');
                    int pos = 0;
                    foreach (var column in columns)
                    {
                        if(fields[pos] == "NA")
                            result.Add(column.Trim('"'), null);
                        else
                            result.Add(column.Trim('"'), fields[pos]);
                        pos++;
                    }
                    yield return result;
                }
            }
        }
    }
}
