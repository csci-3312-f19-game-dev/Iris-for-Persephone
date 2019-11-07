using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.0f;

    // Time when the movement started.
    private float startTime;

    public float radius = 10.0f;

    // Transforms to act as start and end markers for the journey.
    private Vector3 startMarker;
    private Vector3 endMarker = new Vector3(0.0f, 0.0f, 0.0f);

    // Total distance between the markers.
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        startMarker = new Vector3(radius * Mathf.Cos(randomAngle), radius * Mathf.Sin(randomAngle), 0.0f);
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker, endMarker);

    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        Destroy(this.gameObject);
    }
}
