using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float moveSpeed = 10f;
	private CharacterController playControl;
	private Animator anim;

	// Use this for initialization
	void Start () {
		playControl = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		playControl.SimpleMove (moveDirection * moveSpeed);

	}
}
