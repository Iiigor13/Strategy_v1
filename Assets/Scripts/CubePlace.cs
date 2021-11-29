using UnityEngine;
using System;

public class CubePlace : MonoBehaviour
{
	private Renderer	_rend;
	private bool		_canBuild = true;
	
	public GameObject	cubes;		/* Ссылка на родительский объект для новых кубов */
	public GameObject	pfCube;		/* Префаб для новых кубов */
	
	
	private void Start()
	{
		_rend = GetComponent<Renderer> ();
		
		GameController.leftMouseButtonDown	+= Spawn;
		GameController.cursorOnPlane		+= Show;
		GameController.cursorOutOfPlane		+= Enable;
	}
	
	
	private void Show(Vector3 worldPosition)
	{
		_rend.enabled	= true;
		Movement(worldPosition);
	}
	
	
	private void Enable()
	{
		_rend.enabled	= false;
	}
	
	
	private void Spawn()
	{
		if (_rend.isVisible && _canBuild)
		{
			Instantiate(pfCube, transform.position, Quaternion.identity, cubes.transform);
		}
	}
	
	
	private void OnTriggerStay(Collider collider)
	{
		_rend.material.color	= Color.red;
		_canBuild				= false;
	}
	
	
	private void OnTriggerExit(Collider collider)
	{
		_rend.material.color	= Color.green;
		_canBuild				= true;
	}
	
	
	private void Movement(Vector3 position)
	{
		Vector3 resultPosition;
		
		resultPosition.x = (float)Math.Round(position.x);
		resultPosition.y = (float)Math.Round(position.y);
		resultPosition.z = (float)Math.Round(position.z);
		
		transform.position = resultPosition;
	}
}