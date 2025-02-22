using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Heal : Action
{
	private BaseAI target;
	public int amount = 10;
	public override void OnStart()
	{
		target = GetComponent<BaseAI>();
		target.Heal(amount);
	}

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}