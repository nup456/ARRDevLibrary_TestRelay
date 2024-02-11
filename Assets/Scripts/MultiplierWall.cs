using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MultiplierWall : MonoBehaviour
{
    [SerializeField] private int multiplierNum;
    [SerializeField] private GameObject _duplicated;
    private TextMeshPro _tmp;
    
    void Start()
    {
        _tmp = GetComponentInChildren<TextMeshPro>();
        _tmp.text = "x" + multiplierNum;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().num *= multiplierNum;
            for (int i = 0; i < multiplierNum; i++)
            {
                var duplicated = Instantiate(_duplicated);
                var position = other.transform.position + Random.insideUnitSphere;
                position.y = 0.75f;
                duplicated.transform.position = position;
            }
            Destroy(gameObject);
        }
    }
}
