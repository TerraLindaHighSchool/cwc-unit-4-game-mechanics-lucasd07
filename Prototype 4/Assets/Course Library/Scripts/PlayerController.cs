using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool hasPowerup;
    [SerializeField] private float speed;
    [SerializeField] private GameObject powerupIndicator;

    private Rigidbody playerRb;
    private Rigidbody enemyRigidbody;

    private GameObject focalPoint;

    private Vector3 awayFromPlayer;
    
    private float forwardInput;
    private float powerupStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        powerupStrength = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Player collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
