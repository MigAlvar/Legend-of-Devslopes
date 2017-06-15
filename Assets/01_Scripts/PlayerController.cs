using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float moveSpeed = 10f;
	[SerializeField] private LayerMask layerMask;

	private CharacterController playControl;
	private Vector3 currentLookTarget = Vector3.zero;
	private Animator anim;

	// Use this for initialization
	void Start () {
		playControl = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (!GameManager.instance.GameOver) {
			Vector3 moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			playControl.SimpleMove (moveDirection * moveSpeed);

			if (moveDirection == Vector3.zero) {
				anim.SetBool ("isWalking", false);
			} else {
				anim.SetBool ("isWalking", true);
			}
			if (Input.GetMouseButtonDown (0)) {
				anim.Play ("SpinAttack");
			}
			if (Input.GetMouseButtonDown (1)) {
				anim.Play ("DoubleChopAttack");
			}
		}
	}

	void FixedUpdate ()
	{
		if (!GameManager.instance.GameOver) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			Debug.DrawRay(ray.origin, ray.direction * 500, Color.blue);

			if(Physics.Raycast(ray, out hit, 500, layerMask, QueryTriggerInteraction.Ignore)){
				if(hit.point != currentLookTarget){
					currentLookTarget = hit.point;
				}
				Vector3 targetPosition = new Vector3 (hit.point.x, transform.position.y,hit.point.z);
				Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
				transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);
			}

		}
	}
}
