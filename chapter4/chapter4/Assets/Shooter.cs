using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    const int SphereCandyFrequency = 3;

    int sampleCandyCount;

    public GameObject[] candyPrefabs;
    public GameObject[] candySquarePrefabs;
    public GameObject candyHolder;
    public float shotSpeed;
    public float shotTorque;
    public float baseWidth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) Shot();
	}

    GameObject SampleCandy(){
        GameObject prefab = null;
        if (sampleCandyCount % SphereCandyFrequency == 0){
            int index = Random.Range(0, candyPrefabs.Length);
            prefab = candyPrefabs[index];
        } else {
            int index = Random.Range(0, candySquarePrefabs.Length);
            prefab = candySquarePrefabs[index];
        }

        sampleCandyCount++;

        return prefab;
    }

    public void Shot() {
        GameObject candy = (GameObject)Instantiate(candyPrefab, transform.position, Quaternion.identity);

        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotSpeed);
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));
    }
}
