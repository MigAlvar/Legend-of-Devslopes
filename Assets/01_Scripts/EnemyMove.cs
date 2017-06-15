using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	[SerializeField] Transform player;

	private NavMeshAgent nav;
	private Animator anim;

	void Awake(){
		Assert.IsNotNull(player);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManager.instance.GameOver) {
			nav.SetDestination (player.position);
			//anim.Play("Tanker_Walk");
		} else {
			nav.enabled = false;
			anim.Play("Tanker_Idle");
		}
	}
}
