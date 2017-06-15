using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class CameraFollow : MonoBehaviour {


	[SerializeField] private Transform target;
	[SerializeField] private float smoothing = 5.0f;

	private Vector3 offset;

	void Awake(){
		Assert.IsNotNull(target);
	}

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);  
	}
}
