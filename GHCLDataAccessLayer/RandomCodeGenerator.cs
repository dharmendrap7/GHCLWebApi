﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHCLDataAccessLayer
{
    public static class RandomCodeGenerator
    {
        // Generate a random number between two numbers  
        public static int  RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size  
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        // Generate a random password  
        public static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();            
            builder.Append(RandomNumber(100000, 999999));            
            return builder.ToString();
        }

        // Generate a random password  
        public static string RandomQuestionCodeGenerator()
        {
            StringBuilder questionCode = new StringBuilder();
            questionCode.Append(RandomString(4, false));
            questionCode.Append(RandomNumber(100000, 999999));            
            return questionCode.ToString();
        }

    }
}
