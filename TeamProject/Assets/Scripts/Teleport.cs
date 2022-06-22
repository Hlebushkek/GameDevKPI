using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private PlayerUIManager playerUIManager;
    [SerializeField] private float transitionTime = 1f + 0.1f;
    [SerializeField] private GameObject pointTeleport;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PerformTeleportTransition(collision));
        }
    }

    private IEnumerator PerformTeleportTransition(Collider2D collision)
    {
        playerUIManager.ShowTransitionAnim();

        collision.gameObject.GetComponent<PlayerActions>().enabled = false;
        collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        yield return new WaitForSeconds(transitionTime);

        collision.gameObject.transform.position = pointTeleport.gameObject.transform.position;
        collision.gameObject.GetComponent<PlayerMovement>().enabled = true;
        collision.gameObject.GetComponent<PlayerActions>().enabled = true;

        Destroy(gameObject);
    }
}
