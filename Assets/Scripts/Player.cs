using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
    
    public bool walk;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private Vector3 _point, _pos;
    private NavMeshAgent _agent;
    private float _dis;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Start(){
        
        _agent = this.gameObject.GetComponent<NavMeshAgent>();

        _point = transform.position;
        _point.y = 1;

    }

    private void Update(){
        
        _pos = transform.position;
        
        _dis = Vector3.Distance( _pos, _point );
        walk = _dis > .75f;

        if ( walk )
            _agent.SetDestination( _point );

        if ( !Input.GetMouseButtonDown( 0 ) ) return;
        
        var ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            
        if ( !Physics.Raycast( ray, out var hit ) ) return;
            
        _point = hit.point;
        _point.y = 1;

    }

}