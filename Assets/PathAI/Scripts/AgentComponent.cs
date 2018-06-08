using UnityEngine;
using UnityEngine.AI;

namespace Anueves1.SimpleAI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentComponent : MonoBehaviour
    {
        public Transform[] Points;
        
        public int PointIndex;
    }
}