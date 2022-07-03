using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace ListRandomizer
{
    public class RandomListGenerator
    {
        public static List<int> GetRandomIntList()
        {
            var randomList = new List<int>();

            var listSize = GetRandomInt(1, 10);

            for (int i = 0; i < listSize; i++)
            {
                randomList.Add(GetRandomInt());
            }

            return randomList;
        }


        private static int GetRandomInt(int min = int.MinValue, int max = int.MaxValue)
        {
            var pingSender = new Ping();
            var options = new PingOptions() { DontFragment = true };

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send("8.8.4.4", timeout, buffer, options);

            var randomizer = new Random((int)(reply.RoundtripTime * DateTime.Now.Millisecond * DateTime.Now.Ticks));

            var randomIntValue = randomizer.Next(min, max);

            return randomIntValue;
        }
    }
}