using UnityEngine;	/* Библиотека движка Unity */

public class StaticCube : MonoBehaviour
{
	private	Vector3		_prevPos;		/* Предыдущее положение куба */
	private	Quaternion	_prevRot;		/* Предыдущее угловое положение куба */
	
	private	bool	_created = false;	/* Признак того, что объект создан */
	private	 int	_creationFrame;		/* Номер кадра, когда был создан объект */
	
	
	private void Start()
	{
		_created = false;
	}
	
	
	private void Update()
	{
		if(!_created)
		{
			_created		= true;
			_creationFrame	= Time.frameCount;
			
			/* Запоминание положения куба */
			_prevPos = transform.position;
			_prevRot = transform.rotation;
		}
		
		if (Time.frameCount - _creationFrame > 0)
		{
			transform.position = _prevPos;
			transform.rotation = _prevRot;
		}
	}
}