using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
    [SerializeField] Task TaskController;
    [SerializeField] Algorithm AlgorithmController;
    [SerializeField] Condition1 Condition1;
    [SerializeField] Condition2 Condition2;
    [SerializeField] Answer AnswerController;
    [SerializeField] ErrorConsole Error;

    Math.Trio ABC;
    public int r;
    int Algorithm; // 1: r%2 != 0 || 2: r%2 == 0 || 3: r == 2
    Math.Pair Parameters1, Parameters2;
    Math.Pair MN;

    public bool AnswerReady;

	void Start () {
        ABC = new Math.Trio();
        MN = new Math.Pair();
	}

    public void Input_r(InputField Text) { SetVariablePlus(ref r, Text); SetR(); GetAnswer(); }
    public void Input_A(InputField Text) { SetVariablePlus(ref ABC.A, Text); SetABC(); GetAnswer(); }
    public void Input_B(InputField Text) { SetVariablePlus(ref ABC.B, Text); SetABC(); GetAnswer(); }
    public void Input_C(InputField Text) { SetVariablePlus(ref ABC.C, Text); SetABC(); GetAnswer(); }
    public void Input_m(InputField Text) { SetVariable(ref MN.a, Text); GetAnswer(); }
    public void Input_n(InputField Text) { SetVariable(ref MN.b, Text); GetAnswer(); }

    void SetABC() {
        TaskController.UpdateTask(r, ABC);

        if(Algorithm != 0) {
            Condition1.UpdateTask(ABC);

            switch(Algorithm) {
                case 1: Condition2.UpdateTask(ABC, 1); break;
                case 2: Condition2.UpdateTask(ABC, 2); break;
                case 3: Condition2.UpdateTask(ABC, 1); break;
            }
        }

        if(!ABC.HasEmpty()) Error.RemoveError(1);
    }
    void SetR() {
        TaskController.UpdateTask(r, ABC);
        Algorithm = AlgorithmController.SelectAlgorithm(r);

        Condition1.SetAlgorithm(Algorithm);

        Condition1.UpdateTask(ABC);

        switch (Algorithm) {
            case 1: Condition2.UpdateTask(ABC, 1); break;
            case 2: Condition2.UpdateTask(ABC, 2); break;
            case 3: Condition2.UpdateTask(ABC, 1); break;
        }
    }

    public void SetCondition2(int Mode) {
        Condition2.UpdateTask(ABC, Mode);
    }

    bool SetVariablePlus(ref int parameter, InputField Text) {
        int newValue = 0;

        try {
            newValue = int.Parse(Text.text);
            if (newValue <= 0) { 
                Text.text = parameter.ToString(); 
                Error.AddError(1); 
                return false; 
            }
            parameter = newValue; Text.text = parameter.ToString();
            return true;
        } catch {
            Text.text = parameter.ToString();
            Error.AddError(1); return false;
        }
    }
    bool SetVariable(ref int parameter, InputField Text) {
        int newValue = 0;

        try {
            newValue = int.Parse(Text.text);
            parameter = newValue; Text.text = parameter.ToString();
            return true;
        } catch {
            Text.text = parameter.ToString();
            Error.AddError(4); return false;
        }
    }

    void GetAnswer() {
        if (AnswerReady && !MN.HasEmpty()) AnswerController.GetAnswer(Algorithm, r, ABC, Parameters1, Parameters2, MN);
    }

    public void SetParameters1(Math.Pair newParameters1) { Parameters1 = newParameters1; GetAnswer(); }
    public void SetParameters2(Math.Pair newParameters2) { Parameters2 = newParameters2; GetAnswer(); }
}