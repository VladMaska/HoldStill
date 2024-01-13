using UnityEngine;
using System.Collections.Generic;

public class Spectator : MonoBehaviour {

    public Player player;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
    
    private List<IMinion> _minions = new List<IMinion>();
    private Vector3 _playerPos;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Start(){

        player = FindObjectOfType<Player>();

    }

    private void Update(){

        if ( player.walk )
            CallAll();
        else
            StopAll();

    }
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
    
    public void AddMinion( IMinion minion ) => _minions.Add( minion );
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void CallAll(){

        foreach ( var minion in _minions )
            minion.Run();

    }

    private void StopAll(){
        
        foreach ( var minion in _minions )
            minion.Stop();
        
    }
    
}

public interface IMinion {

    public void Run();

    public void Stop();

} 