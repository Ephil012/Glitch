using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(PublicVars.health);
    }
    void Update(){
        healthBar.SetHealth(PublicVars.health);
    }

}
