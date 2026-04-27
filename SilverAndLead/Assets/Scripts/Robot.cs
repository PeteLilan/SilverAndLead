using UnityEngine;
using StarterAssets;
using UnityEngine.AI;
public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<FirstPersonController>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
