using UnityEngine;
using UnityEngine.UI;

public class Algorithm : MonoBehaviour {
    [SerializeField] Text AlgorithmText;
	
	public int SelectAlgorithm(int r) {
        AlgorithmText.text = "Algorithm for ";

		if (r % 2 == 0)
		{
			AlgorithmText.text += "r - even\n"; return 3;
		}
		else if (r % 2 == 1)
		{
			AlgorithmText.text += "r - not even\n"; return 2;
		}
		else return 0;
	}
}