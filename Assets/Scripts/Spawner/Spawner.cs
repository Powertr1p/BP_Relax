using System.Collections;
using Bubbles;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _bubblePrefab;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            var obj = Instantiate(_bubblePrefab, transform.position, Quaternion.identity);
            if (obj.TryGetComponent(out Bubble bubble))
                bubble.Init(_camera);
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}
