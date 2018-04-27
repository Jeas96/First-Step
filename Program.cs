using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    class Program
    {
        static string wanted = "EDUARDO";
        static string coolestBoyInTown = "";
        static int WORDLENGTH = wanted.Length;
        static int WORLDLENGHT = 100;
        static string universe = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string[] world = new string[WORLDLENGHT];
        static string[] youngOnes = new string[WORLDLENGHT];
        static Random r = new Random();

        static void Main(string[] args)
        {
            InitPopulation();

            //while (wanted != coolestBoyInTown)
            //{
            //    coolestBoyInTown = GetBest();
            //}

            WantBabies();
            foreach(var item in youngOnes)
            {
              Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static void InitPopulation()
        {
            for (int i = 0; i < world.Length; i++)
            {
                world[i] = GetRandomBuddy();
            }
        }

        static string GetRandomBuddy()
        {
            string _niceBuddy = "";

            for (int i = 0; i < WORDLENGTH; i++)
            {
                _niceBuddy += universe[r.Next(0, WORDLENGTH)];
            }
            return _niceBuddy;
        }

        static string GetBest()
        {
            string _currentBest = "ZZZZZZZ";
            foreach (var item in world)
            {
                if (GetFitness(_currentBest) < GetFitness(item))
                {
                    _currentBest = item;
                }
            }
            return _currentBest;
        }

        static int GetFitness(string _buddy)
        {
            int _fitness = 0;
            for (int i = 0; i < WORDLENGTH; i++)
            {
                if (wanted[i] == _buddy[i])
                    _fitness += 50;
                else
                    _fitness += Math.Abs(wanted[i] - _buddy[i]);
            }
            return _fitness;
        }

        static void ShowMeTheBoys()
        {
            foreach (var _buddy in world)
            {
                Console.WriteLine(_buddy);
            }
        }

        static void WantBabies()
        {
            string[] _world = world.OrderBy(x => r.Next()).ToArray();
            int _genCounter = 0;
            for (int i = 0; i < world.Length-1; i++)
            {
                int rnd = r.Next(0,WORDLENGTH);
                youngOnes[_genCounter] = DoBaby(_world[i], _world[i + 1],rnd,true);
                youngOnes[_genCounter + 1] = DoBaby(_world[i + 1], _world[i], rnd,false);
                i++;
                _genCounter += 2;
            }
        }

        static string DoBaby(string x, string y, int pos,bool first)
        {
            string slice = "AA";
            if (first)
            {   
                for (int i = 0; i < pos; i++)
                {
                    slice += x[i];
                }

                for (int i = pos; i < y.Length; i++)
                {
                    slice += y[i];
                }
            }
            else
            {
                for (int i = 0; i < pos; i++)
                {
                    slice += y[i];
                }

                for (int i = pos; i < y.Length; i++)
                {
                    slice += x[i];
                }
            }
            int rnd = r.Next(0,WORDLENGTH);
            
            string nueva="";
            for(int inx = 0; inx<WORDLENGTH;inx++){
              if(rnd == inx)
              {
                nueva+= universe[r.Next(0,WORDLENGTH)];
              }
              else{
                nueva+=slice[inx];
              }
            }
            return nueva;
        }
    }
}
