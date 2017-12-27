using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Knot_Hash
{
    class Program
    {
        const bool showHalfwayElaboration=false;

        static void Main(string[] args){
            getOutputPart1("input.txt", 256);
            getOutputPart2("input.txt");
        }


        static void getOutputPart1(String inputFilePath, int lenghtList){
            var sequence = getInputSequencePart1(inputFilePath);
            KnotHash knotHash = new KnotHash(lenghtList, sequence, showHalfwayElaboration);
            knotHash.DoKnots();
            Console.WriteLine("Part 1 Output: {0}",knotHash.GetResultPart1());
        }

        static void getOutputPart2(String inputFilePath){
            var sequence = getInputSequencePart2(inputFilePath);
            KnotHash KnotHash = new KnotHash(256, sequence, showHalfwayElaboration);
            KnotHash.DoKnots(64);
            Console.WriteLine("Part 2 Output: {0}",KnotHash.GetResultPart2());
        }

        static List<int> getInputSequencePart1(String path){
            using (StreamReader sr = new StreamReader(path)){
                while (sr.Peek() >= 0){
                    return sr.ReadLine().Split(",").Select(s => Int32.Parse(s)).ToList();
                }
            }
            return null;
        }

        static List<int> getInputSequencePart2(String path){
            using (StreamReader sr = new StreamReader(path)){
                while (sr.Peek() >= 0){
                    List<int> list = sr.ReadLine().ToCharArray().Select(c => ((int) c)).ToList();
                    list.AddRange(new int[]{17, 31, 73, 47, 23});
                    return list;
                }
            }
            return null;
        }
    }
}
