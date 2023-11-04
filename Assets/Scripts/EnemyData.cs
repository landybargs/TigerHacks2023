using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyData : ScriptableObject //Holds data that can be altered
{
    public int hp;
    public int damage;
    public float speed;
}
