using UnityEngine;

public class Condition1 : ConditionController {
    [SerializeField] Condition11 Condition11;
    [SerializeField] Condition12 Condition12;
    [SerializeField] Condition13 Condition13;

    public void UpdateTask(Math.Trio newABC) {

        switch(Algorithm) {
            case 1:
                Condition12.gameObject.SetActive(false);
                Condition13.gameObject.SetActive(false);

                Condition11.UpdateTask(newABC, 1, true);
                Condition11.SetActive(true);
                break;
            case 2: 
                Condition12.gameObject.SetActive(false);
                Condition13.gameObject.SetActive(false);

                Condition11.UpdateTask(newABC, 2, true);
                Condition11.SetActive(true);
                break;
            case 3:
                Condition12.gameObject.SetActive(true);
                Condition13.gameObject.SetActive(true);

                Condition11.UpdateTask(newABC, 1, true);
                Condition11.SetActive(true);
                Condition12.UpdateTask(newABC, false);
                Condition12.SetActive(false);
                Condition13.UpdateTask(newABC, false);
                Condition13.SetActive(false);
                break;
        }
    }

    public void SetCondition(int count) {
        switch(count) {
            case 1: 
                Condition11.SetActive(true);
                Condition11.SetParameters();
                Condition12.SetActive(false);
                Condition13.SetActive(false);
                break;
            case 2:
                Condition11.SetActive(false);
                Condition12.SetActive(true);
                Condition12.SetParameters();
                Condition13.SetActive(false);
                break;
            case 3:
                Condition11.SetActive(false);
                Condition12.SetActive(false);
                Condition13.SetActive(true);
                Condition13.SetParameters();
                break;
        }
    }
}