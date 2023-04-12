using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour {
    public GameObject Zombie;
    public bool btn_R_down;
    public bool btn_L_down;

    // Use this for initialization
    void Start () {
        btn_R_down=false;
        btn_L_down=false;
    }
	
	// Update is called once per frame
	void Update () {
        if (btn_R_down)
            Zombie.transform.Rotate(Vector3.up * Time.deltaTime * 20, Space.World);
        if (btn_L_down)
            Zombie.transform.Rotate(Vector3.up * Time.deltaTime * -20, Space.World);
    }

    public void btn_R()
    {
        btn_R_down = true;
        btn_L_down = false;
    }
    public void btn_L()
    {
        btn_R_down = false;
        btn_L_down = true;
    }

    }
