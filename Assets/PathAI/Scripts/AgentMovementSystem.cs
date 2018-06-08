using Unity.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace Anueves1.SimpleAI
{
    public class AgentMovementSystem : ComponentSystem
    {
        private struct Filter
        {
            public NavMeshAgent Agent;

            public AgentComponent AgentComponent;
        }

        protected override void OnUpdate()
        {
            //Go trough the entities.
            foreach (var entity in GetEntities<Filter>())
            {
                //Check if the agent has already arrive at that point.
                if (HasArrived(entity.Agent))
                    entity.AgentComponent.PointIndex = GetNextIndex(entity.AgentComponent);   
                
                //Get the current point index.
                var index = entity.AgentComponent.PointIndex;

                //Get the position where the agent should be moving.
                var movePosition = entity.AgentComponent.Points[index].position;                         
                
                //Move the agent towards that position.
                entity.Agent.SetDestination(movePosition);
            }
        }

        private int GetNextIndex(AgentComponent comp)
        {
            //Get the current index.
            var currentIndex = comp.PointIndex + 1;

            //Go back to the first point if we're at the last.
            if (currentIndex > comp.Points.Length - 1)
                currentIndex = 0;

            return currentIndex;
        }

        private bool HasArrived(NavMeshAgent agent)
        {
            //Check if the agent's distance is enough for it to stop.
            var distanceCheck = (agent.remainingDistance <= agent.stoppingDistance);          
            
            return distanceCheck;
        }
    }
}