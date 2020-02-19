using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static float vertVel =0;
    public static int zveladj=1;
    public static float time;
    public static int coinCount = 0;
    public static string lvlcompstatus="";
    public float waitload = 0;

    public float zScenePos = 52; 
    public Transform bbPit;
    public Transform bbNoPit;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate (bbNoPit,new Vector3(0,1.95f,36),bbNoPit.rotation);
        Instantiate (bbNoPit,new Vector3(0,1.95f,40),bbNoPit.rotation);
        Instantiate (bbPit,new Vector3(0,1.95f,44),bbNoPit.rotation);
        Instantiate (bbPit,new Vector3(0,1.95f,48),bbNoPit.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (zScenePos < 120){
            Instantiate (bbNoPit,new Vector3(0,1.95f,zScenePos),bbNoPit.rotation);
            zScenePos +=4;
        }

        if (lvlcompstatus == "Fail") {
            waitload += Time.deltaTime;
        }

        if (waitload > 2) {
            Application.LoadLevel(1);
        }
    }
}
