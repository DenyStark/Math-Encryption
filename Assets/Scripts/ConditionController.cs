using UnityEngine;

public class ConditionController : MonoBehaviour {
    
    protected int Algorithm; // 1: r % 2 == 0 || 2: r % 2 == 1
	
    public void SetAlgorithm(int newAlgorithm) { Algorithm = newAlgorithm; }
}