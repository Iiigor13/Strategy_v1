using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
	private int _cubesNumber = 0;
	public Text cubesNumber;
	public Button quitButton;
	
    private void Start()
    {
        CubePlace.CubeSpawn += ExtendCubesNumber;
    }
	
	
    private void ExtendCubesNumber()
    {
        _cubesNumber++;
		cubesNumber.text = Convert.ToString(_cubesNumber);
    }
	
	
    private void Update()
	{
		/* Debug.Log(thisQuitButton.IsThisHighlighted()); */
		/*C:\Users\Вадим\Documents\GitHub\Strategy_v1\Library\PackageCache\com.unity.ugui@1.0.0\Runtime\UI\Core\Button.cs */
	}
	
	
}

/* 		public bool IsHighlited()
		{
			return (currentSelectionState == SelectionState.Highlighted);
		} */