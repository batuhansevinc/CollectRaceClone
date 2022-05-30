using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiManager : MonoBehaviour
{
    public float radius = 2;
    public GameObject clothesParent;
    public List<GameObject> clothes = new List<GameObject>();
    public List<GameObject> style = new List<GameObject>();
    public List<Vector3> ourClothes = new List<Vector3>();
    private Animator animator;
    private NavMeshAgent agent;
    private bool haveTarget = false;
    public Vector3 targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < clothesParent.transform.childCount; i++)
        {
            clothes.Add(clothesParent.transform.GetChild(i).gameObject);
        }
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!haveTarget && clothes.Count>0)
        {
            ChooseTarget();
        }
        
    }

    void ChooseTarget() 
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Debug.Log(hitColliders[i].transform.parent);
            if (hitColliders[i].transform.parent == clothesParent)
            {
                Debug.Log("Eklendi");
                ourClothes.Add(hitColliders[i].transform.position);
            }
            foreach (GameObject clothesa in clothes)
            {
                if (Vector3.Distance(transform.position, clothesa.transform.position) <= radius)
                {
                    //clothesa.Add(ourClothes);
                }
            }
        }
        if (ourClothes.Count>0)
        {
            Debug.Log("Eklendi111");
            targetTransform = ourClothes[0];
        }
        else
        {
            int random = Random.Range(0, clothes.Count);
            targetTransform = clothes[random].transform.position;
        }

        agent.SetDestination(targetTransform);
        if (!animator.GetBool("Run"))
        {
            animator.SetBool("Run", true);
        }
        haveTarget = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == clothesParent)
        {
            
        }
    }
}
