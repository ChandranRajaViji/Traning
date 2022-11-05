using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string textFilepath = @"C:\Test\data (2).txt";// string.Empty;
            List<RowData> datas = new List<RowData>();
            Program program = new Program();

            using (StreamReader file = new StreamReader(textFilepath))
            {
                List<int[]> list = new List<int[]>();
                var sortColumnIndices = new[] { 1};

                List<string> lines = program.Parse(file);

                List<int[]> newList = program.GetShortByDateDataSetValue(lines);

                var shortDatefirst = newList.OrderBy(x => x[0]).ThenBy(x => x[1]).ThenBy(x => x[2]).ToList();

                List<string> results = program.GetShortByDateDataSetValueResult(shortDatefirst);


                // Write file using StreamWriter  
                using (StreamWriter writer = new StreamWriter(@"C:\Test\OutputFile_Timespan_Dataset_Value.txt"))
                {
                    foreach (var output in results)
                    {
                        writer.WriteLine(output);
                    }

                }

                var shortDatesetfirst = newList.OrderBy(x => x[1]).ThenBy(x => x[0]).ThenBy(x => x[2]).ToList();

                results = program.GetShortByDateDataSetValueResult(shortDatesetfirst);


                // Write file using StreamWriter  
                using (StreamWriter writer = new StreamWriter(@"C:\Test\OutputFile_Dataset_Timespan_Value.txt"))
                {
                    foreach (var output in results)
                    {
                        writer.WriteLine(output);
                    }

                }
                Console.ReadLine();
            }
        }

        internal List<string> Parse(StreamReader streamReader)
        {
            string ln;
            List<string> lines = new List<string>();

            while ((ln = streamReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(ln) == false)
                    lines.Add(ln);
            }

            return lines;
        }


        public List<int[]> GetShortByDateDataSetValue(List<string> lines)
        {
            List<int[]> list = new List<int[]>();
            foreach (string line in lines)
            {
                string[] split = line.Split(',');
                var value = TextParserHelper.GetTimeSpanDoubleValue(split[0]);

                if (value != -1)
                {
                    int[] s = { Convert.ToInt32(value), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]) };

                    list.Add(s);
                }
            }

            return list;
        }


        public List<string> GetShortByDateDataSetValueResult(List<int[]> lines)
        {
            List<string> results = new List<string>();

            foreach (int[] output in lines)
            {
                string timeSpan = string.Empty;
                var result = TextParserHelper.GetTimeSpanStringValueFromIntValue(output[0], timeSpan);
                results.Add(string.Format("{0},{1},{2}", result, output[1], output[2]));
            }

            return results;
        }
    }
}
