using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndBowScript : MonoBehaviour
{
    private Rigidbody myBody;

    public float speed = 30f;
    public float deactivate_Timer = 3f;


    
    public float damage = 15f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactiveGameObject", deactivate_Timer);
    }

   

    public void Launch(Camera mainCamera)
    {

        myBody.velocity = mainCamera.transform.forward * speed;

        transform.LookAt(transform.position + myBody.velocity);

    }

    void DeactivateGameObject()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider target)
    {

        // after we touch an enemy deactivate game object
      //  if (target.tag == Tags.ENEMY_TAG)
       // {

           // target.GetComponent<HealthScript>().ApplyDamage(damage);

        //    gameObject.SetActive(false);

      //  }

    }
}
