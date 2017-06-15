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
	void Update () {
		nav.SetDestination(player.position);
	}
}
