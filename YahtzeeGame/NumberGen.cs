using System;

namespace YahtzeeGame {
    public class NumberGen : IRNG {
        Random random;

        public NumberGen() {
            random = new Random();
        }

        public int Next() {
            return random.Next();
        }

        public int Next(int high) {
            return random.Next(high);
        }

        public int Next(int low, int high) {
            return random.Next(low, high);
        }
    }
}
