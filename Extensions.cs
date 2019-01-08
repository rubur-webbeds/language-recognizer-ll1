using System;
using System.Collections.Generic;

namespace language_recognizer_ll1
{
    public  static class Extensions
    {
        public static bool Inside(this string str, params string[] targets)
        {
            var IsInside = false;
            for (int i = 0; i < targets.Length && !IsInside; i++)
            {
                IsInside = str.Equals(targets[i]);
            }
            return IsInside;
        }

        public static void Push(this Stack<string> stack, params string[] items)
        {
            for (int i = items.Length-1; i >= 0; i--)
            {
                stack.Push(items[i]);
            }
        }
    }
}
