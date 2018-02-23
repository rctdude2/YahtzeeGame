namespace YahtzeeGame {
    class FakeNumberGen {
        private int[] numbers;
        private int currentNum;

        public FakeNumberGen(int[] numbers) {
            this.numbers = numbers;
            this.currentNum = 0;
        }

        public int Next() {
            if (currentNum >= numbers.Length) {
                currentNum = 0;
            }
            return numbers[currentNum++];
        }

        public int Next(int high) {
            if (currentNum >= numbers.Length) {
                currentNum = 0;
            }

            while (currentNum < numbers.Length) {
                if (numbers[currentNum] > high) {
                    currentNum++;
                }
                else {
                    return numbers[currentNum++];
                }
            }

            return high - 1;
        }

        public int Next(int low, int high) {
            if (currentNum >= numbers.Length) {
                currentNum = 0;
            }

            while (currentNum < numbers.Length) {
                if (numbers[currentNum] > high || numbers[currentNum] < low) {
                    currentNum++;
                }
                else {
                    return numbers[currentNum++];
                }
            }

            return high - 1;
        }
    }
}
