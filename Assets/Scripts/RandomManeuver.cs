using UnityEngine;
using System.Collections;

namespace Chapter.Strategy {
    public class RandomManeuver : 
        MonoBehaviour, IManeuverBehaviour { 
        
        public void Maneuver(Drone drone) {
            StartCoroutine(Rand(drone));
        }

        IEnumerator Rand(Drone drone) {
            float time;
            bool isReverse = false;
            float speed = drone.speed;

            while (true) {
                time = 0;
                Vector3 start = drone.transform.position;
                Vector3 end = Random.insideUnitSphere * drone.weavingDistance;

                while (time < speed) {
                    drone.transform.position = 
                        Vector3.Lerp(start, end, time / speed);
                    
                    time += Time.deltaTime;
                    
                    yield return null;
                }

                //time to freeze at the end point
                yield return new WaitForSeconds(0.5f);
                isReverse = !isReverse;
            }
        }
    }
}