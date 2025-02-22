using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class HealthCheck : Conditional
{
    private BaseAI target;

    public enum CheckMode { Percentage, Amount }
    public CheckMode checkMode = CheckMode.Percentage;

    public float percentageThreshold = 30;
    public float amountThreshold = 50;

    public override void OnStart()
    {
        target = GetComponent<BaseAI>();
    }

    public override TaskStatus OnUpdate()
    {
        if (target == null)
        {
            Debug.Log("Target is Null");
            return TaskStatus.Success;
        }

        bool conditionMet = checkMode == CheckMode.Percentage
            ? target.HealthPercentage() > percentageThreshold
            : target.HealthAmount() >= amountThreshold;

        return conditionMet ? TaskStatus.Success : TaskStatus.Failure;
    }
}
