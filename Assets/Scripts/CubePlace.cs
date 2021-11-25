using UnityEngine;
using System;

public class CubePlace : MonoBehaviour
{
	private Renderer	_rend;			/* Рендер материала для CubeToPlace */
	private bool		_canBuild;		/* Признак того, что можно строить */
	private int			_creationFrame;	/* Номер кадра, когда был создан объект */
	
	public GameObject	cubes;			/* Ссылка на родительский объект для новых кубов */
	public GameObject	pfCube;			/* Префаб для новых кубов */
	
	
	private void Start()
	{
		_canBuild = true;
		_creationFrame = 0;
		_rend = GetComponent<Renderer> ();
	}
	
	private void Update()
	{
		_rend.enabled = GameController.mouseOnScreen;
		CubeMovement(GameController.worldPosition);
		
		if	(Input.GetMouseButtonDown(0)			&&
			(Time.frameCount - _creationFrame > 70)	&&
			GameController.mouseOnScreen			&&
			_canBuild)
		{
			_creationFrame		= Time.frameCount;	/* Фиксация кадра, в котором был создан объект */
			Instantiate(pfCube, transform.position, Quaternion.identity, cubes.transform);
		}
	}
	
	/* Метод, вызываемый при соприкосновении с другим объектом */
	private void OnCollisionEnter(Collision collision)
	{
		_rend.material.color	= Color.red;
		_canBuild				= false;
	}
	
	/* Метод, вызываемый при прекращении соприкосновения с другим объектом */
	private void OnCollisionExit(Collision collision)
	{
		_rend.material.color	= Color.green;
		_canBuild				= true;
	}
	
	public void CubeMovement(Vector3 cubePosition)
	{
		Vector3 pos;
		
		pos.x = (float)Math.Round(cubePosition.x);
		pos.y = (float)Math.Round(cubePosition.y);
		pos.z = (float)Math.Round(cubePosition.z);
		
		transform.position = pos;
	}
}


	
