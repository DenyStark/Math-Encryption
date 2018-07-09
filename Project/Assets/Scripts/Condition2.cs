using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Condition2 : FindVariables {

    public bool ZMultC; 

    public void UpdateTask(Math.Trio newABC, int Mode) {
        string stringAB;
        if (newABC.A == 0 && newABC.B == 0) stringAB = "AB";
        else if (newABC.A == 0) stringAB = ToString(newABC.B, "B") + "A";
        else if (newABC.B == 0) stringAB = ToString(newABC.A, "A") + "B";
        else stringAB = ToString(newABC.A*newABC.B, "AB");

        string stringBC;
        if (newABC.B == 0 && newABC.C == 0) stringBC = "BC";
        else if (newABC.B == 0) stringBC = ToString(newABC.B, "B") + "C";
        else if (newABC.C == 0) stringBC = ToString(newABC.C, "C") + "B";
        else stringBC = ToString(newABC.B * newABC.C, "BC");

        string stringAC;
        if (newABC.A == 0 && newABC.C == 0) stringAC = "AC";
        else if (newABC.A == 0) stringAC = ToString(newABC.A, "A") + "C";
        else if (newABC.C == 0) stringAC = ToString(newABC.C, "C") + "A";
        else stringAC = ToString(newABC.A * newABC.C, "AC");

        switch(Mode) {
            case 1:
                if (!newABC.HasEmpty()) {
                    FindParameters1(newABC.A * newABC.B, Mode, false);
                    Task1(stringAB);
                }
                break;
            case 2: 
                string stringC = newABC.C.ToString(); if (newABC.C == 0) stringC = "C";
                Task2(stringAB, stringC);

                if (!newABC.HasEmpty()) FindParameters2(newABC.A * newABC.B, newABC.C, Mode);
                break;
            case 32:
                Task32(stringBC);

                if (!newABC.HasEmpty()) FindParameters1(newABC.B * newABC.C, 1, true);
                break;
            case 33:
                Task33(stringAC);

                if (!newABC.HasEmpty()) FindParameters1(newABC.A * newABC.C, 1, true);
                break;
        }
	}

    void Task1(string stringAB) { Task.text = "yb = " + stringAB; }
    void Task2(string stringAB, string stringC) { Task.text = stringC + " = " + stringAB + "k₂² + l₂²"; }
    void Task32(string stringBC) { Task.text = "yb = -" + stringBC; }
    void Task33(string stringAC) { Task.text = "yb = -" + stringAC; }


    void FindParameters1(int AB, int Mode, bool signMinus) {
        List<Math.Pair> ParametersList = new List<Math.Pair>();

        for (int y = 1; AB >= Math.Pow(y, 2); y++) {
            for (int b = 1; AB >= y*b; b++) {
                if (AB == y*b ) {
                    if(signMinus) {
                        ParametersList.Add(new Math.Pair(-y, b));
                        ParametersList.Add(new Math.Pair(y, -b));
                    } else ParametersList.Add(new Math.Pair(y, b));
                }
            }
        }

        PrintResult(ParametersList);
        SelectController.SetOptions2(ParametersList, Mode);
    }
    void FindParameters2(int AB, int C, int Mode) {
        List<Math.Pair> ParametersList = new List<Math.Pair>();

        for (int k = 0; C >= AB*Math.Pow(k, 2); k++) {
            for (int l = 0; C >= AB*Math.Pow(k, 2) + Math.Pow(l, 2); l++) {
                if (C == AB*Math.Pow(k, 2) + Math.Pow(l, 2)) ParametersList.Add(new Math.Pair(k, l));
            }
        }

        PrintResult(ParametersList);
        SelectController.SetOptions2(ParametersList, Mode);

        if (ParametersList.Count == 0) FindParameters2Empty(AB, C, Mode);
    }

    void FindParameters2Empty(int AB, int C, int Mode) {
        int r = GameObject.Find("Panel").GetComponent<Controller>().r;

        string stringC = Math.Pow(C, r+1).ToString(); if (C == 0) stringC = "C";
        Task2(AB.ToString(), stringC);

        ZMultC = true;
        FindParameters2(AB, Math.Pow(C, r + 1), Mode);
    }
}