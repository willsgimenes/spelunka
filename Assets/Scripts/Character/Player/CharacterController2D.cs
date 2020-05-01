using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float mJumpForce = 10f;
	[SerializeField] private bool mAirControl;
	[SerializeField] private int extraJumps = 1;
	[SerializeField] private float jumpTime = .3f;
	[SerializeField] private LayerMask mWhatIsGround;
	[SerializeField] private Transform mGroundCheck;
	

	private const float GroundedRadius = 1f;
	public bool mGrounded;
	private Rigidbody2D _mRigidbody2D;											
	private bool _mFacingRight = true;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private int _extraJumps;
	private bool _isJumping;
	private float _jumpTimeCounter;

	private void Awake()
	{
		_mRigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		mGrounded = Physics2D.OverlapCircle(mGroundCheck.position, GroundedRadius, mWhatIsGround);
	}

	public void Move(float move)
	{
		if (mGrounded || mAirControl)
		{
			_mRigidbody2D.velocity = new Vector2(move, _mRigidbody2D.velocity.y);

			if (move > 0 && !_mFacingRight)
			{
				Flip();
			}
			else if (move < 0 && _mFacingRight)
			{
				Flip();
			}
		}
		
	}

	public void Jump()
	{
		if (mGrounded)
		{
			_extraJumps = extraJumps;
		}

		if (mGrounded && Input.GetKeyDown(KeyCode.Space) && _extraJumps == 0)
		{
			_isJumping = true;
			_jumpTimeCounter = jumpTime;
			_mRigidbody2D.velocity = Vector2.up * mJumpForce;
		}

		if (Input.GetKey(KeyCode.Space) && _isJumping)
		{
			if (_jumpTimeCounter > 0)
			{
				_mRigidbody2D.velocity = Vector2.up * mJumpForce;
				_jumpTimeCounter -= Time.deltaTime;
			} else {
				_isJumping = false;
			}
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{    
			_isJumping = false;
		}


		if (Input.GetKeyDown(KeyCode.Space) && _extraJumps > 0)
		{
			_isJumping = true;
			_jumpTimeCounter = jumpTime;
			_mRigidbody2D.velocity = Vector2.up * mJumpForce / 3;
			_extraJumps--;
		}
	}

	private void Flip()
	{
		_mFacingRight = !_mFacingRight;

		var transform1 = transform;
		var theScale = transform1.localScale;
		theScale.x *= -1;
		transform1.localScale = theScale;
	}
	
	private void OnGUI(){
		GUI.Label(new Rect(10, 10, Screen.width, Screen.height),"Velocity: " + _mRigidbody2D.velocity);
		GUI.Label(new Rect(10, 30, Screen.width, Screen.height),"Jumping: " + !mGrounded);
		GUI.Label(new Rect(10, 50, Screen.width, Screen.height),"Coordinates: " + _mRigidbody2D.position);
	}
}