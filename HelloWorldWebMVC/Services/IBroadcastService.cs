namespace HelloWorldWeb.Services
{
    public interface IBroadcastService
    {
        void NewTeamMemberAdded(string name, int id);

        void TeamMemberDeleted(int id);

        void TeamMemberEdit(string name, int id);
    }
}