using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New character", menuName = "World/Character")]
public class Character : ScriptableObject
{
    new public string name = "Shubur";
    public float health = 100f;
    public float maxHealth = 100f;
    public float speed = 3f;
    public float coolDown = 3f;
    public bool isDead = false;
}
