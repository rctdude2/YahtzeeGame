namespace YahtzeeGame {
    public interface IRNG {
        int Next();
        int Next(int high);
        int Next(int low, int high);
    }
}
