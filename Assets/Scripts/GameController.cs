using UnityEngine;

public class GameController : MonoBehaviour
{
	private	Camera	_mainCamera;
	private Vector3	_mousePos;
	private bool	_cursorOnScreen;
	
	public GameObject cubeToPlace;
	
	public delegate void PressButton();
	public static event PressButton leftMouseButtonDown;
	public static event PressButton GetKey_d;
	public static event PressButton GetKey_a;
	public static event PressButton GetKey_w;
	public static event PressButton GetKey_s;
	
	public delegate void CursorOnPlane(Vector3	worldPosition);
	public static event CursorOnPlane cursorOnPlane;
	
	public delegate void CursorOutOfPlane();
	public static event CursorOutOfPlane cursorOutOfPlane;
	
	
	private void Start()
	{
		_mainCamera	= Camera.main;
		
		leftMouseButtonDown?.Invoke();
		GetKey_d?.Invoke();
		GetKey_a?.Invoke();
		GetKey_w?.Invoke();
		GetKey_s?.Invoke();
		
		cursorOnPlane?.Invoke(new Vector3(0, 0, 0));
		cursorOutOfPlane?.Invoke();
	}
	
	
	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			leftMouseButtonDown();
		}
		
		if (Input.GetKey("d"))
		{
			GetKey_d();
		}
		
		if (Input.GetKey("a"))
		{
			GetKey_a();
		}
		
		if (Input.GetKey("w"))
		{
			GetKey_w();
		}
		
		if (Input.GetKey("s"))
		{
			GetKey_s();
		}
	}
	
	
	private void FixedUpdate()
	{
		_mousePos	= Input.mousePosition;
		
		Cursor.visible = ((_mousePos.x < 0.0) || (_mousePos.x > Screen.width) ||
						  (_mousePos.y < 0.0) || (_mousePos.y > Screen.height));
		
		var ray			= _mainCamera.ScreenPointToRay(_mousePos);
		var groundPlane	= new Plane(Vector3.up, Vector3.zero);
		
		
		if (!Cursor.visible && groundPlane.Raycast(ray, out float position))
		{
			cursorOnPlane(ray.GetPoint(position));
		}
		else
		{
			cursorOutOfPlane();
		}
		
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}