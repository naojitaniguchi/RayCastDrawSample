using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour {
    public GameObject splashObject;
    public float rayInterval = 0.3f;
    float elaspedTime = 0 ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        elaspedTime += Time.deltaTime;
        if (elaspedTime > rayInterval)
        {
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
            {
                Vector3 pos = new Vector3(hit.point.x, hit.point.y, hit.point.z) + hit.normal * 0.1f;
                GameObject hitSplash = Instantiate(splashObject, pos, Quaternion.FromToRotation(Vector3.forward * -1.0f, hit.normal));
                float rot = Random.Range(0.0f, 360.0f);
                hitSplash.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rot);
                float scale = Random.Range(0.5f, 2.0f);
                hitSplash.transform.localScale = new Vector3(scale, scale, scale);
                //Debug.Log(hit.transform.gameObject.name);
            }
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 30.0f, Color.green, 5, false);
            elaspedTime = 0.0f;
        }
    }
}
