using UnityEngine;
using LitMotion;
using LitMotion.Extensions;

public class parallax : MonoBehaviour
{
    public GameObject background; // The background object
    public Vector3 startPosition; // Start position (A)
    public Vector3 endPosition; // End position (B)
    public float parallaxSpeed; // Speed of the parallax effect

    void Update()
    {
        // Move the background towards the end position
        background.transform.position = Vector3.MoveTowards(background.transform.position, endPosition, parallaxSpeed * Time.deltaTime);

        // Loop back to the start position when it reaches the end position
        if (background.transform.position == endPosition)
        {
            background.transform.position = startPosition;
        }
    }
}
