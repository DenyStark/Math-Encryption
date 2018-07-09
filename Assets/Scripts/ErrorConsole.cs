using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ErrorConsole : MonoBehaviour {
    List<int> Errors;

    [SerializeField] Text ErrorField;

	void Start () {
        Errors = new List<int>();
	}
	
	public void RemoveError(int index) {
        Errors.Remove(index);
        UpdateConsole();
    }
    public void AddError(int index) {
        if (Errors.Find(x => x == index) == 0) Errors.Add(index);
        UpdateConsole();
    }

    void UpdateConsole() {
        string errorLog = "\n";

        foreach(int index in Errors) {
            switch(index) {
                case 1: errorLog += "A, B, C and r must be more than 0.\n"; break;
                case 2: errorLog += "Algorithm error."; break;
                case 3: errorLog += "Can't find parameters\n"; break;
                case 4: errorLog += "m, n can't be 0"; break;
            }
        }

        ErrorField.text = errorLog;
    }
}