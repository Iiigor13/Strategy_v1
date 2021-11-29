using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	private	Transform	_move;
	public	float		speed = 0.05f;
	
	
	private void Start()
	{
		_move = GetComponent<Transform>();
		
		GameController.GetKey_d	+= MoveRight;
		GameController.GetKey_a	+= MoveLeft;
		GameController.GetKey_w	+= MoveForward;
		GameController.GetKey_s	+= MoveBackwards;
	}
	
	
	private void MoveRight()
	{
		Vector3		position = transform.position;
		Quaternion	rotation = transform.rotation;
		
		position.x += speed;
		
		_move.SetPositionAndRotation(position, rotation);
	}
	
	
	private void MoveLeft()
	{
		Vector3		position = transform.position;
		Quaternion	rotation = transform.rotation;
		
		position.x -= speed;
		
		_move.SetPositionAndRotation(position, rotation);
	}
	
	
	private void MoveForward()
	{
		Vector3		position = transform.position;
		Quaternion	rotation = transform.rotation;
		
		position.z += speed;
		
		_move.SetPositionAndRotation(position, rotation);
	}
	
	
	private void MoveBackwards()
	{
		Vector3		position = transform.position;
		Quaternion	rotation = transform.rotation;
		
		position.z -= speed;
		
		_move.SetPositionAndRotation(position, rotation);
	}
}