using UnityEngine;

public class weapon : MonoBehaviour
{
    // Define the maximum distance for the raycast
    public float maxDistance = 10f;
    public GameObject fire;
    public GameObject impact;
    private GameObject fireinstance;
    private GameObject impactinstance;
    public AudioClip shootSound;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooting();
            Destroy(fireinstance, 0.5f);
            Destroy(impactinstance, 0.5f);
            AudioSource.PlayClipAtPoint(shootSound, transform.position);

        }


    }
    
    public void shooting()
    {
        // Declare a variable to store the hit information
        RaycastHit hit;

        // Check if the raycast from the object's position in its forward direction hits anything
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // If it hits, draw a yellow line from the origin to the hit point
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            
            // Log the name of the object that was hit
            Debug.Log("Hit: " + hit.collider.gameObject.name);

            // Log the hit point
            Debug.Log("Hit Point: " + hit.point);

            fireinstance = Instantiate(fire, transform.position, transform.rotation);

            impactinstance = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));

            Zombie enemy = hit.transform.GetComponent<Zombie>();
            if (enemy != null){

                enemy.damage(1);
            }
        }
        else
        {
            // If the raycast hits nothing, draw a yellow line for the full max distance
            Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.yellow);

            // Log that nothing was hit
            Debug.Log("Nothing hit.");
           impactinstance = Instantiate(fire, transform.position, transform.rotation);
        }
    }
}
