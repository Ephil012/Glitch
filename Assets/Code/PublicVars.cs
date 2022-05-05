using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVars : MonoBehaviour
{

    public static int health = 100;

    public static void Reset() {
        health = 100;
    }

    public static void DealDamage() {
        health -= 10;
    }
}
