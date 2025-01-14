using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    float ExpValue = 1;
    float PickUpRadius = 2;
    [SerializeField]
    private float PickUpDeleteDistance = 0.2f;
    [SerializeField]
    private float PickUpDeleteDelay = 0.3f;
    [SerializeField]
    private float PickUpMoveSpeed = 2;

    private void Start()
    {
        if (PlayerStatsCounter.PlayerStatistics.ContainsKey(BaseStats.pickUpRange))
        {
            PickUpRadius *= (PlayerStatsCounter.PlayerStatistics[BaseStats.pickUpRange] * PlayerStatValues.PickUpRangeIncreasePercentage);
        }

        this.GetComponent<CircleCollider2D>().radius = PickUpRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Pickup(collision.gameObject));
        }
    }

    private IEnumerator Pickup(GameObject player)
    {
        GetComponent<CircleCollider2D>().enabled = false;

        while (Vector3.Distance(player.transform.position,this.transform.position) > PickUpDeleteDistance)
        { 
            this.transform.Translate((player.transform.position - this.transform.position).normalized * PickUpMoveSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }

        player.GetComponent<PlayerExperience>().GainExperience(ExpValue);

        Destroy(this.gameObject, PickUpDeleteDelay);
    }
}
