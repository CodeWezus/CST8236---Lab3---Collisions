using UnityEngine;
using System.Collections;

public class RoofCollision : MonoBehaviour
{

    public GameObject roofBlocks = null;

    public void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name != "Bullet")
            return;

            //Instantiate(roofBlocks, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
}
