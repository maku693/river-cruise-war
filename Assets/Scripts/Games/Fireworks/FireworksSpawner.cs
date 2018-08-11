using System.Collections;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject fireworksPrefab;
        [SerializeField] private Collider2D spawnArea;
        [SerializeField] private float coolDown;
        private float remainingCoolDown;
        private float deltaFromLastEmission = 0;

        private void Update()
        {
            EmitFireworksIfNecessary();
        }

        private void EmitFireworksIfNecessary()
        {
            remainingCoolDown -= Time.deltaTime;
            if (remainingCoolDown <= 0)
            {
                EmitFireworks();
                remainingCoolDown = coolDown;
            }
        }

        private void EmitFireworks()
        {
            var position = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                0
            );
            Instantiate(fireworksPrefab, position, Quaternion.identity);
        }
    }
}