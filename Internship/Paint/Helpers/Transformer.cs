using System.Collections.Generic;
using System.Linq;
using Paint.Shapes;

namespace Paint.Helpers
{
    public static class Transformer
    {
        public static List<House> Cast(IEnumerable<House> parameters)
        {
            return parameters.Select(pair => new House(pair.Start, pair.Middle)).ToList();
        }

        public static List<House> Cast(IEnumerable<StartMiddlePair> parameters)
        {
            return parameters.Select(pair => new House(pair.Start, pair.Middle)).ToList();
        }
    }
}