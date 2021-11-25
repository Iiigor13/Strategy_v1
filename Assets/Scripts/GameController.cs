using UnityEngine;

public class GameController : MonoBehaviour
{
	private	Camera	_mainCamera;	/* Ссылка на камеру */
	private Vector3	_mousePos;		/* Положение мыши на экране */
	
	public GameObject cubeToPlace;
	
	public	static Vector3	worldPosition;		/* Положение мыши на экране */
	public	static bool		mouseOnScreen;	/* Признак наличия мыши на экране игры */
	
	
	private void Start()
	{
		_mainCamera	= Camera.main;
	}
	
	private void Update()
	{
		_mousePos	= Input.mousePosition;
		
		/* Признак нахождения мыши в пределах экрана игры */
		mouseOnScreen	= ((_mousePos.x >= 0.0) && (_mousePos.x <= Screen.width) &&
						   (_mousePos.y >= 0.0) && (_mousePos.y <= Screen.height));
		
		Cursor.visible = !mouseOnScreen;
		
		var ray			= _mainCamera.ScreenPointToRay(_mousePos);
		var groundPlane	= new Plane(Vector3.up, Vector3.zero);
		
		if (mouseOnScreen && groundPlane.Raycast(ray, out float position))
		{
			worldPosition	= ray.GetPoint(position);
		}
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}