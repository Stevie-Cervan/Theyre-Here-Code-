using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    GameObject ChildWithAnimator;
    Animator alienAnimationController;
    GameObject target;
    public Collider boxCollider;
    public Collider sphereCollider;

    public Health_And_Damage playerHealthScript;

    void Start() {
        ChildWithAnimator = transform.GetChild(0).gameObject;
        alienAnimationController = ChildWithAnimator.GetComponent<Animator>();
        alienAnimationController.SetBool("isDead", false);

        target = GameObject.Find("FPS Character");

        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();

        playerHealthScript = target.GetComponent<Health_And_Damage>();
    }

    void Update() {
        if(health > 0){
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 5f * Time.deltaTime);
        }
        if(playerHealthScript.playerDead == true){
            Destroy(gameObject);
        }
    }

    public void TakeDamage (float amount){
        health -= amount;
        if(health <= 0f){
            Die();
        }
    }

    void Die(){
        //Destroy(gameObject);
        boxCollider.enabled = false;
        sphereCollider.enabled = false;
        alienAnimationController.SetBool("isDead", true);
        Destroy(gameObject, 4);
    }
}
