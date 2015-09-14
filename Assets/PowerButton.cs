using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour {

	public Button uiButton;
	public Transform swordIcon;

	private Vector3 _mySwordIconInitialPosition;
	private bool _mySwordIconReturning = false;

	private float _myShootStrength;

	private bool _myIsPressed = false;
	private bool _myDoNothing = true;

	private Color _myColorChange = new Color(1.0f,1.0f,1.0f);

	public void OnPress()
	{
		_mySwordIconInitialPosition = swordIcon.transform.localPosition;
		_myIsPressed = true;
		_myDoNothing = false;
		_mySwordIconReturning = false;
	}

	public void OnRelease()
	{
		_myIsPressed = false;
		_myDoNothing = false;
		_myColorChange.g = 1.0f;
		_myColorChange.b = 1.0f;
		uiButton.image.color = _myColorChange;
	}
	
	void FixedUpdate()
	{
		if(!_myDoNothing)
		{
			if(_myIsPressed)
			{
				if(transform.localScale.x < 5.0f)
				{
					swordIcon.transform.localPosition *= 0.98f;
					transform.localScale *= 1.02f;
					_myShootStrength = transform.localScale.x;
					_myColorChange.g *= 0.97f;
					_myColorChange.b *= 0.5f;
					uiButton.image.color = _myColorChange;
				}
				else 
				{
					transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
					_myShootStrength = 5.0f;
					_myDoNothing = true;
				}
			}
			else
			{
				if(transform.localScale.x > 1.0f)
				{
					transform.localScale *= 0.056f * _myShootStrength + 0.65f;

					if(_mySwordIconReturning)
					{
						swordIcon.transform.localPosition *= 0.96f;
					}
					else if(swordIcon.transform.localPosition.x < 1.5f*_mySwordIconInitialPosition.x)
					{
						swordIcon.transform.localPosition *= _myShootStrength * 0.7f;
					}
					else
					{
						_mySwordIconReturning = true;
					}
				}
				else 
				{
					swordIcon.transform.localPosition = _mySwordIconInitialPosition;
					transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
					_myShootStrength = 1.0f;
					_myDoNothing = true;
				}
			}
		}
	}
}
