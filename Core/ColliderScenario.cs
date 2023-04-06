namespace Core
{
    public class ColliderScenario<T, V>
    {
        protected virtual void Scenario(T firstObj, V secondObj)
        {

        }

        public void ExecuteScenario(T firstObj, V secondObj)
        {
            Scenario(firstObj, secondObj);
        }
    }
}
