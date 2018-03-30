using UnityEngine;
using System.Collections;

public class ShootableBox : MonoBehaviour {

    public Rigidbody rb;
    private int direction;


	//The box's current health point total
	public int currentHealth = 3;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        direction = -1;
    }

    private void Update()
    {
        rb.velocity = new Vector3(0, direction * 9.81f, 0);
        //rb.AddForce(transform.forward * -1.1f);
    }

    public void Damage(int damageAmount)
	{
         direction *= -1;

	}
}
