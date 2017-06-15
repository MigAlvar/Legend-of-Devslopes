using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	[SerializeField] private float range = 3f;
	[SerializeField] private float timeBetweenAttacks = 1f;

	private Animator anim;
	private GameObject player;
	private bool playerInRange;
	private BoxCollider[] weaponColliders;

	// Use this for initialization
	void Start () {
		weaponColliders = GetComponentsInChildren<BoxCollider>();
		player = GameManager.instance.Player;
		anim = GetComponent<Animator>();
		StartCoroutine(attack());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance (transform.position, player.transform.position) < range) {
			playerInRange = true;
		} else {
			playerInRange = false;
		}
	}

	IEnumerator attack ()
	{
		if (playerInRange && !GameManager.instance.GameOver) {
			anim.Play("Tanker_Attack");
			yield return new WaitForSeconds(timeBetweenAttacks);	
		} 
			yield return null;
			StartCoroutine(attack());
		}

	public void AttackStart(){
		foreach(var weapons in weaponColliders){
			weapons.enabled = true;
		}
	}
	public void AttackEnd(){
		foreach(var weapons in weaponColliders){
			weapons.enabled = false;
		}
	}


}