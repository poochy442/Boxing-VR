using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
  public int startHealth = 100;
  private int currentHealth;
  public int damage;
  public Transform target;
  public NavMeshAgent agent;
  private Animator anim;
  public float lookRadius = 20f;
  private static readonly int Speed = Animator.StringToHash("Speed");
  private static readonly int Attack1 = Animator.StringToHash("Attack");

  // Start is called before the first frame update
  void Start()
  {
    currentHealth = startHealth;
  }

  // Update is called once per frame
  void Update()
  {
    var distance = Vector3.Distance(target.position, transform.position);

    var velocity = agent.velocity.magnitude;

    if (velocity > 0.5f)
    {
      Walk();
    }

    // If inside the radius
    if (distance <= lookRadius)
    {
      // Move towards the player
      agent.SetDestination(target.position);
    }
  }

  private void Walk()
  {
    anim.SetFloat(Speed, .5f, 0.1f, Time.deltaTime);
  }

  void OnDrawGizmosSelected ()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, lookRadius);
  }

  void OnTriggerEnter(Collider opponent)
  {
    if (opponent.gameObject.CompareTag("Player"))
    {
      currentHealth -= damage;
      if (currentHealth <= 0)
        Die();

      Debug.Log(currentHealth);
    }
  }

  void Die()
  {
    Destroy(gameObject);
    Debug.Log("Die");
  }
}
