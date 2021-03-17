using Phoenix.LayerBases.Entity;

namespace Phoenix.Live.Entity
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
