using UnityEngine;
using System.Collections;

public class BULLET_ThermalDet : MonoBehaviour {

	float lifespan = 3.0f;
	float total = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;

		if(lifespan <= 0) {
			Explode();
		}
		if (total == 14) {
			Debug.Log ("Game Exit");
			Application.Quit ();
		}

	}

	void OnCollisionEnter(Collision collision){
		
		if (collision.gameObject.tag == "Enemy") {
			Destroy(collision.gameObject);
			Destroy(gameObject);
			total++;
		}

	}

	void Explode(){
		Destroy(gameObject);
	}

}



