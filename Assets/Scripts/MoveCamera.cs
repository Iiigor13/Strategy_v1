using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	public	float		speed = 0.05f;	/* Скорость движения камеры */
	private	Transform	_move;			/* Переменная для операций с типом Transform */
	
	/* Метод старта игры */
	private void Start()
	{
		_move = GetComponent<Transform>();
	}
	
	/* Метод для изменений в процессе игры */
	private void Update()
	{
		Vector3		NowPos = transform.position;	/* Вектор, содержащий текущее положение камеры */
		Quaternion	NowRot = transform.rotation;	/* Кватернион, содержащий текущие углы камеры */
		float		x, y, z;						/* Переменные для записи нового положения камеры */
		
		/* Запись координат текущего полоения камеры в переменные */
		x = NowPos.x;
		y = NowPos.y;
		z = NowPos.z;
		
		if (Input.GetKey("d"))
		{
			x = x + speed;
		}
		
		if (Input.GetKey("a"))
		{
			x = x - speed;
		}
		
		if (Input.GetKey("w"))
		{
			z = z + speed;
		}
		
		if (Input.GetKey("s"))
		{
			z = z - speed;
		}
		
		_move.SetPositionAndRotation(new Vector3(x, y, z), NowRot);
	}
}