using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FindVariables : MonoBehaviour {
    [SerializeField] protected SelectParameters SelectController;
    [SerializeField] protected Controller Controller;


    protected List<Math.Pair> ParametersList;
    protected bool hasAnswers;

    [SerializeField] protected Text Task, Result;
    [SerializeField] protected Image Button;

    protected void PrintResult(List<Math.Pair> result) {
        Result.text = string.Empty;

        if(result.Count == 0) { Result.text = "No solutions."; return; }

        foreach(Math.Pair pair in result) {
            Result.text += "[" + pair.a.ToString() + ", " + pair.b.ToString() + "] ";
        }
    }

    protected string ToString(int number, string name) {
        if (number == 0) return name;
        else return number.ToString();
    }

    public void SetActive(bool isActive) {
        if(isActive) {
            Task.color = new Color32(39, 39, 39, 255);
            Result.color = new Color32(39, 39, 39, 255);
            Button.raycastTarget = false;
            if (hasAnswers) SelectController.SetOptions1(ParametersList, 1);
        } else {
            Task.color = new Color32(39, 39, 39, 96);
            Result.color = new Color32(39, 39, 39, 96);
            Button.raycastTarget = true;
        }
    }
}