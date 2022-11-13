namespace Structures.NetSixZero.Extension {
    internal static class RandomExtensions {
        internal static float NextSingle(this Random rnd) {
            return Convert.ToSingle(rnd.NextDouble());
        }
    }
}