using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour {
    [SerializeField] Text C, r, AB;
	
    public void UpdateTask(int newR, Math.Trio newABC) {
        string stringR = newR.ToString(); if (newR == 0) stringR = "r";

        string stringA = ToString(newABC.A, "A");
        string stringB = ToString(newABC.B, "B");
        string stringC = ToString(newABC.C, "C");

        C.text = stringC + "z";
        r.text = stringR;
        AB.text = " = " + stringA + "x² + " + stringB + "y²";
	}

    string ToString(int number, string name) {
        if (number == 0) return name;
        else if (number == 1) return string.Empty;
        else return number.ToString();
    }
}