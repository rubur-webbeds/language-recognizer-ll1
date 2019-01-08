using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace language_recognizer_ll1
{
    class Program
    {
        private static readonly Stack<string> _stack = new Stack<string>();
        private const string END = "$";

        static void Main(string[] args)
        {
            var word = args[0];
            //var word = "pf$";

            Console.WriteLine("Recognizing the word {0}", word);
            var accepts = Recognize(word);

            if(accepts)
            {
               Console.WriteLine("IT WORKS!"); 
            }
            else
            {
                Console.WriteLine("SORRY BRO...");
            }
        }

        private static bool Recognize(string ent)
        {
            var _accepts = true;
            _stack.Push("P");
            int i = 0;
            while (_stack.Count != 0 && !ent[i].ToString().Equals(END) && _accepts)
            {
                if(_stack.Peek().Inside("p", "f", "i", "s", "g", "m", "h"))
                {
                    Console.WriteLine("Checking terminal symbols");
                    if(_stack.Peek().Contains(ent[i].ToString()))
                    {
                        //Console.WriteLine("top: {0}, ent[{1}]: {2}", _stack.Peek(), i, ent[i]);
                        var a = _stack.Pop();
                        i++;
                    }
                    else
                    {
                        _accepts = false;
                    }
                }
                else if(_stack.Peek().Equals("P"))
                {
                    Console.WriteLine("Checking P variable");
                    if(ent[i].ToString().Inside("p"))
                    {
                        var a = _stack.Pop();
                        _stack.Push("p", "B", "f");
                    }
                    else
                    {
                        _accepts = false;
                    }
                }
                else if(_stack.Peek().Equals("B"))
                {
                    Console.WriteLine("Checking B variable");
                    if(ent[i].ToString().Inside("i", "s", "m"))
                    {
                        var a = _stack.Pop();
                        _stack.Push("I", "B");
                    }
                    else if(ent[i].ToString().Inside("f", "g", "h"))
                    {
                        var a = _stack.Pop();
                        //Push lambda ;)
                    }
                    else 
                    {
                        _accepts = false;   
                    }
                }
                else if(_stack.Peek().Equals("I"))
                {
                    Console.WriteLine("Checking I variable");
                    if("i".Contains(ent[i]))
                    {
                        var a = _stack.Pop();
                        _stack.Push("i");
                    }
                    else if("s".Contains(ent[i]))
                    {
                        var a = _stack.Pop();
                        _stack.Push("s", "B", "g");
                    }
                    else if("m".Contains(ent[i]))
                    {
                        var a = _stack.Pop();
                        _stack.Push("m", "B", "h");
                    }
                    else
                    {
                        _accepts = false;
                    }
                }
            }
            if(!ent[i].ToString().Equals(END) || _stack.Count != 0)
            {
                _accepts = false;
                Console.WriteLine("Word: {0}, stack: {1}", ent[i], _stack.Count);
            }

            return _accepts;
        }
    }
}
