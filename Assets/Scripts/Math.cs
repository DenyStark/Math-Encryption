public static class Math {
    public static int C(int m, int n) {
        return (F(m, n) / F(m-n));
    }

    public static int F(int start, int end) {
        int result = 1;
        for (int i = start; i > end; i--) result *= i;
        return result;
    }
    public static int F(int start) {
        int result = 1;
        for (int i = start; i > 1; i--) result *= i;
        return result;
    }

    public static int Pow(int a, int p) {
        int result = 1;
        for (int i = 0; i < p; i++) result *= a;

        return result;
    }

    public class Pair {
        public int a = int.MinValue, b = int.MinValue;

        public Pair(int newA, int newB) { a = newA; b = newB; }
        public Pair() {}

        public bool HasEmpty() {
            if (a == int.MinValue || b == int.MinValue) return true;
            else return false;
        }
    }

    public class Trio {
        public int A, B, C;
        public Trio(int newA, int newB, int newC) { A = newA; B = newB; C = newC; }
        public Trio() {}

        public bool HasEmpty() {
            if (A == 0 || B == 0 || C == 0) return true;
            else return false;
        }
    }
}