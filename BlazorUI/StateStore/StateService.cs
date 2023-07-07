namespace BlazorUI.StateStore
{
    public class StateService
    {
        public string ActiveForeman { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public event Action OnStateChange;
        public void SetActiveForeman(string activeForeman)
        {
            ActiveForeman =activeForeman;
            NotifyStateChanged();
        }
       /* public void SetAuthentication(string token,string userName,string email)
        {
            Token =token;
            UserName =userName;
            Email =email;
            NotifyStateChanged();
        }*/
        /*public void ClearAuthentication()
        {
           Email = null;
           Token = null;
           UserName = null;
           NotifyStateChanged();
        }*/
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
