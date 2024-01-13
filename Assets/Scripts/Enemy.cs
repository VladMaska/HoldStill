using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IMinion {

    public Spectator spectator;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
    
    private NavMeshAgent _agent;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Start(){

        spectator = FindObjectOfType<Spectator>();
        var e = gameObject.GetComponent<Enemy>(); 
        
        spectator.AddMinion( e );
        
        _agent = this.gameObject.GetComponent<NavMeshAgent>();

    }

    public void Run(){

        _agent.isStopped = false;
        _agent.SetDestination( spectator.player.gameObject.transform.position );
        
    }
    
    public void Stop() => _agent.isStopped = true;

}