using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 100f;
	public GameController gameController;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision col) 
	{
		//Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Bullet")
		{
			//Debug.Log ("Collision");
			float damage = col.gameObject.GetComponent<DamageScript>().damageToInflict;
			DestroyObject(col.gameObject);
			//Debug.Log (damage);
			applyDamage(damage);
		}
	}

	void applyDamage(float damage){
		
		health = health - damage;
		if (health <= 0) 
		{
			//TODO add a death partical effect
			Debug.Log("AI has died");
			Destroy(this.gameObject);
		}
	}

	void OnGui(){
		GUI.Label(new Rect(80,80,50,50), "Health: ");
	}
}
