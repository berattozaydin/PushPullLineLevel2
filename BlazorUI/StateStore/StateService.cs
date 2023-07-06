namespace BlazorUI.StateStore
{
    public class StateService
    {
        public string ActiveForeman { get; set; }

        public event Action OnStateChange;
        public void SetActiveForeman(string activeForeman)
        {
            ActiveForeman =activeForeman;
            NotifyStateChanged();
        }
        private void NotifyStateChanged() { OnStateChange?.Invoke(); }
    }
}
