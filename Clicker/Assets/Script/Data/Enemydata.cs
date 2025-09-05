using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Game/CharacterData")]
public class Enemydata : ScriptableObject
{
    public string enemyName;
    public int enemyHealth;
    public int enemyDefence;

    public void SetEnemyData(string name, int health, int defence)
    {
        enemyName = name;
        enemyHealth = health;
        enemyDefence = defence;
    }

}
