using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
  public int startHealth = 100;
  private int currentHealth;
  public int damage;

  // Start is called before the first frame update
  void Start()
  {
    currentHealth = startHealth;
  }

  // Update is called once per frame
  void Update()
  {}

  void OnTriggerEnter(Collider opponent)
  {
    if (opponent.gameObject.CompareTag("Player"))
    {
      currentHealth -= damage;
      if (currentHealth <= 0)
        Die();
    }
  }

  void Die()
  {
    Destroy(gameObject);
  }
}
