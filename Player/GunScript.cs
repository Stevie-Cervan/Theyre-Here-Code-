using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(Input.GetKey(KeyCode.LeftShift)){
                Debug.Log("Can not shoot while running!");
            }
            else{
                Shoot();
            }
        }
    }

    void Shoot(){
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            string objectHitName = hit.transform.name;

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if(enemy != null){
                enemy.TakeDamage(damage);
            }
        }
    }
}
