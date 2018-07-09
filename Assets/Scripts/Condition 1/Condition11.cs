using UnityEngine;
using System.Collections.Generic;

public class Condition11 : FindVariables {
    public void UpdateTask(Math.Trio newABC, int Mode, bool isActive) {
        string stringA = ToString(newABC.A, "A");
        string stringB = ToString(newABC.B, "B");
        string stringC = newABC.C.ToString(); if (newABC.C == 0) stringC = "C";

        if(Mode == 1)      Task.text = stringC + " = " + stringA + "k² + " + stringB + "l²";
        else if(Mode == 2) Task.text = stringC + " = " + stringA + "k₁² + " + stringB + "l₁²";

        if(!newABC.HasEmpty()) {
            FindParameters(newABC.A, newABC.B, newABC.C, Mode, isActive);
            hasAnswers = true;
        } 
	}

    void FindParameters(int A, int B, int C, int Mode, bool isActive) {
        ParametersList = new List<Math.Pair>();

        for(int k = 0; C >= A*Math.Pow(k, 2); k++) {
            for(int l = 0; C >= A*Math.Pow(k, 2) + B*Math.Pow(l, 2); l++) {
                if (C == A*Math.Pow(k, 2) + B*Math.Pow(l, 2)) ParametersList.Add(new Math.Pair(k, l));
            }
        }

        PrintResult(ParametersList);
        if (isActive) SetParameters();
    }

    public void SetParameters() {
        if (hasAnswers) {
            SelectController.SetOptions1(ParametersList, 1);
            Controller.SetCondition2(1);
        }
    }
}