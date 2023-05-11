using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private int sceneInx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider coll) {
        if (coll.GetComponent<PlayerController>() != null) {
            SceneManager.LoadScene(sceneInx);
        }
    }
}
