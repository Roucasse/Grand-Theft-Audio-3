using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject cameraSupport;
	public Rigidbody playerRigidbody;
	public Animator anim;

	private float speed = 5f;
	private float jumpSpeed = 250f;
	private float horizontalRotation = 3f;
	private float verticalRotation = 3f;

	private bool canJump = false;

	void FixedUpdate()
	{
		// Camera
		transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalRotation, 0);
		cameraSupport.transform.Rotate(-Input.GetAxis("Mouse Y") * verticalRotation, 0, 0);

		// Player movement
		playerRigidbody.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
		playerRigidbody.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		// Animation
		if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") == 0 && canJump == true)
		{
			anim.SetInteger("player_state", 1);
		}
		else if (Input.GetAxis("Horizontal") > 0 && canJump == true)
		{
			anim.SetInteger("player_state", 3);
		}
		else if (Input.GetAxis("Horizontal") < 0 && canJump == true)
		{
			anim.SetInteger("player_state", 4);
		}
		else if (canJump == true)
		{
			anim.SetInteger("player_state", 0);
		}

		// Jump
		if (Input.GetButtonDown("Jump") && canJump == true)
		{
			canJump = false;
			playerRigidbody.AddForce(transform.up * jumpSpeed * Time.deltaTime, ForceMode.Impulse);
			playerRigidbody.AddForce(transform.forward * jumpSpeed/2 * Time.deltaTime, ForceMode.Impulse);
			anim.SetInteger("player_state", 2);
		}


		// Respawn if under the map
		if (transform.position.y < -100)
		{
			transform.position = new Vector3(0, 10, 0);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		canJump = true;
	}
}
