using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveorb : MonoBehaviour
{
    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0; 
    public string controlledLock = "n";
    public int laneNum =2 ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3(horizVel,GM.vertVel,4);

        if (Input.GetKeyDown(moveL) && laneNum > 1 && controlledLock == "n") {
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlledLock = "y";
        }

        if (Input.GetKeyDown(moveR) && laneNum < 3 && controlledLock == "n" ) {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlledLock = "y";
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds (.5f) ;
        horizVel = 0;
        controlledLock = "n";
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "lethal"){
            GM.zveladj=0;
            Destroy(gameObject);
            GM.lvlcompstatus="Fail";
        }

        if (other.gameObject.name == "Capsule"){
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "rampbottomtrig"){
            GM.vertVel =2;
        }

        if (other.gameObject.name == "ramptoptrig"){
            GM.vertVel =0;
        }

        if (other.gameObject.name == "exit"){
            // UnityEngine.ScenceManagement.SceneManager.LoadScene("levelcomp");
            Application.LoadLevel(1);
        }

        if (other.gameObject.name == "coin"){
            GM.coinCount =+1;
            Destroy (other.gameObject);
        }
    }
}
