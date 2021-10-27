using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
  public int hitDamage = 20;

  void OnTriggerEnter(Collider opponent)
  {
    if (opponent.gameObject.CompareTag("Opponent"))
    {
      FindObjectOfType<GameManager>().Damage(hitDamage);
    }
  }
}
