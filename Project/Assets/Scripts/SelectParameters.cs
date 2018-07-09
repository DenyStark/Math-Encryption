using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectParameters : MonoBehaviour {
    [SerializeField] Controller Controller;
    [SerializeField] Answer AnswerController;
    [SerializeField] ErrorConsole Error;

    List<Math.Pair> Data1, Data2;

    [SerializeField] GameObject InputMN;
    [SerializeField] Text Condition1, Condition2;
    [SerializeField] Dropdown Dropdown1, Dropdown2;
    List<Dropdown.OptionData> OptionList;
    Dropdown.OptionData Option;

	void Start () {
        Data1 = new List<Math.Pair>();
        Data2 = new List<Math.Pair>();
        HideFields();
	}

    public void SetOptions1(List<Math.Pair> newList, int Mode) {
        Data1 = newList;
        if ((Data1.Count > 0 && Data2.Count > 0) || Mode == 2 && (Data1.Count > 0 || Data2.Count > 0)) { 
            SetFields(Mode); 
            Error.RemoveError(3); 
        } else { 
            HideFields(); 
            Error.AddError(3);
        }
    }
    public void SetOptions2(List<Math.Pair> newList, int Mode) {
        Data2 = newList;
        if ((Data1.Count > 0 && Data2.Count > 0) || Mode == 2 && (Data1.Count > 0 || Data2.Count > 0)) { 
            SetFields(Mode);
            Error.RemoveError(3); 
        } else { 
            HideFields(); 
            Error.AddError(3);
        }
    }

    void SetFields(int Mode) {
        InputMN.SetActive(true);

        if (Mode == 1) {
            Condition1.text = "[k, l]: ";
            Condition2.text = "[y, b]: ";
        } else if (Mode == 2) {
            Condition1.text = "[k₁, l₁]: ";
            Condition2.text = "[k₂, l₂]: ";
        }

        SetOptions(Dropdown1, Data1); SelectOptions1();
        SetOptions(Dropdown2, Data2); SelectOptions2();

        Controller.AnswerReady = true;
    }
    public void HideFields() { 
        Dropdown1.gameObject.SetActive(false);
        Dropdown2.gameObject.SetActive(false);
        Condition1.text = string.Empty;
        Condition2.text = string.Empty;
        InputMN.SetActive(false);

        Controller.AnswerReady = false;
        AnswerController.Clear();
    }

    void SetOptions(Dropdown field, List<Math.Pair> newOptions) {
        field.gameObject.SetActive(true);
        field.options.Clear();
        OptionList = new List<Dropdown.OptionData>();

        foreach(Math.Pair option in newOptions) {
            Option = new Dropdown.OptionData();
            Option.text = "[" + option.a.ToString() + ", " + option.b.ToString() + "]";
            OptionList.Add(Option);
        }

        field.AddOptions(OptionList);
    }

    public void SelectOptions1() {
        if (Data1.Count == 0) Controller.SetParameters1(null);
        else Controller.SetParameters1(Data1[Dropdown1.value]);
    }
    public void SelectOptions2() {
        if (Data2.Count == 0) Controller.SetParameters2(null);
        else Controller.SetParameters2(Data2[Dropdown2.value]);
    }
}