using UnityEngine;
using System.Collections.Generic;

public class Condition12 : FindVariables {
    public void UpdateTask(Math.Trio newABC, bool isActive) {
        string stringA = ToString(newABC.A, "A");
        string stringB = ToString(newABC.B, "B");
        string stringC = newABC.C.ToString(); if (newABC.C == 0) stringC = "C";

        Task.text = stringA + " = " + stringC + "k² - " + stringB + "l²";

        if(!newABC.HasEmpty()) {
            FindParameters(newABC.A, newABC.B, newABC.C, isActive);
            hasAnswers = true;
        }
	}

    void FindParameters(int A, int B, int C, bool isActive) {
        ParametersList = new List<Math.Pair>();

        for(int k = 0; k < 5000; k++) {
            for(int l = 0; l < 5000; l++) {
                if (A == C*Math.Pow(k, 2) - B*Math.Pow(l, 2)) ParametersList.Add(new Math.Pair(k, l));
            }
        }

        PrintResult(ParametersList);
        if (isActive) SetParameters();
    }

    public void SetParameters() {
        if(hasAnswers) {
            SelectController.SetOptions1(ParametersList, 1);
            Controller.SetCondition2(32);
        } 
    }
}