using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "";
    public Sprite icon = null;
    public string kind = "";
    public float damage = 0f;
    public float health = 0f;
    public Mesh mesh = null;

    public virtual void Use()
    {
        MainPlayer.Instance.setWeapon(this);
    }
}
