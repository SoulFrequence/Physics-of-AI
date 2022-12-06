using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class MoveToGoal : Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;
    public override void OnEpisodeBegin()
    {

        transform.localPosition = new Vector3(Random.Range(-7.5f, +3.8f), 0, Random.Range(-2.6f, +2.3f));

        targetTransform.localPosition = new Vector3(Random.Range(4.9f, +7.7f), 0, Random.Range(-2.7f, +1.6f));
    }

    public override void CollectObservations(VectorSensor sensor){
        
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }

  /* Código Sugerido pelo auto complete (Tem Erros)
    public override void OnActionReceived(float[] actions)
    {
         float moveX = actions.ContinuousActions[0];

         float moveZ = actions.ContinuousActions[1];

         float moveSpeed = 1f;

         transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    Código Feito no tutorial aparece com erros aqui apesar de estar bem feito
     
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];

        float moveZ = actions.ContinuousActions[1];

        float moveSpeed = 1f;

        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;

        continuousActions[0] = Input.GetAxisRaw("Horizontal");

        continuousActions[1] = Input.GetAxisRaw("Vertical");

    }*/

    private void OnTriggerEnter(Collider other)
    {

        if(other.TryGetComponent<Goal>(out Goal goal))
        {

            SetReward(1f);
            floorMeshRenderer.material = winMaterial;
            EndEpisode();

        }

        if (other.TryGetComponent<Walls>(out Walls wall))
        {
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();

        }
      
    }
}