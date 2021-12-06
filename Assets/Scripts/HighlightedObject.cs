using System;
using UnityEngine;

public class HighlightedObject : StateMachineBehaviour
{
	public static event Action Highlighting;
	public static event Action Anhighlighting;
	
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Highlighting();
    }
	
	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Anhighlighting();
    }
}
