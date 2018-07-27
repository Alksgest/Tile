using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField] AudioClip coinPickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var mainCamera = FindObjectOfType<Camera>();
        AudioSource.PlayClipAtPoint(coinPickupSFX, mainCamera.transform.position);
        Destroy(gameObject);
    }
}
