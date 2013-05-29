using System;
using System.Linq;

namespace RemoteDuck.Model
{
    public class FriendlyTimeDescription
    {
        static readonly string[] Names = {"day", "hour", "minute", "second"};

        public static string Describe(TimeSpan t)
        {
            int[] ints ={t.Days,t.Hours,t.Minutes,t.Seconds};

            double[] doubles ={t.TotalDays,t.TotalHours,t.TotalMinutes,t.TotalSeconds};

            var firstNonZero = ints
                .Select((value, index) => new {value, index})
                .FirstOrDefault(x => x.value != 0);

            if (firstNonZero == null)
                return "now";

            var i = firstNonZero.index;
            var prefix = (i >= 3) ? "" : "about ";
            var quantity = (int) Math.Round(doubles[i]);
            return prefix + Tense(quantity, Names[i]) + " ago";
        }

        public static string Tense(int quantity, string noun)
        {
            return quantity == 1
                ? "1 " + noun
                : string.Format("{0} {1}s", quantity, noun);
        }
    }
}