using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour {
    public bool isActive;

    [SerializeField] Text AnswerText;

    public void GetAnswer(int Algorithm, int r, Math.Trio ABC, 
                          Math.Pair Var1, Math.Pair Var2, Math.Pair MN) {
        Clear();

        switch(Algorithm) {
            case 1: PrintAnswer(Algorithm1(r, ABC.A, ABC.B, ABC.C, Var1.a, Var1.b, 
                                           Var2.a, Var2.b, MN.a, MN.b), true, r); break;
            case 2: 
                if (Var1 != null) 
                    PrintAnswer(Algorithm21(r, ABC.A, ABC.B, ABC.C, Var1.a, 
                                            Var1.b, MN.a, MN.b), false, r);
                if (Var2 != null) 
                    PrintAnswer(Algorithm22(r, ABC.A, ABC.B, ABC.C, Var2.a, 
                                            Var2.b, MN.a, MN.b), false, r); break;
            case 3: 
                PrintAnswer(Algorithm3(r, ABC.A, ABC.B, ABC.C, Var1.a, Var1.b,
                                       Var2.a, Var2.b, MN.a, MN.b), true, r); break;
        }
    }

    public void Clear() { AnswerText.text = string.Empty; }

    void PrintAnswer(Math.Trio answer, bool isRPair, int r) {
        string sign = "";
        if(isRPair) sign = "±";
        AnswerText.text += "\nx = ±" + Mathf.Abs(answer.A) + 
            "\t\ty = ±" + Mathf.Abs(answer.B) + 
            "\t\tz = " + sign + answer.C;

		if(r%2 == 0 && r != 2) {
			AnswerText.text += "\nThe non-trivial solutions exist.\nFor finding them the recurrent formulas are used";
		}
    }

    Math.Trio Algorithm1(int r, int A, int B, int C, int K, 
                         int L, int Y, int b, int m, int n) {
        Math.Trio answer = new Math.Trio();

        int Part1 = 0, Part2 = 0;
        for (int i = 0; i <= r; i += 2) {
            int sign = Math.Pow(-1, i / 2);
            int CMN = Math.C(r, i);
            int PowY = Math.Pow(Y, (r - i) / 2);
            int Powb = Math.Pow(b, i / 2);
            int PowM = Math.Pow(m, r - i);
            int PowN = Math.Pow(n, i);

            Part1 += sign * CMN * PowY * Powb * PowM * PowN;
        }
        for (int i = 0; i < r; i+=2) {
            int sign = Math.Pow(-1, i / 2);
            int CMN = Math.C(r, i + 1);
            int PowY = Math.Pow(Y, (r - i - 2) / 2);
            int Powb = Math.Pow(b, i / 2);
            int PowM = Math.Pow(m, r - i - 1);
            int PowN = Math.Pow(n, i + 1);

            Part2 += sign * CMN * PowY * Powb * PowM * PowN;
        }

        answer.A = K * Part1 - B * L * Part2;                               // x
        answer.B = A * K * Part2 + L * Part1;                               // y
        answer.C = Y * Math.Pow(m, 2) + b * Math.Pow(n, 2);                 // z
       
        return answer;
    }

    Math.Trio Algorithm21(int r, int A, int B, int C, 
                          int K, int L, int m, int n) {
        Math.Trio answer = new Math.Trio();

        int Part1 = 0, Part2 = 0;

        for (int i = 0; i <= (r - 1) / 2; i++) {
            int sign = Math.Pow(-1, i);
            int CMN = Math.C(r, 2 * i + 1);
            int PowAB = Math.Pow(A * B, (r - i * 2 - 1) / 2);
            int PowM = Math.Pow(m, r - 2 * i - 1);
            int PowN = Math.Pow(n, 2 * i + 1);

            Part1 += sign * CMN * PowAB * PowM * PowN;
        }

        for (int i = 0; i <= (r - 1) / 2; i++) {
            int sign = Math.Pow(-1, i);
            int CMN = Math.C(r, 2 * i);
            int PowAB = Math.Pow(A * B, (r - i * 2 - 1) / 2);
            int PowM = Math.Pow(m, r - 2 * i);
            int PowN = Math.Pow(n, 2 * i);

            Part2 += sign * CMN * PowAB * PowM * PowN;
        }

        answer.A = K * Part1 + B * L * Part2;                               // x
        answer.B = A * K * Part2 - L * Part1;                               // y
        answer.C = A * B * Math.Pow(m, 2) + Math.Pow(n, 2);                 // z

        return answer;
    }
    Math.Trio Algorithm22(int r, int A, int B, int C, 
                          int K, int L, int m, int n) {
        Math.Trio answer = new Math.Trio();

        int Part1 = 0, Part2 = 0;

        for (int i = 0; i <= (r - 1) / 2; i++) {
            int sign = Math.Pow(-1, i);
            int CMN = Math.C(r, 2 * i + 1);
            int PowA = Math.Pow(A, (r - i * 2 - 1) / 2);
            int PowM = Math.Pow(m, r - 2 * i - 1);
            int PowB = Math.Pow(B, i);
            int PowN = Math.Pow(n, 2 * i + 1);

            Part1 += sign * CMN * PowA * PowM * PowB * PowN;
        }

        for (int i = 0; i <= (r - 1) / 2; i++) {
            int sign = Math.Pow(-1, i);
            int CMN = Math.C(r, 2 * i);
            int PowA = Math.Pow(A, (r - i * 2 - 1) / 2);
            int PowM = Math.Pow(m, r - 2 * i);
            int PowB = Math.Pow(B, i);
            int PowN = Math.Pow(n, 2 * i);

            Part2 += sign * CMN * PowA * PowM * PowB * PowN;
        }

        print("hello");

        answer.A = B * K * Part1 + L * Part2;                               // x
        answer.B = A * K * Part2 - L * Part1;                               // y
        answer.C = A * Math.Pow(m, 2) + B * Math.Pow(n, 2);                 // z

        if (GameObject.Find("Canvas/Scroll View/Viewport/Panel/Condition2").GetComponent<Condition2>().ZMultC) answer.C *= C;

        return answer;
    }

    Math.Trio Algorithm3(int r, int A, int B, int C, int K, 
                         int L, int Y, int b, int m, int n) {

        Math.Trio answer = new Math.Trio();

        print(2 * C * K * m * n);

        if (GameObject.Find("Сondition11").GetComponentInChildren<Text>().color == new Color32(39, 39, 39, 255)) {
            answer.A = (K * (Y * Math.Pow(m, 2) - b * Math.Pow(n, 2)) - 2 * B * L * m * n); 
            answer.B = (L * (Y * Math.Pow(m, 2) - b * Math.Pow(n, 2)) + 2 * A * K * m * n);
            answer.C = Y * Math.Pow(m, 2) + b * Math.Pow(n, 2);
        } else if (GameObject.Find("Сondition12").GetComponentInChildren<Text>().color == new Color32(39, 39, 39, 255)) {
            answer.C = (K * (Y * Math.Pow(m, 2) - b * Math.Pow(n, 2)) + 2 * B * L * m * n);
            answer.B = (L * (Y * Math.Pow(m, 2) - b * Math.Pow(n, 2)) + 2 * C * K * m * n);
            answer.A = Y * Math.Pow(m, 2) + b * Math.Pow(n, 2);
        } else {
            answer.C = (K * (Y * Math.Pow(m, 2) - b * Math.Pow(n, 2)) + 2 * A * L * m * n);
            answer.A = (L * (Y * Math.Pow(m, 2) - b * Math.Pow(n, 2)) + 2 * C * K * m * n);
            answer.B = Y * Math.Pow(m, 2) + b * Math.Pow(n, 2);
        }
        return answer;
    }
}