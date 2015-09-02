using UnityEngine;
using System.Collections;

public class RotationButton : MonoBehaviour 
{
	private bool _myIsPressed = false;
	private Vector3 _myMousePosition = new Vector3(-2000.0f,0.0f,0.0f);
	private Vector3 _myMouseDeltaPosition;
	
	public void OnPress()
	{
		_myMousePosition =  Input.mousePosition;
		_myIsPressed = true;
	}
	
	public void OnRelease()
	{
		_myIsPressed = false;
		_myMousePosition = new Vector3(-2000.0f,0.0f,0.0f);;
	}

	void FixedUpdate()
	{
		if(_myIsPressed)
		{
			if (_myMousePosition != Input.mousePosition)
			{
				_myMouseDeltaPosition = Input.mousePosition - _myMousePosition;
				transform.Rotate(0.0f, 0.0f, _myMouseDeltaPosition.x * Time.deltaTime * 10.0f); 
			}
			_myMousePosition =  Input.mousePosition;
		}
	}
}
