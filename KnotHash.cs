using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Knot_Hash
{
    class KnotHash
    {
        private List<int> list = new List<int>();
        private List<int> sequence = new List<int>();
        
        private int position=0;
        private int skipSize=0;

        private bool showHalfwayElaboration = true;

        public KnotHash(int numberMarks, List<int> sequence, bool showHalfwayElaboration=true){
            this.sequence=sequence;
            this.showHalfwayElaboration=showHalfwayElaboration;
            for(int i=0; i<numberMarks; i++){
                list.Add(i);
            }
        }

        public void Print(int subListLenght=0){
            Console.WriteLine();

            if (subListLenght==0){
                for(int i=0; i<list.Count; i++){
                    Console.Write(position==i ? "[{0}] " : "{0} ", list[i]);
                }
            }else{
                int begin = position;
                int end = (position + subListLenght-1) % list.Count;

                for(int i=0; i<list.Count; i++){
                    if (i==begin) Console.Write("(");
                    Console.Write(position==i ? "[{0}]" : "{0}", list[i]);
                    if (i==end) Console.Write(")");
                    Console.Write(" ");
                    
                }
            }

            

            Console.WriteLine();
        }


        public List<int> GetSubListToReverse(int lenght){
            List<int> subList = new List<int>();
            for(int i=position; i<position + lenght; i++){
                subList.Add(list[i % list.Count]); 
            }
            return subList;
        }

        public void Reverse(int lenght){
            List<int> subListToReverse = GetSubListToReverse(lenght);
            if (lenght==0) return;
            int index=lenght-1;
            for(int i=position; i<position + lenght; i++){
                list[i % list.Count] = subListToReverse[index];    
                index--;
            }
        }

        public void SetNextPosition(int lenght){
            position += lenght + skipSize++;
            if(position>=list.Count) position-=list.Count;
        }

        public void KnotIteration(int lenght){
            if (showHalfwayElaboration) Print(lenght);
            Reverse(lenght);
            if (showHalfwayElaboration) Print(lenght);
            SetNextPosition(lenght);
            if (showHalfwayElaboration) Print(0);
        }

        public void DoKnots(int round=1){
            for (int i = 0; i < round; i++){
                sequence.ForEach(lenght => KnotIteration(lenght));
            }
            
        }

        public int GetResultPart1(){
            return list[0]*list[1];
        }

        public String GetResultPart2(){
            String hash="";
            for (int i = 0; i < 16; i++){
                hash += list.GetRange(i*16, 16).Aggregate(0, (acc, x) => acc ^ x).ToString("X2");
            }
            return hash;
        }



    }
}
