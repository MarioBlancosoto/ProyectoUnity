using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float velocity = 2f;
    private Rigidbody2D rb2d;
	
	void Start () {
        //asignamos la velocidad y la dirección de movimiento
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.left * velocity;
	}
	
	
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D other)   {

		//colisionador,si el tag del mismo GameObject es igual a destroyer,que destruya dicho objeta al colisionar
        if (other.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);

        }
    }
}
