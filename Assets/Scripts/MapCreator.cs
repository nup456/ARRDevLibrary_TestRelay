using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] private float _interval;
    [SerializeField] private GameObject[] _map;
    [SerializeField] private int preloadCount;
    // Start is called before the first frame update
    private Vector3 position;
    private int unSafeCount = 0;
    private int lv = 0;
    void Start()
    {
        position = new Vector3(0, 0, _interval);
        unSafeCount = 0;
        lv = 0;
        for(int i = 0 ; i < preloadCount ; ++i)
        {
            LoadMap();
        }
    }
    public void LoadMap()
    {
        int mapIndex = Random.Range(0, _map.Length);

        if(unSafeCount > lv)    
        {
            mapIndex = 0;
            ++lv;
        } 
            
        if(mapIndex > 0)    
            ++unSafeCount;
        else                
            unSafeCount = 0;

        var map = _map[mapIndex];
        Instantiate(map, position, Quaternion.identity, transform);

        position.z += _interval;
    }
}
