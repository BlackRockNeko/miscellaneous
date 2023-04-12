using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M : MonoBehaviour {
    public Animator amin;
    public bool zombie_walk;
    public bool zombie_attack;
    public int walk;
    public int attack;
    public int death;
    public float hp;
    public Text HPText;

    // Use this for initialization
    void Start() {
        amin = GetComponent<Animator>();
        attack = 0;
        walk = 0;
        zombie_walk = false;
        zombie_attack = false;
        hp = 100;
        }

    // Update is called once per frame
    void Update() {        
        if (zombie_walk)
        {
            walk = 1;
        }
        else
        {
            walk = 0;

        }
        amin.SetInteger("walk", walk);

        if (zombie_attack)
        {
            attack = 1;
        }
        else
        {
            attack = 0;
        }
        amin.SetInteger("attalk", attack);

        if (Input.GetMouseButtonDown(0))
        {
            hp -= 1;
            HPText.text = hp.ToString("");
        }
        if (hp<1)
            {
                death = 1;
            }
        else
        {
                death = 0;

            }
            amin.SetInteger("death", death);
        }
    
    public void btn_m()
    {
        zombie_walk = true;
        zombie_attack = false;
    }
    public void btn_a()
    {
        zombie_walk = false;
        zombie_attack = true;
    }
    public void btn_i()
    {
        zombie_walk = false;
        zombie_attack = false;
    }
    public void btn_h()
    {
        hp += 10;
        HPText.text = hp.ToString("");
    }
}