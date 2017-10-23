using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour {

    public GameObject enemyPrefab;
    public float generatorTimer =1.75f;


	void Start () {
       
     
	}
	
	
	void Update () {
       

    }
    

    //se dan como parametros el enemyprefab,la posición actual del generator,y quaternion.identity que es la rotación
    void createEnemy()
    {
        
        Instantiate(enemyPrefab,transform.position, Quaternion.identity);


    }
	//repite el método de CreateEnemy,que comienza con 0f el tiempo,que es inmediato y el intervalo que es cada 1.75s
    public void startGenerator()
    {
        InvokeRepeating("createEnemy", 0f, generatorTimer);
    }

    public void cancelGenerator()
    {
        CancelInvoke("createEnemy");
    }

}
