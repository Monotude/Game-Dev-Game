public interface MonsterState
{
    public abstract void EnterState(MonsterStateMachine monsterStateMachine);
    public abstract void Action(MonsterStateMachine monsterStateMachine);
}
