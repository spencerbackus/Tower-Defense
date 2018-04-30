using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float explosion = 0f;
    public float speed = 70f;
    public int damage = 50;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}

    void HitTarget()
    {
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 2f);

        if (explosion > 0f)
            Explode();
        else
            Damage(target);

        Destroy(gameObject);
    }

    void Explode()
    {
        //Checks all colliders that overlap with this sphere
        //get an array of all colliders in the sphere
        //Function is to make it so the bullet will destroy/do damage to the enemy it hits and enemies near it
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosion);

        foreach(Collider collider in colliders)
        {
            //for each thing we've hit, see if the collider tag is equal to enemy (see if its an enemy)
            if(collider.tag == "Enemy"){
                Damage(collider.transform);
                //if its an enemy, do damage to them
            }
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null)
        {
            e.takeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        //just shows radius that the bullet explodes in in unity.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosion);
    }
}
