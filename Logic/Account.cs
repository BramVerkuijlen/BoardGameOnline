namespace Logic
{
    public class Account
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }

        public Account(int id, string name, string email)
        {
            Id = id;
            Username = name;
            Email = email;
        }
    }
}
